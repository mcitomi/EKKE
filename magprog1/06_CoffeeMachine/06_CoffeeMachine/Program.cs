namespace _06_CoffeeMachine
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CoffeeBase myCoffee = 
                CoffeeMachine.MakeCoffee(CoffeeType.Latte);
        }
    }
}