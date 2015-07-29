using System;
using System.Collections.Generic;

namespace HeyWeek{
	class MainClass{
		public static void Main (string[] args){
			string inputData = FileIO.ReadTextFile("../../data/input.txt");

			NodeGraph graph = NodeGraph.Create(inputData);
			DijkstraWalker q = new DijkstraWalker(graph.GraphMap, graph.CostTable);

			if(q.Search(graph.Start, graph.Goal)){
				string theBestCost = q.BestCost.ToString();
				string thePath = "";
				List<Node> path = q.Path;
				for(int i = path.Count - 1; i >= 0; i--){ thePath += (i == 0 ? path[i].name : path[i].name + " -> "); }
				string content = string.Format("Best path cost: {0}\nPath: {1}", theBestCost, thePath);
				FileIO.WriteToFile(content, "../../data/output.txt");
			}else{
				Console.WriteLine(string.Format ("There is no path between {0} and {1}!", graph.Start.name, graph.Goal.name));
			}
		
		}
	}
}
