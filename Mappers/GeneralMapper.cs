using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using FrbaCrucero.Dominio;
using FrbaCrucero.DB;
using System.Data.SqlClient;

namespace FrbaCrucero.Mappers
{
    class GeneralMapper
    {
        public static Cliente deDataSetACliente(DataSet ds)
        {
            int id = Convert.ToInt32(ds.Tables[0].Rows[0]["clie_id"]);
            string nombre = Convert.ToString(ds.Tables[0].Rows[0]["clie_nombre"]);
            string apellido = Convert.ToString(ds.Tables[0].Rows[0]["clie_apellido"]);
            string mail = Convert.ToString(ds.Tables[0].Rows[0]["clie_mail"]);
            TipoDocumento tipoDocumento = deDataSetATipoDocumento(ds);
            Domicilio domicilio = deDataSetADomicilio(ds);
            int numeroDocumento = Convert.ToInt32(ds.Tables[0].Rows[0]["clie_doc"]);
            string tel = Convert.ToString(ds.Tables[0].Rows[0]["clie_tel"]);
            DateTime fechaNac = Convert.ToDateTime(ds.Tables[0].Rows[0]["clie_fecha_nac"]);
            return new Cliente(id,nombre,apellido,mail,tipoDocumento,domicilio,numeroDocumento,tel,fechaNac);
        }

        public static Domicilio deDataSetADomicilio(DataSet ds)
        {
            int id = Convert.ToInt32(ds.Tables[0].Rows[0]["domi_id"]);
            string pais = Convert.ToString(ds.Tables[0].Rows[0]["domi_pais"]);
            string ciudad = Convert.ToString(ds.Tables[0].Rows[0]["domi_ciudad"]);
            string calle = Convert.ToString(ds.Tables[0].Rows[0]["domi_calle"]);
            int nro = Convert.ToInt32(ds.Tables[0].Rows[0]["domi_nro_calle"]);
            string dpto = Convert.ToString(ds.Tables[0].Rows[0]["domi_dpto"]);
            int piso = 0; //TODO rompe con nullConvert.ToInt32(ds.Tables[0].Rows[0]["domi_piso"]);
            return new Domicilio(id, pais, ciudad, calle, nro, piso, dpto);
        }

        public static TipoDocumento deDataSetATipoDocumento(DataSet ds)
        {
            int id = Convert.ToInt32(ds.Tables[0].Rows[0]["id"]);
            string descripcion = Convert.ToString(ds.Tables[0].Rows[0]["descripcion"]);
            return new TipoDocumento(id, descripcion);
        }

        public static Crucero deDataSetACrucero(DataSet ds)
        {
            string id = Convert.ToString(ds.Tables[0].Rows[0]["cruc_id"]);
            int estado = Convert.ToInt32(ds.Tables[0].Rows[0]["cruc_estado"]);
            string nombre = Convert.ToString(ds.Tables[0].Rows[0]["cruc_nombre"]);
            string modelo = Convert.ToString(ds.Tables[0].Rows[0]["cruc_modelo"]);
            Marca marca = deDataSetAMarca(ds);
            //TODO la fecha en null rompe
            //DateTime fechaAlta = Convert.ToDateTime(ds.Tables[0].Rows[0]["cruc_fecha_alta"]);
            //TODO
            DateTime fechaAlta = Convert.ToDateTime(System.Configuration.ConfigurationManager.AppSettings["fechaSistema"]);
            return new Crucero(id, nombre, modelo, fechaAlta, marca, estado);//TODO
        }

        public static Marca deDataSetAMarca(DataSet ds)
        {
            string nombre = Convert.ToString(ds.Tables[0].Rows[0]["marc_nombre"]);
            int id = Convert.ToInt32(ds.Tables[0].Rows[0]["marc_id"]);
            return new Marca(id, nombre);
        }

        public static Viaje deDataSetAViaje(DataSet ds)
        {
            Crucero crucero = deDataSetACrucero(ds);
            int id = Convert.ToInt32(ds.Tables[0].Rows[0]["viaj_id"]);
            int codigo = Convert.ToInt32(ds.Tables[0].Rows[0]["viaj_codigo"]);
            DateTime fechaInicio = Convert.ToDateTime(ds.Tables[0].Rows[0]["viaj_fecha_inicio"]);
            DateTime fechaFin = Convert.ToDateTime(ds.Tables[0].Rows[0]["viaj_fecha_fin"]);
            DateTime fechaFinEstimada = Convert.ToDateTime(ds.Tables[0].Rows[0]["viaj_fecha_fin_estimada"]);
            return new Viaje(id, codigo, fechaInicio, fechaFin, fechaFinEstimada, crucero);
        }

        public static Cabina deDataSetACabina(int cabinaId)
        
        {
            DataSet ds = DBConnection.getInstance().executeQuery(QueryProvider.SELECT_CABINA());
            if (ds.Tables[0].Rows.Count == 0) 
            {
                return null;
            }
            int id = Convert.ToInt32(ds.Tables[0].Rows[0]["cabi_id"]);
            int numero = Convert.ToInt32(ds.Tables[0].Rows[0]["cabi_numero"]);
            int piso = Convert.ToInt32(ds.Tables[0].Rows[0]["cabi_piso"]);
            TipoCabina tipo = deDataSetATipoCabina(ds);
            Crucero crucero = deDataSetACrucero(ds);
            return new Cabina(id, numero, piso, tipo, crucero);
        }

        public static TipoCabina deDataSetATipoCabina(DataSet ds)
        {
            int id = Convert.ToInt32(ds.Tables[0].Rows[0]["id"]);
            string unaDescripcion = Convert.ToString(ds.Tables[0].Rows[0]["descripcion"]);
            int porcentaje = Convert.ToInt32(ds.Tables[0].Rows[0]["porcentaje_agregado"]);
            return new TipoCabina(id, unaDescripcion, porcentaje);
        }

        public static TipoServicio deDataSetATipoServicio(DataSet ds)
        {
            //return new TipoServicio(id, desc, precio, estado);
            //TODO
            throw new NotImplementedException();
        }

        public static Reserva deDataSetAReserva(DataSet ds)
        { 
           // DataSet dsCliente = DBConnection.getInstance().executeQuery(QueryProvider.SELECT_CLIENTE(Convert.ToInt32(ds.Tables[0].Rows[0]["rese_clintee_id"])));
            
            int id = Convert.ToInt32(ds.Tables[0].Rows[0]["rese_id"]);
            Cliente cliente = deDataSetACliente(ds);
            Crucero crucero = deDataSetACrucero(ds);
            DateTime fechaCreacion = Convert.ToDateTime(ds.Tables[0].Rows[0]["rese_fecha_creacion"]);
            Viaje viaje = deDataSetAViaje(ds);
            int cabinaId = Convert.ToInt32(ds.Tables[0].Rows[0]["rese_cabina_id"]);
            Cabina cabina = deDataSetACabina(cabinaId);
            TipoServicio servicio = deDataSetATipoServicio(ds);
            EstadoReserva estadoReserva = deDataSetAEstadoReserva(ds);
            int pasajeros = Convert.ToInt32(ds.Tables[0].Rows[0]["rese_cantidad_pasajeros"]);
            DataSet dsOrigen = DBConnection.getInstance().executeQuery(QueryProvider.SELECT_PUERTO_POR_CIUDAD(Convert.ToString(ds.Tables[0].Rows[0]["reco_origen_id"])));
            DataSet dsDestino = DBConnection.getInstance().executeQuery(QueryProvider.SELECT_PUERTO_POR_CIUDAD(Convert.ToString(ds.Tables[0].Rows[0]["reco_destino_id"])));
            Puerto origen = new Puerto(dsOrigen);
            Puerto destino = new Puerto(dsDestino);

            return new Reserva(id, cliente, crucero, fechaCreacion, viaje, cabina, servicio, estadoReserva, pasajeros, origen, destino);

        }

        //TODO
        private static EstadoReserva deDataSetAEstadoReserva(DataSet ds)
        {
            throw new NotImplementedException();
        }
    }
}
