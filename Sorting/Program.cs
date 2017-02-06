using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting
{
    /*
     * Useful Links:
     * Sorting Algorithms: https://www.toptal.com/developers/sorting-algorithms/
     * Big-O Explained: https://justin.abrah.ms/computer-science/big-o-notation-explained.html
     * Insertion Sort (Video with explanation and pseudo code): https://www.youtube.com/watch?v=DFG-XuyPYUQ
     * Selection Sort (Video with explanation and pseudo code): https://www.youtube.com/watch?v=f8hXR_Hvybo
     * */
    class Program
    {
        static void Main(string[] args)
        {
            int[] reversedArray = { 6, 5, 4, 3, 2, 1 };
            string[] strings = { "apple",
                                "peach",
                                "straw",
                                "spork" };

            DisplayArray(Algorithms.InsertionSort(reversedArray), "Insertion Sort - Reversed Data: ");
            DisplayArray(Algorithms.InsertionSortGeneric(strings), "Generic Insertion Sort- Reversed Data: ");

            DisplayArray(Algorithms.SelectionSort(reversedArray), "Selection Sort - Reversed Data: ");
            DisplayArray(Algorithms.SelectionSortGeneric(strings), "Generic Selection Sort - Reversed Data: ");

			DisplayArray(Algorithms.BubbleSort(reversedArray), "Bubble Sort - Reversed Data: ");
			DisplayArray(Algorithms.BubbleSortGeneric(strings), "Generic Bubble Sort - Reversed Data: ");

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
