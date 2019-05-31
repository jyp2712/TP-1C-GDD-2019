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

            listView1.View = View.Details;
            listView1.Columns.Add("id");
            listView1.Columns.Add("nombre");
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void comboFuncionalidades_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            DataRowView oDataRowView = comboFuncionalidades.SelectedItem as DataRowView;
            string[] row = { Convert.ToString(oDataRowView.Row["func_id"]), comboFuncionalidades.Text };
            var listViewItem = new ListViewItem(row);
            listView1.Items.Add(listViewItem);
        }
    }
}
