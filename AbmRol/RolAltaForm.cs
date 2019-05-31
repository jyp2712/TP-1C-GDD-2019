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

            listViewFuncionalidadesSeleccionadas.View = View.Details;
            listViewFuncionalidadesSeleccionadas.Columns.Add("id");
            listViewFuncionalidadesSeleccionadas.Columns.Add("nombre");
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void comboFuncionalidades_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private bool IsInCollection(ListViewItem lvi)
        {
            foreach (ListViewItem item in listViewFuncionalidadesSeleccionadas.Items)
            {
                bool subItemEqualFlag = true;
                for (int i = 0; i < item.SubItems.Count; i++)
                {
                    string sub1 = item.SubItems[i].Text;
                    string sub2 = lvi.SubItems[i].Text;
                    if (sub1 != sub2)
                    {
                        subItemEqualFlag = false;
                    }
                }
                if (subItemEqualFlag)
                    return true;
            }
            return false;
        } 

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            DataRowView oDataRowView = comboFuncionalidades.SelectedItem as DataRowView;
            var selectedID = Convert.ToString(oDataRowView.Row["func_id"]);
            string[] row = { selectedID, comboFuncionalidades.Text };
            var listViewItem = new ListViewItem(row);

            if (!IsInCollection(listViewItem))
            {           
                listViewFuncionalidadesSeleccionadas.Items.Add(listViewItem);
            }
            else
            {
                MessageBox.Show("La funcionalidad ya fue seleccionada anteriormente !");
            }  

        }
    }
}
