using ProvaGC.Classi_Chain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvaGC.Classi
{
    class CEO : AbstractHandler
    {

        public override bool Handle(decimal request)
        {
            if (request >= 1000)
            {
                Console.WriteLine($"Spesa Approvata. Livello CEO");
                return approved = true;
            }
                
            else
                return base.Handle(request);
        }
    
    }
}
