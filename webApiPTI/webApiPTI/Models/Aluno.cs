using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webApiPTI.Models
{
    [Table("Aluno")]
    public class Aluno
    {
        [Display(Name = "Código")]
        [Column("Id")]
        [Key]
        public int Id_Aluno { get; set; }

        [Display(Name = "Cpf")]
        [Column("nrCpf")]
        public string Cpf { get; set; }

        [Display(Name = "Nome")]
        [Column("Nome")]
        public string Nome { get; set; }

        [Display(Name = "Nascimento")]
        [Column("dtNascimento")]
        public DateTime Nascimento { get; set; }

        [Display(Name = "Profissao")]
        [Column("nmProfissao")]
        public string Profissao { get; set; }

        [Display(Name = "Pagamento")]
        [Column("dtPagamento")]
        public DateTime Pagamento { get; set; }
        
        [Display(Name = "Telefone")]
        [Column("nrTelefone")]
        public string Telefone { get; set; }

        [Display(Name = "Email")]
        [Column("nmEmail")]
        public string Email { get; set; }

        [ForeignKey("Professor")]
        public virtual int? ProfessorId { get; set; }

        public virtual Professor? Professor { get; set; }



    }
}
