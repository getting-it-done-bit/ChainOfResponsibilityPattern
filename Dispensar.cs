using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainOfResponsibilityPattern
{
    public class FiveHunderedNoteDispensar : DispensarBase
    {
        public FiveHunderedNoteDispensar(IDispensar dispensar) 
            :base(dispensar)
        {
        }
        public override void Dispense(int amount) 
        {
            if (amount / 500 > 0) 
            {
                int dispensedFiveHundredNote =  amount / 500;
                Console.WriteLine($"Dispensed 500 Note: {dispensedFiveHundredNote}");
                amount = amount - dispensedFiveHundredNote * 500;
            }

            if (amount > 0) 
            {
                Next?.Dispense(amount);
            }
        }
        
    }

    public class TwoHundredNoteDispensar : DispensarBase 
    {
        public TwoHundredNoteDispensar(IDispensar dispensar)
            :base(dispensar) 
        {
        }
        public override void Dispense(int amount)
        {
            if (amount / 200 > 0)
            {
                int dispensedTwoHundredNote = amount / 200;
                Console.WriteLine($"Dispensed 200 Note: {dispensedTwoHundredNote}");
                amount = amount - dispensedTwoHundredNote * 200;
            }

            if (amount > 0)
            {
                Next?.Dispense(amount);
            }
        }


    }

    public class HundredNoteDispensar : DispensarBase 
    {
        public HundredNoteDispensar() : base(null)
        {
        }

        public override void Dispense(int amount)
        {
            if (amount / 100 > 0)
            {
                int dispensedHundredNote = amount / 100;
                Console.WriteLine($"Dispensed 100 Note: {dispensedHundredNote}");
                amount = amount - dispensedHundredNote * 100;
            }

        }

    }
}
