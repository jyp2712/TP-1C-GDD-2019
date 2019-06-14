using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrbaCrucero.Dominio
{
    public class MedioDePago:Entidad
    {
        public string Descripcion { get; set; }
        public int Cuotas { get; set; }

        public MedioDePago()
        {
        }

        public MedioDePago(int Id, string desc, int cuotas)
        {
            this.Id = Id;
            this.Descripcion = desc;
            this.Cuotas = cuotas;
        }

    }
}
