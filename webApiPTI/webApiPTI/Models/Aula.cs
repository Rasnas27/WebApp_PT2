using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace webApiPTI.Models
{
    [Table("Aula")]
    public class Aula
    {
        [Display(Name = "Código")]
        [Column("Id")]
        [Key]
        public int Id_Aula { get; set; }
        [Display(Name = "Data Aula")]
        [Column("dtAula")]
        public DateTime dtAula { get; set; }

        [Display(Name = "Professor")]
        [ForeignKey("Professor")] // Adicionando a chave estrangeira
        public int Id_Professor { get; set; }

        public Professor Professor { get; set; }

        [Display(Name = "Aluno")]
        [ForeignKey("Aluno")] // Adicionando a chave estrangeira
        public int Id_Aluno { get; set; }

        public Aluno Aluno { get; set; }

    }
}
