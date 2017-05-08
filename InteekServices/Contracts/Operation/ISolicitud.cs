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
    public interface ISolicitud
    {
        [OperationContract, WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "/Propuesta")]
        Response<String> Propuesta(string nombre, string correo, string telefono, string empresa, string tipoServicio, string mensaje);

    }






}