using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace FrbaCrucero.Dominio
{
    public class Reserva:Entidad
    {
        public Reserva (int id, Cliente cliente, Crucero crucero, DateTime fechaCreacion, Viaje viaje, Cabina cabina,
            TipoServicio servicio, EstadoReserva estadoReserva, int pasajeros)
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
        }

        public Reserva(DataSet ds)
        {
            Crucero crucero = new Crucero(ds);
            this.Id = Convert.ToInt32(ds.Tables[0].Rows[0]["rese_id"]);
            this.Cliente = new Cliente(ds);
            this.Crucero = new Crucero(ds);
            this.FechaCreacion = Convert.ToDateTime(ds.Tables[0].Rows[0]["rese_fecha_creacion"]);
            this.Viaje = new Viaje(ds, crucero);
           // this.Cabina = new Cabina(ds);
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
    }
}
