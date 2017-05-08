using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectLibreria
{
    public class Tarifa
    {
        #region VARIABLES
            private string _CveColaborador;
            private double _tarifa;
            private DateTime _Fecha;
        #endregion


        #region CONSTRUCTOR

            public Tarifa()
            {
                InicializarVariables();
            }

         

            private void InicializarVariables()
            {
                _CveColaborador = "";
                _tarifa = 0;
                _Fecha = DateTime.Now; 
                
            }


            

        #endregion


        #region PROPIEDADES

            public string Clave
            {
                get { return _CveColaborador; }
                set { _CveColaborador = value; }
            }

            public double Monto
            {
                get { return _tarifa; }
                set { _tarifa = value; }
            }

            public DateTime Fecha
            {
                get { return _Fecha; }
                set { _Fecha = value; }
            }

           

        #endregion
    }
}
