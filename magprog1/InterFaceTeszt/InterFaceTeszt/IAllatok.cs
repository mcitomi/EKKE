using System;
using System.Collections.Generic;
using System.Text;

namespace InterFaceTeszt
{
    internal interface IAllatok // kezdjük mar I betűvel az Interfacek nevét
    {
        // csak metodus nevek és konstansok lehetnek, metódus szignaturak
        // privát dolgok ne legyenek mert uyg se lehet elérni

        const int N = 100;

        // ilyent nem szabad:
        public int Add(int a, int b);
      

        // csak ilyeneket:
        public long Multiple(int a, int b);



    }
}
