using System.Globalization;

namespace _20251111datumok;

class Program
{
    static void Main(string[] args)
    {
        string s = "15.11.2025 14:30";
        DateTime d = DateTime.ParseExact(s, "dd.MM.yyyy HH:mm", CultureInfo.InvariantCulture);

        // 1. elozo_napi: napi dátumból (Now) vonjunk ki 2 hónapot és 1 napot
        DateTime elozo_napi = DateTime.Now.AddMonths(-2).AddDays(-1);

        // 2. napi dátumból (Today) adjunk hozzá 1évet és 20percet
        System.Console.WriteLine(DateTime.Today.AddYears(1).AddMinutes(20));

        // 3. kozeljovo: tároljuk el a megfelelő tipusú változóban 2044 év 10 hónap 5 napját
        DateOnly kozeljovo = new DateOnly(2044, 10, 5);

        // 4. negyvenes_evek: tároljuk el megfelelő típusban a "1944-12-10" szövegnek megfelelő dátumot
        DateOnly negyvenes_evek = DateOnly.Parse("1944-12-10");

        // 5. írjuk ki a közeljövőből az évet
        System.Console.WriteLine(kozeljovo.Year);

        // 6. írjuk ki a közeljövőt "2044 év és 10 hónap meg 5 nap" formában
        System.Console.WriteLine($"{kozeljovo.Year} év és {kozeljovo.Month} hónap meg {kozeljovo.Day} nap");

        // 7. írjuk ki a negyvenes_evek-et "pár nap múlva 1945 mert már a hónap 10. napja van 12 hónapban 1944 évben"
        System.Console.WriteLine($"pár nap múlva {negyvenes_evek.AddYears(1).Year} mert már a hónap {negyvenes_evek.Day}. napja van {negyvenes_evek.Month} hónapban {negyvenes_evek.Year} évben");
        
        // 8. írjuk ki az elozo_napi-ból "nap.hónap.év -> óra:perc:másodperc" formában
        System.Console.WriteLine(elozo_napi.ToString("dd.MM.yyyy -> HH:mm:ss"));
    }
}
