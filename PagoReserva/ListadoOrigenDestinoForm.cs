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

namespace FrbaCrucero.PagoReserva
{
    public partial class ListadoOrigenDestinoForm : Form
    {
        DataSet ds;
        TextBox txtToModify;

        public ListadoOrigenDestinoForm(ref TextBox txtToModify)
        {
            InitializeComponent();
            DBConnection dbConnection = DBConnection.getInstance();
            ds = dbConnection.executeQuery(QueryProvider.SELECT_CIUDADES_ORIGEN);
            dgv.ReadOnly = true;
            dgv.DataSource = ds.Tables[0];
            this.txtToModify = txtToModify;

            RolHelper.addButtonToDataGridView(dgv, "Seleccionar", "   *  ");
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {

        }

        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = dgv.Rows[e.RowIndex];
                string puer_nombre = Convert.ToString(selectedRow.Cells["puer_nombre"].Value);

                this.txtToModify.Text = puer_nombre;

                this.RefToPrevForm.Show();
                this.Close();
            }
        }

        public PagoReservaForm RefToPrevForm { get; set; }
    }
}
