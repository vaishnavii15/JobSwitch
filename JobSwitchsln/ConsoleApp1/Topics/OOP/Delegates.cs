using PrepInterview;

namespace ReviseConcepts.Topics.OOP
{
    [Topic("OOPs", "Delegates")]

    public class Delegates: IRunnable
    {
        public void Run()
        {
            MathOperation op = Add; // Assigned delegate to Add method

            int result = op(3, 4);

            Console.WriteLine($"Add delegate result: {result}");

            Console.WriteLine("\n\n\n");

            op = Multiply;         // Assigned delegate to multiply method

            result = op(3, 4);

            Console.WriteLine($"Multiply delegate result: {result}");
        }

        public delegate int MathOperation(int a, int b);

        public int Add(int a, int b) => a + b;

        public int Multiply(int a, int b) => a * b;

    }
}
