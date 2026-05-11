using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public interface IOkosotthon
    {
        public int OkosfunkciokSzama
        {
            get;
        }

        public int AutomatizacioSzintje
        {
            get;
        }

        public double Energiamegtakaritas();
    }
}
