using IntegraBrasilApi.Dtos;

namespace IntegraBrasilApi.Rest
{
    public interface IPortalTransparenciaRest
    {
        Task<ResponseGenerico<CepimResponse>> ConsultarCepim(string cpfCnpj);
        Task<ResponseGenerico<PepsResponse>> ConsultarPeps(string cpfCnpj);
    }
}