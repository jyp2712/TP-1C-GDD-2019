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
        }

        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Mail { get; set; }
        public string Tel { get; set; }
        public DateTime FechaNac { get; set; }
        public Domicilio Domicilio { get; set; }
        public TipoDocumento TipoDoc { get; set; }

        }

}

