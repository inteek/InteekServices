using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectLibreria
{
    public class ContactoDetalleActualiza
    {

        public ContactoDetalleActualiza()
            {
                InicializarPropiedades();
            }

        private void InicializarPropiedades()
        {
            IdContacto = 0;
            Nombre = string.Empty;
            ApellidoPaterno = string.Empty;
            ApellidoMaterno = string.Empty;
            FechaNacimiento = DateTime.Now;
            Sexo = string.Empty;
            EstadoCivil = string.Empty;
            Calle = string.Empty;
            Colonia = string.Empty;
            Cuidad = string.Empty;
            Municipio = string.Empty;
            Estado = string.Empty;
            TelefonoPrincipal = string.Empty;
            TelefonoAdicional = string.Empty;
            Email = string.Empty;
            Activo = true;
            IdTipoContacto = 0;

        }


        public int IdContacto { get; set; }
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Sexo { get; set; }
        public string EstadoCivil { get; set; }
        public string Calle { get; set; }
        public string Colonia { get; set; }
        public string Cuidad { get; set; }
        public string Municipio { get; set; }
        public string Estado { get; set; }
        public string TelefonoPrincipal { get; set; }
        public string TelefonoAdicional { get; set; }
        public string Email { get; set; }
        public bool Activo { get; set; }
        public int IdTipoContacto { get; set; }
    }
}
