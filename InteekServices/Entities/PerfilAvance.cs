using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace inteek.Entities
{

    [DataContract]
    public class PerfilAvance
    {
        [DataMember(Order = 1)]
        public int IdPerfil { get; set; }
        [DataMember(Order = 2)]
        public int Perfil { get; set; }
        [DataMember(Order = 3)]
        public int Conocimientos { get; set; }
        [DataMember(Order = 4)]
        public int Cursos { get; set; }
        [DataMember(Order = 5)]
        public int Competencias { get; set; }
    }
}