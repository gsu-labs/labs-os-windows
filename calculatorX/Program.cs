using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace calculatorX
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.SetWindowSize(40, 10);
			string PathInput = Directory.GetCurrentDirectory();
			string PathOutput = Directory.GetCurrentDirectory();

			for (int i = 0; i < 3; i++)
			{
				PathInput = PathInput.Substring(0, PathInput.LastIndexOf("\\"));
				PathOutput = PathOutput.Substring(0, PathOutput.LastIndexOf("\\"));
			}

			PathInput = "\\input.txt";
			PathOutput = "\\output.txt";

			StreamReader sr = new StreamReader(PathInput, Encoding.Default);
			string input = sr.ReadToEnd();
			sr.Close();
			sr.Dispose();

			String[] words = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

			using (StreamWriter sw = new StreamWriter(PathOutput, false, Encoding.Default))
			{
				if (words[4] == "+")
				{
					input = input.Remove(0, 1);
					addition additionX = new addition();
					sw.Write(additionX.add(int.Parse(words[0]), int.Parse(words[1]), 
											int.Parse(words[2]), int.Parse(words[3])));
				}
				else if (words[4] == "-")
				{
					input = input.Remove(0, 1);
					subtraction subtractionX = new subtraction();
					sw.Write(subtractionX.sub(int.Parse(words[0]), int.Parse(words[1]),
											int.Parse(words[2]), int.Parse(words[3])));
				}
				else
				{
					input = input.Remove(0, 1);
					multiplication multiplicationX = new multiplication();
					sw.Write(multiplicationX.mul(int.Parse(words[0]), int.Parse(words[1]),
											int.Parse(words[2]), int.Parse(words[3])));
				}
			}
		}
	}
}
