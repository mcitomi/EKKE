using System;
using System.Collections.Generic;
using System.Text;

namespace Vine
{
    internal class Producer
    {
        Wine wine;
        ConsoleColor colour;
        int Quantity;
        int Worktime;
        public Producer(Wine WineType, ConsoleColor colour, int quantity, int worktime)
        {
            this.colour = colour;
            this.wine = WineType;
            this.Worktime = worktime;
            this.Quantity = quantity;
        }
        public void Work()
        {
            Supervisor.ProducerStarts();

            for (int i = 0; i < Quantity; i++)
            {
                if(wine.winetype == WineType.Red)
                {
                    Thread.Sleep(Worktime * 2000);
                } else
                {
                    Thread.Sleep(Worktime * 1000);
                }

                Supervisor.AddItem(new Wine(this.wine.winetype, i));

                Console.ForegroundColor = this.colour;
                Console.WriteLine($"Új bor létrehozva #{i}");

            }

            Supervisor.ProducerStops();
        }

    }
}
