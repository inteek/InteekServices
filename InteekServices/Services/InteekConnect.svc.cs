using inteek.Contracts.Operation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using ProjectFramework;



namespace inteek.Services
{
    public class InteekConnect : IInteekConnect
    {

        public Contracts.Data.Response<string> Registro(string nombre, string appPaterno, string appMaterno, char sexo, string fechaNacimiento, string correo, string telefono, string celular, string universidad, string comoTeEnteraste, string mensaje)
        {
            try
            {

                ProjectFramework.InteekConnect framework = new ProjectFramework.InteekConnect();
                bool localizado = framework.LocalizaCorreoRegistrado(correo);
                
                if (localizado == false && framework.Error == null)
                {
                    framework.Registro(nombre, appPaterno, appMaterno, sexo, fechaNacimiento, correo, telefono, celular, universidad, comoTeEnteraste, mensaje);

                    if (framework.Error == null)
                    {

                        MailMessage mail = new MailMessage();
                        SmtpClient SmtpServer = new SmtpClient("inteek.mx");

                        mail.From = new MailAddress("connect@inteek.mx");
                        mail.To.Add(correo);
                        mail.Subject = "Bienvenido al programa Impulsando Talentos";
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
                        body += "<img src='http://inteek.mx/images/header3.png' style='height:100%; width:100%' />";
                        body += "</div><br>";
                        body += string.Format("<div style='height:100%; width:621px;' align='center'><div style='width:501px; text-align:left;'><p style='width:501px;'><strong>Hola {0}</strong>,<br><br>Gracias por formar parte de este programa, te deseamos mucha suerte en este proceso de selección, recuerda que el éxito es la suma de pequeños esfuerzos repetidos día tras día.</p></div></div><br>", nombre);
                        body += "<div style='height:960px; width:621px;'>";
                        body += "<img src='http://connect.inteek.mx/images/PlanPrograma2.jpg' style='height:100%; width:100%' />";
                        body += "</div><br><br><br>";
                        //body += "<div style='height:180px; width:621px;'><img style='height:100%; width:100%' src='http://inteek.mx/images/footer.png'/></div>";
                        body += "</div>";
                        body += "</body>";
                        body += "<html>";


                        mail.Body = body;


                        SmtpServer.Port = 587;
                        SmtpServer.Credentials = new System.Net.NetworkCredential("connect@inteek.mx", "impulsandotalentos2017");
                        //SmtpServer.EnableSsl = true;


                        SmtpServer.Send(mail);



                        Contracts.Data.Response<String> result = new Contracts.Data.Response<String>();
                        return result;

                    }
                    else
                    {
                        Contracts.Data.ResponseError<String> result = new Contracts.Data.ResponseError<String>(framework.Error);
                        return result;
                    }
                }
                else
                {
                    if (framework.Error == null)
                    {
                        Contracts.Data.Response<String> result = new Contracts.Data.Response<String>();
                        result.List.Add("Registro Encontrado");
                        return result;
                    }
                    else
                    {
                        Contracts.Data.ResponseError<String> result = new Contracts.Data.ResponseError<String>(framework.Error);
                        return result;
                    }
                }

            }
            catch (Exception ex)
            {
                Contracts.Data.ResponseError<String> result = new Contracts.Data.ResponseError<String>(ex);
                return result;
            }


        }


        public Contracts.Data.Response<string> EditarPerfilCurso(int idPerfil, string titulo, string institucion, string duracion, string mesAnio, string urlDocumento, int idTipo, string comentarios)
        {
            try
            {
                ProjectFramework.InteekConnect framework = new ProjectFramework.InteekConnect();
                framework.EditarPerfilCurso(idPerfil, titulo, institucion, duracion, mesAnio, urlDocumento, idTipo, comentarios);

                if (framework.Error == null)
                {
                    Contracts.Data.Response<String> result = new Contracts.Data.Response<String>();
                    return result;
                }
                else
                {
                    Contracts.Data.ResponseError<String> result = new Contracts.Data.ResponseError<String>(framework.Error);
                    return result;
                }

            }
            catch (Exception ex)
            {
                Contracts.Data.ResponseError<String> result = new Contracts.Data.ResponseError<String>(ex);
                return result;
            }


        }


        public Contracts.Data.Response<Entities.Curso> ConsultarPerfilCurso(string idPerfil)
        {
            try
            {

                ProjectFramework.InteekConnect framework = new ProjectFramework.InteekConnect();
                List<ProjectLibreria.Curso> lista = framework.ConsultarPerfilCurso(int.Parse(idPerfil));

                if (framework.Error == null)
                {
                    Contracts.Data.Response<Entities.Curso> result = new Contracts.Data.Response<Entities.Curso>();

                    result.List = (from x in lista
                                   select new Entities.Curso
                                    {
                                        IdCurso = x.IdCurso,
                                        IdPerfil = x.IdPerfil,
                                        Titulo = x.Titulo,
                                        Institucion = x.Institucion,
                                        Duracion = x.Duracion,
                                        MesAnio = x.MesAnio,
                                        URLDocumento = x.URLDocumento,
                                        IdTipo = x.IdTipo,
                                        Comentarios = x.Comentarios
                                    }).ToList();


                    
                    return result;
                }
                else
                {
                    Contracts.Data.ResponseError<Entities.Curso> result = new Contracts.Data.ResponseError<Entities.Curso>(framework.Error);
                    return result;
                }

            }
            catch (Exception ex)
            {
                Contracts.Data.ResponseError<Entities.Curso> result = new Contracts.Data.ResponseError<Entities.Curso>(ex);
                return result;
            }
        }


        public Contracts.Data.Response<string> EditarDatosPersonales(int idPerfil, string nombre, string apPaterno, string apMaterno, char sexo, string fechaNacimiento)
        {
            try
            {
                ProjectFramework.InteekConnect framework = new ProjectFramework.InteekConnect();
                framework.EditarDatosPersonales(idPerfil, nombre, apPaterno, apMaterno, sexo, fechaNacimiento);

                if (framework.Error == null)
                {
                    Contracts.Data.Response<String> result = new Contracts.Data.Response<String>();
                    return result;
                }
                else
                {
                    Contracts.Data.ResponseError<String> result = new Contracts.Data.ResponseError<String>(framework.Error);
                    return result;
                }

            }
            catch (Exception ex)
            {
                Contracts.Data.ResponseError<String> result = new Contracts.Data.ResponseError<String>(ex);
                return result;
            }
        }


        public Contracts.Data.Response<string> EditarDatosContacto(int idPerfil, string telCasa, string celular, string correo, string facebook)
        {
            try
            {
                ProjectFramework.InteekConnect framework = new ProjectFramework.InteekConnect();
                framework.EditarDatosContacto(idPerfil, telCasa, celular, correo, facebook);

                if (framework.Error == null)
                {
                    Contracts.Data.Response<String> result = new Contracts.Data.Response<String>();
                    return result;
                }
                else
                {
                    Contracts.Data.ResponseError<String> result = new Contracts.Data.ResponseError<String>(framework.Error);
                    return result;
                }

            }
            catch (Exception ex)
            {
                Contracts.Data.ResponseError<String> result = new Contracts.Data.ResponseError<String>(ex);
                return result;
            }
        }


        public Contracts.Data.Response<string> EditarDatosUniversidad(int idPerfil, string universidad, string carrera, int semestre, string turno)
        {
            try
            {
                ProjectFramework.InteekConnect framework = new ProjectFramework.InteekConnect();
                framework.EditarDatosUniversidad(idPerfil, universidad, carrera, semestre, turno);

                if (framework.Error == null)
                {
                    Contracts.Data.Response<String> result = new Contracts.Data.Response<String>();
                    return result;
                }
                else
                {
                    Contracts.Data.ResponseError<String> result = new Contracts.Data.ResponseError<String>(framework.Error);
                    return result;
                }

            }
            catch (Exception ex)
            {
                Contracts.Data.ResponseError<String> result = new Contracts.Data.ResponseError<String>(ex);
                return result;
            }
        }


        public Contracts.Data.Response<string> EditarDatosTrabajo(int idPerfil, bool actualmenteTrabaja, string empresa, string puesto, string horario)
        {
            try
            {
                ProjectFramework.InteekConnect framework = new ProjectFramework.InteekConnect();
                framework.EditarDatosTrabajo(idPerfil, actualmenteTrabaja, empresa, puesto, horario);

                if (framework.Error == null)
                {
                    Contracts.Data.Response<String> result = new Contracts.Data.Response<String>();
                    return result;
                }
                else
                {
                    Contracts.Data.ResponseError<String> result = new Contracts.Data.ResponseError<String>(framework.Error);
                    return result;
                }

            }
            catch (Exception ex)
            {
                Contracts.Data.ResponseError<String> result = new Contracts.Data.ResponseError<String>(ex);
                return result;
            }
        }


        public Contracts.Data.Response<string> EditarDatosInformacion(int idPerfil, string descProyecto, string interesCurso)
        {
            try
            {
                ProjectFramework.InteekConnect framework = new ProjectFramework.InteekConnect();
                framework.EditarDatosInformacion(idPerfil, descProyecto, interesCurso);

                if (framework.Error == null)
                {
                    Contracts.Data.Response<String> result = new Contracts.Data.Response<String>();
                    return result;
                }
                else
                {
                    Contracts.Data.ResponseError<String> result = new Contracts.Data.ResponseError<String>(framework.Error);
                    return result;
                }

            }
            catch (Exception ex)
            {
                Contracts.Data.ResponseError<String> result = new Contracts.Data.ResponseError<String>(ex);
                return result;
            }
        }


        public Contracts.Data.Response<Entities.Perfil> ConsultarPerfil(string idPerfil)
        {
            try
            {

                ProjectFramework.InteekConnect framework = new ProjectFramework.InteekConnect();
                ProjectLibreria.Perfil ObjetoFramework = framework.consultarPerfil(int.Parse(idPerfil));

                if (framework.Error == null)
                {
                    Contracts.Data.Response<Entities.Perfil> result = new Contracts.Data.Response<Entities.Perfil>();

                    Entities.Perfil Objeto = new Entities.Perfil();

                    Objeto.IdPerfil = ObjetoFramework.IdPerfil;
                    Objeto.Nombre = ObjetoFramework.Nombre;
                    Objeto.ApPaterno = ObjetoFramework.ApPaterno;
                    Objeto.ApMaterno = ObjetoFramework.ApMaterno;
                    Objeto.Sexo = ObjetoFramework.Sexo;
                    Objeto.FechaNacimiento = string.Format("{0:dd/MM/yyyy}", ObjetoFramework.FechaNacimiento);
                    Objeto.TelCasa = ObjetoFramework.TelCasa;
                    Objeto.Celular = ObjetoFramework.Celular;
                    Objeto.Correo = ObjetoFramework.Correo;
                    Objeto.Facebook = ObjetoFramework.Facebook;
                    Objeto.Universidad = ObjetoFramework.Universidad;
                    Objeto.Carrera = ObjetoFramework.Carrera;
                    Objeto.Semestre = ObjetoFramework.Semestre;
                    Objeto.Turno = ObjetoFramework.Turno;
                    Objeto.ActualmenteTrabaja = ObjetoFramework.ActualmenteTrabaja;
                    Objeto.Empresa = ObjetoFramework.Empresa;
                    Objeto.Puesto = ObjetoFramework.Puesto;
                    Objeto.Horario = ObjetoFramework.Horario;
                    Objeto.DescProyecto = ObjetoFramework.DescProyecto;
                    Objeto.InteresCurso = ObjetoFramework.InteresCurso;
                    Objeto.UrlFoto = ObjetoFramework.UrlFoto;
                    
        
                    result.List.Add(Objeto);

                    return result;
                }
                else
                {
                    Contracts.Data.ResponseError<Entities.Perfil> result = new Contracts.Data.ResponseError<Entities.Perfil>(framework.Error);
                    return result;
                }

            }
            catch (Exception ex)
            {
                Contracts.Data.ResponseError<Entities.Perfil> result = new Contracts.Data.ResponseError<Entities.Perfil>(ex);
                return result;
            }
        }


        public Contracts.Data.Response<Entities.PerfilConocimiento> ConsultarPerfilConocimiento(string idPerfil)
        {
            try
            {

                ProjectFramework.InteekConnect framework = new ProjectFramework.InteekConnect();
                ProjectLibreria.PerfilConocimiento lista = framework.consultarPerfilConocimiento(int.Parse(idPerfil));

                if (framework.Error == null)
                {
                    Contracts.Data.Response<Entities.PerfilConocimiento> result = new Contracts.Data.Response<Entities.PerfilConocimiento>();

                    result.List = (from x in lista.Conocimientos
                                   select new Entities.PerfilConocimiento
                                   {
                                       IdConocimiento = x.IdConocimiento,
                                       IdNivelConocimiento = x.IdNivelConocimiento,
                                       IdExperienciaPractica = x.IdExperienciaPractica,
                                       IdClasificacion = x.IdClasificacion
                                   }).ToList();

                    result.Comentarios = lista.Comentarios;

                    return result;
                }
                else
                {
                    Contracts.Data.ResponseError<Entities.PerfilConocimiento> result = new Contracts.Data.ResponseError<Entities.PerfilConocimiento>(framework.Error);
                    return result;
                }

            }
            catch (Exception ex)
            {
                Contracts.Data.ResponseError<Entities.PerfilConocimiento> result = new Contracts.Data.ResponseError<Entities.PerfilConocimiento>(ex);
                return result;
            }
        }


        public Contracts.Data.Response<Entities.PerfilCompetencia> ConsultarPerfilCompetencia(string idPerfil)
        {
            try
            {

                ProjectFramework.InteekConnect framework = new ProjectFramework.InteekConnect();
                List<ProjectLibreria.PerfilCompetencia> lista = framework.consultarPerfilCompetencia(int.Parse(idPerfil));

                if (framework.Error == null)
                {
                    Contracts.Data.Response<Entities.PerfilCompetencia> result = new Contracts.Data.Response<Entities.PerfilCompetencia>();

                    result.List = (from x in lista
                                   select new Entities.PerfilCompetencia
                                   {
                                       IdCompetencia = x.IdCompetencia,
                                       IdRespuestaCompetencia = x.IdRespuestaCompetencia
                                   }).ToList();



                    return result;
                }
                else
                {
                    Contracts.Data.ResponseError<Entities.PerfilCompetencia> result = new Contracts.Data.ResponseError<Entities.PerfilCompetencia>(framework.Error);
                    return result;
                }

            }
            catch (Exception ex)
            {
                Contracts.Data.ResponseError<Entities.PerfilCompetencia> result = new Contracts.Data.ResponseError<Entities.PerfilCompetencia>(ex);
                return result;
            }
        }


        public Contracts.Data.Response<string> EditarFotoPerfil(int idPerfil, string urlFoto)
        {
            try
            {
                ProjectFramework.InteekConnect framework = new ProjectFramework.InteekConnect();
                framework.EditarFotoPerfil(idPerfil, urlFoto);

                if (framework.Error == null)
                {
                    Contracts.Data.Response<String> result = new Contracts.Data.Response<String>();
                    return result;
                }
                else
                {
                    Contracts.Data.ResponseError<String> result = new Contracts.Data.ResponseError<String>(framework.Error);
                    return result;
                }

            }
            catch (Exception ex)
            {
                Contracts.Data.ResponseError<String> result = new Contracts.Data.ResponseError<String>(ex);
                return result;
            }
        }


        public Contracts.Data.Response<string> EditarPerfilProgramacion(int idPerfil, string cadena)
        {

            try
            {
                ProjectFramework.InteekConnect framework = new ProjectFramework.InteekConnect();
                framework.EditarPerfilConocimientos(idPerfil, cadena, 1);

                if (framework.Error == null)
                {
                    Contracts.Data.Response<String> result = new Contracts.Data.Response<String>();
                    return result;
                }
                else
                {
                    Contracts.Data.ResponseError<String> result = new Contracts.Data.ResponseError<String>(framework.Error);
                    return result;
                }

            }
            catch (Exception ex)
            {
                Contracts.Data.ResponseError<String> result = new Contracts.Data.ResponseError<String>(ex);
                return result;
            }
        }


        public Contracts.Data.Response<string> EditarPerfilBase(int idPerfil, string cadena)
        {

            try
            {
                ProjectFramework.InteekConnect framework = new ProjectFramework.InteekConnect();
                framework.EditarPerfilConocimientos(idPerfil, cadena, 2);

                if (framework.Error == null)
                {
                    Contracts.Data.Response<String> result = new Contracts.Data.Response<String>();
                    return result;
                }
                else
                {
                    Contracts.Data.ResponseError<String> result = new Contracts.Data.ResponseError<String>(framework.Error);
                    return result;
                }

            }
            catch (Exception ex)
            {
                Contracts.Data.ResponseError<String> result = new Contracts.Data.ResponseError<String>(ex);
                return result;
            }
        }


        public Contracts.Data.Response<string> EditarPerfilFramework(int idPerfil, string cadena)
        {

            try
            {
                ProjectFramework.InteekConnect framework = new ProjectFramework.InteekConnect();
                framework.EditarPerfilConocimientos(idPerfil, cadena, 3);

                if (framework.Error == null)
                {
                    Contracts.Data.Response<String> result = new Contracts.Data.Response<String>();
                    return result;
                }
                else
                {
                    Contracts.Data.ResponseError<String> result = new Contracts.Data.ResponseError<String>(framework.Error);
                    return result;
                }

            }
            catch (Exception ex)
            {
                Contracts.Data.ResponseError<String> result = new Contracts.Data.ResponseError<String>(ex);
                return result;
            }
        }


        public Contracts.Data.Response<string> EditarComentarioConocimiento(int idPerfil, string conocimiento)
        {
            try
            {
                ProjectFramework.InteekConnect framework = new ProjectFramework.InteekConnect();
                framework.EditarComentarioConocimiento(idPerfil, conocimiento);

                if (framework.Error == null)
                {
                    Contracts.Data.Response<String> result = new Contracts.Data.Response<String>();
                    return result;
                }
                else
                {
                    Contracts.Data.ResponseError<String> result = new Contracts.Data.ResponseError<String>(framework.Error);
                    return result;
                }

            }
            catch (Exception ex)
            {
                Contracts.Data.ResponseError<String> result = new Contracts.Data.ResponseError<String>(ex);
                return result;
            }
        }


        public Contracts.Data.Response<string> EliminarPerfilCurso(int idCurso)  
        {
            try
            {
                ProjectFramework.InteekConnect framework = new ProjectFramework.InteekConnect();
                framework.EliminarPerfilCurso(idCurso);

                if (framework.Error == null)
                {
                    Contracts.Data.Response<String> result = new Contracts.Data.Response<String>();
                    return result;
                }
                else
                {
                    Contracts.Data.ResponseError<String> result = new Contracts.Data.ResponseError<String>(framework.Error);
                    return result;
                }

            }
            catch (Exception ex)
            {
                Contracts.Data.ResponseError<String> result = new Contracts.Data.ResponseError<String>(ex);
                return result;
            }
        }


        public Contracts.Data.Response<string> EditarPerfilCompetencia(int idPerfil, string cadena1)
        {
            try
            {
                ProjectFramework.InteekConnect framework = new ProjectFramework.InteekConnect();
                framework.EditarPerfilCompetencia(idPerfil, cadena1);

                if (framework.Error == null)
                {
                    Contracts.Data.Response<String> result = new Contracts.Data.Response<String>();
                    return result;
                }
                else
                {
                    Contracts.Data.ResponseError<String> result = new Contracts.Data.ResponseError<String>(framework.Error);
                    return result;
                }

            }
            catch (Exception ex)
            {
                Contracts.Data.ResponseError<String> result = new Contracts.Data.ResponseError<String>(ex);
                return result;
            }
        }


        public Contracts.Data.Response<Entities.DatosLogin> Login(string correo, string pwd)
        {
            try
            {

                ProjectFramework.InteekConnect framework = new ProjectFramework.InteekConnect();
                ProjectLibreria.DatosLogin ObjetoFramework = framework.login(correo, pwd);

                if (framework.Error == null)
                {
                    Contracts.Data.Response<Entities.DatosLogin> result = new Contracts.Data.Response<Entities.DatosLogin>();
                    Entities.DatosLogin Objeto = new Entities.DatosLogin();

                    Objeto.IdPerfil = ObjetoFramework.IdPerfil;
                    Objeto.IdRegistro = ObjetoFramework.IdRegistro;
                    Objeto.Nombre = ObjetoFramework.Nombre;


                    result.List.Add(Objeto);

                    return result;
                }
                else
                {
                    Contracts.Data.ResponseError<Entities.DatosLogin> result = new Contracts.Data.ResponseError<Entities.DatosLogin>(framework.Error);
                    return result;
                }

            }
            catch (Exception ex)
            {
                Contracts.Data.ResponseError<Entities.DatosLogin> result = new Contracts.Data.ResponseError<Entities.DatosLogin>(ex);
                return result;
            }
        }



        public Contracts.Data.Response<Entities.PerfilAvance> ConsultarPerfilAvance(string idPerfil)
        {
            try
            {

                ProjectFramework.InteekConnect framework = new ProjectFramework.InteekConnect();
                ProjectLibreria.PerfilAvance ObjetoFramework = framework.ConsultarPerfilAvance(idPerfil);

                if (framework.Error == null)
                {

                    Contracts.Data.Response<Entities.PerfilAvance> result = new Contracts.Data.Response<Entities.PerfilAvance>();
                    Entities.PerfilAvance Objeto = new Entities.PerfilAvance();

                    Objeto.IdPerfil = ObjetoFramework.IdPerfil;
                    Objeto.Perfil = ObjetoFramework.Perfil;
                    Objeto.Conocimientos = ObjetoFramework.Conocimientos;
                    Objeto.Cursos = ObjetoFramework.Cursos;
                    Objeto.Competencias = ObjetoFramework.Competencias;


                    result.List.Add(Objeto);

                    return result;
                }
                else
                {
                    Contracts.Data.ResponseError<Entities.PerfilAvance> result = new Contracts.Data.ResponseError<Entities.PerfilAvance>(framework.Error);
                    return result;
                }

            }
            catch (Exception ex)
            {
                Contracts.Data.ResponseError<Entities.PerfilAvance> result = new Contracts.Data.ResponseError<Entities.PerfilAvance>(ex);
                return result;
            }
        }

        public Contracts.Data.Response<string> EditarPerfilAvance(int idPerfil, string seccion, int porcentaje)
        {
            try
            {
                ProjectFramework.InteekConnect framework = new ProjectFramework.InteekConnect();
                framework.EditarPerfilAvance(idPerfil, seccion, porcentaje);

                if (framework.Error == null)
                {
                    Contracts.Data.Response<String> result = new Contracts.Data.Response<String>();
                    return result;
                }
                else
                {
                    Contracts.Data.ResponseError<String> result = new Contracts.Data.ResponseError<String>(framework.Error);
                    return result;
                }

            }
            catch (Exception ex)
            {
                Contracts.Data.ResponseError<String> result = new Contracts.Data.ResponseError<String>(ex);
                return result;
            }
        }




    }
}


