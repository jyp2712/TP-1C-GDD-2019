using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FrbaCrucero.Dominio;
using FrbaCrucero.DB;

namespace FrbaCrucero.PagoReserva
{
    public partial class PagoReservaForm : Form
    {
        public Reserva reserva {get; set;}
        public Ciudad ciudadOrigen { get; set; }
        public Ciudad ciudadDestino {get; set;}
        public Puerto puertoOrigen {get; set;}
        public Puerto puertoDestino { get; set; }

        private void cargarTipoCabina()
        {
            try
            {
                DBConnection dbConnection = DBConnection.getInstance();
                string query = QueryProvider.SELECT_TIPO_CABINAS_DISPONIBLES(this.crucero.Id);
                DataSet dsServicio = dbConnection.executeQuery(query);
                this.comboTipoCabina.DisplayMember = comboTipoCabina.Text;
                foreach (DataRow row in dsServicio.Tables[0].Rows)
                {
                    comboTipoCabina.Items.Add(row["descripcion"].ToString());
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        public PagoReservaForm()
        {
            InitializeComponent();
            this.dtpSalida.Value = Convert.ToDateTime(System.Configuration.ConfigurationManager.AppSettings["fechaSistema"]).AddDays(1);
            this.dtpRegreso.Value = Convert.ToDateTime(System.Configuration.ConfigurationManager.AppSettings["fechaSistema"]).AddDays(1);
            desactivarTodosLosControlesComunes();
        }

        private void desactivarTodosLosControlesComunes()
        {
            this.txtOrigen.Enabled = false;
            this.txtDestino.Enabled = false;
            this.txtNombreCrucero.Enabled = false;
            this.txtMarcaCrucero.Enabled = false;
            this.txtModeloCrucero.Enabled = false;
            this.txtCabina.Enabled = false;
            this.comboTipoCabina.Enabled = false;
            this.btnCrucero.Enabled = false;
        }

        public PagoReservaForm(Reserva reserva)
        {
            InitializeComponent();
            this.txtOrigen.Text = "TODO";
            this.txtDestino.Text = "TODO";
            this.dtpSalida.Value = reserva.Viaje.FechaInicio;
            this.dtpRegreso.Value = reserva.Viaje.FechaFin; //TODO que hacemos con la estimada?
            this.txtNombreCrucero.Text = reserva.Crucero.Nombre;
            this.txtMarcaCrucero.Text = reserva.Crucero.Marca.Nombre;
            this.txtModeloCrucero.Text = reserva.Crucero.Modelo;
            //this.txtTipoCabina.Text = reserva.Cabina.Tipo.Descripcion;
            //this.txtCabina.Text = Convert.ToString(reserva.Cabina.NumeroCabina);

            this.pasajesUpDown.Text = Convert.ToString(reserva.Pasajeros);

            desactivarTodosLosControlesComunes();
            this.dtpSalida.Enabled = false;
            this.dtpRegreso.Enabled = false;
            this.pasajesUpDown.Enabled = false;
        }

        private void PagoReservaForm_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void btnOrigen_Click(object sender, EventArgs e)
        {
            ListadoOrigenDestinoForm listadoOrigen = new ListadoOrigenDestinoForm(ref this.txtOrigen, true);
            listadoOrigen.Show();
            listadoOrigen.RefToPrevForm = this;
            this.Hide();
        }

        private void habilitarCruceroYCabinaSiCorresponde()
        {
            //TODO logica de cabina
            if (txtOrigen.Text.Length > 0 && txtDestino.Text.Length > 0)
                this.btnCrucero.Enabled = true;
        }

        private void btnFechaSalida_Click(object sender, EventArgs e)
        {
            
        }

        private void btnDestino_Click(object sender, EventArgs e)
        {
            ListadoOrigenDestinoForm listadoDestino = new ListadoOrigenDestinoForm(ref this.txtDestino,false);
            listadoDestino.Show();
            listadoDestino.RefToPrevForm = this;
            this.Hide();
        }

        private void btnCrucero_Click(object sender, EventArgs e)
        {
            string format = "yyyy-MM-dd HH:mm:ss.fff";
            string fechaSalida = dtpSalida.Value.Date.ToString(format);
            string fechaRegreso = dtpRegreso.Value.Date.ToString(format);
            SeleccionCruceroForm seleccionCrucero = new SeleccionCruceroForm(fechaSalida, fechaRegreso, this.puertoOrigen.Id, this.puertoDestino.Id);
            seleccionCrucero.Show();
            seleccionCrucero.RefToNextForm = this;
            this.Hide();
        }

        private void onTxtChanged(object sender, EventArgs e)
        {
            habilitarCruceroYCabinaSiCorresponde();
        }


        internal void llenarInfoCrucero(Crucero crucero)
        {
            this.crucero = crucero;
            this.cargarTipoCabina();
            this.comboTipoCabina.Enabled = true;
            this.txtMarcaCrucero.Text = crucero.Marca.Nombre;
            this.txtModeloCrucero.Text = crucero.Modelo;
            this.txtNombreCrucero.Text = crucero.Nombre;
        }

        private void btnCabina_Click(object sender, EventArgs e)
        {

        }

        private void btnReservar_Click(object sender, EventArgs e)
        {

        }

        private void btnFechaLlegada_Click(object sender, EventArgs e)
        {

        }

        public Crucero crucero { get; set; }

        private void comboTipoCabina_SelectedIndexChanged(object sender, EventArgs e)
        {
            DBConnection dbConnection = DBConnection.getInstance();
            string query = QueryProvider.SELECT_CABINAS(this.crucero.Id, this.comboTipoCabina.Text);
            DataTable dt = dbConnection.executeQuery(query).Tables[0];
            this.txtCabina.Text = Convert.ToString(dt.Rows[0]["cabi_numero"]);
            this.txtPiso.Text = Convert.ToString(dt.Rows[0]["cabi_piso"]);

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }
    }
}
