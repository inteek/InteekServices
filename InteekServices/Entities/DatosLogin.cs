using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace inteek.Entities
{
    [DataContract]
    public class DatosLogin
    {
        [DataMember(Order = 1)]
        public int IdPerfil { get; set; }

        [DataMember(Order = 2)]
        public int IdRegistro { get; set; }

        [DataMember(Order = 3)]
        public string Nombre { get; set; }

        //[DataMember(Order = 4)]
        //public string Correo { get; set; }

        //[DataMember(Order = 5)]
        //public string Pwd { get; set; }

    }
}