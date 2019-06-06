using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrbaCrucero.Dominio
{
    public class Marca:Entidad
    {
        public string Nombre;

        public Marca(int id, string descripcion)
        {
            Id = id;
            Nombre = descripcion;
        }

    }
}
