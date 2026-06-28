using PrepInterview;

namespace ReviseConcepts.Topics.OOP
{
    [Topic("OOPs", "Inheritance")]
    public class Inheritance : IRunnable
    {
        public void Run()
        {
            //1
            //Animal a = new Animal(); // Gives error 

            //2
            Dog d = new Dog("Buddy");
            Console.WriteLine($"{d.Describe()} -> {d.Speak()}, Loves: {d.LovesDoing()}");

            //Dog b = new Animal(); // Child cannot create instance of base.

            Console.WriteLine("\n\n");

            //3
            Cat c = new Cat("Whiskers");
            Console.WriteLine($"{c.Describe()} -> {c.Speak()}, Loves: {c.LovesDoing()}");

            Console.WriteLine("\n\n");

            //4
            Animal gd = new GuideDog("Mufasa");
            Console.WriteLine($"{gd.Describe()} -> {gd.Speak()}");

            Console.WriteLine("\n\n");

            //5
            Animal pd = new PoliceDog("K9");
            Console.WriteLine($"{pd.Describe()} -> {pd.Speak()}");

            //Dog d = new Animal("Buddy"); // compiler error- because not every animal is dog 
        }
    }

    // 1 - Abstract class/ method, Virtual method
    // abstract class — cannot be instantiated, can contain non-abstract methods, outer abstract class cannot be private, inner can
    // abstract method — no body, subclass MUST override, cannot be declared in non-abstract class, cannot be private
    // virtual method  — has default body, subclass MAY override, cannot be private
    public abstract class Animal
    {
        public string Name { get; set; }

        protected Animal(string name) 
        {
            Name = name; 
        }

        public abstract string Speak(); // cannot contain body

        public virtual string Describe() => $"I am {Name}";

        public virtual string LovesDoing() => "Playing";
    }



    // 2 - Inheritance in child and Sealed method
    // Inherits Animal, implements Speak, keeps Describe as-is
    public class Dog: Animal
    {
        public Dog(string name) : base(name) { }

        public override string Speak() => "WOOF"; // Must implement else gives compile error

        // Keeping virtual implementation same

        public sealed override string LovesDoing() => "Fetching..."; // sealed method, stops inheritance chaining
        // cannot seal method which does not exist in base
    }



    // 3 - Calling base 
    // Overrides both Speak AND Describe
    // base.Describe() reuses parent logic, then extends it
    public class Cat: Animal
    {
        public Cat(string name): base(name) { }

        public override string Speak() => "Meow!";

        public override string Describe() => base.Describe() + ", a cat"; // base keyword invokes base class method directly
    }



    // 4 - Sealed cannot be invoked later
    // Third level: GuideDog → Dog → Animal
    // base.Speak() calls Dog's version, not Animal's
    public class GuideDog: Dog
    {
        public GuideDog(string name): base(name) { }

        public override string Speak() => base.Speak() + " (trained)";  // base keyword on grandparent

        //public override string LovesDoing() => "Hunt"; // cannot override, because method is sealed

    }




    // 5 - Sealed class
    // sealed — nobody can inherit from PoliceDog,
    // can inherit from others, object can be created
    // outer sealed cannot be private, inner sealed can
    public sealed class PoliceDog: Dog
    {
        public PoliceDog(string name): base(name) { }

        public override string Speak() => "Woof I'm police STOP!";
    }

}
