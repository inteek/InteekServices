using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SQLEntity;
using System.Data;
using ProjectUtilerias;

namespace ProjectLibreria
{
    public class TarifaList
    {
        #region VARIABLES
            List<Tarifa> _Lista;
            Exception _Error;
            DataTable Dt;
        #endregion

        #region CONSTRUCTOR

            public TarifaList()
            {
                _Lista = new List<Tarifa>();
                
            }

            public TarifaList(string CveColaborador)
            {
                GetObjetos(CveColaborador);
            }


        #endregion

        #region PROPIEDADES

            public List<Tarifa> Lista
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

            public bool Guardar()
            {
                try
                {
                    if (_Error != null) { return false; }

                    ArrayList Parametros = new ArrayList();
                    Entity ObjEntity;
                    foreach (Tarifa Objeto in _Lista)
                    {
                        Parametros.Add(Util.AddSqlParameter("@CveColaborador", SqlDbType.VarChar, Objeto.Clave));
                        Parametros.Add(Util.AddSqlParameter("@Nombre", SqlDbType.Money, Objeto.Monto));

                        ObjEntity = new Entity();
                        ObjEntity.SqlCommand("spTarifaInsert", Parametros);


                        if (ObjEntity.Error != null)
                        {
                            _Error = new Exception();
                            _Error = ObjEntity.Error;
                            return false;
                        }

                    }

                    return true;

                }
                catch (Exception ex)
                {
                    _Error = new Exception();
                    _Error = ex;
                    return false;
                }

            }

         


            private void GetObjetos(string CveColaborador)
            {
                try
                {
                    
                    ArrayList Parametros = new ArrayList();
                    Parametros.Add(Util.AddSqlParameter("@CveColaborador", SqlDbType.VarChar, CveColaborador));


                    Entity ObjEntity = new Entity();
                    Dt = ObjEntity.SqlDataAdapter("spTarifa", Parametros);

                    if (ObjEntity.Error == null)
                    {
                        Tarifa Objeto;
                        foreach (DataRow dr in Dt.Rows)
                        {
                            Objeto = new Tarifa();
                            Objeto.Clave = Util.ValidaDbNullString(dr, "CveBono");
                            Objeto.Monto = Util.ValidaDbNullDouble(dr, "Descripcion");
                            Objeto.Fecha = Util.ValidaDbNullDateTime(dr, "FechaPago");
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
