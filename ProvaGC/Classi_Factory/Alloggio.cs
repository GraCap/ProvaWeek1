using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvaGC.Classi_Factory
{
    class Alloggio : ICategory
    {
        public decimal Importo;

        public Alloggio(decimal importo)
        {
            Importo = importo;
        }
        public decimal CalcoloRimborso(decimal importo)
        {
            return importo;
        }
    }
}
