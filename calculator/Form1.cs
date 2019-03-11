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
		[DllImport("user32.dll", EntryPoint = "SetWindowPos")]
		public static extern IntPtr SetWindowPos(IntPtr hWnd, int hWndInsertAfter, int x, int y, int cx, int cy, int wFlags);

		[DllImport("user32.dll", SetLastError = true)]
		static extern UInt32 GetWindowLong(IntPtr hWnd, int nIndex);

		[DllImport("user32.dll")]
		static extern int SetWindowLong(IntPtr hWnd, int nIndex, UInt32 dwNewLong);

		[DllImport("user32.dll")]
		static extern bool SetLayeredWindowAttributes(IntPtr hwnd, uint crKey, byte bAlpha, uint dwFlags);

		[DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
		private static extern IntPtr CreateRoundRectRgn(int nLeftRect, int nTopRect, int nRightRect, int nBottomRect, int nWidthEllipse, int nHeightEllipse);

		[DllImport("Gdi32.dll", EntryPoint = "DeleteObject")]
		public static extern bool DeleteObject(IntPtr hObject);

		[DllImport("Gdi32.dll", EntryPoint = "CreateEllipticRgn")]
		private static extern IntPtr CreateEllipticRgn(int nLeftRect, int nTopRect, int nRightRect, int nBottomRect);

		[DllImport("gdi32.dll", EntryPoint = "CreatePolygonRgn")]
		static extern IntPtr CreatePolygonRgn(Point[] poly, int cPoints, int fnPolyFillMode);

		[DllImport("gdi32.dll", EntryPoint = "CombineRgn")]
		static extern IntPtr CombineRgn(IntPtr hrgnDst, IntPtr hrgnSrc1, IntPtr hrgnSrc2, int iMode);

		[DllImport("gdi32", EntryPoint = "FillRgn")]
		public static extern int FillRgn(IntPtr hDC, IntPtr hRgn, int hBrush);

		public const int GWL_EXSTYLE = -20;
		public const int WS_EX_LAYERED = 0x80000;
		public const int LWA_ALPHA = 0x2;
		public const int LWA_COLORKEY = 0x1;
		public int r;
		public Point[] p = new Point[7];

		string additionPath = Directory.GetCurrentDirectory();
		string subtractionPath = Directory.GetCurrentDirectory();
		string multiplicationPath = Directory.GetCurrentDirectory();

		public Form1()
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

			r = GetR();

			IntPtr handle = CreateRoundRectRgn(0, 0, Width, Height, 100, 100);
			IntPtr handle2 = CreateEllipticRgn(Width / 3, Height / 3, Width / 3 + r, Height / 3 + r);
			CombineRgn(handle, handle, handle2, 3);
			IntPtr handle3 = CreateRoundRectRgn(Width / 3 + r / 4, Height / 3 + r / 5, Width / 3 + r / 5 * 2, Height / 3 + r / 7 * 6, 0, 0);
			CombineRgn(handle, handle, handle3, 2);
			IntPtr handle4 = CreateRoundRectRgn(Width / 3 + r / 4, Height / 3 + r / 5, Width / 3 + r / 6 * 4, Height / 3 + r / 6 * 2, 0, 0);
			CombineRgn(handle, handle, handle4, 2);

			IntPtr handle5 = CreateRoundRectRgn(Width / 3 + r / 4, Height / 3 + r / 7 * 5, Width / 3 + r / 6 * 4, Height / 3 + r / 7 * 6, 0, 0);
			CombineRgn(handle, handle, handle5, 2);
			IntPtr handle6 = CreateRoundRectRgn(Width / 3 + r / 4, Height / 3 + r / 7 * 3, Width / 3 + r / 6 * 4, Height / 3 + r / 7 * 4, 0, 0);
			CombineRgn(handle, handle, handle6, 2);

			Region = Region.FromHrgn(handle);
			DeleteObject(handle);
			DeleteObject(handle2);
			DeleteObject(handle3);
			DeleteObject(handle4);

			DeleteObject(handle5);
			DeleteObject(handle6);
		}

		public int GetR()
		{
			return this.Height > this.Width ? this.Width / 2 : this.Height / 2;
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

		private void Form1_Load(object sender, EventArgs e)
		{
			SetWindowPos(this.Handle, -1, 0, 0, this.Bounds.Width, this.Bounds.Height, 0);
		}

		private void Form1_Deactivate(object sender, EventArgs e)
		{
			SetWindowLong(Handle, GWL_EXSTYLE, WS_EX_LAYERED);
			SetLayeredWindowAttributes(this.Handle, 0, 200, LWA_ALPHA);
		}

		private void Form1_Activated(object sender, EventArgs e)
		{
			SetWindowLong(Handle, GWL_EXSTYLE, 852235 ^ WS_EX_LAYERED);// getWindowLong
		}

		private void Form1_Resize(object sender, EventArgs e)
		{
			r = GetR();
			IntPtr handle = CreateRoundRectRgn(0, 0, Width, Height, 100, 100);
			IntPtr handle2 = CreateEllipticRgn(Width / 3, Height / 3, Width / 3 + r, Height / 3 + r);
			CombineRgn(handle, handle, handle2, 3);
			IntPtr handle3 = CreateRoundRectRgn(Width / 3 + r / 4, Height / 3 + r / 5, Width / 3 + r / 5 * 2, Height / 3 + r / 7 * 6, 0, 0);
			CombineRgn(handle, handle, handle3, 2);
			IntPtr handle4 = CreateRoundRectRgn(Width / 3 + r / 4, Height / 3 + r / 5, Width / 3 + r / 6 * 4, Height / 3 + r / 6 * 2, 0, 0);
			CombineRgn(handle, handle, handle4, 2);

			IntPtr handle5 = CreateRoundRectRgn(Width / 3 + r / 4, Height / 3 + r / 7 * 5, Width / 3 + r / 6 * 4, Height / 3 + r / 7 * 6, 0, 0);
			CombineRgn(handle, handle, handle5, 2);
			IntPtr handle6 = CreateRoundRectRgn(Width / 3 + r / 4, Height / 3 + r / 7 * 3, Width / 3 + r / 6 * 4, Height / 3 + r / 7 * 4, 0, 0);
			CombineRgn(handle, handle, handle6, 2);

			Region = Region.FromHrgn(handle);
			DeleteObject(handle);
			DeleteObject(handle2);
			DeleteObject(handle3);
			DeleteObject(handle4);

			DeleteObject(handle5);
			DeleteObject(handle6);
		}
	}
}
