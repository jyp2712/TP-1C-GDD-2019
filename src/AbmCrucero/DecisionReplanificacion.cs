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

namespace FrbaCrucero.AbmCrucero
{
    public partial class DecisionReplanificacion : Form
    {
        private string crucero;
        private string cruceroNuevo;
        private string motivo;
        private DateTime fechaReactivacion;
        public bool reemplazoOk { get; set; }

        public DecisionReplanificacion(string crucero, string motivo, DateTime fechaReactivacion)
        {
            this.reemplazoOk = false;
            this.crucero = crucero;
            this.motivo = motivo;
            this.fechaReactivacion = fechaReactivacion;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DBConnection dbConnection = DBConnection.getInstance();
            DataSet ds = dbConnection.executeQuery(QueryProvider.SELECT_VIAJES_REPLANIFICACION(this.crucero, Convert.ToDateTime(System.Configuration.ConfigurationManager.AppSettings["fechaSistema"]).ToString(), this.fechaReactivacion.ToString()));
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                DBAdapter.ejecutarProcedure("baja_viaje_por_crucero", row["viaj_id"], Convert.ToDateTime(System.Configuration.ConfigurationManager.AppSettings["fechaSistema"]));
            }

            MessageBox.Show("Viajes y Reservas canceladas");
            this.reemplazoOk = true;
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DBConnection dbConnection = DBConnection.getInstance();
            DataSet ds = dbConnection.executeQuery(QueryProvider.SELECT_VIAJES_REPLANIFICACION(this.crucero, Convert.ToDateTime(System.Configuration.ConfigurationManager.AppSettings["fechaSistema"]).ToString(), this.fechaReactivacion.ToString()));

            if (string.Equals("Fuera de Servicio", this.motivo))
            {
                CantidadDiasCorrimiento cdc = new CantidadDiasCorrimiento(Convert.ToInt32((this.fechaReactivacion - Convert.ToDateTime(System.Configuration.ConfigurationManager.AppSettings["fechaSistema"])).TotalDays));
                cdc.ShowDialog();
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    DBAdapter.ejecutarProcedure("correr_fecha_reserva", Convert.ToInt32(row["viaj_id"]), cdc.dias);
                }
                MessageBox.Show("Viajes replanificados");
                this.reemplazoOk = true;
            }
            else {
                try
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        DBAdapter.actualizarDatosEnTabla("reemplazar_crucero", this.crucero, Convert.ToInt32(row["viaj_id"]));
                    }
                    MessageBox.Show("Viajes replanificados");
                    this.reemplazoOk = true;
                }
                catch { 
                    MessageBox.Show("No se pueden reemplazar los viajes. Debera dar de alta un crucero nuevo");

                    CruceroAlta car = new CruceroAlta(this.crucero);
                    car.ShowDialog();
                    if (!String.IsNullOrEmpty(car.codigo))
                    {
                        this.cruceroNuevo = car.codigo;
                        DBAdapter.ejecutarProcedure("replicar_cabinas", cruceroNuevo, this.crucero);

                        foreach (DataRow row in ds.Tables[0].Rows)
                        {
                            DBAdapter.ejecutarProcedure("reemplazar_crucero_reserva", cruceroNuevo, row["viaj_id"], this.crucero);
                        }
                        MessageBox.Show("Viajes replanificados");
                        this.reemplazoOk = true;
                    }
                    else {
                        MessageBox.Show("Replanificacion abortada");
                        this.Close();
                    }
                }
            }

            this.Close();
        }
    }
}
