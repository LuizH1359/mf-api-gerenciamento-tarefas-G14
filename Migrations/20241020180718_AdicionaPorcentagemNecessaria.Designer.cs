﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using mf_api_gerenciamento_tarefas_G14.Models;

#nullable disable

namespace mf_api_gerenciamento_tarefas_G14.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20241020180718_AdicionaPorcentagemNecessaria")]
    partial class AdicionaPorcentagemNecessaria
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("mf_api_gerenciamento_tarefas_G14.Models.Disciplina", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal>("Media")
                        .HasColumnType("decimal(65,30)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<decimal>("PorcentagemNecessaria")
                        .HasColumnType("decimal(65,30)");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Disciplinas");
                });

            modelBuilder.Entity("mf_api_gerenciamento_tarefas_G14.Models.Nota", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("DisciplinaId")
                        .HasColumnType("int");

                    b.Property<decimal>("NotaMaxima")
                        .HasColumnType("decimal(65,30)");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("int");

                    b.Property<decimal>("Valor")
                        .HasColumnType("decimal(65,30)");

                    b.HasKey("Id");

                    b.HasIndex("DisciplinaId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Notas");
                });

            modelBuilder.Entity("mf_api_gerenciamento_tarefas_G14.Models.Tarefa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("Realizada")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Tarefas");
                });

            modelBuilder.Entity("mf_api_gerenciamento_tarefas_G14.Models.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Usuários");
                });

            modelBuilder.Entity("mf_api_gerenciamento_tarefas_G14.Models.Disciplina", b =>
                {
                    b.HasOne("mf_api_gerenciamento_tarefas_G14.Models.Usuario", "Usuario")
                        .WithMany("Disciplinas")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("mf_api_gerenciamento_tarefas_G14.Models.Nota", b =>
                {
                    b.HasOne("mf_api_gerenciamento_tarefas_G14.Models.Disciplina", "Disciplina")
                        .WithMany("Notas")
                        .HasForeignKey("DisciplinaId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("mf_api_gerenciamento_tarefas_G14.Models.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Disciplina");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("mf_api_gerenciamento_tarefas_G14.Models.Tarefa", b =>
                {
                    b.HasOne("mf_api_gerenciamento_tarefas_G14.Models.Usuario", "Usuario")
                        .WithMany("Tarefas")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("mf_api_gerenciamento_tarefas_G14.Models.Disciplina", b =>
                {
                    b.Navigation("Notas");
                });

            modelBuilder.Entity("mf_api_gerenciamento_tarefas_G14.Models.Usuario", b =>
                {
                    b.Navigation("Disciplinas");

                    b.Navigation("Tarefas");
                });
#pragma warning restore 612, 618
        }
    }
}
