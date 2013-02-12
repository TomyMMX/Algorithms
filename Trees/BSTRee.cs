using System;

namespace Algorithms.Trees
{
	public enum TraversalType{
		Pre,
		In, 
		Post
	}

	public class BSTRee<TValue>
	{
		public class Node
        {
                // node internal data
                //internal int level;
				internal Node parrent=null;
                internal Node [] children= new Node[2];
               
                // user data
                internal int key;
                internal TValue value;

                // constuctor for the sentinel node
                internal Node()
                {
                        //this.level = 0;
						this.children[0]=this;
						this.children[1]=this;
                }

                // constuctor for regular nodes (that all start life as leaf nodes)
                internal Node(int key, TValue value, Node parrent, Node air)
                {
                        //this.level = 1;
						this.children[0]=air;
						this.children[1]=air;
                        this.key = key;
                        this.value = value;
						this.parrent=parrent;
                }
        }

		Node root;
        Node air;

		public BSTRee ()
		{
			root = air = new Node();
		}

		public void insertNode (object key)
		{
			insertNode((int)key, (TValue)key);
		}

		public bool insertNode (int key, TValue val)
		{

			if (this.root == air) {
				this.root = new Node(key, val, null, air); //the root node
			} else {

				Node current = this.root;
				while(true){
					if(current.key==key)
						return false; //already exists

					int dirrection = current.key > key ? 0:1;

					if(current.children[dirrection]==air)
					{
						current.children[dirrection] = new Node(key, val, current, air);
						break;
					}
					current=current.children[dirrection];
				}
			}
			return true;
		}


		public Node ReturnNode (int key)
		{
			if (this.root == air) {
				return null;
			} else {

				Node current = this.root;
				while(true){
					if(current.key==key)
						return current;

					int dirrection = current.key > key ? 0:1;

					if(current.children[dirrection]==air)
					{
						return null;
					}
					current=current.children[dirrection];
				}
			}
		}

		public void PrintTreePostOrder()
		{
			prinTreeRecursive(root, TraversalType.Post);
			Console.Out.WriteLine();
		}

		public void PrintTreeInOrder()
		{
			prinTreeRecursive(root, TraversalType.In);
			Console.Out.WriteLine();
		}

		public void PrintTreePreOrder()
		{
			prinTreeRecursive(root, TraversalType.Pre);
			Console.Out.WriteLine();
		}

		private void prinTreeRecursive (Node root, TraversalType t)
		{
			if (root != air) {
				if(t==TraversalType.Pre)
					Console.Out.Write(root.key+" ");
				prinTreeRecursive(root.children[0],t);
				if(t==TraversalType.In)
					Console.Out.Write(root.key+" ");
				prinTreeRecursive(root.children[1],t);
				if(t==TraversalType.Post)
					Console.Out.Write(root.key+" ");

							
			}

		}
	}
}

