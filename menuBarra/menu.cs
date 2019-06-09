using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaCrucero.menuBarra
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
            this.abm.Visible = false;
            this.estadistica.Visible = false;
            this.generarViaje.Visible = false;
        }

        public Menu(String user)
        {
            InitializeComponent();
            this.abm.Visible = false;
            this.abmCrucero.Visible = false;
            this.abmRecorrido.Visible = false;
            this.abmRol.Visible = false;
            this.estadistica.Visible = false;
            this.generarViaje.Visible = false;
            DataTable funcionalidades = new DataTable();
            funcionalidades = DB.DBAdapter.traerDataTable("funcionalidades",user);
            for (int i = 0; i < funcionalidades.Rows.Count; i++)
            {
                if (funcionalidades.Rows[i][0].Equals("Administrar Roles"))
                {
                    this.abm.Visible = true;
                    this.abmRol.Visible = true;
                }
                if (funcionalidades.Rows[i][0].Equals("Administrar Recorridos"))
                {
                    this.abm.Visible = true;
                    this.abmRecorrido.Visible = true;
                }
                if (funcionalidades.Rows[i][0].Equals("Administrar Cruceros"))
                {
                    this.abm.Visible = true;
                    this.abmCrucero.Visible = true;
                }
                if (funcionalidades.Rows[i][0].Equals("Administrar Viajes"))
                {
                    this.generarViaje.Visible = true;
                }

                if (funcionalidades.Rows[i][0].Equals("Listado Estadistico"))
                {
                    this.estadistica.Visible = true;
                }
             }
        }

        private void toolStripTextBox2_Click(object sender, EventArgs e)
        {
            FrbaCrucero.CompraPasaje.Form1 compra = new CompraPasaje.Form1();
            compra.Show();
        }

        private void toolStripTextBox1_Click(object sender, EventArgs e)
        {
            FrbaCrucero.GeneracionViaje.ViajeAlta viaje = new GeneracionViaje.ViajeAlta();
            viaje.Show();
        }

        private void abmRol_Click(object sender, EventArgs e)
        {
            FrbaCrucero.AbmRol.RolForm rol = new AbmRol.RolForm();
            rol.Show();
        }

        private void abmRecorrido_Click(object sender, EventArgs e)
        {
            FrbaCrucero.AbmRecorrido.RecorridoHome recorrido = new AbmRecorrido.RecorridoHome();
            recorrido.Show();
        }

        private void pagoReserva_Click(object sender, EventArgs e)
        {
            FrbaCrucero.PagoReserva.SeleccionReservaForm pago = new PagoReserva.SeleccionReservaForm();
            pago.Show();
        }

        private void abmCrucero_Click(object sender, EventArgs e)
        {
            FrbaCrucero.AbmCrucero.Form1 crucero = new AbmCrucero.Form1();
            crucero.Show();
        }

        private void estadistica_Click(object sender, EventArgs e)
        {
            FrbaCrucero.Listado_Estadistico.ListadoEstadistico estadistica = new Listado_Estadistico.ListadoEstadistico();
            estadistica.Show();
        }
    }
}
