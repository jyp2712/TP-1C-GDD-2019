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
        public static string SELECT_RECORRIDOS = "SELECT * FROM [GD1C2019].[EYE_OF_THE_TRIGGER].[Recorrido]";
        public static string SELECT_MARCAS = "SELECT * FROM [GD1C2019].[EYE_OF_THE_TRIGGER].[Marca]";
        public static string SELECT_CRUCEROS = "SELECT * FROM [GD1C2019].[EYE_OF_THE_TRIGGER].[Crucero]";

        public static string SELECT_RESERVAS_REPLANIFICACION(string crucero)
        {
            return "SELECT DISTINCT rese_id FROM EYE_OF_THE_TRIGGER.Reserva JOIN EYE_OF_THE_TRIGGER.Viaje ON viaj_crucero_id = rese_crucero_id WHERE viaj_fecha_inicio >= GETDATE() AND rese_crucero_id ='" + crucero + "'";
        }

        public static string SELECT_CRUCEROS_REPLANIFICACION(string crucero)
        {
            return "SELECT DISTINCT rese_viaje_id FROM EYE_OF_THE_TRIGGER.Reserva JOIN EYE_OF_THE_TRIGGER.Viaje ON viaj_crucero_id = rese_crucero_id WHERE viaj_fecha_inicio >= GETDATE() AND rese_crucero_id ='" + crucero + "'";
        }

        public static string SELECT_RECORRIDOS_POR_ID(int id){
            return "SELECT * FROM [GD1C2019].[EYE_OF_THE_TRIGGER].[Recorrido] WHERE reco_id="+id;
        }

        public static string DELETE_ROLE(int id) 
        {
            return "UPDATE [GD1C2019].[EYE_OF_THE_TRIGGER].[Rol] SET rol_estado=0 WHERE rol_id=" + id;
        }

        public static string SELECT_FUNCIONALIDADES_NOMBRE = "SELECT * FROM [GD1C2019].[EYE_OF_THE_TRIGGER].[Funcionalidad]";
        public static string SELECT_CIUDADES_PUERTOS_NOMBRE = "SELECT (ISNULL(ciud_nombre, '') + '-' + puer_nombre) nombre FROM [GD1C2019].[EYE_OF_THE_TRIGGER].[Ciudad] JOIN [GD1C2019].[EYE_OF_THE_TRIGGER].[Puerto] ON puer_id = ciud_puerto_id WHERE puer_estado = 1";

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

        public static string SELECT_RECORRIDOS_TEXTUAL(string nombreRecorrido)
        {
            return "SELECT * FROM [EYE_OF_THE_TRIGGER].[Recorrido] WHERE reco_codigo =" + nombreRecorrido;
        }

        public static string SELECT_RECORRIDOS_LIKE(string nombreRecorrido)
        {
            return "SELECT * FROM [EYE_OF_THE_TRIGGER].[Recorrido] WHERE reco_codigo LIKE '%" + nombreRecorrido + "%'";
        }
        
        public static string SELECT_CRUCEROS_TEXTUAL(string nombreCrucero)
        {
            return "SELECT * FROM [EYE_OF_THE_TRIGGER].[Crucero] WHERE cruc_nombre =" + nombreCrucero;
        }

        public static string SELECT_CRUCEROS_LIKE(string nombreCrucero)
        {
            return "SELECT * FROM [EYE_OF_THE_TRIGGER].[Crucero] WHERE cruc_nombre LIKE '%" + nombreCrucero + "%'";
        }

        public static string SELECT_ALL_ROLES = "SELECT * FROM [EYE_OF_THE_TRIGGER].[Rol]";

        public static string SELECT_ROLES_CON_FUNCIONALIDADES(string rol_id) { 
            return "SELECT * FROM [EYE_OF_THE_TRIGGER].[Rol] JOIN [EYE_OF_THE_TRIGGER].[Rol_Funcionalidad] on [EYE_OF_THE_TRIGGER].[Rol_Funcionalidad].[rol_id] = [EYE_OF_THE_TRIGGER].[Rol].[rol_id] JOIN [EYE_OF_THE_TRIGGER].[Funcionalidad] on[EYE_OF_THE_TRIGGER].[Funcionalidad].[func_id] = [EYE_OF_THE_TRIGGER].[Rol_Funcionalidad].[func_id]WHERE [EYE_OF_THE_TRIGGER].[Rol].[rol_id] =" + rol_id;
        }

        /*public static string SELECT_RESERVA(string idReserva) {
            return "SELECT * FROM [GD1C2019].[EYE_OF_THE_TRIGGER].Reserva JOIN [GD1C2019].[EYE_OF_THE_TRIGGER].Cliente on rese_cliente_id = clie_id JOIN [GD1C2019].[EYE_OF_THE_TRIGGER].Crucero on cruc_id = rese_crucero_id JOIN [GD1C2019].[EYE_OF_THE_TRIGGER].TipoDocumento on clie_tipo_doc = TipoDocumento.id JOIN [GD1C2019].[EYE_OF_THE_TRIGGER].Domicilio on clie_domicilio_id = domi_id JOIN [GD1C2019].[EYE_OF_THE_TRIGGER].Marca on marc_id = cruc_marca JOIN [GD1C2019].[EYE_OF_THE_TRIGGER].Viaje on rese_viaje_id = viaj_id JOIN [GD1C2019].[EYE_OF_THE_TRIGGER].RecorridoViaje on RecorridoViaje.viaj_id = Reserva.rese_viaje_id JOIN [GD1C2019].[EYE_OF_THE_TRIGGER].Recorrido on Recorrido.reco_id = RecorridoViaje.reco_id JOIN [GD1C2019].[EYE_OF_THE_TRIGGER].Ciudad origen on ciud_id = reco_origen_id JOIN [GD1C2019].[EYE_OF_THE_TRIGGER].Ciudad destino on destino.ciud_id = reco_origen_id JOIN [GD1C2019].[EYE_OF_THE_TRIGGER].Puerto puertoOrigen on origen.ciud_puerto_id = puertoOrigen.puer_id JOIN [GD1C2019].[EYE_OF_THE_TRIGGER].Puerto puertoDestino on reco_destino_id = puertoDestino.puer_id WHERE rese_id='" + idReserva + "'";
        }
        */
        public static string SELECT_RESERVA(string idReserva)
        {
            return "SELECT * FROM [GD1C2019].[EYE_OF_THE_TRIGGER].Reserva JOIN [GD1C2019].[EYE_OF_THE_TRIGGER].Cliente on rese_cliente_id = clie_id JOIN [GD1C2019].[EYE_OF_THE_TRIGGER].Crucero on cruc_id = rese_crucero_id JOIN [GD1C2019].[EYE_OF_THE_TRIGGER].TipoDocumento on clie_tipo_doc = TipoDocumento.id JOIN [GD1C2019].[EYE_OF_THE_TRIGGER].Domicilio on clie_domicilio_id = domi_id JOIN [GD1C2019].[EYE_OF_THE_TRIGGER].Marca on marc_id = cruc_marca JOIN [GD1C2019].[EYE_OF_THE_TRIGGER].Viaje on rese_viaje_id = viaj_id WHERE rese_id='" + idReserva + "'";
        }


        public static string SELECT_PUERTO_POR_CIUDAD(string ciudadId)
        {

            return "SELECT * FROM [GD1C2019].[EYE_OF_THE_TRIGGER].Ciudad JOIN [GD1C2019].[EYE_OF_THE_TRIGGER].Puerto on ciud_puerto_id = puer_id WHERE ciud_id='" + ciudadId + "'";

        }

        internal static string SELECT_CABINA()
        {
            //throw new NotImplementedException();
            return "";
        }

        public static string SELECT_CIUDADES_ORIGEN = "SELECT * FROM [GD1C2019].[EYE_OF_THE_TRIGGER].Ciudad JOIN [GD1C2019].[EYE_OF_THE_TRIGGER].[Puerto] on ciud_puerto_id = ciud_id";
    }
}
