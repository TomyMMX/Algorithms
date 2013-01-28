using System;
using System.Diagnostics;
using System.Collections.Generic;

namespace Algorithms
{
	class MainClass
	{

		private static Stopwatch stw=new Stopwatch();

		public static void Main (string[] args)
		{
			Random rnd = new Random();
			int noElements=100000;


			var _elements = new int[noElements];
			for (int i=0; i<noElements; i++) {
				_elements [i] = rnd.Next (noElements*2);
				//_elements [i] = 1;
			}	


			var _elements2=new int[noElements];
			Array.Copy(_elements, _elements2, noElements);
			var _elements3=new int[noElements];
			Array.Copy(_elements, _elements3, noElements);
			var _elements4=new int[noElements];
			Array.Copy(_elements, _elements4, noElements);


			
			Console.WriteLine ("Hello .NET Sort!");
			stw.Start();
			Array.Sort(_elements3);
			stw.Stop();
			var sp = stw.ElapsedMilliseconds;
			Console.WriteLine(string.Format("Sorted {0} elements.", noElements));
			Console.WriteLine(string.Format("Time taken: {0}", sp));

			Console.WriteLine ("Hello MergeSort!");
			MergeSort ms = new MergeSort(_elements2, noElements);

			Console.WriteLine ("Hello QuickSort!");
			QuickSort qs = new QuickSort(_elements, noElements);

			Console.WriteLine ("Hello HeapSort!");
			HeapSort hs = new HeapSort(_elements, noElements);
		}
	}
}
