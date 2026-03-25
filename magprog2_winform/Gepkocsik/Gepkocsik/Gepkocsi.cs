using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Gepkocsik
{
    public class Gepkocsi
    {
        private string rendszam;
        public string Rendszam { 
            get { return rendszam;}
            private set
            {
                if(string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Nem lehet üres rendszám");
                }

                string pattern = @"[A-Z]{3}-[0-9]{3}";

                Regex regex = new Regex(pattern);

                if(!regex.IsMatch(value))
                {
                    throw new Exception("A rendszám nem megfelelő");
                }

                if (value[0] == '0' && value[5] == '0' && value[6] ==  '0')
                {
                    throw new Exception("Nem lehet csupa 0 a rendszám");
                }

                rendszam = value;
            }
        }
        
        int _evjarat;
        public int Evjarat { 
            get { return _evjarat; }
            set
            {
                if(value < 1950 || value > 2022)
                {
                    throw new ArgumentException("Nem valós intervallum");
                }

                _evjarat = value;
            }
        }

        int _eredetiAr;
        bool isEdited = false;
        public int EredetiAr { 
            get
            {
                return _eredetiAr;
            }
            set
            {
                if(value < 300_000 || value > 12_000_000)
                {
                    throw new Exception("Nem megfelelő értékű az ár");
                }

                if(isEdited)
                {
                    throw new Exception("Az eredeti ár csak 1x adható meg");
                }

                _eredetiAr = value;
                isEdited = true;
            }
        }

        int _kor;
        public int Kor { 
            get
            {
                return DateTime.Now.Year - Evjarat;
            }
        }

        int _extraar;
        public virtual int Extraar {
            get
            {
                if (Kor <= 2 && Allapot == AllapotEnum.Ujszeru)
                {
                    return EredetiAr = EredetiAr + (int)(EredetiAr * 0.02);
                }

                return 0;
            }
        }

        public AllapotEnum Allapot;

        public Gepkocsi(string rendszam, int evjarat, int eredetiAr, AllapotEnum allapot)
        {
            Rendszam = rendszam;
            Evjarat = evjarat;
            EredetiAr = eredetiAr;
            Allapot = allapot;
        }

        public Gepkocsi(string r, int e, int ar) : this(r, e, ar, AllapotEnum.Megkimelt)
        {

        }
    }
}
