using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H008
{
    internal interface IJatekos
    {
        // egy fv van benne amit akkor hívunk ha nyer a jatekos
        // csak fv szignaturát lehet írni
        // védelmi szint + visszater tipus + név + params
        // (minden publikus és virtal az Interfaceben általában alapbol)

        public void Nyert();
        public void Veszitett();
    }
}
