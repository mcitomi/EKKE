using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H008
{
    internal class BejaroTippelo : GepiJAtekos
    {
        int aktualisTipp;

        public override void JatekIndul(int alsohataer, int felsohatar)
        {

        }

        public override int KovetkezoTipp()
        {
            return aktualisTipp++;
        }
    }
}
