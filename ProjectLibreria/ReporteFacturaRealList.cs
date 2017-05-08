using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SQLEntity;
using System.Data;
using ProjectUtilerias;
using OpenCrypto;

namespace ProjectLibreria
{
    public class ReporteFacturaRealList
    {
        #region VARIABLES
            private int _mes;
            private int _Ejercicio;
            private Exception _Error;
            private DataSet ds;
        #endregion


        
        #region CONSTRUCTOR


            public ReporteFacturaRealList()
            {
                InicializarVariables();
            }

            private void InicializarVariables()
            {
                _mes = 0;
                _Ejercicio = 0;
            }

            public enum TipoReporte
            {
                Colaboradores = 1,
                Infraestructura = 2
            }


            public ReporteFacturaRealList(int mes, int ejercicio)
            {
                _mes = mes;
                _Ejercicio = ejercicio;
                GetObjetos();
            }

           


        #endregion

        #region PROPIEDADES
   

            public int mes
            {
                get { return _mes; }
            }

            public int Ejercicio
            {
                get { return _Ejercicio; }
            }

           


            public DataSet Data
            {
                get { return ds; }
            }

            public Exception Error
            {
                get { return _Error; }
            }

        #endregion


        #region METODOS


            private void GetObjetos()
            {
                try
                {

                    ds = new DataSet();
                    ds = ConsultaReporteFacturaReal();

                   
                }
                catch (Exception ex)
                {
                    _Error = ex;
                }
            }




            private DataSet ConsultaReporteFacturaReal()
            {
                try
                {
                    ArrayList Parametros = new ArrayList();
                    Parametros.Add(Util.AddSqlParameter("@mes", SqlDbType.VarChar, _mes));
                    Parametros.Add(Util.AddSqlParameter("@anio", SqlDbType.Int, _Ejercicio));

                    Entity ObjEntity = new Entity(Entity.Connection.SAAMI);
                    DataSet Datos = ObjEntity.SqlDataAdapterDs("spConsultaFacturacionNormalVSReal", Parametros);


                    string strIdColaborador = "";
                    if (ObjEntity.Error == null)
                    {
                        Datos.Tables[0].TableName = "Clientes";
                        Datos.Tables[0].Columns.Add("Altas", Type.GetType("System.Int32"));
                        Datos.Tables[0].Columns.Add("Bajas", Type.GetType("System.Int32"));
                        Datos.Tables[0].Columns.Add("TotalColaborador", Type.GetType("System.Int32"));
                        Datos.Tables[0].Columns.Add("Variante", Type.GetType("System.Decimal"), "FacturacionReal - Costo");
                        Datos.Tables[0].Columns.Add("Porcentaje", Type.GetType("System.Int32"));

                        Datos.Tables[1].TableName = "Colaboradores";


                        foreach (DataRow dr in Datos.Tables["Colaboradores"].Rows)
                            {
                                DataTable DtValores;
                                decimal Monto;

                                int IdClienteCUC = int.Parse(dr["IdPadre"].ToString());
                                int IdColaborador = int.Parse(dr["IdColaborador"].ToString());
                                int IdEmpresa = int.Parse(dr["IdEmpresa"].ToString());
                         
                                decimal OpenH, OpenA, OpenN, Total;


                                string caseSwitch = dr["Sistema"].ToString();
                                switch (caseSwitch)
                                {
                                    case "OpenH":
                                        DtValores = ConsultaColaboradorOpenH(IdColaborador, IdEmpresa);
                                        if (_Error != null) { return null; }

                                        Monto = 0;
                                        foreach (DataRow dr1 in DtValores.Rows)
                                        {
                                            Monto += decimal.Parse(OpenCrypto.Desencrypt.DesencryptValue(Util.ValidaDbNullString(dr1, "Valor")));
                                        }
                                        OpenH = Monto;
                                        OpenA = 0;
                                        OpenN = 0;
                                        break;
                                    case "OpenA":

                                        DtValores = ConsultaColaboradorOpenA(IdColaborador, IdEmpresa);
                                        if (_Error != null) { return null; }

                                        Monto = 0;
                                        foreach (DataRow dr2 in DtValores.Rows)
                                        {
                                            Monto += decimal.Parse(OpenCrypto.Desencrypt.DesencryptValue(Util.ValidaDbNullString(dr2, "Valor")));
                                        }
                                        OpenH = 0;
                                        OpenA = Monto;
                                        OpenN = 0;
                                        break;

                                    case "OpenN":

                                        DtValores = ConsultaColaboradorOpenN(IdColaborador, IdEmpresa);
                                        if (_Error != null) { return null; }

                                        Monto = 0;
                                        foreach (DataRow dr3 in DtValores.Rows)
                                        {
                                            Monto += decimal.Parse(OpenCrypto.Desencrypt.DesencryptValue(Util.ValidaDbNullString(dr3, "Valor")));
                                            Monto += decimal.Parse(OpenCrypto.Desencrypt.DesencryptValue(Util.ValidaDbNullString(dr3, "BonoDesenpeno")));
                                            Monto += decimal.Parse(OpenCrypto.Desencrypt.DesencryptValue(Util.ValidaDbNullString(dr3, "BonoProyecto")));
                                            Monto += decimal.Parse(OpenCrypto.Desencrypt.DesencryptValue(Util.ValidaDbNullString(dr3, "BonoMensual")));
                                            Monto += decimal.Parse(OpenCrypto.Desencrypt.DesencryptValue(Util.ValidaDbNullString(dr3, "BonoAsignacion")));
                                            Monto += decimal.Parse(OpenCrypto.Desencrypt.DesencryptValue(Util.ValidaDbNullString(dr3, "BonoLaptop")));
                                            Monto += decimal.Parse(OpenCrypto.Desencrypt.DesencryptValue(Util.ValidaDbNullString(dr3, "Otro")));
                                        }
                                        OpenH = 0;
                                        OpenA = 0;
                                        OpenN = Monto;
                                        break;
                                    default:
                                        OpenH = 0;
                                        OpenA = 0;
                                        OpenN = 0;
                                        break;
                                }

                                Total = OpenH + OpenA + OpenN;


                                Datos.Tables["Clientes"].DefaultView.RowFilter = "IdClienteCUC = '" + IdClienteCUC + "'";

                                if (Datos.Tables["Clientes"].DefaultView.Count > 0)
                                {
                                    Datos.Tables["Clientes"].DefaultView[0]["Costo"] = decimal.Parse(Datos.Tables["Clientes"].DefaultView[0]["Costo"].ToString()) + Total;

                                    
                                    if (strIdColaborador.Contains(IdColaborador.ToString()) == false)
                                    {
                                        if (Datos.Tables["Clientes"].DefaultView[0]["TotalColaborador"].ToString() == ""){
                                            Datos.Tables["Clientes"].DefaultView[0]["TotalColaborador"] = 0;
                                        }

                                        Datos.Tables["Clientes"].DefaultView[0]["TotalColaborador"] = int.Parse(Datos.Tables["Clientes"].DefaultView[0]["TotalColaborador"].ToString()) + 1;

                                        if (strIdColaborador == "") { strIdColaborador = IdColaborador.ToString(); } else { strIdColaborador = "," + IdColaborador.ToString(); }
                                    }

                                }

                                Datos.Tables["Clientes"].DefaultView.RowFilter = "";

                            }

                            foreach (DataRow dr1 in Datos.Tables["Clientes"].Rows)
                            {
                                DataTable data = ReporteAsignadosAltaBaja(int.Parse(dr1["IdClienteCUC"].ToString()));
                                dr1["Altas"] = data.Rows[0]["Altas"].ToString();
                                dr1["Bajas"] = data.Rows[0]["Bajas"].ToString();
                            }
                          
                        
                    }
                    else
                    {
                        _Error = ObjEntity.Error;
                        return  null;
                    }


                    
                    return Datos;


                }
                catch (Exception ex)
                {
                    _Error = ex;
                    return null;
                }
            }

            private DataTable ReporteAsignadosAltaBaja(int idClienteCuc)
            {
                try
                {
                    ArrayList Parametros = new ArrayList();
                    Parametros.Add(Util.AddSqlParameter("@IdClienteCUC", SqlDbType.Int, idClienteCuc));
                    Parametros.Add(Util.AddSqlParameter("@Mes", SqlDbType.Int, _mes));
                    Parametros.Add(Util.AddSqlParameter("@ejercicio", SqlDbType.Int, _Ejercicio));


                    Entity ObjEntity = new Entity(Entity.Connection.SAAMI);
                    DataTable Datos = ObjEntity.SqlDataAdapter("spReporteMovimientosColaboradores", Parametros);


                    if (ObjEntity.Error != null)
                    {
                        _Error = ObjEntity.Error;
                        return null;
                    }



                    return Datos;


                }
                catch (Exception ex)
                {
                    _Error = ex;
                    return null;
                }
            }

            #region Montos

                private DataTable ConsultaColaboradorOpenH(int IdColaborador, int IdEmpresa)
                {
                    try
                    {
                        ArrayList Parametros = new ArrayList();
                        Parametros.Add(Util.AddSqlParameter("@IdColaborador", SqlDbType.Int, IdColaborador));
                        Parametros.Add(Util.AddSqlParameter("@IdEmpresa", SqlDbType.Int, IdEmpresa));
                        Parametros.Add(Util.AddSqlParameter("@Mes", SqlDbType.VarChar, _mes));
                        Parametros.Add(Util.AddSqlParameter("@ejercicio", SqlDbType.Int, _Ejercicio));


                        Entity ObjEntity = new Entity(Entity.Connection.SAAMI);
                        DataTable Dt = ObjEntity.SqlDataAdapter("spReporteOpenHPercepcionesDeduccionesColaborador", Parametros);
                        Dt.TableName = "ColaboradorOpenH";


                        if (ObjEntity.Error != null)
                        {
                            _Error = ObjEntity.Error;
                        }

                        return Dt;

                    }
                    catch (Exception ex)
                    {
                        _Error = ex;
                        return null;
                    }
                }

                private DataTable ConsultaColaboradorOpenA(int IdColaborador, int IdEmpresa)
                {
                    try
                    {
                        ArrayList Parametros = new ArrayList();
                        Parametros.Add(Util.AddSqlParameter("@IdColaborador", SqlDbType.Int, IdColaborador));
                        Parametros.Add(Util.AddSqlParameter("@IdEmpresa", SqlDbType.Int, IdEmpresa));
                        Parametros.Add(Util.AddSqlParameter("@Mes", SqlDbType.VarChar, _mes));
                        Parametros.Add(Util.AddSqlParameter("@ejercicio", SqlDbType.Int, _Ejercicio));


                        Entity ObjEntity = new Entity(Entity.Connection.SAAMI);
                        DataTable Dt = ObjEntity.SqlDataAdapter("spReporteOpenAPercepcionesDeduccionesColaborador", Parametros);
                        Dt.TableName = "ColaboradorOpenA";


                        if (ObjEntity.Error != null)
                        {
                            _Error = ObjEntity.Error;
                        }

                        return Dt;

                    }
                    catch (Exception ex)
                    {
                        _Error = ex;
                        return null;
                    }
                }

                private DataTable ConsultaColaboradorOpenN(int IdColaborador, int IdEmpresa)
                {
                    try
                    {
                        ArrayList Parametros = new ArrayList();
                        Parametros.Add(Util.AddSqlParameter("@IdColaborador", SqlDbType.Int, IdColaborador));
                        Parametros.Add(Util.AddSqlParameter("@IdEmpresa", SqlDbType.Int, IdEmpresa));
                        Parametros.Add(Util.AddSqlParameter("@Mes", SqlDbType.VarChar, _mes));
                        Parametros.Add(Util.AddSqlParameter("@ejercicio", SqlDbType.Int, _Ejercicio));


                        Entity ObjEntity = new Entity(Entity.Connection.SAAMI);
                        DataTable Dt = ObjEntity.SqlDataAdapter("spConsultaColaboradorNomina", Parametros);
                        Dt.TableName = "ColaboradorOpenN";


                        if (ObjEntity.Error != null)
                        {
                            _Error = ObjEntity.Error;
                        }

                        return Dt;

                    }
                    catch (Exception ex)
                    {
                        _Error = ex;
                        return null;
                    }
                }

            #endregion














         

          

           


            


        

       #endregion


    }
}
