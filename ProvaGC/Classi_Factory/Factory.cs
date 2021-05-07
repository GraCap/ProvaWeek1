using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvaGC.Classi_Factory
{
    class Factory
    {
        public static ICategory FactoryFunction(string categoria, decimal importo)
        {
            ICategory category = null;

            if (categoria == "Viaggio")
                category = new Viaggio(importo);
            else if (categoria == "Alloggio")
                category = new Alloggio(importo);
            else if (categoria == "Vitto")
                category = new Vitto(importo);
            else if (categoria == "Altro")
                category = new Altro(importo);
            else
                return category;

            return category;
        }
    }
}
