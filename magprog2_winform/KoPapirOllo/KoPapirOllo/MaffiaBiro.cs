using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoPapirOllo
{
    internal class MaffiaBiro : Biro
    {
        private int beszedett = 0;

        public int Beszedett
        {
            get { return beszedett; }
        }

        public override void Lebonyolit(KinaiJatekos j1, KinaiJatekos j2)
        {
            if (!j1.AkarJatszani() || !j2.AkarJatszani())
                return;

            EnumLepes l1 = j1.Felmutat();
            EnumLepes l2 = j2.Felmutat();

            if (l1 == l2)
            {
                j1.ElveszRizs(1);
                j2.ElveszRizs(1);
                beszedett += 2;
                Console.WriteLine("Döntetlen, maffia beszedett 2 rizst");
                return;
            }

            base.Lebonyolit(j1, j2);
        }
    }
}
