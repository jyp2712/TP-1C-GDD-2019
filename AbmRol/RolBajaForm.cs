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

namespace FrbaCrucero.AbmRol
{
    public partial class RolBajaForm : Form
    {

        public Form RefToRolForm { get; set; }

        DataSet ds;

        public RolBajaForm()
        {
            InitializeComponent();
            DBConnection dbConnection = DBConnection.getInstance();
            ds = dbConnection.executeQuery(QueryProvider.SELECT_ROLES);
            dataGridViewRoles.ReadOnly = true;
            dataGridViewRoles.DataSource = ds.Tables[0];
           
            dataGridViewRoles.Columns["rol_id"].HeaderText = "Id";
            dataGridViewRoles.Columns["rol_nombre"].HeaderText = "Nombre";
            dataGridViewRoles.Columns["rol_estado"].HeaderText = "Habilitado";

            DataGridViewButtonColumn button = new DataGridViewButtonColumn();
            {
                button.Name = "button";
                button.HeaderText = "Eliminar";
                button.Text = "   *  ";
                button.UseColumnTextForButtonValue = true;
                this.dataGridViewRoles.Columns.Add(button);
            }
        }

        private void inicializarDataGridView()
        {

        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            this.Close();
            RefToRolForm.Show();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            DBConnection dbConnection = DBConnection.getInstance();          
            DataGridViewRow selectedRow = dataGridViewRoles.SelectedRows[0];
            int id = Convert.ToInt32(selectedRow.Cells["rol_id"].Value);
            string query = QueryProvider.DELETE_ROLE(id);
            dbConnection.executeQuery(query);
            this.Close();
            RefToRolForm.Show();
  
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtNombre.Clear();
            dataGridViewRoles.Refresh();
            ds.Clear();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string rol_nombre = this.txtNombre.Text;
            DataTable dt = DBAdapter.traerDataTable("buscarRolNombre", rol_nombre);
            dataGridViewRoles.DataSource = dt; 
        }

        private void dataGridViewRoles_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = dataGridViewRoles.Rows[e.RowIndex];
                string selected_rol_id = Convert.ToString(selectedRow.Cells["rol_id"].Value);

                DBConnection dbConnection = DBConnection.getInstance();
                int id = Convert.ToInt32(selectedRow.Cells["rol_id"].Value);
                string query = QueryProvider.DELETE_ROLE(id);
                dbConnection.executeQuery(query);
                this.Close();
                RefToRolForm.Show();
            }
        }

     
    }
}
