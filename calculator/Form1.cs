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
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace calculator
{
	public partial class Form1 : Form
	{
		[DllImport("User32.dll")]
		public static extern IntPtr GetWindow(IntPtr hndl, uint k);
		[DllImport("Shell32.dll")]
		public static extern IntPtr ShellExecuteA(IntPtr hwnd, string lpOperation, string lpFile, string lpParameters, string lpDirecotry, int nShowCmd);

		[DllImport("Kernel32.dll")]
		public static extern bool GetExitCodeProcess(IntPtr hwnd, out uint ExitCode);

		string PathInput = Directory.GetCurrentDirectory();
		string PathOutput = Directory.GetCurrentDirectory();

		string ClacPath = Directory.GetCurrentDirectory();

		public Form1()
		{
			InitializeComponent();

			for (int i = 0; i < 3; i++)
			{
				PathInput = PathInput.Substring(0, PathInput.LastIndexOf("\\"));
				PathOutput = PathOutput.Substring(0, PathOutput.LastIndexOf("\\"));
				ClacPath = ClacPath.Substring(0, ClacPath.LastIndexOf("\\"));
			}

			PathInput += "\\input.txt";
			PathOutput += "\\output.txt";
			ClacPath += "\\calculatorX\\bin\\Debug\\calculatorX.exe";
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

		public void GetComplex()
		{
			if (textBox1.Text == "" || textBox2.Text == "" ||
				textBox3.Text == "" || textBox4.Text == "")
				return;

			string request = "";
			request = textBox1.Text + " " + textBox2.Text + " " + textBox3.Text + " " + textBox4.Text;
			request += " " + label1.Text;

			using (StreamWriter sw = new StreamWriter(PathInput, false, Encoding.Default))
			{
				sw.Write(request);
			}

			uint arg = 2;

			if (radioButton1.Checked)
				ShellExecuteA(this.Handle, "open", @"D:\ОС\labs\Lab4_os\Console\Console\bin\Debug\Console.exe", null, null, 1);
			else
				ShellExecuteA(this.Handle, "open", @"D:\ОС\labs\Lab4_os\Console\Console\bin\Debug\Console.exe", null, null, 0);

			int process = 0;
			Process[] pp = Process.GetProcesses();
			for (int i = 0; i < pp.Length; i++)
				if (pp[i].ProcessName == "Console")
				{
					process = i;
					break;
				}

			while (arg <= 259 && arg != 0)
			{
				GetExitCodeProcess(pp[process].Handle, out arg);
			}

			StreamReader sr = new StreamReader(PathOutput, Encoding.Default);
			string answer = sr.ReadToEnd();
			sr.Close();
			sr.Dispose();

			label3.Text = answer;
		}

		private void button1_Click(object sender, EventArgs e)
		{
			label1.Text = "+";
			GetComplex();

			//button1.Enabled = true;
			//button2.Enabled = true;
			//button3.Enabled = true;
			//try
			//{
			//	if (textBox1.Text == "" || textBox2.Text == "" ||
			//		textBox3.Text == "" || textBox4.Text == "")
			//		return;

			//	Assembly asm = Assembly.LoadFrom(additionPath);
			//	Type t = asm.GetType("addition", true, true);
			//	object obj = Activator.CreateInstance(t);
			//	MethodInfo add = t.GetMethod("add");
			//	Object res;

			//	MethodInfo purpose = t.GetMethod("purpose");
			//	Object purp;

			//	int a1 = int.Parse(textBox1.Text);
			//	int b1 = int.Parse(textBox2.Text);
			//	int a2 = int.Parse(textBox3.Text);
			//	int b2 = int.Parse(textBox4.Text);

			//	label4.Text = Complex(a1, b1);
			//	label5.Text = Complex(a2, b2);
			//	label1.Text = "+";

			//	purp = purpose.Invoke(obj, new object[] { });
			//	label6.Visible = true;
			//	label6.Text = purp.ToString();

			//	res = add.Invoke(obj, new object[] { a1, b1, a2, b2 });
			//	label3.Text = res.ToString();
			//}
			//catch (Exception ex)
			//{
			//	label6.Visible = false;
			//	button1.Enabled = false;
			//	MessageBox.Show("Could not load DLL with addition function or input error");
			//}
		}

		private void button2_Click(object sender, EventArgs e)
		{
			button1.Enabled = true;
			button2.Enabled = true;
			button3.Enabled = true;
			try
			{
				if (textBox1.Text == "" || textBox2.Text == "" ||
					textBox3.Text == "" || textBox4.Text == "")
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
				if (textBox1.Text == "" || textBox2.Text == "" ||
					textBox3.Text == "" || textBox4.Text == "")
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
