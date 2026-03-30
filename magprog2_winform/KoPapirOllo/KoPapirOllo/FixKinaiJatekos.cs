using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoPapirOllo
{
    internal class FixKinaiJatekos : KinaiJatekos
    {
        private readonly EnumLepes fixErtek;

        public EnumLepes FixErtek
        {
            get { return fixErtek; }
        }

        public FixKinaiJatekos(string nev, int mohosag, int kezdoRizs, EnumLepes fix) : base(nev, mohosag, kezdoRizs)
        {
            this.fixErtek = fix;
        }

        public FixKinaiJatekos(string nev, int mohosag, EnumLepes fix) : base(nev, mohosag)
        {
            this.fixErtek = fix;
        }

        public override EnumLepes Felmutat()
        {
            return fixErtek;
        }
    }
}
