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
using System.Security.Cryptography;
using FrbaCrucero.AbmRol;
using System.Data.SqlClient;

namespace FrbaCrucero.Login
{
    public partial class LoginForm : Form
    {
        public Form RefToMainForm { get; set; }

        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            this.Close();
            //FrbaCrucero.MainForm mainForm = new FrbaCrucero.MainForm();
            RefToMainForm.Show();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            if (this.checkUserAndPassword())
            {
                this.Hide();
                RolForm rolForm = new RolForm();
                rolForm.Show();
                //TODO abrir form con cosas de administrador
            }
            else
            {
                this.clearTxtFields();
            }
        }

        private void clearTxtFields()
        {
            this.txtPassword.Clear();
            this.txtUser.Clear();
        }

        private Boolean checkUserAndPassword() {

            String user_name = this.txtUser.Text;
            String password = this.txtPassword.Text;
            try
            {
                int logueado = DBAdapter.ejecutarProcedureWithReturnValue("login", user_name, password);
                return Convert.ToBoolean(logueado);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return false;
            }
        }
    }
}

