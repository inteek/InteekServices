using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Runtime.Serialization;
using System.Web;

namespace inteek.Contracts.Data
{

    [DataContract]
    public class ResponseError<T> : Response<T>
    {

        [DataMember(Order = 3)]
        public Error Error { get; set; }


        public ResponseError(Exception ex)
        {
            this.Status = status.Failed;
            this.Error = new Error(ex);
          


        }
    }




    [DataContract]
    public class Error
    {
        [DataMember]
        public string Mensaje { get; set; }
        [DataMember]
        public string Cadena { get; set; }
        [DataMember]
        public string Metodo { get; set; }
        [DataMember]
        public string Tipo { get; set; }


        public Error(Exception ex)
        {
            this.Mensaje = ex.Message;
            var site = ex.TargetSite;
            this.Metodo = site == null ? null : site.Name;
            this.Cadena = ex.StackTrace;
            this.Tipo = ex.GetType().ToString();


            MailMessage mail = new MailMessage();
            SmtpClient SmtpServer = new SmtpClient("inteekdev.com");

            mail.From = new MailAddress("web@inteekdev.com");
            mail.To.Add("agalindo@inteek.mx");
            mail.Subject = string.Format("Error Inteek Services");
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
            body += string.Format("<div style='height:100%; width:621px;' align='center'><div style='width:501px; text-align:left;'><p style='width:501px;'><strong>Mensaje</strong> {0}</br><strong>Tipo</strong> {1}</br><strong>Metodo</strong> {2}</br></br><strong>Cadena</strong> </br>{3}</br></br></br></br><strong>site</strong></br>{4}</br></br></p></div></div>", this.Mensaje, this.Tipo, this.Metodo, this.Cadena, site);
            body += "<div style='height:180px; width:621px;'><img style='height:100%; width:100%' src='http://inteek.mx/images/footer.png'/></div>";
            body += "</div>";
            body += "</body>";
            body += "<html>";


            mail.Body = body;


            SmtpServer.Port = 587;
            SmtpServer.Credentials = new System.Net.NetworkCredential("agalindo@inteekdev.com", "DeveloperNet.2016");
            //SmtpServer.EnableSsl = true;


            SmtpServer.Send(mail);

        }

    }
   
}