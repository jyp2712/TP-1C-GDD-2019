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