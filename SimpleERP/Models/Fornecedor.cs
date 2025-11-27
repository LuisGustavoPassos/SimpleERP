namespace SimpleERP.Models
{
    public class Fornecedor
    {
     
        public int Id { get; set; }
        public string NomeFornecedor{ get; set; }
        public string RazaoSocial {  get; set; }
        public string Cnpj { get; set; }
        public string Email { get; set; }
        public string Endereco { get; set; }
        public string Telefone { get; set; }
        public string CadastroFiscal { get; set; }
    }
}
