using System;
using System.Collections.Generic;

namespace HeyWeek{

	public class NodeGraph{

		#region Fields
		public Node start;
		public Node	goal;

		public Dictionary<NodePair, int> costTable = new Dictionary<NodePair, int>();
		public List<Node> graphNodes = new List<Node>();
		#endregion

		#region Static (Create)
		public static NodeGraph Create(string content){
			NodeGraph graph = new NodeGraph();

			string[] lines = content.Split(Environment.NewLine.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
			string [] startGoal = lines[0].Split(new char[]{' ', '\t'}, StringSplitOptions.RemoveEmptyEntries);
			graph.start = new Node(){name = startGoal[0]};
			graph.goal = new Node(){name = startGoal[1]};

			for(int i = 1; i < lines.Length; i++){
				string [] data = lines[i].Split(new char[]{' ', '\t'}, StringSplitOptions.RemoveEmptyEntries);
				string 	name_1 	= data[0];
				string 	name_2 	= data[1];
				int		cost  	= int.Parse(data[2]);
				graph.AddToCostTable(name_1, name_2, cost);
				graph.AddToGraphList(name_1, name_2);
			}


			foreach(KeyValuePair<NodePair, int> kvp in graph.costTable){
				Console.WriteLine(kvp.Key.ToString() + "\t" + kvp.Value.ToString());
			}
			Console.WriteLine();
			foreach(Node n in graph.graphNodes){
				Console.WriteLine(n.ToString());
			}

			return graph;
		}
		#endregion

		#region Helpers
		private void AddToCostTable(string name_1, string name_2, int cost){
			NodePair nPair = new NodePair(name_1, name_2);
			if(!costTable.ContainsKey(nPair)){
				costTable.Add(nPair, cost);
			}else{
				Console.WriteLine("ERROR: Several roads between the same cities!");
			}
		}

		private void AddToGraphList(string name_1, string name_2){
			Node n1 = new Node(){name = name_1};
			Node n2 = new Node(){name = name_2};

			int index1 = graphNodes.IndexOf(n1);
			int index2 = graphNodes.IndexOf(n2);
			Console.WriteLine("index1: " + index1);
			Console.WriteLine("index2: " + index2);
			if(index1 < 0){
				if(index2 < 0){
					graphNodes.Add(n1);
					graphNodes.Add(n2);
					if(!n1.children.Contains(n2)) n1.children.Push(n2);
				}else{
					graphNodes.Add(n1);
					n1.children.Push(graphNodes[index2]);
				}
			}else{
				if(index2 < 0){
					graphNodes.Add(n2);
					if(!graphNodes[index1].children.Contains(n2)) graphNodes[index1].children.Push(n2);
				}else{
					if(!graphNodes[index1].children.Contains(graphNodes[index2])) graphNodes[index1].children.Push(graphNodes[index2]);
				}
			}

		}
		#endregion

	}
}

