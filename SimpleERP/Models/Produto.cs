using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimpleERP.Models
{
        [Table("Produto")]

    public class Produto
    {
        [Display(Name = "Código")]
        [Column("id")]
        [Key]
        public int Id { get; set; }


        [Display(Name = "Nome do produto")]
        [Column("Nome")]
        public string Nome{ get; set; }
        
        [Display(Name = "Valor do produto")]
        [Column("valor")]
        public decimal Valor{ get; set; }

        [Display(Name = "descrição do produto")]
        [Column("Descricao")]
        public string? Descricao { get; set; }
        [Display(Name = "quantidade do produto")]
        [Column("Quantidade")]
        public int Quantidade { get; set; }
    }
    
}
