using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace szallitoDll.Classes
{
    internal class SzallitoVallalat
    {
        List<KuldemenyAlap> kuldemenyek = new List<KuldemenyAlap>();

        public void Add(KuldemenyAlap alap)
        {
            if (!kuldemenyek.Contains(alap))
            {
                kuldemenyek.Add(alap);
                kuldemenyek.Sort();
            }

            throw new Exception();
        }

        public void Test()
        {

        }

        public int Test2(int x) => x;

        public List<Kuldemeny> EunKivuliKuldemenyek
        {
            get => (List<Kuldemeny>)kuldemenyek
                .Where(k => !k.Cim.EuTagallam)
                .OrderBy(k => k.Cim.OrszagKod)
                .ThenBy(k => k.Cim.VarosNev)
                .ThenByDescending(k => k.Terfogat)
                .Select(k => k.Clone())
                .Cast<Kuldemeny>()
                .ToList();
        }

        public delegate int KuldemenyEgeszDelegate(KuldemenyAlap x);

        public int Min(KuldemenyEgeszDelegate funk)
        {
            KuldemenyAlap min = new Kuldemeny();

            int legkisebb_eretek = 0;

            foreach (var item in kuldemenyek)
            {
                if(funk(item) < legkisebb_eretek)
                {
                    min = item;
                    legkisebb_eretek = funk(item);
                }
            }

            return legkisebb_eretek;
        }

        private int Terfogat(KuldemenyAlap x)
        {
            return x.Terfogat;
        }

        public int MinTerfogat()
        {
            return Min(Terfogat);
        }

    }
}   
