using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace force.Models
{
    public class JugadotScoringDto
    {
        public string? Nickname { get; set; }
        public string? Documento { get; set; }
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public int Edad { get; set; }
        public string? Mail { get; set; }
        public string? Colegio { get; set; }
        public string? Facebook { get; set; }
        public string? Instagram { get; set; }
        public int Scoring { get; set ;}
    }
}