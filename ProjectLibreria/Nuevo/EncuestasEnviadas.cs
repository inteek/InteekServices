using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectLibreria
{
    public class EncuestasEnviadas
    {
        public EncuestasEnviadas()
            {
                InicializarPropiedades();
            }

        private void InicializarPropiedades()
        {
            IdEncuesta = 0;
            Titulo = string.Empty;
            Objetivo = string.Empty;
            Activo = true;
        }
        public int IdEncuesta { get; set; }
        public string Titulo { get; set; }
        public string Objetivo { get; set; }
        public bool Activo { get; set; }

    }
}
