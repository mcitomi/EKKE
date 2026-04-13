using Allatok;

Random rn = new Random();
Kikepzotabor tabor=new Kikepzotabor();
for (int i = 0; i < 100; i++)
{
    int tipus = rn.Next(3);
    double kaja = rn.Next(1,100);
    double viz = rn.Next(1,100);

    switch (tipus)
    {
        case 0: tabor.Hozzaad(new Kacsa(kaja, viz)); break;
        case 1: tabor.Hozzaad(new Roka(kaja, viz)); break;
        case 2: tabor.Hozzaad(new Sas(kaja, viz)); break;
    }
}
while (tabor.Tulelok_szama >= 20)
{
    int tevekenyseg = rn.Next(5);
    switch (tevekenyseg)
    {
        case 0: tabor.Etetes(rn.Next(20,41)*tabor.Tulelok_szama); break;
        case 1: tabor.Itatas(rn.Next(20, 41) * tabor.Tulelok_szama); break;
        case 2: tabor.Futas(rn.Next(10, 31));break;
        case 3: tabor.Uszas(rn.Next(10, 31)); break;
        case 4: tabor.Repules(rn.Next(10, 31)); break;
    }
}
foreach (var item in tabor.Tulelok)
{
    Console.WriteLine(item.ToString());
}
