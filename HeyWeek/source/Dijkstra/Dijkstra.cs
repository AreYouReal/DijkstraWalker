using System;

namespace HeyWeek{

	public class Dijkstra{

		public static bool Search(Node start, Node goal){
			PriorityQueue<Node> open;
			Node n, child;
	
			start.parent 	= null;
			start.cost 		= 0;

			open.Enqueue(start);
			while(!open.Empty()){
				n = open.Dequeue();
				n.visited = true;
				if(n.Equals(goal)){
					//MakePath();
					return true;
				}

				while(n.HasMoreChildren){
					child = n.GetNextChildren();
					int newCost = n.cost + Cost(n, child);
					if(child.visited) continue;
					if(open.Contains(child) && child.cost <= newCost) continue;
					child.parent = n;
					child.cost = newCost;
					if(!open.Contains(child)) open.Enqueue(child);
					else open.FullRefresh();
				}
			}

			return false;
		}



		private static int Cost(Node n1, Node n2){
			return -1;
		}
	}
}

