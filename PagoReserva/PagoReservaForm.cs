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

namespace FrbaCrucero.PagoReserva
{
    public partial class PagoReservaForm : Form
    {
        Reserva reserva;

        public PagoReservaForm()
        {
            InitializeComponent();
            this.dtpSalida.Value = DateTime.Now.AddDays(1);
            this.dtpRegreso.Value = DateTime.Now.AddDays(1);
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

            this.txtCantidadPasajes.Text = Convert.ToString(reserva.Pasajeros);

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

        }

        private void btnFechaSalida_Click(object sender, EventArgs e)
        {

        }
    }
}
