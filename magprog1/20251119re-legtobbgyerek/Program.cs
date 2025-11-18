namespace _20251119re_legtobbgyerek;

class Program
{
    static void Main(string[] args)
    {
        string[] NKinput = Console.ReadLine().Split(' ');

        int N = int.Parse(NKinput[0]);
        int K = int.Parse(NKinput[1]);

        Dictionary<int, int> legtobbGyerek = new Dictionary<int, int>();
        
        for (int i = 0; i < K; i++)
        {
            int szulo = int.Parse(Console.ReadLine().Split(' ')[0]);

            if (legtobbGyerek.ContainsKey(szulo))
            {
                legtobbGyerek[szulo]++;
            }
            else
            {
                legtobbGyerek.Add(szulo, 1);
            }
        }


        int[] legtobbGyerekesSzulo = new int[2];
        foreach (var item in legtobbGyerek)
        {
            if (item.Value > legtobbGyerekesSzulo[1])
            {
                legtobbGyerekesSzulo[0] = item.Key;
                legtobbGyerekesSzulo[1] = item.Value;
            }
            else if (item.Value == legtobbGyerekesSzulo[1])
            {
                if (item.Key < legtobbGyerekesSzulo[0])
                {
                    legtobbGyerekesSzulo[0] = item.Key;
                }
            }
        }

        System.Console.WriteLine(legtobbGyerekesSzulo[0]);
    }
}
