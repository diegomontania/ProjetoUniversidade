﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using UniversidadeDiego.Data;

namespace UniversidadeDiego.Migrations
{
    [DbContext(typeof(EscolaContexto))]
    partial class EscolaContextoModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("UniversidadeDiego.Models.Curso", b =>
                {
                    b.Property<int>("CursoID")
                        .HasColumnType("int");

                    b.Property<int>("Creditos")
                        .HasColumnType("int");

                    b.Property<string>("Titulo")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CursoID");

                    b.ToTable("Curso");
                });

            modelBuilder.Entity("UniversidadeDiego.Models.Estudante", b =>
                {
                    b.Property<int>("EstudanteID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DataMatricula")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SobreNome")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EstudanteID");

                    b.ToTable("Estudante");
                });

            modelBuilder.Entity("UniversidadeDiego.Models.Instrutor", b =>
                {
                    b.Property<int>("InstrutorID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DataMatricula")
                        .HasColumnType("datetime2");

                    b.Property<int>("Idade")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SobreNome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TurnoAtual")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("InstrutorID");

                    b.ToTable("Instrutor");
                });

            modelBuilder.Entity("UniversidadeDiego.Models.Matricula", b =>
                {
                    b.Property<int>("MatriculaID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CursoID")
                        .HasColumnType("int");

                    b.Property<int>("EstudanteID")
                        .HasColumnType("int");

                    b.Property<int?>("Nota")
                        .HasColumnType("int");

                    b.HasKey("MatriculaID");

                    b.HasIndex("CursoID");

                    b.HasIndex("EstudanteID");

                    b.ToTable("Matricula");
                });

            modelBuilder.Entity("UniversidadeDiego.Models.Matricula", b =>
                {
                    b.HasOne("UniversidadeDiego.Models.Curso", "Curso")
                        .WithMany("Matriculas")
                        .HasForeignKey("CursoID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("UniversidadeDiego.Models.Estudante", "Estudante")
                        .WithMany("Matriculas")
                        .HasForeignKey("EstudanteID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
