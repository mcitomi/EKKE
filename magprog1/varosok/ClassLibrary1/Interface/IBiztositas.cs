using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using szallitoDll.Enum;

namespace szallitoDll.Interface
{
    public interface IBiztositas
    {
        int Biztositas(int ertek);
        BiztositasTipus BiztositasTipus { get; set; }
    }
}
