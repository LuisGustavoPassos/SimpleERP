namespace SimpleERP.ViewModels
{
    public class UsuarioViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Email{ get; set; } = string.Empty;
        public string Telefone { get; set; } = string.Empty;
        public string TelefoneFormatado 
        {
            get 
            {
                if (string.IsNullOrWhiteSpace(Telefone) || Telefone.Length != 11)
                    return Telefone;
               
                var ddd = Telefone.Substring(2,2);
                var parte1 = Telefone.Substring(4,5);
                var parte2 = Telefone.Substring(9,4);
                return $"+{55} ({parte1}-{parte2})";
            }
            
        }
        
    }
}
