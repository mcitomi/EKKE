using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H008
{
    internal abstract class GepiJAtekos : ITippelo
    {
        protected int alsohatar;
        protected int felsohatar;
        int nyertDB;
        int veszitettDB;
        // nem lehet abstrakt osztalyt inicialni, de van kontrutkora

        public void JatekIndul(int alsohater, int felsohatar)
        {
            this.alsohatar = alsohater;
            this.felsohatar = felsohatar;
        }

        // abstrakt fuggveny: nincs kifejtve, szemben a virtual metodussal
        // abstrakt metodus egyben virtualis is
        public abstract int KovetkezoTipp();

        public void Nyert()
        {
            throw new NotImplementedException();
        }

        public void Veszitett()
        {
            throw new NotImplementedException();
        }
    }
}
