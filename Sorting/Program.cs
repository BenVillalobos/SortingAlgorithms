using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting
{
    /*
     * Useful Links:
     * Sorting Algorithms: https://www.toptal.com/developers/sorting-algorithms/
     * Big-O Explained: https://justin.abrah.ms/computer-science/big-o-notation-explained.html
     * Insertion Sort (Video): https://www.youtube.com/watch?v=DFG-XuyPYUQ
     * Selection Sort (Video): https://www.youtube.com/watch?v=f8hXR_Hvybo
     * Merge Sort (Video): https://www.youtube.com/watch?v=EeQ8pwjQxTM
     * Quick Sort (Video): https://www.youtube.com/watch?v=SLauY6PpjW4
     * Quick Sort (Implementation): http://snipd.net/quicksort-in-c#comment-346
     * */
    class Program
    {
        static void Main(string[] args)
        {
			int[] originalReversed = { 6, 5, 4, 3, 2, 1 };
			int[] originalRandom = { 9, 3, 2, 10, 8, 6 };
            int[] reversedArray = { 6, 5, 4, 3, 2, 1 };
			int[] randomArray = { 9, 3, 2, 10, 8, 6 };

            string[] strings = { "apple",
                                "peach",
                                "straw",
                                "spork" };
			
			DisplayArray(Algorithms.QuickSort(randomArray, 0, randomArray.Length - 1), "Quick Sort - Random Data: ");
			DisplayArray(Algorithms.QuickSort(reversedArray, 0, reversedArray.Length - 1), "Quick Sort - Random Data: ");

            DisplayArray(Algorithms.InsertionSort(reversedArray), "Insertion Sort - Reversed Data: ");
			DisplayArray(Algorithms.InsertionSort(randomArray), "Insertion Sort - Random Data: ");
            DisplayArray(GenericAlgorithms.InsertionSortGeneric(strings), "Insertion Sort Generic - Reversed Data: ");

            DisplayArray(Algorithms.SelectionSort(reversedArray), "Selection Sort - Reversed Data: ");
			DisplayArray(Algorithms.SelectionSort(randomArray), "Selection Sort - Random Data: ");
            DisplayArray(GenericAlgorithms.SelectionSortGeneric(strings), "Selection Sort Generic - Reversed Data: ");

			DisplayArray(Algorithms.BubbleSort(reversedArray), "Bubble Sort - Reversed Data: ");
			DisplayArray(Algorithms.BubbleSort(randomArray), "Bubble Sort - Random Data: ");
			DisplayArray(GenericAlgorithms.BubbleSortGeneric(strings), "Bubble Sort Generic - Reversed Data: ");

			DisplayArray(Algorithms.MergeSort(reversedArray), "Merge Sort - Reversed Data: ");
			DisplayArray(Algorithms.MergeSort(randomArray), "Merge Sort - Random Data: ");
			DisplayArray(GenericAlgorithms.MergeSortGeneric(reversedArray), "Merge Sort Generic - Reversed Data: ");
			DisplayArray(GenericAlgorithms.MergeSortGeneric(randomArray), "Merge Sort Generic - Random Data: ");

			Debug.Assert(compareArrays(originalReversed, reversedArray), "Original reversed array does not match the current reversed array.");
			Debug.Assert(compareArrays(originalRandom, randomArray), "Original random array does not match the current random array.");

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

		//Assuming both arrays are same length
		static bool compareArrays<T>(T[] array1, T[] array2)
			where T: IComparable
		{
			for (int i = 0; i < array1.Length; i++)
			{
				if (array1[i].CompareTo(array2[i]) != 0)
				{
					return false;
				}
			}
			return true;
		}
    }
}
