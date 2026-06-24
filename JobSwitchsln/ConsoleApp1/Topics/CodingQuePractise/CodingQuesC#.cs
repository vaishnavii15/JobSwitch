using PrepInterview;

namespace ReviseConcepts.Topics.CodingQuePractise
{
    [Topic("Coding Questions", "C#")]
    public class CodingQues: IRunnable
    {
        public void Run() 
        {
            ReverseString();

            StarPattern(6);

            CheckStringPalindrome("aab1baa");

            CountVowelsAndConsonants("Vaishnavi");
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

    }
}
