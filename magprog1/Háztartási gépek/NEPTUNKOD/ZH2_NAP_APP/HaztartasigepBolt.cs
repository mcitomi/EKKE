using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZH2_NAP_APP
{
    internal class HaztartasigepBolt
    {
        List<Nagygep> nagygepek = new List<Nagygep>();

        public void Elment(Nagygep obj)
        {
            if(!nagygepek.Contains(obj))
            {
                nagygepek.Add(obj);
            }

            throw new Exception("Ezt a gépet már tartalmazza a lista");
        }


    }
}
