using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaCrucero.AbmCrucero
{
    public partial class CruceroHome : Form
    {
        public CruceroHome()
        {
            InitializeComponent();
        }

        private void Alta_Click(object sender, EventArgs e)
        {
            CruceroAlta altaForm = new CruceroAlta();
            altaForm.Show();
        }

        private void Baja_Click(object sender, EventArgs e)
        {
            CruceroBaja bajaForm = new CruceroBaja();
            bajaForm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            CruceroModificacion modificacionForm = new CruceroModificacion();
            modificacionForm.Show();
        }
    }
}
