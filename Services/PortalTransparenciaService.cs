using IntegraBrasilApi.Dtos;
using IntegraBrasilApi.Interfaces;
using IntegraBrasilApi.Rest;

namespace IntegraBrasilApi.Services
{
    public class PortalTransparenciaService : IPortalTransparenciaService
    {
        private readonly PortalTransparenciaRest _rest;

        public PortalTransparenciaService(PortalTransparenciaRest rest)
        {
            _rest = rest;
        }

        public async Task<ResponseGenerico<CepimResponse>> ConsultarCepim(string cpfCnpj)
        {
            return await _rest.ConsultarCepim(cpfCnpj);
        }

        public async Task<ResponseGenerico<PepsResponse>> ConsultarPeps(string cpfCnpj)
        {
            return await _rest.ConsultarPeps(cpfCnpj);
        }

    }
}