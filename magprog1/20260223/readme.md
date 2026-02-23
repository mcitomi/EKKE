https://aries.ektf.hu/~ksanyi/magasprog2/1.txt

```
Hozzunk létre egy Student osztályt! MProg2-en ez mindig legyen külön .cs-ben!
Az osztály neve nagybetűvel kezdődjön.
Mezők: 
- Firstname, string. Nem lehet sem üres, sem null (string.IsNullOrEmpty), legalább 2 karakter hosszú, csak betűből állhat (char.IsLetter()), nem lehet benne szóköz sem.
Írjunk hozzá property-ket (get és set)!
- LastName, string. Írjunk függvényt (SetLastName()), amely megvizsgálja, legalább 2 karakter hosszú-e, csak betűből áll csak (szóköz nem lehet), valamint nem lehet sem üres, sem null. Legfeljebb 2x lehet módosítani. Egy másik függvény adja vissza a mező értét (GetDateOfBirth())!
- DateOfBirth, DateOnly típusú. Írjunk függvényt, amely figyelni, hogy csak egyszer lehessen neki kezdőértéket adni, valamint a [18,120] intervullumba kell esnie. 
- City, string. Írjunk hozzá property-ket! Csak karaktereket és '-'-et tartalmazhat!
- Average, double. 1.0-5.0 közötti valós szám! Írjunk meg a property-t!
- gender, Gender típusú, ami Enum típusú! Írjunk hozzá property-ket!
- isActive, boolean. Írjunk hozzá Get és Set metódusokat!

Minden property, valamint metódus esetében, ha a kapott érték nem megfelelő, akkor a program dobjon kivételt (throw new Exception("Error message")!

Mivel többször kell kiírni Student objektumokat, így írjuk meg a ToString() metódust! (override!) Ne írjunk még konstruktort!

A Gender Enum is külön cs-ben legyen! 
internal enum Gender
{
        Male,
        Female,
        Other
}

 
Hozzunk létre egy Student objektumot! Állítuk be a mezők értékét! Próbáljuk hibás értékkel is!
Írjunk programot, amely beolvassa a students.txt tartalmát! Írassuk ki a képernyőre a tartalmát! Beolvasáskor tároljuk
a fájlt tartalmát egy SortedSet-be, majd a kiírás után írjuk ki a SortedSet tartalmát! Előtte bővítsük az osztályt a Comparable
interface használatával!

students.txt
Zorro Lajos;1781.12.20;4.6;Cadiz;Male;igaz
Superman Géza;1981.12.21;4.7;Kripto;Male;igaz
Harcos Women;1881.12.22;4.9;Gibralter;Female;igaz
Hermione Granger;2003.12.23;5.0;York;Female;igaz


Hogyan módosítsuk az osztályt????


Tudás:
TimeSpan totalAge = DateTime.Now - dateOfBirth.ToDateTime(TimeOnly.MinValue);

(Genre)Enum.Parse(typeof(Genre), data[3])

```