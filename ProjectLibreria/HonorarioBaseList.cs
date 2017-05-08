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
    public class HonorarioBaseList
    {
        #region VARIABLES
        List<HonorarioBase> _Lista;
            Exception _Error;
            DataTable Dt;
        #endregion

        #region CONSTRUCTOR


            public HonorarioBaseList()
            {
                _Lista = new List<HonorarioBase>();
            }



            public HonorarioBaseList(int CveColaborador, string Periodos, int Ejercicio)
            {
                _Lista = new List<HonorarioBase>();
                GetObjetos(CveColaborador, Periodos, Ejercicio);
            }

           


        #endregion

        #region PROPIEDADES

            public List<HonorarioBase> Lista
            {
               get { return _Lista; }
               set { _Lista = value; }
               
            }

            public Exception Error
            {
                get { return _Error; }
            }

        #endregion

        #region METODOS

            private void GetObjetos(int CveColaborador, string Periodos, int Ejercicio)
            {
                try
                {
                    Lista.Clear();
                    ArrayList Parametros = new ArrayList();
                    Parametros.Add(Util.AddSqlParameter("@IdColaborador", SqlDbType.Int, CveColaborador));
                    Parametros.Add(Util.AddSqlParameter("@idPeriodos", SqlDbType.VarChar, Periodos));
                    Parametros.Add(Util.AddSqlParameter("@ejercicio", SqlDbType.Int, Ejercicio));
                    


                    Entity ObjEntity = new Entity(Entity.Connection.SAAMI);
                    Dt = ObjEntity.SqlDataAdapter("spSelEmpresasColaborador", Parametros);

                    if (ObjEntity.Error == null)
                    {
                        HonorarioBase Objeto;
                        foreach (DataRow dr in Dt.Rows)
                        {
                            Objeto = new HonorarioBase();
                            Objeto.Clave = Util.ValidaDbNullInt(dr, "IdEmpresa");
                            Objeto.Empresa = Util.ValidaDbNullString(dr, "Empresa");
                            Objeto.Sistema = Util.ValidaDbNullString(dr, "Sistema");
                            _Lista.Add(Objeto);
                        }
                    }
                    else
                    {
                        _Error = ObjEntity.Error;
                    }
                }
                catch (Exception ex)
                {
                    _Error = ex;
                }
            }

       #endregion
    }
}
