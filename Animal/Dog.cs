class Dog : Animal
{
    public Dog(string name) : base(name)
    {
    }

    public void Run()
    {
        System.Console.WriteLine("Ich laufe!");
    }

    public override void MakeNoise()
    {
        System.Console.WriteLine("Wuff");
    }
}