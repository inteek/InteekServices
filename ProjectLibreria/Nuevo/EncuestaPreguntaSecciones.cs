using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectLibreria
{
    public class EncuestaPreguntaSecciones
    {
        public EncuestaPreguntaSecciones()
            {
                InicializarPropiedades();
            }

        private void InicializarPropiedades()
        {
            IdSeccion = 0;
            Titulo = string.Empty;
            IdEncuesta = 0;
            Orden = 0;
        }

        public int IdSeccion { get; set; }
        public string Titulo { get; set; }
        public int IdEncuesta { get; set; }
        public int Orden { get; set; }
    }
}
