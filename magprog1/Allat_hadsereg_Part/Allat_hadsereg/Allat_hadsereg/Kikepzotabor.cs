using System;

namespace Allatok
{
    class Kikepzotabor
    {
        
        public void Hozzaad(Allatka allat)
        {
            allatok.Add(allat);
        }
        public void Torol(Allatka allat)
        {
            allatok.Remove(allat);
        }
        public void Etetes(double kaja)
        {
            double adag = kaja / allatok.Count;
            foreach(var item in allatok)
            {
                item.Eszik(adag);
            }
        }
        public void Itatas(double viz)
        {
            double adag = viz / allatok.Count;
            foreach (var item in allatok)
            {
                item.Iszik(adag);
            }
        }
        public void Futas(double km)
        {
            foreach (var item in allatok)
            {
                item.Fut(km);
            }
            for (int i = 0; i < allatok.Count; i++)
            {
                if (allatok[i].Elajult)
                {
                    Torol(allatok[i]);
                }
            }
        }
        public void Uszas(double km)
        {
            foreach (var item in allatok)
            {
                item.Uszik(km);
            }

            for (int i = 0; i < allatok.Count; i++)
            {
                if (allatok[i].Elajult)
                {
                    Torol(allatok[i]);
                }
            }
        }
        public void Repules(double km)
        {
            foreach (var item in allatok)
            {
                item.Repul(km);
            }
           
        }
        public int Tulelok_szama
        {
            get
            {
                return allatok.Count;
            }
        }
        public List<Allatka> Tulelok
        {
            get
            {
                return allatok;
            }
        }
    }
}
