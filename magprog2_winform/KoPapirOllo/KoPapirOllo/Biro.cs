using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoPapirOllo
{
    internal class Biro
    {
        public virtual void Lebonyolit(KinaiJatekos j1, KinaiJatekos j2)
        {
            if (!j1.AkarJatszani() || !j2.AkarJatszani())
                return;

            EnumLepes l1 = j1.Felmutat();
            EnumLepes l2 = j2.Felmutat();

            Console.WriteLine(j1.Nev + " mutatja: " + l1);
            Console.WriteLine(j2.Nev + " mutatja: " + l2);

            if (l1 == l2)
            {
                Console.WriteLine("Döntetlen");
                return;
            }

            bool j1Nyert =
                (l1 == EnumLepes.Ko && l2 == EnumLepes.Ollo) ||
                (l1 == EnumLepes.Papir && l2 == EnumLepes.Ko) ||
                (l1 == EnumLepes.Ollo && l2 == EnumLepes.Papir);

            if (j1Nyert)
            {
                j1.HozzaadRizs(3);
                j2.ElveszRizs(3);
                Console.WriteLine(j1.Nev + " nyert!");
            }
            else
            {
                j2.HozzaadRizs(3);
                j1.ElveszRizs(3);
                Console.WriteLine(j2.Nev + " nyert!");
            }
        }
    }
}
