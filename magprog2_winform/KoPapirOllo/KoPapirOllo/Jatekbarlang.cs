using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoPapirOllo
{
    internal class Jatekbarlang
    {
       //Kellene két lista. jLista és bLista néven!;
       List<KinaiJatekos> jLista = new List<KinaiJatekos>();
       List<Biro> bLista = new List<Biro>();

        private int maxJ;
        private int maxB;

        private Random rnd = new Random();

        public Jatekbarlang(int maxJ, int maxB)
        {
            this.maxJ = maxJ;
            this.maxB = maxB;
        }

        public void HozzaadJatekos(KinaiJatekos j)
        {
            if (jLista.Count < maxJ) 
                jLista.Add(j);
        }

        public void HozzaadBiro(Biro b)
        {
            if (bLista.Count < maxB)
                bLista.Add(b);
        }

       

        public void Lebonyolit()
        {
            if (jLista.Count < 2 || bLista.Count == 0)
                return;

            Biro b = bLista[rnd.Next(bLista.Count)];
            KinaiJatekos j1 = jLista[rnd.Next(jLista.Count)];
            KinaiJatekos j2 = jLista[rnd.Next(jLista.Count)];

            if (j1 == j2)
                return;

            Console.WriteLine("---- Játék ----");
            b.Lebonyolit(j1, j2);
        }

        public List<KinaiJatekos> GetJatekosok()
        {
            return jLista;
        }

        public List<Biro> GetBirok()
        {
            return bLista;
        }

        public KinaiJatekos this[string nev] {
            get
            {
                foreach (KinaiJatekos j in jLista)
                {
                    if (j.Name == nev)
                    {
                        return j;
                    }
                }

                throw new Exception("Nincs ilyen játékos!");
            }
        }
    }
}
