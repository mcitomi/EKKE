using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H008
{
    internal interface ITippelo : IJatekos
    {
        void JatekIndul(int alsohater, int felsohatar);
        int KovetkezoTipp();
    }
}
