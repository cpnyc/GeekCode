/*
 Author: Chirag Patel (programmer.guru@gmail.com)
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace GeekCode
{
    public class MyHashTable
    {
        public class KeyValuePair
        {
            public object Key;
            public object Value;
        }

        /*
        1. hashtable holds list of keys
        2. hashtable holds list of values
        3. hashtable holds keys that are indexed (no dupes)
        */
        protected uint size = 10;

        //protected int[] HashCodes { get; set; }
        protected object[] KeyValueList { get; set; }

        public MyHashTable()
        {
            //HashCodes = new int[size];
            KeyValueList = new object[size];

        }

        public MyHashTable(uint sz)
        {
            size = sz;
            // HashCodes = new int[size];
            KeyValueList = new object[size];
        }

        //given method
        protected uint GetHashCode(object key)
        {
            return (uint) key.GetHashCode();
        }


        //ht.Insert("Foo", bar);
        //ht.Insert("Foo", baz);
        //ht.Insert("Foo", bar);
        //ht.Insert("Bar", "barzzz");
        // to-do re-size hashtable when values increased
        //
        public void Insert(object key, object val)
        {
            uint hc = (uint) GetHashCode(key);

            uint hcKey = hc % size;
            object currVal = KeyValueList[hcKey];
            if (KeyValueList[hcKey] != null)
            {
                List<KeyValuePair> valList = null;
                if (currVal is IList && currVal.GetType().IsGenericType)
                {
                    valList = (List<KeyValuePair>) currVal;
                }
                else
                {
                    valList = new List<KeyValuePair>();
                    KeyValuePair cv = currVal as KeyValuePair;
                    if (cv != null)
                        valList.Add(new KeyValuePair {Key = cv.Key, Value = cv.Value});
                }
                bool found = false;
                foreach (var item in valList)
                {
                    if (key == item.Key)
                    {
                        item.Value = val;
                        found = true;
                        break;
                    }
                }
                if (!found)
                {
                    KeyValuePair kv = new KeyValuePair {Key = key, Value = val};
                    valList.Add(kv);
                }
                KeyValueList[hcKey] = valList;
            }
            else KeyValueList[hcKey] = new KeyValuePair {Key = key, Value = val};
        }

        // to-do
        public object Lookup(object key)
        {
            uint hcKey = GetHashCode(key) % size;
            object currVal = KeyValueList[hcKey];
            if (currVal == null) return null;
            if (currVal is IList && currVal.GetType().IsGenericType)
            {
                var valList = (List<KeyValuePair>) currVal;
                foreach (var kvPair in valList)
                {
                    if (kvPair.Key == key)
                        return kvPair.Value;
                }
            }
            else
            {
                return (currVal as KeyValuePair).Value;
            }
            return null;
        }
    }
}