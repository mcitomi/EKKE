namespace cs;

class Program
{
    static void Main(string[] args)
    {
        int dec = 0;
        string bin = "10111";
        int help = 1;

        for (int i = bin.Length - 1; i >= 0; i--) {
            dec += (bin[i]-'0') * help;
            help*=2;
        }
        System.Console.WriteLine(dec);
    }
}
