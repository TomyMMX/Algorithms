using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Algorithms
{
	//IN-PLACE quickSort
	public class QuickSort
	{
		private int [] _elements;
		private Random rnd = new Random();


		private int Partition (int[] A, int left, int right, int pivotIndex)
		{
			int pivotValue = A [pivotIndex];
			A [pivotIndex] = A [right];
			A [right] = pivotValue;

			int storeIndex = left;

			for (int i=left; i<right; i++) {
				if(A[i]<pivotValue)
				{
					var tmp = A[i];
					A[i]=A[storeIndex];
					A[storeIndex]=tmp;
					storeIndex++;
				}
			}
			var tmp2=A[storeIndex];
			A[storeIndex]=A[right];
			A[right]=tmp2;

			return storeIndex;
		}


		public void theQuickSort (int[] A, int left, int right)
		{
			if(A.Length<=1)
				return;

			if(left<right)
			{
				int pivotIndex = rnd.Next(left, right);

				int newPivotIndex=Partition(A, left, right, pivotIndex);

				theQuickSort(A, left, newPivotIndex-1);
				theQuickSort(A, newPivotIndex+1, right);
			}
		}


		public QuickSort (int[] input, int noElements)
		{
			_elements=input;

			Stopwatch stw=new Stopwatch();

			stw.Start();
			theQuickSort (_elements, 0, noElements-1);
			stw.Stop();

			/*foreach (var e in _elements) {
				Console.Write(e+", ");
			}
			Console.WriteLine();*/

			var sp = stw.ElapsedMilliseconds;
			Console.WriteLine(string.Format("Sorted {0} elements.", noElements));
			Console.WriteLine(string.Format("Time taken: {0}", sp));


		}
	}
}

