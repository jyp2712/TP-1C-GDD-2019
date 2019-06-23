using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaCrucero.Dominio
{
    public class Ciudad
    {
        public int ciudId { get; set; }
        private string ciudNombre { get; set; }
        private int ciudPuertoId { get; set; }

        public Ciudad(int ciud_id, string ciud_nombre, int ciud_puerto_id)
        {
            this.ciudId = ciud_id;
            this.ciudNombre = ciud_nombre;
            this.ciudPuertoId = ciud_puerto_id;
        }

    }
}
