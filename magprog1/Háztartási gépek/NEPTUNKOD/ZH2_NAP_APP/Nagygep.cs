using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZH2_NAP_APP
{
    internal abstract class Nagygep : ICloneable, IComparable
    {
        protected Nagygep(string gyarto, string tipus)
        {
            Gyarto = new Gyarto(gyarto);
            Tipus = tipus ?? throw new ArgumentNullException(nameof(tipus));
        }

        public Gyarto Gyarto { get; set; }
        public string Tipus { get; protected set; }

        public abstract int Relevancia();

        public abstract double Hatekonysag();

        public abstract object Clone();

        public int CompareTo(object? obj)
        {
            if (obj is null) return 1;
            if (obj is not Nagygep) throw new ArgumentException("Nem nagygép");

            Nagygep o = obj as Nagygep;

            
        }

        public override bool Equals(object obj)
        {
            if (obj is null) return false;

            if(obj is not Nagygep) return false;

            Nagygep o = obj as Nagygep;

            return o.Gyarto == this.Gyarto && o.Tipus == this.Tipus;
        }

      



        //public override string ToString()
        //{
        //    return $"{Gyarto} {Tipus}, {Relevancia}, {Hatekonysag() * 100}%";
        //}
    }
}
