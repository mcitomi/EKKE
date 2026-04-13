using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06_CoffeeMachine
{
    internal class Esspresso : CoffeeBase
    {
        public override void BoilWater()
        {
            Console.WriteLine("Boil 40 ml of water.");
        }

        public override void GrindCoffee()
        {
            Console.WriteLine("Grind very smooth 50 grams of coffee.");
        }

        public override void PourWater()
        {
            Console.WriteLine("Pour the boiled water through the grinded coffee in high pressure.");
        }
    }
}
