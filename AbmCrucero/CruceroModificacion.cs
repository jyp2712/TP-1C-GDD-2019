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
    public partial class CruceroModificacion : Form
    {
        DataSet ds;

        public CruceroModificacion()
        {
            InitializeComponent();
            initializeDataGridView(dataGridViewCruceros, ref ds);
            addButtonToDataGridView(dataGridViewCruceros, "Seleccionar", "   Modificar  ");

        }

        public static void initializeDataGridView(DataGridView dgv, ref DataSet ds)
        {
            DBConnection dbConnection = DBConnection.getInstance();
            ds = dbConnection.executeQuery(QueryProvider.SELECT_CRUCEROS);
            dgv.ReadOnly = true;
            dgv.DataSource = ds.Tables[0];


            dgv.Columns["cruc_id"].HeaderText = "Id";
            dgv.Columns["cruc_nombre"].HeaderText = "Nombre";
            dgv.Columns["cruc_fecha_alta"].HeaderText = "Fecha de alta";
            dgv.Columns["cruc_marca"].HeaderText = "Marca";
            dgv.Columns["cruc_estado"].HeaderText = "Estado";
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



        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.txtNombre.Clear();
            this.textNombre2.Clear();
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
                    ds = dbConnection.executeQuery(QueryProvider.SELECT_CRUCEROS_TEXTUAL(this.txtNombre.Text));
                }
                else
                {
                    if (this.textNombre2.TextLength > 0)
                    {
                        ds = dbConnection.executeQuery(QueryProvider.SELECT_CRUCEROS_LIKE(this.textNombre2.Text));
                    }
                }

                dataGridViewCruceros.ReadOnly = true;
                dataGridViewCruceros.DataSource = ds.Tables[0];


                dataGridViewCruceros.Columns["cruc_id"].HeaderText = "Id";
                dataGridViewCruceros.Columns["cruc_nombre"].HeaderText = "Nombre";
                dataGridViewCruceros.Columns["cruc_fecha_alta"].HeaderText = "Fecha de alta";
                dataGridViewCruceros.Columns["cruc_marca"].HeaderText = "Marca";
                dataGridViewCruceros.Columns["cruc_estado"].HeaderText = "Estado";
         
            }
        }

        private void dataGridViewCruceros_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            /*Para esto tengo problemas con los tipos (por ejemplo el del ID y particularmente
            con los nulls de las tablas)*/
        }
    }
}
