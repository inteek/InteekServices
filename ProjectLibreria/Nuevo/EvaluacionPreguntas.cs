using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectLibreria
{
    class EvaluacionPreguntas
    {
        public int IdPregunta { get; set; }
        public string Descripcion { get; set; }
        public int IdPreguntaSuperior { get; set; }
        public int IdTipoComponente { get; set; }
        public int IdEncuesta { get; set; }
        public int IdSeccion { get; set; }
        public int Orden { get; set; }

        public List<EvaluacionPregunta_Seccion> Secciones { get; set; }
        public List<EvaluacionPregunta_Pregunta> Preguntas { get; set; }
        public List<EvaluacionPregunta_Opciones> Opciones { get; set; }
        public List<EvaluacionPregunta_Rangos> Rangos { get; set; }

        public EvaluacionPreguntas()
        {
            InicializarPropiedades();
        }
        private void InicializarPropiedades()
        {
            IdPregunta = 0;
            Descripcion = string.Empty;
            IdPreguntaSuperior = 0;
            IdTipoComponente = 0;
            IdEncuesta = 0;
            IdSeccion = 0;
            Orden = 0;
            Secciones = new List<EvaluacionPregunta_Seccion>();
            Preguntas = new List<EvaluacionPregunta_Pregunta>();
            Opciones = new List<EvaluacionPregunta_Opciones>();
            Rangos = new List<EvaluacionPregunta_Rangos>();

        }

    }
}
