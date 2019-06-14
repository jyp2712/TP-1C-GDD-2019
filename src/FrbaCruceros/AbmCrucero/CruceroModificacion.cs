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
            cargarServicios();
            initializeDataGridView(dataGridViewCruceros, ref ds);
            addButtonToDataGridView(dataGridViewCruceros, "Seleccionar", "   Modificar  ");

        }

        private void cargarServicios()
        {

            try
            {
                DBConnection dbConnection = DBConnection.getInstance();
                ds = dbConnection.executeQuery("SELECT * FROM [GD1C2019].[EYE_OF_THE_TRIGGER].[Servicio]");
                this.comboServicio.DisplayMember = comboServicio.Text;
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    comboServicio.Items.Add(row["serv_descripcion"].ToString());
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        public static void initializeDataGridView(DataGridView dgv, ref DataSet ds)
        {
            DBConnection dbConnection = DBConnection.getInstance();
            ds = dbConnection.executeQuery("SELECT * FROM [GD1C2019].[EYE_OF_THE_TRIGGER].[Crucero] WHERE cruc_estado=1");
            dgv.ReadOnly = true;
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToDeleteRows = false;
            dgv.DataSource = ds.Tables[0];


            dgv.Columns["cruc_id"].HeaderText = "Codigo";
            dgv.Columns["cruc_estado"].Visible = false;
        }
        
        private void dataGridViewCruceros_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = dataGridViewCruceros.Rows[e.RowIndex];
                string selected_crucero_id = Convert.ToString(selectedRow.Cells["cruc_id"].Value);

                CruceroModificacionForm bajaForm = new CruceroModificacionForm(selected_crucero_id);
                bajaForm.Show();

                initializeDataGridView(dataGridViewCruceros, ref ds);
            }
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
            this.Marca.Clear();
            this.Codigo.Clear();
            this.CodigoContiene.Clear();
            this.comboServicio.ResetText();
            initializeDataGridView(dataGridViewCruceros, ref ds);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            DBConnection dbConnection = DBConnection.getInstance();
            if (this.Codigo.TextLength < 1 && this.CodigoContiene.TextLength < 1 && string.IsNullOrEmpty(this.comboServicio.Text) && this.Marca.TextLength < 1)
                initializeDataGridView(dataGridViewCruceros, ref ds);
            else
            {
                if (this.CodigoContiene.TextLength < 1 && string.IsNullOrEmpty(this.comboServicio.Text) && this.Marca.TextLength < 1)
                {
                    ds = dbConnection.executeQuery("SELECT * FROM EYE_OF_THE_TRIGGER.Crucero WHERE cruc_id='" + this.Codigo.Text + "' AND cruc_estado=1");
                }
                else
                {
                    DataSet dserv;
                    dserv = dbConnection.executeQuery("SELECT * FROM [GD1C2019].[EYE_OF_THE_TRIGGER].[Servicio] WHERE serv_descripcion='" + this.comboServicio.Text.ToString() + "'");
                    if (dserv.Tables[0].Rows.Count > 0)
                    {
                        if (this.Codigo.TextLength < 1)
                        {
                            ds = dbConnection.executeQuery("SELECT * FROM EYE_OF_THE_TRIGGER.Crucero WHERE cruc_id LIKE('%" + this.CodigoContiene.Text + "%') AND cruc_marca LIKE('%" + this.Marca.Text + "%') AND ISNULL(cruc_servicio, 0) LIKE('%" + dserv.Tables[0].Rows[0]["serv_id"] + "%') AND cruc_estado=1");
                        }
                        else
                        {
                            ds = dbConnection.executeQuery("SELECT * FROM EYE_OF_THE_TRIGGER.Crucero WHERE cruc_id='" + this.Codigo.Text + "' AND cruc_id LIKE('%" + this.CodigoContiene.Text + "%') AND cruc_marca LIKE('%" + this.Marca.Text + "%') AND ISNULL(cruc_servicio, 0) LIKE('%" + dserv.Tables[0].Rows[0]["serv_id"] + "%') AND cruc_estado=1");
                        }
                    }
                    else
                    {
                        if (this.Codigo.TextLength < 1)
                        {
                            ds = dbConnection.executeQuery("SELECT * FROM EYE_OF_THE_TRIGGER.Crucero WHERE cruc_id LIKE('%" + this.CodigoContiene.Text + "%') AND cruc_marca LIKE('%" + this.Marca.Text + "%') AND ISNULL(cruc_servicio, 0) LIKE('%%') AND cruc_estado=1");
                        }
                        else
                        {
                            ds = dbConnection.executeQuery("SELECT * FROM EYE_OF_THE_TRIGGER.Crucero WHERE cruc_id='" + this.Codigo.Text + "' AND cruc_id LIKE('%" + this.CodigoContiene.Text + "%') AND cruc_marca LIKE('%" + this.Marca.Text + "%') AND ISNULL(cruc_servicio, 0) LIKE('%%') AND cruc_estado=1");
                        }
                    }
                }

                dataGridViewCruceros.ReadOnly = true;
                dataGridViewCruceros.DataSource = ds.Tables[0];

                dataGridViewCruceros.Columns["cruc_id"].HeaderText = "Codigo";
                dataGridViewCruceros.Columns["cruc_estado"].Visible = false;
            }
        }

        private void Seleccionar_Click(object sender, EventArgs e)
        {
            SeleccionarMarca sm = new SeleccionarMarca();
            sm.ShowDialog();
            this.Marca.Text = sm.id.ToString();
        }

        
    }
}
