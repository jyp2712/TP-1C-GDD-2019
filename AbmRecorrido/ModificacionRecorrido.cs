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
    public partial class ModificacionRecorrido : Form
    {
    DataSet ds;

        public ModificacionRecorrido()
        {
            InitializeComponent();
            initializeDataGridView(dataGridViewRecorridos, ref ds);
            addButtonToDataGridView(dataGridViewRecorridos, "Seleccionar", "   Modificar  ");

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void dataGridViewRecorridos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = dataGridViewRecorridos.Rows[e.RowIndex];
                string selected_recorrido_id = Convert.ToString(selectedRow.Cells["reco_id"].Value);
                int id = Convert.ToInt32(selectedRow.Cells["reco_id"].Value);

                ModificacionRecorridoForm modifForm = new ModificacionRecorridoForm(id);
                modifForm.Show();

                initializeDataGridView(dataGridViewRecorridos, ref ds);
            }

        }


        public static void initializeDataGridView(DataGridView dgv, ref DataSet ds)
        {
            DBConnection dbConnection = DBConnection.getInstance();
            ds = dbConnection.executeQuery(QueryProvider.SELECT_RECORRIDOS);
            dgv.ReadOnly = true;
            dgv.DataSource = ds.Tables[0];


            dgv.Columns["reco_id"].HeaderText = "Id";
            dgv.Columns["reco_codigo"].HeaderText = "Codigo";
            dgv.Columns["reco_origen_id"].HeaderText = "Desde";
            dgv.Columns["reco_destino_id"].HeaderText = "Hasta";
            dgv.Columns["reco_precio"].HeaderText = "Precio";
            dgv.Columns["reco_estado"].HeaderText = "Estado";
        }

        public static void addButtonToDataGridView(DataGridView dgv, string headerText, string buttonText)
        {

            DataGridViewButtonColumn button = new DataGridViewButtonColumn();
            {
                button.Name = "button";
                button.HeaderText = headerText;
                button.Text = buttonText;
                button.UseColumnTextForButtonValue = true;
                dgv.Columns.Add(button);
            }
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.txtNombre.Clear();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {

            if (this.txtNombre.TextLength > 0)
            {
                foreach (DataGridViewRow row in dataGridViewRecorridos.Rows)
                {
                    row.Visible = true;
                }
                foreach (DataGridViewRow row in dataGridViewRecorridos.Rows)
                {
                    if (!Convert.ToString(row.Cells["reco_codigo"].Value).Equals(this.txtNombre.Text))
                    {
                            row.Visible = false;
                    }
                }
            }
            else
            {
                initializeDataGridView(dataGridViewRecorridos, ref ds);
            }

        }
    }
}
