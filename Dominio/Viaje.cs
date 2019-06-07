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

        public Viaje(DataSet ds, Crucero crucero)
        {
            this.Id = Convert.ToInt32(ds.Tables[0].Rows[0]["viaj_id"]);
            this.Codigo = Convert.ToInt32(ds.Tables[0].Rows[0]["viaj_codigo"]);
            this.FechaInicio = Convert.ToDateTime(ds.Tables[0].Rows[0]["viaj_fecha_inicio"]);
            this.FechaFin = Convert.ToDateTime(ds.Tables[0].Rows[0]["viaj_fecha_fin"]);
            this.FechaFinEstimada = Convert.ToDateTime(ds.Tables[0].Rows[0]["viaj_fecha_fin_estimada"]);
            this.Crucero = crucero;
        }

        public Crucero Crucero { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public DateTime FechaFinEstimada { get; set; }
        public int Codigo { get; set; }
 
    }
}
