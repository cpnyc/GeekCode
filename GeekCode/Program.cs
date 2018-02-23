using System;

namespace GeekCode
{
    class Program
    {
        static void Main(string[] args)
        {
            MyHashTable ht = new MyHashTable(5);
            ht.Insert("k1","v1");
            ht.Insert("k2", "v2");
            ht.Insert("k3", "v3");
            ht.Insert("k4", "v4");
            ht.Insert("k5", "v5");
            ht.Insert("k6", "v6");
            ht.Insert("k7", "v7");

            Console.WriteLine(ht.Lookup("k1"));
            Console.WriteLine(ht.Lookup("k2"));
            Console.WriteLine(ht.Lookup("k3"));
            Console.WriteLine(ht.Lookup("k4"));
            Console.WriteLine(ht.Lookup("k5"));
            Console.WriteLine(ht.Lookup("k6"));
            Console.WriteLine(ht.Lookup("k7"));
        }

    }
}
