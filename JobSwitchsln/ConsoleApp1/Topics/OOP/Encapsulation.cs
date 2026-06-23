using PrepInterview;
namespace ReviseConcepts.Topics.OOP
{
    [Topic("OOPs", "Encapsulation")]
    public class Encapsulation : IRunnable
    {
        public void Run()
        {
            PublicClass obj = new PublicClass();
            //obj.EmployeeSalary = 90000; // Compilation error .Implementing encapsulation. The salary cannot be modified directly from outside the class.

            obj.Deposit(10000); // Deposit method can be used to modify the salary
            Console.WriteLine($"Updated Salary: {obj.EmployeeSalary}"); // Output: Updated Salary: 60000
        }
    }


    public class PublicClass
    {
       private decimal employeeSalary= 50000; // Encapsulated field

        public decimal EmployeeSalary
        {
            get { return employeeSalary; } // Read-only access, cannot be modified directly
        }

        public void Deposit(decimal amount) // Methid to modify the salary, encapsulating the logic
        {
            if (amount <= 0)
                throw new ArgumentException("Deposit amount must be positive.");
            employeeSalary += amount;
        }
    }
}
