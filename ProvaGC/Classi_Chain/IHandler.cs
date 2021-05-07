using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvaGC.Classi_Chain
{
    public interface IHandler
    {
        IHandler SetNext(IHandler handler);
        bool Handle(decimal request);
    }
}
