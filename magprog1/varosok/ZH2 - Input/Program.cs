using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using TesztDll.Class1;
using Allatok;
using System.Threading.Tasks;
using szalllito

namespace ZH2___Input
{
    internal class Program
    {
        static Random rnd = new Random();
    
        static void Main(string[] args)
        {
            Class1 class1 = new Class1();

            StreamWriter sw = new StreamWriter("kuldemenyek.csv");
            for (int i = 0; i < 158; i++)
            {
                int index = rnd.Next(Varos.Varosok.Count);
                if (rnd.NextDouble() < 0.7)
                {
                    sw.WriteLine($"{rnd.Next(1, 10) * 10};{rnd.Next(1, 10) * 10};{rnd.Next(1, 10) * 10};" +
                        $"{rnd.Next(10, 1000) / 100.0};" +
                        $"{Varos.Varosok[index].OrszagKod};{Varos.Varosok[index].VarosNev};" +
                        $"{(BiztositasTipus)rnd.Next(3)}");
                }
                else
                {
                    sw.WriteLine($"{rnd.Next(1, 400)};{rnd.Next(1, 400)};{rnd.Next(1, 30) * 10};" +
                        $"{rnd.Next(10, 3000) / 100.0};" +
                        $"{Varos.Varosok[index].OrszagKod};{Varos.Varosok[index].VarosNev};" +
                        $"{(BiztositasTipus)rnd.Next(3)}");
                }
            }
            sw.Close();            
        }
    }
}
