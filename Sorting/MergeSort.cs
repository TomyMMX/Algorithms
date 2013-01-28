using System;
using System.Diagnostics;

namespace Algorithms
{
	public class MergeSort
	{
		private int[] mergeSort (int[] M)
		{
			if(M.Length<=1)
				return M;

			int middle = M.Length/2;
			int[] left=new int[middle];
			int[] right=new int[M.Length-middle];

			int middleValue=M[middle];

			for(int i=0;i<middle;i++)
				left[i]=M[i];
			for(int i=middle;i<M.Length;i++)
				right[i-middle]=M[i];

			left=mergeSort(left);
			right=mergeSort(right);

			return merge(left, right);
		}

		private int[] merge (int[]left, int[]right)
		{
			int [] result = new int[left.Length + right.Length];

			int leftCount = left.Length;
			int rightCount = right.Length;

			int leftHead = 0;
			int rightHead = 0;

			while (rightCount>0||leftCount>0) {
				if(rightCount>0&&leftCount>0)
				{
					if(left[leftHead]<=right[rightHead])
					{
						result[leftHead+rightHead]=left[leftHead];
						leftHead++;
						leftCount--;
					}
					else{
						result[leftHead+rightHead]=right[rightHead];
						rightHead++;
						rightCount--;
					}
				}
				else if(leftCount>0)
				{
					result[leftHead+rightHead]=left[leftHead];
					leftHead++;
					leftCount--;
				}
				else if(rightCount>0)
				{
					result[leftHead+rightHead]=right[rightHead];
					rightHead++;
					rightCount--;
				}
			}

			return result;
		}

		public MergeSort (int[] input, int noElements)
		{
			Stopwatch stw=new Stopwatch();

			stw.Start();
			var output=mergeSort (input);
			stw.Stop();

			/*foreach (var e in output) {
				Console.Write(e+", ");
			}
			Console.WriteLine();*/

			var sp = stw.ElapsedMilliseconds;
			Console.WriteLine(string.Format("Sorted {0} elements.", noElements));
			Console.WriteLine(string.Format("Time taken: {0}", sp));
		}
	}
}

