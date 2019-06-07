using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrbaCrucero.Dominio
{
    public class Marca:Entidad
    {
        public string Nombre {get; set;}
        private System.Data.DataSet ds;

        public Marca(int id, string descripcion)
        {
            Id = id;
            Nombre = descripcion;
        }

        public Marca(System.Data.DataSet ds)
        {
            this.Nombre = Convert.ToString(ds.Tables[0].Rows[0]["marc_nombre"]);
            this.Id = Convert.ToInt32(ds.Tables[0].Rows[0]["marc_id"]);
            this.ds = ds;
        }

    }
}
