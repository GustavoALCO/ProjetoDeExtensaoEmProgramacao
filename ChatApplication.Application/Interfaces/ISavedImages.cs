namespace ChatApplication.Application.Interfaces;

public interface ISavedImages
{
    public Task<string> UploadBase64ImagesAsync(string base64Images, int indiceContainer);

    public Task<List<string>> UploadListBase64ImagesAsync(List<string> base64Images, int indiceContainer);

    public Task DeleteImagesAsync(string imageNames, int indiceContainer);

    public Task DeleteListImagesAsync(List<string> imageNames, int indiceContainer);


}
