using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class subtraction
{
	public static string sub(int a1, int b1, int a2, int b2)
	{
		int a = a1 - a2;
		int b = b1 - b2;
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

	public string purpose()
	{
		return "subtraction";
	}
}
