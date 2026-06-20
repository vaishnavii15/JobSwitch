using PrepInterview;

namespace ReviseConcepts.Topics.Memory
{
    [Topic("Memory", "As Is Implementation")]
    public class AsIsImplementation: IRunnable
    {
        public void Run() 
        {
            Console.WriteLine("=== Is implementation ===");
            IsImplementation();

            Console.WriteLine("\n\n=== As implementation ===");
            AsImplementation();
        }

        void AsImplementation()
        {

            object obj = "StringValue";
            string str = obj as string;

            Console.WriteLine(str);

            Console.WriteLine("\nAttempts to convert an object to a specified reference or nullable type.\nReturns the converted object if successful, otherwise null.");
        }

        void IsImplementation()
        {
            object s = "string";
            string a = "a";

            if (s is string b)
            {
                Console.WriteLine($"s is string");
            }

            Console.WriteLine("\nChecks if an object’s runtime type is compatible with a given type.\nReturns true or false");
        }


    }
}
