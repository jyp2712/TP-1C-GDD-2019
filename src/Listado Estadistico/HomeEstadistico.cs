using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaCrucero.DB;
using FrbaCrucero.Forms;

namespace FrbaCrucero.Listado_Estadistico
{
    public partial class HomeEstadistico : Alta
    {
        public HomeEstadistico()
        {
            InitializeComponent();
        }

        private int anio;
        private int semestre;
        private string procedureAEjecutar;
        private Dictionary<int, string> proceduresPorIdFormato = new Dictionary<int, string>();
        private DataTable resultados;

        public HomeEstadistico(FormNavegable owner, int anioIngresado, int semestreElegido)
            : base(owner)
        {
            anio = anioIngresado;
            semestre = semestreElegido;

            proceduresPorIdFormato.Add(0, "top5_recorridos_mas_pasajes_comprados");
            proceduresPorIdFormato.Add(1, "top5_recorridos_mas_cabinas_libres_viaje_realizado");
            proceduresPorIdFormato.Add(2, "top5_cruceros_con_mayor_periodo_inahabilitado");

            InitializeComponent();

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            proceduresPorIdFormato.TryGetValue(comboBox1.SelectedIndex, out procedureAEjecutar);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            resultados = DBAdapter.traerDataTable(procedureAEjecutar, semestre, anio);
            cargarGrilla(dataGridView1, resultados);
        }

        private void Home_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 1;
        }

    }
}
