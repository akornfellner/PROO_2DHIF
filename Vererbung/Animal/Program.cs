Dog rex = new Dog("Rex");

Cat amigo = new Cat("Amigo");

System.Console.WriteLine(amigo.Return1());

Animal[] animals = { rex, amigo };

foreach (var animal in animals)
{
    animal.MakeNoise();
}