using ProvaGC.Classi_Chain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvaGC.Classi
{
    class Manager : AbstractHandler
    {

        public override bool Handle(decimal request)
        {
            if (request >= 0 && request <= 400)
            {
                Console.WriteLine($"Spesa Approvata. Livello Manager");
                return approved = true;
            }
                
            else
                return base.Handle(request);
        }
    
    }
}
