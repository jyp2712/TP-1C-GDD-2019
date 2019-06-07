using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrbaCrucero.Dominio
{
    public class Cabina : Entidad
    {
        private System.Data.DataSet ds;

        public Cabina(int id, int numero, int piso, TipoCabina tipo, Crucero crucero)
        {
            this.Id = id;
            this.Tipo = tipo;
            this.NumeroCabina = numero;
            this.Piso = piso;
            this.Crucero = crucero;
        }

        public Cabina()
        {
        }

        public Crucero Crucero { get; set; }
        public int NumeroCabina { get; set; }
        public int Piso { get; set; }
        public TipoCabina Tipo { get; set; }

        public string ToString(){
            return Convert.ToString(this.NumeroCabina); 
        }

    }
}
