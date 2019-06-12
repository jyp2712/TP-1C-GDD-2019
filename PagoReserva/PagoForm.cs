using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FrbaCrucero.DB;

namespace FrbaCrucero.PagoReserva
{
    public partial class PagoForm : Form
    {
        public PagoForm()
        {
            InitializeComponent();
            cargarMediosDePago();
        }

        private void cargarMediosDePago()
        {
            try
            {
                DBConnection dbConnection = DBConnection.getInstance();
                DataSet ds = dbConnection.executeQuery("SELECT * FROM [GD1C2019].[EYE_OF_THE_TRIGGER].[MedioDePago]");
                this.comboBox1.DisplayMember = comboBox1.Text;
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    comboBox1.Items.Add(row["medio_descripcion"].ToString());
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (String.Equals(this.comboBox1.Text, "Efectivo"))
            {
                this.numericUpDown1.Value = 1;
                this.numericUpDown1.Enabled = false;
                this.textBox1.Clear();
                this.textBox1.Enabled = false;
                this.textBox2.Enabled = false;
                this.textBox2.Clear();
                this.textBox3.Enabled = false;
                this.textBox3.Clear();
                this.dateTimePicker1.Enabled = false;
            }
            else {
                this.numericUpDown1.Enabled = true;
                this.textBox1.Enabled = true;
                this.textBox2.Enabled = true;
                this.textBox3.Enabled = true;
                this.dateTimePicker1.Enabled = true;
            }

        }
    }
}
