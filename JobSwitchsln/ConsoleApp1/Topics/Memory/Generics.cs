using PrepInterview;

namespace ReviseConcepts.Topics.Memory
{
    [Topic("Memory", "Generics")]

    public class Generics: IRunnable
    {
        public void Run()
        {
            // 1
            int firstInt = GetFirst(new int[] { 1, 2, 3 });
            string firstString = GetFirst(new string[] { "A", "B" });

            Console.WriteLine($"Int type: {firstInt}, String type: {firstString}");

            // 2
            Box<int> intBox = new Box<int>();
            intBox.Set(42);

            Box<string> stringBox = new Box<string>();
            stringBox.Set("Hii!!");
        }


        //Write one piece of code that works for any data type — without sacrificing type safety.


        //1 - One method any type
        // Basic generics implementation
        public T GetFirst<T>(T[] array)
        {
            return array[0];
        }
    }


    // 2 - Generic class
    public class Box<T>
    {
        private T _value;

        public void Set(T value) => _value = value;
        public T Get() => _value;
    }
}
