using PrepInterview;

namespace ReviseConcepts.Topics.Memory
{
    [Topic("Memory", "Special Types (var, object, dynamic)")]

    public class SpecialTypes: IRunnable
    {
        //1. Var
        //2. Dynamic
        //3. Object
        public void Run()
        {
            DemoSpecialTypes();
        }

        void DemoSpecialTypes()
        {
            //Var 
            var variable = 11;
            var name = "John";
            //Type cannot be changed once initialized

            Console.WriteLine("\nObject:\nType Resolution: Compile-time (statically typed).\nImplicitly typed local variable — the compiler infers the type from the right-hand side.\nType cannot change after initialization.");


            //dynamic

            dynamic data = 1;
            data = "Hello!!";

            Console.WriteLine("\n\nDynamic:\nType Resolution: Runtime (dynamically typed).\nCan change type after initialized\nNot type safe");


            //object
            object o = 44;
            int num = (int)o;

            Console.WriteLine("\n\nObject:\nType Resolution: Compile-time\nCan store any type, but accessing specific members requires explicit casting.\nBoxing Unboxing issue");
        }
    }
}
