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
using FrbaCrucero.Validaciones;

namespace FrbaCrucero.PagoReserva
{
    public partial class PagoForm : Form
    {
        private int reserva { get; set; }
        private int viaje { get; set; }
        private string crucero { get; set; }

        public PagoForm(int reserva, int viaje, string crucero)
        {
            this.reserva = reserva;
            this.viaje = viaje;
            this.crucero = crucero;

            InitializeComponent();
            cargarMediosDePago();
            cargarEmisores();
            this.dateTimePicker1.MinDate = Convert.ToDateTime(System.Configuration.ConfigurationManager.AppSettings["fechaSistema"]);
        }

        private void cargarEmisores()
        {
            this.comboBox2.DisplayMember = comboBox2.Text;
            comboBox2.Items.Add("VISA");
            comboBox2.Items.Add("MAESTRO/MASTERCARD");

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
                this.Tarjeta.Clear();
                this.Tarjeta.Enabled = false;
                this.Nombre.Enabled = false;
                this.Nombre.Clear();
                this.Codigo.Enabled = false;
                this.Codigo.Clear();
                this.comboBox2.Enabled = false;
                this.comboBox2.Text = "";
                this.dateTimePicker1.Enabled = false;
            }
            else
            {
                if (String.Equals(this.comboBox1.Text, "Tarjeta de Debito"))
                {
                    this.numericUpDown1.Value = 1;
                    this.numericUpDown1.Enabled = false;
                    this.Tarjeta.Enabled = true;
                    this.Nombre.Enabled = true;
                    this.Codigo.Enabled = true;
                    this.comboBox2.Enabled = true;
                    this.dateTimePicker1.Enabled = true;
                }
                else
                {
                    this.numericUpDown1.Enabled = true;
                    this.Tarjeta.Enabled = true;
                    this.Nombre.Enabled = true;
                    this.Codigo.Enabled = true;
                    this.comboBox2.Enabled = true;
                    this.dateTimePicker1.Enabled = true;
                }
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DBConnection dbConnection = DBConnection.getInstance();
            DataSet ds;

            if (String.Equals(this.comboBox1.Text, "Efectivo"))
            {
                DBAdapter.ejecutarProcedure("facturar", this.reserva, this.viaje, this.crucero, this.comboBox1.Text,
                    Convert.ToInt32(this.numericUpDown1.Value), Convert.ToDateTime(System.Configuration.ConfigurationManager.AppSettings["fechaSistema"]));
                ds = dbConnection.executeQuery("SELECT MAX(comp_id) FROM [GD1C2019].[EYE_OF_THE_TRIGGER].[Compra]");
                MessageBox.Show("Compra efectuada. Nº de voucher: "+ ds.Tables[0].Rows[0]["comp_id"].ToString());

                this.Close();
            }
            else
            {
                if (String.IsNullOrEmpty(this.comboBox1.Text) || String.IsNullOrEmpty(this.comboBox2.Text))
                {
                    MessageBox.Show("Debe completar todos los campos");
                }
                else
                {
                    try
                    {
                        ValidacionesHelper.validarCampoSoloNumerico(this.Tarjeta);
                        ValidacionesHelper.validarCampoSoloTexto(this.Nombre);
                        ValidacionesHelper.validarCampoSoloNumerico(this.Codigo);
                        if (String.IsNullOrWhiteSpace(this.Nombre.Text))
                        {
                            MessageBox.Show("Complete su nombre por favor");
                        }
                        else
                        {
                            DBAdapter.ejecutarProcedure("facturar", this.reserva, this.viaje, this.crucero, this.comboBox1.Text,
                                Convert.ToInt32(this.numericUpDown1.Value), Convert.ToDateTime(System.Configuration.ConfigurationManager.AppSettings["fechaSistema"]));
                            ds = dbConnection.executeQuery("SELECT MAX(comp_id) FROM [GD1C2019].[EYE_OF_THE_TRIGGER].[Compra]");
                            MessageBox.Show("Compra efectuada. Nº de voucher: " + ds.Tables[0].Rows[0]["comp_id"].ToString());
                            this.Close();
                        }
                    }
                    catch { }
                }

            }



        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

    }
}
