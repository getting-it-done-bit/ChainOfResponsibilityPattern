using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainOfResponsibilityPattern
{
    public abstract class DispensarBase : IDispensar
    {
        protected readonly IDispensar? Next;

        protected DispensarBase(IDispensar? dispensar) 
        {
            Next = dispensar;
        }

        public abstract void Dispense(int amount);
    }
}
