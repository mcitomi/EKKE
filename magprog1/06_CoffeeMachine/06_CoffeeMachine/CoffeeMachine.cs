using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06_CoffeeMachine
{
    public enum CoffeeType { Esspresso, Latte }
    internal class CoffeeMachine
    {
        public static CoffeeBase MakeCoffee(CoffeeType coffeeType)
        {
            switch (coffeeType)
            {
                case CoffeeType.Esspresso: return new Esspresso();
                case CoffeeType.Latte: return new Latte();
                default: throw new Exception();
            }
        }
    }
}
