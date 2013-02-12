using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace Algorithms.HashTable
{
	public class DuplicateKeyException : Exception{

	}

	public class ElementNotFoundException : Exception{

	}


	public class HTable<Tkey, TValue>
	{

		class ListElement
		{
			public bool isEnd;
			public Tkey key;
			public TValue value;
			public ListElement next;

			public ListElement(Tkey key, TValue value, ListElement end=null)
			{
				this.key=key;
				this.value=value;
				next=end;
			}

			public void makeEnd ()
			{
				this.isEnd=true;
			}
		}

		private int count=0;
		private int size=0;
		private ListElement [] tableArray;
		private ListElement end;

		public HTable(int size=31)
		{
			end = new ListElement(default(Tkey), default(TValue));
			end.makeEnd();

			tableArray = new ListElement[size];
			this.size=size;
		}

		public bool Add (Tkey key, TValue value)
		{
			uint bucketNo = getBucketNumber (key);

			if (tableArray [bucketNo] == null)
				tableArray [bucketNo] = new ListElement (key, value, end);
			else {

				ListElement current=tableArray[bucketNo];
				while(true)
				{
					if(current.key.Equals(key))
					{
						//duplicate key
						throw new DuplicateKeyException();
					}
					else if(current.next==end)
					{
						current.next=new ListElement(key, value, end);
						break;
					}
					current=current.next;
				}				
			}
			count++;
			return true;
		}

		public TValue GetValue (Tkey key)
		{
			uint bucketNo = getBucketNumber (key);
			if (tableArray [bucketNo] != null){
				ListElement current=tableArray[bucketNo];
				while(true)
				{
					if(current.key.Equals(key))
					{
						return current.value;
					}
					else if(current.next==end)
					{
						break;
					}
					current=current.next;
				}				
			}
			throw new ElementNotFoundException();
		}


		public void PrintTable ()
		{
			for(int i=0;i<size;i++) {
				Console.Out.Write(i+": ");
				if(tableArray[i]!=null)
				{
					ListElement current=tableArray[i];
					while(true)
					{
						if(current!=end)
						{
							Console.Out.Write(current.key+", ");
						}
						else
							break;

						current=current.next;
					}			
				}
				Console.Out.WriteLine();
			}		
		}


		private uint getBucketNumber(Tkey key)
		{
			byte [] p = ObjectToByteArray(key);
			int len = p.Length;

			//FNV hash
			uint h = 2166136261;
   			int i;

			for ( i = 0; i < len; i++ )
     			 h = ( h * 16777619 ) ^ (uint)p[i];

  			return (uint)(h % size);
		}



		private byte[] ObjectToByteArray(Object obj)
		{
		    if(obj == null)
		        return null;
		    BinaryFormatter bf = new BinaryFormatter();
		    MemoryStream ms = new MemoryStream();
		    bf.Serialize(ms, obj);
		    return ms.ToArray();
		}
	}
}

