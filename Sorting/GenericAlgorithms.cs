using System;
namespace Sorting
{
	public static class GenericAlgorithms
	{
		public static T[] InsertionSortGeneric<T>(T[] data)
			where T : IComparable<T>
		{
			//Don't want to modify the data (for the purposes of my example)
			//I realize this isn't smart in terms of memory.
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


		public static T[] SelectionSortGeneric<T>(T[] data)
			where T : IComparable<T>
		{
			//Don't want to modify the data (for the purposes of my example)
			//I realize this isn't smart in terms of memory.
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


		public static T[] BubbleSortGeneric<T>(T[] data)
			where T : IComparable
		{
			//Don't want to modify the data (for the purposes of my example)
			//I realize this isn't smart in terms of memory.
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

		//MergeSort helper function
		static void MergeGeneric<T>(T[] L, T[] R, T[] dataToModify)
			where T : IComparable
		{
			//Notice that I'm not copying over the data into a "copiedData" array.
			//At this point, it is safe to modify "dataToModify" because we know it won't modify the original data.

			//We need individual counters for each array because elements aren't necessarily added in order.
			int leftCounter, rightCounter, dataCounter;
			leftCounter = rightCounter = dataCounter = 0;

			//Compare the items in both arrays, placing the smaller into our data array.
			while (leftCounter < L.Length && rightCounter < R.Length)
			{
				if (L[leftCounter].CompareTo(R[rightCounter]) < 0)
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

		public static T[] MergeSortGeneric<T>(T[] data)
			where T : IComparable
		{
			//Don't sort if it is empty or only has 1 item.
			if (data.Length < 2)
			{
				return data;
			}

			//Don't want to modify the data (for the purposes of my example).
			//I realize this isn't smart in terms of memory.
			T[] copiedData = new T[data.Length];
			data.CopyTo(copiedData, 0);

			int mid = copiedData.Length / 2;

			//Cut the array in half so we can handle them individually.
			T[] Left = new T[mid];
			T[] Right = new T[copiedData.Length - mid];

			//Copy the data over.
			Array.Copy(copiedData, Left, mid);
			Array.Copy(copiedData, mid, Right, 0, Right.Length);

			//Recursion! We must do exactly what we've just done to each individual array.
			//For clarity, breakpoint your way through these calls to understand exactly what's happening.
			Left = MergeSortGeneric(Left);
			Right = MergeSortGeneric(Right);
			MergeGeneric(Left, Right, copiedData);

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
		public static T[] QuickSortGeneric<T>(T[] data, int left, int right)
			where T: IComparable
		{
			//Don't want to modify the data (for the purposes of my example).
			//I realize this isn't smart in terms of memory.
			T[] copiedData = new T[data.Length];
			data.CopyTo(copiedData, 0);

			//two counters to increment inward from the left and right walls
			int i = left, j = right;

			//mid point pivot. This should be random to avoid n^2 complexity?
			T pivot = copiedData[(left + right) / 2];

			while (i <= j)
			{
				//Increment until the number on the left should be swapped to the right side
				while (copiedData[i].CompareTo(pivot) < 0) { i++; }

				//Decrement until the number on the right should be swapped to the left side
				while (copiedData[j].CompareTo(pivot) > 0) { j--; }

				//Swap the two numbers 
				if (i <= j)
				{
					T temp = copiedData[i];
					copiedData[i] = copiedData[j];
					copiedData[j] = temp;
					i++;
					j--;
				}
			}

			//if my left wall is less than j, there is more to sort.
			if (left < j)
			{
				copiedData = QuickSortGeneric(copiedData, left, j);
			}

			if (i < right)
			{
				copiedData = QuickSortGeneric(copiedData, i, right);
			}

			return copiedData;
		}

	}
}
