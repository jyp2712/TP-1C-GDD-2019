using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaCrucero.menuBarra
{
    public partial class menu : Form
    {
        public menu()
        {
            InitializeComponent();
        }

        private void toolStripTextBox2_Click(object sender, EventArgs e)
        {
            FrbaCrucero.CompraPasaje.Form1 compra = new CompraPasaje.Form1();
            compra.Show();
        }

        private void toolStripTextBox1_Click(object sender, EventArgs e)
        {
            FrbaCrucero.GeneracionViaje.ViajeAlta viaje = new GeneracionViaje.ViajeAlta();
            viaje.Show();
        }

        private void abmRol_Click(object sender, EventArgs e)
        {
            FrbaCrucero.AbmRol.RolForm rol = new AbmRol.RolForm();
            rol.Show();
        }

        private void abmRecorrido_Click(object sender, EventArgs e)
        {
            FrbaCrucero.AbmRecorrido.RecorridoHome recorrido = new AbmRecorrido.RecorridoHome();
            recorrido.Show();
        }

        private void pagoReserva_Click(object sender, EventArgs e)
        {
            FrbaCrucero.PagoReserva.SeleccionReservaForm pago = new PagoReserva.SeleccionReservaForm();
            pago.Show();
        }

        private void abmCrucero_Click(object sender, EventArgs e)
        {
            FrbaCrucero.AbmCrucero.Form1 crucero = new AbmCrucero.Form1();
            crucero.Show();
        }

        private void estadistica_Click(object sender, EventArgs e)
        {
            FrbaCrucero.Listado_Estadistico.HomeEstadistico estadistica = new Listado_Estadistico.HomeEstadistico();
            estadistica.Show();
        }
    }
}
