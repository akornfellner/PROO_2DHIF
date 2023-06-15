MyList<int> mylist = new MyList<int>();


mylist.Add(1);
mylist.Add(2);
mylist.Add(3);

foreach (var item in mylist)
{
    System.Console.WriteLine(item);
}