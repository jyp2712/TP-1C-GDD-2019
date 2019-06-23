using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaCrucero.Forms;

namespace FrbaCrucero.Listado_Estadistico
{
    public partial class ListadoEstadistico : Alta
    {
        public ListadoEstadistico()
        {
            InitializeComponent();
        }

        public ListadoEstadistico(FormNavegable owner)
            : base(owner)
        {
            InitializeComponent();
        }

        private string anio;
        private int semestre;


        public void _anio_TextChanged(object sender, EventArgs e)
        {

            anio = _anio.Text;
        }

        public void _semestre_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_semestre.SelectedIndex + 1 != 0)
                semestre = _semestre.SelectedIndex + 1;
        }

        public void _seleccionar_Click(object sender, EventArgs e)
        {
            ExcecuteAndShow(Validar);

        }

        public virtual void Validar()
        {
            ValidarErrores();
            new HomeEstadistico(this, Convert.ToInt32(anio), semestre).FinalStandaloneOpen();
        }

        public override void ValidarErroresConcretos()
        {
            ValidarVaciosYLongitud(new string[] { "Año", "Semestre" }, new object[] { _anio.Text, _semestre.SelectedItem });
            ValidarNumericos(anio);
            try
            {
                if (Convert.ToInt32(anio) < 2010 || Convert.ToInt32(anio) > 2020)
                    errorMessage += "El campo año debe tener un valor comrpendido entre 2010 y 2020\n";
            }
            catch (Exception) { }

        }

        protected override void ExcecuteAndShow(ExceptionableTask task)
        {
            try
            {
                task();
            }
            catch (ExcepcionFrbaCrucero e)
            {
                MessageBox.Show(e.Message, "Error");
                errorMessage += "  ";
            }
            catch (SystemException)
            {
                MessageBox.Show("Ups! error desconocido. Estamos trabajando para solucionarlo");
                errorMessage += "  ";
            }
        }


    }
}
