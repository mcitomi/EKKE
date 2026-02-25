namespace _20260225_gunics
{
    internal class Employee : IComparable
    {
        // 4 mező
        // 1. FristName string
        // 2. DateOfBirth
        // 3. Salary int
        // 4. Position Position

        private string _firstName; // alapbol private nem kell kiírni
        DateOnly _dateOfBirth;
        int _salary;
        Position _position;

        // get set property
        // Arra jó, hogy elérjük a private mezőt, és kontrollálva lehet csak változtatni.

        public string FirstName
        {
            get
            {
                return this._firstName;
            }
            set
            {
                // ellenőrzéseket lehet végezni a beállítás után
                // 1. Nem lehet üres
                // 2. legalabb 2 karatker hosszu
                // 3. csak betűk, nem szóköz
                // hiba esetén dobjon kivételt

                if (string.IsNullOrEmpty(value))
                {
                    throw new Exception("Az érték üres vagy null");
                }

                if (value.Length < 2)
                {
                    throw new Exception("Túl rövid név");
                }

                foreach (char c in value)
                {
                    if (!char.IsLetter(c) || c == ' ')
                    {
                        throw new Exception("A névben csak karakter szerepelhet");
                    }
                }

                this._firstName = value;
            }
        }

        // Standard más nyelvekben:
        // Get és Set metódus írása, get set csak c#-ban van kb

        int setDateCounter = 0;
        public void SetDateOfBirt(DateOnly propValue)
        {
            // Csak kétszer lehessen beállítani, és csak 18-65 éves kor közé essen.

            if (setDateCounter >= 2)
            {
                throw new Exception("Csak kétszer lehet módosítani maximum");
            }

            int age = DateTime.Now.Year - propValue.Year;
            if (age < 18 || age > 65)
            {
                throw new Exception("Invalid kor");
            }

            setDateCounter++;
            this._dateOfBirth = propValue;
        }

        public int Salary
        {
            get { return this._salary; }
            set
            {
                this._salary = value;
            }
        }

        public Position Position
        {
            get { return this._position; }
            set { this._position = value; }
        }

        public override string ToString()
        {
            return $"Név: {FirstName} Fizetése: {Salary} Ft. ";
        }

        public int CompareTo(object? obj)
        {
            // Működése: Egész számot ad vissza, 0, kisebb mint 0 vagy nagyobb
            Employee other = new Employee();

            if(obj is Employee)
            {
                other = obj as Employee;
            }
            
            return this.Salary.CompareTo(other.Salary);
        }
    }
}

