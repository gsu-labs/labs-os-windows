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
		public static string Complex(int a, int b)
		{
			if (a != 0)
			{
				if (b < 0)
					return (a).ToString() + (b).ToString() + "i";
				else if (b > 0)
					return (a).ToString() + "+" + (b).ToString() + "i";
				else
					return (a).ToString();
			}
			else
			{
				if (b != 0)
					return (b).ToString() + "i";
				else
					return "0";
			}
		}

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
			PathInput += "\\input.txt";
			PathOutput += "\\output.txt";

			StreamReader sr = new StreamReader(PathInput, Encoding.Default);
			string str = sr.ReadToEnd();
			sr.Close();
			sr.Dispose();

			String[] words = str.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

			using (StreamWriter sw = new StreamWriter(PathOutput, false, Encoding.Default))
			{
				str = str.Remove(0, 9);
				str += Complex(int.Parse(words[0]), int.Parse(words[1])) + " ";
				str += Complex(int.Parse(words[2]), int.Parse(words[3])) + " ";
				if (words[4] == "+")
				{
					addition addx = new addition();
					str += addx.add(int.Parse(words[0]), int.Parse(words[1]), int.Parse(words[2]), int.Parse(words[3]));
				}
				else if (words[4] == "-")
				{
					subtraction subx = new subtraction();
					str += subx.sub(int.Parse(words[0]), int.Parse(words[1]), int.Parse(words[2]), int.Parse(words[3]));
				}
				else
				{
					multiplication mulx = new multiplication();
					str += mulx.mul(int.Parse(words[0]), int.Parse(words[1]), int.Parse(words[2]), int.Parse(words[3]));
				}
				sw.Write(str);
			}
		}
	}
}
