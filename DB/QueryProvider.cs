using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;  

namespace FrbaCrucero.DB
{
    class QueryProvider
    {
        public static string LOGIN_QUERY(String user, String password)
        {
            string sha256Password = "\'" + toSHA256(password) + "\'";
            string username = "\'" + user + "\'";
            return "SELECT * FROM [GD1C2019].[dbo].[User] WHERE user_usuario=" + username + " AND user_contrasenia=" + sha256Password;
        }

        private static string toSHA256(String rawData)
        {
            // Create a SHA256   
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // ComputeHash - returns byte array  
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));

                // Convert byte array to a string   
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }  
    }
}
