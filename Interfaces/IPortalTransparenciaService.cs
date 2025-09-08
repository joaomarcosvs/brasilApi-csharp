using IntegraBrasilApi.Dtos;

namespace IntegraBrasilApi.Interfaces
{
    public interface IPortalTransparenciaService
    {
        Task<ResponseGenerico<CepimResponse>> ConsultarCepim(string cpfCnpj);
        Task<ResponseGenerico<PepsResponse>> ConsultarPeps(string cpfCnpj);
    }
}