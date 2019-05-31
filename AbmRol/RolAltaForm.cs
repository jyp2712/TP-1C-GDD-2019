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
            cargarComboFuncionalidades();
            prepararListView();
        }

        public RolAltaForm(string rol_id)
        {
            InitializeComponent();
            cargarComboFuncionalidades();
            prepararListView();
            try
            {
                DBConnection dbConnection = DBConnection.getInstance();
                DataSet ds = dbConnection.executeQuery(QueryProvider.SELECT_ROLES_CON_FUNCIONALIDADES(rol_id));
                txtNombre.Text = Convert.ToString(ds.Tables[0].Rows[0]["rol_nombre"]);
                 foreach (DataRow row in ds.Tables[0].Rows)
                 {
                     //TODO
                     string funcId = Convert.ToString(row["func_id"]);
                     string funcNombre = Convert.ToString(row["func_nombre"]);

                 }

                //listViewFuncionalidadesSeleccionadas.Items.Add({});
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            } 
        }

        private void cargarComboFuncionalidades()
        {
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

        private void prepararListView()
        {
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

        //TODO
        private void btnCrear_Click(object sender, EventArgs e)
        {
            DBConnection dbConnection = DBConnection.getInstance();
            DataSet ds = dbConnection.executeQuery(QueryProvider.INSERT_ROL(this.txtNombre.Text));
        }
    }
}
