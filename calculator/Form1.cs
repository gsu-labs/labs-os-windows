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
		string CalcPath = Directory.GetCurrentDirectory();

		public Form1()
		{
			InitializeComponent();

			for (int i = 0; i < 3; i++)
			{
				PathInput = PathInput.Substring(0, PathInput.LastIndexOf("\\"));
				PathOutput = PathOutput.Substring(0, PathOutput.LastIndexOf("\\"));
				CalcPath = CalcPath.Substring(0, CalcPath.LastIndexOf("\\"));
			}

			PathInput += "\\input.txt";
			PathOutput += "\\output.txt";
			CalcPath += "\\calculatorX\\bin\\Debug\\calculatorX.exe";
		}

		public void ComplexCalculator()
		{
			if (textBox1.Text == "" || textBox2.Text == "" ||
				textBox3.Text == "" || textBox4.Text == "")
				return;

			string str = textBox1.Text + " " + textBox2.Text + " " + textBox3.Text + " " + textBox4.Text;
			str += " " + label1.Text;

			using (StreamWriter sw = new StreamWriter(PathInput, false, Encoding.Default))
			{
				sw.Write(str);
			}

			uint arg = 2;

			if (radioButton1.Checked)
				ShellExecuteA(this.Handle, "open", CalcPath, null, null, 1);
			else
				ShellExecuteA(this.Handle, "open", CalcPath, null, null, 0);

			int process = 0;
			Process[] pp = Process.GetProcesses();
			for (int i = 0; i < pp.Length; i++)
				if (pp[i].ProcessName == "calculatorX")
				{
					process = i;
					break;
				}

			while (arg <= 259 && arg != 0)
			{
				GetExitCodeProcess(pp[process].Handle, out arg);
			}

			StreamReader sr = new StreamReader(PathOutput, Encoding.Default);
			string result = sr.ReadToEnd();
			sr.Close();
			sr.Dispose();

			String[] words = result.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

			label3.Text = words[2];
			label4.Text = words[0];
			label5.Text = words[1];
			label6.Visible = true;
		}

		private void button1_Click(object sender, EventArgs e)
		{
			label1.Text = "+";
			label6.Text = button1.Text;
			ComplexCalculator();
		}

		private void button2_Click(object sender, EventArgs e)
		{
			label1.Text = "-";
			label6.Text = button2.Text;
			ComplexCalculator();
		}

		private void button3_Click(object sender, EventArgs e)
		{
			label1.Text = "*";
			label6.Text = button3.Text;
			ComplexCalculator();
		}
	}
}
