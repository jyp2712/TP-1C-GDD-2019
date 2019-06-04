using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaCrucero.Login;

namespace FrbaCrucero
{
    public partial class ABM
    {
        private void Continuar()
        {
            //TODO: Negrada, mejorar si hay tiempo
            if (this.radioAlta.Checked)
                alta();
            else if (this.radioModificacion.Checked)
                modificacion();
            else if (this.radioBaja.Checked)
                baja();
            else
                throw new ExcepcionFrbaCrucero("Debe seleccionar una acción para continuar");
        }
   
        public virtual void alta(){}
        public virtual void baja(){}
        public virtual void modificacion(){}
    }
}
