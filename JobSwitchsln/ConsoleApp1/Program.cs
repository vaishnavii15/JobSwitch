using PrepInterview;
using System.Reflection;

var topics = Assembly.GetExecutingAssembly().GetTypes()
    .Where(t => t.GetCustomAttribute<TopicAttribute>() != null &&
    typeof(IRunnable).IsAssignableFrom(t))
    .Select(t => new
    {
        Type = t,
        Attribute = t.GetCustomAttribute<TopicAttribute>()
    })
    .GroupBy(t => t.Attribute.Category)
    .ToDictionary(g => g.Key, g => g.ToList());



while (true)
{
    Console.Clear();
    Console.WriteLine("╔══════════════════════════╗");
    Console.WriteLine("║      C# Mastery Menu     ║");
    Console.WriteLine("╚══════════════════════════╝");

    var categories = topics.Keys.ToList();
    for (int i = 0; i < categories.Count; i++)
        Console.WriteLine($"  {i + 1}. {categories[i]}");
    Console.WriteLine("  0. Exit");
    Console.Write("\nChoose category: ");


    var catInput = Console.ReadLine();
    if (catInput == "0") break;
    if (!int.TryParse(catInput, out int catIndex)
        || catIndex < 1 || catIndex > categories.Count) continue;


    // --- Topic menu ---
    var selectedCategory = categories[catIndex - 1];
    var topicsInCategory = topics[selectedCategory];


    Console.Clear();
    Console.WriteLine($"╔══════════════════════════╗");
    Console.WriteLine($"║  {selectedCategory,-24}║");
    Console.WriteLine($"╚══════════════════════════╝");

    for (int i = 0; i < topicsInCategory.Count; i++)
        Console.WriteLine($"  {i + 1}. {topicsInCategory[i].Attribute.Name}");
    Console.WriteLine("  0. Back");
    Console.Write("\nChoose topic: ");

    var topicInput = Console.ReadLine();
    if (topicInput == "0") continue;
    if (!int.TryParse(topicInput, out int topicIndex)
        || topicIndex < 1 || topicIndex > topicsInCategory.Count) continue;

    // --- Run selected topic ---
    Console.Clear();
    Console.WriteLine($"=== {topicsInCategory[topicIndex - 1].Attribute.Name} ===\n");

    var instance = Activator.CreateInstance(
                       topicsInCategory[topicIndex - 1].Type
                   ) as IRunnable;
    instance?.Run();

    Console.WriteLine("\nPress any key to go back...");
    Console.ReadKey();
}