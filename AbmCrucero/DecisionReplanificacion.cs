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
            DataSet ds = dbConnection.executeQuery(QueryProvider.SELECT_RESERVAS_REPLANIFICACION(crucero, DateTime.Parse(System.Configuration.ConfigurationManager.AppSettings["fechaSistema"]).ToShortDateString(), fechaReactivacion.ToShortDateString()));
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                DBAdapter.ejecutarProcedure("baja_reserva_por_crucero", Convert.ToInt32(row["rese_id"]), Convert.ToDateTime(System.Configuration.ConfigurationManager.AppSettings["fechaSistema"]));
            }
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DBConnection dbConnection = DBConnection.getInstance();
            Console.WriteLine(QueryProvider.SELECT_RESERVAS_REPLANIFICACION(crucero, DateTime.Parse(System.Configuration.ConfigurationManager.AppSettings["fechaSistema"]).ToShortDateString(), fechaReactivacion.ToShortDateString()));
            DataSet ds = dbConnection.executeQuery(QueryProvider.SELECT_RESERVAS_REPLANIFICACION(crucero, DateTime.Parse(System.Configuration.ConfigurationManager.AppSettings["fechaSistema"]).ToShortDateString(), fechaReactivacion.ToShortDateString()));

            if (string.Equals("Fuera de Servicio", this.motivo))
            {
                CantidadDiasCorrimiento cdc = new CantidadDiasCorrimiento(Convert.ToInt32((this.fechaReactivacion - Convert.ToDateTime(System.Configuration.ConfigurationManager.AppSettings["fechaSistema"])).TotalDays));
                cdc.ShowDialog();
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    DBAdapter.ejecutarProcedure("correr_fecha_reserva", Convert.ToInt32(row["rese_id"]), this.crucero, cdc.dias, Convert.ToDateTime(System.Configuration.ConfigurationManager.AppSettings["fechaSistema"]));
                }
                MessageBox.Show("Viajes replanificados");
                this.reemplazoOk = true;
            }
            else {
                try
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        DBAdapter.actualizarDatosEnTabla("reemplazar_crucero", this.crucero, Convert.ToInt32(row["rese_id"]), Convert.ToInt32(row["viaj_id"]), Convert.ToDateTime(row["viaj_fecha_inicio"]), Convert.ToDateTime(row["viaj_fecha_fin_estimada"]));
                    }
                }
                catch { 
                    MessageBox.Show("No se pueden reemplazar todas las reservas. Debera dar de alta un crucero nuevo");

                    CruceroAlta car = new CruceroAlta(this.crucero);
                    car.ShowDialog();
                    if (!String.IsNullOrEmpty(car.codigo))
                    {
                        this.cruceroNuevo = car.codigo;

                        foreach (DataRow row in ds.Tables[0].Rows)
                        {
                            DBAdapter.ejecutarProcedure("reemplazar_crucero_reserva", row["rese_id"], cruceroNuevo, this.crucero);
                        }
                    }
                    else {
                        MessageBox.Show("Replanificacion abortada");
                        this.Close();
                    }
                }
                MessageBox.Show("Viajes replanificados");
                this.reemplazoOk = true;
            }

            this.Close();
        }
    }
}
