using System;
using System.Collections.Generic;

namespace Algorithms
{
	public class Lottery
	{
		class OneLottery : IComparable<OneLottery>
		{
			public string Name;
			public long WinOptions;

			public int CompareTo (OneLottery obj)
			{
				if(((OneLottery)obj).WinOptions>this.WinOptions)
					return -1;
				else if(((OneLottery)obj).WinOptions<this.WinOptions)
					return 1;
				else
				{
					return this.Name.CompareTo(((OneLottery)obj).Name);
				}
			}
		}


		public Lottery ()
		{

		}


		public string[] sortByOdds (string[] rules)
		{
			if(rules.Length==0)
				return new string[0];

			List<OneLottery> results = new List<OneLottery>();

			for (int i=0; i<rules.Length; i++) {
				results.Add(getLoteryOptions (rules [i]));			
			}

			results.Sort();
			string[] outResults = new string[rules.Length];

			for (int i=0; i<rules.Length; i++) {
				outResults[i]=results[i].Name;
			}

			return outResults;
		}

		private OneLottery getLoteryOptions (string str)
		{
			int noOptions=0;
			int noBlanks=0;
			bool sorted=false;
			bool unique=false;

			OneLottery current = new OneLottery ();
			current.Name = str.Substring (0, str.IndexOf (":"));

			string [] parts = str.Substring (str.IndexOf (": ") + 1).Split (new char[]{' '}, StringSplitOptions.RemoveEmptyEntries);

			for (int i=0; i<parts.Length; i++) {
				if(i==0)
					noOptions=int.Parse(parts[i]);
				else if(i==1)
					noBlanks=int.Parse(parts[i]);
				else if(i==2)
					sorted=parts[i].Equals("T");
				else if(i==3)
					unique=parts[i].Equals("T");
			}


			if(!sorted&&!unique)
				current.WinOptions=(long)Math.Pow(noOptions,noBlanks);
			else if(sorted&&unique)
				current.WinOptions=GetBinCoeff(noOptions, noBlanks);
			else if(!sorted&&unique)
				current.WinOptions=GetBinCoeff(noOptions, noBlanks)*factorial(noBlanks);
			else
				current.WinOptions=GetBinCoeff(noOptions+noBlanks-1, noBlanks); //Stanley's symbol

			return current;
		}


		private long factorial(long N)
		{
		    if (N == 0) return 1;
		    long t = N;
		    while(N-- > 2) t *= N;
		    return t;
		}

		private long GetBinCoeff(long N, long K)
		{
		   long r = 1;
		   long d;
		   if (K > N) return 0;
		   for (d = 1; d <= K; d++)
		   {
		      r *= N--;
		      r /= d;
		   }
		   return r;
		}
	}
}

