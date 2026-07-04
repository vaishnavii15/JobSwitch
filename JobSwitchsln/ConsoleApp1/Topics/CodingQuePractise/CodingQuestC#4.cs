using PrepInterview;

namespace ReviseConcepts.Topics.CodingQuePractise
{
    [Topic("Coding Questions", "4C#")]
    public class CodingQuestC_4: IRunnable
    {
        public void Run()
        {
            NumberOfSentences("Hello. How are you? I am fine! I'm Vaishnavi.");

            IsStringPangram("The quick brown fox jumps over the lazy dog");

            ToggleCase("Hello World");

            ShortestWord("The quick brown fox & he is cute");

            RemoveNonAlNum("Hello, World! 123");
        }

        // Count the Number of Sentences in a Paragraph

        void NumberOfSentences(string s)
        {
            var ans = s.Count(c => c == '.' || c == '!' || c == '?');

            Console.WriteLine($"No. of sentences in given paragraph is: {ans}");
        }



        //  Check if a String is a Pangram

        void IsStringPangram(string s)
        {
            Console.WriteLine("\n\n\n");

            s = s.ToLower();

            var ans = Enumerable.Range('a', 26).All(c => s.Contains((char)c));

            Console.WriteLine($"Is the given string a Panagram: {ans}");
        }



        // Toggle Case of Each Character

        void ToggleCase(string s)
        {
            Console.WriteLine("\n\n\n");

            var ans = new string(s.Select(c => char.IsUpper(c) ? char.ToLower(c) : char.ToUpper(c)).ToArray());

            Console.WriteLine($"Toggled case string is: {ans}");
        }



        // Find the Shortest Word in a Sentence

        void ShortestWord(string s)
        {
            Console.WriteLine("\n\n\n");

            var ans = s.Split(' ').OrderBy(w => w.Length).First();

            Console.WriteLine($"Shortest word from given sentence is: {ans}");
        }



        // Remove All Non-Alphanumeric Characters

        void RemoveNonAlNum(string s)
        {
            Console.WriteLine("\n\n\n");

            var ans = new String(s.Where(char.IsLetterOrDigit).ToArray());

            Console.WriteLine($"String after removing all non alphanmeric characters: {ans}");
        }
    }
}
