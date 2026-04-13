using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06_CoffeeMachine
{ 
    /*
    * common and same methods: non virtual methods with exact algorithm
    * common but different methods: abstract methods
    * optional methods: hook methods -> virtual methods with empty body
    */
    internal abstract class CoffeeBase
    {
        public CoffeeBase()
        {
            HeatTheFibre();
            BoilWater();
            GrindCoffee();
            PourWater();
            AddMilk();
            AddSugar();
            AddExtra();
        }

        public void HeatTheFibre() { Console.WriteLine("Heat the fibre."); }
        public abstract void BoilWater();
        public abstract void GrindCoffee();
        public abstract void PourWater();
        public virtual void AddMilk() { }
        public virtual void AddSugar() { }
        public virtual void AddExtra() { }
    }
}
