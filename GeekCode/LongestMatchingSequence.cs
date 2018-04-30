using System;
using System.Collections.Generic;
using System.Text;

namespace GeekCode
{
    class LongestMatchingSequence
    {
        public void Test()
        {
            string[] user0 = new string[] { "/nine.html", "/four.html", "/six.html", "/seven.html", "/one.html" };
            string[] user1 = new string[] { "/one.html", "/two.html", "/three.html", "/four.html", "/six.html" };
            string[] user2 = new string[] { "/nine.html", "/two.html", "/three.html", "/four.html", "/six.html", "/seven.html" };
            string[] user3 = new string[] { "/three.html", "/eight.html" };


            // Sample output:

            // (user0, user2):
            //    /four.html
            //    /six.html
            //    /seven.html

            // (user1, user2):
            //    /two.html
            //    /three.html
            //    /four.html
            //    /six.html

            // (user0, user3):
            //    None

            // (user1, user3):
            //    /three.html

            Test(user0, user2);
        }

        private void Test(string[] user0, string[] user1)
        {
            List<string> outputList = findBestMatch(user0, user1);

            foreach (var s in outputList)
            {
                Console.WriteLine(s);
            }
        }
        public static List<string> findBestMatch(string[] u1, string[] u2)
        {
            List<string> outputMatch = new List<string>();

            if (u1 == null || u2 == null || u1.Length == 0 || u2.Length == 0)
                return outputMatch;

            int len1 = u1.Length;
            int len2 = u2.Length;
            int curr = 0;
            for (int i = 0; i < len1; i++)
            {
                List<string> possibleMatch = new List<string>();
                bool found = false;
                for (int j = curr; j < len2; j++)
                {
                    string s1 = u1[i];
                    string s2 = u2[j];
                    if (s1.Equals(s2))
                    {
                        possibleMatch.Add(s1);
                        curr++;
                        i++;
                        found = true;
                        if (i >= len1) break;
                    }
                    else
                    {
                        if (found)
                        {
                            if(outputMatch.Count < possibleMatch.Count)
                                outputMatch = possibleMatch;
                            found = false;
                        }
                        possibleMatch = new List<string>();
                    }

                    //Console.WriteLine(s1);
                    //Console.WriteLine(s2);
                }
                //Console.WriteLine(i);
                //foreach (var s in possibleMatch)
                //    Console.WriteLine(s);

                if (outputMatch.Count < possibleMatch.Count)
                    outputMatch = possibleMatch;

            }
            return outputMatch;
        }
    }
}
