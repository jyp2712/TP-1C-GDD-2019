using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaCrucero
{
    class ABMHelper
    {
        public static void addButtonToDataGridView(DataGridView dgv, string headerText, string buttonText)
        {

            DataGridViewButtonColumn button = new DataGridViewButtonColumn();
            {
                button.Name = "button";
                button.HeaderText = headerText;
                button.Text = buttonText;
                button.UseColumnTextForButtonValue = true;
                dgv.Columns.Add(button);
            }
        }

    }
}
