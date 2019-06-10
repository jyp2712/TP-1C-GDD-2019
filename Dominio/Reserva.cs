using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using FrbaCrucero.DB;

namespace FrbaCrucero.Dominio
{
    public class Reserva:Entidad
    {
        public Reserva (int id, Cliente cliente, Crucero crucero, DateTime fechaCreacion, Viaje viaje, Cabina cabina,
            TipoServicio servicio, EstadoReserva estadoReserva, int pasajeros, Puerto origen, Puerto destino)
        {
            this.Id=id;
            this.Cliente = cliente;
            this.Crucero = crucero;
            this.FechaCreacion = fechaCreacion;
            this.Viaje = viaje;
            this.Cabina = cabina;
            this.Servicio = servicio;
            this.EstadoReserva = estadoReserva;
            this.Pasajeros = pasajeros;
            this.Origen = origen;
            this.Destino = destino;
        }

        public Reserva(DataSet ds)
        {
            DataSet dsOrigen = DBConnection.getInstance().executeQuery(QueryProvider.SELECT_PUERTO_POR_CIUDAD(Convert.ToString(ds.Tables[0].Rows[0]["reco_origen_id"])));
            //Crucero crucero = new Crucero(ds);
            Puerto origen = new Puerto(dsOrigen);

            /*this.TipoServicio = new TipoServicio(ds);
            this.EstadoReserva = new EstadoReserva(ds);
            this.Pasajeros = ds.Tables[0].Rows[0]["rese_cantidad_pasajeros"];*/
        }

        public Cliente Cliente { get; set; }
        public Crucero Crucero { get; set; }
        public DateTime FechaCreacion { get; set; }
        public Viaje Viaje { get; set; }
        public Cabina Cabina { get; set; }
        public TipoServicio Servicio { get; set; }
        public EstadoReserva EstadoReserva { get; set; }
        public int Pasajeros { get; set; }
        public Puerto Origen { get; set; }
        public Puerto Destino { get; set; }
    }
}
