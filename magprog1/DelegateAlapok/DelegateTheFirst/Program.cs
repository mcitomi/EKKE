/*
     * A delegate olyan típus, amely egy vagy több metódusra hivatkozik. Minden delegate különálló objektum, amely
egy listát tárol a meghívandó metódusokról (értelemszerűen ez egyúttal erős referencia is lesz a metódust
szolgáltató osztályra). Nemcsak példány-, hanem statikus metódusokra is mutathat. Egy delegate
deklarációjánál megadjuk, hogy milyen szignatúrával rendelkező metódusok megfelelőek:
delegate int TestDelegate(int x);
Delegate nem deklarálható blokkon belül, csakis osztályon belül tagként, illetve osztályokon kívül (hasonlóan az
enum típusokhoz). Ez a delegate olyan metódusra mutathat, amelynek visszatérési értéke int típusú és
egyetlen int paramétere van, pl.:
    static public int Pow(int x)
{
return (x * x);
}
A használata:
TestDelegate dlgt = Pow;
int result = dlgt(10);
A delegate-ekhez egynél több metódust is hozzáadhatunk a += és + operátorokkal, valamint elvehetjük őket a -
= és – operátorokkal. A delegate hívásakor a listáján lévő összes metódust meghívja a megadott paraméterre.

     
     */
class Test
{
    public delegate void TestDelegate(string msg);
    private TestDelegate handler;
    public Test()
    {
        handler += Test.StaticMethod;
        handler += this.InstanceMethod;
    }
    static public void StaticMethod(string msg)
    {
        Console.WriteLine(msg);
    }
    public void InstanceMethod(string msg)
    {
        Console.WriteLine(msg);
    }
    public void CallDelegate(string msg)
    {
        handler(msg);
    }
}

internal class Program
{
    
    private static void Main(string[] args)
    {
        Test delegate1 = new Test();
        delegate1.CallDelegate("Működik?"); //2x írja ki!:-)
        
    }
}