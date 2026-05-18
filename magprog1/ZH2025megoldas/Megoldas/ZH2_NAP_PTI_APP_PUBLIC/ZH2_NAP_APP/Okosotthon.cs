using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interface;

namespace ZH2_NAP_APP
{
    internal class Okosotthon : Epulet, Interface.IOkosotthon
    {
        private List<OkosFunkcio> okosFunkciok = new List<OkosFunkcio>();

        private Okosotthon()
        {
        }

        public Okosotthon(EpitoCeg epitoCeg,double terulet, int szobak, List<OkosFunkcio> okosFunkciok)
            : base(epitoCeg, EpuletTipus.CsaladiHaz, terulet, szobak)
        {
            this.okosFunkciok = okosFunkciok;
        }

        public int OkosfunkciokSzama
        {
            get
            {
                return okosFunkciok.Distinct().Count();
            }
        }

        public double AutomatizacioSzintje
        {
            get
            {
                return OkosfunkciokSzama / 6.0 * 100;
            }
        }

        public double Energiamegtakaritas()
        {
            int db = okosFunkciok.Count(x => x != OkosFunkcio.Kamera && x != OkosFunkcio.Multimedia);

            return db / Math.Abs(100 - Terulet);
        }

        public override double KomfortSzint
        {
            get
            {
                return AutomatizacioSzintje * Energiamegtakaritas() / 5.0;
            }
        }

        public override object Clone()
        {
            Okosotthon clone = new Okosotthon();

            clone.EpitoCeg = new EpitoCeg(this.EpitoCeg.Nev);

            clone.EpuletTipus = this.EpuletTipus;
            clone.Terulet = this.Terulet;
            clone.Szobak = this.Szobak;

            clone.okosFunkciok = new List<OkosFunkcio>(this.okosFunkciok);

            return clone;
        }

        public override string ToString()
        {
            return base.ToString() +  $" Okosfunkciók száma: {OkosfunkciokSzama}" + $" Automatizáció: {AutomatizacioSzintje:F2}" +
                   $" Energiamegtakarítás: {Energiamegtakaritas():F2}";
        }
        public Okosotthon(List<string> okosFunkciok): base()
        {
            foreach (string okosfunkcio in okosFunkciok)
            {
                this.okosFunkciok.Add((OkosFunkcio)Enum.Parse(typeof(OkosFunkcio), okosfunkcio));
            }
        }

        
    }
}
