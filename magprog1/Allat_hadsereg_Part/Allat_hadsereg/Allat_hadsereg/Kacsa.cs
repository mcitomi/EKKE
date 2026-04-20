using IAllatosUj;
using System;
using System.Security.Cryptography;

namespace Allatok
{
    class Kacsa : AllatokInterface2.IAllatok
    {
        Random rn = new Random();
        public override void Uszik(double km)
        {
            Fogyaszt(1, 0, km);
            for (int i = 0;i<km;i++)
            {
                Iszik(rn.NextDouble() * 3 + 2);
            }
        }
        public override void Repul(double km)
        {
                Fogyaszt(5, 4,km);
        }
        public override void Fut(double km)
        {
                Fogyaszt(7, 5,km);
        }
        
    }
}
