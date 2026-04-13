using AllatInterface;
using System;

namespace Allatok
{
    class Sas
    {
        public override void Repul(double km)
        {
            Fogyaszt(0.5, 0.5, km);
        }
        public override void Fut(double km)
        {
            Fogyaszt(5, 3, km);
        }
        public override void Uszik(double km)
        {}
        public Sas(double kaja, double viz)
            : base(kaja, viz) { }
    }
}
