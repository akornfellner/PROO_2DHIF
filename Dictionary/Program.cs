/*
a dictionary is a collection of key/value pairs that are organized based on the key.
instead of accessing elements using an index, you use a key to retrieve a value from a dictionary.
it can be useful when you need to quickly find a value based on a key.
*/

Dictionary<int, string> dict = new Dictionary<int, string>();

// you can add elements to a dictionary using the Add method.
dict.Add(10, "John");
dict.Add(20, "Jane");

System.Console.WriteLine(dict[10]);
// System.Console.WriteLine(dict[30]); //causes exception

// or you can use the indexer to add elements to a dictionary.
dict[30] = "Jack";

System.Console.WriteLine(dict[30]);

// you can replace an element in a dictionary by using the indexer.
dict[10] = "John Doe";

// you can remove an element from a dictionary using the Remove method.
dict.Remove(20);

// you can check if a dictionary contains a specific key using the ContainsKey method.
System.Console.WriteLine(dict.ContainsKey(10)); // true
System.Console.WriteLine(dict.ContainsKey(20)); // false

// you can check if a dictionary contains a specific value using the ContainsValue method.
System.Console.WriteLine(dict.ContainsValue("John Doe")); // true
System.Console.WriteLine(dict.ContainsValue("Jane")); // false

// you can get the number of elements in a dictionary using the Count property.
System.Console.WriteLine(dict.Count); // 2

// you can get all keys in a dictionary using the Keys property.
foreach (int key in dict.Keys)
{
    System.Console.WriteLine(key);
}

// you can get all values in a dictionary using the Values property.
foreach (var value in dict.Values)
{
    System.Console.WriteLine(value);
}

// you can loop through all elements in a dictionary using the foreach loop.
foreach (KeyValuePair<int, string> kvp in dict)
{
    System.Console.WriteLine(kvp.Key + " " + kvp.Value);
}

// you can also loop through all elements in a dictionary using the for loop.
for (int i = 0; i < dict.Count; i++)
{
    System.Console.WriteLine(dict.Keys.ElementAt(i) + " " + dict.Values.ElementAt(i));
}

// you can clear all elements from a dictionary using the Clear method.
dict.Clear();

// you can also use the Count property to check if a dictionary is empty.
System.Console.WriteLine(dict.Count == 0); // true


//dictionary is a generic collection, so you can use any type for the key and value.
Dictionary<string, int> dict2 = new Dictionary<string, int>();

dict2.Add("John", 10);
dict2.Add("Jane", 20);