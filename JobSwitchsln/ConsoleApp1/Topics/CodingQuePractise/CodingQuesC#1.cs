using PrepInterview;

namespace ReviseConcepts.Topics.CodingQuePractise
{
    [Topic("Coding Questions", "1C#")]
    public class CodingQues: IRunnable
    {
        public void Run() 
        {
            ReverseString();

            StarPattern(6);

            CheckStringPalindrome("aab1baa");

            CountVowelsAndConsonants("Vaishnavi");

            bool isAnagram = CheckAnagram("BaD", "DaD");
            Console.WriteLine($"Given strings are anagrams?: {isAnagram}");

            CountOccurance("Vaishnavi", 'a');

            RemoveStrings("Vaishnavi has abundance of intelligence");

            RevWordsInSentence("Vaishnavi is Great");

            FirstSingleChar("aabbcde");

            FindDuplicates("Vaishnavi");

            IsAllDigit("63871364a4");
        }


        //Reverse the given string
        // Make char arr, use while loop to swap the l and r char, convert back to string
        void ReverseString() 
        {
            string s = "hello";
            //Direct 
            //Console.WriteLine(s.Reverse().ToArray());

            //Indirect
            char[] arr = s.ToCharArray();

            int l = 0;
            int r = arr.Length - 1;

            while (l < r) 
            {
                (arr[l], arr[r]) = (arr[r], arr[l]);
                l ++;
                r --;
            }

            Console.WriteLine(new string(arr));
        
        }



        //Print star pattern
        //2 for loops, inner loop should check till outer var, inner has Write and outer WriteLine
        void StarPattern(int n) 
        {
            Console.WriteLine("\n\n\n");
            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= i; j++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
            }
        }



        //Check if given string is palindrome or not 
        // Just traverse in while loop using l, r and compare
        void CheckStringPalindrome(string s) 
        {
            Console.WriteLine("\n\n\n");

            s = s.ToLower();

            int l = 0;
            int r = s.Length - 1;
            bool checkPalindrome = true;

            while (l <= r)
            {
                if (s[l] != s[r])
                {
                    checkPalindrome = false;
                    break;
                }
                l += 1;
                r -= 1;
            }

            if (checkPalindrome)
            {
                Console.WriteLine("IT IS A PALINDROME");
            }
            else
            {
                Console.WriteLine("NOT A PALINDROME");
            }
        }



        //Get vowel and consonant count
        // Iterate over given string and check if given char is vowel or not
        void CountVowelsAndConsonants(string s)
        {
            Console.WriteLine("\n\n\n");

            s = s.ToLower();
            int vowelCount = 0;
            int consonantCount = 0;

            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == 'a' || s[i] == 'e' || s[i] == 'i' || s[i] == 'o' || s[i] == 'u')
                {
                    vowelCount += 1;
                }
            }

            consonantCount = s.Length - vowelCount;

            Console.WriteLine($"Vowel Count: {vowelCount}");
            Console.WriteLine($"Consonant Count: {consonantCount}");

        }



        // Check if strings are anagram 
        // make lower and compare using sequence equal
        bool CheckAnagram(string a, string b)
        {
            Console.WriteLine("\n\n\n");

            if (a.Length != b.Length)
            {
                return false;
            }

            return a.ToLower().OrderBy(c => c).SequenceEqual(b.ToLower().OrderBy(c => c));
        }



        // Count occurance of character
        // use Count func with lambda ex
        void CountOccurance(string str, char c)
        {
            Console.WriteLine("\n\n\n");

            int count = str.Count(x => x == c);

            Console.WriteLine($"Count of {c} in {str} is {count}");
        }



        // Remove all spaces from string
        // use linq 
        void RemoveStrings(string str)
        {
            Console.WriteLine("\n\n\n");

            //var a = string.Concat(str.Split(' '));

            var a = new string(str.Where(x => x != ' ').ToArray());

            Console.WriteLine($"Concatinated string is: {a}");
        }



        // Reverse words in a sentence 
        // direct Reverse or while to reverse
        void RevWordsInSentence(string str)
        {
            Console.WriteLine("\n\n\n");

            var w = str.Split(' ');

            //var ans = String.Join(" ", w.Reverse()); // Direct implementation

            int l = 0, r = w.Length - 1;

            while (l < r)
            {
                (w[l], w[r]) = (w[r], w[l]);
                l += 1;
                r -= 1;
            }

            var ans = String.Join(" ", w);

            Console.WriteLine(ans);
        }



        // First non-repeating character
        // use groupby and first having count = 1
        void FirstSingleChar(string s)
        {
            Console.WriteLine("\n\n\n");

            var ans = s.GroupBy(c => c).FirstOrDefault(g => g.Count() == 1)?.Key ?? '\0';

            Console.WriteLine($"First non-repeating character is: {ans}");
        }



        // Find Duplicates
        // just groupby, and where count > 1, those are duplicate
        void FindDuplicates(string s)
        {
            Console.WriteLine("\n\n\n");

            s.GroupBy(c => c).Where(g => g.Count() > 1).ToList().ForEach(g => Console.Write(g.Key + " "));
        }



        // Check if string contains only digit
        // char.IsDigit
        void IsAllDigit(string s)
        {
            Console.WriteLine("\n\n\n");

            var ans = s.All(char.IsDigit);

            Console.WriteLine($"IsAllDigit: {ans}");
        }

    }
}
