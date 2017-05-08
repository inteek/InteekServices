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
    public class ReporteDetalle
    {
        #region VARIABLES
            private int _mes;
            private int _Ejercicio;
            private Exception _Error;
            private DataSet ds;
        #endregion


        
        #region CONSTRUCTOR


            public ReporteDetalle()
            {
                InicializarVariables();
            }

            private void InicializarVariables()
            {
                _mes = 0;
                _Ejercicio = 0;
            }




            public ReporteDetalle(int mes, int ejercicio)
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

                    ds = ConsultaReporteDetalle();

                    
                    
                    if (_Error == null)
                    {
                      
                        PrepararRelacionDs();
                    }
                   

                }
                catch (Exception ex)
                {
                    _Error = ex;
                }
            }

          


            private DataSet ConsultaReporteDetalle()
            {
                try
                {
                    ArrayList Parametros = new ArrayList();
                    Parametros.Add(Util.AddSqlParameter("@Mes", SqlDbType.VarChar, _mes));
                    Parametros.Add(Util.AddSqlParameter("@ejercicio", SqlDbType.Int, _Ejercicio));


                    ds = new DataSet();
                    Entity ObjEntity = new Entity(Entity.Connection.SAAMI);
                    DataSet Datos = ObjEntity.SqlDataAdapterDs("spReporteDetalle", Parametros);

                   

                    DataTable DtResult = new DataTable("Colaboradores");
                    DtResult.Columns.Add("IdVendedor", Type.GetType("System.Int32"));
                    DtResult.Columns.Add("IdClienteCUC", Type.GetType("System.Int32"));
                    DtResult.Columns.Add("IdTipo", Type.GetType("System.Int32"));
                    DtResult.Columns.Add("IdColaborador", Type.GetType("System.Int32"));
                    DtResult.Columns.Add("NumNomina", Type.GetType("System.Int32"));
                    DtResult.Columns.Add("IdEmpresaComercial", Type.GetType("System.Int32"));
                    DtResult.Columns.Add("EmpresaComercial", Type.GetType("System.String"));
                    DtResult.Columns.Add("Nombre", Type.GetType("System.String"));
                    DtResult.Columns.Add("OpenH", Type.GetType("System.Double"));
                    DtResult.Columns.Add("OpenA", Type.GetType("System.Double"));
                    DtResult.Columns.Add("OpenN", Type.GetType("System.Double"));
                    DtResult.Columns.Add("Total", Type.GetType("System.Double"));
                    DtResult.Columns.Add("Tipo", Type.GetType("System.String"));

                    if (ObjEntity.Error == null)
                    {

                        foreach (DataRow dr in Datos.Tables[3].Rows)
                        {
                            DataTable DtValores;
                            decimal Monto;

                            int IdVendedor = int.Parse(dr["IdVendedor"].ToString());
                            int IdClienteCUC = int.Parse(dr["IdClienteCUC"].ToString());
                            int IdTipo = int.Parse(dr["IdTipo"].ToString());
                            int IdColaborador = int.Parse(dr["IdColaborador"].ToString());
                            int NumNomina = int.Parse(dr["NumNomina"].ToString());
                            int IdEmpresa = int.Parse(dr["IdEmpresa"].ToString());
                            int IdEmpresaComercial = int.Parse(dr["IdEmpresaComercial"].ToString());
                            int EmpresaComercial = int.Parse(dr["EmpresaComercial"].ToString());
                            string Nombre = dr["Nombre"].ToString();
                            string Tipo = dr["Tipo"].ToString();
                            decimal OpenH, OpenA, OpenN, Total;
                            

                            string  caseSwitch = dr["Sistema"].ToString();
                            switch (caseSwitch)
                            {
                                case "OpenH": 
                                    DtValores = ConsultaColaboradorOpenH(IdColaborador, IdEmpresa);
                                    if (_Error != null) { return null;}

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


                            //foreach (DataRow dr4 in dtEmpresa.Rows)
                            //{
                            //    if (dr4["IdEmpresaComercial"].ToString() == IdEmpresaComercial.ToString())
                            //    {

                            //        dr4["TotalOpenH"] = decimal.Parse(dr4["TotalOpenH"].ToString()) + OpenH;
                            //        dr4["TotalOpenA"] = decimal.Parse(dr4["TotalOpenA"].ToString()) + OpenA;
                            //        dr4["TotalOpenN"] = decimal.Parse(dr4["TotalOpenN"].ToString()) + OpenN;
                            //        dr4["TotalOpen"] = decimal.Parse(dr4["TotalOpen"].ToString()) + Total;

                            //        DtResult.DefaultView.RowFilter = "IdColaborador = '" + IdColaborador + "'";
                            //        if (DtResult.DefaultView.Count == 0)
                            //        {
                            //            if (Tipo.ToString() == "Asignados")
                            //            {
                            //                dr4["Asignados"] = int.Parse(dr4["Asignados"].ToString()) + 1;
                            //            }
                            //            else
                            //            {
                            //                dr4["Proyectos"] = int.Parse(dr4["Proyectos"].ToString()) + 1;
                            //            }

                            //            dr4["Colaborador"] = int.Parse(dr4["Colaborador"].ToString()) + 1;

                            //        }
                            //        DtResult.DefaultView.RowFilter = "";
                            //    }
                            //}

                          
                            DtResult.DefaultView.RowFilter = "IdColaborador = '" + IdColaborador + "'" +
                            " AND " + "IdVendedor = '" + IdVendedor + "'" +
                            " AND " + "IdClienteCUC = '" + IdClienteCUC + "'" +
                            " AND " + "IdTipo = '" + IdTipo + "'";


                            if (DtResult.DefaultView.Count > 0)
                            {
                                DtResult.DefaultView[0]["OpenH"] =  decimal.Parse(DtResult.DefaultView[0]["OpenH"].ToString()) + OpenH;
                                DtResult.DefaultView[0]["OpenA"] =  decimal.Parse(DtResult.DefaultView[0]["OpenA"].ToString()) + OpenA;
                                DtResult.DefaultView[0]["OpenN"] =  decimal.Parse(DtResult.DefaultView[0]["OpenN"].ToString()) + OpenN;
                                DtResult.DefaultView[0]["Total"] = decimal.Parse(DtResult.DefaultView[0]["Total"].ToString()) + Total;
                            }
                            else{

                                    DataRow drNew = DtResult.NewRow();
                                    drNew["IdVendedor"] = IdVendedor;
                                    drNew["IdClienteCUC"] = IdClienteCUC;
                                    drNew["IdTipo"] = IdTipo;
                                    drNew["IdColaborador"] = IdColaborador;
                                    drNew["NumNomina"] = NumNomina;
                                    drNew["IdEmpresaComercial"] = IdEmpresaComercial;
                                    drNew["EmpresaComercial"] = EmpresaComercial;
                                    drNew["Nombre"] = Nombre;
                                    drNew["OpenH"] = OpenH;
                                    drNew["OpenA"] = OpenA;
                                    drNew["OpenN"] = OpenN;
                                    drNew["Total"] = Total;
                                    drNew["Tipo"] = Tipo;
                                
                                    DtResult.Rows.Add(drNew); 
                            }

                             DtResult.DefaultView.RowFilter = "";

                        }
                           
                    }
                    else
                    {
                        _Error = ObjEntity.Error;
                        return  null;
                    }


                    
                    Datos.Tables[0].TableName = "Vendedores";
                    Datos.Tables[1].TableName = "Clientes";
                    Datos.Tables[2].TableName = "TipoServicio";
                    
                    Datos.Tables.Remove(Datos.Tables[3]); 
                    Datos.Tables.Add(DtResult);

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


                        ds = new DataSet();
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


                        ds = new DataSet();
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


                        ds = new DataSet();
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














         

            private void PrepararRelacionDs()
            {
                if (ds.Tables["Vendedores"].Rows.Count > 0 && ds.Tables["Clientes"].Rows.Count > 0 && ds.Tables["TipoServicio"].Rows.Count > 0 && ds.Tables["Colaboradores"].Rows.Count > 0)
                {
                    DataRelation Relation1 = ds.Relations.Add("MyRelation1", ds.Tables["Vendedores"].Columns["IdVendedor"], ds.Tables["Clientes"].Columns["IdVendedor"]);
                    Relation1.Nested = true;


                    DataColumn[] dcParent;
                    DataColumn[] dcChild;
                    dcParent = new DataColumn[2];
                    dcParent[0] = ds.Tables["Clientes"].Columns["IdVendedor"];
                    dcParent[1] = ds.Tables["Clientes"].Columns["IdClienteCUC"];

                    dcChild = new DataColumn[2];
                    dcChild[0] = ds.Tables["TipoServicio"].Columns["IdVendedor"];
                    dcChild[1] = ds.Tables["TipoServicio"].Columns["IdClienteCUC"];

                    DataRelation Relation2 = ds.Relations.Add("MyRelation2", dcParent, dcChild);
                    Relation2.Nested = true;


                    dcParent = new DataColumn[3];
                    dcParent[0] = ds.Tables["TipoServicio"].Columns["IdVendedor"];
                    dcParent[1] = ds.Tables["TipoServicio"].Columns["IdClienteCUC"];
                    dcParent[2] = ds.Tables["TipoServicio"].Columns["IdTipo"];

                    dcChild = new DataColumn[3];
                    dcChild[0] = ds.Tables["Colaboradores"].Columns["IdVendedor"];
                    dcChild[1] = ds.Tables["Colaboradores"].Columns["IdClienteCUC"];
                    dcChild[2] = ds.Tables["Colaboradores"].Columns["IdTipo"];


                    DataRelation Relation3 = ds.Relations.Add("MyRelation3", dcParent, dcChild);
                    Relation3.Nested = true;

                }
                

            }

           


            


        

       #endregion


    }
}
