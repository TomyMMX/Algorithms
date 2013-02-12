using System;
using System.Collections.Generic;

namespace Algorithms
{
	public class Employee : IComparable<Employee>{
		public int No;
		public int Points;
		public int Bonus;

		public int CompareTo (Employee obj)
		{
			if(((Employee)obj).Points>this.Points)
					return 1;
			else if(((Employee)obj).Points<this.Points)
				return -1;
			else
			{
				if(((Employee)obj).No>this.No){
					return -1;
				}
				else if(((Employee)obj).No<this.No)
				{
					return 1;
				}

				return 0;
			}
		}
	}


	public class Bonuses
	{

		public Bonuses ()
		{
		}

		public int[] getDivision (int[] points)
		{
			int totalPoints = 0;
			int bonusGiven = 0;

			List<Employee> workers = new List<Employee> ();

			for (int i=0; i<points.Length; i++) {
				totalPoints += points [i];
				Employee e = new Employee ();
				e.No = i;
				e.Points = points [i];

				workers.Add (e);
			}
			workers.Sort ();

			foreach (var e in workers) {
				e.Bonus = (int)Math.Floor (((decimal)e.Points / totalPoints) * 100);
				bonusGiven += e.Bonus;
			}

			int bonusLeft = 100 - bonusGiven;

			for (int i=0; i<points.Length; i++) {
				if(bonusLeft>0)
				{
					workers[i].Bonus+=1;
					bonusLeft--;
				}

				points[workers[i].No]=workers[i].Bonus;
			}

			return points;
		}
	}
}

