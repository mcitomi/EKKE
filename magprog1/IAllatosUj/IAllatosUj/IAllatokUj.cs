using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IAllatosUj
{
    public interface IAllatokUj
    {
        void Eszik(double mennyiseg);
        void Iszik(double mennyiseg);
        void Fut(double km);
        void Repul(double km);
        void Uszik(double km);
    }
}
