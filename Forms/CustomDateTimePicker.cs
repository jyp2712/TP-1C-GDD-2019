using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrbaCrucero.Forms
{
    public class CustomDateTimePicker:System.Windows.Forms.DateTimePicker
    {
        public CustomDateTimePicker()
            : base()
        {
            if(MinDate<DateTime.Now && DateTime.Now<MaxDate)
                this.Value = DateTime.Now;
        }

    }
}
