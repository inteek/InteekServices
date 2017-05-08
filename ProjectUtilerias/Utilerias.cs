using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Runtime.InteropServices;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.Xml.Serialization;
using System.Web;
using System.IO;
using SQLEntity;


using Crypto;

namespace ProjectUtilerias
{
    public class Util
    {
        public enum TipoDato
            {
                String = 1,
                Int = 2,
                Double = 3,
                Date = 4,
                Boolean = 5,
                Byte = 6
                 
            }

        public static string NombreMes(int NoMes)
        {
            
            switch (NoMes)
            {
                case 1:
                    return "Enero";

                case 2:
                    return "Febrero";

                case 3:
                    return "Marzo";

                case 4:
                    return "Abril";

                case 5:
                    return "Mayo";

                case 6:
                    return "Junio";

                case 7:
                    return "Julio";

                case 8:
                    return "Agosto";

                case 9:
                    return "Septiembre"; 

                case 10:
                    return "Octubre";

                case 11:
                    return "Noviembre";

                case 12:
                    return "Diciembre";

                default:
                    return null;
            }
            
        } 

        public static string ValidaDbNull(DataRow Dr, string ColumnName, TipoDato Type)
        {
            try
            {
                string valor = "";


                if (Dr[ColumnName] == DBNull.Value)
                {
                    switch (Type)
                    {
                        case TipoDato.String:
                            valor = "";
                            break;

                        case TipoDato.Int:
                            valor = "0";
                            break;

                        case TipoDato.Double:
                            valor = "0.00";
                            break;

                        case TipoDato.Date:
                            DateTime Fecha = Convert.ToDateTime("01/01/1900 12:00:00 a.m.");
                            valor = Convert.ToString(Fecha);
                            break;

                        case TipoDato.Boolean:
                            valor = "false";
                            break;

                        case TipoDato.Byte:
                            valor = "0";
                            break;

                        default:
                            //dostuff;
                            break;
                    }

                    return valor;
                }
                else
                {
                    if (Type == TipoDato.Boolean)
                    {
                        if (IsNumeric(Convert.ToString(Dr[ColumnName])))
                        {
                            if (Convert.ToString(Dr[ColumnName]) == "1") { return "true"; } else { return "false"; }
                        }
                        else
                        {
                            if (Convert.ToString(Dr[ColumnName]) == "") { return "false"; }

                            return Convert.ToString(Dr[ColumnName]);
                        }
                    }
                    else
                    {
                        return Convert.ToString(Dr[ColumnName]);
                    }

                }
            }
            catch (Exception ex)
            {
                string e = ex.Message;
                return null;
            }


        }

        public static string ValidaDbNullString(DataRow Dr, string ColumnName)
        {
            try
            {
                if (Dr[ColumnName] == DBNull.Value)
                {
                    return "";
                }
                else
                {
                    return Dr[ColumnName].ToString();
                }
            }
            catch 
            {
                return "";
            }


        }

        public static int ValidaDbNullInt(DataRow Dr, string ColumnName)
        {
            try
            {
                if (Dr[ColumnName] == DBNull.Value)
                {
                   return 0;
                }
                else
                {
                    return int.Parse(Dr[ColumnName].ToString());
                }
            }
            catch
            {
                return 0;
            }


        }

        public static Double ValidaDbNullDouble(DataRow Dr, string ColumnName)
        {
            try
            {
                if (Dr[ColumnName] == DBNull.Value)
                {
                   return 0.00;
                }
                else
                {
                    return Double.Parse(Dr[ColumnName].ToString());
                }
            }
            catch
            {
                return 0.00;
            }


        }

        public static Decimal ValidaDbNullDecimal(DataRow Dr, string ColumnName)
        {
            try
            {
                if (Dr[ColumnName] == DBNull.Value)
                {
                    return 0.0M;
                }
                else
                {
                    return Decimal.Parse(Dr[ColumnName].ToString());
                }
            }
            catch 
            {
                return 0.0M;
            }


        }

        public static DateTime ValidaDbNullDateTime(DataRow Dr, string ColumnName)
        {
            try
            {
                if (Dr[ColumnName] == DBNull.Value)
                {
                    return DateTime.Parse("01/01/1900 12:00:00 a.m.");
                }
                else
                {
                    return DateTime.Parse(Dr[ColumnName].ToString());
                }
            }
            catch 
            {
                return DateTime.Parse("01/01/1900 12:00:00 a.m.");
            }


        }

        public static Boolean ValidaDbNullBoolean(DataRow Dr, string ColumnName)
        {
            try
            {
                if (Dr[ColumnName] == DBNull.Value)
                {
                    return false;
                }
                else
                {
                    if (IsNumeric(Dr[ColumnName].ToString()))
                    {
                        if (Dr[ColumnName].ToString() == "1") { return true; } else { return false; }
                    }
                    else
                    {
                        if (Dr[ColumnName].ToString() == "") { return false; }

                        return Boolean.Parse(Dr[ColumnName].ToString());
                    }
                }
            }
            catch
            {
                return false;
            }


        }

        public static bool IsNumeric(string Value)
        {
            try
            {
                Convert.ToInt32(Value);
                return true;
            }
            catch
            {
                return false;
            }
        } 

        public static SqlParameter AddSqlParameter(string Name, SqlDbType SqlType, object ObjValue)
        {
            SqlParameter Param = new SqlParameter(Name, SqlType);
            if (SqlType == SqlDbType.VarChar)
            {
                Param.Value = ObjValue.ToString().Trim();
            }
            else
            {
                Param.Value = ObjValue;    
            }
            return Param;
        }

        public static SqlParameter AddSqlParameter(string Name, SqlDbType SqlType, object ObjValue, Int32 Size)
        {
            SqlParameter Param = new SqlParameter(Name, SqlType, Size);
            if (SqlType == SqlDbType.VarChar)
            {
                Param.Value = ObjValue.ToString().Trim();
            }
            else
            {
                Param.Value = ObjValue;
            }
            return Param; 
        }

        public static Byte[] ConvertBinary(string Path)
        {
            Byte[] CodigoByte = null;

            if (File.Exists(Path))
            {
                FileStream fs = new FileStream(Path, FileMode.Open);
                CodigoByte = new byte[Convert.ToInt32(fs.Length - 1)];

                fs.Read(CodigoByte, 0, CodigoByte.Length);
                fs.Close();
            }

            return CodigoByte;
           
        }

        [System.Runtime.InteropServices.DllImport("urlmon.dll", EntryPoint = "FindMimeFromData", ExactSpelling = true, CharSet = System.Runtime.InteropServices.CharSet.Ansi, SetLastError = true)]
        public static extern int FindMimeFromData(IntPtr pBC, [MarshalAs(UnmanagedType.LPWStr)] string pwzUrl, [MarshalAs(UnmanagedType.LPArray)] byte[] pBuffer, int cbSize, [MarshalAs(UnmanagedType.LPWStr)] string pwzMimeProposed, int dwMimeFlags, [MarshalAs(UnmanagedType.LPWStr)] ref string ppwzMimeOut, int dwReserved);

        public static string GetMimeFromFile(string file)
        {

            string mimeout = "";
            int MaxContent = 0;
            FileStream fs = null;
            byte[] buf = null;
            int result = 0;

            if (!(System.IO.File.Exists(file)))
            {
                return null;
            }
          

            MaxContent = System.Convert.ToInt32(new FileInfo(file).Length);
            fs = new FileStream(file, FileMode.Open);
            buf = new byte[MaxContent + 1];
            fs.Read(buf, 0, MaxContent);
            fs.Close();

            result = FindMimeFromData(IntPtr.Zero, file, buf, MaxContent, null, 0, ref mimeout, 0);
            return mimeout;

        }

        public static string Desencriptar(string cadena)
        {
            Crypto.Encrypting_Service objCrypto = new Crypto.Encrypting_Service();
            if (cadena != "" && cadena!=null)
            {
             return objCrypto.Decrypt(cadena);
            }
            return "";
        }

        public static string Encriptar(string cadena)
        {
            Crypto.Encrypting_Service objCrypto = new Crypto.Encrypting_Service();

            if (cadena != "" && cadena != null)
            {
             return objCrypto.Encrypt(cadena);
            }
            return "";
        }
        
        public static DateTime GetDateTime()
        {
            try
            {
                DateTime Fecha = DateTime.Now; 

                DataTable Dt = new DataTable();
                Entity ObjEntity = new Entity();
                Dt = ObjEntity.SqlDataAdapter("spGetDate");


                foreach (DataRow dr in Dt.Rows)
                {
                    Fecha = ValidaDbNullDateTime(dr, "FECHA");
                }

                return Fecha;
               
            }
            catch
            {
                return DateTime.Now;
            }

        }

        public static string EliminaAcentos(string inputString)
        {
            System.Text.RegularExpressions.Regex replace_a_Accents = new System.Text.RegularExpressions.Regex("[á|à|ä|â]", System.Text.RegularExpressions.RegexOptions.Compiled);
            System.Text.RegularExpressions.Regex replace_e_Accents = new System.Text.RegularExpressions.Regex("[é|è|ë|ê]", System.Text.RegularExpressions.RegexOptions.Compiled);
            System.Text.RegularExpressions.Regex replace_i_Accents = new System.Text.RegularExpressions.Regex("[í|ì|ï|î]", System.Text.RegularExpressions.RegexOptions.Compiled);
            System.Text.RegularExpressions.Regex replace_o_Accents = new System.Text.RegularExpressions.Regex("[ó|ò|ö|ô]", System.Text.RegularExpressions.RegexOptions.Compiled);
            System.Text.RegularExpressions.Regex replace_u_Accents = new System.Text.RegularExpressions.Regex("[ú|ù|ü|û]", System.Text.RegularExpressions.RegexOptions.Compiled);
            inputString = replace_a_Accents.Replace(inputString, "a");
            inputString = replace_e_Accents.Replace(inputString, "e");
            inputString = replace_i_Accents.Replace(inputString, "i");
            inputString = replace_o_Accents.Replace(inputString, "o");
            inputString = replace_u_Accents.Replace(inputString, "u");
            return inputString;
        }
        

    }
}
