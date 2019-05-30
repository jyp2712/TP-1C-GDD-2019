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
    public partial class RolAltaForm : Form
    {
        public RolAltaForm()
        {
           
            InitializeComponent();
            try
            {

                DBConnection dbConnection = DBConnection.getInstance();
                DataSet ds = dbConnection.executeQuery(QueryProvider.SELECT_FUNCIONALIDADES_NOMBRE);
                this.comboFuncionalidades.DisplayMember = "func_nombre";
                this.comboFuncionalidades.ValueMember = "your field"; //TODO //Field in the datatable which you want to be the value of the combobox 
                this.comboFuncionalidades.DataSource = ds.Tables[0];
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }  
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void comboFuncionalidades_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {

            //dataGridFuncionalidadesAgregadas.Rows.Add()
            //DataGridViewRow row = dataGridFuncionalidadesAgregadas.Rows[rowId];

            //row.Cells["id"].Value = comboFuncionalidades.DataSource
            //row.Cells["codigoArticulo"].Value = pLineasArticulo.codigoArticulo;
        }
    }
}
