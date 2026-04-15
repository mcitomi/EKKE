using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H008
{
    internal class SzamkitalaloJatek
    {
        const int MAX_VERSENYZO = 5;

        Random rnd = new Random();

        ITippelo[] versenyzok = new ITippelo[MAX_VERSENYZO];

        // Az aktualis tombben levo versenyzok szama
        int versenyzoN;

        public void VersenyzoFelvetele(ITippelo versenyzo)
        {
            if (versenyzoN >= MAX_VERSENYZO)
            {
                throw new Exception("Nem lehet több játékso");
            }

            versenyzok[versenyzoN] = versenyzo;
            versenyzoN++;
        }

        int alsoHatar;
        int felsoHaatr;
        int cel;

        public void VersenyIndul()
        {
            cel = rnd.Next(alsoHatar, felsoHaatr + 1);

            for (int i = 0; i < versenyzoN; i++)
            {
                versenyzok[i].JatekIndul(alsoHatar, felsoHaatr);
            }
        }

        public bool MindenkiTippel()
        {
            bool nyertMarValaki = false;

            for (int i = 0; i < versenyzoN; i++)
            {
                int tipp = versenyzok[i].KovetkezoTipp();
                Console.WriteLine($"A {i+1}. jatekos tippje {tipp}");

                if(tipp == cel)
                {
                    versenyzok[i].Nyert();
                }

                if(tipp == cel && !nyertMarValaki)
                {
                    nyertMarValaki=true;
                    // maghivjuk a veszitettet a korabbi jatekosokra
                    for (int j = 0; j < i; j++)
                    {
                        versenyzok[j].Veszitett();
                    }
                }

                // ha mar van nyertes akkor a veszitettete hivjuk meg
                if(tipp != cel && nyertMarValaki)
                {
                    for (int j = 0; j < i; j++)
                    {
                        versenyzok[j].Veszitett();
                    }
                }

                if (versenyzok[i] is IOkosTippelo okos)
                {
                    if(tipp < cel)
                    {
                        okos.Kisebb();
                    }
                    else
                    {
                        okos.Nagyobb();
                    }
                }
            }

            return nyertMarValaki;
        }

        public void Jatek()
        {
            VersenyIndul();
            while (!MindenkiTippel());
        }

        public SzamkitalaloJatek(int alsoHatar, int felsoHatar)
        {
            this.alsoHatar = alsoHatar;
            this.felsoHaatr = felsoHatar;
        }
    }
}
