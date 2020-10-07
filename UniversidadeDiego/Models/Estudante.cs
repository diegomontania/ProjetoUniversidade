using System;
using System.Collections.Generic;

namespace UniversidadeDiego.Models
{
    public class Estudante
    {
        public int EstudanteID { get; set; }
        public string Nome { get; set; }
        public string SobreNome { get; set; }
        public DateTime DataMatricula { get; set; }
        public ICollection<Matricula> Matriculas { get; set; }

    }
}
