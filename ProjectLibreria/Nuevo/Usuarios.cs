using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectLibreria
{
    public class Usuarios
    {

        public Usuarios()
            {
                InicializarPropiedades();
            }

        private void InicializarPropiedades()
        {
            IdUsuario = 0;
            Nombre = string.Empty;
            ApellidoPaterno = string.Empty;
            ApellidoMaterno = string.Empty;
            Correo = string.Empty;
            Usuario = string.Empty;
            Pwd = string.Empty;
        }

        public int IdUsuario { get; set; }
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string Correo { get; set; }
        public string Usuario { get; set; }
        public string Pwd { get; set; }
    }
}
