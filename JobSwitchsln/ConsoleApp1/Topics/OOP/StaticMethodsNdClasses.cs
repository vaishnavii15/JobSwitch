using PrepInterview;

namespace ReviseConcepts.Topics.OOP
{
    [Topic("OOPs", "Statics")]
    public class StaticMethodsNdClasses: IRunnable
    {
        public void Run()
        {
            //1
            //var a = new MathHelper(); // compile error

            Console.WriteLine("\n\n");

            //2
            Console.WriteLine($"First static field: {Counter.Total}");
            var c1 = new Counter();
            var c2 = new Counter();
            Console.WriteLine($"Second static field: {Counter.Total}");
            Console.WriteLine($"{c1.Id} {c2.Id}");

            Console.WriteLine("\n\n");

            //3
            var mp = new MsgPrinter();
            //mp.Print("");// static method cannot be accessed via instance
            MsgPrinter.Print("Written by Vaishnavi");

            Console.WriteLine("\n\n");

            //4
            Console.WriteLine(Config.AppName);

            Console.WriteLine("\n\n");

            //5
            var obj = new Setting();
            //obj.MaxRetry = 55; // Can't change with instance
            Console.WriteLine($"{Setting.MaxRetry}, {Setting.LaunchDate}");


            Console.WriteLine("\n\n");

            // 6
            Base b = new Child();
            Console.WriteLine(Base.Who());                  // Base
            Console.WriteLine(Child.Who());                 // Child

            Console.WriteLine("\n\n");

            //7
            Parent p = new Child1();
            Console.Write("Base reference: ");
            p.Method();
            Child1 p1 = new Child1();
            Console.Write("Child reference: ");
            p1.Method();
        }
    }



    //1 - normal Static class
    // all members must be static, cannot instantiate, cannot inherit
    public static class MathHelper
    {
        public static int Square(int x)
        {
            return (x * x);
        }
    }



    //2 - STATIC MEMBER IN A NORMAL CLASS
    // normal classes can have static members
    public class Counter
    {
        public static int Total = 0; // shared across all instances

        public int Id;

        public Counter()
        {
            Total++;
            Id = Total;
        }
    }



    //3 - STATIC METHOD 
    // static methods cannot have non-static fields
    public class MsgPrinter
    {
        public string Name = "Vaishnavi";

        public static void Print(string msg)
        {
            Console.WriteLine(msg);
        }

        //public static void WrongMethod() => Console.WriteLine(Name);// compile error cannot acces non-static members from same class
    }



    //4 - STATIC CONSTRUCTOR
    // static constructor doesn't have modifier, no parameter
    // Runs ONCE automatically before the class is first used.
    // You cannot call it manually.
    public class Config
    {
        public static string AppName;

        static Config()
        {
            AppName = "myAppName";
        }
    }



    //5 - CONST vs STATIC READONLY
    //const -> compile time, implicitely static, only primitive/ string
    //static readonly -> runtime, set once, can hold any type
    public class Setting
    {
        public const int MaxRetry = 3;

        public static readonly DateTime LaunchDate = new DateTime(2024, 1, 1);

    }



    //6 - STATIC HIDING (not overriding)
    // static methods are not polymorphic 
    // 'new' hides the base method — but call is resolved by TYPE, not object.
    public class Base
    {
        public static string Who() => "Base";
    }

    public class Child: Base
    {
        public new static string Who() => "Child";
    }



    //7- New Keyword implementation
    public class Parent
    {
        public void Method() => Console.WriteLine("Parent");
    }

    public class Child1: Parent
    {
        public new void Method() => Console.WriteLine("Child");
    }
}
