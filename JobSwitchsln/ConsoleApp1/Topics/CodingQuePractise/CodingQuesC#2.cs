using PrepInterview;
using System.Text;

namespace ReviseConcepts.Topics.CodingQuePractise
{
    [Topic("Coding Questions", "2C#")]
    public class CodingQuestC_2: IRunnable
    {
        public void Run()
        {
            WordsInString("Vaishnavi is sooooo  much   greatest     ");

            StringToTitle("intelligent is vaishnavi");

            var rotationString = StringRotationOfOthers("abcdef", "defabcz");
            Console.WriteLine($"Is string rotation of others: {rotationString}");

            RemoveDuplChars("abccdeeav");

            LongestWord("Hello my nameee is Vaishnavi!");

            FreqofChar("abccddaabz");

            ReplaceOccurance("good", "boy");

            CheckIfSubstring("abcccd", "cc");

            CompressedString("aaaabcccdddde");

            var isValidParenthese = ValidParentheses("{{{(())}}}");
            Console.WriteLine($"Is this valid parenthese: {isValidParenthese}");
        }

        // Count words in string 
        // split, just check length>0
        void WordsInString(string s)
        {
            var charArr = s.Split(new char[] { ' ' });

            var ans = charArr.Where(c => c.Length > 0).Count();

            Console.WriteLine($"Count of Words is: {ans}");
        }



        // Convert string to title case
        // split and add in new string with first char upper rest substring
        void StringToTitle(string s)
        {
            Console.WriteLine("\n\n\n");

            string ans = "";

            var charArr = s.Split(new char[] {' '});

            foreach(var a in charArr)
            {
                ans += char.ToUpper(a[0]) + a.Substring(1) + " ";
            }

            Console.WriteLine($"Title Case: {ans}");
        }



        // Check if string is rotation of other
        bool StringRotationOfOthers(string a, string b)
        {
            Console.WriteLine("\n\n\n");

            if (a.Length != b.Length)
            {
                return false;
            }

            if ((a + a).Contains(b))
            {
                return true;
            }

            return false;
        }



        // Remove duplicate characters from string
        // just get the distinct, make arr, convert to string
        void RemoveDuplChars(string s)
        {
            Console.WriteLine("\n\n\n");

            var ans = new string(s.Distinct().ToArray());

            Console.WriteLine(ans);
        }



        // Find longest word in sentence
        // split, order by descending
        void LongestWord(string s)
        {
            Console.WriteLine("\n\n\n");

            var charArr = s.Split(" ");

            var ans = charArr.OrderByDescending(c=> c.Length).First();

            Console.WriteLine($"Longest word in sentence: {ans}");
        }



        // Count frequency of each character 
        // groupby and count
        void FreqofChar(string s)
        {
            Console.WriteLine("\n\n\n");

            //s.GroupBy(c => c).ToList().ForEach(c => Console.WriteLine($"{c.Key} -> {c.Count()}"));

            var ans = s.GroupBy(c => c);

            foreach (var i in ans)
            {
                Console.WriteLine($"{i.Key} -> {i.Count()}");
            }
        }



        // Replace all occurance of word
        // split and replace
        void ReplaceOccurance(string a, string b)
        {
            Console.WriteLine("\n\n\n");

            string s = "Buddy (the dog) is a good boy";

            var v= s.Split(" ");

            for (int i = 0; i<= v.Length-1; i++)
            {
                if (v[i] == a)
                {
                    v[i] = b;
                }
            }

            Console.WriteLine(String.Join(" ", v));
        }



        // Check if string is subsctring of others
        // use contains
        void CheckIfSubstring(string a, string b)
        {
            Console.WriteLine("\n\n\n");

            var ans = a.Contains(b);

            Console.WriteLine($"Is b substring of a: {ans}");
        }



        // Compress a string 
        void CompressedString(string s)
        {
            Console.WriteLine("\n\n\n");
            var newStr = new StringBuilder();

            int i = 0;

            while (i < s.Length)
            {
                char c = s[i];
                int count = 0;

                while (i < s.Length && s[i] == c)
                {
                    count++;
                    i++;
                }
                newStr.Append(c).Append(count > 1 ? count.ToString() : "");
            }
            Console.WriteLine($"CompressedString: {newStr}");
        }



        // Check if Parantheses are balanced

        bool ValidParentheses(string s)
        {
            Console.WriteLine("\n\n\n");

            var stack = new Stack<char>();

            foreach(char c in s)
            {
                if (c =='(' || c == '{' || c == '[')
                {
                    stack.Push(c);
                }
                else if (c == ')' || c == '}' || c == ']')
                {
                    if (stack.Count() == 0) return false;

                    char top = stack.Pop();

                    if (c == ')' && top != '(') return false;
                    if (c == '}' && top != '{') return false;
                    if (c == ']' && top != '[') return false;
                }

            }
            return stack.Count() == 0;
        }
    }
}
