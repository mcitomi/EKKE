using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06_CoffeeMachine
{
    internal class Latte : CoffeeBase
    {
        public override void BoilWater()
        {
            Console.WriteLine("Boil 70 ml of water.");
        }

        public override void GrindCoffee()
        {
            Console.WriteLine("Grind semi-smooth 40 grams of coffee.");
        }

        public override void PourWater()
        {
            Console.WriteLine("Pour the boiled water through the grinded coffee in medium pressure.");
        }

        public override void AddMilk()
        {
            Console.WriteLine("Add 80 ml of warm milk.");
        }
    }
}
