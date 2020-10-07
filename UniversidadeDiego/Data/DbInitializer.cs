﻿using Microsoft.EntityFrameworkCore.Internal;
using System;
using UniversidadeDiego.Models;

namespace UniversidadeDiego.Data
{
    public class DbInitializer
    {
        public static void Initialize(EscolaContexto contexto)
        {
            contexto.Database.EnsureCreated();  /*cria o banco caso ele não exista : C:/Users/<user>*/

            // procura por qualquer estudante
            if (contexto.Estudantes.Any())
            {
                return; //O banco foi inicializado 
            }

            AdicionaEstudantes(contexto);
            AdicionaCursos(contexto);
            AdicionaMatriculas(contexto);
        }

        private static void AdicionaEstudantes(EscolaContexto contexto)
        {
            //insere estudantes, apenas na inicialização
            var estudantes = new Estudante[]
            {
                new Estudante{Nome="Carlos",SobreNome="Silveira",DataMatricula=DateTime.Parse("2015-09-01")},
                new Estudante{Nome="Maria",SobreNome="Alonso",DataMatricula=DateTime.Parse("2012-09-01")},
                new Estudante{Nome="Bianca",SobreNome="Almeida",DataMatricula=DateTime.Parse("2013-09-01")},
                new Estudante{Nome="Jose Carlos",SobreNome="Siqueira",DataMatricula=DateTime.Parse("2012-09-01")},
                new Estudante{Nome="Yuri",SobreNome="Silva",DataMatricula=DateTime.Parse("2012-09-01")},
                new Estudante{Nome="Mario",SobreNome="Domingues",DataMatricula=DateTime.Parse("2011-09-01")},
                new Estudante{Nome="Laura",SobreNome="Santos",DataMatricula=DateTime.Parse("2013-09-01")},
                new Estudante{Nome="Jefferson",SobreNome="Bueno",DataMatricula=DateTime.Parse("2015-09-01")}
            };

            //adiciona
            foreach (Estudante s in estudantes)
            {
                contexto.Estudantes.Add(s);
            }

            //salva as alterações
            contexto.SaveChanges();
        }

        private static void AdicionaCursos(EscolaContexto contexto)
        {
            var cursos = new Curso[]
            {
                new Curso{CursoID=1050,Titulo="Quimica",Creditos=3,},
                new Curso{CursoID=4022,Titulo="Economia",Creditos=3,},
                new Curso{CursoID=4041,Titulo="Economia",Creditos=3,},
                new Curso{CursoID=1045,Titulo="Cálculo",Creditos=4,},
                new Curso{CursoID=3141,Titulo="Trigonometria",Creditos=4,},
                new Curso{CursoID=2021,Titulo="Música",Creditos=3,},
                new Curso{CursoID=2042,Titulo="Literatura",Creditos=4,}
            };
            foreach (Curso c in cursos)
            {
                contexto.Cursos.Add(c);
            }
            contexto.SaveChanges();
        }

        private static void AdicionaMatriculas(EscolaContexto contexto)
        {
            var matriculas = new Matricula[]
            {
                new Matricula{EstudanteID=1,CursoID=1050,Nota=Nota.A},
                new Matricula{EstudanteID=1,CursoID=4022,Nota=Nota.C},
                new Matricula{EstudanteID=1,CursoID=4041,Nota=Nota.B},
                new Matricula{EstudanteID=2,CursoID=1045,Nota=Nota.B},
                new Matricula{EstudanteID=2,CursoID=3141,Nota=Nota.F},
                new Matricula{EstudanteID=2,CursoID=2021,Nota=Nota.F},
                new Matricula{EstudanteID=3,CursoID=1050},
                new Matricula{EstudanteID=4,CursoID=1050,},
                new Matricula{EstudanteID=4,CursoID=4022,Nota=Nota.F},
                new Matricula{EstudanteID=5,CursoID=4041,Nota=Nota.C},
                new Matricula{EstudanteID=6,CursoID=1045},
                new Matricula{EstudanteID=7,CursoID=3141,Nota=Nota.A},
            };
            foreach (Matricula e in matriculas)
            {
                contexto.Matriculas.Add(e);
            }
            contexto.SaveChanges();
        }
    }
}
