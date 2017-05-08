using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace inteek.Entities
{
    [DataContract]
    public class PerfilCompetencia
    {
        [DataMember(Order = 1)]
        public int IdCompetencia { get; set; }
        
        [DataMember(Order = 1)]
        public int IdRespuestaCompetencia { get; set; }
    }
}