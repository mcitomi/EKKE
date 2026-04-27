using System.Collections;
using System.IO;
using System.Security.Cryptography.X509Certificates;

class Bike: IEnumerable
{
    private string[] _markak;

    public Bike()
    {
        _markak = new string[] { "Trek", "Specialized", "Bianchi", "Merida" };
    }

    public IEnumerator GetEnumerator()
    {
        return _markak.GetEnumerator();
    }
}

   


internal class Program
{
    private static void Main(string[] args)
    {
        Bike bike = new Bike();
        foreach (string tag in bike)
        {
            Console.WriteLine(tag);
        }
        Console.ReadKey();


    }
}