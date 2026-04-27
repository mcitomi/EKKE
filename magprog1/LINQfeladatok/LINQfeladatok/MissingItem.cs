using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQfeladatok
{
    internal class MissingItem: InvalidOperationException
    {
        public MissingItem(): base("Missing Item In the Series")
        { }
    }
}
