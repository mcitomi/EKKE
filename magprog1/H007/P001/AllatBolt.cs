using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P001
{
    //konténerosztály
    internal class AllatBolt
    {
        List<Allat> allatok = new List<Allat>();

        public string BoltTulaj { get; set; }

        //hozzáadunk egy alaltot
        public void AddAllat(Allat allat)
        {
            //ha benne van a listában dobjon kivételt

            if (allatok.Contains(allat))
            {
                throw new Exception("Már benne van ez az allat");
            }

            allatok.Add(allat);
        }

        //csak olvasható property
        //visszadja azokat a FarmAllatokat
        //amelyek reggel 10 után kelnek
        public List<FarmAllat> KesoNKeloFarmAllat
        {
            get
            {
                List<FarmAllat> farmAllatok = new List<FarmAllat>();

                foreach (var allat in allatok)
                {
                    if(allat is FarmAllat)
                    {
                        if((allat as FarmAllat).GetKelesOra() > 10)
                        {
                            farmAllatok.Add(allat as FarmAllat);
                        }
                    }
                }

                return farmAllatok;
            }
        }

        // metódus ami összegyűjti és visszadja
        //az adott tulajhoz tartozó állatoakt

        public List<Allat> AdottTulajAllatok(string tulaj)
        {
            List<Allat> tulaj_allatai = new List<Allat>();

            foreach (var allat in allatok)
            {
                if(allat.Tulaj == tulaj)
                {
                    tulaj_allatai.Add(allat);
                }
            }

            return tulaj_allatai;
        }

        //indexelő
        //speciális csak olvasható property
        //a neve mindig this
        //a neve után szögletes zárójelben van egy paraméter lista

        //védelmiszint + visszatérés típusa + this[indexelő paraméter]
        //{ get{}}

        // indexelő, ami azonosító alapján adja vissza az Allatot
        public Allat this[string azonosito]
        {
            get
            {
                foreach (var allat in allatok)
                {
                    if(allat.Azonosito == azonosito)
                    {
                        return allat;
                    }
                }

                throw new IndexOutOfRangeException();
            }
        }


    }
}
