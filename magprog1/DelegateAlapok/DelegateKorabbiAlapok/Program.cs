
using DelegateKorabbiAlapok;

internal class Program
{
    delegate int Matekos(int i);
    delegate void Matek_Proc(int i);
    private static void Main(string[] args)
    {
        
  
        Matekos m1 = new Matekos(TesztElek.Matek1); //Itt még nem hívok meg semmit, csak rámutatok () nem kell!:-))
        Console.WriteLine(m1(10)); //Na itt hívom meg. Mit? Az m1-et? Azt nem hinném, az csak egy pointer... Akkor amire mutat
        TesztElek tesztElek = new TesztElek(); //Na, 10*10 megvolt
        Matekos m2 = new Matekos(tesztElek.Matek2); //most egy másik fv pointer
        Console.WriteLine(m2(10)); //ez a Matek2-ra mutat, így azt hívjuk meg! 10*2;
        Matekos m3 = new Matekos(tesztElek.Matek3);  //itt a harmadik fv. pointer!
        m2 = m3; //oops castolás?single. Matek3 lesz  //ez meg a Matek3-ra mutat. De most már az m2 is!
        Console.WriteLine(m2(10));  //Azaz matek3 meghívása, így lesz 30 az eredmény. 
        Matek_Proc mproc = new Matek_Proc(tesztElek.Matek_alap); //most egy eljárás pointer lesz!
        mproc += new Matek_Proc(tesztElek.Matek_alap2); // A matek_alap2 eljárásra mutat...
        mproc(10); //meghívjuk..Mit is ír ki? Mi az, hogy mit? Miket!!!:-)) 10, 20, és 20. De miért 10?
        //és ha nincs ott a + jel?? Nagyon jó a kérdés!:-))
        Console.ReadKey();

    }
}