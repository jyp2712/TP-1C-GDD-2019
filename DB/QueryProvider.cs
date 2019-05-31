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

        public static string SELECT_ROLES = "SELECT * FROM [GD1C2019].[EYE_OF_THE_TRIGGER].[Rol]";
        public static string DELETE_ROLE(int id) 
        {
            return "UPDATE [GD1C2019].[EYE_OF_THE_TRIGGER].[Rol] SET rol_estado=0 WHERE rol_id=" + id;
        }
        
        public static string LOGIN_QUERY(String user, String password)
        {
            string sha256Password = "\'" + toSHA256(password) + "\'";
            string username = "\'" + user + "\'";
            //return "SELECT * FROM [GD1C2019].[EYE_OF_THE_TRIGGER].[User] WHERE user_usuario=" + username + " AND user_contrasenia=" + sha256Password;
            return "SELECT * FROM [GD1C2019].[EYE_OF_THE_TRIGGER].[User] WHERE user_usuario=" + username + " AND user_contrasenia=" + "0xE6B87050BFCB8143FCB8DB0170A4DC9ED00D904DDD3E2A4AD1B1E8DC0FDC9BE7";
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

        public static string SELECT_FUNCIONALIDADES_NOMBRE = "SELECT * FROM [GD1C2019].[EYE_OF_THE_TRIGGER].[Funcionalidad]";

        //TODO test
        public static string INSERT_ROL(string rol_nombre)
        {
            return "INSERT INTO [EYE_OF_THE_TRIGGER].[Rol] ([rol_nombre] ,[rol_estado]) VALUES (" + rol_nombre + ", 1)";
        }

        public static string SELECT_ROL_LIKE(string nombreRol)
        {
            return "SELECT * FROM [EYE_OF_THE_TRIGGER].[Rol] WHERE rol_nombre LIKE '%" + nombreRol + "%'";
        }

        public static string SELECT_ALL_ROLES = "SELECT * FROM [EYE_OF_THE_TRIGGER].[Rol]";
        
    }
}
