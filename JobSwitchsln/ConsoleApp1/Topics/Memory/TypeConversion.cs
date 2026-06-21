using PrepInterview;

namespace ReviseConcepts.Topics.Memory
{
    [Topic("Memory", "Type Conversion and Casting")]
    public class TypeConversion: IRunnable
    {
        //1. Is Implementation 
        //2. As Implementation
        //3. Convert.ToString()
        //4. .ToString()

        public void Run() 
        {
            Console.WriteLine("=== Is implementation ===");
            IsImplementation();

            Console.WriteLine("\n\n=== As implementation ===");
            AsImplementation();

            Console.WriteLine("\n\n=== Convert.ToString() ===");
            ConvertToString();

            Console.WriteLine("\n\n===.ToString() ===");
            DemoToString();
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

            Console.WriteLine("\nChecks if an object’s runtime type is compatible with a given type.\nReturns true or false.\nAlso known as pattern matching");
        }


        void ConvertToString()
        {
            int a = 1;
            string b = Convert.ToString(a);

            string nullable = null;
            string c = Convert.ToString(nullable);

            Console.WriteLine($"Converted int value: {b} and nullable value: {c}");

            Console.WriteLine($"\nConverts into string while handling nullable fields as well.\nNullReferenceException is never thrown");
        }


        void DemoToString()
        {
            int a = 1;
            string b = a.ToString();

            string nullable = null;
            //string c = nullable.ToString();

            Console.WriteLine($"Converted int value: {b} and nullable value: GIVES AN ERROR");

            Console.WriteLine($"\nConverts into string.\nNullReferenceException is thrown while converting null values");

        }
    }
}
