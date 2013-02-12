using System;
using System.Text;

namespace Algorithms
{
	//SRM 144 DIV1 - 300
	public class BinaryCode
	{
		public BinaryCode ()
		{
		}

		public string[] decode (string message)
		{
			int [] messageIntArray = getIntArrayFromString(message);

			string[] decodedStrings = new string[2];
			decodedStrings [0] = doDecode(0, messageIntArray);
			decodedStrings [1] = doDecode(1, messageIntArray);

			return decodedStrings;
		}

		private int[] getIntArrayFromString (string message)
		{
			int[] outArray= new int[message.Length];
			for (int i=0; i<message.Length; i++) {
				outArray [i] = int.Parse (message [i].ToString ());
			}

			return outArray;
		}

		private string intArrayToString (int[] decoded)
		{
			StringBuilder sb = new StringBuilder();
			for(int i=0;i<decoded.Length;i++)
			{
				sb.Append(decoded[i].ToString());
			}
			return sb.ToString();
		}

		private string doDecode (int first, int[] message)
		{
			if (message.Length == 1) {
				if (message [0] != first) 
					return "NONE";
			}

			int[] decoded = new int [message.Length];
			decoded [0] = first;

			for (int i=1; i<message.Length; i++) {
				decoded [i] = message [i - 1] - decoded [i - 1];
				if (i - 2 >= 0)
					decoded [i] -= decoded [i - 2];
				if (decoded [i] < 0 || decoded [i] > 1) 
					return "NONE";
			}

			if (message.Length > 1) {
				if (message [message.Length - 1] != decoded [message.Length - 1] + decoded [message.Length - 2]) {
					return "NONE";
				}	
			}

			return intArrayToString(decoded);
		}
	}
}

