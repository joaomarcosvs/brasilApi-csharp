using IntegraBrasilApi.Dtos;

namespace IntegraBrasilApi.Rest
{
    public interface IPortalTransparenciaRest
    {
        Task<ResponseGenerico<List<CepimResponse>>> ConsultarCepim(string cpfCnpj);
        Task<ResponseGenerico<PepsResponse>> ConsultarPeps(string cpfCnpj);
    }
}