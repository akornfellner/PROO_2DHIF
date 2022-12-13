class Cat : Animal
{
    public int Lives { get; set; }

    public Cat(string name) : base(name)
    {
        Lives = 9;
    }

    public override void MakeNoise()
    {
        System.Console.WriteLine("Miau");
    }
}