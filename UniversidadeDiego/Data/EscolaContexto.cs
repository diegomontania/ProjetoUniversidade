﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UniversidadeDiego.Models;

namespace UniversidadeDiego.Data
{
    public class EscolaContexto : DbContext
    {
        public EscolaContexto(DbContextOptions<EscolaContexto> options) : base(options)
        {
            
        }

        //tabelas do banco
        public DbSet<Curso> Cursos { get; set; }
        public DbSet<Matricula> Matriculas { get; set; }
        public DbSet<Estudante> Estudantes { get; set; }
        public DbSet<Instrutor> Instrutores { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Curso>().ToTable("Curso");
            modelBuilder.Entity<Matricula>().ToTable("Matricula");
            modelBuilder.Entity<Estudante>().ToTable("Estudante");
            modelBuilder.Entity<Instrutor>().ToTable("Instrutor");
        }

    }
}
