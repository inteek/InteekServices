using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectLibreria
{
    public class EncuestaPreguntaOpciones
    {
        public EncuestaPreguntaOpciones()
            {
                InicializarPropiedades();
            }

        private void InicializarPropiedades()
        {
            IdOpcion = 0;
            Descripcion = string.Empty;
            Puntuacion = 0;
            GeneraPregunta = false;
            Orden = 0;
            IdPregunta = 0;
            IdCarita = 0;
        }
        public int IdOpcion { get; set; }
        public string Descripcion { get; set; }
        public int Puntuacion { get; set; }
        public bool GeneraPregunta { get; set; }
        public int Orden { get; set; }
        public int IdPregunta { get; set; }
        public int IdCarita { get; set; }
    }
}
