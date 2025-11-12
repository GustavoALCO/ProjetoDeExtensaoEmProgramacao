using ChatApplication.Aplication.DTOs;
using ChatApplication.Aplication.Features.Querys.Mensage;
using ChatApplication.Dommain.Interfaces.Mensage;
using ChatApplication.Dommain.Interfaces.User;
using MediatR;

namespace ChatApplication.Aplication.Features.Querys.Mensage.Handler;

public class BuscarMensagemInfoHandler : IRequestHandler<BuscarMensagemInfo, MensageDTO>
{
    private readonly IMensageRepositoryQuery _query;

    private readonly IUserRepositoryQuery _users;

    public BuscarMensagemInfoHandler(IMensageRepositoryQuery query, IUserRepositoryQuery status)
    {
        _query = query;
        _users = status;
    }

    public async Task<MensageDTO> Handle(BuscarMensagemInfo request, CancellationToken cancellationToken)
    {
        try
        {
            //Buscando os dados da Mensagem que o usuario quer o status
            var mensage = await _query.BuscarMensagemId(request.Id);

            //Instanciando Variavel da Lista para salvar os dados
            List<MensageStatusDTO> ms = new List<MensageStatusDTO>();

            //Loop para atribuir lista a lista do MensageStatus para um DTO
            foreach (var mensageStatus in mensage.MensageStatus) {

                //Busca o usuario do Id Selecionado na list
                var user = await _users.GetUserById(mensageStatus.RecibeUserId);

                //Transforma o usuario para atribuir em mensagestatusDTO
                UsersDTO users = new UsersDTO()
                {
                    UserId = user.UserId,
                    Image = user.Image,
                    Username = user.Username,
                };

                //Molda o mensageStatus em um dto
                var mensageStatusDTO = new MensageStatusDTO()
                {
                    IsReceived = mensageStatus.IsReceived,
                    ReaAt = mensageStatus.ReaAt,
                    User = users,
                };

                //Adiciona a lista o DTO de mensageStatus
                ms.Add(mensageStatusDTO);
            }

            //Monta DTO para o retorno do handler
            MensageDTO dto = new MensageDTO()
            {
                MensageId = mensage.MensageId,
                ChatId = mensage.ChatId,
                UserId = mensage.UserId,
                Content = mensage.Content,
                ImageMensage = mensage.ImageMensage,
                SendMensage = mensage.SendMensage,
                MensageStatus = ms.ToList()
            };

            //retorna valor encapsulado em um DTO
            return dto;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.ToString());
        }
    }
}
