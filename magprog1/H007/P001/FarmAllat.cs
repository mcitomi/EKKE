using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P001
{
    internal class FarmAllat : Allat
    {

        int kelesOra;

        //set és get metódust
        //Kívülről nem módosítható
        //az értéke csak a [1-24] intervallumban érvényes
        public int GetKelesOra()
        {
            return kelesOra;
        }
        private void setKelesOra(int value)
        {
            if (value < 1 || 24 < value)
                throw new Exception("A keles óra csak vlódi óra lehet");

            kelesOra = value;
        }

        public override int Veszely
        {
            get
            {
                return 1;
            }
        }

        public FarmAllat(string azonosito, string tulaj, Faj faj, bool biztonsagos, int kelesOra):
            base(azonosito, tulaj,faj,biztonsagos)
        {
            setKelesOra(kelesOra);
        }

        public FarmAllat(string azonosito, string tulaj, Faj faj) :
            this(azonosito, tulaj, faj, false, 6)
        {
        }

        public override float Ar()
        {
            float alapAr = base.Ar();

            //ha 6 előtt kel akkor extra 3000 ft
            //ha 10 után akkor extra 2000 Ft + 10 % növelés
            // különben nem változik

            if (kelesOra < 6)
                alapAr += 3000;
            else if(kelesOra > 10)
            {
                alapAr += 2000;
                alapAr *= 1.1f;
            }

            return alapAr;
        }

        public override string ToString()
        {
            return base.ToString() + "Keles óra: " + $"{GetKelesOra()}";
        }
    }
}
