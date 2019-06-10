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
    public partial class AltaCabina : Form
    {
        public decimal id { get; set; }
        public Dictionary<String, decimal> cabinas { get; set; }

        public AltaCabina()
        {
            this.cabinas = new Dictionary<String, decimal>();
            foreach (NumericUpDown control in this.Controls.OfType<NumericUpDown>())
            {
                this.cabinas.Add(control.Name, control.Value);
            }
            InitializeComponent();
        }

        public AltaCabina(Dictionary<String, decimal> dic)
        {
            this.cabinas = dic;
            InitializeComponent();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (NumericUpDown control in this.Controls.OfType<NumericUpDown>()) {
                this.cabinas[control.Name] = control.Value;
            }
            this.id = this.cabinas.Sum(x => x.Value);

            this.Close();
        }
    }
}
