public class Student : IPerson, IComparable<Student>
{
    public string Name { get; set; }
    public int Age { get; set; }

    public Student(string name, int age)
    {
        Name = name;
        Age = age;
    }

    public int CompareTo(Student? other)
    {
        if (other == null)
        {
            return -1;
        }

        if (Age == other.Age)
        {
            return 0;
        }

        if (Age < other.Age)
        {
            return -1;
        }

        return 1;
    }

    public override string ToString()
    {
        return $"Name: {Name} | Alter: {Age}";
    }
}