namespace _20251104learntolive;

class Program
{
    static void Main(string[] args)
    {
        string orarend = "";
        int actualLength = 0;

        string line = "";

        while (line != "vége")
        {
            line = Console.ReadLine();

            switch (line)
            {
                case "következő":
                    orarend += ";";
                    break;

                case "fizika" or "kémia" or "biológia":
                    if (actualLength + 60 > 240)
                    {
                        orarend += ";" + line + ",";
                        actualLength = 0;
                    }
                    else
                    {
                        orarend += line + ",";
                        actualLength += 60;
                    }

                    break;

                case "programozás" or "robotika":
                    if (actualLength + 90 > 240)
                    {
                        orarend += ";" + line + ",";
                        actualLength = 0;
                    }
                    else
                    {
                        orarend += line + ","; ;
                        actualLength += 90;
                    }

                    break;

                case "történelem" or "nyelvtan" or "angol" or "német":
                    if (actualLength + 45 > 240)
                    {
                        orarend += ";" + line + ",";
                        actualLength = 0;
                    }
                    else
                    {
                        orarend += line + ","; ;
                        actualLength += 45;
                    }

                    break;
                default:
                    break;
            }

            System.Console.WriteLine(orarend);
        }
    }
}
