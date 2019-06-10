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
        private string motivo;
        private DateTime fechaReactivacion;

        public DecisionReplanificacion(string crucero, string motivo, DateTime fechaReactivacion)
        {
            this.crucero = crucero;
            this.motivo = motivo;
            this.fechaReactivacion = fechaReactivacion;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DBConnection dbConnection = DBConnection.getInstance();
            DataSet ds = dbConnection.executeQuery(QueryProvider.SELECT_RESERVAS_REPLANIFICACION(crucero));
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                DBAdapter.ejecutarProcedure("baja_reserva_por_crucero", Convert.ToInt32(row["rese_id"]));
            }
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DBConnection dbConnection = DBConnection.getInstance();
            DataSet ds = dbConnection.executeQuery(QueryProvider.SELECT_RESERVAS_REPLANIFICACION(crucero));

            if (string.Equals("Fuera de Servicio", this.motivo))
            {
                CantidadDiasCorrimiento cdc = new CantidadDiasCorrimiento(Convert.ToInt32((this.fechaReactivacion - DateTime.Today).TotalDays));
                cdc.ShowDialog();
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    DBAdapter.ejecutarProcedure("correr_fecha_reserva", Convert.ToInt32(row["rese_id"]), this.fechaReactivacion, this.crucero, cdc.dias);
                }
                MessageBox.Show("Viajes replanificados");
                this.Close();
            }
            else {
                try
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        DBAdapter.ejecutarProcedure("reemplazar_crucero", Convert.ToInt32(row["rese_id"]));
                    }
                }
                catch { 
                    MessageBox.Show("No se pueden reemplazar todas las reservas. Debera dar de alta un crucero nuevos");

                    CruceroAlta car = new CruceroAlta();
                    car.ShowDialog();
                    ds = dbConnection.executeQuery(QueryProvider.SELECT_RESERVAS_REPLANIFICACION(crucero));

                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        DBAdapter.ejecutarProcedure("reemplazar_crucero_reserva", car.codigo);
                    }
                }
            }
        }
    }
}
