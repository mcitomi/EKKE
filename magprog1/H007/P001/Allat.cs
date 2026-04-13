using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace P001
{
    internal class Allat
    {


        //Azonosito Csak Angol ABC nagybetui
        // - tartalmazhat
        // de nem lehet benne 2 - egymás után
        //osztályon kívül nem módosítható

        //properoty sztintaxis
        //védelmi szint visszatérés típusa név
        // get és set ág
        string azonosito;
        public string Azonosito
        {
            get
            {
                return azonosito;
            }
            private set
            {
                string pattern = @"[A-Za-z0-9-]";
                Regex regex = new Regex(pattern);

                if (!regex.IsMatch(value))
                {
                    throw new Exception("Nem megfelelő karaktert tartalmaz");
                }

                //ha van hossz megkötés
                //legfeljebb 5 hosszú
                if(value.Length > 5)
                {
                    throw new Exception("A hossz túl hosszú");
                }

                // a - nem szerepel egymás után 2szer
                if (value.Contains("--"))
                {
                    throw new Exception("A - nem szereplhet egymás után 2-szer");
                }

                //Az utolsó karakter nem lehet -
                if (value.Last() == '-')
                {
                    throw new Exception("Az utolsó karakter nem lehet -");
                }

                azonosito = value;

            }
        }

        //tulaj - kivűlról nem módosítható
        // a tulaj egy nem üres string legalább 5 karakter
        // és betűt, zóközt, pontot, kötőjelet tartalmazhat
        string tulaj;
        public string Tulaj
        {
            get { return tulaj; }
            private set
            {
                if (value.Length < 5)
                {
                    throw new Exception("Túl rövid a tulaj neve");
                }
                string pattern = @"[a-zA-Z-\s\.]";

                Regex regex = new Regex(pattern);
                if (!regex.IsMatch(value))
                {
                    throw new Exception("Nem megfelelő karakterekt használ");
                }

                tulaj = value;
            }

        }

        public Faj Faj { get; set; }

        //biztonságos-e 
        //logikai, csak egyszer állítható be

        bool biztonsagos;
        int counter = 0;
        public bool Biztonsagos
        {
            get { return biztonsagos; }
            set
            {
                if(counter > 0)
                {
                    throw new Exception("Nem lehet többször beállítani");
                }

                counter++;
                biztonsagos = value;
            }
        }

        // csak olvasható porperty
        // alkalmazozon késői kötést
        public virtual int Veszely
        {
            get
            {
                int result = biztonsagos ? 1 : 0;

                switch (Faj)
                {
                    case Faj.Emlos:
                        return result * 2;
                        break;
                    case Faj.Madar:
                        return result * 1;
                        break;
                    case Faj.Hal:
                        return 0;
                        break;
                    case Faj.Bogar:
                        return result * 3;
                        break;
                    case Faj.Hullo:
                        return result * 1;
                        break;
                    case Faj.Rovar:
                        return result * 1;
                        break;
                    default:
                        throw new Exception();
                        break;
                }
            }
        }

        public Allat(string azonosito, string tulaj, Faj faj, bool biztonsagos)
        {
            this.Azonosito = azonosito;
            this.Tulaj = tulaj;
            Faj = faj;
            this.Biztonsagos = biztonsagos;
        }

        public Allat(string azonosito, string tulaj, Faj faj) :
           this(azonosito, tulaj, faj, false)
        {
        }

        public virtual float Ar()
        {
            float alapAr = 500;

            switch (Faj)
            {
                case Faj.Emlos:
                    alapAr += 500;
                    break;
                case Faj.Madar:
                    alapAr += 1000;
                    break;
                case Faj.Hal:
                    alapAr += 1500;
                    break;
                case Faj.Bogar:
                    alapAr -= 200;
                    break;
                case Faj.Hullo:
                    alapAr *= 1.03f; //3% növekedés van
                    break;
                case Faj.Rovar:
                    alapAr -= 400;
                    break;
                default:
                    break;
            }

            return alapAr;
        }

        public override string ToString()
        {
            return $"{Faj.ToString()} ";
        }

        public override bool Equals(object? obj)
        {
            //elnneőrizzük, hogy obj null-e
            if (obj == null)
                return false;
            //obj Allat-e
            if (obj is not Allat) // is: példány rendelkezik-e ezzel
                                    //típussal
                return false;

            Allat other = obj as Allat; //as: típus kényszerítés

            if (other.azonosito == this.azonosito)
                return true;

            return false;

        }
    }
}
