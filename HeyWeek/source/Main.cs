using System;

namespace HeyWeek{
	class MainClass{
		public static void Main (string[] args){
			string inputData = FileIO.ReadTextFile("../../data/input.txt");

			NodeGraph graph = NodeGraph.Create(inputData);
			Dijkstra q = new Dijkstra(graph.graphNodes, graph.costTable);
			q.Search(graph.start, graph.goal);
		}
	}
}
