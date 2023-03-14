MyList<int> list = new MyList<int>();

list.Add(1);
list.Add(2);
list.Add(0);

System.Console.WriteLine(list.GetBiggest());

MyList<string> list2 = new MyList<string>();

list2.Add("Hello");
list2.Add("World");

System.Console.WriteLine(list2.GetBiggest());

MyList<Person> personList = new MyList<Person>();

personList.Add(new Person("John", 20));
personList.Add(new Person("Jane", 50));
personList.Add(new Person("Jack", 40));

System.Console.WriteLine(personList.GetBiggest());