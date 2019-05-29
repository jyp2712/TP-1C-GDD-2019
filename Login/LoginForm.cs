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
            FrbaCrucero.MainForm mainForm = new FrbaCrucero.MainForm();
            RefToMainForm.Show();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            if (this.checkUserAndPassword())
            {
                MessageBox.Show("VAAAMOO");
                //TODO abrir form con cosas de administrador

                //TODO setear en 0 la cantidad de reintentos de login.
            }
            else
            {
                this.clearTxtFields();
                this.incrementLoginAttempts();
            }
        }

        private void incrementLoginAttempts()
        {
            //TODO ir a la DB a incrementar el numero de reintentos.
            //throw new NotImplementedException();

        }

        private void clearTxtFields()
        {
            this.txtPassword.Clear();
            this.txtUser.Clear();
        }

        private Boolean checkUserAndPassword() {
            DBConnection dbConnection = DBConnection.getInstance();           
            DataSet ds = dbConnection.executeQuery(QueryProvider.LOGIN_QUERY(this.txtUser.Text, this.txtPassword.Text));
            int r = ds.Tables[0].Rows.Count;
            return ds.Tables[0].Rows.Count != 0;
        }  
       
    }
}
