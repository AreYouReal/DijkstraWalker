/**
*	DijkstraWalker class use on of the Dijkstra's algorithm variation.
*	Search the shortest path in @graph according to the @costTable.
*	@author Alexander Kolesnikov
*
*	email: viertual@gmail.com
*/
using System;
using System.Collections.Generic;

namespace HeyWeek{

	public enum SearchState{ NONE, STILL_SEARCH, REACHED_THE_GOAL, UNABLE_TO_REACH}

	public class DijkstraWalker{

		#region Fields
		private List<Node> 					graph;
		private Dictionary<NodePair, int> 	costTable;
		private Node 						goal;
		private List<Node> 					thePath;
		private int							bestCost;
		#endregion

		#region Properties
		public int 			BestCost { get{ return bestCost;}}
		public List<Node> 	Path	 { get{ return thePath; }}
		#endregion

		#region Constructor
		public DijkstraWalker(List<Node> g, Dictionary<NodePair, int> ct){
			graph = g;
			costTable = ct;
		}
		#endregion

		#region Public
		public bool Search(Node start, Node goal){
			this.goal = goal;
			PriorityQueue<Node> open = new PriorityQueue<Node>();
			start.parent 	= null;
			start.cost 		= 0;
			open.Enqueue(graph[graph.IndexOf(start)]);


			while(!open.Empty()){
				SearchState currentState = Step (open);
				if( currentState == SearchState.REACHED_THE_GOAL){
					return true;
				}
			}

			return false;
		}
		#endregion

		#region Helpers(Private)
		private SearchState Step(PriorityQueue<Node> open){
			Node n, child;
			n = open.Dequeue();
			n.visited = true;
			if(n.Equals(goal)){
				thePath = MakePath(n);
				bestCost = n.cost;
				return SearchState.REACHED_THE_GOAL;
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
			return SearchState.STILL_SEARCH;
		}

		private int Cost(Node n1, Node n2){
			NodePair np = new NodePair(n1, n2);
			if(costTable.ContainsKey(np)) return costTable[np];
			else Console.WriteLine("Error: Unable to find path cost!");

			return -1;
		}

		private List<Node> MakePath(Node goal){
			Node n = goal.parent;
			List<Node> path = new List<Node>();
			path.Add(goal);
			while(n != null){
				path.Add(n);
				n = n.parent;
			}
			return path;
		}
		#endregion

	}
}

