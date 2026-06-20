[AttributeUsage(AttributeTargets.Class)]
public class TopicAttribute : Attribute
{
    public string Category { get; }
    public string Name { get; }
    public TopicAttribute(string category, string name)
    {
        Category = category;
        Name = name;
    }
}