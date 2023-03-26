using System;
using System.Collections.Generic;

namespace Lab5Games
{
    public static class ListExtensions
    {
        public static T First<T>(this IList<T> inList)
        {
            if (inList.Count == 0)
                throw new InvalidOperationException("The list is empty");

            return inList[0];
        }

        public static T Last<T>(this IList<T> inList)
        {
            if (inList.Count == 0)
                throw new InvalidOperationException("The list is empty");

            return inList[inList.Count - 1];
        }

        public static List<string> GetStringList<T>(this IList<T> inList)
        {
            List<string> strList = new List<string>();

            foreach (var item in inList)
            {
                strList.Add(item.IsNull() ? "NULL" : item.ToString());
            }

            return strList;
        }

        public static List<T> Clone<T>(this IList<T> inList)
        {
            List<T> cloned = new List<T>();

            foreach (var item in inList)
                cloned.Add(item);

            return cloned;
        }

        public static bool ContainsNull<T>(this IList<T> inList)
        {
            foreach (var item in inList)
            {
                if (item.IsNull())
                    return true;
            }

            return false;
        }

        public static int RemoveNulls<T>(this IList<T> inList)
        {
            int removedCount = 0;

            for (int indx = inList.Count - 1; indx >= 0; indx--)
            {
                if (inList[indx].IsNull())
                {
                    removedCount++;
                    inList.RemoveAt(indx);
                }
            }

            return removedCount;
        }

        public static bool AddUnique<T>(this IList<T> inList, T item)
        {
            if (item.IsNull()) return false;

            if (inList.Contains(item)) return false;

            inList.Add(item);
            return true;
        }

        // 聯集。包含 a-list 和 b-list 中的所有元素
        public static List<T> Union<T>(this IList<T> a, IList<T> b)
        {
            List<T> result = new List<T>();

            foreach (var item in a)
                result.AddUnique(item);

            foreach (var item in b)
                result.AddUnique(item);

            return result;
        }

        // 交集。a-list 中有，且 b-list 中也有
        public static List<T> Intersect<T>(this IList<T> a, IList<T> b)
        {
            List<T> result = new List<T>();

            foreach (var item in a)
            {
                if (b.Contains(item))
                {
                    result.AddUnique(item);
                }
            }

            return result;
        }

        // 差集。a-list 中有，而 b-list 中沒有
        public static List<T> Except<T>(this IList<T> a, IList<T> b)
        {
            List<T> outList = new List<T>();

            foreach (var item in a)
            {
                if (!b.Contains(item))
                {
                    outList.AddUnique(item);
                }
            }

            return outList;
        }

        // This method is used to return the unique element(s) from the respective collection.
        public static List<T> Distinct<T>(this IList<T> inList)
        {
            List<T> result = new List<T>();

            foreach (var item in inList)
                result.AddUnique(item);

            return result;
        }

        public static List<T> Shuffle<T>(this IList<T> inList)
        {
            int n = inList.Count;
            List<T> outList = inList.Clone();

            while (n > 1)
            {
                int k = UnityEngine.Random.Range(0, n);
                T val = outList[k];
                outList[k] = outList[n - 1];
                outList[n - 1] = val;

                --n;
            }

            return outList;
        }

        public static List<T> Reverse<T>(this IList<T> list)
        {
            int start = 0;
            int end = list.Count - 1;
            List<T> outList = new List<T>(list);

            while (end < start)
            {
                T tmp = outList[start];
                outList[start] = outList[end];
                outList[end] = tmp;

                start++;
                end--;
            }

            return outList;
        }
    }
}