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
    public partial class CruceroModificacionForm : Form
    {
        DataSet ds;
        string id;
        protected AltaCabina ac = new AltaCabina();

        public CruceroModificacionForm(string id)
        {
            this.id = id;
            InitializeComponent();
            cargarDatos();
            cargarComboMarcas();
            cargarServicios();
            
        }

        public CruceroModificacionForm()
        {
            InitializeComponent();
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

        private void cargarServicios()
        {
            try
            {
                DBConnection dbConnection = DBConnection.getInstance();
                DataSet ds = dbConnection.executeQuery("SELECT * FROM [GD1C2019].[EYE_OF_THE_TRIGGER].[Servicio]");
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

        private void cargarDatos()
        {
            DBConnection dbConnection = DBConnection.getInstance();
            ds = dbConnection.executeQuery("SELECT * FROM [GD1C2019].[EYE_OF_THE_TRIGGER].[Crucero] WHERE cruc_id='" + id + "'");


            txtCodigo.ReadOnly = true;
            txtCodigo.Text = ds.Tables[0].Rows[0]["cruc_id"].ToString();
            //txtNombre.ReadOnly = true;
            txtNombre.Text = ds.Tables[0].Rows[0]["cruc_nombre"].ToString();
            //txtModelo.ReadOnly = true;
            txtModelo.Text = ds.Tables[0].Rows[0]["cruc_modelo"].ToString();

            DataSet dserv = dbConnection.executeQuery("SELECT * FROM [GD1C2019].[EYE_OF_THE_TRIGGER].[Servicio] WHERE serv_id=" + ds.Tables[0].Rows[0]["cruc_servicio"].ToString());
            DataSet dmarc = dbConnection.executeQuery("SELECT * FROM [GD1C2019].[EYE_OF_THE_TRIGGER].[Marca] WHERE marc_id=" + ds.Tables[0].Rows[0]["cruc_marca"].ToString());

            comboMarcas.Enabled = true;
            comboMarcas.Text = dmarc.Tables[0].Rows[0]["marc_nombre"].ToString();
            comboServicio.Enabled = true;
            comboServicio.Text = dserv.Tables[0].Rows[0]["serv_descripcion"].ToString();

            txtCabinas.ReadOnly = true;
            txtCabinas.Text = ds.Tables[0].Rows[0]["cruc_cant_cabinas"].ToString();
        }
        
        private void Seleccionar_Click(object sender, EventArgs e)
        {
           
        }

        private void CruceroModificacionForm_Load(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Limpiar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Modificar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.txtCodigo.Text) || string.IsNullOrWhiteSpace(this.txtCodigo.Text)
              || string.IsNullOrEmpty(this.txtNombre.Text) || string.IsNullOrWhiteSpace(this.txtNombre.Text)
              || string.IsNullOrEmpty(this.txtModelo.Text) || string.IsNullOrWhiteSpace(this.txtModelo.Text)
              || string.IsNullOrEmpty(this.comboServicio.Text) || string.IsNullOrWhiteSpace(this.comboServicio.Text)
              || string.IsNullOrEmpty(this.comboMarcas.Text) || string.IsNullOrWhiteSpace(this.comboMarcas.Text)
              || string.IsNullOrEmpty(this.txtCabinas.Text) || string.IsNullOrWhiteSpace(this.txtCabinas.Text))
            {
                MessageBox.Show("Debe completar todos los campos");
            }

            else
            {
                DBAdapter.actualizarDatosEnTabla("crucero", this.id, this.txtNombre.Text, this.txtModelo.Text, Convert.ToInt32(this.comboMarcas.Text), Convert.ToInt32(this.comboServicio.Text));
                MessageBox.Show("Crucero " + id + " modificado");
                this.cargarDatos();
            }

        }

        
    }
}
