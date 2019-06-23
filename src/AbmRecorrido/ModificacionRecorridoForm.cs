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
    public partial class ModificacionRecorridoForm : Form
    {

        private int id;
        private int codigo;

        DataSet ds;
        public Puerto puertoOrigen { get; set; }
        public Puerto puertoDestino { get; set; }
        public Ciudad ciudadOrigen { get; set; }
        public Ciudad ciudadDestino { get; set; }

        public ModificacionRecorridoForm(int id, int codigo)
        {
            this.id = id;
            this.codigo = codigo;
            InitializeComponent();
            cargarDatos();
        }

        private void Agregar_Click(object sender, EventArgs e)
        {
        }

        private void Codigo_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(this.Codigo.Text)) this.Codigo.Clear();

        }

        private void cargarDatos()
        {
            DBConnection dbConnection = DBConnection.getInstance();
            ds = dbConnection.executeQuery(QueryProvider.SELECT_RECORRIDOS_POR_ID(id));
            DataSet dsPuertoOrigen = dbConnection.executeQuery(QueryProvider.SELECT_PUERTO_POR_CIUDAD(ds.Tables[0].Rows[0]["reco_origen_id"].ToString()));
            DataSet dsPuertoDestino = dbConnection.executeQuery(QueryProvider.SELECT_PUERTO_POR_CIUDAD(ds.Tables[0].Rows[0]["reco_destino_id"].ToString()));

            Codigo.Text = ds.Tables[0].Rows[0]["reco_codigo"].ToString();
            textBox1.Text = dsPuertoOrigen.Tables[0].Rows[0]["puer_nombre"].ToString();
            textBox2.Text = dsPuertoDestino.Tables[0].Rows[0]["puer_nombre"].ToString();
            Precio.Text = ds.Tables[0].Rows[0]["reco_precio"].ToString();
        }

        private void Modificar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(this.Codigo.Text) && !string.IsNullOrWhiteSpace(this.Precio.Text))
            {

                DBAdapter.actualizarDatosEnTabla("recorrido", id, Convert.ToInt32(Codigo.Text), textBox1.Text, textBox2.Text,
                    Convert.ToDouble(Precio.Text));
                MessageBox.Show("Recorrido " + id + " modificado");
            }
            else {
                MessageBox.Show("Debe completar todos los campos");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Precio_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(this.Precio.Text)) this.Precio.Clear();

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            ListadosPuertosModificacion list = new ListadosPuertosModificacion(ref this.textBox1, true);
            list.Show();
            list.RefToPrevForm = this;
            this.Hide();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            ListadosPuertosModificacion list = new ListadosPuertosModificacion(ref this.textBox2, false);
            list.Show();
            list.RefToPrevForm = this;
            this.Hide();
        }
    }
}