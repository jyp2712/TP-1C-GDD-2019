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
using FrbaCrucero.AbmRecorrido;
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
                FrbaCrucero.menuBarra.Menu menu = new menuBarra.Menu(this.txtUser.Text);
                menu.Show();
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

        private Boolean checkUserAndPassword()
        {

            DBConnection dbConnection = DBConnection.getInstance();

            using (SqlCommand cmd = dbConnection.connection.CreateCommand())
            {
                cmd.CommandText = "[GD1C2019].[EYE_OF_THE_TRIGGER].[login]";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@user_name", this.txtUser.Text);
                cmd.Parameters.AddWithValue("@user_contrasenia", this.txtPassword.Text);

                cmd.Parameters.Add("@Resultado", SqlDbType.Bit).Direction = ParameterDirection.Output;

                try
                {
                    dbConnection.connection.Open();
                    cmd.ExecuteNonQuery();
                    var logueado = cmd.Parameters["@Resultado"].Value;
                    dbConnection.connection.Close();
                    return Convert.ToBoolean(logueado);
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                    return false;
                }
                finally {
                    if (dbConnection.connection.State == ConnectionState.Open) dbConnection.connection.Close();
                }
            }
        }

        private void txtUser_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(this.txtUser.Text)) this.txtUser.Clear();

        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(this.txtPassword.Text)) this.txtPassword.Clear();

        }
    }
}

