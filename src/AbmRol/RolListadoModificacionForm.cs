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

        DataSet ds;

        public RolListadoModificacionForm()
        {
            InitializeComponent();
            RolHelper.initializeDataGridView(dgvRoles, ref ds);
            RolHelper.addButtonToDataGridView(dgvRoles, "Seleccionar", "   *  ");
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        //TODO no anda...
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtNombreRol.Clear();
            ds.Clear();
            RolHelper.initializeDataGridView(dgvRoles, ref ds);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            DataTable dt = RolHelper.buscarRolPorNombre(this.txtNombreRol.Text);
            dgvRoles.DataSource = dt;
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
                dgvRoles.AllowUserToAddRows = false;
                dgvRoles.AllowUserToDeleteRows = false;
                dgvRoles.ReadOnly = true;
            }
        }

        private void txtNombreRol_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
