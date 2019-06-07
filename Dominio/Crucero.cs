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

namespace FrbaCrucero
{
    public class Crucero:Entidad
    {

        public Crucero(string id, string nombre, string modelo, DateTime fechaAlta, Marca marca, int estado)
        {
            this.Id = id;
            this.Nombre = nombre;
            this.Modelo = modelo;
            this.FechaAlta = fechaAlta;
            this.Marca = marca;
            this.estado = estado;
        }

        public string Nombre { get; set; }
        public string Modelo { get; set; }
        public DateTime FechaAlta { get; set; }
        public Marca Marca { get; set; }
        public int estado { get; set; }
        public string Id { get; set; }


        public string ToString() {
            return this.Nombre + this.Modelo + this.Marca.Nombre;
        }
    }
}
