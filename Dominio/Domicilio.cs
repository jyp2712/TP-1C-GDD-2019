using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FrbaCrucero
{

    public class Domicilio:Entidad
    {
        public string Descripcion;

        public Domicilio(int id, string pais, string ciudad, string calle, int nro, int piso, string dpto)
        {
            Id = id;
            Pais = pais;
            Ciudad = ciudad;
            Calle = calle;
            Nro = nro;
            Piso = piso;
            Dpto = dpto;
        }

        public Domicilio(DataSet ds)
        {
            this.Id = Convert.ToInt32(ds.Tables[0].Rows[0]["domi_id"]);
            this.Pais = Convert.ToString(ds.Tables[0].Rows[0]["domi_pais"]);
            this.Ciudad = Convert.ToString(ds.Tables[0].Rows[0]["domi_ciudad"]);
            this.Calle = Convert.ToString(ds.Tables[0].Rows[0]["domi_calle"]);
            this.Nro = Convert.ToInt32(ds.Tables[0].Rows[0]["domi_nro_calle"]);
            this.Dpto = Convert.ToString(ds.Tables[0].Rows[0]["domi_dpto"]);
            this.Piso = 0; //TODO rompe con nullConvert.ToInt32(ds.Tables[0].Rows[0]["domi_piso"]);
        }

        public string Pais { get; set; }
        public string Ciudad { get; set; }
        public string Calle { get; set; }
        public int Nro { get; set; }
        public int Piso { get; set; }
        public string Dpto { get; set; }

        public override string ToString()
        {
            return Calle + ' ' + Nro + ' ' + Piso + ' ' + Dpto;
        }
    }
}
