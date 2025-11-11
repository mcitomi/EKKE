namespace _20251111fuggvenyek;

internal class B
{
    public int Szam1 { get; set; }
    public B(int szam)
    {
        this.Szam1 = szam;
    }
}
internal class A
{
    public B InternalClass { get; set; }
}
class Program
{
    static void Test(ref int val)
    {
        val = 20;
    }
    static void Main(string[] args)
    {
        // int szam = 10;
        // Test(ref szam);

        A elso = new A();
        elso.InternalClass = new B(33);

        System.Console.WriteLine(elso.InternalClass.Szam1);

        B tmp = elso.InternalClass;
        tmp.Szam1 -= 2;

        System.Console.WriteLine(elso.InternalClass.Szam1);
    }
}
