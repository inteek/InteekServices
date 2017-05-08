using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectLibreria
{
    public class Lista
    {
        public Lista()
            {
                InicializarPropiedades();
            }

        private void InicializarPropiedades()
        {
            IdLista = 0;
            Titulo = string.Empty;
        }
        public int IdLista { set; get; }
        public string Titulo { set; get; }
    }
}
