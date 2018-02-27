using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace GeekCode
{
    /*
     * You are given an alphanumeric string. Complete the function sortSegments that will segment 
     * the string into substrings of consecutive letters or numbers and then sort the substrings. 
     * For example, the string "AZQF013452BAB" will result in "AFQZ012345ABB". The input letters 
     * will be uppercase and numbers will be between 0 and 9 inclusive. 
     * 
     */
    class SortSegmentsOfString
    {
        class Segment
        {
            private readonly int[,] charCount;
            private readonly int size = 0;
            private int factor = 0;
            public Segment(int sz)
            {
                size = sz;
                charCount = new int[sz, 1];
                if (size == 10) factor = 48;
                else if (size == 26) factor = 65;
            }
            public void SetValue(char c)
            {
                var index = ((int) c) - factor;
                charCount[index, 0] = charCount[index,0] + 1;
            }

            public override string ToString()
            {
                StringBuilder sb = new StringBuilder();
                for(int i =0; i<size; i++)
                {
                    if (charCount[i, 0] > 0)
                    {
                        for(int j=0;j<charCount[i,0]; j++)
                            sb.Append(Convert.ToChar(i + factor));
                    }
                }
                
                return sb.ToString();
            }
        }

        public string sortSegments(string str)
        {
            if (string.IsNullOrWhiteSpace(str))
                return string.Empty;

            bool isNumberSegment = false;
            bool isCharSegment = false;
            List<Segment> segments = new List<Segment>();
            Segment currSegment = null;

            for (int i = 0; i < str.Length; i++)
            {
                int x = (int)str[i];
                if (x < 65) // number segment
                {
                    if (isNumberSegment == false)
                    {
                        currSegment = new Segment(10);
                        segments.Add(currSegment);

                        isNumberSegment = true;
                        isCharSegment = false;
                    }
                    currSegment.SetValue(str[i]);
                }
                else
                {
                    if (isCharSegment == false)
                    {
                        currSegment = new Segment(26);
                        segments.Add(currSegment);

                        isNumberSegment = false;
                        isCharSegment = true;
                    }
                    currSegment.SetValue(str[i]);
                }
            }
            string finalString = string.Empty;
            foreach (var segment in segments)
            {
                finalString += segment;
            }

            return finalString;
        }

        public void Test()
        {
            Console.WriteLine( sortSegments("AZQF013452BAB")); 
        }
    }
}
