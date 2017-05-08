using inteek.Contracts.Operation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace inteek.Services
{
    public class Solicitud : ISolicitud
    {


        public Contracts.Data.Response<String> Propuesta(string nombre, string correo, string telefono, string empresa, string tipoServicio, string mensaje)
        {
            try {


                Contracts.Data.Response<String> result = new Contracts.Data.Response<String>();

                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("inteekdev.com");

                mail.From = new MailAddress("web@inteekdev.com");
                mail.To.Add("agalindo@inteek.mx");
                mail.Subject = string.Format("Solicitud de Propuesta: {0}", servicioSolicitado(tipoServicio));
                mail.IsBodyHtml = true;


                string body = "<!DOCTYPE html>";
                body += "<html lang='es'>";
                body += "<head>";
                body += "<meta name='viewport' content='width=device-width'>";
                body += "<style>";
                body += "@media only screen and (max-width:319px)  { body{font-size:8px}}";
                body += "@media only screen and (min-width:320px) and (max-width:767px)  { body{font-size:10px} }";
                body += "@media only screen and (min-width:768px) and (max-width:1023px)  { body{font-size:12px} }";
                body += "@media only screen and (min-width:1024px) and (max-width:1899px) { body{font-size:14px} }";
                body += "@media only screen and (min-width:1900px) { body{font-size:16px} }";
                body += "</style>";
                body += "</head>";
                body += "<body>";
                body += "<div style='width:100%;' align='center'>";
                body += "<div style='height:180px; width:621px;'>";
                body += "<img src='http://inteek.mx/images/header.png' style='height:100%; width:100%' />";
                body += "</div>";
                body += string.Format("<div style='height:100%; width:621px;' align='center'><div style='width:501px; text-align:left;'><p style='width:501px;'><strong>Contacto</strong> {0}</br><strong>Correo</strong> {1}</br><strong>Teléfono</strong> {2}</br><strong>Empresa</strong> {3}</br></br></br><strong>Servicio</strong></br>{4}</br></br><strong>Mensaje</strong></br>{5}</p></div></div>", nombre, correo, telefono, empresa, servicioSolicitado(tipoServicio), mensaje);
                body += "<div style='height:180px; width:621px;'><img style='height:100%; width:100%' src='http://inteek.mx/images/footer.png'/></div>";
                body += "</div>";
                body += "</body>";
                body += "<html>";


                mail.Body = body;

                
                SmtpServer.Port = 587;
                SmtpServer.Credentials = new System.Net.NetworkCredential("agalindo@inteekdev.com", "DeveloperNet.2016");
                //SmtpServer.EnableSsl = true;
                

                SmtpServer.Send(mail);



                return result;
            
            }
            catch(Exception ex){


                Contracts.Data.ResponseError<String> result = new Contracts.Data.ResponseError<String>(ex);
                return result;
            
            
            }
        }

        private string servicioSolicitado(string tipoServicio)
        {
            switch (tipoServicio)
            { 
                case "1":
                    return "Fabrica de Software";
                case "2":
                    return "Time-Real Business Intelligence RT-BI";
                case "3":
                    return "Business Process Management (BPM)";
                case "4":
                    return "Aplicaciones Móviles";
                case "5":
                    return "Soluciones en la Nube";
                case "6":
                    return "Asignación de Personal";
                default:
                    return "Otros";
            
            }
        }
    }
}
