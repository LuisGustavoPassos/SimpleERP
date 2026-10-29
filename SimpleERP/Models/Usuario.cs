//estou usando a model Usuario para se comunicar apenas com o db sem influenciar view
//usuario de login
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimpleERP.Models
{
    [Table ("Usuario")]
    public class Usuario
    {
        [Display(Name = "Código")]
        [Column("id")]
        [Key]
        public int Id{ get; set; }

        [Required(ErrorMessage ="Nome inválido")]
        [Display(Name = "Nome")]
        [Column("Nome")]
        public string Nome { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email inválido")]
        [Display(Name = "Email")]
        [Column("Email")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Telefone inválido")]
        [StringLength(13)]
        [Display(Name = "Telefone")]
        [Column("Telefone")]
        public string Telefone { get; set; } = string.Empty;

    }
}
