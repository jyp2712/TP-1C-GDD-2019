using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaCrucero.Dominio;
using FrbaCrucero.DB;

namespace FrbaCrucero.Dominio
{
    public class Viaje : Entidad
    {
        public Viaje(int id, int codigo, DateTime fechaInicio, DateTime fechaFin, DateTime fechaFinEstimada, Crucero cruceroId)
        {
            this.Id = id;
            this.Crucero = cruceroId;
            this.FechaInicio = fechaInicio;
            this.FechaFin = fechaFin;
            this.FechaFinEstimada = fechaFinEstimada;
            this.Codigo = codigo;
        }

        public Crucero Crucero { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public DateTime FechaFinEstimada { get; set; }
        public int Codigo { get; set; }
 
    }
}
