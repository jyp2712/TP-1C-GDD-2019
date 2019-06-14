using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaCrucero
{
    public partial class menuBarra : Form
    {
        public menuBarra()
        {
            InitializeComponent();
        }

        private void toolStripTextBox1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void abmCrucero_Click(object sender, EventArgs e)
        {
            FrbaCrucero.AbmCrucero.Form1 crucero = new AbmCrucero.Form1();
            crucero.Show();
        }

        private void generarViaje_Click(object sender, EventArgs e)
        {
            FrbaCrucero.GeneracionViaje.ViajeAlta viaje = new GeneracionViaje.ViajeAlta();
            viaje.Show();
        }

        private void toolStripTextBox1_Click_1(object sender, EventArgs e)
        {
            FrbaCrucero.AbmRol.RolForm rol = new AbmRol.RolForm();
            rol.Show();
        }

        private void abmRecorrido_Click(object sender, EventArgs e)
        {
            FrbaCrucero.AbmRecorrido.RecorridoHome recorrido = new AbmRecorrido.RecorridoHome();
            recorrido.Show();
        }

        private void compra_reserva_Click(object sender, EventArgs e)
        {
            FrbaCrucero.CompraPasaje.Form1 compra = new CompraPasaje.Form1();
            compra.Show();
        }

        private void pagarReserva_Click(object sender, EventArgs e)
        {
            FrbaCrucero.PagoReserva.SeleccionReservaForm pago = new PagoReserva.SeleccionReservaForm();
            pago.Show();
        }
    }
}
