using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UniversidadeDiego.Models
{
    public class Instrutor
    {
        public int InstrutorID { get; set; }
        public string Nome { get; set; }
        public string SobreNome { get; set; }
        public int Idade { get; set; }
        public string TurnoAtual { get; set; }

        [DataType(DataType.Date)]
        public DateTime DataMatricula { get; set; }
    }
}
