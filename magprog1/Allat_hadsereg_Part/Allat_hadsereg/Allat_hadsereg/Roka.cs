
using System;

namespace Allatok
{
    class Roka : Allatka, IAllatosUj.IAllatokUj
    {
        public override void Uszik(double km)
        {
            Fogyaszt(6, 2, km);
        }
   
    }
}
