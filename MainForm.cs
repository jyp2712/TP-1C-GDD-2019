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
            //FrbaCrucero.GeneracionViaje.ViajeAlta rh = new GeneracionViaje.ViajeAlta();



            FrbaCrucero.menuBarra.menu menu = new menuBarra.menu();
            menu.Show();


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
