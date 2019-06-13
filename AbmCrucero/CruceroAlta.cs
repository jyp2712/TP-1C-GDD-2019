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
    public partial class CruceroAlta : Form
    {
        protected AltaCabina ac = new AltaCabina();
        public string codigo { get; set; }

        public CruceroAlta(string codigo)
        {
            InitializeComponent();
            cargarComboMarcas();
            cargarDatos(codigo);
        }

        private void cargarDatos(string codigo)
        {
            DBConnection dbConnection = DBConnection.getInstance();
            DataSet ds = dbConnection.executeQuery("SELECT * FROM [GD1C2019].[EYE_OF_THE_TRIGGER].[Crucero] WHERE cruc_id='" + codigo + "'");
            DataSet dserv = dbConnection.executeQuery("SELECT * FROM [GD1C2019].[EYE_OF_THE_TRIGGER].[Servicio] WHERE serv_id=" + ds.Tables[0].Rows[0]["cruc_servicio"]);

            this.comboServicio.Enabled = false;
            this.comboServicio.Text = dserv.Tables[0].Rows[0]["serv_descripcion"].ToString();
            this.txtCabinas.Enabled = false;
            this.txtCabinas.Text = ds.Tables[0].Rows[0]["cruc_cant_cabinas"].ToString();

        }

        public CruceroAlta()
        {
            InitializeComponent();
            cargarComboMarcas();
            cargarServicios();
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

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void CruceroAlta_Load(object sender, EventArgs e)
        {

        }

        private void Seleccionar_Click(object sender, EventArgs e)
        {
            ac.ShowDialog();
            if (ac.id > 0)
                this.txtCabinas.Text = ac.id.ToString();
        }

        private void Guardar_Click(object sender, EventArgs e)
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
                DBConnection dbConnection = DBConnection.getInstance();
                DataSet ds = dbConnection.executeQuery("SELECT * FROM [GD1C2019].[EYE_OF_THE_TRIGGER].[Crucero] WHERE cruc_id='" + this.txtCodigo.Text + "'");
                if (ds.Tables[0].Rows.Count == 1)
                {
                    MessageBox.Show("El crucero ya existe");
                }
                else
                {
                    DataSet dserv = dbConnection.executeQuery("SELECT * FROM [GD1C2019].[EYE_OF_THE_TRIGGER].[Servicio] WHERE serv_descripcion='" + this.comboServicio.Text + "'");
                    DataSet dmarc = dbConnection.executeQuery("SELECT * FROM [GD1C2019].[EYE_OF_THE_TRIGGER].[Marca] WHERE marc_nombre='" + this.comboMarcas.Text + "'");

                    DBAdapter.insertarDatosEnTabla("crucero", this.txtCodigo.Text, Convert.ToDateTime(System.Configuration.ConfigurationManager.AppSettings["fechaSistema"]), this.txtNombre.Text, this.txtModelo.Text, Convert.ToInt32(dserv.Tables[0].Rows[0]["serv_id"]),
                        Convert.ToInt32(dmarc.Tables[0].Rows[0]["marc_id"]), Convert.ToInt32(this.txtCabinas.Text));

                    int nro = 1;

                    foreach (KeyValuePair<string, decimal> result in ac.cabinas)
                    {
                        int piso = 0, tipo = 0;
                        if (result.Value > 0)
                        {
                            switch (result.Key)
                            {
                                case "estandar0": piso = 0; tipo = 1;
                                    break;
                                case "estandar1": piso = 1; tipo = 1;
                                    break;
                                case "exterior0": piso = 0; tipo = 2;
                                    break;
                                case "exterior1": piso = 1; tipo = 2;
                                    break;
                                case "suite0": piso = 0; tipo = 3;
                                    break;
                                case "suite1": piso = 1; tipo = 3;
                                    break;
                                case "balcon0": piso = 0; tipo = 4;
                                    break;
                                case "balcon1": piso = 1; tipo = 4;
                                    break;
                                case "ejecutivo0": piso = 0; tipo = 5;
                                    break;
                                case "ejecutivo1": piso = 1; tipo = 5;
                                    break;
                                    
                            }
                            DBAdapter.insertarDatosEnTabla("cabina", nro, piso, tipo, this.txtCodigo.Text);
                            nro++;
                        }
                    }
                    this.codigo = this.txtCodigo.Text;
                    MessageBox.Show("Crucero dado de Alta");
                    this.Close();
                }
            }


        }

        private void comboServicio_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtCodigo_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(this.txtCodigo.Text)) this.txtCodigo.Clear();
        }

        private void Limpiar_Click(object sender, EventArgs e)
        {
            this.txtCodigo.Clear();
            this.txtNombre.Clear();
            this.txtCabinas.Clear();
            this.txtModelo.Clear();
            this.comboServicio.ResetText();
            this.comboMarcas.ResetText();
        }

        private void comboMarcas_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(this.txtNombre.Text)) this.txtNombre.Clear();
        }

        private void txtModelo_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(this.txtModelo.Text)) this.txtModelo.Clear();

        }
    }
}
