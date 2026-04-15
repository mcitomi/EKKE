using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H008
{
    internal class VeletelenTippelo : GepiJAtekos
    {
        static Random rnd = new Random();
        public override int KovetkezoTipp()
        {
            return rnd.Next(alsohatar, felsohatar + 1);
        }
    }
}
