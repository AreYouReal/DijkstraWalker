/**
*	Node class. Node represent the graph's vertex.
*	Implements the IComparable interface. 
*	@author Alexander Kolesnikov
*
*	email: viertual@gmail.com
*/
using System;
using System.Collections.Generic;

namespace HeyWeek{

	public class Node : IComparable<Node>{
	
		#region Fields
		public string name;

		public int	cost;
		public bool visited = false;

		public Node parent;
		public Stack<Node> children;

		#endregion

		#region Properties
		public bool HasMoreChildren{
			get{ return children.Count > 0; }
		}
		#endregion

		#region Constructor
		public Node (){
			children = new Stack<Node>();
		}
		#endregion

		#region Public
		public Node GetNextChildren(){
			if(children.Count > 0) return children.Pop();
			return null;
		}
		#endregion

		#region IComparable Interface implementation
		public int CompareTo (Node other){
			return this.cost.CompareTo(other.cost);
		}
		#endregion

		#region Overrides
		public override bool Equals (object obj){
			Node other = obj as Node;
			return name.Equals(other.name);
		}

		public override int GetHashCode (){
			return name.GetHashCode();
		}

		public override string ToString (){
			string childrenStr = "";
			foreach(Node n in children){
				childrenStr += " | " + n.name;
			}
			return string.Format ("[Node] {0} -> {1}", name, childrenStr );
		}
		#endregion
	}
}

