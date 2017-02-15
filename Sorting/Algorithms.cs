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
         * Adaptive: The algorithm may be faster depending on how sorted the array is. 
         * 			 If an algorithm is not adaptive, it may take the same time regardless of how array is sorted.
         * */


		/*  INSERTION SORT (Stable)
         *  Time complexity: O(n^2) comparisons and swaps.
         *  Pros: Adaptive. O(n) time for nearly sorted arrays.
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
			//Don't want to modify the data (for the purposes of my example)
			//I realize this isn't smart in terms of memory.
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

		/*  SELECTION SORT (Unstable)
        *  Time complexity: O(n^2) comparisons. O(n) swaps.
        *  Pros: Minimizes number of swaps.
        *  Cons: Not adaptive.
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
			//Don't want to modify the data (for the purposes of my example)
			//I realize this isn't smart in terms of memory.
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

		/* BUBBLE SORT (Stable)
		 * Time Complexity: O(n^2) swaps and comparisons.
		 * Pros: Adaptive. O(n) time for nearly sorted lists.
		 * Cons: Reversed array takes the most time.
		 * 
		 * Concept & Steps: 
		 * Iterate through the array from back to front (or front to back). 
		 * Constantly check current item to the next, if not in order then swap.
		 * If a swap occurred and we hit the sorted portion, repeat. If no swap occurred, we're sorted.
		 * */
		public static int[] BubbleSort(int[] data)
		{
			//Don't want to modify the data (for the purposes of my example)
			//I realize this isn't smart in terms of memory.
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

		//MergeSort helper function
		static void Merge(int[] L, int[] R, int[] dataToModify)
		{
			//Notice that I'm not copying over the data into a "copiedData" array.
			//At this point, it is safe to modify "dataToModify" because we know it won't modify the original data.

			//We need individual counters for each array because elements aren't necessarily added in order.
			int leftCounter, rightCounter, dataCounter;
			leftCounter = rightCounter = dataCounter = 0;

			//Compare the items in both arrays, placing the smaller into our data array.
			while (leftCounter < L.Length && rightCounter < R.Length)
			{
				if (L[leftCounter] < R[rightCounter])
				{
					dataToModify[dataCounter++] = L[leftCounter++];
				}
				else
				{
					dataToModify[dataCounter++] = R[rightCounter++];
				}
			}

			//Once one of the arrays is completely transferred, transfer ALL of the other arrays elements (which are already sorted)
			while (leftCounter < L.Length)
			{
				dataToModify[dataCounter++] = L[leftCounter++];
			}

			while (rightCounter < R.Length)
			{
				dataToModify[dataCounter++] = R[rightCounter++];
			}
		}

		/* MERGE SORT (Stable)
		 * 
		 * Time Complexity: O(nlg(n))
		 * Space Complexity: O(n)
		 * Pros: Great if memory is not an issue.
		 * Cons: If the size of the data is huge, this sort may not be ideal.
		 * 		 Need extra space for linked lists.
		 * 		 Not adaptive.
		 * 
		 * */
		public static int[] MergeSort(int[] data)
		{
			//Don't sort if it is empty or only has 1 item.
			if (data.Length < 2)
			{
				return data;
			}

			//Don't want to modify the data (for the purposes of my example).
			//I realize this isn't smart in terms of memory.
			int[] copiedData = new int[data.Length];
			data.CopyTo(copiedData, 0);

			int mid = copiedData.Length / 2;

			//Cut the array in half so we can handle them individually.
			int[] Left = new int[mid];
			int[] Right = new int[copiedData.Length - mid];

			//Copy the data over.
			Array.Copy(copiedData, Left, mid);
			Array.Copy(copiedData, mid, Right, 0, Right.Length);

			//Recursion! We must do exactly what we've just done to each individual array.
			//For clarity, breakpoint your way through these calls to understand exactly what's happening.
			Left = MergeSort(Left);
			Right = MergeSort(Right);
			Merge(Left, Right, copiedData);

			return copiedData;
		}

		/* QUICK SORT (Unstable)
		* 
 		* Time Complexity: O(nlg(n)) typically. O(n^2) worst case.
 		* Space Complexity: O(n). O(lg(n)) if optimized.
 		* Pros: If optimized, great overall for time and space.
 		* Cons: Not adaptive or stable.
 		* 
 		* */
		public static int[] QuickSort(int[] data, int left, int right)
		{
			//Don't want to modify the data (for the purposes of my example).
			//I realize this isn't smart in terms of memory.
			int[] copiedData = new int[data.Length];
			data.CopyTo(copiedData, 0);

			//two counters to increment inward from the left and right walls
			int i = left, j = right;

			//mid point pivot. This should be random to avoid n^2 complexity?
			int pivot = copiedData[(left + right) / 2];

			while (i <= j)
			{
				//Increment until the number on the left should be swapped to the right side
				while (copiedData[i] < pivot) { i++; }

				//Decrement until the number on the right should be swapped to the left side
				while (copiedData[j] > pivot) { j--; }

				//Swap the two numbers 
				if (i <= j)
				{
					int temp = copiedData[i];
					copiedData[i] = copiedData[j];
					copiedData[j] = temp;
					i++;
					j--;
				}
			}

			//if my left wall is less than j, there is more to sort.
			if (left < j)
			{
				copiedData = QuickSort(copiedData, left, j);
			}

			if (i < right)
			{
				copiedData = QuickSort(copiedData, i, right);
			}

			return copiedData;
		}


	}
}
