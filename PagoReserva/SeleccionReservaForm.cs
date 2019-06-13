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
using FrbaCrucero.Dominio;

namespace FrbaCrucero.PagoReserva
{
    public partial class SeleccionReservaForm : Form
    {
        public SeleccionReservaForm()
        {
            InitializeComponent();
        }

        private void txtIdReserva_TextChanged(object sender, EventArgs e)
        {
            if(this.txtIdReserva.TextLength>0)
                try
                {
                    Validaciones.ValidacionesHelper.validarCampoSoloNumerico(this.txtIdReserva);
                }
                catch { }
        }

        private void btnIngresarAlPago_Click(object sender, EventArgs e)
        {

                string rese_id = this.txtIdReserva.Text;
                //DataSet ds = DBConnection.getInstance().executeQuery("SELECT * FROM [GD1C2019].[EYE_OF_THE_TRIGGER].[Reserva] JOIN [GD1C2019].[EYE_OF_THE_TRIGGER].Cliente on rese_cliente_id = clie_id JOIN [GD1C2019].[EYE_OF_THE_TRIGGER].Crucero on cruc_id = rese_crucero_id JOIN [GD1C2019].[EYE_OF_THE_TRIGGER].TipoDocumento on clie_tipo_doc = TipoDocumento.id   JOIN [GD1C2019].[EYE_OF_THE_TRIGGER].Domicilio on clie_domicilio_id = domi_id JOIN [GD1C2019].[EYE_OF_THE_TRIGGER].Marca on marc_id = cruc_marca JOIN [GD1C2019].[EYE_OF_THE_TRIGGER].Viaje on rese_viaje_id = viaj_id WHERE rese_id='" + rese_id + "'");
                DataSet ds = DBConnection.getInstance().executeQuery(QueryProvider.SELECT_RESERVA(rese_id));

                if (ds.Tables[0].Rows.Count == 0)
                {
                    MessageBox.Show("La reserva solicitada no existe o se encuentra vencida.");
                }
                else
                {

                    switch (Convert.ToInt32(ds.Tables[0].Rows[0]["rese_estado_reserva"]))
                    {
                        case 4:
                            MessageBox.Show("Reserva cancelada por baja de crucero");
                            break;
                        case 1:
                            MessageBox.Show("Reserva Correcta");
                            break;
                        case 5:
                            MessageBox.Show("Reserva Vencida");
                            break;
                        case 3:
                            //Reserva reserva = new Reserva(ds);
                            Reserva reserva = Mappers.GeneralMapper.deDataSetAReserva(ds);
                            PagoReservaForm formReserva = new PagoReservaForm(reserva);
                            formReserva.Show();
                            this.Hide();
                            break;
                        case 2:
                            MessageBox.Show("Reserva Modificada");
                            break;
                    }


                }

        }
    }
}
