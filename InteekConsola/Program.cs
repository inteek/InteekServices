using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;

namespace InteekConsola
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hola mundo");
            Console.ReadLine();
        }
        public class NewPassword
        {
            public string CreateRandomPassword(int PasswordLength)
            {
                string _allowedChars = "abcdefghijkmnpqrstuvwxyzABCDEFGHJKLMNPQRSTUVWXYZ23456789!@$?";
                Byte[] randomBytes = new Byte[PasswordLength];
                char[] chars = new char[PasswordLength];
                int allowedCharCount = _allowedChars.Length;

                for (int i = 0; i < PasswordLength; i++)
                {
                    Random randomObj = new Random();
                    randomObj.NextBytes(randomBytes);
                    chars[i] = _allowedChars[(int)randomBytes[i] % allowedCharCount];
                }

                return new string(chars);

            } char[] ValueAfanumeric = { 'q', 'w', 'e', 'r', 't', 'y', 'u', 'i', 'o', 'p', 'a', 's', 'd', 'f', 'g', 'h', 'j', 'k', 'l', 'z', 'x', 'c', 'v', 'b', 'n', 'm', 'Q', 'W', 'E', 'R', 'T', 'Y', 'U', 'I', 'O', 'P', 'A', 'S', 'D', 'F', 'G', 'H', 'J', 'K', 'L', 'Z', 'X', 'C', 'V', 'B', 'N', 'M', '!', '#', '$', '%', '&', '?', '¿' };

            public string GenerarPass(int LongPassMin, int LongPassMax)
            {
                Random ram = new Random();
                int LogitudPass = ram.Next(LongPassMin, LongPassMax);
                string Password = String.Empty;

                for (int i = 0; i < LogitudPass; i++)
                {
                    int rm = ram.Next(0, 2);

                    if (rm == 0)
                    {
                        Password += ram.Next(0, 10);
                    }
                    else
                    {
                        Password += ValueAfanumeric[ram.Next(0, 59)];
                    }
                }
                return Password;
            }
        }

        //public bool GenerarPwd (int idRegistro)
        //{
        //    return true;
        //}

        //public bool EnviarCorreo()
        //{
        //    return true;
        //}


    }
}
