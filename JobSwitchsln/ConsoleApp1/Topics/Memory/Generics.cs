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
        }


        //1 - One method any type
        // Basic generics implementation
        public T GetFirst<T>(T[] array)
        {
            return array[0];
        }
    }
}
