using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H008
{
    internal class LogaritmikusKereso : GepiJAtekos, IOkosTippelo
    {
        public override int KovetkezoTipp()
        {
            return (alsohatar + felsohatar) / 2;
        }

        public void Kisebb()
        {
            felsohatar = (alsohatar + felsohatar) / 2;
        }

        public void Nagyobb()
        {
            alsohatar = (alsohatar + felsohatar) / 2;
        }
    }
}
