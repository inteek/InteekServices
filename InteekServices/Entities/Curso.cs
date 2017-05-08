using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace inteek.Entities
{

    [DataContract]
    public class Curso
    {

        [DataMember(Order = 1)]
        public int IdCurso { get; set; }

        [DataMember(Order = 2)]
        public string Titulo { get; set; }

        [DataMember(Order = 3)]
        public string Institucion { get; set; }

        [DataMember(Order = 4)]
        public string Duracion { get; set; }

        [DataMember(Order = 5)]
        public string MesAnio { get; set; }

        [DataMember(Order = 7)]
        public string URLDocumento {get; set;}

        [DataMember(Order = 8, Name = "Perfil")]
        public int IdPerfil { get; set; }

        [DataMember(Order = 9)]
        public int IdTipo { get; set; }

        [DataMember(Order = 10)]
        public int Comentarios { get; set; }

    }
}