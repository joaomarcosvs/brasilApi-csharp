namespace IntegraBrasilApi.Dtos
{
    public class OrgaoMaximo
    {
        public string codigo { get; set; }
        public string sigla { get; set; }
        public string nome { get; set; }
    }

    public class OrgaoSuperior
    {
        public string nome { get; set; }
        public string codigoSIAFI { get; set; }
        public string cnpj { get; set; }
        public string sigla { get; set; }
        public string descricaoPoder { get; set; }
        public OrgaoMaximo orgaoMaximo { get; set; }
    }

    public class PessoaJuridica
    {
        public long id { get; set; }
        public string cpfFormatado { get; set; }
        public string cnpjFormatado { get; set; }
        public string numeroInscricaoSocial { get; set; }
        public string nome { get; set; }
        public string razaoSocialReceita { get; set; }
        public string nomeFantasiaReceita { get; set; }
        public string tipo { get; set; }
    }

    public class Convenio
    {
        public string codigo { get; set; }
        public string objeto { get; set; }
        public string numero { get; set; }
    }

    public class CepimResponse
    {
        public long id { get; set; }
        public string dataReferencia { get; set; }
        public string motivo { get; set; }
        public OrgaoSuperior orgaoSuperior { get; set; }
        public PessoaJuridica pessoaJuridica { get; set; }
        public Convenio convenio { get; set; }
    }
}