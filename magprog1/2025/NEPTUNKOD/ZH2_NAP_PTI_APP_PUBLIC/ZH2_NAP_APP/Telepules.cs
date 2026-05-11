using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZH2_NAP_APP
{
    internal class Telepules
    {
        List<Epulet> epuletek = new List<Epulet>();

        public void Regisztral(Epulet e)
        {
            if (epuletek.Contains(e))
            {
                throw new Exception("Ez az épület már létezik a településben");
            }

            epuletek.Add(e);
        }

    }
}
