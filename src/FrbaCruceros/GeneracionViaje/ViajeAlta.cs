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

namespace FrbaCrucero.GeneracionViaje
{
    public partial class ViajeAlta : Form
    {

        public ViajeAlta()
        {
            InitializeComponent();
            this.dateTimePicker1.MinDate = Convert.ToDateTime(System.Configuration.ConfigurationManager.AppSettings["fechaSistema"]).AddDays(1);
            this.dateTimePicker2.MinDate = Convert.ToDateTime(System.Configuration.ConfigurationManager.AppSettings["fechaSistema"]).AddDays(1);
        }

        private void Codigo_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ListadoRecorridos lr = new ListadoRecorridos();
            lr.ShowDialog();
            if (lr.id != 0)
                this.Codigo.Text = lr.id.ToString();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            ListadoCruceros lc = new ListadoCruceros();
            lc.ShowDialog();
            if (!String.IsNullOrEmpty(lc.id))
                this.Crucero.Text = lc.id;
        }

        private void Crucero_TextChanged(object sender, EventArgs e)
        {

        }

        private void Agregar_Click(object sender, EventArgs e)
        {
            if (this.Codigo.TextLength < 1 || this.Crucero.TextLength < 1 || this.Viaje.TextLength < 1)
            {
                MessageBox.Show("Debe completar todos los campos");
            }
            else
            {
                try
                {
                    ValidacionesHelper.validarCampoSoloNumerico(this.Viaje);
                    if (this.dateTimePicker1.Value >= this.dateTimePicker2.Value)
                    {
                        MessageBox.Show("La fecha de fin debe ser mayor a la de inicio");
                    }
                    else
                    {

                        if (DBAdapter.checkIfExists("crucero_no_disponible", Crucero.Text, Convert.ToDateTime(dateTimePicker1.Value), Convert.ToDateTime(dateTimePicker2.Value)))
                        {
                            MessageBox.Show("El crucero no esta disponible en esas fechas");
                        }


                        else
                        {
                            DBAdapter.insertarDatosEnTabla("viaje", Viaje.Text, Codigo.Text, Convert.ToDateTime(dateTimePicker1.Value), Convert.ToDateTime(dateTimePicker2.Value), Crucero.Text);
                            MessageBox.Show("Viaje dado de alta");
                        }
                    }
                }
                catch 
                {

                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(this.Viaje.Text)) this.Viaje.Clear();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Codigo.Clear();
            this.Viaje.Clear();
            this.Crucero.Clear();
            this.dateTimePicker1.Value = Convert.ToDateTime(System.Configuration.ConfigurationManager.AppSettings["fechaSistema"]).AddDays(1);
            this.dateTimePicker2.Value = Convert.ToDateTime(System.Configuration.ConfigurationManager.AppSettings["fechaSistema"]).AddDays(1);

        }
    }
}
