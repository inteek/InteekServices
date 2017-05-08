using ProjectLibreria;
using ProjectUtilerias;
using SQLEntity;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectFramework
{
    public class InteekConnect
    {
        #region VARIABLES
            Exception _Error;
            DataTable Dt;
            DataSet Ds;
        #endregion

        #region METODOS

            public bool Registro(string nombre, string apPaterno, string apMaterno, char sexo, string fechaNacimiento, string correo, string telefono, string celular, string universidad, string comoTeEnteraste, string mensaje)
            {
                try
                {
                    ArrayList Parametros = new ArrayList();
                    Parametros.Add(Util.AddSqlParameter("@Nombre", SqlDbType.VarChar, nombre));
                    Parametros.Add(Util.AddSqlParameter("@ApPaterno", SqlDbType.VarChar, apPaterno));
                    Parametros.Add(Util.AddSqlParameter("@ApMaterno", SqlDbType.VarChar, apMaterno));
                    Parametros.Add(Util.AddSqlParameter("@Sexo", SqlDbType.Char, sexo));
                    Parametros.Add(Util.AddSqlParameter("@FechaNacimiento", SqlDbType.VarChar, fechaNacimiento));
                    Parametros.Add(Util.AddSqlParameter("@Correo", SqlDbType.VarChar, correo));
                    Parametros.Add(Util.AddSqlParameter("@Telefono", SqlDbType.VarChar, telefono));
                    Parametros.Add(Util.AddSqlParameter("@Celular", SqlDbType.VarChar, celular));
                    Parametros.Add(Util.AddSqlParameter("@Universidad", SqlDbType.VarChar, universidad));
                    Parametros.Add(Util.AddSqlParameter("@Mensaje", SqlDbType.VarChar, mensaje));
                    Parametros.Add(Util.AddSqlParameter("@ComoTeEnteraste", SqlDbType.VarChar, comoTeEnteraste));


                    Entity ObjEntity = new Entity();
                    ObjEntity.SqlCommand("SpRegistro", Parametros);

                    if (ObjEntity.Error != null)
                    {
                        _Error = ObjEntity.Error;
                        return false;
                    }

                    return true;
                }
                catch (Exception ex)
                {
                    _Error = ex;
                    return false;
                }
            }


            public bool LocalizaCorreoRegistrado(string correo)
            {
                try
                {
                    ArrayList Parametros = new ArrayList();
                    Parametros.Add(Util.AddSqlParameter("@Correo", SqlDbType.VarChar, correo));


                    Entity ObjEntity = new Entity();
                    Dt = ObjEntity.SqlDataAdapter("SpLocalizaCorreoRegistrado", Parametros);

                    if (ObjEntity.Error != null)
                    {
                        _Error = ObjEntity.Error;
                        return false;
                    }
                    else {
                        if (Dt.Rows.Count > 0){
                            return true;
                        }
                        else{
                            return false;
                        }
                    }
                }
                catch (Exception ex)
                {
                    _Error = ex;
                    return false;
                }
            }


            public bool EditarPerfilCurso(int idPerfil, string titulo, string institucion, string duracion, string mesAnio, string urlDocumento, int idTipo, string comentarios)
            {
            try
            {
                    ArrayList Parametros = new ArrayList();
                    Parametros.Add(Util.AddSqlParameter("@IdPerfil", SqlDbType.Int, idPerfil));
                    Parametros.Add(Util.AddSqlParameter("@Titulo", SqlDbType.VarChar, titulo));
                    Parametros.Add(Util.AddSqlParameter("@Institucion", SqlDbType.VarChar, institucion));
                    Parametros.Add(Util.AddSqlParameter("@Duracion", SqlDbType.VarChar, duracion));
                    Parametros.Add(Util.AddSqlParameter("@MesAnio", SqlDbType.VarChar, mesAnio));
                    Parametros.Add(Util.AddSqlParameter("@UrlDocumento", SqlDbType.VarChar, urlDocumento));
                    Parametros.Add(Util.AddSqlParameter("@IdTipo", SqlDbType.Int, idTipo));
                    Parametros.Add(Util.AddSqlParameter("@Comentarios", SqlDbType.VarChar, comentarios));


                    Entity ObjEntity = new Entity();
                    ObjEntity.SqlCommand("SpAgregarCurso", Parametros);

                    if (ObjEntity.Error != null)
                    {
                        _Error = ObjEntity.Error;
                        return false;
                    }

                    return true;
                }
                catch (Exception ex)
                {
                    _Error = ex;
                    return false;
                }
            }


            public List<ProjectLibreria.Curso>  ConsultarPerfilCurso(int idPerfil)
            {
                try
                {
                    List<ProjectLibreria.Curso> lista = new List<ProjectLibreria.Curso>();

                    ArrayList Parametros = new ArrayList();
                    Parametros.Add(Util.AddSqlParameter("@IdPerfil", SqlDbType.Int, idPerfil));

                    Entity ObjEntity = new Entity();
                    Dt = ObjEntity.SqlDataAdapter("spConsultarCursos", Parametros);

                    if (ObjEntity.Error == null)
                    {
                        Curso Objeto;
                        foreach (DataRow dr in Dt.Rows)
                        {
                            Objeto = new Curso();
                            Objeto.IdCurso = Util.ValidaDbNullInt(dr, "IdCurso");
                            Objeto.IdPerfil = Util.ValidaDbNullInt(dr, "IdPerfil");
                            Objeto.Titulo = Util.ValidaDbNullString(dr, "Titulo");
                            Objeto.Institucion = Util.ValidaDbNullString(dr, "Institucion");
                            Objeto.Duracion = Util.ValidaDbNullString(dr, "Duracion");
                            Objeto.MesAnio = Util.ValidaDbNullString(dr, "MesAnio");
                            Objeto.URLDocumento = Util.ValidaDbNullString(dr, "URLDocumento");
                            Objeto.IdTipo = Util.ValidaDbNullInt(dr, "IdTipo");
                            Objeto.Comentarios = Util.ValidaDbNullInt(dr, "Comentarios");

                            lista.Add(Objeto);
                        }
                    }
                    else
                    {
                        _Error = ObjEntity.Error;
                    }

                    return lista;
                }
                catch (Exception ex)
                {
                    _Error = ex;

                    return new List<ProjectLibreria.Curso>();
                }
            }


            public bool EditarDatosPersonales(int idPerfil, string nombre, string apPaterno, string apMaterno, char sexo, string fechaNacimiento)
            {
                try
                {
                    ArrayList Parametros = new ArrayList();
                    Parametros.Add(Util.AddSqlParameter("@IdPerfil", SqlDbType.Int, idPerfil));
                    Parametros.Add(Util.AddSqlParameter("@Nombre", SqlDbType.VarChar, nombre));
                    Parametros.Add(Util.AddSqlParameter("@ApPaterno", SqlDbType.VarChar, apPaterno));
                    Parametros.Add(Util.AddSqlParameter("@ApMaterno", SqlDbType.VarChar, apMaterno));
                    Parametros.Add(Util.AddSqlParameter("@Sexo", SqlDbType.Char, sexo));
                    Parametros.Add(Util.AddSqlParameter("@FechaNacimiento", SqlDbType.VarChar, fechaNacimiento));

                    Entity ObjEntity = new Entity();
                    ObjEntity.SqlCommand("SpEditarDatosPerfil", Parametros);

                    if (ObjEntity.Error != null)
                    {
                        _Error = ObjEntity.Error;
                        return false;
                    }

                    return true;
                }
                catch (Exception ex)
                {
                    _Error = ex;
                    return false;
                }
            }


            public bool EditarDatosContacto(int idPerfil, string telCasa, string celular, string correo, string facebook)
            {
                try
                {
                    ArrayList Parametros = new ArrayList();
                    Parametros.Add(Util.AddSqlParameter("@IdPerfil", SqlDbType.Int, idPerfil));
                    Parametros.Add(Util.AddSqlParameter("@TelCasa", SqlDbType.VarChar, telCasa));
                    Parametros.Add(Util.AddSqlParameter("@Celular", SqlDbType.VarChar, celular));
                    Parametros.Add(Util.AddSqlParameter("@Correo", SqlDbType.VarChar, correo));
                    Parametros.Add(Util.AddSqlParameter("@Facebook", SqlDbType.VarChar, facebook));

                    Entity ObjEntity = new Entity();
                    ObjEntity.SqlCommand("SpEditarDatosContacto", Parametros);

                    if (ObjEntity.Error != null)
                    {
                        _Error = ObjEntity.Error;
                        return false;
                    }

                    return true;
                }
                catch (Exception ex)
                {
                    _Error = ex;
                    return false;
                }
            }


            public bool EditarDatosUniversidad(int idPerfil, string universidad, string carrera, int semestre, string turno)
            {
                try
                {
                    ArrayList Parametros = new ArrayList();
                    Parametros.Add(Util.AddSqlParameter("@IdPerfil", SqlDbType.Int, idPerfil));
                    Parametros.Add(Util.AddSqlParameter("@Universidad", SqlDbType.VarChar, universidad));
                    Parametros.Add(Util.AddSqlParameter("@Carrera", SqlDbType.VarChar, carrera));
                    Parametros.Add(Util.AddSqlParameter("@Semestre", SqlDbType.Int, semestre));
                    Parametros.Add(Util.AddSqlParameter("@Turno", SqlDbType.VarChar, turno));

                    Entity ObjEntity = new Entity();
                    ObjEntity.SqlCommand("SpEditarDatosUniversidad", Parametros);

                    if (ObjEntity.Error != null)
                    {
                        _Error = ObjEntity.Error;
                        return false;
                    }

                    return true;
                }
                catch (Exception ex)
                {
                    _Error = ex;
                    return false;
                }
            }


        
            public bool EditarDatosTrabajo(int idPerfil, bool actualmenteTrabaja, string empresa, string puesto, string horario)
            {
                try
                {
                    ArrayList Parametros = new ArrayList();
                    Parametros.Add(Util.AddSqlParameter("@IdPerfil", SqlDbType.Int, idPerfil));
                    Parametros.Add(Util.AddSqlParameter("@ActualmenteTrabaja", SqlDbType.Bit, actualmenteTrabaja));
                    Parametros.Add(Util.AddSqlParameter("@Empresa", SqlDbType.VarChar, empresa));
                    Parametros.Add(Util.AddSqlParameter("@Puesto", SqlDbType.VarChar, puesto));
                    Parametros.Add(Util.AddSqlParameter("@Horario", SqlDbType.VarChar, horario));

                    Entity ObjEntity = new Entity();
                    ObjEntity.SqlCommand("SpEditarDatosTrabajo", Parametros);

                    if (ObjEntity.Error != null)
                    {
                        _Error = ObjEntity.Error;
                        return false;
                    }

                    return true;
                }
                catch (Exception ex)
                {
                    _Error = ex;
                    return false;
                }
            }


            public bool EditarDatosInformacion(int idPerfil, string descProyecto, string interesCurso)
            {
                try
                {
                    ArrayList Parametros = new ArrayList();
                    Parametros.Add(Util.AddSqlParameter("@IdPerfil", SqlDbType.Int, idPerfil));
                    Parametros.Add(Util.AddSqlParameter("@DescProyecto", SqlDbType.VarChar, descProyecto));
                    Parametros.Add(Util.AddSqlParameter("@InteresCurso", SqlDbType.VarChar, interesCurso));

                    Entity ObjEntity = new Entity();
                    ObjEntity.SqlCommand("SpEditarDatosInformacion", Parametros);

                    if (ObjEntity.Error != null)
                    {
                        _Error = ObjEntity.Error;
                        return false;
                    }

                    return true;
                }
                catch (Exception ex)
                {
                    _Error = ex;
                    return false;
                }
            }


            public ProjectLibreria.Perfil consultarPerfil(int idPerfil)
            {
                try
                {
                    ProjectLibreria.Perfil Objeto = new ProjectLibreria.Perfil();

                    ArrayList Parametros = new ArrayList();
                    Parametros.Add(Util.AddSqlParameter("@IdPerfil", SqlDbType.Int, idPerfil));

                    Entity ObjEntity = new Entity();
                    Dt = ObjEntity.SqlDataAdapter("spConsultarPerfil", Parametros);

                    if (ObjEntity.Error == null)
                    {
                        foreach (DataRow dr in Dt.Rows)
                        {
                            Objeto.IdPerfil = Util.ValidaDbNullInt(dr, "IdPerfil");
                            Objeto.Nombre = Util.ValidaDbNullString(dr, "Nombre");
                            Objeto.ApPaterno = Util.ValidaDbNullString(dr, "ApPaterno");
                            Objeto.ApMaterno = Util.ValidaDbNullString(dr, "ApMaterno");
                            Objeto.Sexo = Util.ValidaDbNullString(dr, "Sexo");
                            Objeto.FechaNacimiento = Util.ValidaDbNullDateTime(dr, "FechaNacimiento");
                            Objeto.TelCasa = Util.ValidaDbNullString(dr, "TelCasa");
                            Objeto.Celular = Util.ValidaDbNullString(dr, "Celular");
                            Objeto.Correo = Util.ValidaDbNullString(dr, "Correo");
                            Objeto.Facebook = Util.ValidaDbNullString(dr, "Facebook");
                            Objeto.Universidad = Util.ValidaDbNullString(dr, "Universidad");
                            Objeto.Carrera = Util.ValidaDbNullString(dr, "Carrera");
                            Objeto.Semestre = Util.ValidaDbNullInt(dr, "Semestre");
                            Objeto.Turno = Util.ValidaDbNullString(dr, "Turno");
                            Objeto.ActualmenteTrabaja = Util.ValidaDbNullBoolean(dr, "ActualmenteTrabaja");
                            Objeto.Empresa = Util.ValidaDbNullString(dr, "Empresa");
                            Objeto.Puesto = Util.ValidaDbNullString(dr, "Puesto");
                            Objeto.Horario = Util.ValidaDbNullString(dr, "Horario");
                            Objeto.DescProyecto = Util.ValidaDbNullString(dr, "DescProyecto");
                            Objeto.InteresCurso = Util.ValidaDbNullString(dr, "InteresCurso");
                            Objeto.UrlFoto = Util.ValidaDbNullString(dr, "UrlFoto");

                        }
                    }
                    else
                    {
                        _Error = ObjEntity.Error;
                    }

                    return Objeto;
                }
                catch (Exception ex)
                {
                    _Error = ex;

                    return new ProjectLibreria.Perfil();
                }
            }

            public ProjectLibreria.PerfilConocimiento consultarPerfilConocimiento(int idPerfil)
            {
                try
                {
                    ProjectLibreria.PerfilConocimiento perfilConocimientos = new ProjectLibreria.PerfilConocimiento();

                    ArrayList Parametros = new ArrayList();
                    Parametros.Add(Util.AddSqlParameter("@IdPerfil", SqlDbType.Int, idPerfil));

                    Entity ObjEntity = new Entity();
                    Ds = ObjEntity.SqlDataAdapterDs("spConsultarConocimientos", Parametros);

                    if (ObjEntity.Error == null)
                    {
                        Conocimiento Objeto;
                        foreach (DataRow dr in Ds.Tables[0].Rows)
                        {
                            Objeto = new Conocimiento();
                            Objeto.IdConocimiento = Util.ValidaDbNullInt(dr, "IdConocimiento");
                            Objeto.IdNivelConocimiento = Util.ValidaDbNullInt(dr, "IdNivelConocimiento");
                            Objeto.IdExperienciaPractica = Util.ValidaDbNullInt(dr, "IdExperienciaPractica");
                            Objeto.IdClasificacion = Util.ValidaDbNullInt(dr, "IdClasificacion");

                            perfilConocimientos.Conocimientos.Add(Objeto);
                        }

                        foreach (DataRow dr in Ds.Tables[1].Rows)
                        {
                            perfilConocimientos.Comentarios = Util.ValidaDbNullString(dr, "Comentarios");
                        }
                    }
                    else
                    {
                        _Error = ObjEntity.Error;
                    }

                    return perfilConocimientos;
                }
                catch (Exception ex)
                {
                    _Error = ex;

                    return new ProjectLibreria.PerfilConocimiento();
                }
            }


            public List<ProjectLibreria.PerfilCompetencia> consultarPerfilCompetencia(int idPerfil)
            {
                try
                {
                    List<ProjectLibreria.PerfilCompetencia> lista = new List<ProjectLibreria.PerfilCompetencia>();

                    ArrayList Parametros = new ArrayList();
                    Parametros.Add(Util.AddSqlParameter("@IdPerfil", SqlDbType.Int, idPerfil));

                    Entity ObjEntity = new Entity();
                    Dt = ObjEntity.SqlDataAdapter("spConsultarCompetencia", Parametros);

                    if (ObjEntity.Error == null)
                    {
                        PerfilCompetencia Objeto;
                        foreach (DataRow dr in Dt.Rows)
                        {
                            Objeto = new PerfilCompetencia();
                            Objeto.IdCompetencia = Util.ValidaDbNullInt(dr, "IdCompetencia");
                            Objeto.IdRespuestaCompetencia = Util.ValidaDbNullInt(dr, "IdRespuestaCompetencia");

                            lista.Add(Objeto);
                        }
                    }
                    else
                    {
                        _Error = ObjEntity.Error;
                    }

                    return lista;
                }
                catch (Exception ex)
                {
                    _Error = ex;

                    return new List<ProjectLibreria.PerfilCompetencia>();
                }
            }


            public bool EditarFotoPerfil(int idPerfil, string urlFoto)
            {
                try
                {
                    ArrayList Parametros = new ArrayList();
                    Parametros.Add(Util.AddSqlParameter("@IdPerfil", SqlDbType.Int, idPerfil));
                    Parametros.Add(Util.AddSqlParameter("@UrlFoto", SqlDbType.VarChar, urlFoto));

                    Entity ObjEntity = new Entity();
                    ObjEntity.SqlCommand("spEditarFotoPerfil", Parametros);

                    if (ObjEntity.Error != null)
                    {
                        _Error = ObjEntity.Error;
                        return false;
                    }

                    return true;
                }
                catch (Exception ex)
                {
                    _Error = ex;
                    return false;
                }
            }


            public bool EditarPerfilConocimientos(int idPerfil, string cadena, int idClasificacion)
            {
                try
                {
                    ArrayList Parametros = new ArrayList();
                    Parametros.Add(Util.AddSqlParameter("@IdPerfil", SqlDbType.Int, idPerfil));
                    Parametros.Add(Util.AddSqlParameter("@Cadena", SqlDbType.VarChar, cadena));
                    Parametros.Add(Util.AddSqlParameter("@IdClasificacion", SqlDbType.VarChar, idClasificacion));

                    Entity ObjEntity = new Entity();
                    ObjEntity.SqlCommand("SpEditarPerfilConocimientos", Parametros);

                    if (ObjEntity.Error != null)
                    {
                        _Error = ObjEntity.Error;
                        return false;
                    }

                    return true;
                }
                catch (Exception ex)
                {
                    _Error = ex;
                    return false;
                }
            }


            public bool EditarComentarioConocimiento(int idPerfil, string conocimiento)
            {
                try
                {
                    ArrayList Parametros = new ArrayList();
                    Parametros.Add(Util.AddSqlParameter("@IdPerfil", SqlDbType.Int, idPerfil));
                    Parametros.Add(Util.AddSqlParameter("@Conocimiento", SqlDbType.VarChar, conocimiento));

                    Entity ObjEntity = new Entity();
                    ObjEntity.SqlCommand("SpEditarConocimiento", Parametros);

                    if (ObjEntity.Error != null)
                    {
                        _Error = ObjEntity.Error;
                        return false;
                    }

                    return true;
                }
                catch (Exception ex)
                {
                    _Error = ex;
                    return false;
                }
            }


            public bool EliminarPerfilCurso(int idCurso)
            {
                try
                {
                    ArrayList Parametros = new ArrayList();
                    Parametros.Add(Util.AddSqlParameter("@IdCurso", SqlDbType.Int, idCurso));

                    Entity ObjEntity = new Entity();
                    ObjEntity.SqlCommand("SpEliminarCurso", Parametros);

                    if (ObjEntity.Error != null)
                    {
                        _Error = ObjEntity.Error;
                        return false;
                    }

                    return true;
                }
                catch (Exception ex)
                {
                    _Error = ex;
                    return false;
                }
            }


            public bool EditarPerfilCompetencia(int idPerfil, string cadena1)
            {
                try
                {
                    ArrayList Parametros = new ArrayList();
                    Parametros.Add(Util.AddSqlParameter("@IdPerfil", SqlDbType.Int, idPerfil));
                    Parametros.Add(Util.AddSqlParameter("@Cadena1", SqlDbType.VarChar, cadena1));

                    Entity ObjEntity = new Entity();
                    ObjEntity.SqlCommand("SpEditarPerfilCompetencia", Parametros);

                    if (ObjEntity.Error != null)
                    {
                        _Error = ObjEntity.Error;
                        return false;
                    }

                    return true;
                }
                catch (Exception ex)
                {
                    _Error = ex;
                    return false;
                }
            }


            public ProjectLibreria.DatosLogin login(string correo, string pwd)
            {
                try
                {
                    ProjectLibreria.DatosLogin Objeto = new ProjectLibreria.DatosLogin();

                    ArrayList Parametros = new ArrayList();
                    Parametros.Add(Util.AddSqlParameter("@Correo", SqlDbType.VarChar, correo));
                    Parametros.Add(Util.AddSqlParameter("@Pwd", SqlDbType.VarChar, pwd));

                    Entity ObjEntity = new Entity();
                    Dt = ObjEntity.SqlDataAdapter("SpLogin", Parametros);

                    if (ObjEntity.Error == null)
                    {
                        foreach (DataRow dr in Dt.Rows)
                        {
                            Objeto.IdPerfil = Util.ValidaDbNullInt(dr, "IdPerfil");
                            Objeto.IdRegistro = Util.ValidaDbNullInt(dr, "IdRegistro");
                            Objeto.Nombre = Util.ValidaDbNullString(dr, "Nombre");

                        }
                    }
                    else
                    {
                        _Error = ObjEntity.Error;
                    }

                    return Objeto;
                }
                catch (Exception ex)
                {
                    _Error = ex;

                    return new ProjectLibreria.DatosLogin();
                }
            }


            public ProjectLibreria.Registros ConsultarRegistros(int idRegistro)
            {
                try
                {
                    ProjectLibreria.Registros Objeto = new ProjectLibreria.Registros();

                    ArrayList Parametros = new ArrayList();
                    Parametros.Add(Util.AddSqlParameter("@IdRegistro", SqlDbType.Int, idRegistro));

                    Entity ObjEntity = new Entity();
                    Dt = ObjEntity.SqlDataAdapter("SpTraerRegistros");

                    if (ObjEntity.Error == null)
                    {
                        foreach (DataRow dr in Dt.Rows)
                        {
                            Objeto.IdRegistro = Util.ValidaDbNullInt(dr, "IdRegistro");
                            Objeto.Nombre = Util.ValidaDbNullString(dr, "Nombre");
                            Objeto.ApPaterno = Util.ValidaDbNullString(dr, "ApPaterno");
                            Objeto.ApMaterno = Util.ValidaDbNullString(dr, "ApMaterno");
                            Objeto.Correo = Util.ValidaDbNullString(dr, "Correo");
                            Objeto.Pwd = Util.ValidaDbNullString(dr, "Pwd");

                        }
                    }
                    else
                    {
                        _Error = ObjEntity.Error;
                    }

                    return Objeto;
                }
                catch (Exception ex)
                {
                    _Error = ex;

                    return new ProjectLibreria.Registros();
                }
            }


            public ProjectLibreria.PerfilAvance ConsultarPerfilAvance(string idPerfil)
            {
                try
                {
                    ProjectLibreria.PerfilAvance Objeto = new ProjectLibreria.PerfilAvance();

                    ArrayList Parametros = new ArrayList();
                    Parametros.Add(Util.AddSqlParameter("@IdPerfil", SqlDbType.Int, idPerfil));

                    Entity ObjEntity = new Entity();
                    Dt = ObjEntity.SqlDataAdapter("SpConsultarPerfilAvance", Parametros);

                    if (ObjEntity.Error == null)
                    {
                        foreach (DataRow dr in Dt.Rows)
                        {
                            Objeto.IdPerfil = Util.ValidaDbNullInt(dr, "IdPerfil");
                            Objeto.Perfil = Util.ValidaDbNullInt(dr, "Perfil");
                            Objeto.Conocimientos = Util.ValidaDbNullInt(dr, "Conocimientos");
                            Objeto.Cursos = Util.ValidaDbNullInt(dr, "Cursos");
                            Objeto.Competencias = Util.ValidaDbNullInt(dr, "Competencias");

                        }
                    }
                    else
                    {
                        _Error = ObjEntity.Error;
                    }

                    return Objeto;
                }
                catch (Exception ex)
                {
                    _Error = ex;

                    return new ProjectLibreria.PerfilAvance();
                }
            }

            public bool EditarPerfilAvance(int idPerfil, string seccion, int porcentaje)
            {
                try
                {
                    ArrayList Parametros = new ArrayList();
                    Parametros.Add(Util.AddSqlParameter("@IdPerfil", SqlDbType.Int, idPerfil));
                    Parametros.Add(Util.AddSqlParameter("@Seccion", SqlDbType.VarChar, seccion));
                    Parametros.Add(Util.AddSqlParameter("@Porcentaje", SqlDbType.Int, porcentaje));

                    Entity ObjEntity = new Entity();
                    ObjEntity.SqlCommand("SpEditarPerfilAvance", Parametros);

                    if (ObjEntity.Error != null)
                    {
                        _Error = ObjEntity.Error;
                        return false;
                    }

                    return true;
                }
                catch (Exception ex)
                {
                    _Error = ex;
                    return false;
                }
            }


        #endregion


        #region PROPIEDADES
            public Exception Error
            {
                get { return _Error; }
            }

        #endregion
    }
}
