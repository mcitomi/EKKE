using System.Text.RegularExpressions;

namespace _20260318Gunics_Regex;

internal class HaztartasiGep
{
    private static Dictionary<int, char> energiaKodok = new Dictionary<int, char>
    {
        [1] = 'A',
        [2] = 'B',
        [3] = 'C',
        [4] = 'D',
        [5] = 'E'
    };
    string kod;
    public int gyartasiEv { get; private set; }
    public bool kisGep { get; private set; }
    double fogyasztas;

    public double getFogyasztas()
    {
        return fogyasztas;
    }

    public string Kod
    {
        get { return kod; }
        set
        {
            string regex = "^[A-Z][A-Z0-9-]{11}[A-Z0-9]$";
            string regex2 = "^[A-Z](?!.*--)$";

            Regex pattern = new Regex(regex);
            if (!pattern.IsMatch(value))
            {
                throw new Exception("A kód nem megfelelő a mintának");
            }

            if (value.Contains("--"))
            {
                throw new Exception("Nem tartalamzhat kettő kötőjelet egymás után");
            }

            kod = value;
        }
    }

    protected void setFogyasztas(float value)
    {
        this.fogyasztas = value;
    }

    public HaztartasiGep(string kod, bool kisgep, float fogyasztas, int gyartasiEv)
    {
        this.Kod = kod;
        this.kisGep = kisgep;
        this.setFogyasztas(fogyasztas);
        this.gyartasiEv = gyartasiEv;
    }

    // Meghívja az előző konstruktort de nem kéri be a gyartasiévet, hanem fix 2024-re állítja
    public HaztartasiGep(string kod, bool kisgep, float fogyasztas) : this(kod, kisgep, fogyasztas, 2024)
    {
        // Üres törzs, de kell
    }

    // Metódusok:
    // - Eljárás: nincs vissaztérési érték, void
    // - Funcktion: Van visszatérési érték
    public int Energiaosztály()
    {
        int energiaosztaly = 1;

        if (fogyasztas >= 0.2 && fogyasztas < 0.6)
        {
            energiaosztaly = 1;
        }

        if (fogyasztas >= 0.6 && fogyasztas < 1)
        {
            energiaosztaly = 2;
        }

        if (fogyasztas >= 1 && fogyasztas < 1.5)
        {
            energiaosztaly = 3;
        }

        if (fogyasztas >= 1.5 && fogyasztas < 2)
        {
            energiaosztaly = 4;
        }

        if (fogyasztas >= 2 && fogyasztas < 2.5)
        {
            energiaosztaly = 5;
        }

        if (energiaosztaly > 1 && DateTime.Now.Year - this.gyartasiEv > 5)
        {
            energiaosztaly--;
        }

        return energiaosztaly;
    }
}
