namespace _20260225_gunics;

class Program
{
    static void Main(string[] args)
    {
        Employee e1 = new Employee();
        e1.Salary = 164_000;
        e1.Position = Position.Lead;
        e1.FirstName = "Sándor";
        e1.SetDateOfBirt(new DateOnly(2005, 2, 9));

        Employee e2 = new Employee();
        e2.Salary = 464_500;
        e2.Position = Position.Lead;
        e2.FirstName = "Sándor";
        e2.SetDateOfBirt(new DateOnly(2005, 2, 9));

        Employee e3 = new Employee();
        e3.Salary = 666_000;
        e3.Position = Position.Lead;
        e3.FirstName = "Sándor";
        e3.SetDateOfBirt(new DateOnly(2005, 2, 9));

        SortedSet<Employee> ceg = new SortedSet<Employee>();

        ceg.Add(e1);
        ceg.Add(e2);
        ceg.Add(e3);

        foreach (var item in ceg)
        {
            System.Console.WriteLine(item.ToString());   
        }
    }
}
