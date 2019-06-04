using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace FrbaCrucero.Dominio
{
    public class Reserva:Entidad
    {
        public Reserva (int id, Cliente cliente, Crucero crucero, string fechaCreacion, Viaje viaje, Cabina cabina,
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

        public Cliente Cliente { get; set; }
        public Crucero Crucero { get; set; }
        public string FechaCreacion { get; set; }
        public Viaje Viaje { get; set; }
        public Cabina Cabina { get; set; }
        public TipoServicio Servicio { get; set; }
        public EstadoReserva EstadoReserva { get; set; }
        public int Pasajeros { get; set; }
    }
}
