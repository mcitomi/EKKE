using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZH2_NAP_APP
{
    public class EpitoCegNemLetezikException : Exception
    {
        static List<string> ismeretlenGyartok = new List<string>();
        public EpitoCegNemLetezikException(string gyarto) : base($"Ismeretlen gyártó: {gyarto}")
        {
            ismeretlenGyartok.Add(gyarto);
        }
    }
    internal class EpitoCeg
    {
        public EpitoCeg(string nev)
        {
            Nev = nev ?? throw new ArgumentNullException(nameof(nev));
        }
        private EpitoCeg(string nev, double ertekeles)
        {
            Nev = nev ?? throw new ArgumentNullException(nameof(nev));
            Ertekeles = ertekeles;
        }

        public string Nev { get; set; }
        public double Ertekeles { get; set; }

        public bool Megbizhato { 
            get
            {
                int i = 0;
                for (i = 0; i < EPITOCEGEK.Count && EPITOCEGEK[i].Nev != Nev; i++) { 

                };

                if(EPITOCEGEK.Count == i)
                {
                    throw new EpitoCegNemLetezikException(Nev);
                }

                return EPITOCEGEK[i].Ertekeles > 4;
            }
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
    }
}
