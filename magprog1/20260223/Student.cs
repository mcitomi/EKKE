namespace _20260223;

class Student : IComparable<Student>
{
    private string _FirstName;
    public string FirstName
    {
        get
        {
            return _FirstName;
        }
        set
        {
            if (value.Length < 2)
            {
                throw new Exception("Túl kicsi");
            }
            if (string.IsNullOrEmpty(value))
            {
                throw new Exception("Null vagy üres szöveg nem lehet");
            }
            for (int i = 0; i < value.Length; i++)
            {
                if (!char.IsLetter(value[i]))
                {
                    throw new Exception("Csak betű lehet benne");
                }
            }
            _FirstName = value;
        }
    }
    string _LastName; // Nem kell kiírni hogy "private" alapbol az a property
    // Belső privát változó elé vagy _ írunk vagy kisebtűvel írjuk.

    public void SetLastName(string paramValue)
    {
        if (paramValue.Length < 2)
        {
            throw new Exception("Túl kicsi");
        }
        if (string.IsNullOrEmpty(paramValue))
        {
            throw new Exception("Null vagy üres szöveg nem lehet");
        }
        for (int i = 0; i < paramValue.Length; i++)
        {
            if (!char.IsLetter(paramValue[i]))
            {
                throw new Exception("Csak betű lehet benne");
            }
        }
        _LastName = paramValue;
    }

    public string GetLastName()
    {
        return _LastName;
    }

    DateOnly? _DateOfBirth = null;

    public void SetDateOfBirth(DateOnly paramValue)
    {
        if (_DateOfBirth is not null)
        {
            throw new Exception("Már adtak meg születési dátumot");
        }

        TimeSpan totalAge = DateTime.Now - paramValue.ToDateTime(TimeOnly.MinValue);

        if (totalAge.TotalDays < 18 * 365 || totalAge.TotalDays > 120 * 365)
        {
            throw new Exception("Hibás kor (18-120)");
        }

        _DateOfBirth = paramValue;
    }
    public DateOnly? GetDateOfBirth()
    {
        return _DateOfBirth;
    }

    string _City;
    public string City
    {
        get { return _City; }
        set
        {
            for (int i = 0; i < value.Length; i++)
            {
                if (!char.IsLetter(value[i]) && value[i] != '-')
                {
                    throw new Exception("Csak betű lehet benne");
                }
            }
        }
    }

    double _Average = 0.0;
    public double Average
    {
        get { return _Average; }
        set
        {
            if (value < 1.0 || value > 5.0)
            {
                throw new Exception("Hibás érték (1-5)");
            }

            _Average = value;
        }
    }

    bool _IsActive;
    public bool IsActive
    {
        get { return _IsActive; }
        set
        {
            _IsActive = value;
        }
    }

    GenderEnum _Gender;
    public GenderEnum Gender
    {
        get { return _Gender; }
        set { _Gender = value; }
    }

    public override string ToString()
    {
        return $"{FirstName} {GetLastName()} {GetDateOfBirth()} {City}"; // ilyenkor nincs jelentősége hogy melyiket írjuk ki a védettet vagy a propertyt
    }

    public Student() {}

    public Student(string p1, string p2, DateOnly p3, string p4, double p5, bool p6, GenderEnum p7)
    {
        FirstName = p1;
        SetLastName(p2);
        SetDateOfBirth(p3);
        City = p4;
        Average = p5;
        IsActive = p6;
        Gender = p7;
    }

    public int CompareTo(Student obj)
    {
        if(this.GetLastName() == obj.GetLastName())
        {
            return this.FirstName.CompareTo(obj.FirstName) * -1;
        }
        else
        {
            return this.GetLastName().CompareTo(obj.GetLastName()) * -1;
        }
    }
}
