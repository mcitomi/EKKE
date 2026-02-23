namespace _20260223;

class Program
{
    static void Main(string[] args)
    {
        Student myStudent = new Student();

        myStudent.FirstName = "Kanut";
        myStudent.SetLastName("King");
        myStudent.City = "Cegléd";
        myStudent.Average = 2.75;
        myStudent.Gender = GenderEnum.Male;
        myStudent.IsActive = false;
        myStudent.SetDateOfBirth(DateOnly.Parse("1999.01.01"));

        SortedSet<Student> store = new SortedSet<Student>();
        StreamReader inp = new StreamReader("students.txt");

        while (!inp.EndOfStream)
        {
            string[] line = inp.ReadLine().Split(';');

            store.Add(new Student(
                line[0],
                line[1],
                DateOnly.Parse(line[2].ToString()),
                line[3],
                double.Parse(line[4]),
                bool.Parse(line[5]),
                (GenderEnum) Enum.Parse(typeof(GenderEnum), line[6])
                )
            );
        }

        inp.Close();
    }
}
