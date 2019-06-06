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

namespace FrbaCrucero.AbmRecorrido
{
    public partial class BajaRecorridoForm : Form
    {
        private int id;
        DataSet ds;

        public BajaRecorridoForm(int id)
        {
            this.id = id;         
            InitializeComponent();
            cargarDatos();
        }

        private void Agregar_Click(object sender, EventArgs e)
        {
            DBAdapter.borrarDatosEnTabla("recorrido", id);
            MessageBox.Show("Recorrido " + id + " eliminado");
        }

        private void Codigo_TextChanged(object sender, EventArgs e)
        {

        }

        private void cargarDatos() {
            DBConnection dbConnection = DBConnection.getInstance();
            ds = dbConnection.executeQuery(QueryProvider.SELECT_RECORRIDOS_POR_ID(id));

            Codigo.ReadOnly = true;
            Codigo.Text = ds.Tables[0].Rows[0]["reco_codigo"].ToString();
            comboBoxCiudadPuertoOrigen.Enabled = false;
            comboBoxCiudadPuertoOrigen.Text = ds.Tables[0].Rows[0]["reco_origen_id"].ToString();
            comboBoxCiudadPuertoDestino.Enabled = false;
            comboBoxCiudadPuertoDestino.Text = ds.Tables[0].Rows[0]["reco_destino_id"].ToString();
            Precio.ReadOnly = true;
            Precio.Text = ds.Tables[0].Rows[0]["reco_precio"].ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
