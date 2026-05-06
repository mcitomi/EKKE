using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using szallitoDll.Exceptions;

namespace szallitoDll.Classes
{
    public class Varos : ICloneable
    {
        private Varos(string orszagKod, string varos)
        {
            OrszagKod = orszagKod;
            VarosNev = varos;
        }
        public string OrszagKod { get; set; }
        public string VarosNev { get; set; }

        private static List<Varos> varosok = new List<Varos>()
        {
                new Varos( "H", "Budapest" ),
                new Varos( "H", "Debrecen" ),
                new Varos( "H", "Miskolc" ),
                new Varos( "EST", "Tallin" ),
                new Varos( "VN", "Hanoi" ),
                new Varos( "VN", "Pleiku" ),
                new Varos( "RO", "Bukarest" ),
                new Varos( "SK", "Donovali" ),
                new Varos( "SK", "Sahy" ),
                new Varos( "ARM", "Yerevan" ),
                new Varos( "SYR", "Damaskus" ),
                new Varos( "F", "Lyon" ),
                new Varos( "F", "Paris" )
        };

        public static List<Varos> Varosok { get { return new List<Varos>(varosok); } }

        public bool EuTagallam
        {
            get
            {
                foreach (var varos in Varosok)
                {
                    if (varos.OrszagKod == OrszagKod) {
                        return true;
                    }
                }

                throw new NemTalalhatoOrszagKodException(OrszagKod);
            }
        }

        public object Clone()
        {
            return new Varos(OrszagKod, VarosNev);
        }
    }
}
