using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectLibreria
{
    public class ConfiguracionActualiza
    {

        public ConfiguracionActualiza()
            {
                InicializarPropiedades();
            }

        private void InicializarPropiedades()
        {
            Remitente = string.Empty;
            Asunto = string.Empty;
            Mensaje = string.Empty;
        }
        public string Remitente { get; set; }

        public string Asunto { get; set; }

        public string Mensaje { get; set; }
    }
}
