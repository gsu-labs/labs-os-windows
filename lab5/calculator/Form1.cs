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
using System.Threading;

namespace calculator
{
	public partial class Form1 : Form
	{
		bool isRunning = true;

		[DllImport("kernel32.dll")]
		static extern IntPtr CreateThread(uint lpThreadAttributes, uint StackSize, ThreadStart StartFunction, uint ThreadParameter, uint CreationFags, out uint Threadld);

		[DllImport("kernel32.dll")]
		static extern bool SetThreadPriority(IntPtr hThread, int nPriority);

		[DllImport("kernel32.dll")]
		static extern bool CloseHandle(IntPtr hndl);

		[DllImport("kernel32.dll")]
		static extern bool SuspendThread(IntPtr hndl);

		[DllImport("kernel32.dll")]
		static extern bool GetExitCodeThread(IntPtr hThread, out uint lpExitCode);

		[DllImport("kernel32.dll")]
		static extern void ExitThread(uint dwExitCode);

		int first = 0;
		int second = 0;
		int third = 0;

		Thread t;
		IntPtr p1;
		IntPtr p2;
		IntPtr p3;

		public Form1()
		{
			InitializeComponent();
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

		void F1()
		{
			while (true)
			{
				addition add = new addition();
				add.add(0,0,0,0);
				first++;
			}
		}

		void F2()
		{
			while (true)
			{
				subtraction sub = new subtraction();
				sub.sub(0,0,0,0);
				second++;
			}
		}

		void F3()
		{
			while (true)
			{
				multiplication mul = new multiplication();
				mul.mul(0,0,0,0);
				third++;
			}
		}

		void thrd()
		{
			while (true)
			{
				Thread.Sleep(1000);
				label5.Invoke(new Action(() => label5.Text = first.ToString()));
				label6.Invoke(new Action(() => label6.Text = second.ToString()));
				label7.Invoke(new Action(() => label7.Text = third.ToString()));
				first = 0;
				second = 0;
				third = 0;
			}
		}

		private void button1_Click(object sender, EventArgs e)
		{
			uint threadID1;
			uint threadID2;
			uint threadID3;
			ThreadStart threadStart = thrd;
			p1 = CreateThread(0, 0, F1, 0, 0, out threadID1);
			p2 = CreateThread(0, 0, F2, 0, 0, out threadID2);
			p3 = CreateThread(0, 0, F3, 0, 0, out threadID3);
			t = new Thread(threadStart);
			t.Start();
			button1.Enabled = false;
		}

		private void button2_Click(object sender, EventArgs e)
		{
			if (isRunning)
			{
				t.Suspend();
				isRunning = false;
				button2.Text = "RESUME";
			}
			else
			{
				first = 0;
				second = 0;
				third = 0;
				t.Resume();
				isRunning = true;
				button2.Text = "STOP";
			}
		}

		private void trackBar1_Scroll(object sender, EventArgs e)
		{
			SetThreadPriority(p1, trackBar1.Value);
		}

		private void trackBar2_Scroll(object sender, EventArgs e)
		{
			SetThreadPriority(p2, trackBar2.Value);
		}

		private void trackBar3_Scroll(object sender, EventArgs e)
		{
			SetThreadPriority(p3, trackBar3.Value);
		}

		private void Form1_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (isRunning)
				t.Abort();
			else
			{
				t.Resume();
				t.Abort();
			}
		}
	}
}
