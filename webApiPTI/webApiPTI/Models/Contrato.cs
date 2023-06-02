using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace webApiPTI.Models
{
    [Table("Contrato")]
    public class Contrato
    {
        [Display(Name = "Código")]
        [Column("Id")]
        [Key]
        public int id_Contrato { get; set; }

        [Display(Name = "Data do Pagamento")]
        [Column("dtPagamento")]
        public DateTime dtPagamento { get; set; }

        [Display(Name = "Valor")]
        [Column("Valor")]
        public double valor { get; set; }

        [Display(Name = "Aluno")]
        [ForeignKey("Aluno")] // Adicionando a chave estrangeira
        public int Id_Aluno { get; set; }
        public Aluno Aluno { get; set; } // Propriedade de navegação

        [Display(Name = "Professor")]
        [ForeignKey("Professor")] // Adicionando a chave estrangeira
        public int Id_Professor { get; set; }
        public Professor Professor { get; set; } // Propriedade de navegação
    }
}