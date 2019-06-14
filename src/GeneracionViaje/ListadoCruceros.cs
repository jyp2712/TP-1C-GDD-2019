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

namespace FrbaCrucero.GeneracionViaje
{
    public partial class ListadoCruceros : Form
    {

       DataSet ds;
       public string id { get; set; } 

       public ListadoCruceros()
        {
            InitializeComponent();
            initializeDataGridView(dataGridViewCruceros, ref ds);
            addButtonToDataGridView(dataGridViewCruceros, "Seleccionar", "   Seleccionar  ");

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

        private void dataGridViewCruceros_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = dataGridViewCruceros.Rows[e.RowIndex];
                string selected_recorrido_id = Convert.ToString(selectedRow.Cells["cruc_id"].Value);
                id = Convert.ToString(selectedRow.Cells["cruc_id"].Value);

                this.Close();
            }
        }

        public static void initializeDataGridView(DataGridView dgv, ref DataSet ds)
        {
            DBConnection dbConnection = DBConnection.getInstance();
            ds = dbConnection.executeQuery("SELECT * FROM [GD1C2019].[EYE_OF_THE_TRIGGER].[Crucero] WHERE cruc_estado=1");
            dgv.ReadOnly = true;
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToDeleteRows = false;
            dgv.DataSource = ds.Tables[0];


            dgv.Columns["cruc_id"].HeaderText = "Id";
            dgv.Columns["cruc_nombre"].HeaderText = "Nombre";
            dgv.Columns["cruc_fecha_alta"].Visible = false;
            dgv.Columns["cruc_modelo"].HeaderText = "Modelo";
            dgv.Columns["cruc_marca"].HeaderText = "Marca";
            dgv.Columns["cruc_estado"].Visible = false;
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


        private void btnBuscar_Click_1(object sender, EventArgs e)
        {

        }

        private void btnLimpiar_Click_1(object sender, EventArgs e)
        {
            this.txtNombre.Clear();
            this.textNombre2.Clear();
        }

        private void txtNombre_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            DBConnection dbConnection = DBConnection.getInstance();
            if (this.txtNombre.TextLength < 1 && this.textNombre2.TextLength < 1)
                initializeDataGridView(dataGridViewCruceros, ref ds);
            else
            {
                if (this.txtNombre.TextLength > 0)
                {
                    ds = dbConnection.executeQuery("SELECT * FROM [EYE_OF_THE_TRIGGER].[Crucero] WHERE cruc_estado=1 AND cruc_id ='" + this.txtNombre.Text + "'");
                }
                else
                {
                    if (this.textNombre2.TextLength > 0)
                    {
                        ds = dbConnection.executeQuery("SELECT * FROM [EYE_OF_THE_TRIGGER].[Crucero] WHERE cruc_estado=1 AND cruc_id LIKE '%" + this.textNombre2.Text + "%'");
                    }
                }

                dataGridViewCruceros.ReadOnly = true;
                dataGridViewCruceros.DataSource = ds.Tables[0];

                dataGridViewCruceros.Columns["cruc_id"].HeaderText = "Id";
                dataGridViewCruceros.Columns["cruc_nombre"].HeaderText = "Nombre";
                dataGridViewCruceros.Columns["cruc_fecha_alta"].Visible = false;
                dataGridViewCruceros.Columns["cruc_modelo"].HeaderText = "Modelo";
                dataGridViewCruceros.Columns["cruc_marca"].HeaderText = "Marca";
                dataGridViewCruceros.Columns["cruc_estado"].Visible = false;
            }
        }

        private void dataGridViewCruceros_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnLimpiar_Click_2(object sender, EventArgs e)
        {
            this.txtNombre.Clear();
            this.textNombre2.Clear();
        }
    }
}
