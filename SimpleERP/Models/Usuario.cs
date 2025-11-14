
//estou usando a model Usuario para se comunicar apenas com o db sem influenciar view
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
        public string Nome { get; set; }

        [Required(ErrorMessage = "Email inválido")]
        [Display(Name = "Email")]
        [Column("Email")]
        public string Email { get; set; }

        //+55 espaço opcional (2 digitos) espaço opcional 9+ 4 digitos - 4 digitos
        //[RegularExpression(@"^\55\s?\(\d{2}\)\s?9\d{4}-\d{4}$",
        [Required(ErrorMessage = "Telefone inválido")]
        [Display(Name = "Telefone")]
        [RegularExpression(@"^55\d{11}$",
            ErrorMessage ="Informe o telefone no formato:+55(**)*****-****")]
        [Column("Telefone")]
        [StringLength(13, ErrorMessage = "O telefone deve conter 13 dígitos: 55 + DDD + número (9 dígitos).")]
        public string Telefone { get; set; }
    }
}
