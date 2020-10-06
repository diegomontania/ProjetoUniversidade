using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace UniversidadeDiego.Models
{
    public class Curso
    {
        //https://www.learnentityframeworkcore.com/configuration/data-annotation-attributes/databasegenerated-attribute
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CursoID { get; set; }
        public string Titulo { get; set; }
        public int Creditos { get; set; }

        public ICollection<Matricula> Matriculas { get; set; }
    }
}