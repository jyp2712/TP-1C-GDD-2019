using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrbaCrucero.Dominio
{
    public class TipoCabina : Entidad
    {

        public TipoCabina(int unId,string unaDescripcion, double porcentaje)
        {
            this.Id = unId;
            this.Descripcion = unaDescripcion;
            this.PorcentajeAgregado = porcentaje;
        }

        public string Descripcion { get; set; }
        public double PorcentajeAgregado { get; set; }
    }
}
