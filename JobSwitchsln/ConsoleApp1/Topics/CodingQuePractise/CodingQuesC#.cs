using PrepInterview;

namespace ReviseConcepts.Topics.CodingQuePractise
{
    [Topic("Coding Questions", "C#")]
    public class CodingQues: IRunnable
    {
        public void Run() 
        {
            ReverseString();
        }


        //Reverse the given string

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
    }
}
