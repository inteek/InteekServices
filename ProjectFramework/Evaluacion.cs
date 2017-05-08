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
    public  class Evaluacion
    {
        #region VARIABLES
            Exception _Error;
            DataTable Dt;
            DataSet Ds;
        #endregion

        #region METODOS



            #region Configuracio
                public ProjectLibreria.Configuracion  ConfiguracionGet()
                {
                    try
                    {
                        ProjectLibreria.Configuracion objecto = null;

                        Entity ObjEntity = new Entity();
                        Dt = ObjEntity.SqlDataAdapter("spConfiguracion");

                        if (ObjEntity.Error == null)
                        {
                            objecto = new Configuracion();
                            foreach (DataRow dr in Dt.Rows)
                            {
                                objecto.Remitente = Util.ValidaDbNullString(dr, "Remitente");
                                objecto.Asunto = Util.ValidaDbNullString(dr, "Asunto");
                                objecto.Mensaje = Util.ValidaDbNullString(dr, "Mensaje");
                            }
                        }
                        else
                        {
                            _Error = ObjEntity.Error;
                        }

                        return objecto;
                    }
                    catch (Exception ex)
                    {
                        _Error = ex;

                        return null;
                    }
                }

                public bool ConfiguracionSet(string remitente, string asunto, string mensaje)
            {
                try
                {
                    ArrayList Parametros = new ArrayList();
                    Parametros.Add(Util.AddSqlParameter("@remitente", SqlDbType.VarChar, remitente));
                    Parametros.Add(Util.AddSqlParameter("@asunto", SqlDbType.VarChar, asunto));
                    Parametros.Add(Util.AddSqlParameter("@mensaje", SqlDbType.VarChar, mensaje));


                    Entity ObjEntity = new Entity();
                    ObjEntity.SqlCommand("spConfiguracionActualiza", Parametros);

                    if (ObjEntity.Error != null)
                    {
                        _Error = ObjEntity.Error;
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


            public List<ProjectLibreria.Contacto> ContactosGet(int idLista)
            {
                try
                {
                    List<ProjectLibreria.Contacto> lista = new List<ProjectLibreria.Contacto>();

                    ArrayList Parametros = new ArrayList();
                    Parametros.Add(Util.AddSqlParameter("@idLista", SqlDbType.Int, idLista));

                    Entity ObjEntity = new Entity();
                    Dt = ObjEntity.SqlDataAdapter("spContacto", Parametros);

                    if (ObjEntity.Error == null)
                    {
                        Contacto Objeto;
                        foreach (DataRow dr in Dt.Rows)
                        {
                            Objeto = new Contacto();
                            Objeto.IdContacto = Util.ValidaDbNullInt(dr, "IdContacto");
                            Objeto.Nombre = Util.ValidaDbNullString(dr, "Nombre");
                            Objeto.ApellidoPaterno = Util.ValidaDbNullString(dr, "ApellidoPaterno");
                            Objeto.ApellidoMaterno = Util.ValidaDbNullString(dr, "ApellidoMaterno");
                            Objeto.Email = Util.ValidaDbNullString(dr, "Email");
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

                    return new List<ProjectLibreria.Contacto>();
                }
            }

            public bool ContactoSet(int idContacto, string nombre, string apellidoPaterno, string apellidoMaterno, string email)
            {
                try
                {
                    ArrayList Parametros = new ArrayList();
                    Parametros.Add(Util.AddSqlParameter("@IdContacto", SqlDbType.Int, idContacto));
                    Parametros.Add(Util.AddSqlParameter("@Nombre", SqlDbType.VarChar, nombre));
                    Parametros.Add(Util.AddSqlParameter("@ApellidoPaterno", SqlDbType.VarChar, apellidoPaterno));
                    Parametros.Add(Util.AddSqlParameter("@ApellidoMaterno", SqlDbType.VarChar, apellidoMaterno));
                    Parametros.Add(Util.AddSqlParameter("@Email", SqlDbType.VarChar, email));


                    Entity ObjEntity = new Entity();
                    ObjEntity.SqlCommand("spContactoActualiza", Parametros);

                    if (ObjEntity.Error != null)
                    {
                        _Error = ObjEntity.Error;
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
