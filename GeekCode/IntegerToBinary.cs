using System;
using System.Collections.Generic;
using System.Text;

namespace GeekCode
{
    class IntegerToBinary
    {
        public string ToBinary(uint number)
        {
            String s = string.Empty;
            if (number == 0) return "0";

            while (number > 0)
            {
                s = (number % 2 == 0 ? "0" : "1") + s;
                number = number / 2;
            }
            return s;
        }

        public void Test()
        {
            Console.WriteLine(ToBinary(2));     // 10
            Console.WriteLine(ToBinary(3));     // 10
            Console.WriteLine(ToBinary(15));    // 1111
            Console.WriteLine(ToBinary(155));   // 10011011
        }
    }
}
