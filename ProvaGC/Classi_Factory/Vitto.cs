using ProvaGC.Classi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvaGC.Classi_Factory
{
    class Vitto : ICategory
    {
        public decimal Importo;
        public Vitto(decimal importo)
        {
            Importo = importo;
        }
        public decimal CalcoloRimborso(decimal importo)
        {
            return (importo * 70) / 100;
        }
    }
}
