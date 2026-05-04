using DelegateANDIEnumerable;

internal class Program
{
    private static void Main(string[] args)
    {
        DelegateDemo delegateDemo = new DelegateDemo(); //lesz egy osztályunk, létrejön a tömb
        Kiir(delegateDemo); //Meghívjuk a Kiirt, annak paramétere egy object
        delegateDemo.Modosit(Negyzet);  //Itt kapja meg, hogy a negyzetre "mutasson"
        Kiir(delegateDemo);  //megint kiírja az elemekt, de...
        delegateDemo.Modosit(Duplaz);
        Kiir(delegateDemo);
        Console.ReadKey();
    }

    private static void Kiir(DelegateDemo delegateDemo) //objektum
    {
        Console.WriteLine("Elemek:");
        foreach (var item in delegateDemo) //a tömb elemeit írja ki! Mert van IENumerable....Egyébként nem menne!
        {
            Console.WriteLine(item);
        }
        Console.WriteLine();
    }

    private static int Duplaz(int bemenet)
    {
        return 2 * bemenet;
    }

    private static int Negyzet(int bemenet)
    {
        return bemenet * bemenet;
    }
}
