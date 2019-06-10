using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace FrbaCrucero.Dominio
{
    public class Puerto: Entidad
    {
        public string Nombre {get; set;}
        public Boolean Estado { get; set; }

        public Puerto(string nombre, Boolean estado, int id)
        { 
            this.Id = id;
            this.Nombre = nombre;
            this.Estado = estado;
        }

        public Puerto(DataSet ds)
        {
            this.Id = Convert.ToInt32(ds.Tables[0].Rows[0]["puer_id"]);
            this.Nombre = Convert.ToString(ds.Tables[0].Rows[0]["puer_nombre"]);
            this.Estado = Convert.ToBoolean(ds.Tables[0].Rows[0]["puer_estado"]);
        }
    }
}
