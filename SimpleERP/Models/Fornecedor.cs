namespace SimpleERP.Models
{
    public class Fornecedor
    {
     
        public int Id { get; set; }
        public string NomeFornecedor{ get; set; } = string.Empty;
        public string RazaoSocial {  get; set; } = string.Empty;
        public string Cnpj { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Endereco { get; set; } = string.Empty;
        public string Telefone { get; set; } = string.Empty;
        public string CadastroFiscal { get; set; } = string.Empty;
    }
}
