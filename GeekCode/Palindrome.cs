using System;

namespace GeekCode
{
    class Palindrome
    {

        /*
         *  string str = "civic";
         *  ValidatePalindrome(str);
         */

        private static void ValidatePalindrome(string str)
        {
            char[] cArry = str.ToCharArray();
            int strLen = cArry.Length;
            int len = cArry.Length / 2;
            for (int i = 0; i < len; i++)
            {
                if (cArry[i] != cArry[strLen - i - 1])
                    return;
            }
            Console.WriteLine("This word {0} is palindrome", str);
        }
    }
}