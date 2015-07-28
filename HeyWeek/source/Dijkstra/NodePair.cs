using System;

namespace HeyWeek{
	
	public class NodePair{
		public string[] names;

		public NodePair (string nName1, string nName2){
			names = new string[2];
			names[0] = nName1;
			names[1] = nName2;
		}

		public override bool Equals (object obj){
			NodePair other = obj as NodePair;
			return ( other.names[0].Equals(names[0]) && other.names[1].Equals(names[1]) );
		}

		public override int GetHashCode (){
			return (names[0].GetHashCode() + names[1].GetHashCode());
		}

		public override string ToString (){
			return string.Format ("[NodePair] From {0} To {1}", names[0], names[1]);
		}

	}


}

