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
    }
}
