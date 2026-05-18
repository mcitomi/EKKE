using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZH2_NAP_APP
{
    class NagyMaximalisToltotomegException: Exception
    {
        public NagyMaximalisToltotomegException()
        {
            
        }
    }

    class MaximalisFordulatszamNemErvenyesException : Exception
    {
        public MaximalisFordulatszamNemErvenyesException()
        {
            
        }
    }
    internal class Mosogep : Nagygep, IMosogep
    {
        int _maxtoltotomeg;
        int _maxfordulat;
        public int MaxToltotomeg
        {
            get 
            {
                return this._maxtoltotomeg;
            }

            private set
            {

                if(value < 5)
                {
                    throw new Exception("A megadott érték kisebb mint 5");
                }

                if(value > 11)
                {
                    throw new NagyMaximalisToltotomegException();
                }

                this._maxtoltotomeg = value;
            }
            
        }

        public int MaxFordulat
        {
            get
            {
                return this._maxfordulat;
            }
            private set
            {
                if(value % 100 != 0)
                {
                    throw new MaximalisFordulatszamNemErvenyesException();
                }

                if (value > 1400 || value < 800)
                {
                    throw new Exception("A fordulatszám 800 és 1400 közé kell hogy essen");
                }

                this._maxfordulat = value;
            }
        }

        public double VizFelhasznalas(MosogepProgram param1, double tomeg)
        {
            if(tomeg > MaxToltotomeg)
            {
                throw new NagyMaximalisToltotomegException();
            }

            if(param1 == MosogepProgram.GYAPJU)
            {
                return  tomeg / 2;
            }

            if(param1 == MosogepProgram.ECO)
            {
                return tomeg / 3;
            }

            if(param1 == MosogepProgram.EXTRA)
            {
                return tomeg / 1.5;
            }

            if(param1 == MosogepProgram.CENTRIFUGA)
            {
                return 0;
            }
            return 0;
        }

        public Mosogep(string gyarto, string tipus, int maxFordulat, int maxToltott) : base(gyarto, tipus)
        {
           this.MaxFordulat = maxFordulat;
           this.MaxToltotomeg = maxToltott;
        }

        public override double Hatekonysag()
        {
            return (this.MaxToltotomeg * this.MaxFordulat) / 15400;
        }

        public override int Relevancia()
        {
            return (int)Math.Floor(((Hatekonysag() - 0.26) / 0.74) * 10);
        }
        public object Clone()
        {
            Mosogep obj = new Mosogep(this.Gyarto.ToString(), this.Tipus, this.MaxFordulat, this.MaxToltotomeg);

            return obj;
        }
    }
}
