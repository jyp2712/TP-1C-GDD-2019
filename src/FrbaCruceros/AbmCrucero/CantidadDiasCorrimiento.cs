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
    public partial class CantidadDiasCorrimiento : Form
    {
        public int dias { get; set; }

        public CantidadDiasCorrimiento(int dias)
        {
            InitializeComponent();
            this.numericUpDown1.Minimum = Convert.ToDecimal(dias);
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.dias = Convert.ToInt32(this.numericUpDown1.Value);
            this.Close();
        }
    }
}
