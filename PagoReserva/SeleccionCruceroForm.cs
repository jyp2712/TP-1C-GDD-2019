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

namespace FrbaCrucero.PagoReserva
{
    public partial class SeleccionCruceroForm : Form
    {

        DataSet ds;
        public PagoReservaForm RefToNextForm{ get; set;}

        public SeleccionCruceroForm()
        {
            InitializeComponent();
            cargarServicios();
            cargarMarcas();
            inicializarDataGridView();
            ABMHelper.addButtonToDataGridView(dgv, "Seleccionar", "  Seleccionar ");
        }

        private void cargarMarcas()
        {
            try
            {
                DBConnection dbConnection = DBConnection.getInstance();
                DataSet dsMarca = dbConnection.executeQuery("SELECT * FROM [GD1C2019].[EYE_OF_THE_TRIGGER].[Marca]");
                this.comboMarcas.DisplayMember = comboMarcas.Text;
                foreach (DataRow row in dsMarca.Tables[0].Rows)
                {
                    comboMarcas.Items.Add(row["marc_nombre"].ToString());
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private void cargarServicios()
        {
            try
            {
                DBConnection dbConnection = DBConnection.getInstance();
                DataSet dsServicio = dbConnection.executeQuery("SELECT * FROM [GD1C2019].[EYE_OF_THE_TRIGGER].[Servicio]");
                this.comboServicio.DisplayMember = comboServicio.Text;
                foreach (DataRow row in dsServicio.Tables[0].Rows)
                {
                    comboServicio.Items.Add(row["serv_descripcion"].ToString());
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private void buscar() 
        {
            DBConnection dbConnection = DBConnection.getInstance();
            ds = dbConnection.executeQuery(QueryProvider.SELECT_CRUCERO_MARCA_SERVICIO_MODELO(this.comboMarcas.Text, this.comboServicio.Text, this.txtModelo.Text));
            dgv.ReadOnly = true;
            dgv.DataSource = ds.Tables[0];
           // dgv.Refresh();
        }

        private void inicializarDataGridView() 
        {
            buscar();

            dgv.Columns["cruc_id"].HeaderText = "Codigo";
            dgv.Columns["cruc_fecha_alta"].Visible = false;
            dgv.Columns["cruc_nombre"].HeaderText = "Nombre";
            dgv.Columns["cruc_modelo"].HeaderText = "Modelo";
            dgv.Columns["cruc_cant_cabinas"].Visible = false;
            dgv.Columns["cruc_marca"].Visible = false;
            dgv.Columns["cruc_servicio"].Visible = false;
            dgv.Columns["cruc_estado"].Visible = false;
            dgv.Columns["marc_id"].Visible = false;
            dgv.Columns["marc_nombre"].HeaderText = "Marca";
            dgv.Columns["serv_id"].Visible = false;
            dgv.Columns["serv_descripcion"].HeaderText = "Tipo Servicio";
            dgv.Columns["serv_precio"].Visible = false;
            dgv.Columns["serv_estado"].Visible = false;

        }

        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = dgv.Rows[e.RowIndex];
//                string selected_crucero_id = Convert.ToString(selectedRow.Cells["cruc_id"].Value);

                Crucero crucero = Mappers.GeneralMapper.deDataRowACrucero(selectedRow);

                this.RefToNextForm.llenarInfoCrucero(crucero);
                this.RefToNextForm.Show();
                this.Hide();
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            buscar();
        }
        
    }
}
