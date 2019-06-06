using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaCrucero.AbmRol
{
    public partial class RolForm : Form
    {
        public RolForm()
        {
            InitializeComponent();
        }

        private void RolForm_FormClosing(object sender, FormClosingEventArgs e) {
            //   
        }

        private void btnAlta_Click(object sender, EventArgs e)
        {
            //this.Hide();
            RolAltaModificacionForm altaForm = new RolAltaModificacionForm();
            altaForm.RefToRolForm = this;
            altaForm.Show();
        }

        private void btnBaja_Click(object sender, EventArgs e)
        {
            //this.Hide();
            RolBajaForm bajaForm = new RolBajaForm();
            bajaForm.RefToRolForm = this;
            bajaForm.Show();
        }

        private void btnModificacion_Click(object sender, EventArgs e)
        {
            //this.Hide();
            RolListadoModificacionForm listadoForm = new RolListadoModificacionForm();
            listadoForm.RefToRolForm = this;
            listadoForm.Show();
        }

        private void btnAtras_Click(object sender, EventArgs e)
        {

        }

        private void RolForm_Load(object sender, EventArgs e)
        {

        }
    }
}
