using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZH2_NAP_APP
{
    class EpitoCegNemLetezikException : Exception
    {
        public string CegNev { get; }

        public EpitoCegNemLetezikException(string cegNev)
            : base($"A következő építőcég nem létezik: {cegNev}")
        {
            CegNev = cegNev;
        }
    }
    class TeruletAlacsonyException : Exception
    {
        public TeruletAlacsonyException()
            : base("A terület nem lehet kisebb, mint 30!")
        {
        }
    }

    class SzobakSzamaNemErvenyesException : Exception
    {
        public int RosszErtek { get; }

        public SzobakSzamaNemErvenyesException(int rosszErtek)
            : base($"Érvénytelen szobaszám: {rosszErtek}")
        {
            RosszErtek = rosszErtek;
        }
    }
}
