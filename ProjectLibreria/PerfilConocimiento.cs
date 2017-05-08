using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectLibreria
{
    public class PerfilConocimiento
    {
        public List<Conocimiento> Conocimientos { get; set; }
        public string Comentarios { get; set; }


        public PerfilConocimiento() 
        {
            Conocimientos = new List<Conocimiento>();
            Comentarios = string.Empty;
        }
    }


    
    public class Conocimiento
    {
        public int IdConocimiento { get; set; }

        public int IdNivelConocimiento { get; set; }

        public int IdExperienciaPractica { get; set; }

        public int IdClasificacion { get; set; }
    }


}
