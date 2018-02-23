namespace GeekCode
{
    class MergeSort
    {
        /*
 * list of non-negative integers to sort
 * int[] arry = new[] {12, 34, 15, 10, 79, 8, 22};
 */
        public static int[] Merge(int[] data)
        {
            if (data.Length == 1) return data;

            int len = data.Length / 2;
            int[] leftArry = new int[len];
            int[] rightArry = new int[data.Length - len];
            for (int i = 0; i < leftArry.Length; i++)
                leftArry[i] = data[i];
            for (int i = 0; i < rightArry.Length; i++)
                rightArry[i] = data[len + i];

            var left = Merge(leftArry);
            var right = Merge(rightArry);

            return mergesort(left, right);
        }

        private static int[] mergesort(int[] l, int[] r)
        {
            int[] m = new int[l.Length + r.Length];

            int li = 0, ri = 0, mi = 0;
            while (l.Length - li > 0 && r.Length - ri > 0)
            {
                if (l[li] < r[ri])
                {
                    m[mi++] = l[li];
                    li++;
                }
                else
                {
                    m[mi++] = r[ri];
                    ri++;
                }
            }

            while (li < l.Length)
                m[mi++] = l[li++];
            while (ri < r.Length)
                m[mi++] = r[ri++];

            return m;
        }

        public void Test()
        {
            int[] arry = new[] { 12, 34, 15, 10, 79, 8, 22 };
            Merge(arry);
        }
    }
}