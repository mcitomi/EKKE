using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace KoPapirOllo
{
    internal class KinaiJatekos : Jatekos
    {
        protected int rizsMenny;
        protected readonly int rizsKezd;
        protected int mohosag;
        protected static Random rnd = new Random();

        public int RizsMenny
        {
            get { return rizsMenny; } //Ez nem jó! Jó, az!
        }

        public int RizsKezd
        {
            get { return rizsKezd; } //Ez sem jó!
            // set { rizsKezd = value; } <-- readonly nem kaphat értéket csak konstruktorbol
        }

        public int Mohosag
        {
            get { return mohosag; } //Ez sem jó!
            set
            {
                if (value < 2 || value > 10)
                {
                    throw new Exception("Nem jó érték (2-10)");
                }

                this.mohosag = value;
            }
        }

        public KinaiJatekos(string nev, int mohosag, int kezdoRizs)
        {
            if (kezdoRizs < 0 || kezdoRizs > 100)
            {
                throw new Exception("A kezedti rizs nem ok! (0-100)");
            }

            this.Name = nev;
            this.Mohosag = mohosag;
            this.rizsKezd = kezdoRizs;  // nincs setter, ezert meghivjuk a mezőt
            this.rizsMenny = kezdoRizs;
        }

        public KinaiJatekos(string nev, int mohosag) : this(nev, mohosag, 5)
        {

        }

        public override bool AkarJatszani()
        {
            if (rizsMenny < 3)
                return false;

            if (rizsMenny >= rizsKezd * mohosag)
                return false;

            return true;
        }

        public override EnumLepes Felmutat()
        {
            int r = rnd.Next(3);
            return (EnumLepes)r;
        }

        public void HozzaadRizs(int mennyiseg)
        {
            rizsMenny += mennyiseg;
        }

        public void ElveszRizs(int mennyiseg)
        {
            rizsMenny -= mennyiseg;
        }

        public override string ToString()
        {
            return $"Név: {this.Name}, Rizs: {this.rizsMenny}, Mohóság: {this.mohosag}";
        }

        /*
        * Kellene a két operátor!
        * */

        public static bool operator <(KinaiJatekos k1, KinaiJatekos k2)
        {
            if (k1.RizsMenny < k2.RizsMenny)
            {
                return true;
            }

            return false;
        }

        public static bool operator >(KinaiJatekos k1, KinaiJatekos k2)
        {
            if (k1.RizsMenny > k2.RizsMenny)
            {
                return true;
            }

            return false;
        }
    }
}
