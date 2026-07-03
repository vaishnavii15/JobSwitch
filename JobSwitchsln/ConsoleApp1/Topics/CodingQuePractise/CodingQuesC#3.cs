using PrepInterview;

namespace ReviseConcepts.Topics.CodingQuePractise
{
    [Topic("Coding Questions", "3C#")]
    public class CodingQuesC_3: IRunnable
    {
        public void Run()
        {
            MostFreqChar("misssissippi");

            CheckifAllUnique("abcddef");

            ReverseVowels("hello");

            UpperAndLowercase("Hello World");

            Console.WriteLine("\n\n\n");

            FindAllPermutations("abc");

            var a = ConvertToInt("1234");
            Console.WriteLine(a);

            CheckIfStringsAreEqual("Hello", "hello");

            LongestPrefix(["flower", "flow", "flight"]);

            NWords("The quick brown fox", 2);

            IsValidEmail("vaishnaviidayal15@gmail.com");
        }


        //Find most frequent character
        // use grouping and top key 
        void MostFreqChar(string s)
        {
            var ans = s.GroupBy(c => c).OrderByDescending(g => g.Count()).First().Key;

            Console.WriteLine($"Most frequent character is:{ans}");
        }



        // Check if string has all unique characters
        void CheckifAllUnique(string s)
        {
            Console.WriteLine("\n\n\n");

            var ans = s.Distinct().Count() == s.Length;

            Console.WriteLine($"Are all characters in word unique: {ans}");
        }



        // Reverse only vowels in string 

        void ReverseVowels(string s)
        {
            Console.WriteLine("\n\n\n");
            string vowels = "aeiouAEIOU";

            char[] arr = s.ToCharArray();

            int l = 0;
            int r = arr.Length - 1;

            while (l < r)
            {
                while (l < r && !vowels.Contains(arr[l])) l++;
                while (l < r && !vowels.Contains(arr[r])) r--;

                (arr[l], arr[r]) = (arr[r], arr[l]);
                l++;
                r--;
            }

            Console.WriteLine($"Reversed vowel word: {new string(arr)}");
        }



        // Count Uppercase and Lowercase Letters
        void UpperAndLowercase(string s)
        {
            Console.WriteLine("\n\n\n");

            var lowerCount = s.Count(char.IsLower);
            var upperCount = s.Count(char.IsUpper);

            Console.WriteLine($"Upper count: {upperCount}, Lower count: {lowerCount}");
        }



        // Find All Permutations of a String

        void FindAllPermutations(string s, string result = "")
        {
            if (s.Length == 0) { Console.Write(result + " "); return; }

            for (int i = 0; i< s.Length; i++)
            {
                FindAllPermutations(s.Remove(i, 1), result + s[i]);
            }
        }



        // Convert a String to Integer
        int ConvertToInt(string s)
        {
            Console.WriteLine("\n\n\n");

            int result = 0;
            bool neg = s[0] == '-';
            int start = neg ? 1 : 0;

            for (int i = start; i < s.Length; i++)
                result = result * 10 + (s[i] - '0');
            return neg ? -result : result;
        }



        // Check if Two Strings are Equal Ignoring Case
        void CheckIfStringsAreEqual(string s1, string s2)
        {
            Console.WriteLine("\n\n\n");

            var ans = s1.ToLower() == s2.ToLower();

            Console.WriteLine($"Are both strings equal: {ans}");
        }



        // Find the Longest Common Prefix

        void LongestPrefix(string[] s)
        {
            Console.WriteLine("\n\n\n");

            string prefix = s[0];

            foreach(var i in s)
            {
                while (!i.StartsWith(prefix))
                {
                    prefix = prefix.Substring(0, prefix.Length - 1);
                }
            }

            Console.WriteLine($"Longest Prefix is: {prefix}");
        }



        // Truncate a String to N Words
        void NWords(string s, int n)
        {
            Console.WriteLine("\n\n\n");

            var splitted = s.Split(' ');

            var ans = string.Join(" ", splitted.Take(n));

            Console.WriteLine($"Taking {n} words from string is: {ans}");
        }



        // Check if a String is a Valid Email (Basic Check)
        void IsValidEmail(string email)
        {
            Console.WriteLine("\n\n\n");

            var ans = email.Contains("@") && email.Contains(".com");

            Console.WriteLine($"Is the given email valid? : {ans}");
        }
    }
}
