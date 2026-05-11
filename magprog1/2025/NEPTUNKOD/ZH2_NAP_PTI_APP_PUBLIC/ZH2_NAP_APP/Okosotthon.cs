using ClassLibrary1;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZH2_NAP_APP
{
    internal class Okosotthon : Epulet, IOkosotthon
    {
        private Okosotthon() : base() 
        {

        }
        
        public Okosotthon(List<string> okosFunkciok, int terulet, int szobak, EpitoCeg epitoCeg) 
            : base(terulet, szobak, epitoCeg, EpuletTipus.CsaladiHaz)
        {
            foreach (string okosfunkcio in okosFunkciok)
            {
                this.okosFunkciok.Add((OkosFunkcio)Enum.Parse(typeof(OkosFunkcio), okosfunkcio));
            }
        }

        private List<OkosFunkcio> okosFunkciok = new List<OkosFunkcio>();

        public override double KomfortSzint
        {
            get
            {
                return ((AutomatizacioSzintje * Energiamegtakaritas()) / 5);
            }
        }

        public int OkosfunkciokSzama
        {
            
            get
            {
                List<OkosFunkcio> temp = new List<OkosFunkcio>();

                foreach (OkosFunkcio o in okosFunkciok)
                {
                    if(!temp.Contains(o))
                    {
                        temp.Add(o);
                    }
                }

                return temp.Count;
            }
        }

        public int AutomatizacioSzintje
        {
            get
            {
                return ((OkosfunkciokSzama / 6) * 100);
            }
        }

        public override object Clone()
        {
            Okosotthon o = new Okosotthon();
            
            // ???

            return o; 
        }

        public double Energiamegtakaritas()
        {
            int n = 0;

            foreach (var item in okosFunkciok)
            {
                if(item != OkosFunkcio.Kamera || item != OkosFunkcio.Multimedia)
                {
                    n++;
                }
            }

            return (n / Math.Abs(100 - Terulet));
        }


    }
}
