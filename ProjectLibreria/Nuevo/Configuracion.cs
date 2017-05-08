using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectLibreria
{
    public class Configuracion
    {
        public Configuracion()
            {
                InicializarPropiedades();
            }
            
        private void InicializarPropiedades()
        {
            Remitente = string.Empty;
            Asunto = string.Empty;
            Mensaje = string.Empty;
        }

        //PROPIEDADES
        public string Remitente { set; get; }

        public string Asunto { set; get; }

        public string Mensaje { set; get; }
    }
}
