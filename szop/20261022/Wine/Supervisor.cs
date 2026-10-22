using System;
using System.Collections.Generic;
using System.Text;

namespace Vine
{
    internal class Supervisor
    {
        static readonly List<Wine> buffer = new List<Wine>();
        const int maxSize = 50;

        static int NumberOfProducers = 0;
        static int NumberOfConsumers = 0;

        static bool isProducersStopped = false;
        static bool isConsumersStopped = false;
        


        public static void ConsumerStarts()
        {
            Interlocked.Increment(ref NumberOfConsumers);
        }
        public static void ProducerStarts()
        {
            Interlocked.Increment(ref NumberOfProducers);
        }
        public static void ConsumerStops()
        {
            lock(typeof(Supervisor))
            {
                NumberOfConsumers--;

                if(NumberOfConsumers == 0)
                {
                    isConsumersStopped = true;

                    lock(buffer)
                    {
                        Monitor.PulseAll(buffer);
                    }
                }
            }
        }

        public static void ProducerStops()
        {
            lock(typeof(Supervisor))
            {
                NumberOfProducers--;

                if(NumberOfProducers == 0)
                {
                    isProducersStopped = true;

                    lock(buffer)
                    {
                        Monitor.PulseAll(buffer);
                    }
                }
            }
        }

        public static void AddItem(Wine wine)
        {
            lock(buffer)
            {
                while (buffer.Count == maxSize)
                {
                    if (isConsumersStopped)
                    {
                        throw new Exception("Nincs több Consumer");
                    }

                    Monitor.Wait(buffer);


                }

                buffer.Add(wine);
                Monitor.PulseAll(buffer);
            }
        }

        public static Wine Removeitem(Wine wine)
        {
            lock(buffer)
            {
                while(!buffer.Exists((x) => x == wine))
                {
                    if (isProducersStopped)
                    {
                        throw new Exception("A termelők leálltak");
                    }
                    Monitor.Wait(buffer);
                }

                
                buffer.Remove(wine);
                Monitor.PulseAll(buffer);
            }
            return wine;
        }

        // public static Wine Removeitem(WineType wine)
        // {
        //     Wine temp = new Wine(WineType.Red, 0);
        //     lock(buffer)
        //     {
        //         while(!buffer.Exists((x) => x.winetype == wine))
        //         {
        //             if (isProducersStopped)
        //             {
        //                 throw new Exception("A termelők leálltak");
        //             }
        //             Monitor.Wait(buffer);
        //         }

        //         temp = buffer.Find(x => x.winetype == wine);
        //         buffer.Remove(temp);
        //         Monitor.PulseAll(buffer);
        //     }
        //     return temp;
        //     // return new Wine(WineType.Red, 0);
        // }
    }
}
