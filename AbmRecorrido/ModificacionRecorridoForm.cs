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
    public partial class ModificacionRecorridoForm : Form
    {

        private int id;
        DataSet ds;

        public ModificacionRecorridoForm(int id)
        {
            this.id = id;
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

            Codigo.Text = ds.Tables[0].Rows[0]["reco_codigo"].ToString();
            comboBoxCiudadPuertoOrigen.Text = ds.Tables[0].Rows[0]["reco_origen_id"].ToString();
            comboBoxCiudadPuertoDestino.Text = ds.Tables[0].Rows[0]["reco_destino_id"].ToString();
            Precio.Text = ds.Tables[0].Rows[0]["reco_precio"].ToString();
        }

        private void Modificar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(this.Codigo.Text) && !string.IsNullOrWhiteSpace(this.Precio.Text))
            {

                DBAdapter.actualizarDatosEnTabla("recorrido", id, Convert.ToInt32(Codigo.Text), Convert.ToInt32(comboBoxCiudadPuertoOrigen.Text), Convert.ToInt32(comboBoxCiudadPuertoDestino.Text),
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
    }
}