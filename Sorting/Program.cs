using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] reversedArray = { 6, 5, 4, 3, 2, 1 };

            Algorithms.InsertionSort(reversedArray);

            DisplayArray(reversedArray, "Insertion Sort - Reversed Data: ");

            Console.ReadKey();
        }

        static void DisplayArray<T>(T[] data, string message = "")
        {
            Console.Write(message);
            for (int i = 0; i < data.Length; i++)
            {
                Console.Write(string.Format("{0} ", data[i]));
            }
            Console.WriteLine();
            Console.WriteLine("-----------");
        }
    }
}
