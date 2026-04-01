namespace Gepkocsik
{
    internal class Kereskedes
    {
        public List<Gepkocsi> gepkocsik = new List<Gepkocsi>();

        // prop ami vissadja  aSzemelygepkocsikat
        public List<SzemelygepKocsi> SzemelygepKocsiLista
        {
            get
            {
                List<SzemelygepKocsi> szemelygepkocsik = new List<SzemelygepKocsi>();

                foreach (Gepkocsi kocsi in gepkocsik)
                {
                    if (kocsi is SzemelygepKocsi)
                    {
                        szemelygepkocsik.Add(kocsi as SzemelygepKocsi);
                    }

                }

                return szemelygepkocsik;
            }
        }

        // legolcsobb megkimelt szemely gepkocsi

        public SzemelygepKocsi LegolcsobbMegkimeltSzemelygepKocsi
        {
            get
            {
                List<SzemelygepKocsi> szemelygepkocsik = SzemelygepKocsiLista;

                SzemelygepKocsi LMSZGK = null;

                if(szemelygepkocsik.Count > 0)
                {
                    LMSZGK = szemelygepkocsik[0];
                }
                else
                {
                    throw new Exception("Nincs Szemelygepkocsi a kereskefesben");
                }

                foreach (SzemelygepKocsi kocsi in szemelygepkocsik)
                {
                    if (kocsi.Allapot == AllapotEnum.Megkimelt && kocsi.Vetelar() < LMSZGK.Vetelar())
                    {
                        LMSZGK = kocsi;
                    }
                }

                return LMSZGK;
            }
        }

        // indexelő rendszam alapjan

        public Gepkocsi this[string rendszam]
        {
            get
            {
                foreach (Gepkocsi kocsi in gepkocsik)
                {
                    if(kocsi.Rendszam == rendszam)
                    {
                        return kocsi;
                    }
                }

                throw new IndexOutOfRangeException("Nincs ilyen rendszámú kocsi");
            }
        }

        public void AddKocsi(Gepkocsi kocsi)
        {
            if(gepkocsik.Contains(kocsi))
            {
                throw new Exception("Már van ez a kocsi");
            }

            gepkocsik.Add(kocsi);
        }
    }
}