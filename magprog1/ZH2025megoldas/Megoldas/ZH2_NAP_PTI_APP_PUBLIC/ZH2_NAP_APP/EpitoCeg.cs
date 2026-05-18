using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZH2_NAP_APP
{
    internal class EpitoCeg
    {
     
        public double Ertekeles { get; set; }

        public string Nev { get; set; }
        public EpitoCeg(string nev)
        {
            this.Nev = nev ?? throw new ArgumentNullException(nameof(nev));
        }
        private EpitoCeg(string nev, double ertekeles)
        {
            this.Nev = nev ?? throw new ArgumentNullException(nameof(nev));
            Ertekeles = ertekeles;
        }

       

        public override string ToString()
        {
            return $"{Nev} ({Ertekeles})";
        }

        private static List<EpitoCeg> EPITOCEGEK = new List<EpitoCeg>()
        {
            new EpitoCeg("Luxury Builders", 4.2),
            new EpitoCeg("Eco Homes", 4.6),
            new EpitoCeg("Budget Construction", 3.7),
            new EpitoCeg("Modern Living", 4.1)
        };
      /*  private static Dictionary<string, double> ertekelesek =
            new Dictionary<string, double>()
            {
                {"Modern Living", 4.2},
                {"Eco Homes", 4.6},
                {"CheapBuild", 2.9},
                {"Luxury House Ltd", 4.9}
            };*/


       /* public bool Megbizhato
        {
            get
            {
                if (!ertekelesek.ContainsKey(Nev))
                    throw new EpitoCegNemLetezikException(Nev);

                return ertekelesek[Nev] > 4.0;
            }
        }*/

        public bool Megbizhato
        {
            get
            {
                int i = 0;
                for (i = 0; i < EPITOCEGEK.Count && EPITOCEGEK[i].Nev != Nev; i++) ;
                if (i ==EPITOCEGEK.Count)
                    throw new EpitoCegNemLetezikException(Nev);

                return EPITOCEGEK[i].Ertekeles > 4.0;
            }
        }

    }
}

