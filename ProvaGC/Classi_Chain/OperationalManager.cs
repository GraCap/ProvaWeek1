using ProvaGC.Classi_Chain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvaGC.Classi
{
    class OperationalManager : AbstractHandler
    {

        public override bool Handle(decimal request)
        {
            if (request >= 401 && request <= 1000)
            {
                Console.WriteLine($"Spesa Approvata. Livello Operational Manager");
                return approved = true;
            }
                
            else
                return base.Handle(request);
        }
    
    
    }
}
