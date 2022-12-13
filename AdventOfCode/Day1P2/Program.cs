var data = """
1000
2000
3000

4000

5000
6000

7000
8000
9000

10000
""";

var mealsOfElfs = data.Split("\n\n").Select(e => e.Split("\n").Select(int.Parse).Sum())
    .OrderByDescending(n => n)
    .Take(3)
    .Sum();

Console.WriteLine(mealsOfElfs);
