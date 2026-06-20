namespace PrepInterview.Topics.Memory
{
    [Topic("Memory", "Boxing and unboxing")]
    public class BoxingAndUnboxing: IRunnable
    {
        public void Run()
        {
            //Console.WriteLine("=== Boxing and Unboxing ===");
            BoxingAndUnboxingImplementation();
        }


        void BoxingAndUnboxingImplementation()
        {
            int val = 100;

            object boxed = val;
            Console.WriteLine($"\nBoxed = boxed: {boxed}");

            Console.WriteLine("\nBoxing: Converting a value type into a reference type (object). Implicite conversion");

            int unboxed = (int)boxed;
            Console.WriteLine($"\n\nUnboxed = unboxed: {unboxed}");

            Console.WriteLine("\nUnboxing: Extracting the value type from the object. Explicite conversion");

        }
    }
}
