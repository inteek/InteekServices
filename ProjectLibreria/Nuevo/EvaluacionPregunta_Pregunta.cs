using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectLibreria
{
    public class EvaluacionPregunta_Pregunta
    {
        public EvaluacionPregunta_Pregunta()
            {
                InicializarPropiedades();
            }
            
        private void InicializarPropiedades()
        {
            IdSeccion = 0;
            Descripcion = string.Empty;
            IdPreguntaSuperior = 0;
            IdTipoComponente = 0;
            IdEncuesta = 0;
            IdSeccion = 0;
            Orden = 0;
        }
        public int IdPregunta { get; set; }
        public string Descripcion { get; set; }
        public int IdPreguntaSuperior { get; set; }
        public int IdTipoComponente { get; set; }
        public int IdEncuesta { get; set; }
        public int IdSeccion { get; set; }
        public int Orden { get; set; }
    }
}
