using PrepInterview;
using System.Text;

namespace ReviseConcepts.Topics.CodingQuePractise
{
    [Topic("Coding Questions", "5C#")]

    public class CodingQuestC_5: IRunnable
    {
        public void Run()
        {
            LeftPad("Hello World!", 7);

            RightPad("Hello", 7);

            ExtractNumbers("abc 123 def 456");

            FindMiddleChar("abcdef");

            CamelCase("hello world foo");
        }


        // Left Pad a String to a Fixed Width
        //Pad the string on the left with spaces (or a character) until it reaches length N.
        void LeftPad(string s, int n, char padChar = ' ')
        {
            var ans = s.PadLeft(n, padChar);

            Console.WriteLine($"Left padded string: {ans}");
        }



        // Right Pad a String to a Fixed Width

        void RightPad(string s, int n, char padChar = ' ')
        {
            Console.WriteLine("\n\n\n");

            var ans = s.PadRight(n, padChar);

            Console.WriteLine($"Right padded string: {ans}.");
        }



        // Extract All Numbers from a String
        void ExtractNumbers(string s)
        {
            Console.WriteLine("\n\n\n");

            var ans = System.Text.RegularExpressions.Regex.Matches(s, @"\d+")
                .Select(m => int.Parse(m.Value))
                .ToList();

            Console.WriteLine("All the numbers from given string:");

            foreach (var a in ans)
            {
                Console.Write($",{a} ");
            }
        }



        // Find the Middle Character(s) of a String

        void FindMiddleChar(string s)
        {
            Console.WriteLine("\n\n\n");

            int mid = s.Length / 2;

            var ans = "";

            if (s.Length%2 == 0)
            {
                ans = s.Substring(mid - 1, 2);
            }
            else
            {
                ans = s.Substring(mid, 1);
            }

            Console.WriteLine($"The middle charcter/s of given string is: {ans}");
        }



        // Convert a Sentence to Camel Case

        void CamelCase(string s)
        {
            Console.WriteLine("\n\n\n");

            var arrWords = s.Split(' ');

            var ans = arrWords[0].ToLower() +
                string.Concat(arrWords.Skip(1)
                .Select(w => char.ToUpper(w[0]) +
                w.Substring(1).ToLower()));


            Console.WriteLine($"CamelCased string: {ans}");
        }
    }
}
