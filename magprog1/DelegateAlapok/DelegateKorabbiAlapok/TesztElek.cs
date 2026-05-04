using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateKorabbiAlapok
{
    internal class TesztElek
    {
        public static int Matek1(int i)
        {
            return i * i;
        }

        public int Matek2(int i)
        {
            return 2 * i;
        }

        //2. rész

        public int Matek3(int i)
        {
            return 3 * i;
        }

        public void Matek_alap(int i)
        {
            Console.WriteLine(i);
        }

        public void Matek_alap2(int i)
        {
            Console.WriteLine(2 * i);
            Console.WriteLine(Matek2(i));
        }


    }
}
