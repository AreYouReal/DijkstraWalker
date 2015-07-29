using System;
using System.Collections.Generic;

namespace HeyWeek{

	public class Dijkstra{

		private List<Node> graph;
		private Dictionary<NodePair, int> costTable;

		private List<Node> theShortestPath;

		private Node start;
		private Node goal;

		public Dijkstra(List<Node> g, Dictionary<NodePair, int> ct){
			graph = g;
			costTable = ct;
		}

		public bool Search(Node start, Node goal){
			this.start = start;
			this.goal = goal;
			PriorityQueue<Node> open = new PriorityQueue<Node>();
			Node n, child;
	
			start.parent 	= null;
			start.cost 		= 0;

			open.Enqueue(graph[graph.IndexOf(start)]);
			while(!open.Empty()){
				n = open.Dequeue();
				n.visited = true;
				if(n.Equals(goal)){
					theShortestPath = MakePath();
					Console.WriteLine("Goal has reached!");
					return true;
				}

				while(n.HasMoreChildren){
					child = n.GetNextChildren();
					if(child.visited) continue;
					int newCost = n.cost + Cost(n, child);
					if(open.Contains(child) && child.cost <= newCost) continue;
					child.parent = n;
					child.cost = newCost;
					if(!open.Contains(child)) open.Enqueue(child);
					else open.FullRefresh();
				}
			}

			return false;
		}

		private int Cost(Node n1, Node n2){
			NodePair np = new NodePair(n1, n2);
			if(costTable.ContainsKey(np)) return costTable[np];
			else Console.WriteLine("Error: Unable to find path cost!");

			return -1;
		}

		private List<Node> MakePath(){
			Node n = goal.parent;
			theShortestPath = new List<Node>();

			theShortestPath.Add(goal);
			while(n != null){
				theShortestPath.Add(n);
			}

			foreach(Node nd in theShortestPath){
				Console.Write (nd.name + " --> ");
			}
			Console.WriteLine("Making path");
			return null;
		}
	}
}

