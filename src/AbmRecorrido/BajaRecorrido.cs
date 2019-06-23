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
using System.Data.SqlClient;

namespace FrbaCrucero.AbmRecorrido
{
    public partial class BajaRecorrido : Form
    {
        DataSet ds;

        public BajaRecorrido()
        {
            InitializeComponent();
            initializeDataGridView(dataGridViewRecorridos, ref ds);
            addButtonToDataGridView(dataGridViewRecorridos, "Eliminar", "   Borrar  ");

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
                int selected_recorrido_id = Convert.ToInt32(selectedRow.Cells["reco_id"].Value);
                int id = Convert.ToInt32(selectedRow.Cells["reco_codigo"].Value);

                BajaRecorridoForm bajaForm = new BajaRecorridoForm(selected_recorrido_id, id);
                bajaForm.ShowDialog();

                initializeDataGridView(dataGridViewRecorridos, ref ds);
            }
        }

        public static void initializeDataGridView(DataGridView dgv, ref DataSet ds)
        {
            DBConnection dbConnection = DBConnection.getInstance();
            ds = dbConnection.executeQuery(QueryProvider.SELECT_RECORRIDOS);
            dgv.ReadOnly = true;
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToDeleteRows = false;
            dgv.DataSource = ds.Tables[0];


            dgv.Columns["reco_id"].HeaderText = "Id";
            dgv.Columns["reco_codigo"].HeaderText = "Codigo";
            dgv.Columns["reco_origen_id"].HeaderText = "Desde";
            dgv.Columns["reco_destino_id"].HeaderText = "Hasta";
            dgv.Columns["reco_precio"].HeaderText = "Precio";
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
            this.textNombre2.Clear();

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            DBConnection dbConnection = DBConnection.getInstance();
            if (this.txtNombre.TextLength < 1 && this.textNombre2.TextLength < 1)
                initializeDataGridView(dataGridViewRecorridos, ref ds);
            else
            {
                if (this.txtNombre.TextLength > 0)
                {
                    ds = dbConnection.executeQuery(QueryProvider.SELECT_RECORRIDOS_TEXTUAL(this.txtNombre.Text));
                }
                else
                {
                    if (this.textNombre2.TextLength > 0)
                    {
                        ds = dbConnection.executeQuery(QueryProvider.SELECT_RECORRIDOS_LIKE(this.textNombre2.Text));
                    }
                }

                dataGridViewRecorridos.ReadOnly = true;
                dataGridViewRecorridos.DataSource = ds.Tables[0];


                dataGridViewRecorridos.Columns["reco_id"].HeaderText = "Id";
                dataGridViewRecorridos.Columns["reco_codigo"].HeaderText = "Codigo";
                dataGridViewRecorridos.Columns["reco_origen_id"].HeaderText = "Desde";
                dataGridViewRecorridos.Columns["reco_destino_id"].HeaderText = "Hasta";
                dataGridViewRecorridos.Columns["reco_precio"].HeaderText = "Precio";
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

