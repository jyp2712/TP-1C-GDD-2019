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

        public static string SELECT_FUNCIONALIDADES_NOMBRE = "SELECT * FROM [GD1C2019].[EYE_OF_THE_TRIGGER].[Funcionalidad]";

        //TODO test
        public static string INSERT_ROL(string rol_nombre)
        {
            return "INSERT INTO [EYE_OF_THE_TRIGGER].[Rol] ([rol_nombre] ,[rol_estado]) VALUES (" + rol_nombre + ", 1)";
        }

        public static string UPDATE_ROL(string rol_nombre, string rol_id)
        {
            return "UPDATE [EYE_OF_THE_TRIGGER].[Rol] SET [rol_nombre] = '" + rol_nombre + "',[rol_estado] = 1 WHERE [rol_id] = " + rol_id;
        }

        public static string SELECT_ROL_LIKE(string nombreRol)
        {
            return "SELECT * FROM [EYE_OF_THE_TRIGGER].[Rol] WHERE rol_nombre LIKE '%" + nombreRol + "%'";
        }

        public static string SELECT_ALL_ROLES = "SELECT * FROM [EYE_OF_THE_TRIGGER].[Rol]";

        public static string SELECT_ROLES_CON_FUNCIONALIDADES(string rol_id) { 
            return "SELECT * FROM [EYE_OF_THE_TRIGGER].[Rol] JOIN [EYE_OF_THE_TRIGGER].[Rol_Funcionalidad] on [EYE_OF_THE_TRIGGER].[Rol_Funcionalidad].[rol_id] = [EYE_OF_THE_TRIGGER].[Rol].[rol_id] JOIN [EYE_OF_THE_TRIGGER].[Funcionalidad] on[EYE_OF_THE_TRIGGER].[Funcionalidad].[func_id] = [EYE_OF_THE_TRIGGER].[Rol_Funcionalidad].[func_id]WHERE [EYE_OF_THE_TRIGGER].[Rol].[rol_id] =" + rol_id;
        }
    }
}
