using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H008
{
    internal interface IOkosTippelo : ITippelo
    {
        void Kisebb();
        void Nagyobb();
    }
}
