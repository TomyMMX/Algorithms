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

		public HeapSort (int[] input, int noElements, bool what)
		{
			Stopwatch stw=new Stopwatch();

			a = input;
			x = noElements;

			stw.Start();
			sortArray2();
			stw.Stop();

			/*foreach (var e in output) {
				Console.Write(e+", ");
			}
			Console.WriteLine();*/

			var sp = stw.ElapsedMilliseconds;
			Console.WriteLine(string.Format("Sorted {0} elements.", noElements));
			Console.WriteLine(string.Format("Time taken: {0}", sp));
		}

		 
	
		public void sortArray2()
		{
		  int i;
		  int temp;
		 
		  for( i = (x/2)-1; i >= 0; i-- )
		  {
		    jsw_do_heap(a, i, x);
		  }
		 
		  for( i = x-1; i >= 1; i-- )
		  {
		    temp = a[0];
		    a[0] = a[i];
		    a[i] = temp;
		    jsw_do_heap(a, 0, i-1);
		  }
		}
			 

		 void jsw_do_heap ( int [] a, int i, int n )
		 {
		    int k = i * 2 + 1;
		    int save = a[i];
		  
		    while ( k < n ) {
		      if ( k + 1 < n && a[k] < a[k + 1] )
		        ++k;
		  
		     if ( save >= a[k] )
		       break;
		 
		     a[i] = a[k];
		     i = k;
		     k = i * 2 + 1;
				//k=++i * 2 + 1;
		   }
		 
		   a[i] = save;
		 }
	}
}

