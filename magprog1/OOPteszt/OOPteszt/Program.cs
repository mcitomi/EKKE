
class BaseA
{
    public int number1;
    protected int number2;
    private int number3;
    public static int stat;


    public int Number3
    {
        get { return number3; }
        set { number3 = value; }
    }
    public BaseA(ushort number2, short number3)
    {
        this.number2 = number2;
        this.number3 = number3;
        Console.WriteLine("Példány konstruktor");
    }
    public BaseA(short number2, short number3)
    {
        this.number2 = (int)number2;
        this.number3 = number3;
        Console.WriteLine("Példány konstruktor, longos");
    }
    static BaseA()
    {
        Console.WriteLine("A statikus konstruktor");
    }

    public void StatNovel()
    {
        stat++;
    }
    public void Kiiras()
    {
        Console.WriteLine(number3);
    }

    public void Display_Csak_Itt_Van()
    {
        Display();
    }

    public virtual void Display()
    {
        Console.WriteLine("Inside A");
    }
}

class BaseB : BaseA
{
    short baseb; short baseb2;
    public BaseB(ushort baseb, short baseb2) : base(baseb, baseb2)  // az ős osztály konstruktorát hívom meg a base-el.
    {
        Number3 = baseb2;

    }

    public new void Kiiras() //New van!! -> Új metódus az egész osztályban, nem felülírás, hanem új metódus, ami shadowolja a BaseA Kiiras-át.
    {
        Console.WriteLine(Number3);
    }

    public override void Display() //és ha new-t írok?
    {
        Console.WriteLine("Inside B");
    }

}

internal class Program
{
    private static void Main(string[] args)
    {
        BaseA myBaseA = new BaseA(10, 20);
        BaseA myBaseA2 = new BaseA(10, 21);
        myBaseA.number1 = 1; myBaseA2.number1 = 2;
        Console.WriteLine("{0}, {1}", myBaseA.number1, myBaseA2.number1);
        myBaseA.StatNovel(); myBaseA2.StatNovel();
        Console.WriteLine(BaseA.stat);
        BaseB myBaseB = new BaseB(10, 20); myBaseB.number1 = 1;

        Console.WriteLine("{0}, {1}", myBaseA.number1, myBaseB.number1);

        myBaseB.Kiiras();
        myBaseB.Display_Csak_Itt_Van();


        Console.ReadKey();

    }
}