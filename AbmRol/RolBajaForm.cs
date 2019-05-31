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
    public partial class RolBajaForm : Form
    {

        public Form RefToRolForm { get; set; }

        public RolBajaForm()
        {
            InitializeComponent();
            DBConnection dbConnection = DBConnection.getInstance();
            DataSet ds = dbConnection.executeQuery(QueryProvider.SELECT_ROLES);
            dataGridViewRoles.ReadOnly = true;
            dataGridViewRoles.DataSource = ds.Tables[0];
        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            this.Close();
            RefToRolForm.Show();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            DBConnection dbConnection = DBConnection.getInstance();          
            DataGridViewRow selectedRow = dataGridViewRoles.SelectedRows[0];
            int id = Convert.ToInt32(selectedRow.Cells["rol_id"].Value);
            string query = QueryProvider.DELETE_ROLE(id);
            dbConnection.executeQuery(query);
            this.Close();
            RefToRolForm.Show();
  
        }

     
    }
}
