using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectLibreria
{
    public class Evaluaciones
    {
        public Evaluaciones()
            {
                InicializarPropiedades();
            }
            
        private void InicializarPropiedades()
        {
            IdEvaluacion = 0;
            IdEvaluacionEstatus = 0;
            FechaEnvio = DateTime.Now;
            FechaVigencia = DateTime.Now;
            IdEncuesta = 0;
            IdLista = 0;
            TituloLista = string.Empty;
        }

        public int IdEvaluacion { get; set; }
        public int IdEvaluacionEstatus { get; set; }
        public DateTime FechaEnvio { get; set; }
        public DateTime FechaVigencia { get; set; }
        public int IdEncuesta { get; set; }
        public int IdLista { get; set; }
        public string TituloLista { get; set; }
    }
}
