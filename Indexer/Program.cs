namespace Indexer;
class Program
{
    static void Main(string[] args)
    {
        StringList list = new();

        list.Add("Hello World");
        list.Add("abc");
        list.Add("xyz");
        list.Add("qwertz");

        System.Console.WriteLine(list[4]);
    }
}
