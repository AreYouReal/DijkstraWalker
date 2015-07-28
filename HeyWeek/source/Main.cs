using System;

namespace HeyWeek{
	class MainClass{
		public static void Main (string[] args){
			string inputData = FileIO.ReadTextFile("../../data/input.txt");



			NodeGraph.Create(inputData);
		
		}
	}
}
