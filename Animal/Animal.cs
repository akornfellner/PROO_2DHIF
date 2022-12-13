abstract class Animal
{
    public string Name { get; set; }

    public Animal(string name)
    {
        Name = name;
    }

    public int Return1()
    {
        return 1;
    }

    public abstract void MakeNoise();
}