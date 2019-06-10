using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using FrbaCrucero.DB;

namespace FrbaCrucero.Dominio
{
    public class Cliente:Entidad
    {

        public Cliente(int Id)
        {
            this.Id = Id;
        }

       /* public Cliente(DataSet ds)
        {
            this.Id = Convert.ToInt32(ds.Tables[0].Rows[0]["clie_id"]);
            this.Nombre = Convert.ToString(ds.Tables[0].Rows[0]["clie_nombre"]);
            this.Apellido = Convert.ToString(ds.Tables[0].Rows[0]["clie_apellido"]);
            this.Mail = Convert.ToString(ds.Tables[0].Rows[0]["clie_mail"]);
            this.TipoDoc = new TipoDocumento(ds);
            this.Domicilio = new Domicilio(ds);
            this.Doc = Convert.ToInt32(ds.Tables[0].Rows[0]["clie_doc"]);
            this.Tel = Convert.ToString(ds.Tables[0].Rows[0]["clie_tel"]);
            this.FechaNac = Convert.ToDateTime(ds.Tables[0].Rows[0]["clie_fecha_nac"]);
        }*/

        public Cliente(int Id, string nombre, string apellido, string mail, TipoDocumento tipoDoc, Domicilio domicilio,
            int doc, string tel, DateTime fechaNac)
        {
            this.TipoDoc = tipoDoc;
            this.Domicilio = domicilio;
            this.Apellido = apellido;
            this.Nombre = nombre;
            this.Mail = mail;
            this.Tel = tel;
            this.FechaNac = fechaNac;
            this.Id = Id;
            this.Doc = doc;
        }

        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Mail { get; set; }
        public string Tel { get; set; }
        public DateTime FechaNac { get; set; }
        public Domicilio Domicilio { get; set; }
        public TipoDocumento TipoDoc { get; set; }
        public int Doc { get; set; }

        }

}

