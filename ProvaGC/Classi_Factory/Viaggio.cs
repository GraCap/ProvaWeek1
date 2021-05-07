using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvaGC.Classi_Factory
{
    class Viaggio : ICategory
    {
        public decimal Importo;

        public Viaggio(decimal importo)
        {
            Importo = importo;
        }
        public decimal CalcoloRimborso(decimal importo)
        {
            return importo + 50;
        }

        
    }
}
