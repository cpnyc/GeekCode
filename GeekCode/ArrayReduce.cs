using System;
using System.Collections.Generic;
using System.Text;

namespace GeekCode
{
    class ArrayReduce
    {
        private T Reduce<T, U>(Func<U, T, T> func, IEnumerable<U> list, T acc)
        {
            foreach (var i in list)
                acc = func(i, acc);

            return acc;
        }

        private int Reduce1(int[] list)
        {
            int sum = 0;
            for (int i = 0; i < list.Length; i++)
            {
                sum += list[i];
            }

            return sum;
        }
        public void Test()
        {
            int[] a = new[] {1,2,3,4};
            var testList = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            Console.WriteLine(Reduce<int, int>((x, y) => x + y, testList, 0));
            Console.WriteLine(Reduce1(a));
        }
    }
}
