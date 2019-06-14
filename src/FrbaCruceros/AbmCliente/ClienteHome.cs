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
using FrbaCrucero.Validaciones;
using FrbaCrucero.Dominio;

namespace FrbaCrucero.AbmCliente
{
    public partial class ClienteHome : Form
    {
        DataSet ds;
        private String nombre { get; set; }
        private int documento { get; set; }
        private String tipoDocumento { get; set; }
        DBConnection dbConnection = DBConnection.getInstance();

        public ClienteHome()
        {
            this.tipoDocumento = "DNI";
            InitializeComponent();
            cargarTiposDocumentos();
            this.dateTimePicker1.MaxDate = Convert.ToDateTime(System.Configuration.ConfigurationManager.AppSettings["fechaSistema"]).AddYears(-18);

        }

        public ClienteHome(int id)
        {
            InitializeComponent();
            this.Documento.Text = id.ToString();
            Action<Control.ControlCollection> func = null;
            func = (controls) =>
            {
                foreach (Control control in controls)
                {
                    if (control is TextBox) (control as TextBox).Enabled = false;
                }
            };

            func(Controls);
            this.comboBoxTipoDoc.Enabled = false;
            this.Calle.Enabled = false;
            this.Nro.Enabled = false;
            this.Piso.Enabled = false;
            this.Dpto.Enabled = false;
            this.Ciudad.Enabled = false;
            this.Pais.Enabled = false;
            this.Telefono.Enabled = false;
            this.dateTimePicker1.Enabled = false;
            this.button3.Visible = false;
            this.Agregar.Visible = false;
        }

        private void cargarTiposDocumentos()
        {
            DataSet dsDoc;
            dsDoc = dbConnection.executeQuery("SELECT * FROM [GD1C2019].[EYE_OF_THE_TRIGGER].[TipoDocumento]");
            foreach (DataRow row in dsDoc.Tables[0].Rows)
            {
                comboBoxTipoDoc.Items.Add(row["descripcion"].ToString());
            }

        }

        private void ClienteHome_Load(object sender, EventArgs e)
        {

        }


        private void label12_Click(object sender, EventArgs e)
        {

        }

        public void cargarCliente(DataRow row)
        {
            DataSet dsDoc, dsDom;
            this.Apellido.Text = row["clie_apellido"].ToString();
            this.Nombre.Text = row["clie_nombre"].ToString();
            dsDoc = dbConnection.executeQuery("SELECT * FROM [GD1C2019].[EYE_OF_THE_TRIGGER].[TipoDocumento] WHERE id=" + row["clie_tipo_doc"].ToString());
            this.comboBoxTipoDoc.Text = dsDoc.Tables[0].Rows[0]["descripcion"].ToString();
            this.dateTimePicker1.Text = Convert.ToDateTime(row["clie_fecha_nac"].ToString()).ToShortDateString();
            this.email.Text = row["clie_mail"].ToString();
            this.Telefono.Text = row["clie_tel"].ToString();

            dsDom = dbConnection.executeQuery("SELECT * FROM [GD1C2019].[EYE_OF_THE_TRIGGER].[Domicilio] WHERE domi_id=" + row["clie_domicilio_id"].ToString());
            this.Calle.Text = dsDom.Tables[0].Rows[0]["domi_calle"].ToString();
            this.Nro.Text = dsDom.Tables[0].Rows[0]["domi_nro_calle"].ToString();
            this.Piso.Text = dsDom.Tables[0].Rows[0]["domi_piso"].ToString();
            this.Dpto.Text = dsDom.Tables[0].Rows[0]["domi_dpto"].ToString();
            this.Ciudad.Text = dsDom.Tables[0].Rows[0]["domi_ciudad"].ToString();
            this.Pais.Text = dsDom.Tables[0].Rows[0]["domi_pais"].ToString();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            this.Documento.BackColor = Color.White;
            try
            {
                this.documento = Convert.ToInt32(this.Documento.Text);
                ds = dbConnection.executeQuery("SELECT * FROM [GD1C2019].[EYE_OF_THE_TRIGGER].[Cliente] WHERE clie_doc=" + this.documento);
                if (ds.Tables[0].Rows.Count == 1)
                {
                    this.cargarCliente(ds.Tables[0].Rows[0]);
                }
                else
                {
                    if (ds.Tables[0].Rows.Count > 1 && !String.IsNullOrEmpty(this.Nombre.Text))
                    {
                        foreach (DataRow row in ds.Tables[0].Rows)
                        {
                            if (String.Equals(row["clie_nombre"].ToString(), this.Nombre.Text))
                            {
                                this.cargarCliente(row);
                            }
                        }

                    }
                    else
                    {
                        if (ds.Tables[0].Rows.Count > 1 && String.IsNullOrEmpty(this.Nombre.Text))
                        {
                            this.Nombre.BackColor = Color.Red;
                        }

                    }
                }
            }
            catch { }
        }

        private void Codigo_TextChanged(object sender, EventArgs e)
        {
            this.Nombre.BackColor = Color.White;
            this.nombre = this.Nombre.Text;
            if (!String.IsNullOrEmpty(this.Documento.Text) && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    if (String.Equals(row["clie_nombre"].ToString(), this.Nombre.Text))
                    {
                        this.cargarCliente(row);
                    }
                }
            }
        }

        private void comboBoxTipoDoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.comboBoxTipoDoc.BackColor = Color.White;
            this.tipoDocumento = this.comboBoxTipoDoc.Text;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Action<Control.ControlCollection> func = null;
            func = (controls) =>
            {
                foreach (Control control in controls)
                {
                    if (control is TextBox) (control as TextBox).Clear();
                }
            };

            func(Controls);
            this.Calle.Clear();
            this.Nro.Clear();
            this.Piso.Clear();
            this.Dpto.Clear();
            this.Ciudad.Clear();
            this.Pais.Clear();
            this.Telefono.Clear();
            this.dateTimePicker1.Text = Convert.ToDateTime(System.Configuration.ConfigurationManager.AppSettings["fechaSistema"]).AddYears(-18).ToShortDateString();

        }

        private void Calle_TextChanged(object sender, EventArgs e)
        {

        }

        private void Agregar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.Apellido.Text) || string.IsNullOrWhiteSpace(this.Apellido.Text)
                || string.IsNullOrEmpty(this.Nombre.Text) || string.IsNullOrWhiteSpace(this.Nombre.Text)
                || string.IsNullOrEmpty(this.comboBoxTipoDoc.Text) || string.IsNullOrWhiteSpace(this.comboBoxTipoDoc.Text)
                || string.IsNullOrEmpty(this.Documento.Text) || string.IsNullOrWhiteSpace(this.Documento.Text)
                || string.IsNullOrEmpty(this.Calle.Text) || string.IsNullOrWhiteSpace(this.Calle.Text)
                || string.IsNullOrEmpty(this.Nro.Text) || string.IsNullOrWhiteSpace(this.Nro.Text)
                || string.IsNullOrEmpty(this.Ciudad.Text) || string.IsNullOrWhiteSpace(this.Ciudad.Text)
                || string.IsNullOrEmpty(this.Pais.Text) || string.IsNullOrWhiteSpace(this.Pais.Text)
                || string.IsNullOrEmpty(this.Telefono.Text) || string.IsNullOrWhiteSpace(this.Telefono.Text))
            {
                MessageBox.Show("Hay campos necesarios sin completar");
                Action<Control.ControlCollection> func = null;
                func = (controls) =>
                {
                    foreach (Control control in controls)
                    {
                        if (control is TextBox && (string.IsNullOrEmpty(control.Text) || string.IsNullOrWhiteSpace(control.Text))) (control as TextBox).BackColor = Color.Red;
                    }
                };

                func(Controls);
                this.email.BackColor = Color.White;
                if (string.IsNullOrEmpty(this.comboBoxTipoDoc.Text) || string.IsNullOrWhiteSpace(this.comboBoxTipoDoc.Text)) this.comboBoxTipoDoc.BackColor = Color.Red;
                if (string.IsNullOrEmpty(this.Calle.Text) || string.IsNullOrWhiteSpace(this.Calle.Text)) this.Calle.BackColor = Color.Red;
                if (string.IsNullOrEmpty(this.Nro.Text) || string.IsNullOrWhiteSpace(this.Nro.Text)) this.Nro.BackColor = Color.Red;
                if (string.IsNullOrEmpty(this.Calle.Text) || string.IsNullOrWhiteSpace(this.Calle.Text)) this.Calle.BackColor = Color.Red;
                if (string.IsNullOrEmpty(this.Ciudad.Text) || string.IsNullOrWhiteSpace(this.Ciudad.Text)) this.Ciudad.BackColor = Color.Red;
                if (string.IsNullOrEmpty(this.Pais.Text) || string.IsNullOrWhiteSpace(this.Pais.Text)) this.Pais.BackColor = Color.Red;
                if (string.IsNullOrEmpty(this.Telefono.Text) || string.IsNullOrWhiteSpace(this.Telefono.Text)) this.Telefono.BackColor = Color.Red;
            }
            else
            {
                try
                {
                    if (!this.Apellido.Text.ToCharArray().Any(c => char.IsLetter(c)))
                        MessageBox.Show("El apellido admite solo letras");
                    if (!this.Nombre.Text.ToCharArray().Any(c => char.IsLetter(c)))
                        MessageBox.Show("El nombre admite solo letras");

                    ValidacionesHelper.validarCampoSoloTexto(this.Pais);
                    ValidacionesHelper.validarCampoSoloNumerico(this.Documento);
                    ValidacionesHelper.validarCampoSoloNumerico(this.Nro);
                    ValidacionesHelper.validarCampoSoloNumerico(this.Telefono);
                    if (!String.IsNullOrEmpty(this.email.Text))
                        this.validarMail(this.email.Text);
                    if (!String.IsNullOrEmpty(this.Piso.Text))
                        ValidacionesHelper.validarCampoSoloNumerico(this.Piso);
                    this.guardarCliente();
                }
                catch { }
            }
        }

        private void guardarCliente()
        {

            this.documento = Convert.ToInt32(this.Documento.Text);
            ds = dbConnection.executeQuery("SELECT * FROM [GD1C2019].[EYE_OF_THE_TRIGGER].[Cliente] WHERE clie_doc=" + this.documento);
            if (ds.Tables[0].Rows.Count == 1)
            {
                this.actualizarCliente(ds.Tables[0].Rows[0]);
            }
            else
            {
                if (ds.Tables[0].Rows.Count > 1)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        if (String.Equals(row["clie_nombre"].ToString(), this.Nombre.Text))
                        {
                            this.actualizarCliente(row);
                        }
                    }

                }
                else
                {

                    DataSet dsDoc;
                    dsDoc = dbConnection.executeQuery("SELECT * FROM [GD1C2019].[EYE_OF_THE_TRIGGER].[TipoDocumento] WHERE descripcion='" + this.comboBoxTipoDoc.Text + "'");
                    //dsDom = dbConnection.executeQuery("SELECT * FROM [GD1C2019].[EYE_OF_THE_TRIGGER].[Domicilio] WHERE domi_calle=" + this.Calle.Text + " AND domi_nro_calle=" + Convert.ToInt32(this.Nro.Text)+
                    //    " AND domi_piso=" + this.Piso.Text + " AND domi_dpto=" + this.Dpto.Text + " AND domi_ciudad=" + this.Ciudad.Text + " AND domi_pais=" + this.Pais.Text);

                    DBAdapter.insertarDatosEnTabla("cliente", this.Nombre.Text, this.Apellido.Text,
                        Convert.ToInt32(dsDoc.Tables[0].Rows[0]["id"]), Convert.ToInt32(this.Documento.Text),
                        this.Calle.Text, Convert.ToInt32(this.Nro.Text), this.Piso.Text, this.Dpto.Text,
                        this.Ciudad.Text, this.Pais.Text, Convert.ToInt32(this.Telefono.Text), this.email.Text,
                        Convert.ToDateTime(this.dateTimePicker1.Text));
                    MessageBox.Show("Cliente dado de alta");

                }
            }


            this.documento = Convert.ToInt32(this.Documento.Text);
            ds = dbConnection.executeQuery("SELECT * FROM [GD1C2019].[EYE_OF_THE_TRIGGER].[Cliente] WHERE clie_doc=" + this.documento);
            int clie_id = Convert.ToInt32(ds.Tables[0].Rows[0]["clie_id"]);
            this.ClienteId = clie_id;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void actualizarCliente(DataRow row)
        {
            DataSet dsDoc;
            dsDoc = dbConnection.executeQuery("SELECT * FROM [GD1C2019].[EYE_OF_THE_TRIGGER].[TipoDocumento] WHERE descripcion='" + this.comboBoxTipoDoc.Text + "'");

            DBAdapter.actualizarDatosEnTabla("cliente", Convert.ToInt32(row["clie_id"]), this.Nombre.Text, this.Apellido.Text,
                Convert.ToInt32(dsDoc.Tables[0].Rows[0]["id"]), Convert.ToInt32(this.Documento.Text),
                this.Calle.Text, Convert.ToInt32(this.Nro.Text), this.Piso.Text, this.Dpto.Text, this.Ciudad.Text,
                this.Pais.Text, this.Telefono.Text, this.email.Text, Convert.ToDateTime(this.dateTimePicker1.Text));
            MessageBox.Show("Datos cargados correctamente");
        }

        private void validarMail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
            }
            catch
            {
                MessageBox.Show("El correo electronico ingresado no es valido");
            }
        }

        private void Apellido_TextChanged(object sender, EventArgs e)
        {
            this.Apellido.BackColor = Color.White;
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void Calle_TextChanged_1(object sender, EventArgs e)
        {
            this.Calle.BackColor = Color.White;

        }

        private void Nro_TextChanged(object sender, EventArgs e)
        {
            this.Nro.BackColor = Color.White;

        }

        private void Ciudad_TextChanged(object sender, EventArgs e)
        {
            this.Ciudad.BackColor = Color.White;

        }

        private void Pais_TextChanged(object sender, EventArgs e)
        {
            this.Pais.BackColor = Color.White;

        }

        private void Telefono_TextChanged(object sender, EventArgs e)
        {
            this.Telefono.BackColor = Color.White;

        }

        private void email_TextChanged(object sender, EventArgs e)
        {
            this.email.BackColor = Color.White;

        }

        public int ClienteId { get; set; }
    }
}
