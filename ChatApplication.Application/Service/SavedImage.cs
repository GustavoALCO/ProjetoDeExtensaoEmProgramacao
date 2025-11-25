using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using ChatApplication.Application.Interfaces;
using ChatApplication.Application.Settings;
using Microsoft.Extensions.Options;
using System.Text.RegularExpressions;

namespace ChatApplication.Application.Service;

public class SavedImage : ISavedImages
{
    private readonly BlobSettings _blobService;

    public SavedImage(IOptions<BlobSettings> configuration)
    {
        _blobService = configuration.Value;
    }

    public async Task<string> UploadBase64ImagesAsync(string base64Image, int indiceContainer)
    {
        if (string.IsNullOrWhiteSpace(base64Image))
            throw new ArgumentException("A imagem base64 está vazia.");

        // Verifica índice do container
        if (indiceContainer < 0 || indiceContainer >= _blobService.Container.Length)
            throw new ArgumentOutOfRangeException(nameof(indiceContainer), "Índice do container inválido.");

        // Detecta extensão da imagem
        var match = Regex.Match(base64Image, @"^data:image\/(?<ext>[a-zA-Z0-9]+);base64,");
        var extension = match.Success ? match.Groups["ext"].Value : "jpg";

        // Remove prefixo da string base64
        var base64Data = match.Success
            ? base64Image.Substring(match.Value.Length)
            : base64Image;

        byte[] imageBytes;

        try
        {
            imageBytes = Convert.FromBase64String(base64Data);
        }
        catch
        {
            throw new FormatException("A string Base64 não está em um formato válido.");
        }

        var fileName = $"{Guid.NewGuid()}.{extension}";

        var blobClient = new BlobClient(
            _blobService.ConnectionString,
            _blobService.Container[indiceContainer],
            fileName
        );

        using var stream = new MemoryStream(imageBytes);

        // Envia com ContentType correto
        await blobClient.UploadAsync(stream, new BlobHttpHeaders
        {
            ContentType = $"image/{extension}"
        });

        return blobClient.Uri.AbsoluteUri;
    }


    public async Task<List<string>> UploadListBase64ImagesAsync(List<string> base64Images, int indiceContainer)
    {
        List<string> imageUrls = [];

        foreach (var base64Image in base64Images)
        {

            imageUrls.Add( await UploadBase64ImagesAsync(base64Image, indiceContainer)); // Adiciona a URL da imagem à lista
        }

        return imageUrls;
        // Retorna a lista de URLs das imagens
    }


    public async Task DeleteImagesAsync(string imageNames, int indiceContainer)
    {
        var containerClient = new BlobContainerClient(_blobService.ConnectionString, _blobService.Container[indiceContainer]);
        //Conecta no blob passando o nome do container

        var imageName = GetBlobNameFromUrl(imageNames);
        //Separa apenas o id da imagem para ser apagada 

        var blobClient = containerClient.GetBlobClient(imageName);
        //Passa o Id da imagem a ser excluida

        if (await blobClient.ExistsAsync())
        {
            await blobClient.DeleteAsync();
            Console.WriteLine($"Imagem {imageName} deletada com sucesso.");
        }//Se acha ele direciona para o deleteAsync onnde vai ser apagado
        else
        {
            Console.WriteLine($"Imagem {imageName} não encontrada.");
        }//Se não achar ele envia uma mensagem no console informando que não foi achado
        
    }

    public async Task DeleteListImagesAsync(List<string> imageNames, int indiceContainer)
    {
        foreach (var UrlImage in imageNames)
        {

            await DeleteImagesAsync(UrlImage, indiceContainer);
        }
    }

    private static string GetBlobNameFromUrl(string url)
    {
        Uri uri = new(url);
        return Path.GetFileName(uri.LocalPath);
    }
}
