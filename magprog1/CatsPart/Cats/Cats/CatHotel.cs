using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cats
{
    internal class CatHotel
    {
        // const int N = 10;
        // protected HouseCat[] cats = new HouseCat[N]; 
        //  protected HouseCat[] cats = new HouseCat[N]; // Miért nem jó ez? 
        private List<Cat> cats = new List<Cat>();

        public Cat this[int index]  //Basic indexer 
        {
            get
            {
                if (index < 0 || index > cats.Count)
                    throw new IndexOutOfRangeException();
                return cats[index];
            }
            set
            {
                if (index < 0 || index > cats.Count)
                    throw new IndexOutOfRangeException();
                // cats[index] = value; //
                Cat tempCat = value as Cat; //
                cats[index] = tempCat;//Readonly is better
            }
        }

        public bool Exist(Cat cica)  //
        {
            return cats.Contains(cica);

        }
        public void AddCat(Cat m)
        {
            if (!Exist(m))
                cats.Add(m);//
        }

        public List<Cat> Ordered()
        {
            //Array esetén is menne?
            return cats;
        }
        public List<Cat> GetAllCats()
        {
            return cats;
        }



    }
}
