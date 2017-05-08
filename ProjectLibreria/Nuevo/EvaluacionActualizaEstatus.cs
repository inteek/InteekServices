using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectLibreria
{
    public class EvaluacionActualizaEstatus
    {
        public EvaluacionActualizaEstatus()
            {
                InicializarPropiedades();
            }
            
        private void InicializarPropiedades()
        {
            IdEvalucion = 0;
            IdEvalucionEstatus = 0;
            FechaEnvio = DateTime.Now;
            FechaVigencia = DateTime.Now;
            IdEncuesta = 0;
            IdLista = 0;
            TituloLista = string.Empty;
        }


        public int IdEvalucion { get; set; }
        public int IdEvalucionEstatus { get; set; }
        public DateTime FechaEnvio { get; set; }
        public DateTime FechaVigencia { get; set; }
        public int IdEncuesta { get; set; }
        public int IdLista { get; set; }
        public string TituloLista { get; set; }

    }
}
