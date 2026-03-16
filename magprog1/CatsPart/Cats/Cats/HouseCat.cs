using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cats
{
    internal class HouseCat : Cat
    {
        int weight;
        public int Weight //javítani kell
        {
            get { return weight; }
            set { weight = value; }
        }
        public override byte Age
        {
            get { return age; }
            set
            {
                if (value < 0 || value > 20)
                {
                    throw new Exception("Ilyen korú nem lehet egy macska");
                }
                age = value;
            }
        }
        public HouseCat(string p_name, byte p_age, string p_chipId, int weight) : base(p_name, p_age, p_chipId)
        {
            this.Weight = weight;
        }

        public HouseCat(Cat other, int weight) : base(other.GetName(), other.Age, other.ChipID)
        {
            this.Weight = weight;
            this.Mother = other.Mother;
        }
        //Kell még egy konstruktor

        public override string ToString()
        {
            return base.ToString() + $"{this.Weight}";
        }

        public HouseCat() : base()
        {
        }


    }
}
