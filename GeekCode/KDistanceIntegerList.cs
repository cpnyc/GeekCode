using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace GeekCode
{
    class KDistanceIntegerList
    {
        public void Test()
        {
            Random r = new Random(50000);
            int len = 5000;
            //int[] a = new[] {1,5,3,8,4,6};
            int[] a = new int[len];
            HashSet<int> setA = new HashSet<int>();
            while(setA.Count < len)
            {
                setA.Add(r.Next(1, len*10));
            }
            setA.CopyTo(a);
            int count = findPairCount(a,100);
            Console.WriteLine(count);
        }

        private int findPairCount(int[] a, int k)
        {
            int count = 0;
            Console.WriteLine("start = " + System.DateTime.Now.ToString("HH:mm:ss.fff"));
            for (int i = 0; i < a.Length; i++)
            {
                for (int j = i + 1; j < a.Length; j++)
                {
                    if (a[i] - a[j] == k || a[j] - a[i] == k)
                        count++;
                }
            }
            Console.WriteLine("finish = " + System.DateTime.Now.ToString("HH:mm:ss.fff"));
            Console.WriteLine(count);

            count = 0;
            Console.WriteLine("start = " + System.DateTime.Now.ToString("HH:mm:ss.fff"));
            ArrayList al = new ArrayList(a);
            al.Sort();
            for(int i =0; i<al.Count-1; i++)
            {
                int x = (int)al[i];
                int next = (int)al[i+1];
                if ((x + k) == next) count++;
                else
                {
                    if ((x + k) < next) continue;

                    for (int j = i + 1; j < al.Count; j++)
                    {
                        next = (int)al[j];
                        if((x + k) < next) break;
                        if ((x + k) == next)
                        {
                            count++;
                            break;
                        }
                    }
                }
            }
            Console.WriteLine("finish = " + System.DateTime.Now.ToString("HH:mm:ss.fff"));
            return count;
        }
    }
}
