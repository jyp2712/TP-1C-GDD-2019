using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace FrbaCrucero
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnIngresarCliente_Click(object sender, EventArgs e)
        {
            this.Hide();


            //FrbaCrucero.AbmCliente.ClienteHome rh = new AbmCliente.ClienteHome();
            //rh.Show();

            //FrbaCrucero.GeneracionViaje.ViajeAlta rh = new GeneracionViaje.ViajeAlta();
            FrbaCrucero.menuBarra.Menu menu = new menuBarra.Menu();

          //  FrbaCrucero.AbmCrucero.CruceroAlta menu = new AbmCrucero.CruceroAlta();

          //  FrbaCrucero.AbmCrucero.CruceroAlta menu = new AbmCrucero.CruceroAlta();

          //  FrbaCrucero.AbmCrucero.CruceroAlta menu = new AbmCrucero.CruceroAlta();

         //   FrbaCrucero.AbmCrucero.CruceroAlta menu = new AbmCrucero.CruceroAlta();


            menu.Show();

           // FrbaCrucero.AbmCliente.ClienteHome rh = new AbmCliente.ClienteHome();
           // rh.Show();

            //FrbaCrucero.GeneracionViaje.ViajeAlta rh = new GeneracionViaje.ViajeAlta();
            //FrbaCrucero.PagoReserva.SeleccionReservaForm asd = new PagoReserva.SeleccionReservaForm();
            //FrbaCrucero.PagoReserva.PagoReservaForm frm = new FrbaCrucero.PagoReserva.PagoReservaForm();
            //frm.Show();
            //asd.Show();


        }

        private void btnIngresarAdministrador_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrbaCrucero.Login.LoginForm login = new FrbaCrucero.Login.LoginForm();
            login.RefToMainForm = this;
            login.Show();
        }
    }
}
