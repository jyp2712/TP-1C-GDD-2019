﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaCrucero.Validaciones
{
    class ValidacionesHelper
    {

        private static void validarCampo(TextBox textBox, string regex, string mensajeError) 
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(textBox.Text, regex))
            {
                MessageBox.Show(mensajeError);
                textBox.Text = textBox.Text.Remove(textBox.Text.Length - 1);
            }   
        }

        public static void validarCampoSoloTexto(TextBox textBox)
        {
            validarCampo(textBox, "^[a-zA-Z ]+$", "Este campo admite solo texto.");
        }

        public static void validarCampoSoloNumerico(TextBox textBox)
        {
            validarCampo(textBox, "^[0-9]+$", "Este campo admite solo numeros");
        }
    }
}
