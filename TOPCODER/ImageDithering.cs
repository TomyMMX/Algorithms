using System;
using System.Collections.Generic;

namespace Algorithms
{
	public class ImageDithering
	{
		public ImageDithering ()
		{
		}

		public int count (String dithered, String[] screen)
		{
			Dictionary<char, char> charsInColor = new Dictionary<char, char> (dithered.Length * 2);
			//Dictionary<char, char> usedChars = new Dictionary<char, char> (dithered.Length * 2);

			for (int i=0; i<dithered.Length; i++) {
				charsInColor.Add(dithered[i], dithered[i]);
			}

			int totalPixelCount = 0;

			for (int i=0; i<screen.Length; i++) {
				int currentCount=0;
				for(int j=0; j<screen[i].Length;j++)
				{
					char c;
					if(charsInColor.TryGetValue(screen[i][j], out c))
					{
						totalPixelCount++;										
					}
				}
			
			}

			return totalPixelCount;
		}
	}
}

