using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Sorting
{
    public static class Algorithms
    {
        /*  INSERTION SORT
         *  Time complexity: O(n^2).
         *  
         *  Concept:
         *  Iterate through the array. O(n)
         *  Compare the current item to every item before it. O(n)
         *  Place the current item in front of the first item that it is less than. O(1)
         * */
        public static int[] InsertionSort(int[] data)
        {
            int currentElement = 0;

            //O(n)
            for (int i = 0, j = 0; i < data.Length; i++) 
            {
                //O(1)
                currentElement = data[i];

                //O(n)
                //In the worst case, the final item should be the first item.
                for (j = i; j > 0 && data[j-1] > currentElement; j--) 
                {
                    //O(1)
                    data[j] = data[j - 1];
                }
                //O(1)
                data[j] = currentElement;
            }
            return data;
        }
        
        //Just for fun
        public static void InsertionSortGeneric<T>(T[] data) 
            where T : IComparable<T>
        {
            T currentElement;

            for (int i = 0, j = 0; i < data.Length; i++)
            {
                currentElement = data[i];
                for (j = i; j > 0 && data[j-1].CompareTo(currentElement) > 0; j--)
                {
                    data[j] = data[j - 1];
                }
                data[j] = currentElement;
            }
        }
    }
}
