using System.Net;
using System.Text.Json;
using IntegraBrasilApi.Dtos;
using Microsoft.Extensions.Configuration;

namespace IntegraBrasilApi.Rest
{
    public class PortalTransparenciaRest : IPortalTransparenciaRest
    {
        private readonly HttpClient _httpClient;

        public PortalTransparenciaRest(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;

            // Recupera a chave do appsettings.json
            var apiKey = configuration["PortalTransparencia:ApiKey"];
            if (!string.IsNullOrEmpty(apiKey))
            {
                _httpClient.DefaultRequestHeaders.Add("chave-api", apiKey);
            }
        }

        public async Task<ResponseGenerico<CepimResponse>> ConsultarCepim(string cpfCnpj)
        {
            var response = new ResponseGenerico<CepimResponse>();

            try
            {
                var request = await _httpClient.GetAsync(
                    $"https://api.portaldatransparencia.gov.br/api-de-dados/cepim?cpfCnpj={cpfCnpj}");

                response.CodigoHttp = request.StatusCode;

                if (request.IsSuccessStatusCode)
                {
                    var content = await request.Content.ReadAsStringAsync();
                    response.DadosRetorno = JsonSerializer.Deserialize<CepimResponse>(content);
                }
                else
                {
                    response.ErroRetorno = await request.Content.ReadAsStringAsync();
                }
            }
            catch (Exception ex)
            {
                response.CodigoHttp = HttpStatusCode.InternalServerError;
                response.ErroRetorno = ex.Message;
            }

            return response;
        }

        public async Task<ResponseGenerico<PepsResponse>> ConsultarPeps(string cpfCnpj)
        {
            var response = new ResponseGenerico<PepsResponse>();

            try
            {
                var request = await _httpClient.GetAsync(
                    $"https://api.portaldatransparencia.gov.br/api-de-dados/peps?cpfCnpj={cpfCnpj}");

                response.CodigoHttp = request.StatusCode;

                if (request.IsSuccessStatusCode)
                {
                    var content = await request.Content.ReadAsStringAsync();
                    response.DadosRetorno = JsonSerializer.Deserialize<PepsResponse>(content);
                }
                else
                {
                    response.ErroRetorno = await request.Content.ReadAsStringAsync();
                }
            }
            catch (Exception ex)
            {
                response.CodigoHttp = HttpStatusCode.InternalServerError;
                response.ErroRetorno = ex.Message;
            }

            return response;
        }
    }
}
