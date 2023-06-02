﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using webApiPTI.Data;

#nullable disable

namespace webApiPTI.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20230531221016_Second migration")]
    partial class Secondmigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("webApiPTI.Models.Aluno", b =>
                {
                    b.Property<int>("Id_Aluno")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id_Aluno"), 1L, 1);

                    b.Property<int>("Cpf")
                        .HasColumnType("int")
                        .HasColumnName("nrCpf");

                    b.Property<int>("Id_Professor")
                        .HasColumnType("int");

                    b.Property<DateTime>("Nascimento")
                        .HasColumnType("datetime2")
                        .HasColumnName("dtNascimento");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Nome");

                    b.Property<DateTime>("Pagamento")
                        .HasColumnType("datetime2")
                        .HasColumnName("dtPagamento");

                    b.Property<string>("Profissao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("nmProfissao");

                    b.HasKey("Id_Aluno");

                    b.HasIndex("Id_Professor");

                    b.ToTable("Aluno");
                });

            modelBuilder.Entity("webApiPTI.Models.Aula", b =>
                {
                    b.Property<int>("Id_Aula")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id_Aula"), 1L, 1);

                    b.Property<int>("Id_Aluno")
                        .HasColumnType("int");

                    b.Property<int>("Id_Professor")
                        .HasColumnType("int");

                    b.Property<DateTime>("dtAula")
                        .HasColumnType("datetime2")
                        .HasColumnName("dtAula");

                    b.HasKey("Id_Aula");

                    b.HasIndex("Id_Aluno");

                    b.HasIndex("Id_Professor");

                    b.ToTable("Aula");
                });

            modelBuilder.Entity("webApiPTI.Models.Contrato", b =>
                {
                    b.Property<int>("id_Contrato")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id_Contrato"), 1L, 1);

                    b.Property<int>("Id_Aluno")
                        .HasColumnType("int");

                    b.Property<int>("Id_Professor")
                        .HasColumnType("int");

                    b.Property<DateTime>("dtPagamento")
                        .HasColumnType("datetime2")
                        .HasColumnName("dtPagamento");

                    b.Property<double>("valor")
                        .HasColumnType("float")
                        .HasColumnName("Valor");

                    b.HasKey("id_Contrato");

                    b.HasIndex("Id_Aluno");

                    b.HasIndex("Id_Professor");

                    b.ToTable("Contrato");
                });

            modelBuilder.Entity("webApiPTI.Models.Professor", b =>
                {
                    b.Property<int>("Id_Professor")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id_Professor"), 1L, 1);

                    b.Property<int>("Cpf")
                        .HasColumnType("int")
                        .HasColumnName("nrCpf");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Login");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Nome");

                    b.Property<int>("Senha")
                        .HasColumnType("int")
                        .HasColumnName("Senha");

                    b.HasKey("Id_Professor");

                    b.ToTable("Professores");
                });

            modelBuilder.Entity("webApiPTI.Models.Aluno", b =>
                {
                    b.HasOne("webApiPTI.Models.Professor", "Professor")
                        .WithMany()
                        .HasForeignKey("Id_Professor")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Professor");
                });

            modelBuilder.Entity("webApiPTI.Models.Aula", b =>
                {
                    b.HasOne("webApiPTI.Models.Aluno", "Aluno")
                        .WithMany()
                        .HasForeignKey("Id_Aluno")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("webApiPTI.Models.Professor", "Professor")
                        .WithMany()
                        .HasForeignKey("Id_Professor")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Aluno");

                    b.Navigation("Professor");
                });

            modelBuilder.Entity("webApiPTI.Models.Contrato", b =>
                {
                    b.HasOne("webApiPTI.Models.Aluno", "Aluno")
                        .WithMany()
                        .HasForeignKey("Id_Aluno")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("webApiPTI.Models.Professor", "Professor")
                        .WithMany()
                        .HasForeignKey("Id_Professor")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Aluno");

                    b.Navigation("Professor");
                });
#pragma warning restore 612, 618
        }
    }
}
