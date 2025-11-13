using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimpleERP.Models
{
    [Table ("Usuario")]
    public class Usuario
    {
        [Display(Name = "código")]
        [Column("id")]
        [Key]
        public int Id{ get; set; }

        [Display(Name = "código")]
        [Column("Nome")]
        public string? Nome { get; set; }
    }
}
