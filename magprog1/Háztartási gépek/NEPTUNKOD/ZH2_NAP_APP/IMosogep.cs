using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZH2_NAP_APP
{
    internal interface IMosogep
    {
        public int MaxToltotomeg
        {
            get;
        }

        public int MaxFordulat
        {
            get;
        }

        public double VizFelhasznalas(MosogepProgram param1, double tomeg);


    }
}
