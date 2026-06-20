namespace PrepInterview.Topics.Memory
{
    [Topic("Memory", "Value vs Reference Types")]
    public class ValueVsReference: IRunnable
    {
        public void Run() 
        { 
            Console.WriteLine("=== Value Types ===");
            DemoIntValueType();

            Console.WriteLine("\n\n=== Reference Types ===");
            DemoReferanceType();

            Console.WriteLine("\n\n=== String Reference Type ===");
            StringReferanceType();

            Console.WriteLine("\n\n=== When both types passed into method ===");
            PassingIntoMethod();

            Console.WriteLine("\n\n=== Ref Keyword ===");
            Refkeyword();
        }


        void DemoIntValueType()
        {
            int a = 10;
            int b = a;
            b = 20;

            Console.WriteLine($"a: {a}, b: {b}"); // a: 10, b: 20

            Console.WriteLine("\nValue types directly store their data in a fixed amount of memory on the stack. When a value type is assigned to a variable or passed to a method, a copy of the data is created and used. This means that changes to the data in one context do not affect the original data.");
        }


        void DemoReferanceType()
        {
            int[] arr1 = { 1, 2, 3 };
            int[] arr2 = arr1;
            arr2[0] = 10;

            Console.WriteLine($"arr1[0] = {arr1[0]}");
            Console.WriteLine($"arr2[0] = {arr2[0]}");

            Console.WriteLine("\nReference types store references to data in a variable amount of memory on the heap. When a reference type is assigned to a variable or passed to a method, the reference to the data is used, not the data itself. This means that changes to the data in one context affect the original data.");
        }


        void StringReferanceType()
        {
            string str1 = "Hi";
            string str2 = str1;
            str2 = "Hello";

            Console.WriteLine($"str1: {str1}");
            Console.WriteLine($"str2: {str2}");

            Console.WriteLine("\nStrings are reference types, but they are immutable and act like value type. When you assign a new value to a string variable, it creates a new string object in memory rather than modifying the existing one. This means that even though strings are reference types, they behave like value types in terms of immutability.");
        }


        void PassingIntoMethod()
        {
            int x = 5;
            ModifyValue(x);
            Console.WriteLine($"ValueType passed to method x: {x}");


            int[] arr = { 4, 5, 6 };
            ModifyValue(arr[0]);
            Console.WriteLine($"ReferanceType passed to method arr[0]: {arr[0]}");

            Console.WriteLine($"\nValue type — method gets a copy, original unchanged\nReference type — method gets the reference, original affected");
        }

        void ModifyValue(int y)
        {
            y = 100;
        }


        void Refkeyword()
        {
            int a = 100;
            ModifyRef(ref a);

            Console.WriteLine($"Using ref keyword= a: {a}");

            Console.WriteLine($"\nForces value type to be passed by reference\nCan modify the original variable");

        }

        void ModifyRef(ref int x)
        {
            x = 200;
        }
    }



}
