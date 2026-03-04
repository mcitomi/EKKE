namespace _20260304_gunics_02;

// ez egy konténer osztály, tárolja egy másik osztály elemeit
internal class Meteraru
{
    private List<Szonyeg> szonyegek = new List<Szonyeg>();

    public List<Szonyeg> Szonyegek
    {
        get
        {
            return szonyegek;
        }
    }

    public void AddSzonyeg(Szonyeg szonyeg)
    {
        if (szonyeg is null)
        {
            throw new Exception();
        }
        else
        {
            szonyegek.Add(szonyeg);
        }
    }
}