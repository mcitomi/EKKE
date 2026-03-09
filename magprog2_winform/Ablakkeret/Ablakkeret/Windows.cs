using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WindowsShop
{
    public class Window
    {
        private static string karakter = "W";
        string pattern = "aábccsddzdzseéfggyhiíjkllymnnyoóöőprsszttyuúüűvzzsAÁBCCSDDZDZSEÉFGGYHIÍJKLLYMNNYOÓÖŐPRSSZTTYUÚÜŰVZZS .-";

        private string megrendelo;
        public string Megrendelo
        {
            get { return megrendelo; }
        }

        private void SETRENDEL(string value)
        {
            foreach (char c in value)
            {
                if (!pattern.Contains(c))
                    throw new Exception("Nem megfelelő a megrendelő formátuma");
            }
            megrendelo = value;
        }

        public int Reteg { get; private set; }
        public int Szel { get; private set; }
        public int Magas { get; private set; }

        public virtual string Kod
        {
            get { return $"{karakter}-{Reteg}-{Szel}-{Magas}"; }
        }

        public Window(string megrendelo, int reteg, int szel, int mag)
        {
            SETRENDEL(megrendelo);
            Reteg = reteg;
            Szel = szel;
            Magas = mag;
        }
    }
}

