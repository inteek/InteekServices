using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectLibreria
{
    public class ContactoCampoActualiza
    {
        public ContactoCampoActualiza()
            {
                InicializarPropiedades();
            }

        private void InicializarPropiedades()
        {
            IdContacto = 0;
            IdCampo = 0;
            IdCampoOpcion = 0;
            Valor = string.Empty;
        }

        public int IdContacto { get; set; }
        public int IdCampo { get; set; }
        public int IdCampoOpcion { get; set; }
        public string Valor { get; set; }
    }
}
