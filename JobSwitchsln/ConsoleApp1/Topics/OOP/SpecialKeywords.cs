using PrepInterview;

namespace ReviseConcepts.Topics.OOP
{
    [Topic("OOPs", "Special Keywords")]
    public class SpecialKeywords: IRunnable
    {
        public void Run()
        {
            // 1
            DynamicMethod();

            //3
            int x = 100;           // must be initialized before passing
            Double(ref x);         // must use ref keyword while calling too 
            Console.WriteLine(x);  // original variable modified

            //4
            Divide(100, 2, out int result, out bool success);    // No need to initialize result and success before passing
            Console.WriteLine($"{result}, {success}");

            //5
            double h = 3.0;
            double w = 5.0;         // must be initialized
            PrintArea(in w, in h);  // 'in' keyword optional at call site
        }


        // 1 - Dynamice keyword
        // Bypasses compile-time type checking — resolved at runtime
        void DynamicMethod()
        {
            dynamic obj = "Vaishnavi";
            Console.WriteLine(obj.Length);

            obj = "Dayal";
            Console.WriteLine(obj.Length);

            obj = 42;
            Console.WriteLine(obj);
        }



        // 2 - Var keyword
        // type decided at compile time, strongly typed unlike dynamic
        void VarKeyword()
        {
            var name = "Vaishnavi";
            //name = 1; // can't change
        }



        // 3 - Ref keyword 
        // passing in referance type, can READ and MODIFY the original variable
        void Double(ref int number)
        {
            Console.WriteLine("\n\n");
            number = number * 2;
        }



        // 4 - Out keyword
        // out: caller doesn't need to initialize
        // but we MUST assign it before method ends
        void Divide(int a, int b, out int result, out bool success)
        {
            Console.WriteLine("\n\n");

            if (b == 0)
            {
                result = 0;
                success = false;
                return;
            }
            result = a / b;
            success = true;
        }



        // 5 - In keyword 
        // in: caller must initialize (like ref)
        // but we can ONLY READ, not modify (unlike ref)
        void PrintArea(in double width, in double height)
        {
            Console.WriteLine("\n\n");

            //width = 100;      - Modification not allowed
            Console.WriteLine($"Area: {width * height}");
        }
    }
}
