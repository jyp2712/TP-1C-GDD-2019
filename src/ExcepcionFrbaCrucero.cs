
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrbaCrucero
{
    class ExcepcionFrbaCrucero : Exception
    {
        public ExcepcionFrbaCrucero()
            : base()
        {
        }

        public ExcepcionFrbaCrucero(String message)
            : base(message)
        {
        }
    }


}