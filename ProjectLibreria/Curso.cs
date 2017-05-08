using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectLibreria
{
    public class Curso
    {

        public int IdCurso { get; set; }
        public string Titulo { get; set; }
        public string Institucion { get; set; }
        public string Duracion { get; set; }
        public string MesAnio { get; set; }
        public string URLDocumento { get; set; }
        public int IdPerfil { get; set; }
        public int IdTipo { get; set; }
        public int Comentarios { get; set; }
    }
}
