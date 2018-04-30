using System;
using System.Collections.Generic;

namespace GeekCode
{
    class Program
    {
        static void Main(string[] args)
        {
            //new SortSegmentsOfString().Test();
            //new KDistanceIntegerList().Test();
            //int[] a = new[] {82921272,
            //    110219722,
            //    162495938,
            //    470311130,
            //    583170602,
            //    329963077,
            //    403414481,
            //    437623101,
            //    485366585,
            //    599466263,
            //    959094281};
            //var count = moves(a);
            //Console.WriteLine(count);

            //new ArrayReduce().Test();
            //DistanceCalculator dc = new DistanceCalculator();

            //List<Tuple<string, string>> addressList = new List<Tuple<string, string>>();

            //Tuple<string, string> origin_destination_pair1 = new Tuple<string, string>("101 station lading, medford, ma 02155","56 manemet rd,newton center, ma 02459" );
            //Tuple<string, string> origin_destination_pair2 = new Tuple<string, string>("56 manemet rd,newton center, ma 02459","67 york terrace, brookline, ma 02446");
            //Tuple<string, string> origin_destination_pair3 = new Tuple<string, string>("67 york terrace, brookline, ma 02446", "101 station lading, medford, ma 02155");

            //addressList.Add(origin_destination_pair1);
            //addressList.Add(origin_destination_pair2);
            //addressList.Add(origin_destination_pair3);

            //double totalDistanceTraveled = dc.getTotalMilesTraveled(addressList);

            //Console.WriteLine( "Total distance traveled = " + totalDistanceTraveled + " miles");

            LongestMatchingSequence lms = new LongestMatchingSequence();
            lms.Test();

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
