List<Student> list = new();

list.Add(new Student("Max", 40));
list.Add(new Student("Karl", 3));
list.Add(new Student("Alexander", 29));

list.Sort(); // sort funktioniert wegen IComparable

foreach (var student in list)
{
    System.Console.WriteLine(student);
}