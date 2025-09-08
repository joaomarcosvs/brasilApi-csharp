using IntegraBrasilApi.Dtos;
using IntegraBrasilApi.Models;

namespace IntegraBrasilApi.Mappings
{
    public static class PepsMapping
    {
        public static PepsResponse ToDto(PepsModel model)
        {
            return new PepsResponse
            {
                Nome = model.Nome,
                CpfCnpj = model.CpfCnpj,
                Cargo = model.Cargo
            };
        }
    }
}