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

        public static string SELECT_VIAJES_REPLANIFICACION(string crucero, String FechaActual, String fechaReactivacion)
        {
            return "SELECT DISTINCT viaj_id FROM [GD1C2019].[EYE_OF_THE_TRIGGER].[Viaje] WHERE (viaj_fecha_inicio BETWEEN convert(datetime, '" + FechaActual + "') AND convert(datetime, '" + fechaReactivacion + "')) AND viaj_crucero_id ='" + crucero + "'";
        }

        public static string SELECT_RECORRIDOS_POR_ID(int id)
        {
            return "SELECT * FROM [GD1C2019].[EYE_OF_THE_TRIGGER].[Recorrido] WHERE reco_id=" + id;
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

        public static string UPDATE_RESERVA(int reserva_id)
        {
            return "UPDATE EYE_OF_THE_TRIGGER.Reserva SET rese_estado_reserva = (SELECT id FROM EYE_OF_THE_TRIGGER.EstadoReserva WHERE descripcion='Reserva modificada') WHERE rese_id =" + reserva_id;
        }

        public static string SELECT_ROL_LIKE(string nombreRol)
        {
            return "SELECT * FROM [EYE_OF_THE_TRIGGER].[Rol] WHERE rol_nombre LIKE '%" + nombreRol + "%'";
        }

        public static string SELECT_RECORRIDOS_TEXTUAL(string nombreRecorrido)
        {
            return "SELECT * FROM [EYE_OF_THE_TRIGGER].[Recorrido] WHERE reco_codigo =" + nombreRecorrido;
        }

        public static string SELECT_RECORRIDOS_MAX_ID(string nombreRecorrido)
        {
            return "SELECT * FROM [EYE_OF_THE_TRIGGER].[Recorrido] WHERE reco_id = (SELECT MAX(reco_id) FROM [EYE_OF_THE_TRIGGER].[Recorrido]) AND reco_codigo =" + nombreRecorrido;
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

        public static string SELECT_ROLES_CON_FUNCIONALIDADES(string rol_id)
        {
            return "SELECT * FROM [EYE_OF_THE_TRIGGER].[Rol] JOIN [EYE_OF_THE_TRIGGER].[Rol_Funcionalidad] on [EYE_OF_THE_TRIGGER].[Rol_Funcionalidad].[rol_id] = [EYE_OF_THE_TRIGGER].[Rol].[rol_id] JOIN [EYE_OF_THE_TRIGGER].[Funcionalidad] on[EYE_OF_THE_TRIGGER].[Funcionalidad].[func_id] = [EYE_OF_THE_TRIGGER].[Rol_Funcionalidad].[func_id]WHERE [EYE_OF_THE_TRIGGER].[Rol].[rol_id] =" + rol_id;
        }

        /*public static string SELECT_RESERVA(string idReserva) {
            return "SELECT * FROM [GD1C2019].[EYE_OF_THE_TRIGGER].Reserva JOIN [GD1C2019].[EYE_OF_THE_TRIGGER].Cliente on rese_cliente_id = clie_id JOIN [GD1C2019].[EYE_OF_THE_TRIGGER].Crucero on cruc_id = rese_crucero_id JOIN [GD1C2019].[EYE_OF_THE_TRIGGER].TipoDocumento on clie_tipo_doc = TipoDocumento.id JOIN [GD1C2019].[EYE_OF_THE_TRIGGER].Domicilio on clie_domicilio_id = domi_id JOIN [GD1C2019].[EYE_OF_THE_TRIGGER].Marca on marc_id = cruc_marca JOIN [GD1C2019].[EYE_OF_THE_TRIGGER].Viaje on rese_viaje_id = viaj_id JOIN [GD1C2019].[EYE_OF_THE_TRIGGER].RecorridoViaje on RecorridoViaje.viaj_id = Reserva.rese_viaje_id JOIN [GD1C2019].[EYE_OF_THE_TRIGGER].Recorrido on Recorrido.reco_id = RecorridoViaje.reco_id JOIN [GD1C2019].[EYE_OF_THE_TRIGGER].Ciudad origen on ciud_id = reco_origen_id JOIN [GD1C2019].[EYE_OF_THE_TRIGGER].Ciudad destino on destino.ciud_id = reco_origen_id JOIN [GD1C2019].[EYE_OF_THE_TRIGGER].Puerto puertoOrigen on origen.ciud_puerto_id = puertoOrigen.puer_id JOIN [GD1C2019].[EYE_OF_THE_TRIGGER].Puerto puertoDestino on reco_destino_id = puertoDestino.puer_id WHERE rese_id='" + idReserva + "'";
        }
        */
        public static string SELECT_RESERVA(string idReserva)
        {
            return "SELECT * FROM [GD1C2019].[EYE_OF_THE_TRIGGER].Reserva JOIN [GD1C2019].[EYE_OF_THE_TRIGGER].Cliente on rese_cliente_id = clie_id JOIN [GD1C2019].[EYE_OF_THE_TRIGGER].Crucero on cruc_id = rese_crucero_id JOIN [GD1C2019].[EYE_OF_THE_TRIGGER].Servicio on cruc_servicio=serv_id JOIN [GD1C2019].[EYE_OF_THE_TRIGGER].TipoDocumento on clie_tipo_doc = TipoDocumento.id JOIN [GD1C2019].[EYE_OF_THE_TRIGGER].Domicilio on clie_domicilio_id = domi_id JOIN [GD1C2019].[EYE_OF_THE_TRIGGER].Marca on marc_id = cruc_marca JOIN [GD1C2019].[EYE_OF_THE_TRIGGER].Viaje v on rese_viaje_id = v.viaj_id JOIN [GD1C2019].[EYE_OF_THE_TRIGGER].RecorridoViaje rv on rv.viaj_id = v.viaj_id JOIN [GD1C2019].[EYE_OF_THE_TRIGGER].Recorrido r on r.reco_id = rv.reco_id WHERE rese_id='" + idReserva + "' AND rese_estado_reserva = 3";
        }


        public static string SELECT_PUERTO_POR_CIUDAD(string ciudadId)
        {

            return "SELECT * FROM [GD1C2019].[EYE_OF_THE_TRIGGER].Ciudad JOIN [GD1C2019].[EYE_OF_THE_TRIGGER].Puerto on ciud_puerto_id = puer_id WHERE ciud_id='" + ciudadId + "'";

        }

        internal static string SELECT_CABINA(int cabinaId)
        {
            //throw new NotImplementedException();
            return "SELECT * FROM [GD1C2019].[EYE_OF_THE_TRIGGER].Cabina JOIN [GD1C2019].[EYE_OF_THE_TRIGGER].TipoCabina ON cabi_tipo_cabina = id JOIN [GD1C2019].[EYE_OF_THE_TRIGGER].Crucero ON cruc_id=cabi_cruc_id JOIN [GD1C2019].[EYE_OF_THE_TRIGGER].Marca ON marc_id=cruc_marca WHERE cabi_id=" + cabinaId;
        }

        public static string SELECT_CIUDADES_Y_PUERTO = "SELECT * FROM [GD1C2019].[EYE_OF_THE_TRIGGER].Ciudad JOIN [GD1C2019].[EYE_OF_THE_TRIGGER].[Puerto] on ciud_puerto_id = puer_id WHERE puer_estado = 1";

        public static string SELECT_CIUDADES_Y_PUERTO_LIKE(string nombre)
        {
            return "SELECT * FROM [GD1C2019].[EYE_OF_THE_TRIGGER].Ciudad JOIN [GD1C2019].[EYE_OF_THE_TRIGGER].[Puerto] on ciud_puerto_id = puer_id WHERE puer_estado = 1 AND (ciud_nombre LIKE '%" + nombre + "%' OR puer_nombre LIKE '%" + nombre + "%')";
        }

        public static string SELECT_CRUCERO_MARCA_SERVICIO_MODELO(string marca, string servicio, string modelo, string fechaSalida, string fechaRegreso, int puertoIdOrigen, int puertoIdDestino)
        {
            string baseQuery = "SELECT * FROM [GD1C2019].[EYE_OF_THE_TRIGGER].[Crucero] JOIN [GD1C2019].[EYE_OF_THE_TRIGGER].[Marca] on marc_id = cruc_marca JOIN [GD1C2019].[EYE_OF_THE_TRIGGER].[Servicio] on serv_id = cruc_servicio JOIN [GD1C2019].[EYE_OF_THE_TRIGGER].[Viaje] on cruc_id = viaj_crucero_id JOIN [GD1C2019].[EYE_OF_THE_TRIGGER].RecorridoViaje on RecorridoViaje.viaj_id = Viaje.viaj_id JOIN [GD1C2019].[EYE_OF_THE_TRIGGER].Recorrido on Recorrido.reco_id = RecorridoViaje.reco_id JOIN [GD1C2019].[EYE_OF_THE_TRIGGER].Puerto p1 on p1.puer_id = Recorrido.reco_origen_id JOIN [GD1C2019].[EYE_OF_THE_TRIGGER].Puerto p2 on p2.puer_id = Recorrido.reco_destino_id WHERE viaj_estado=1 AND cruc_estado=1 AND Convert(datetime, viaj_fecha_inicio) <= Convert(datetime, '" + fechaRegreso + "', 121) AND Convert(datetime, viaj_fecha_inicio, 121) >= Convert(datetime, '" + fechaSalida + "', 121) AND p1.puer_id =" + puertoIdOrigen + " AND p2.puer_id = " + puertoIdDestino + " ";
            if (marca.Length > 0)
                baseQuery = baseQuery + "AND marc_nombre LIKE '%" + marca + "%'";
            if (servicio.Length > 0)
                baseQuery = baseQuery + "AND serv_descripcion = '" + servicio + "' AND serv_estado = 1";
            if (modelo.Length > 0)
                baseQuery = baseQuery + "AND cruc_modelo LIKE '%" + modelo + "%'";

            return baseQuery;
        }

        internal static string SELECT_TIPO_CABINAS_DISPONIBLES(string idCrucero, string viajeId)
        {
            return "SELECT DISTINCT(descripcion) FROM [EYE_OF_THE_TRIGGER].[Cabina] JOIN [EYE_OF_THE_TRIGGER].TipoCabina on cabi_tipo_cabina = id JOIN [EYE_OF_THE_TRIGGER].Viaje on cabi_cruc_id = viaj_crucero_id WHERE cabi_cruc_id = '" + idCrucero + "' and cabi_id not in (SELECT cabi_id FROM [EYE_OF_THE_TRIGGER].CabinasReservadas) and viaj_id = " + viajeId;
        }



        internal static string SELECT_CABINAS(string idCrucero, string descripcion)
        {
            return "SELECT TOP 1 * FROM [EYE_OF_THE_TRIGGER].[Cabina] JOIN [EYE_OF_THE_TRIGGER].TipoCabina on cabi_tipo_cabina = id WHERE cabi_cruc_id = '" + idCrucero + "' and cabi_id not in (SELECT cabi_id FROM [EYE_OF_THE_TRIGGER].CabinasReservadas) and descripcion = '" + descripcion + "'";
        }

        internal static string SELECT_CLIENTE_COMPLETO(int clieId)
        {
            return "SELECT * FROM  [GD1C2019].[EYE_OF_THE_TRIGGER].[Cliente] JOIN [GD1C2019].[EYE_OF_THE_TRIGGER].[TipoDocumento] on clie_tipo_doc = TipoDocumento.id JOIN [GD1C2019].[EYE_OF_THE_TRIGGER].[Domicilio] on clie_domicilio_id = domi_id WHERE clie_id = " + clieId;
        }
    }
}
