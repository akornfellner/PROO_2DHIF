/*
a dictionary is a collection of key/value pairs that are organized based on the key.
instead of accessing elements using an index, you use a key to retrieve a value from a dictionary.
it can be useful when you need to quickly find a value based on a key.
*/

Dictionary<int, string> dict = new Dictionary<int, string>();

// you can also initialize a dictionary using object initializer syntax.
Dictionary<int, string> dict2 = new()
{
    [1] = "John",
    [2] = "Jane",
};

// you can add elements to a dictionary using the Add method.
dict.Add(10, "John");
dict.Add(20, "Jane");

Console.WriteLine(dict[10]);
// Console.WriteLine(dict[30]); //causes exception

// or you can use the indexer to add elements to a dictionary.
dict[30] = "Jack";

Console.WriteLine(dict[30]);

// you can replace an element in a dictionary by using the indexer.
dict[10] = "John Doe";

// you can remove an element from a dictionary using the Remove method.
dict.Remove(20);

// you can check if a dictionary contains a specific key using the ContainsKey method.
Console.WriteLine(dict.ContainsKey(10)); // true
Console.WriteLine(dict.ContainsKey(20)); // false

// you can check if a dictionary contains a specific value using the ContainsValue method.
Console.WriteLine(dict.ContainsValue("John Doe")); // true
Console.WriteLine(dict.ContainsValue("Jane")); // false

// you can get the number of elements in a dictionary using the Count property.
Console.WriteLine(dict.Count); // 2

// you can get all keys in a dictionary using the Keys property.
foreach (int key in dict.Keys)
{
    Console.WriteLine(key);
}

// you can get all values in a dictionary using the Values property.
foreach (var value in dict.Values)
{
    Console.WriteLine(value);
}

// you can loop through all elements in a dictionary using the foreach loop.
foreach (KeyValuePair<int, string> kvp in dict)
{
    Console.WriteLine(kvp.Key + " " + kvp.Value);
}

// you can also loop through all elements in a dictionary using the for loop.
for (int i = 0; i < dict.Count; i++)
{
    Console.WriteLine(dict.Keys.ElementAt(i) + " " + dict.Values.ElementAt(i));
}

// you can clear all elements from a dictionary using the Clear method.
dict.Clear();

// you can also use the Count property to check if a dictionary is empty.
Console.WriteLine(dict.Count == 0); // true


//dictionary is a generic collection, so you can use any type for the key and value.
Dictionary<string, int> dict3 = new Dictionary<string, int>();

dict3.Add("John", 10);
dict3.Add("Jane", 20);