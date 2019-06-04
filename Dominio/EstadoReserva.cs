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

    public class EstadoReserva:Entidad
    {
        public string Descripcion;

        public EstadoReserva(int id, string descripcion)
        {
            Id = id;
            Descripcion = descripcion;
        }

    }
}