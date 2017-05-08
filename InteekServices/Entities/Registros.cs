using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace inteek.Entities
{
    [DataContract]
    public class Registros
    {
        [DataMember(Order = 1)]
        public int IdRegistro { get; set; }

        [DataMember(Order = 2)]
        public string Nombre { get; set; }

        [DataMember(Order = 3)]
        public string ApPaterno { get; set; }

        [DataMember(Order = 4)]
        public string ApMaterno { get; set; }

        [DataMember(Order = 5)]
        public string Correo { get; set; }

        [DataMember(Order = 6)]
        public string Universidad { get; set; }

        [DataMember(Order = 7)]
        public string Pwd {get; set;}

    }
}