using System;
using System.Diagnostics;
using System.Collections.Generic;
using Algorithms.Trees;
using Algorithms.HashTable;


namespace Algorithms
{
	class MainClass
	{

		private static Stopwatch stw=new Stopwatch();
		private static Random random = new Random();

		public static void Main (string[] args)
		{
		/*	HTable<string, int> ht = new HTable<string, int>(37);

			int noElements=15;
			Random rnd = new Random();
			var _elements = new int[noElements];
			for (int i=0; i<noElements; i++) {
				_elements [i] = rnd.Next (noElements*100);
				//_elements [i] = 1;
			}	

			foreach (var e in _elements) {
				try{
					ht.Add(getRandomString(), e);
				}
				catch{}
			}

			ht.Add("tomaz", 99999);


			ht.PrintTable();
			Console.Out.WriteLine("tomaz: "+ht.GetValue("tomaz"));*/

			//sorting();

			/*BinaryCode bc = new BinaryCode();
			bc.decode("12221112222221112221111111112221111");*/


			/*Lottery l = new Lottery();

			string [] rules = new string[]{"INDIGO: 93 8 T F",
 "ORANGE: 29 8 F T",
 "VIOLET: 76 6 F F",
 "BLUE: 100 8 T T",
 "RED: 99 8 T T",
 "GREEN: 78 6 F T",
 "YELLOW: 75 6 F F"};

			l.sortByOdds(rules);

*/

			/*Bonuses b = new Bonuses();
			b.getDivision(new int[]{485, 324, 263, 143, 470, 292, 304, 188, 100, 254, 296,
 255, 360, 231, 311, 275,  93, 463, 115, 366, 197, 470});*/


			ImageDithering id = new ImageDithering();
			id.count("ACEGIKMOQSUWY", new string[]{"ABCDEFGHIJKLMNOPQRSTUVWXYZABCDEFGHIJKLMNOPQRSTUVWX",
 "ABCDEFGHIJKLMNOPQRSTUVWXYZABCDEFGHIJKLMNOPQRSTUVWX",
 "ABCDEFGHIJKLMNOPQRSTUVWXYZABCDEFGHIJKLMNOPQRSTUVWX",
 "ABCDEFGHIJKLMNOPQRSTUVWXYZABCDEFGHIJKLMNOPQRSTUVWX",
 "ABCDEFGHIJKLMNOPQRSTUVWXYZABCDEFGHIJKLMNOPQRSTUVWX",
 "ABCDEFGHIJKLMNOPQRSTUVWXYZABCDEFGHIJKLMNOPQRSTUVWX"});

		}


		private static string getRandomString ()
		{
			var chars = "ABCČDEFGHIJKLMNOPQRSSTUVWXYZŽ0123456789";

			var stringChars = new char[8];
			for (int i = 0; i < stringChars.Length; i++)
			{
			    stringChars[i] = chars[random.Next(chars.Length)];
			}

			return new String(stringChars);
		}

		private static void trees ()
		{
			BSTRee<int> tree = new BSTRee<int>();

			tree.insertNode(5);
			tree.PrintTreePostOrder();
			tree.insertNode(2);
			tree.PrintTreePostOrder();
			tree.insertNode(8);
			tree.PrintTreePostOrder();
			tree.insertNode(4);
			tree.PrintTreePostOrder();
			tree.insertNode(9);
			tree.PrintTreePostOrder();
			tree.insertNode(3);
			tree.PrintTreePostOrder();
			tree.insertNode(1);
			tree.PrintTreePostOrder();


			tree.PrintTreePreOrder();
			tree.PrintTreeInOrder();
			tree.PrintTreePostOrder();
		}

		private static void sorting()
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


			
			/*Console.WriteLine ("Hello .NET Sort!");
			stw.Start();
			Array.Sort(_elements3);
			stw.Stop();
			var sp = stw.ElapsedMilliseconds;
			Console.WriteLine(string.Format("Sorted {0} elements.", noElements));
			Console.WriteLine(string.Format("Time taken: {0}", sp));

			Console.WriteLine ("Hello MergeSort!");
			MergeSort ms = new MergeSort(_elements2, noElements);

			Console.WriteLine ("Hello QuickSort!");
			QuickSort qs = new QuickSort(_elements, noElements);*/

			Console.WriteLine ("Hello HeapSort!");
			HeapSort hs = new HeapSort(_elements, noElements, true);

			HeapSort hs2 = new HeapSort(_elements2, noElements, false);
		}
	}
}
