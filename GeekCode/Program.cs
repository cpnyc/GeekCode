using System;

namespace GeekCode
{
    class Program
    {
        static void Main(string[] args)
        {
            //new SortSegmentsOfString().Test();
            int[] a = new[] {82921272,
                110219722,
                162495938,
                470311130,
                583170602,
                329963077,
                403414481,
                437623101,
                485366585,
                599466263,
                959094281};
            var count = moves(a);
            Console.WriteLine(count);
        }

        static int moves(int[] a)
        {
            int count = 0;
            int oddIndex = 0;
            int evenIndex = a.Length-1;
            bool foundOdd = false;
            bool foundEven = false;
            while(oddIndex < evenIndex)
            {
                if (a[oddIndex] % 2 == 1) foundOdd = true;
                else oddIndex++;
                if (a[evenIndex] % 2 == 0) foundEven = true;
                else evenIndex--;
                if (foundEven && foundOdd)
                {
                    count++;
                    foundEven = foundOdd = false;
                    oddIndex++;
                    evenIndex--;
                }
                
            }

            return count;
        }



    }

    
}
