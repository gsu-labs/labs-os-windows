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
		object lockObj = new object();
		int i = 0, itemsCount = 0, sleepTime1 = 0, sleepTime2 = 0;
		const int sizeOfStack = 7;
		Thread t1;
		Thread t2;
		Thread t3;
		Semaphore s = new Semaphore(1, 1);
		Semaphore s2 = new Semaphore(sizeOfStack, sizeOfStack);

		public Form1()
		{
			InitializeComponent();
			dataGridView1.RowHeadersVisible = false;
			dataGridView2.RowHeadersVisible = false;
			dataGridView2.RowCount = sizeOfStack;
		}

		private void button1_Click(object sender, EventArgs e)
		{
			t1 = new Thread(new ThreadStart(thrd1));
			t2 = new Thread(new ThreadStart(thrd2));
			t3 = new Thread(new ThreadStart(thrd3));
			t1.Start();
			t2.Start();
			t3.Start();
			timer1.Enabled = true;
			button1.Enabled = false;
		}

		private void trackBar1_Scroll(object sender, EventArgs e)
		{
			sleepTime1 = trackBar1.Value;
		}

		private void trackBar2_Scroll(object sender, EventArgs e)
		{
			sleepTime2 = trackBar2.Value;
		}

		private void timer1_Tick(object sender, EventArgs e)
		{
			label6.Text = t1.ThreadState.ToString();
			label7.Text = t2.ThreadState.ToString();
			label8.Text = t3.ThreadState.ToString();
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			bool ex = false;
			Mutex m = new Mutex(true, "mutexName", out ex);
			if (!ex)
			{
				MessageBox.Show("The app is running!");
				this.Close();
			}
			dataGridView1.RowCount = sizeOfStack;
		}

		private void Form1_FormClosing(object sender, FormClosingEventArgs e)
		{
			try { t1.Abort(); }
			catch (Exception) { }
			try { t2.Abort(); }
			catch (Exception) { }
			try { t3.Abort(); }
			catch (Exception) { }
		}

		void thrd1()
		{
			while (true)
			{
				Thread.Sleep(sleepTime1);
				addition add = new addition();
				Random r = new Random();
				string str = $"1. {add.add(r.Next(-100, 100), r.Next(-100, 100), r.Next(-100, 100), r.Next(-100, 100))}";
				s.WaitOne();
				s2.WaitOne();
				lock (lockObj)
				{
					for (int i = itemsCount; i > 0; i--)
					{
						dataGridView1.Invoke(new Action(() => dataGridView1.Rows[i].Cells[0].Value = dataGridView1.Rows[i - 1].Cells[0].Value));
					}
					dataGridView1.Invoke(new Action(() => dataGridView1.Rows[0].Cells[0].Value = str));
					itemsCount++;
				}
				s.Release();
			}
		}

		void thrd2()
		{
			while (true)
			{
				Thread.Sleep(sleepTime1);
				subtraction sub = new subtraction();
				Random r = new Random();
				string str = $"2. {sub.sub(r.Next(-100, 100), r.Next(-100, 100), r.Next(-100, 100), r.Next(-100, 100))}";
				s.WaitOne();
				s2.WaitOne();
				lock (lockObj)
				{
					for (int i = itemsCount; i > 0; i--)
					{
						dataGridView1.Invoke(new Action(() => dataGridView1.Rows[i].Cells[0].Value = dataGridView1.Rows[i - 1].Cells[0].Value));
					}
					dataGridView1.Invoke(new Action(() => dataGridView1.Rows[0].Cells[0].Value = str));
					itemsCount++;
				}
				s.Release();
			}
		}

		void thrd3()
		{
			while (true)
			{
				if (itemsCount > 0 && itemsCount < sizeOfStack)
				{
					lock (lockObj)
					{
						Thread.Sleep(sleepTime2);
						dataGridView2.Invoke(new Action(() => dataGridView2.RowCount += 1));
						dataGridView2.Invoke(new Action(() => dataGridView2.Rows[i++].Cells[0].Value = dataGridView1.Rows[itemsCount - 1].Cells[0].Value));
						dataGridView2.Invoke(new Action(() => dataGridView1.Rows[itemsCount - 1].Cells[0].Value = ""));
						itemsCount--;
					}
					s2.Release();
				}
			}
		}
	}
}
