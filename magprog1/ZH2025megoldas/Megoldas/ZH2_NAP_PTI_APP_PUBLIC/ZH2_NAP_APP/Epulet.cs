using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZH2_NAP_APP
{
    internal abstract class Epulet : ICloneable, IComparable<Epulet>
    {
        protected Epulet() { }
        protected Epulet(int terulet, int szobak, EpitoCeg epitoCeg, EpuletTipus epuletTipus)
        {
            Terulet = terulet;
            Szobak = szobak;
            EpitoCeg = epitoCeg;
            EpuletTipus = epuletTipus;
        }

        private double _terulet;
        private int _szobak;

        public EpitoCeg EpitoCeg { get; set; }

        public EpuletTipus EpuletTipus { get; set; }

        public double Terulet
        {
            get { return _terulet; }
            set
            {
                if (value < 30)
                    throw new TeruletAlacsonyException();

                _terulet = value;
            }
        }

        public int Szobak
        {
            get { return _szobak; }
            set
            {
                if (value < 1 || value > 15)
                    throw new SzobakSzamaNemErvenyesException(value);

                _szobak = value;
            }
        }

        public abstract double KomfortSzint { get; }

        protected Epulet(EpitoCeg epitoCeg,EpuletTipus epuletTipus, double terulet,int szobak)
        {
            EpitoCeg = epitoCeg;
            EpuletTipus = epuletTipus;
            Terulet = terulet;
            Szobak = szobak;
        }

        public abstract object Clone();

        public int CompareTo(Epulet other)
        {
            if (this.KomfortSzint > other.KomfortSzint)
                return 1;

            if (this.KomfortSzint < other.KomfortSzint)
                return -1;

            return this.Terulet.CompareTo(other.Terulet);
        }

        public override bool Equals(object obj)  //HashCode? :-((
        {
            if (obj == null || !(obj is Epulet))
                return false;

            Epulet other = (Epulet)obj;

            return this.EpitoCeg.Nev == other.EpitoCeg.Nev
                && this.EpuletTipus == other.EpuletTipus
                && this.Terulet == other.Terulet
                && this.KomfortSzint == other.KomfortSzint;
        }

        public override string ToString()
        {
            return $"Építőcég: {EpitoCeg}, " +
                   $"Típus: {EpuletTipus}, " +
                   $"Terület: {Terulet}, " +
                   $"Szobák: {Szobak}, " +
                   $"Komfortszint: {KomfortSzint:F2}";
        }
    }
}
