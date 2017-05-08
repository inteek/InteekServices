using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace inteek.Entities
{
    [DataContract]
    public class PerfilConocimiento
    {

        [DataMember(Order = 1)]
        public int IdConocimiento { get; set; }
        
        [DataMember(Order = 2)]
        public int IdNivelConocimiento { get; set; }

        [DataMember(Order = 3)]
        public int IdExperienciaPractica { get; set; }

        [DataMember(Order = 4)]
        public int IdClasificacion { get; set; }

    }
}