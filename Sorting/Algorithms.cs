using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Sorting
{
	public static class Algorithms
	{

		/* DEFINITIONS
         * Stable: A sorting algorithm is said to be stable if two objects with equal keys appear in the same order in sorted output as they appear in the input array to be sorted
         */


		/*  INSERTION SORT (Stable)
         *  Time complexity: O(n^2) comparisons and swaps.
         *  Pros: Works best for nearly sorted arrays.
         *  Cons: Terrible for a reversed array.
         *  
         *  Concept:
         *  As we iterate through the array, compare the current item to every item before it to keep it sorted.
         *  
         *  Steps:
         *  Iterate through the array.
         *  Compare the current item to every item before it.
         *  Place the current item in front of the first item that it is greater than.
         *  Repeat
         * */
		public static int[] InsertionSort(int[] data)
		{
			int[] copiedData = new int[data.Length];
			data.CopyTo(copiedData, 0);
			//O(n)
			for (int i = 0, j = 0; i < copiedData.Length; i++)
			{

				//O(n)
				//In the worst case, the final item should be the first item.
				for (j = i; j > 0 && copiedData[j - 1] > copiedData[j]; j--)
				{
					int temp = copiedData[j];

					//O(1)
					copiedData[j] = copiedData[j - 1];

					//O(1)
					copiedData[j - 1] = temp;
				}
			}
			return copiedData;
		}

		//Generic just for fun
		public static T[] InsertionSortGeneric<T>(T[] data)
			where T : IComparable<T>
		{
			T[] copiedData = new T[data.Length];
			data.CopyTo(copiedData, 0);

			for (int i = 0, j = 0; i < copiedData.Length; i++)
			{
				for (j = i; j > 0 && copiedData[j - 1].CompareTo(copiedData[j]) > 0; j--)
				{
					T temp = copiedData[j];
					copiedData[j] = copiedData[j - 1];
					copiedData[j - 1] = temp;
				}
			}
			return copiedData;
		}

		/*  SELECTION SORT (Unstable)
        *  Time complexity: O(n^2) comparisons. O(n) swaps.
        *  Pros: Minimizes number of swaps.
        *  Cons: In different types of arrays (nearly sorted, random, reversed), they all take the same time to complete.
        *  
        *  Concept:
        *  Iterate through the array and find the smallest number. Place that number at the beginning.
        *  Iterate through the unsorted portion and swap the next smallest with the number in front of the last smallest number (which should now be at the beginning).
        *  
        *  Steps:
        *  Iterate through unsorted portion of array.
        *  Find the smallest item, place in sorted portion.
        *  Place that item next in the sorted portion of the list.
        *  Repeat
        * */

		public static int[] SelectionSort(int[] data)
		{
			int[] copiedData = new int[data.Length];
			data.CopyTo(copiedData, 0);

			//O(n)
			for (int i = 0, temp = 0; i < copiedData.Length; i++)
			{
				int smallest = i;

				//O(n)
				for (int j = i + 1; j < copiedData.Length; j++)
				{
					if (copiedData[j] < copiedData[smallest])
					{
						smallest = j;
					}
				}

				//O(1)
				temp = copiedData[i];
				copiedData[i] = copiedData[smallest];
				copiedData[smallest] = temp;
			}
			return copiedData;
		}

		public static T[] SelectionSortGeneric<T>(T[] data)
			where T : IComparable<T>
		{
			T[] copiedData = new T[data.Length];
			data.CopyTo(copiedData, 0);

			//O(n)
			for (int i = 0; i < copiedData.Length; i++)
			{
				int smallest = i;

				//O(n)
				for (int j = i + 1; j < copiedData.Length; j++)
				{
					if (copiedData[j].CompareTo(copiedData[smallest]) < 0)
					{
						smallest = j;
					}
				}

				//O(1)
				T temp = copiedData[i];
				copiedData[i] = copiedData[smallest];
				copiedData[smallest] = temp;
			}
			return copiedData;
		}

		/* BUBBLE SORT (Stable)
		 * Time Complexity: O(n^2) swaps and comparisons.
		 * Pros: Adapts better to nearly sorted lists. Becomes O(n)
		 * Cons: Reversed array takes the most time.
		 * 
		 * Concept & Steps: 
		 * Iterate through the array from back to front (or front to back). 
		 * Constantly check current item to the next, if not in order then swap.
		 * If a swap occurred and we hit the sorted portion, repeat. If no swap occurred, we're sorted.
		 */
		public static int[] BubbleSort(int[] data)
		{
			int[] copiedData = new int[data.Length];
			data.CopyTo(copiedData, 0);

			bool swapped = true;
			//O(n)
			for (int i = 0; i < copiedData.Length && swapped; i++)
			{
				swapped = false;

				//O(n)
				for (int j = copiedData.Length - 1; j > i; j--)
				{
					if (copiedData[j] < copiedData[j - 1])
					{
						int temp = copiedData[j];
						copiedData[j] = copiedData[j - 1];
						copiedData[j - 1] = temp;
						swapped = true;
					}
				}
			}

			return copiedData;
		}

		public static T[] BubbleSortGeneric<T>(T[] data)
			where T : IComparable
		{
			T[] copiedData = new T[data.Length];
			data.CopyTo(copiedData, 0);

			bool swapped = true;
			//O(n)
			for (int i = 0; i < copiedData.Length && swapped; i++)
			{
				swapped = false;

				//O(n)
				for (int j = copiedData.Length - 1; j > i; j--)
				{
					if (copiedData[j].CompareTo(copiedData[j - 1]) < 0)
					{
						T temp = copiedData[j];
						copiedData[j] = copiedData[j - 1];
						copiedData[j - 1] = temp;
						swapped = true;
					}
				}
			}

			return copiedData;
		}

		public static int[] MergeSort(int[] data)
		{
			int[] copiedData = new int[data.Length];
			data.CopyTo(copiedData, 0);



			return copiedData;
		}


    }
}
