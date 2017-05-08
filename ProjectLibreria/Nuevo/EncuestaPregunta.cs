using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectLibreria
{
    class EncuestaPregunta
    {
        public int IdEncuesta { get; set; }
        public string Titulo { get; set; }
        public string Objetivo { get; set; }

        public List<EncuestaPreguntaSecciones> Secciones { get; set; }
        public List<EncuestaPregunta_Preguntas> Preguntas { get; set; }
        public List<EncuestaPreguntaOpciones> Opciones { get; set; }
        public List<EncuestaPreguntaRangos> Rangos { get; set; }

        public EncuestaPregunta()
        {
            InicializarPropiedades();
        }
        private void InicializarPropiedades()
        {
            IdEncuesta = 0;
            Titulo = string.Empty;
            Objetivo = string.Empty;
            Secciones = new List<EncuestaPreguntaSecciones>();
            Preguntas = new List<EncuestaPregunta_Preguntas>();
            Opciones = new List<EncuestaPreguntaOpciones>();
            Rangos = new List<EncuestaPreguntaRangos>();

        }
    }
}
