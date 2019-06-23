using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FrbaCrucero.DB;
using System.Data;

namespace FrbaCrucero.AbmRol
{
    class RolHelper
    {
        public static void initializeDataGridView(DataGridView dgv, ref DataSet ds)
        {
            DBConnection dbConnection = DBConnection.getInstance();
            ds = dbConnection.executeQuery(QueryProvider.SELECT_ROLES);
            dgv.ReadOnly = true;
            dgv.DataSource = ds.Tables[0];

            dgv.Columns["rol_id"].HeaderText = "Id";
            dgv.Columns["rol_nombre"].HeaderText = "Nombre";
            dgv.Columns["rol_estado"].HeaderText = "Habilitado";
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

        public static DataTable buscarRolPorNombre(string nombre)
        {
            string rol_nombre = nombre;
            return DBAdapter.traerDataTable("buscarRolNombre", rol_nombre);
        }
    }
}
