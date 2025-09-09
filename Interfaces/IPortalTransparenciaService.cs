using IntegraBrasilApi.Dtos;

namespace IntegraBrasilApi.Interfaces
{
    public interface IPortalTransparenciaService
    {
        Task<ResponseGenerico<List<CepimResponse>>> ConsultarCepim(string cpfCnpj);
        Task<ResponseGenerico<PepsResponse>> ConsultarPeps(string cpfCnpj);
    }
}