using PrepInterview;


namespace ReviseConcepts.Topics.OOP
{
    [Topic("OOPs", "Overloading")]
    public class MethodOverloading: IRunnable
    {
        public void Run()
        {
            var basicOverloading = new Printer();
            basicOverloading.Print("Print Vaishnavi", "BLUE");

            Console.WriteLine("\n\n");

            var argTypeOverLoading = new Calculator();
            Console.WriteLine(argTypeOverLoading.Add("1.3", "9"));

        }
    }



    // -----1---------------Basic overloading----------------------
    // same method name different parameter count
    public class Printer
    {
        public void Print(string msg) => Console.WriteLine(msg);

        public void Print(string msg, int times) => Console.WriteLine($"{msg} X {times}");

        public void Print(string msg, string color) => Console.WriteLine($"{msg} with {color} color");
    }



    // ----2----------------Different Parameter types------------------------
    // Compiler picks the best match based on argument type
    public class Calculator
    {
        public int Add(int a, int b) => a + b;

        public double Add(double a, double b) => a + b;

        public string Add(string a, string b) => a + b;
    }
}
