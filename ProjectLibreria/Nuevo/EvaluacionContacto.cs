using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectLibreria
{
    public class EvaluacionContacto
    {
        public EvaluacionContacto()
            {
                InicializarPropiedades();
            }
            
        private void InicializarPropiedades()
        {
            IdContacto = 0;
            Nombre = string.Empty;
            ApellidoPaterno = string.Empty;
            ApellidoMaterno = string.Empty;
            Email = string.Empty;
            Activo = true;


        }


        public int IdContacto { get; set; }
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string Email { get; set; }
        public bool Activo { get; set; }
    }
}
