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
    public partial class RolListadoModificacionForm : Form
    {
        public RolForm RefToRolForm { get; set; }

        public RolListadoModificacionForm()
        {
            InitializeComponent();
            DBConnection dbConnection = DBConnection.getInstance();
            string query = QueryProvider.SELECT_ALL_ROLES;
            DataSet ds = dbConnection.executeQuery(query);
            dgvRoles.DataSource = ds.Tables[0];
            DataGridViewButtonColumn button = new DataGridViewButtonColumn();
            {
                button.Name = "button";
                button.HeaderText = "Seleccionar";
                button.Text = "   *  ";
                button.UseColumnTextForButtonValue = true; //dont forget this line
                this.dgvRoles.Columns.Add(button);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtNombreRol.Clear();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            DBConnection dbConnection = DBConnection.getInstance();
            string query = QueryProvider.SELECT_ROL_LIKE(txtNombreRol.Text);
            DataSet ds = dbConnection.executeQuery(query);
            dgvRoles.DataSource = ds.Tables[0];
        }

        private void dgvRoles_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = dgvRoles.Rows[e.RowIndex];
                string selected_rol_id = Convert.ToString(selectedRow.Cells["rol_id"].Value);           

                RolAltaForm altaForm = new RolAltaForm(selected_rol_id);
                altaForm.Show();
                altaForm.RefToRolForm = this.RefToRolForm;
            }
        }
    }
}
