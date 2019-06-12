using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FrbaCrucero.Validaciones;
using FrbaCrucero.DB;
using FrbaCrucero.Dominio;

namespace FrbaCrucero.AbmRecorrido
{
    public partial class AltaRecorrido : Form
    {
        public Puerto puertoOrigen { get; set; }
        public Puerto puertoDestino { get; set; }
        public Ciudad ciudadOrigen { get; set; }
        public Ciudad ciudadDestino { get; set; }

        public AltaRecorrido()
        {
            InitializeComponent();
            this.textBox1.Enabled = false;
            this.textBox2.Enabled = false;    
        }

        private void AltaRecorrido_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void comboBoxCiudadPuertoDestino_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        private void button1_Click(object sender, EventArgs e)
        {
            if (Codigo.TextLength < 1 || Precio.TextLength < 1 || string.IsNullOrEmpty(this.textBox1.Text) || string.IsNullOrEmpty(this.textBox2.Text))
            {
                MessageBox.Show("Debe completar todos los campos");
            }
            else
            {
                if (String.Equals(this.textBox1.Text, this.textBox2.Text))
                {
                    MessageBox.Show("El puerto de origen debe ser diferente al puerto de destino");
                }
                else
                {
                    ValidacionesHelper.validarCampoSoloNumerico(this.Codigo);
                    ValidacionesHelper.validarCampoSoloNumerico(this.Precio);
                    if (DBAdapter.checkIfExists("recorrido_finalizado", Codigo.Text, Convert.ToDateTime(System.Configuration.ConfigurationManager.AppSettings["fechaSistema"])))
                    {
                        MessageBox.Show("Ese recorrido ya fue realizado");
                    }
                    else
                    {
                        if (DBAdapter.checkIfExists("recorrido_existente", Codigo.Text, textBox1.Text, textBox2.Text))
                        {
                            MessageBox.Show("Ese recorrido ya existe");
                        }
                        else
                        {

                            DataRow origen = DBAdapter.traerDataTable("ciudad_id", textBox1.Text).Rows[0];
                            DataRow destino = DBAdapter.traerDataTable("ciudad_id", textBox2.Text).Rows[0];

                            DBAdapter.insertarDatosEnTabla("recorrido", Codigo.Text, origen["ciud_id"], destino["ciud_id"], Precio.Text);
                        }
                    }
                }
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            ListadoPuertos list = new ListadoPuertos(ref this.textBox1, true);
            list.Show();
            list.RefToPrevForm = this;
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ListadoPuertos list = new ListadoPuertos(ref this.textBox2, false);
            list.Show();
            list.RefToPrevForm = this;
            this.Hide();
        }

 
    }
}
