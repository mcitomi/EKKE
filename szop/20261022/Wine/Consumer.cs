using System;
using System.Collections.Generic;
using System.Text;

namespace Vine
{
    internal class Consumer
    {
        Wine wine;
        ConsoleColor colour;
        public Consumer(Wine WineType, ConsoleColor colour)
        {
            this.colour = colour;
            this.wine = WineType;

        }
        public void Consume(object o)
        {
            Supervisor.ConsumerStarts();

            while (true)
            {
                try
                {
                    Wine temp = Supervisor.Removeitem(this.wine);

                    lock (typeof(Program))
                    {
                        Console.ForegroundColor = this.colour;
                        Console.WriteLine($"Egy fogyasztó elvett egy {wine.winetype} bort");
                    }

                }
                catch (System.Exception)
                {
                    Console.WriteLine("A fogyasztók leálltak");
                    break;
                }
            }

            Supervisor.ConsumerStops();
        }

    }
}
