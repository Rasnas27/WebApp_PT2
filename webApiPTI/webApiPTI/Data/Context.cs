using Microsoft.EntityFrameworkCore;
using webApiPTI.Models;

namespace webApiPTI.Data
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {

        }

        public DbSet<Aluno> Aluno { get; set; }
        public DbSet<Professor> Professor { get; set; }
        public DbSet<Aula> Aula { get; set; }
        public DbSet<Contrato> Contrato { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contrato>()
               .HasOne(c => c.Professor) // Propriedade de navegação
               .WithMany() // Não há propriedade de coleção em Contrato
               .HasForeignKey(c => c.Id_Professor); // Chave estrangeira


            modelBuilder.Entity<Contrato>()
               .HasOne(c => c.Aluno) // Propriedade de navegação
               .WithMany() // Não há propriedade de coleção em Contrato
               .HasForeignKey(c => c.Id_Aluno); // Chave estrangeira

            modelBuilder.Entity<Aula>()
                .HasOne(a => a.Professor) // Propriedade de navegação para Professor
                .WithMany() // Não há propriedade de coleção em Professor
                .HasForeignKey(a => a.Id_Professor); // Chave estrangeira para Professor

            modelBuilder.Entity<Aula>()
                .HasOne(a => a.Aluno) // Propriedade de navegação para Aluno
                .WithMany() // Não há propriedade de coleção em Aluno
                .HasForeignKey(a => a.Id_Aluno); // Chave estrangeira para Aluno
        }

    }

}
