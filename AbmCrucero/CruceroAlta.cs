using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FrbaCrucero.Validaciones;
using FrbaCrucero.DB;

namespace FrbaCrucero.AbmCrucero
{
    public partial class CruceroAlta : Form
    {
        public CruceroAlta()
        {
            InitializeComponent();
            cargarComboMarcas();
        }

        private void cargarComboMarcas()
        {
            try
            {
                DBConnection dbConnection = DBConnection.getInstance();
                DataSet ds = dbConnection.executeQuery(QueryProvider.SELECT_MARCAS);
                this.comboMarcas.DisplayMember = comboMarcas.Text;
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    comboMarcas.Items.Add(row["marc_nombre"].ToString());
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void CruceroAlta_Load(object sender, EventArgs e)
        {

        }
    }
}
