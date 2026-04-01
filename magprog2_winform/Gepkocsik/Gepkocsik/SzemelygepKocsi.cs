using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gepkocsik
{
    internal class SzemelygepKocsi : Gepkocsi
    {
        int _szallithatoDb;
        public int SzallithatoDb
        {
            get { return _szallithatoDb; }
            set
            {
                if (value == 2 || value == 4 || value == 5 || value == 7)
                {
                    _szallithatoDb = value;
                    return;
                }

                throw new Exception("Nem fegfelelő darabszám");
            }
        }

        KlimaTipus _klima;
        public KlimaTipus Klima
        {
            get
            {
                return _klima;
            }
            set
            {
                _klima = value;
            }
        }

        public bool Vonohorog { get; set; }
        // Ez ugyan az mint amit a klímánál csinaltunk, a háttérben a privat valtozot is létrehozza, ellenőrzés nélküli megoldás.

        public override int Extraar
        {
            get
            {
                int alap_extra = base.Extraar;

                // ha van horog +60k
                // ha van 7 szemely +100k
                // klima fajtai még plus

                int extra_plus = 0;

                if (Vonohorog)
                {
                    extra_plus += 60_000;
                }

                if (SzallithatoDb == 7)
                {
                    extra_plus += 100_000;
                }

                switch (Klima)
                {
                    case KlimaTipus.Manuális:
                        extra_plus += 40_000;
                        break;

                    case KlimaTipus.Digitális:
                        extra_plus += 150_000;
                        break;

                    case KlimaTipus.Digitális_Többzónás:
                        extra_plus += 350_000;
                        break;

                    default:
                        break;
                }


                return extra_plus + alap_extra;
            }
        }

        public SzemelygepKocsi(string rendszam, int evjarat, int eredetiar, AllapotEnum allapot, int szallithatodb, bool vonohorog, KlimaTipus klima) : base(rendszam, evjarat, eredetiar)
        {
            SzallithatoDb = szallithatodb;
            Vonohorog = vonohorog;
            Klima = klima;
        }

        public SzemelygepKocsi(string rendszam, int evjarat, int eredetiAr, int szallithatodb, bool vonohorog) : this(rendszam, evjarat, eredetiAr, AllapotEnum.Megkimelt, szallithatodb, vonohorog, KlimaTipus.Digitális)
        {

        }


        public override int Vetelar()
        {
            float amortizacio = 0;
            // ha 7 szemelyes akkor 1.2x olyan gyorsan amortizalodik

            if (Allapot == AllapotEnum.Ujszeru)
            {
                amortizacio = 0.08f;
            }
            if (Allapot == AllapotEnum.Megkimelt)
            {
                amortizacio = 0.09f;
            }
            if (Allapot == AllapotEnum.Serult)
            {
                amortizacio = 0.12f;
            }
            if (Allapot == AllapotEnum.Hibas)
            {
                amortizacio = 0.13f;
            }

            if (SzallithatoDb == 7)
            {
                amortizacio *= 1.2f;
            }

            return (int)(EredetiAr * Math.Pow(amortizacio, Kor)) + Extraar;
        }

        public override string ToString()
        {
            return $"{Rendszam} - {Evjarat} - {EredetiAr} Ft - {Allapot} - {Kor} - {Extraar} Ft - {Vetelar()} Ft - {SzallithatoDb} - " +( Vonohorog ? "Vonóhorgos" : "Nincs vonóhorog") + $" - {Klima}";
        }
    }
}
