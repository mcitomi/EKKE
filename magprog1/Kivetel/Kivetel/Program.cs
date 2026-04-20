class MyException : ArgumentException
{
    public MyException(string message) : base(message)
    { }
}

class MyException2 : Exception 
{
    public MyException2(string kapokvmit) : base(String.Format("Ez egy hiba: \n" + kapokvmit))
    {
    }
}
internal class Program
{
    private static void Main(string[] args)
    {
        int[] a=new int[10];
        try
        {
            throw new MyException("Hiba van!!!");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }
        try
        {
            double c = 10 / 0.0;
            a[11] = 100;
        }
        catch (IndexOutOfRangeException e) { Console.WriteLine("Na!"); }
        catch (Exception) { Console.WriteLine("Gond van"); }
        finally { Console.WriteLine("Itt a vége!"); }
        
        Console.ReadKey();
    }
}