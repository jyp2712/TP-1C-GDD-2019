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
    public partial class BajaRecorrido : Form
    {
        DataSet ds;

        public BajaRecorrido()
        {
            InitializeComponent();
            initializeDataGridView(dataGridViewRecorridos, ref ds);
            addButtonToDataGridView(dataGridViewRecorridos, "Eliminar", "   *  ");

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

        }

        public static void initializeDataGridView(DataGridView dgv, ref DataSet ds)
        {
            DBConnection dbConnection = DBConnection.getInstance();
            ds = dbConnection.executeQuery(QueryProvider.SELECT_RECORRIDOS);
            dgv.ReadOnly = true;
            dgv.DataSource = ds.Tables[0];

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
    }
}
