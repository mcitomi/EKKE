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
                if(value == 2 || value == 4 || value == 5 || value == 7)
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

        int _extraAr;
        public override int Extraar
        {
            get
            {
                if(Vonohorog)
                {
                    _extraAr += 60000;
                }

                return _extraAr;
            }
        }

        public SzemelygepKocsi(string rendszam, int evjarat, int eredetiar, AllapotEnum allapot, int szallithatodb, bool vonohorog, KlimaTipus klima): base(rendszam, evjarat, eredetiar)
        {
            SzallithatoDb = szallithatodb;
            Vonohorog = vonohorog;
            Klima = klima;
        }

        public SzemelygepKocsi(string rendszam, int evjarat, int eredetiAr, int szallithatodb, bool vonohorog) : this(rendszam, evjarat, eredetiAr, AllapotEnum.Megkimelt, szallithatodb, vonohorog, KlimaTipus.Digitális )
        {

        }
    }
}
