using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectLibreria
{
    public class ListaActualiza
    {
        public ListaActualiza()
            {
                InicializarPropiedades();
            }

        private void InicializarPropiedades()
        {
            IdLista = 0;
            Titulo = string.Empty;
        }
        public int IdLista { get; set; }
        public string Titulo { get; set; }
    }
}
