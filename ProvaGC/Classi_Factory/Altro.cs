using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvaGC.Classi_Factory
{
    class Altro : ICategory
    {
        public decimal Importo;

        public Altro(decimal importo)
        {
            Importo = importo;
        }
        public decimal CalcoloRimborso(decimal importo)
        {
            return (importo * 10) / 100;
        }
    }
}
