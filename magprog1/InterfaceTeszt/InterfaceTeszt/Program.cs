interface IMyInterface
{
    void MyMethod();
    public void MyMethod2()
    {
        Console.WriteLine("Implemented");
    }
}

class MyClass : IMyInterface
{
    public void MyMethod()
    {
        Console.WriteLine("Implemented");
    }
  /*  public void MyMethod2()
    {
        Console.WriteLine("Implemented in MyClass");
    }*/
}
internal class Program
{
    private static void Main(string[] args)
    {
        MyClass myClass = new MyClass();
        //myClass.MyMethod2();
        IMyInterface obj = new MyClass();
        obj.MyMethod2();
    }
}