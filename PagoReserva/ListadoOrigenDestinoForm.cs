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

namespace FrbaCrucero.PagoReserva
{
    public partial class ListadoOrigenDestinoForm : Form
    {
        DataSet ds;
        TextBox txtToModify;
        Boolean isOrigen;

        public ListadoOrigenDestinoForm(ref TextBox txtToModify, Boolean isOrigen)
        {
            InitializeComponent();
            DBConnection dbConnection = DBConnection.getInstance();
            ds = dbConnection.executeQuery(QueryProvider.SELECT_CIUDADES_ORIGEN);
            dgv.ReadOnly = true;
            dgv.DataSource = ds.Tables[0];
            this.txtToModify = txtToModify;
            this.isOrigen = isOrigen;

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

        public PagoReservaForm RefToPrevForm { get; set; }
    }
}
