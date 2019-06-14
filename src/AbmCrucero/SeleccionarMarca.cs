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

namespace FrbaCrucero.AbmCrucero
{
    public partial class SeleccionarMarca : Form
    {
        public int id { get; set; }

        public SeleccionarMarca()
        {
            InitializeComponent();
            cargarMarcas();
        }

        private void cargarMarcas()
        {

            try
            {
                DBConnection dbConnection = DBConnection.getInstance();
                DataSet ds = dbConnection.executeQuery(QueryProvider.SELECT_MARCAS);
                this.comboBox1.DisplayMember = comboBox1.Text;
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    comboBox1.Items.Add(row["marc_nombre"].ToString());
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Seleccionar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.comboBox1.Text))
            {
                MessageBox.Show("Debe seleccionar una marca");

            }
            else
            {
                DBConnection dbConnection = DBConnection.getInstance();
                DataSet ds = dbConnection.executeQuery("SELECT * FROM [GD1C2019].[EYE_OF_THE_TRIGGER].[Marca] WHERE marc_nombre='" + this.comboBox1.Text.ToString() + "'");
                this.id = Convert.ToInt32(ds.Tables[0].Rows[0]["marc_id"]);
                this.Close();
            }
        }
    }
}
