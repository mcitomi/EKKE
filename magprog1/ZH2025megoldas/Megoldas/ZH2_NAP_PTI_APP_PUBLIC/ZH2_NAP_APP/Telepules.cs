using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZH2_NAP_APP
{
    delegate double OkosotthonDelegate(Okosotthon o); //A feladat int-et kér, de nem vágom, h miért?
    // Olyan függvényre mutathat, ami: kap egy Okosotthon objektumot, visszaad egy int értéket. Lásd lent.
    //pl. int Szobaszam(Okosotthon o)
    //{
     //   return o.Szobak;
    //}
    //De miért int? Szerintem "sajtóhiba"...

class Telepules : IEnumerable<Epulet>
    {
        private List<Epulet> epuletek =  new List<Epulet>();

        public void Regisztral(Epulet epulet)
        {
            if (epuletek.Contains(epulet))
                throw new Exception("Az épület már szerepel!");

            epuletek.Add(epulet);

            epuletek.Sort(); //Tudja rendezni! public int CompareTo(Epulet other) miatt! tavalyi anyag...:-))
        }

        public List<Epulet> ModernLivingAltalEpitett100M2FolottiEpuletek2 //Kell ehhez lista? IEnumerable<Epulet>
        {
            get
            {
                return epuletek.Where(x => x.EpitoCeg.Nev == "Modern Living" && x.Terulet > 100).ToList();
            }
        }
        //Nem, nem kell hozzá!:-))
        public IEnumerable<Epulet> ModernLivingAltalEpitett100M2FolottiEpuletek //A különbség az, hogy nincs ToList() :-))
        {
            get
            {
                return epuletek.Where(x => x.EpitoCeg.Nev == "Modern Living" && x.Terulet > 100);
                    
            }
        }


        public List<Epulet> MegbizhatoCegAltalEpitettEpuletek2  //Ez is menne IEnumerable<Epulet> megoldással, ugye? IEnumerable<Epulet> implementáció miatt
        {
            get
            {
                return epuletek.Where(x => x.EpitoCeg.Megbizhato)
                    .ToList();
            }
        }

        public IEnumerable<Epulet> MegbizhatoCegAltalEpitettEpuletek  //Ez is menne IEnumerable<Epulet> megoldással, ugye? IEnumerable<Epulet> implementáció miatt
        {
            get
            {
                return epuletek.Where(x => x.EpitoCeg.Megbizhato); // Lambda nélkül yield kellene... 
            }
        }

        public List<Okosotthon> OtLegkomfortosabbOkosotthon120m2FolottAmitEcoHomesEpitett
        {
            get
            {
                return epuletek.OfType<Okosotthon>().Where(x =>x.EpitoCeg.Nev == "Eco Homes" && x.Terulet >= 120)
                    .OrderByDescending(x => x.KomfortSzint).Take(5).ToList();
            }
        }

        public double Atlag(OkosotthonDelegate func)  //Funct menne?
        {
            List<Okosotthon> lista = epuletek.OfType<Okosotthon>().ToList();
            //Az OfType: Visszaadja az epuletek listából azokat az elemeket, amelyek Okosotthon típusúak.
            //Így nem kell "is"-élni!:-)) 
            if (!lista.Any()) //Nehogy kivételt dobjon nekem...
                return 0;
            //return epuletek.OfType<Okosotthon>().Average(x => func(x)); //Kicsit elbonyolítva. 

            return lista.Average(x => func(x)); //Itt a függvényhívás. A func által mutatott függvényt hívja. Pl. Szobaszam(x)
            //double atlag = telepules.Atlag(x => x.Szobak); helyett
            //x => x.Szobak. Az Átlag metódust nem kell 3x megírni (AtlagTerulet, AtlagSzobaszam, AtlagKomfort)
            //Atlag(x => x.Szobak) , Atlag(x => x.OkosfunkciokSzama), Atlag(x => (int)x.KomfortSzint). Egy elég
        }

        //!! Vegyük észre, hogy a fenti és a lenti teljesen ugyanaz. Ezt abból látni, hogy ha alul az Atlag2-ből törlöm a 2-est, akkor a
        ///Program.cs-ben nem tudja, hogy melyik Atlag metódust hívja meg!:-)) Azt mondja, hogy nem egyértelmű <summary>
        /// Program.cs-ben nem tudja, hogy melyik Atlag metódust hívja meg!:-)) Azt mondja, hogy nem egyértelmű
        public double Atlag2(Func<Okosotthon, double> func) // int-et akar, de double-t írok. 
        {
            return epuletek
                .OfType<Okosotthon>()
                .Average(x => func(x));
        }
        //És ha nem ismerem az OfType-ot? Nem is tanultuk... Akkor íme:
        public double Atlag3(Func<Okosotthon, double> func) // int-et akar, de double-t írok. 
        {
            List<Okosotthon> lista = new List<Okosotthon>();
            foreach (Epulet item in epuletek)
                if (item is Okosotthon)
                    lista.Add(item as Okosotthon);
            return lista.Average(x => func(x));
        }

        

        public IEnumerator<Epulet> GetEnumerator()
        {
            foreach (Epulet e in epuletek)
            {
                yield return (Epulet)e.Clone();
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
