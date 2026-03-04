namespace _20260304_gunics_02;

internal class Szonyeg
{
    float _hossz;
    float _szelesseg;
    bool _rojtosE;
    Szin _szin;
    int _evjarat;

    // hosszhoz property
    // védelmi szint + visszatérési típus + Mező neve

    public float Hossz
    {
        get
        {
            return this._hossz;
        }
        set
        {
            // ellenőrzéseket végzünk
            // value alapérték
            // minimum 2 méter és max 20 méter

            if (value < 2 || value > 20)
            {
                throw new Exception("A szőnyeg hossza nem megfelelő: " + value + " méter.");
            }

            this._hossz = value;
        }
    }

    // szélesség get és set metódus

    public float getSzelesseg()
    {
        return this._szelesseg;
    }

    public void setSzelesseg(float valueParam)
    {
        if (valueParam < 0.3 || valueParam > 4)
        {
            throw new Exception("Túl széles vagy túl vékony a szőnyeg");
        }

        this._szelesseg = valueParam;
    }

    // rojtossaga csak 1x állítható be

    private int szamlalo = 0;

    public bool RojtosE
    {
        get
        {
            return this._rojtosE;
        }
        set
        {
            if (szamlalo >= 1)
            {
                throw new Exception("Nem lehet állítani a rojtosságát a szőnyegnek");
            }

            this._rojtosE = value;
            szamlalo++;
        }
    }

    internal Szin Szin { get => this._szin; set => this._szin = value; }

    // nem lehet a mai dátumnál újabb

    public int Evjarat
    {
        get => this._evjarat;
        set
        {
            if (value > DateTime.Now.Year)
            {
                throw new Exception("Az évjárat nem lehet nagyobb az ideinél");
            }

            this._evjarat = value;
        }
    }

    // számított property

    // terület számított property

    // ha a rojt 5cm hosszu

    public float Terulet
    {
        get
        {
            if (this._rojtosE)
            {
                return (this._hossz - 2 * 0.05f) * (this._szelesseg - 2 * 0.05f);
            }
            else
            {
                return this._hossz * this._szelesseg;
            }
        }
    }

    public double Matek()
    {
        double teruletNegyzet = Math.Pow(Terulet, 2);

        double teruletKerekitve = Math.Round(Terulet, 2);

        return 2;
    }

    // kostruktor hívási lánc:
    public Szonyeg() { }

    public Szonyeg(float szelesseg, float hossz, int evjarat, Szin szin)
    {
        setSzelesseg(szelesseg);
        Hossz = hossz;
        Evjarat = evjarat;
        Szin = szin;
    }

    public Szonyeg(float szelesseg, float hossz, int evjarat, Szin szin, bool rojtose) : this(szelesseg, hossz, evjarat, szin)
    {
        RojtosE = rojtose;
    }

    public override string ToString()
    {
        return $"A szőnyeg {Hossz} m hosszú, {getSzelesseg()} m széles. területe: {Terulet} m^2";
    }

    public override bool Equals(object? obj)
    {
        // az a szőnyeg nagyobb ami hosszabb

        if(obj is not null && obj is Szonyeg)
        {
            Szonyeg other = obj as Szonyeg;

            return other.Hossz == this._hossz;
        } else
        {
            return false;
        }
    }
}