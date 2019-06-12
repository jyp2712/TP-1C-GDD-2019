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
    public partial class CruceroBajaForm : Form
    {
        private string id;
        DataSet ds;

        public CruceroBajaForm(string id)
        {
            this.id = id;
            InitializeComponent();
            cargarDatos();
            cargarMotivos();
            this.dateTimePickerBaja.MinDate = Convert.ToDateTime(System.Configuration.ConfigurationManager.AppSettings["fechaSistema"]);
        }

        private void cargarMotivos()
        {
            comboBoxMotivo.Items.Add("Fuera de Servicio");
            comboBoxMotivo.Items.Add("Baja Definitiva");
        }

        private void cargarDatos()
        {
            DBConnection dbConnection = DBConnection.getInstance();
            ds = dbConnection.executeQuery("SELECT * FROM [GD1C2019].[EYE_OF_THE_TRIGGER].[Crucero] WHERE cruc_id='" + id + "'");


            txtCodigo.ReadOnly = true;
            txtCodigo.Text = ds.Tables[0].Rows[0]["cruc_id"].ToString();
            txtNombre.ReadOnly = true;
            txtNombre.Text = ds.Tables[0].Rows[0]["cruc_nombre"].ToString();
            txtModelo.ReadOnly = true;
            txtModelo.Text = ds.Tables[0].Rows[0]["cruc_modelo"].ToString();

            DataSet dserv = dbConnection.executeQuery("SELECT * FROM [GD1C2019].[EYE_OF_THE_TRIGGER].[Servicio] WHERE serv_id=" + ds.Tables[0].Rows[0]["cruc_servicio"].ToString());
            DataSet dmarc = dbConnection.executeQuery("SELECT * FROM [GD1C2019].[EYE_OF_THE_TRIGGER].[Marca] WHERE marc_id=" + ds.Tables[0].Rows[0]["cruc_marca"].ToString());

            comboMarcas.Enabled = false;
            comboMarcas.Text = dmarc.Tables[0].Rows[0]["marc_nombre"].ToString();
            comboServicio.Enabled = false;
            comboServicio.Text = dserv.Tables[0].Rows[0]["serv_descripcion"].ToString();

            txtCabinas.ReadOnly = true;
            txtCabinas.Text = ds.Tables[0].Rows[0]["cruc_cant_cabinas"].ToString();
        }


        private void Eliminar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.comboBoxMotivo.Text) || string.IsNullOrWhiteSpace(this.comboBoxMotivo.Text))
            {
                MessageBox.Show("Debe especificar un motivo de baja");
            }
            else
            {
                if (DBAdapter.checkIfExists("reservas_para_crucero", this.txtCodigo.Text, Convert.ToDateTime(System.Configuration.ConfigurationManager.AppSettings["fechaSistema"]), Convert.ToDateTime(this.dateTimePickerBaja.Text)))
                {
                    DecisionReplanificacion dr = new DecisionReplanificacion(this.txtCodigo.Text, this.comboBoxMotivo.Text, Convert.ToDateTime(this.dateTimePickerBaja.Value));
                    dr.ShowDialog();
                    if (dr.reemplazoOk)
                    {
                        DBAdapter.actualizarDatosEnTabla("crucero_estado", this.id, this.comboBoxMotivo.Text, Convert.ToDateTime(this.dateTimePickerBaja.Value), Convert.ToDateTime(System.Configuration.ConfigurationManager.AppSettings["fechaSistema"]));
                    }
                    else
                    {
                        MessageBox.Show("Ups! Algo fallo, estamos trabajando para solucionarlo");
                    }
                }
                else {
                    DBAdapter.actualizarDatosEnTabla("crucero_estado", this.id, this.comboBoxMotivo.Text, Convert.ToDateTime(this.dateTimePickerBaja.Value), Convert.ToDateTime(System.Configuration.ConfigurationManager.AppSettings["fechaSistema"]));
                }
                MessageBox.Show("Crucero " + id + " dado de baja");
                this.Close();
            }
        }

        private void Cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dateTimePickerBaja_ValueChanged(object sender, EventArgs e)
        {

        }

        private void comboBoxMotivo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (string.Equals(this.comboBoxMotivo.Text, "Baja Definitiva"))
            {
                this.dateTimePickerBaja.Enabled = false;
                this.dateTimePickerBaja.Value = this.dateTimePickerBaja.MaxDate;
            }
            else
            {
                this.dateTimePickerBaja.Value = Convert.ToDateTime(System.Configuration.ConfigurationManager.AppSettings["fechaSistema"]);
                this.dateTimePickerBaja.Enabled = true;
            }
        }
    }
}
