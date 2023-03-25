MyList<int> list = new MyList<int>();

list.Add(1);
list.Add(2);
list.Add(3);

// the foreach loop can be used because MyList<T> implements IEnumerable<T>
foreach (int i in list)
{
    Console.WriteLine(i);
}

MyList<Person> people = new MyList<Person>();

people.Add(new Person("John", 20));
people.Add(new Person("Jane", 30));

foreach (Person person in people)
{
    Console.WriteLine(person);
}