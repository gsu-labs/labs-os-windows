using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace calculator
{
	public partial class Form2 : Form
	{
		string additionPath = Directory.GetCurrentDirectory();
		string subtractionPath = Directory.GetCurrentDirectory();
		string multiplicationPath = Directory.GetCurrentDirectory();

		public Form2()
		{
			InitializeComponent();

			for (int i = 0; i < 3; i++)
			{
				additionPath = additionPath.Substring(0, additionPath.LastIndexOf("\\"));
				subtractionPath = subtractionPath.Substring(0, subtractionPath.LastIndexOf("\\"));
				multiplicationPath = multiplicationPath.Substring(0, multiplicationPath.LastIndexOf("\\"));
			}
			additionPath += "\\addition\\bin\\Debug\\addition.dll";
			subtractionPath += "\\subtraction\\bin\\Debug\\subtraction.dll";
			multiplicationPath += "\\multiplication\\bin\\Debug\\multiplication.dll";

			//@"C:/Users/Ikon/Desktop/Work/OS&SP/labs/addition/bin/Debug/addition.dll"
			//@"C:/Users/Ikon/Desktop/Work/OS&SP/labs/subtraction/bin/Debug/subtraction.dll"
			//@"C:/Users/Ikon/Desktop/Work/OS&SP/labs/multiplication/bin/Debug/multiplication.dll"

			if (!File.Exists(additionPath))
			{
				button1.Enabled = false;
			}
			if (!File.Exists(subtractionPath))
			{
				button2.Enabled = false;
			}
			if (!File.Exists(multiplicationPath))
			{
				button3.Enabled = false;
			}
		}

		public string Complex(int a, int b)
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

		private void button1_Click(object sender, EventArgs e)
		{
			button1.Enabled = true;
			button2.Enabled = true;
			button3.Enabled = true;
			try
			{
				if (textBox1.Text == "" || textBox2.Text == "")
					return;

				Assembly asm = Assembly.LoadFrom(additionPath);
				Type t = asm.GetType("addition", true, true);
				object obj = Activator.CreateInstance(t);
				MethodInfo add = t.GetMethod("add");
				Object res;

				MethodInfo purpose = t.GetMethod("purpose");
				Object purp;

				int a1 = int.Parse(textBox1.Text);
				int b1 = int.Parse(textBox2.Text);
				int a2 = int.Parse(textBox3.Text);
				int b2 = int.Parse(textBox4.Text);

				label4.Text = Complex(a1, b1);
				label5.Text = Complex(a2, b2);
				label1.Text = "+";

				purp = purpose.Invoke(obj, new object[] { });
				label6.Visible = true;
				label6.Text = purp.ToString();

				res = add.Invoke(obj, new object[] { a1, b1, a2, b2 });
				label3.Text = res.ToString();
			}
			catch (Exception ex)
			{
				label6.Visible = false;
				button1.Enabled = false;
				MessageBox.Show("Could not load DLL with addition function or input error");
			}
		}

		private void button2_Click(object sender, EventArgs e)
		{
			button1.Enabled = true;
			button2.Enabled = true;
			button3.Enabled = true;
			try
			{
				if (textBox1.Text == "" || textBox2.Text == "")
					return;

				Assembly asm = Assembly.LoadFrom(subtractionPath);
				Type t = asm.GetType("subtraction", true, true);
				object obj = Activator.CreateInstance(t);
				MethodInfo sub = t.GetMethod("sub");
				Object res;

				MethodInfo purpose = t.GetMethod("purpose");
				Object purp;

				int a1 = int.Parse(textBox1.Text);
				int b1 = int.Parse(textBox2.Text);
				int a2 = int.Parse(textBox3.Text);
				int b2 = int.Parse(textBox4.Text);

				label4.Text = Complex(a1, b1);
				label5.Text = Complex(a2, b2);
				label1.Text = "-";

				purp = purpose.Invoke(obj, new object[] { });
				label6.Visible = true;
				label6.Text = purp.ToString();

				res = sub.Invoke(obj, new object[] { a1, b1, a2, b2 });
				label3.Text = res.ToString();
			}
			catch (Exception ex)
			{
				label6.Visible = false;
				button2.Enabled = false;
				MessageBox.Show("Could not load DLL with subtraction function or input error");
			}
		}

		private void button3_Click(object sender, EventArgs e)
		{
			button1.Enabled = true;
			button2.Enabled = true;
			button3.Enabled = true;
			try
			{
				if (textBox1.Text == "" || textBox2.Text == "")
					return;

				Assembly asm = Assembly.LoadFrom(multiplicationPath);
				Type t = asm.GetType("multiplication", true, true);
				object obj = Activator.CreateInstance(t);
				MethodInfo mul = t.GetMethod("mul");
				Object res;

				MethodInfo purpose = t.GetMethod("purpose");
				Object purp;

				int a1 = int.Parse(textBox1.Text);
				int b1 = int.Parse(textBox2.Text);
				int a2 = int.Parse(textBox3.Text);
				int b2 = int.Parse(textBox4.Text);

				label4.Text = Complex(a1, b1);
				label5.Text = Complex(a2, b2);
				label1.Text = "*";

				purp = purpose.Invoke(obj, new object[] { });
				label6.Visible = true;
				label6.Text = purp.ToString();

				res = mul.Invoke(obj, new object[] { a1, b1, a2, b2 });
				label3.Text = res.ToString();
			}
			catch (Exception ex)
			{
				label6.Visible = false;
				button3.Enabled = false;
				MessageBox.Show("Could not load DLL with multiplication function or input error");
			}
		}
	}
}
