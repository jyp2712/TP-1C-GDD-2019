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

                //TODO setear en 0 la cantidad de reintentos de login.
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
            DBConnection dbConnection = DBConnection.getInstance();           

            using (SqlCommand cmd = dbConnection.connection.CreateCommand())
            {
                cmd.CommandText = "[GD1C2019].[EYE_OF_THE_TRIGGER].[login]";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@user_name", this.txtUser.Text);
                cmd.Parameters.AddWithValue("@user_contrasenia", this.txtPassword.Text);

                cmd.Parameters.Add("@logeado", SqlDbType.Bit).Direction = ParameterDirection.Output;

                try
                {
                    dbConnection.connection.Open();
                    cmd.ExecuteNonQuery();
                    var result = cmd.Parameters["@logeado"].Value;
                    dbConnection.connection.Close();
                    return Convert.ToBoolean(result);
                }
                catch (SqlException e)
                {
                    MessageBox.Show(e.Message);
                    return false;
                }
                finally
                {
                    if (dbConnection.connection.State == ConnectionState.Open) dbConnection.connection.Close();
                }
            }
        }  
       
    }
}
