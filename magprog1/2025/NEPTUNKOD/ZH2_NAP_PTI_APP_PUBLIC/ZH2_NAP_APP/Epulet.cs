using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZH2_NAP_APP
{
    class TeruletAlacsonyException: Exception
    {
        public TeruletAlacsonyException(string message) : base(message) { }
    }

    class SzobakSzamaNemErvenyesException : Exception
    {
        readonly int rossz_szoba_ertek;
        public SzobakSzamaNemErvenyesException(int szobak) 
        {
            rossz_szoba_ertek = szobak;
        }
    }

    internal abstract class Epulet : ICloneable
    {
        protected Epulet() { }
        protected Epulet(int terulet, int szobak, EpitoCeg epitoCeg, EpuletTipus epuletTipus)
        {
            Terulet = terulet;
            Szobak = szobak;
            EpitoCeg = epitoCeg;
            EpuletTipus = epuletTipus;
        }

        int _terulet;
        int _szobak;
        

        public int Terulet {
            get => _terulet;
            set
            {
                if ( value < 30)
                {
                    throw new TeruletAlacsonyException("A terület kisebb mint 30");
                }

                _terulet = value;
            }
        }
        public int Szobak { 
            get => _szobak; 
            set
            {
                if(value < 1 || value > 15)
                {
                    throw new SzobakSzamaNemErvenyesException(value);
                }

                _szobak = value;
            }
        }
        public EpitoCeg EpitoCeg { get; set; }
        public EpuletTipus EpuletTipus { get; private set; }

        public abstract double KomfortSzint { get; }

        public override bool Equals(object? obj)
        {
            
            if(obj == null) return false;

            if (obj is not Epulet) return false;

            Epulet ce = obj as Epulet;

            return ce.EpitoCeg.Nev == this.EpitoCeg.Nev && ce.EpuletTipus == this.EpuletTipus && ce.Terulet == this.Terulet && ce.KomfortSzint == this.KomfortSzint;
            
        }

        public override string ToString()
        {
            return $"{Terulet} - {Szobak} - {EpitoCeg.Nev} - {EpuletTipus} - {KomfortSzint}";
        }

        public abstract object Clone();
    }
}
