using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace KoPapirOllo
{
    internal abstract class Jatekos //abstrakt osztály legyen
    {
        // Regex reg = new Regex(@"^[A-Za-z0-9]$");
        Regex reg = new Regex(@"^[\p{L}0-9]+$");    // legalabb 1 szám +jel miatt jelenti \p{L} unicode pl magyar betűk
        // Regex reg = new Regex(@"^[\p{L}][\p{L}0-9]+$");
        // Regex reg = new Regex(@"^[\p{L}0-9]*$");
        // Regex reg = new Regex(@"^[\p{L}][0-9]+$");
        // Regex reg = new Regex(@"^[A-Za-z0-9]+$");
        string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                if(!reg.IsMatch(value))
                {
                    throw new ArgumentException("Nem megfelelő karakter");
                }

                for (int i = 0; i < value.Length; i++)
                {
                    if(!char.IsAsciiLetter(value[i]) && !char.IsDigit(value[i]))
                    {
                        throw new ArgumentException("Nem megfelelő karakter a nevében");
                    }
                }

                this._name = value;
            }
        }

        public abstract EnumLepes Felmutat();
        public abstract bool AkarJatszani();
    }
}
