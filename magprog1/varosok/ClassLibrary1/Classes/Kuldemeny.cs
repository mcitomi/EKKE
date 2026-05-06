using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using szallitoDll.Enum;

namespace szallitoDll.Classes
{
    public class Kuldemeny : KuldemenyAlap
    {
        private static int TERFOGATSULY_EGYUTTHATO = 139;
        private static int AR_KILOGRAMMONKENT = 1520;
        private static int EUN_KIVULI_FELAR = 500;
        private static int ALAP_AR = 700;


        public BiztositasTipus BiztositasTipus { get; set; }

        public override float TerfogatSuly
        {
            get
            {
                return Terfogat / TERFOGATSULY_EGYUTTHATO;
            }
        }


        public override object Clone()
        {
            throw new NotImplementedException();
        }

        public override int KalkulaltAr()
        {
            return ALAP_AR + ((int)VeglegesSuly * AR_KILOGRAMMONKENT) +
                (this.Cim.EuTagallam ? EUN_KIVULI_FELAR : 0);
        }
    }
}
