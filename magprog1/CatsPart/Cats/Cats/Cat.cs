using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Cats
{
    public class Cat : IComparable<Cat>
    {
        Random rn = new Random();
        const string pattern = @"^(Cat|CAT|C[aeiouAEIOU]T)$";
        const string namePattern = @"^{\p}+[A-Za-z]$";
        protected static int ID = 1;
        protected string name;
        protected string chipID;
        protected string colour; //javítani kell, enum legyen!
        protected byte age;
        protected ColourEnum Color;
        Cat mother;
        public Cat Mother
        {
            get { return mother; }
            set
            {

                mother = value;

            }
        }
        public virtual byte Age
        {
            get { return age; }
            set
            {
                if (value < 0 || value > 15)
                {
                    throw new Exception("Ilyen korú nem lehet egy macska");
                }
                age = value;
            }
        }

        public Cat Clone()
        {
            Cat myCat = new Cat();
            myCat.SetName(this.GetName());
            myCat.chipID = this.chipID;
            myCat.colour = this.colour;
            myCat.Mother = this.Mother;
            return myCat;
            // return (Cat)this.MemberwiseClone();
        }



        // public string Name
        // {
        //     get { return name; }
        //     set { name = value; }
        // }

        public string GetName()
        {
            return this.name;
        }
        public void SetName(string value)
        {


            if (!Regex.IsMatch(value, namePattern))
            {
                throw new Exception("Hibás név");
            }

            this.name = value;
        }

        public string ChipID
        {

            get { return chipID; }
            set
            {
                if (value.Substring(0, 3).ToUpper() != "CAT" && !Regex.IsMatch(value, pattern))
                    throw new ArgumentException("ChipID must start with CAT or C.T");
                chipID = value.Substring(0, 3) + ID.ToString();
                ID++;
            }
        }

        public static bool operator <(Cat a, Cat b)  //Mikor kisebb egy macska a másiktól? Összehasonlítás!!
        {
            if (a.Age > b.Age)
                return false;
            else
                if (a.Age < b.Age)
                    return true;
                else
                    if (a.ChipID.CompareTo(b.ChipID) > 0)
                        return false;
                    else return true;
            // return a.ChipID < b.ChipID; Ha long
        }
        public static bool operator >(Cat a, Cat b)  //Static!!! Important!
        {
            if (a.Age > b.Age)
                return true;
            else
                if (a.Age < b.Age)
                    return false;
                else
                    if (a.ChipID.CompareTo(b.ChipID) == -1)
                        return false;
                    else
                        return true;
            //return a.ChipID > b.ChipID;
        }
        public Cat(string p_name, byte p_age, string p_chipId)
        {
            this.SetName(p_name);
            this.age = p_age;
            this.ChipID = p_chipId;
            this.Color = ColourEnum.black;
        }
        public Cat(string p_name, string p_chipId) : this(p_name, 0, p_chipId)
        {
            this.Color = ColourEnum.black;
        }

        public Cat(string p_name, byte p_age, string p_chipId, Cat p_Mother) : this(p_name, p_age, p_chipId)
        {
            this.Mother = p_Mother;
            this.Color = ColourEnum.black;
        }

        public Cat(string p_name, byte p_age, string p_chipId, Cat p_Mother, ColourEnum p_color) : this(p_name, p_age, p_chipId)
        {
            this.Mother = p_Mother;
            this.Color = p_color;
        }

        public Cat() //
        {
        }

        public int CompareTo(Cat m)
        {
            return this.ChipID.CompareTo(m.ChipID);
        }


        public override bool Equals(object obj)  //Az Equals felülírása, megadása!
        {
            if (obj == this)
                return true;
            if (obj == null)
                return false;
            if (obj is Cat)
            {
                Cat objCasted = (Cat)obj;
                return objCasted.ChipID.GetHashCode() == ChipID.GetHashCode();
            }
            else
                return false;
        }
        public override int GetHashCode()
        {
            return this.ChipID.GetHashCode();
            //return HashCode.Combine(this.ChipID.GetHashCode(), this.Name.GetHashCode());
        }

        public override string ToString()
        {
            return "Cat Chip:" + this.ChipID.ToString() + " Cat name:" + this.GetName() + " Age:" + this.Age + " Mother:" + this.Mother;
        }

    }
}
