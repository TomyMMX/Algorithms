using System;
using System.Diagnostics;

namespace Algorithms
{
	public class HeapSort
	{
		// array of integers to hold values
		private int[] a;
		 
		// number of elements in array
		private int x;

		public HeapSort (int[] input, int noElements)
		{
			Stopwatch stw=new Stopwatch();

			a = input;
			x = noElements;

			stw.Start();
			sortArray();
			stw.Stop();

			/*foreach (var e in output) {
				Console.Write(e+", ");
			}
			Console.WriteLine();*/

			var sp = stw.ElapsedMilliseconds;
			Console.WriteLine(string.Format("Sorted {0} elements.", noElements));
			Console.WriteLine(string.Format("Time taken: {0}", sp));
		}

		 
		// Heap Sort Algorithm
		public void sortArray()
		{
		  int i;
		  int temp;
		 
		  for( i = (x/2)-1; i >= 0; i-- )
		  {
		    siftDown( i, x );
		  }
		 
		  for( i = x-1; i >= 1; i-- )
		  {
		    temp = a[0];
		    a[0] = a[i];
		    a[i] = temp;
		    siftDown( 0, i-1 );
		  }
		}
		 
		public void siftDown( int root, int bottom )
		{
		  bool done = false;
		  int maxChild;
		  int temp;
		 
		  while( (root*2 <= bottom) && (!done) )
		  {
		    if( root*2 == bottom )
		      maxChild = root * 2;
		    else if( a[root * 2] > a[root * 2 + 1] )
		      maxChild = root * 2;
		    else
		      maxChild = root * 2 + 1;
		 
		    if( a[root] < a[maxChild] )
		    {
		      temp = a[root];
		      a[root] = a[maxChild];
		      a[maxChild] = temp;
		      root = maxChild;
		    }
		    else
		    {
		      done = true;
		    }
		  }
		}
	}
}

