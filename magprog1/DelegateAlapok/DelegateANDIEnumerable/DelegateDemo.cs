using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateANDIEnumerable
{
    delegate int Modosito(int bemenet);


    internal class DelegateDemo
    {
        private int[] _tomb;

        public DelegateDemo()  //ez egy konstruktor, aki nem ismerné fel!:-))
        {
            _tomb = new int[] { 1, 2, 3, 4, 5 };
        }

        public IEnumerator GetEnumerator()
        {
            return _tomb.GetEnumerator(); //Ezt tudják, hogy mi???
        }
        //A négyzetre mutat rá, majd a duplazra!!
        public void Modosit(Modosito modosito)  //a paraméter egy delegate
        {
            if (modosito == null) return; // hibavédelem

            for (int i = 0; i < _tomb.Length; i++)  //Ez az érdekes
            {
                _tomb[i] = modosito(_tomb[i]); //meghívunk egy függvényt (amire a módosító mutat), persze más-más paraméterrel
            }

        }
    }
}
