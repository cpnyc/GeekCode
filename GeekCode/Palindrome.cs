using System;

namespace GeekCode
{
    class Palindrome
    {
        /*
         *  string str = "civic";
         *  ValidatePalindrome(str);
         */

        public static void ValidatePalindrome(string str)
        {
            char[] cArry = str.ToCharArray();
            int strLen = cArry.Length;
            int len = cArry.Length / 2;
            for (int i = 0; i < len; i++)
            {
                if (cArry[i] != cArry[strLen - i - 1])
                {
                    Console.WriteLine("This word {0} is NOT a palindrome", str);
                    return;
                }
            }
            Console.WriteLine("This word {0} is a palindrome", str);
        }

        public void Test()
        {
            string str = "civic";
            ValidatePalindrome(str);
        }
    }
}