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

namespace FrbaCrucero.AbmRecorrido
{
    public partial class AltaRecorrido : Form
    {
        public AltaRecorrido()
        {
            InitializeComponent();
            cargarComboPuertos();

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

        private void cargarComboPuertos()
        {
            try
            {
                DBConnection dbConnection = DBConnection.getInstance();
                DataSet ds = dbConnection.executeQuery(QueryProvider.SELECT_CIUDADES_PUERTOS_NOMBRE);
                this.comboBoxCiudadPuertoOrigen.DisplayMember = comboBoxCiudadPuertoOrigen.Text;
                this.comboBoxCiudadPuertoDestino.DisplayMember = comboBoxCiudadPuertoOrigen.Text;
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    comboBoxCiudadPuertoOrigen.Items.Add(row["nombre"].ToString());
                    comboBoxCiudadPuertoDestino.Items.Add(row["nombre"].ToString());
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Codigo.TextLength < 1 || Precio.TextLength < 1 || string.IsNullOrEmpty(this.comboBoxCiudadPuertoOrigen.Text) || string.IsNullOrEmpty(this.comboBoxCiudadPuertoDestino.Text))
            {
                MessageBox.Show("Debe completar todos los campos");
            }
            else
            {
                if (String.Equals(this.comboBoxCiudadPuertoOrigen.Text, this.comboBoxCiudadPuertoDestino.Text))
                {
                    MessageBox.Show("El puerto de origen debe ser diferente al puerto de destino");
                }
                else
                {
                    ValidacionesHelper.validarCampoSoloNumerico(this.Codigo);
                    ValidacionesHelper.validarCampoSoloNumerico(this.Precio);
                    if (DBAdapter.checkIfExists("recorrido_finalizado", Codigo.Text))
                    {
                        MessageBox.Show("Ese recorrido ya fue realizado");
                    }
                    else
                    {
                        if (DBAdapter.checkIfExists("recorrido_existente", Codigo.Text, comboBoxCiudadPuertoOrigen.Text, comboBoxCiudadPuertoDestino.Text))
                        {
                            MessageBox.Show("Ese recorrido ya existe");
                        }
                        else
                        {

                            DataRow origen = DBAdapter.traerDataTable("ciudad_id", comboBoxCiudadPuertoOrigen.Text).Rows[0];
                            DataRow destino = DBAdapter.traerDataTable("ciudad_id", comboBoxCiudadPuertoDestino.Text).Rows[0];

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

 
    }
}
