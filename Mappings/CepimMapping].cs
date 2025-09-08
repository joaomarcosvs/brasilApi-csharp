using IntegraBrasilApi.Dtos;
using IntegraBrasilApi.Models;

namespace IntegraBrasilApi.Mappings
{
    public static class CepimMapping
    {
        public static CepimResponse ToDto(CepimModel model)
        {
            return new CepimResponse
            {
                Nome = model.Nome,
                CpfCnpj = model.CpfCnpj,
                Situacao = model.Situacao
            };
        }
    }
}