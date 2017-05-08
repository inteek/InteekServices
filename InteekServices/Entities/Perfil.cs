using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace inteek.Entities
{
    [DataContract]
    public class Perfil
    {
        [DataMember(Order = 1)]
        public int IdPerfil { get; set; }

        [DataMember(Order = 2)]
        public string Nombre { get; set; }

        [DataMember(Order = 3)]
        public string ApPaterno { get; set; }

        [DataMember(Order = 4)]
        public string ApMaterno { get; set; }

        [DataMember(Order = 5)]
        public string Sexo { get; set; }

        [DataMember(Order = 6)]
        public string FechaNacimiento { get; set; }

        [DataMember(Order = 7)]
        public string TelCasa { get; set; }

        [DataMember(Order = 8)]
        public string Celular { get; set; }
        [DataMember(Order = 9)]

        public string Correo { get; set; }
        [DataMember(Order = 10)]
        public string Facebook { get; set; }

        [DataMember(Order = 11)]
        public string Universidad { get; set; }

        [DataMember(Order = 12)]
        public string Carrera { get; set; }

        [DataMember(Order = 13)]
        public int Semestre { get; set; }

        [DataMember(Order = 14)]
        public string Turno { get; set; }

        [DataMember(Order = 15)]
        public bool ActualmenteTrabaja { get; set; }

        [DataMember(Order = 16)]
        public string Empresa { get; set; }

        [DataMember(Order = 17)]
        public string Puesto { get; set; }

        [DataMember(Order = 18)]
        public string Horario { get; set; }

        [DataMember(Order = 19)]
        public string DescProyecto { get; set; }

        [DataMember(Order = 20)]
        public string InteresCurso { get; set; }

        [DataMember(Order = 21)]
        public string UrlFoto { get; set; }
    }
}