using PrepInterview;

namespace ReviseConcepts.Topics.DesignPatterns
{
    [Topic("Design Patterns", "Singleton Pattern")]
    public class SingletonPattern: IRunnable
    {
        public void Run()
        {
            Console.WriteLine("Starting Singleton Demo.....\n");

            Logger logger1 = Logger.Instance;
            logger1.Log("First Log message");

            Console.WriteLine();

            Logger logger2 = Logger.Instance;
            logger2.Log("Second Log message");

            Console.WriteLine();

            bool isSameInstance = ReferenceEquals(logger1, logger2);
            Console.WriteLine($"Are logger1 and logger2 same instance?: {isSameInstance}");

            Console.WriteLine($"logger 1 ID: {logger1.InstanceId}");
            Console.WriteLine($"logger 2 ID: {logger2.InstanceId}");

        }
    }

    // Singleton class 
    public sealed class Logger
    {
        // private static field to hold singleton instance 
        // Lazy ensures - instance created first time only - thread safe
        private static readonly Lazy<Logger> _instance = new Lazy<Logger>(() => new Logger());

        // public static property - global access point
        public static Logger Instance => _instance.Value;

        public Guid InstanceId { get; } = Guid.NewGuid();

        // private constructore - prvents new instance creation
        private Logger()
        {
            Console.WriteLine($"Logger instance created with ID: {InstanceId}");
        }

        public void Log(string message)
        {
            Console.WriteLine($"[{DateTime.Now:HH:mm:ss}] [{InstanceId}] {message}");
        }
    }

}
