using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PasswordGenerator;

namespace MongoConsoleApp.Classes
{
    public class Utils
    {
        public Utils()
        {

        }

        public static string GenerateNewPassword(uint n)
        {
            try
            {
                if (n <= 0)
                {
                    throw new InvalidOperationException("More than zero please");
                }
            }
            catch (Exception)
            {

                Console.WriteLine("oh dear");
            }



            var pwd = new Password(includeLowercase: true, includeUppercase: true, includeNumeric: true, includeSpecial: true, passwordLength: (int)n);
            var password = pwd.Next();
            return password;
        }
    }


}
