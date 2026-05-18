using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZH2_NAP_APP
{
    internal class GyartoNemTalalhatoException : Exception
    {
        string nemTalaltGyarto;
        public GyartoNemTalalhatoException(string gyartoNeve)
        {
            nemTalaltGyarto = gyartoNeve;
        }
    }

    internal class Gyarto : ICloneable
    {
        public Gyarto(string nev)
        {
            Nev = nev ?? throw new ArgumentNullException(nameof(nev));
        }

        private Gyarto(string nev, bool nepszeru)
        {
            Nev = nev ?? throw new ArgumentNullException(nameof(nev));
            Nepszeru = nepszeru;
        }

        public string Nev { get; set; }

        protected bool nepszeru;
        public bool Nepszeru { 
            get
            {
                foreach (Gyarto gyarto in GYARTOK)
                {
                    if(gyarto.Nev == Nev && gyarto.Nepszeru)
                    {
                        return true;
                    }
                }
                throw new GyartoNemTalalhatoException(Nev);
            } 

            private set
            {
                nepszeru = value;
            }
        }

        private static List<Gyarto> GYARTOK = new List<Gyarto>()
        {
            new Gyarto("Philips", true),
            new Gyarto("AEG", true),
            new Gyarto("Candy", false),
            new Gyarto("LG", true),
            new Gyarto("Phicolo", false),
            new Gyarto("Electrolux", true),
            new Gyarto("Beko", false)
        };

        public override string ToString()
        {
            return Nev;
        }

        public object Clone()
        {
            return new Gyarto(Nev, nepszeru);
        }
    }
}
