using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrbaCrucero.Dominio
{
    public class TipoServicio:Entidad
    {
        public string Descripcion { get; set; }
        public double PrecioBase { get; set; }
        public int Estado { get; set; }

        public TipoServicio(int id, string desc, double precio, int estado)
        {
            this.Id = id;
            this.Descripcion = desc;
            this.PrecioBase = precio;
            this.Estado = estado;
        }


    }
}
