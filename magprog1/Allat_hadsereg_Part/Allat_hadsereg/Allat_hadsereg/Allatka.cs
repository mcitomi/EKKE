
using System;

namespace Allatok
{

   
    class Allatka 
    {
        protected double tarolt_kaja;
        public double Tarolt_kaja
        {
            get { return tarolt_kaja; }
            set
            {
                if (value < 0.0 || value > 100.0)
                    throw new ArgumentException("Csak 0.0-100.0-ig");
                tarolt_kaja = value;
            }
        }
        protected double tarolt_viz;
        public double Tarolt_viz
        {
            get { return tarolt_viz; }
            set
            {
                if (value < 0.0 || value > 100.0)
                    throw new ArgumentException("Csak 0.0-100.0-ig");
                tarolt_viz = value;
            }
        }
        protected bool elajult;
        public bool Elajult
        {
            get { return elajult; }
            set { elajult = value; }
        }
        public void Eszik(double mennyiseg)
        {
            if (elajult) return;
            this.Tarolt_kaja = Math.Min(Tarolt_kaja + mennyiseg, 100);
        }
        public void Iszik(double mennyiseg)
        {
            if (elajult) return;
            this.Tarolt_viz =Math.Min(Tarolt_viz+mennyiseg,100);
        }
        public void Fogyaszt(double kaja, double viz, double km)
        {
            if (Tarolt_kaja - (kaja * km) <= 0.0 || Tarolt_viz - (viz * km) <= 0.0)
            {
                elajult = true;
            }
            if (elajult) return;
            Tarolt_kaja -= (kaja*km);
            Tarolt_viz -= (viz*km);
        }
       
        public override string ToString()
        {
            return $"{GetType().Name}-{Tarolt_viz} vize és {Tarolt_kaja} kajája van";
        }
      

    }
}
