using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectLibreria
{
    public class EncuestasEnviadasPreguntas
    {
        public EncuestasEnviadasPreguntas()
            {
                InicializarPropiedades();
            }

        private void InicializarPropiedades()
        {
            IdPregunta = 0;
            Descripcion = string.Empty;
            Activo = true;
            IdPreguntaSuperior = 0;
            IdTipoComponente = 0;
            IdEncuesta = 0;
            IdSeccion = 0;
            Orden = 0;
        }

        public int IdPregunta { get; set; }
        public string Descripcion { get; set; }
        public bool Activo { get; set; }
        public int IdPreguntaSuperior { get; set; }
        public int IdTipoComponente { get; set; }
        public int IdEncuesta { get; set; }
        public int IdSeccion { get; set; }
        public int Orden { get; set; }

    }
}
