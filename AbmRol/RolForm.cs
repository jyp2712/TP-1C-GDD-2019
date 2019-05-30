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

        private void btnAlta_Click(object sender, EventArgs e)
        {
            this.Hide();
            RolAltaForm altaForm = new RolAltaForm();
            altaForm.Show();
        }

        private void btnBaja_Click(object sender, EventArgs e)
        {
            this.Hide();
            RolBajaForm bajaForm = new RolBajaForm();
            bajaForm.RefToRolForm = this;
            bajaForm.Show();
        }
    }
}
