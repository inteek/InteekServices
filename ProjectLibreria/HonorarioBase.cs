using System;
using System.Collections;
using System.Linq;
using System.Text;
using SQLEntity;
using ProjectUtilerias;

namespace ProjectLibreria
{
    public class HonorarioBase
    {
        #region VARIABLES
            private int _IdEmpresa;
            private string _Empresa;
            private decimal _Honorario;
            private string _Sistema;
        #endregion


        #region CONSTRUCTOR

            public HonorarioBase()
            {
                InicializarVariables();
            }

         

            private void InicializarVariables()
            {
                _IdEmpresa = 0;
                _Empresa = "";
                _Honorario = 0;
                _Sistema = "";
            }


            

        #endregion


        #region PROPIEDADES

            public int Clave
            {
                get { return _IdEmpresa; }
                set { _IdEmpresa = value; }
            }

            public string  Empresa
            {
                get { return _Empresa; }
                set { _Empresa = value; }
            }

            public decimal Cantidad
            {
                get { return _Honorario; }
                set { _Honorario = value; }
            }

            public string  Sistema
            {
                get { return _Sistema; }
                set { _Sistema = value; }
            }

        #endregion
    }
}
