using PrepInterview;

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
    }
}
