class Array
{
    public delegate void Transformer(ref int item);
    private int[] array;
    public Array(int length)
    {
        Length = length;
        array = new int[Length];
    }
    public int Length { get; set; }
    public int this[int idx]
    {
        get { return array[idx]; }
        set { array[idx] = value; }
    }
    public void Transform(Transformer t)
    {
        for (int i = 0; i < array.Length; ++i)
        {
            t(ref array[i]);
        }
    }
}
internal class Program
{
    static public void TransformerMethod(ref int item)
    {
        item *= item;
    }
    private static void Main(string[] args)
    {
        Array array = new Array(10);
        for (int i = 0; i < array.Length; ++i)
        {
            array[i] = i; //indexelő használata!:-)
        }
        array.Transform(Program.TransformerMethod); //Ez milyen szép
        for (int i = 0; i < array.Length; ++i)
        {
            Console.WriteLine(array[i]);
        }
        Console.ReadKey();
    }
}