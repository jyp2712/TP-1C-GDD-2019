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

namespace FrbaCrucero.AbmCliente
{
    public partial class ClienteHome : Form
    {
        DataSet ds;
        private String nombre { get; set; }
        private int documento { get; set; }
        private int tipoDocumento  { get; set; }

        public ClienteHome()
        {
            this.tipoDocumento = 1;
            InitializeComponent();
        }

        private void ClienteHome_Load(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                this.documento = Convert.ToInt32(this.Documento.Text);
                DBConnection dbConnection = DBConnection.getInstance();
                ds = dbConnection.executeQuery("SELECT * FROM [GD1C2019].[EYE_OF_THE_TRIGGER].[Cliente] WHERE clie_doc=" + this.documento);
                if (ds.Tables[0].Rows.Count == 1)
                {
                    DataSet dsDoc, dsDom;
                    this.Apellido.Text = ds.Tables[0].Rows[0]["clie_apellido"].ToString();
                    this.Nombre.Text = ds.Tables[0].Rows[0]["clie_nombre"].ToString();
                    dsDoc = dbConnection.executeQuery("SELECT * FROM [GD1C2019].[EYE_OF_THE_TRIGGER].[TipoDocumento] WHERE id=" + ds.Tables[0].Rows[0]["clie_tipo_doc"].ToString());
                    this.comboBoxTipoDoc.Text = dsDoc.Tables[0].Rows[0]["descripcion"].ToString();
                    this.dateTimePicker1.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["clie_fecha_nac"].ToString()).ToShortDateString();
                    this.email.Text = ds.Tables[0].Rows[0]["clie_mail"].ToString();
                    this.Telefono.Text = ds.Tables[0].Rows[0]["clie_tel"].ToString();

                    dsDom = dbConnection.executeQuery("SELECT * FROM [GD1C2019].[EYE_OF_THE_TRIGGER].[Domicilio] WHERE domi_id=" + ds.Tables[0].Rows[0]["clie_domicilio_id"].ToString());
                    this.Calle.Text = dsDom.Tables[0].Rows[0]["domi_calle"].ToString();
                    this.Nro.Text = dsDom.Tables[0].Rows[0]["domi_nro_calle"].ToString();
                    this.Piso.Text = dsDom.Tables[0].Rows[0]["domi_piso"].ToString();
                    this.Dpto.Text = dsDom.Tables[0].Rows[0]["domi_dpto"].ToString();
                    this.Ciudad.Text = dsDom.Tables[0].Rows[0]["domi_ciudad"].ToString();
                    this.Pais.Text = dsDom.Tables[0].Rows[0]["domi_pais"].ToString();

                }
                else
                {
                    if (ds.Tables[0].Rows.Count > 1 && !String.IsNullOrEmpty(this.Nombre.Text))
                    {
                        foreach(DataRow row in ds.Tables[0].Rows){
                            if (String.Equals(ds.Tables[0].Rows[0]["clie_nombre"].ToString(), this.Nombre.Text))
                            {
                                DataSet dsDoc, dsDom;
                                this.Apellido.Text = ds.Tables[0].Rows[0]["clie_apellido"].ToString();
                                dsDoc = dbConnection.executeQuery("SELECT * FROM [GD1C2019].[EYE_OF_THE_TRIGGER].[TipoDocumento] WHERE id=" + ds.Tables[0].Rows[0]["clie_tipo_doc"].ToString());
                                this.comboBoxTipoDoc.Text = dsDoc.Tables[0].Rows[0]["descripcion"].ToString();
                                this.dateTimePicker1.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["clie_fecha_nac"].ToString()).ToShortDateString();
                                this.email.Text = ds.Tables[0].Rows[0]["clie_mail"].ToString();
                                this.Telefono.Text = ds.Tables[0].Rows[0]["clie_tel"].ToString();

                                dsDom = dbConnection.executeQuery("SELECT * FROM [GD1C2019].[EYE_OF_THE_TRIGGER].[Domicilio] WHERE domi_id=" + ds.Tables[0].Rows[0]["clie_domicilio_id"].ToString());
                                this.Calle.Text = dsDom.Tables[0].Rows[0]["domi_calle"].ToString();
                                this.Nro.Text = dsDom.Tables[0].Rows[0]["domi_nro_calle"].ToString();
                                this.Piso.Text = dsDom.Tables[0].Rows[0]["domi_piso"].ToString();
                                this.Dpto.Text = dsDom.Tables[0].Rows[0]["domi_dpto"].ToString();
                                this.Ciudad.Text = dsDom.Tables[0].Rows[0]["domi_ciudad"].ToString();
                                this.Pais.Text = dsDom.Tables[0].Rows[0]["domi_pais"].ToString();
                            }
                        }

                    }
                }
            }
            catch { }
        }

        private void Codigo_TextChanged(object sender, EventArgs e)
        {
            this.nombre = this.Nombre.Text;
        }

        private void comboBoxTipoDoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.tipoDocumento = Convert.ToInt32(this.comboBoxTipoDoc.Text);
        }
    }
}
