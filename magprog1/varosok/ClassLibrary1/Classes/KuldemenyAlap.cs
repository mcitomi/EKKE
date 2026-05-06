using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using szallitoDll.Exceptions;

namespace szallitoDll.Classes
{
    public abstract class KuldemenyAlap : ICloneable, IComparable
    {
        public Varos Cim { get; set; }
        public int Magassag { get; set; }
        public int Melyseg { get; set; }
        public int Szelesseg { get; set; }
        public int Terfogat { get; set; }

        private float tomeg;

        public float Tomeg
        {
            get { return tomeg; }
            set
            {
                if (value < 0.1)
                {
                    throw new TomegAlacsonyException();
                }
            }
        }

        public abstract float TerfogatSuly
        {
            get;
        }

        public float VeglegesSuly
        {
            get
            {
                return (Tomeg > TerfogatSuly ? Tomeg : TerfogatSuly);
            }
        }

        public bool TerfogatSulyos
        {
            get
            {
                return TerfogatSuly > Tomeg;
            }
        }

        public abstract int KalkulaltAr();


        public int Id { get; set; }

        public override bool Equals(object? obj)
        {
            //kettő Küldemeny akko egyenlő, ha megegyezik az ID
            if (obj is KuldemenyAlap alap)
            {
                return alap.Id == this.Id;
            }

            return false;
        }

        public abstract object Clone();

        public int CompareTo(object? obj)
        {
            if(obj is not KuldemenyAlap)
            {
                throw new Exception("Nem lehet őket összehasonlítani");
            }


            KuldemenyAlap other = obj as KuldemenyAlap;

            return VeglegesSuly.CompareTo(other.VeglegesSuly);
        }
    }
}
