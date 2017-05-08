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
    public class IngresoList
    {
        #region VARIABLES
            private int _CveColaborador;
            private int _IdEmpresa;
            private int[] _Periodos;
            private int _Ejercicio;
            private string _NomSistema;
            private DataView _Peridodo1;
            private DataView _Peridodo2;
            private DataView _Peridodo3;
            private Exception _Error;
            private DataTable Dt;
        #endregion

        #region CONSTRUCTOR

            public IngresoList()
            {
                InicializarVariables();
            }

            public IngresoList(int CveColaborador, int IdEmpresa, int[] Periodos, int Ejercicio, string strSistema)
            {
                
                GetObjetos();
            }

            private void InicializarVariables() {

                _CveColaborador = 0;
                _IdEmpresa = 0;
                _Periodos = new int[2]{0,0};
                _Ejercicio = 0;
                _NomSistema ="";
                _Peridodo1 = new DataView();
                _Peridodo2 = new DataView();
                _Peridodo3 = new DataView();
            }


        #endregion

        #region PROPIEDADES

            public int CveColaborador
            {
                get { return _CveColaborador; }
            }

            public int IdEmpresa
            {
                get { return _IdEmpresa; }
            }

            public int[] Periodos
            {
                get { return _Periodos; }
            }

            public int Ejercicio
            {
                get { return _Ejercicio; }
            }

            public string NomSistema
            {
                get { return _NomSistema; }
            }
         
            public DataView Peridodo1
            {
                get { return _Peridodo1; }
                set { _Peridodo1 = value; }

            }

            public DataView Peridodo2
            {
                get { return _Peridodo2; }
                set { _Peridodo2 = value; }

            }

            public DataView Peridodo3
            {
                get { return _Peridodo3; }
                set { _Peridodo3 = value; }

            }

            public Exception Error
            {
                get { return _Error; }
            }


            public enum Sistema
            {
                OpenH = 1,
                OpenA = 2
            }

        #endregion

        #region METODOS

           
            private void GetObjetos()
            {
                try
                {
                    int cont = 0;
                    ArrayList Parametros;
                    Entity ObjEntity;
                    foreach (int Periodo in _Periodos)
                    {
                        cont = cont + 1;
                        Parametros = new ArrayList();
                        Parametros.Add(Util.AddSqlParameter("@idColaborador", SqlDbType.Int, _CveColaborador));
                        Parametros.Add(Util.AddSqlParameter("@idEmpresa", SqlDbType.Int, _IdEmpresa));
                        Parametros.Add(Util.AddSqlParameter("@idPeriodo", SqlDbType.Int, Periodo));
                        Parametros.Add(Util.AddSqlParameter("@ejercicio", SqlDbType.Int, _Ejercicio));


                        ObjEntity = new Entity(Entity.Connection.SAAMI);
                        if (_NomSistema == Sistema.OpenH.ToString())
                        {
                            Dt = ObjEntity.SqlDataAdapter("spSelOpenHPercepcionesDeduccionesColaborador", Parametros);
                        }
                        else{
                            Dt = ObjEntity.SqlDataAdapter("spSelOpenAPercepcionesDeduccionesColaborador", Parametros);
                        }
                        
                        if (ObjEntity.Error == null)
                        {
                            switch (cont)
                            {
                                case 1:
                                    _Peridodo1 = Dt.DefaultView; 
                                    break;

                                case 2:
                                    _Peridodo2 = Dt.DefaultView; 
                                    break;

                                case 3:
                                    _Peridodo3 = Dt.DefaultView; 
                                    break;

                                default:
                                    break;
                            }
                        }
                        else
                        {
                            _Error = ObjEntity.Error;
                            return;
                        }
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
