using inteek.Contracts.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web; 
using System.Text;

namespace inteek.Contracts.Operation
{

    [ServiceContract]
    public interface IInteekConnect
    {
        [OperationContract, WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "/Registro")]
        Response<String> Registro(string nombre, string appPaterno, string appMaterno, char sexo, string fechaNacimiento, string correo, string telefono, string celular, string universidad, string comoTeEnteraste, string mensaje);


        [OperationContract, WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "/EditarPerfilCurso")]
        Response<String> EditarPerfilCurso(int idPerfil, string titulo, string institucion, string duracion, string mesAnio, string urlDocumento, int idTipo, string comentarios);


        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "/ConsultarPerfilCurso/{idPerfil}")]
        Response<Entities.Curso> ConsultarPerfilCurso(string idPerfil);


        [OperationContract, WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "/EditarDatosPersonales")]
        Response<String> EditarDatosPersonales(int idPerfil, string nombre, string apPaterno, string apMaterno, char sexo, string fechaNacimiento);


        [OperationContract, WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "/EditarDatosContacto")]
        Response<String> EditarDatosContacto(int idPerfil, string telCasa, string celular, string correo, string facebook);


        [OperationContract, WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "/EditarDatosUniversidad")]
        Response<String> EditarDatosUniversidad(int idPerfil, string universidad, string carrera, int semestre, string turno);


        [OperationContract, WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "/EditarDatosTrabajo")]
        Response<String> EditarDatosTrabajo(int idPerfil, bool actualmenteTrabaja, string empresa, string puesto, string horario);


        [OperationContract, WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "/EditarDatosInformacion")]
        Response<String> EditarDatosInformacion(int idPerfil, string descProyecto, string interesCurso);


        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "/ConsultarPerfil/{idPerfil}")]
        Response<Entities.Perfil> ConsultarPerfil(string idPerfil);


        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "/ConsultarPerfilConocimiento/{idPerfil}")]
        Response<Entities.PerfilConocimiento> ConsultarPerfilConocimiento(string idPerfil);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "/ConsultarPerfilCompetencia/{idPerfil}")]
        Response<Entities.PerfilCompetencia> ConsultarPerfilCompetencia(string idPerfil);


        [OperationContract, WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "/EditarFotoPerfil")]
        Response<String> EditarFotoPerfil(int idPerfil, string urlFoto);


        [OperationContract, WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "/EditarPerfilProgramacion")]
        Response<String> EditarPerfilProgramacion(int idPerfil, string cadena);


        [OperationContract, WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "/EditarPerfilBase")]
        Response<String> EditarPerfilBase(int idPerfil, string cadena);


        [OperationContract, WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "/EditarPerfilFramework")]
        Response<String> EditarPerfilFramework(int idPerfil, string cadena);


        [OperationContract, WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "/EditarComentarioConocimiento")]
        Response<String> EditarComentarioConocimiento(int idPerfil, string conocimiento);


        [OperationContract, WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "/EliminarPerfilCurso")]
        Response<String> EliminarPerfilCurso(int idCurso);

        [OperationContract, WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "/EditarPerfilCompetencia")]
        Response<String> EditarPerfilCompetencia(int idPerfil, string cadena1);


        [OperationContract, WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "/Login")]
        Response<Entities.DatosLogin> Login(string correo, string pwd);




        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "/ConsultarPerfilAvance/{idPerfil}")]
        Response<Entities.PerfilAvance> ConsultarPerfilAvance(string idPerfil);


        [OperationContract, WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "/EditarPerfilAvance")]
        Response<String> EditarPerfilAvance(int idPerfil, string seccion, int porcentaje);


    }






}