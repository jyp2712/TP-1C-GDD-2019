using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FrbaCrucero.AbmRol;
using FrbaCrucero.DB;
using FrbaCrucero.Dominio;

namespace FrbaCrucero.AbmRecorrido
{
    public partial class ListadoPuertos : Form
    {
        DataSet ds;
        TextBox txtToModify;
        Boolean isOrigen;

        public ListadoPuertos(ref TextBox txtToModify, Boolean isOrigen)
        {
            InitializeComponent();
            inicializarDataGridView();
            this.txtToModify = txtToModify;
            this.isOrigen = isOrigen;
            RolHelper.addButtonToDataGridView(dgv, "Seleccionar", "   *  ");

        }

        private void inicializarDataGridView()
        {
            cargarEstadoInicial();
            dgv.ReadOnly = true;
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToDeleteRows = false;
            dgv.DataSource = ds.Tables[0];

            dgv.Columns["ciud_id"].Visible = false;
            dgv.Columns["ciud_nombre"].HeaderText = "Nombre Ciudad";
            dgv.Columns["ciud_puerto_id"].Visible = false;
            dgv.Columns["puer_id"].Visible = false;
            dgv.Columns["puer_estado"].Visible = false;
            dgv.Columns["puer_nombre"].HeaderText = "Nombre Puerto";

        }

        private void cargarEstadoInicial() 
        {
            DBConnection dbConnection = DBConnection.getInstance();
            string query = QueryProvider.SELECT_CIUDADES_Y_PUERTO;
            ds = dbConnection.executeQuery(query);
        }


        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string query = QueryProvider.SELECT_CIUDADES_Y_PUERTO_LIKE(this.txtNombreCiudad.Text);
            DataSet ds = DBConnection.getInstance().executeQuery(query);
            dgv.DataSource = ds.Tables[0];
        }

        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = dgv.Rows[e.RowIndex];
                string puer_nombre = Convert.ToString(selectedRow.Cells["puer_nombre"].Value);
                int puer_id = Convert.ToInt32(selectedRow.Cells["puer_id"].Value);
                Boolean puer_estado = Convert.ToBoolean(selectedRow.Cells["puer_estado"].Value);
                Puerto puerto = new Puerto(puer_nombre, puer_estado, puer_id);

                int ciud_id = Convert.ToInt32(selectedRow.Cells["ciud_id"].Value);
                string ciud_nombre = Convert.ToString(selectedRow.Cells["ciud_nombre"].Value);
                int ciud_puerto_id = Convert.ToInt32(selectedRow.Cells["ciud_puerto_id"].Value);

                Ciudad ciudad = new Ciudad(ciud_id, ciud_nombre, ciud_puerto_id);

                this.txtToModify.Text = puer_nombre;

                if (isOrigen){
                    this.RefToPrevForm.puertoOrigen = puerto;
                    this.RefToPrevForm.ciudadOrigen = ciudad;
                    this.RefToPrevForm.Show();

                } else {
                    this.RefToPrevForm.puertoDestino = puerto;
                    this.RefToPrevForm.ciudadDestino = ciudad;
                    this.RefToPrevForm.Show();
                }
                
                this.Close();
            }
        }

        public AltaRecorrido RefToPrevForm { get; set; }

        //TODO no anda.
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtNombreCiudad.Clear();
            ds.Clear();
            cargarEstadoInicial();
            dgv.Refresh();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void txtNombreCiudad_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnBuscar_Click_1(object sender, EventArgs e)
        {
            string query = QueryProvider.SELECT_CIUDADES_Y_PUERTO_LIKE(this.txtNombreCiudad.Text);
            DataSet ds = DBConnection.getInstance().executeQuery(query);
            dgv.DataSource = ds.Tables[0];
        }

        private void btnLimpiar_Click_1(object sender, EventArgs e)
        {
            txtNombreCiudad.Clear();
            ds.Clear();
            cargarEstadoInicial();
            dgv.Refresh();
        }
    }
}
