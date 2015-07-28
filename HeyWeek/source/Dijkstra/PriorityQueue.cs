using System;
using System.Collections;
using System.Collections.Generic;

namespace HeyWeek{

	public class PriorityQueue <T> where T : IComparable<T> {
		private List<T> data;

		public PriorityQueue(){
			this.data = new List<T>();
		}

		public void Enqueue(T item){
			data.Add(item);
			int child = data.Count - 1;
			while(child > 0){
				int parent = (child - 1)/2;
				if(data[child].CompareTo(data[parent]) >= 0)
					break;

				Swap (child, parent);
				child = parent;
			}
			PrintQueueContent();
		}

		public T Dequeue(){
			if(data.Count <= 0)
				return default(T);

			int lastIndex = data.Count - 1;
			T	frontItem = data[0];
			data[0] = data[lastIndex];
			data.RemoveAt(lastIndex);
			--lastIndex;
			int parent = 0;
			while(true){
				int child = parent * 2 + 1;
				if(child > lastIndex) 
					break;

				int rightChild = child + 1;
				if(rightChild <= lastIndex && data[rightChild].CompareTo(data[child]) < 0)
					child = rightChild;

				if(data[parent].CompareTo(data[child]) <= 0)
					break;

				Swap (child, parent);
				parent = child;
			}

			PrintQueueContent();
			return frontItem;
		}
	
		public bool Empty(){
			return (data.Count == 0);
		}

		public int Count(){
			return data.Count;
		}

		public T Peek(){
			T frontItem = data[0];
			return frontItem;
		}

		public void Clear(){
			data.Clear();
		}

		// TODO: Check this method
		public bool Contains(T n){
			return data.Contains(n);
		}

		private void Swap(int i, int j){
			T tmp = data[i];
			data[i] = data[j];
			data[j] = tmp;
		}

		public void FullRefresh(){
			int child = data.Count - 1;
			while(child > 0){
				int parent = (child - 1)/2;
				if(data[child].CompareTo(data[parent]) >= 0)
					continue;
				
				Swap (child, parent);
				child = parent;
			}

			PrintQueueContent();
		}

		public void PrintQueueContent(){
			foreach(T n in data){
				Console.WriteLine(" | " +  (n as Node).cost);
			}
		}

	}
}
