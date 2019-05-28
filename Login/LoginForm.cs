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
            //TODO ir a la DB.
            DBConnection dbConnection = DBConnection.getInstance();
            //string query = "SELECT * FROM [GD1C2019].[dbo].[User] WHERE user_usuario='admin' AND user_contrasenia='E6B87050BFCB8143FCB8DB0170A4DC9ED00D904DDD3E2A4AD1B1E8DC0FDC9BE7'";
            string sha256Password =  "\'" + toSHA256(this.txtPassword.Text) + "\'";
            string username = "\'" + this.txtUser.Text + "\'";
            string query = "SELECT * FROM [GD1C2019].[dbo].[User] WHERE user_usuario=" + username + " AND user_contrasenia=" + sha256Password;
            DataSet ds = dbConnection.executeQuery(query);
            int r = ds.Tables[0].Rows.Count;
            return ds.Tables[0].Rows.Count != 0;
        }

        private string toSHA256(String rawData) 
        {  
            // Create a SHA256   
            using (SHA256 sha256Hash = SHA256.Create())  
            {  
                // ComputeHash - returns byte array  
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));  
  
                // Convert byte array to a string   
                StringBuilder builder = new StringBuilder();  
                for (int i = 0; i < bytes.Length; i++)  
                {  
                    builder.Append(bytes[i].ToString("x2"));  
                }  
                return builder.ToString();  
            }  
        }  
       
    }
}
