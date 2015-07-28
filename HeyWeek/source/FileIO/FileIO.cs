using System;
using System.IO;
namespace HeyWeek{
	public class FileIO{

		public static string ReadTextFile(string path){
			string fileContent = null;
			try{
				using(StreamReader reader = new StreamReader(path)){
					fileContent = reader.ReadToEnd();
				}
			}catch(Exception e){ Console.WriteLine(e.Message); }
			return fileContent;
		}

		public static bool WriteToFile(string content, string path){
			try{
				using(StreamWriter writer = new StreamWriter(path)){
					writer.WriteLine(content);
				}
			}catch(Exception e){ Console.WriteLine(e.Message);
				return false;
			}
			return true;
		}

	}
}


