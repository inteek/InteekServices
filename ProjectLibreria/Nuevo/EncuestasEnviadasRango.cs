using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectLibreria
{
    public class EncuestasEnviadasRango
    {
        public EncuestasEnviadasRango()
            {
                InicializarPropiedades();
            }

        private void InicializarPropiedades()
        {
            IdRango = 0;
            ValorMinimo = 0;
            ValorMaximo = 0;
            IdPregunta = 0;
        }

        public int IdRango { get; set; }
        public int ValorMinimo { get; set; }
        public int ValorMaximo { get; set; }
        public int IdPregunta { get; set; }
    }
}
