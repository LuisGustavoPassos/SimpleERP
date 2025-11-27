using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimpleERP.Models
{
    public class Cliente
    {
        [Display(Name = "Código")]
        [Column("id")]
        [Key]
        public int Id { get; set; }
        public int NomeCompletoCliente { get; set; }
        public int CpfCnpj { get; set; }
        public string Endereco { get; set; }
        public string Ie { get; set; }

    }
}
