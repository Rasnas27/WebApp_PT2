using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace webApiPTI.Models
{
    [Table("Professores")]
    public class Professor
    {
        [Display(Name = "Código")]
        [Column("Id")]
        [Key]
        public int Id_Professor { get; set; }

        [Display(Name = "Cpf")]
        [Column("nrCpf")]
        public int Cpf { get; set; }

        [Display(Name = "Nome")]
        [Column("Nome")]
        public string Nome { get; set; }

        [Display(Name = "Login")]
        [Column("Login")]
        public string Login { get; set; }

        [Display(Name = "Senha")]
        [Column("Senha")]
        public string Senha { get; set; }

    }
}
