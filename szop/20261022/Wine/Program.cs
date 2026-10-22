using Vine;

public enum WineType
{
    Red,
    White
};
internal class Program
{
    private static void Main(string[] args)
    {
        List<ConsoleColor> Randomcolors = new List<ConsoleColor> { ConsoleColor.Red, ConsoleColor.White, ConsoleColor.Yellow };
        Random random = new Random();

        

        Console.ReadKey();

    }
}