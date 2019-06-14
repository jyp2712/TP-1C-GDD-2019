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
        private int codigo;
        DataSet ds;

        public BajaRecorridoForm(int id, int codigo)
        {
            this.id = id;
            this.codigo = codigo;
            InitializeComponent();
            cargarDatos();
        }

        private void Agregar_Click(object sender, EventArgs e)
        {
            DBAdapter.borrarDatosEnTabla("recorrido", id);
            MessageBox.Show("Recorrido " + id + " eliminado");
            this.Close();
        }

        private void Codigo_TextChanged(object sender, EventArgs e)
        {

        }

        private void cargarDatos() {
            DBConnection dbConnection = DBConnection.getInstance();
            ds = dbConnection.executeQuery(QueryProvider.SELECT_RECORRIDOS_POR_ID(id));
            DataSet dsPuertoOrigen = dbConnection.executeQuery(QueryProvider.SELECT_PUERTO_POR_CIUDAD(ds.Tables[0].Rows[0]["reco_origen_id"].ToString()));
            DataSet dsPuertoDestino = dbConnection.executeQuery(QueryProvider.SELECT_PUERTO_POR_CIUDAD(ds.Tables[0].Rows[0]["reco_destino_id"].ToString()));

            Codigo.ReadOnly = true;
            Codigo.Text = ds.Tables[0].Rows[0]["reco_codigo"].ToString();
            comboBoxCiudadPuertoOrigen.Text = dsPuertoOrigen.Tables[0].Rows[0]["puer_nombre"].ToString();
            comboBoxCiudadPuertoDestino.Text = dsPuertoDestino.Tables[0].Rows[0]["puer_nombre"].ToString();
            Precio.ReadOnly = true;
            Precio.Text = ds.Tables[0].Rows[0]["reco_precio"].ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBoxCiudadPuertoOrigen_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

    }
}
