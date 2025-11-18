using _20251118;

namespace _20251118;

enum PlayerClass
{
    Warrior,
    Mage,
    Rogue,
    Cleric,
    Ranger,
    Knight
}

enum PlayerAlignment
{
    Good,
    Neutral,
    Evil
}

class Karakter
{
    public string KarakterId;
    public string Name;
    public int Level;
    public PlayerClass Class;
    public int HealthPoints;
    public int ManaPoints;
    public PlayerAlignment Alignment;
    public string Region;
    public double Gold;

    public Karakter(string id, string name, int lvl, PlayerClass classname, int health, int mana, PlayerAlignment alignment, string region, double gold)
    {
        this.KarakterId = id;
        this.Name = name;
        this.Level = lvl;
        this.Class = classname;
        this.HealthPoints = health;
        this.ManaPoints = mana;
        this.Alignment = alignment;
        this.Region = region;
        this.Gold = gold;
    }

    public override string ToString()
    {
        return $"{this.KarakterId} - {this.Name} - {this.Level} - {this.Class} - {this.HealthPoints} - {this.ManaPoints} - {this.Alignment} - {this.Region} - {this.Gold}";
    }
}

class Program
{
    static void Main(string[] args)
    {
        List<Karakter> list = new List<Karakter>();

        StreamReader sr = new StreamReader("input.txt");

        while (!sr.EndOfStream)
        {
            string[] line = sr.ReadLine().Split('|');

            try
            {
                int lvl = int.Parse(line[2]);
                if (lvl < 1 || lvl > 100) throw new Exception("Invalid lvl");

                int health = int.Parse(line[4]);
                if (health < 1) throw new Exception("Invalid health");

                int mana = int.Parse(line[5]);
                if (mana < 0) throw new Exception("Invalid mana");

                if (line[7] == "") throw new Exception("Invalid Region");

                double gold = double.Parse(line[8]);
                if(gold < 0 || gold > 1000000) throw new Exception("Invalid Gold");

                list.Add(new Karakter(
                    line[0],
                    line[1],
                    lvl,
                    (PlayerClass)Enum.Parse(typeof(PlayerClass), line[3]),
                    health,
                    mana,
                    (PlayerAlignment)Enum.Parse(typeof(PlayerAlignment), line[6]),
                    line[7],
                    gold
                ));
            }
            catch (System.Exception e)
            {
                System.Console.WriteLine($"{line[0]} - Skipped - {e.Message}");
            }
        }

        foreach (Karakter item in list)
        {
            System.Console.WriteLine(item.ToString());
        }
    }
}
