using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


namespace SQLEntity
{
    public class Entity
    {
        
        #region VARIABLES

            SqlDataAdapter Adapter;
            SqlCommand Command;
            SqlConnection Conexion;
            Exception _Error;

        #endregion


        #region PROPIEDADES

            public Exception Error
            {
                get { return _Error; }
            }

            public enum Connection
            {
                SAAMI = 1,
                OpenPromocionRH = 2,
                OpenH = 3
            }

        #endregion
        

        #region CONSTRUCTOR

            public Entity()
            {
                Adapter = new SqlDataAdapter();
                Command = new SqlCommand();


                string cnx = System.Configuration.ConfigurationSettings.AppSettings["BD"];
                Conexion = new SqlConnection(cnx);



            }

            public Entity(string Cnx)
            {
                Adapter = new SqlDataAdapter();
                Command = new SqlCommand();
                Conexion = new SqlConnection(Cnx);
                      
            }
        
        #endregion
        
        
        #region METODOS


            public DataTable SqlDataAdapter(String Stored)
            {
                try
                {
                    DataTable Dt = new DataTable();

                    Conexion.Open();
                    Adapter.SelectCommand = new SqlCommand();
                    Adapter.SelectCommand.Connection = Conexion;
                    Adapter.SelectCommand.CommandText = Stored;
                    Adapter.SelectCommand.CommandType = CommandType.StoredProcedure;


                    Adapter.SelectCommand.CommandTimeout = Conexion.ConnectionTimeout;
                    Adapter.Fill(Dt);

                    return Dt;
                }
                catch (Exception ex)
                {
                    _Error = new Exception();
                    _Error = ex;

                    DataTable Dt = new DataTable();
                    return Dt;
                }

                finally
                {
                    Adapter.Dispose();
                    ConexionDispose();
                }


            }


            public DataTable SqlDataAdapter(String Stored, ArrayList Parametros)
            {
                try
                {
                    DataTable Dt = new DataTable();

                    Conexion.Open();
                    Adapter.SelectCommand = new SqlCommand();
                    Adapter.SelectCommand.Connection = Conexion;
                    Adapter.SelectCommand.CommandText = Stored;
                    Adapter.SelectCommand.CommandType = CommandType.StoredProcedure;


                    if (Parametros != null)
                    {
                        foreach (SqlParameter param in Parametros)
                        {
                            Adapter.SelectCommand.Parameters.Add(param);
                        }
                    }

                    Adapter.SelectCommand.CommandTimeout = Conexion.ConnectionTimeout;
                    Adapter.Fill(Dt);

                    return Dt;
                }
                catch (Exception ex)
                {
                    _Error = new Exception();
                    _Error = ex;

                    DataTable Dt = new DataTable();
                    return Dt;
                }

                finally
                {
                    Adapter.Dispose();
                    ConexionDispose();
                }


            }


            public DataSet SqlDataAdapterDs(String Stored, ArrayList Parametros)
            {
                try
                {
                    DataSet Ds = new DataSet();

                    Conexion.Open();
                    Adapter.SelectCommand = new SqlCommand();
                    Adapter.SelectCommand.Connection = Conexion;
                    Adapter.SelectCommand.CommandText = Stored;
                    Adapter.SelectCommand.CommandType = CommandType.StoredProcedure;


                    if (Parametros != null)
                    {
                        foreach (SqlParameter param in Parametros)
                        {
                            Adapter.SelectCommand.Parameters.Add(param);
                        }
                    }

                    Adapter.SelectCommand.CommandTimeout = Conexion.ConnectionTimeout;
                    Adapter.Fill(Ds);

                    return Ds;
                }
                catch (Exception ex)
                {
                    _Error = new Exception();
                    _Error = ex;

                    DataSet Ds = new DataSet();
                    return Ds;
                }

                finally
                {
                    Adapter.Dispose();
                    ConexionDispose();
                }


            }

            public DataSet SqlDataAdapterDs(String Stored)
            {
                try
                {
                    DataSet Ds = new DataSet();

                    Conexion.Open();
                    Adapter.SelectCommand = new SqlCommand();
                    Adapter.SelectCommand.Connection = Conexion;
                    Adapter.SelectCommand.CommandText = Stored;
                    Adapter.SelectCommand.CommandType = CommandType.StoredProcedure;


                    Adapter.SelectCommand.CommandTimeout = Conexion.ConnectionTimeout;
                    Adapter.Fill(Ds);

                    return Ds;
                }
                catch (Exception ex)
                {
                    _Error = new Exception();
                    _Error = ex;

                    DataSet Ds = new DataSet();
                    return Ds;
                }

                finally
                {
                    Adapter.Dispose();
                    ConexionDispose();
                }


            }


            public bool SqlCommand(String Stored, ArrayList Parametros)
            {
                try
                    {

                        Conexion.Open();
                        Command.CommandText = Stored;
                        Command.CommandType = CommandType.StoredProcedure;


                        Command.Parameters.Clear();
                        if (Parametros != null) 
                        {
                            foreach (SqlParameter param in Parametros)
                            {
                                Command.Parameters.Add(param);
                            }
                        }


                        Command.Connection = Conexion;
                        Command.CommandTimeout = Conexion.ConnectionTimeout;
                        Command.ExecuteNonQuery();

                        return true;
                    }

                    catch (Exception ex)
                    {
                        _Error = new Exception();
                        _Error = ex;
                        return false;
                        //ex.Message
                    }


                    finally
                    {
                        Command.Dispose();
                        ConexionDispose();
                    }

        }


            public bool SqlCommand(String Stored)
            {
                try
                {

                    Conexion.Open();
                    Command.CommandText = Stored;
                    Command.CommandType = CommandType.StoredProcedure;

                  
                    Command.Connection = Conexion;
                    Command.CommandTimeout = Conexion.ConnectionTimeout;
                    Command.ExecuteNonQuery();

                    return true;
                }

                catch (Exception ex)
                {
                    _Error = new Exception();
                    _Error = ex;
                    return false;
                    //ex.Message
                }


                finally
                {
                    Command.Dispose();
                    ConexionDispose();
                }

            }


            private void ConexionDispose()
            {
                if (Conexion != null)
                {
                    if (Conexion.State == ConnectionState.Open)
                    {
                        Conexion.Close();
                        Conexion.Dispose(); 
                    }
                }
            }


        #endregion



    }


}
