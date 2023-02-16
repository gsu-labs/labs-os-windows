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
using System.Threading;
using System.Runtime.InteropServices;

namespace calculator
{
	public partial class Form1 : Form
	{
		Thread t;
		Thread t2;
		bool noExit = true;
		const int MAX = 256;
		StringBuilder volname = new StringBuilder(MAX);
		int sn;
		int maxcomplen;
		int sysflags;
		uint len = 0;
		StringBuilder sysname = new StringBuilder(MAX);
		SYSTEMTIME d = new SYSTEMTIME();
		NativeOverlapped natOverLap = new NativeOverlapped();
		IntPtr p;
		IntPtr[] pp = new IntPtr[3];

		[DllImport("kernel32.dll", EntryPoint = "WaitForMultipleObjects", SetLastError = true)]
		static extern int WaitForMultipleObjects(UInt32 nCount, IntPtr[] lpHandles, Boolean fWaitAll, int dwMilliseconds);

		[DllImport("kernel32.dll")]
		static extern IntPtr FindFirstChangeNotification(string lpPathName, bool bWatchSubtree, uint dwNotifyFilter);

		[DllImport("kernel32.dll", SetLastError = true)]
		static extern int FindNextChangeNotification(IntPtr hChangeHandle);

		[DllImport("kernel32.dll", SetLastError = true)]
		static extern int FindCloseChangeNotification(IntPtr hChangeHandle);

		[DllImport("kernel32.dll")]
		static extern bool WriteFile(IntPtr hFile, byte[] lpBuffer, int nNumberOfBytesToWrite, out uint lpNumberOfBytesWritten, [In] ref System.Threading.NativeOverlapped lpOverlapped);

		[DllImport("kernel32", CharSet = CharSet.Auto, SetLastError = true)]
		private static extern IntPtr FindFirstFile(string lpFileName, out WIN32_FIND_DATA lpFindFileData);

		[DllImport("kernel32", CharSet = CharSet.Auto, SetLastError = true)]
		private static extern bool FindNextFile(IntPtr hFindFile, out WIN32_FIND_DATA lpFindFileData);

		[DllImport("kernel32.dll", SetLastError = true)]
		private static extern bool FindClose(IntPtr hFindFile);
		private static readonly IntPtr INVALID_HANDLE_VALUE = new IntPtr(-1);

		[DllImport("kernel32.dll")]
		static extern uint SetFilePointerEx(IntPtr hFile, long liDistanceToMove, out uint lpNewFilePointer, [In] EMoveMethod dwMoveMethod);
		public enum EMoveMethod : uint
		{
			Begin = 0,
			Current = 1,
			End = 2
		}

		private const int MAX_PATH = 260;

		[Serializable]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
		[BestFitMapping(false)]
		private struct WIN32_FIND_DATA
		{
			public FileAttributes dwFileAttributes;
			public FILETIME ftCreationTime;
			public FILETIME ftLastAccessTime;
			public FILETIME ftLastWriteTime;
			public int nFileSizeHigh;
			public int nFileSizeLow;
			public int dwReserved0;
			public int dwReserved1;
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_PATH)]
			public string cFileName;
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 14)]
			public string cAlternate;
		}

		[StructLayout(LayoutKind.Sequential)]
		private struct SYSTEMTIME
		{
			[MarshalAs(UnmanagedType.U2)] public short Year;
			[MarshalAs(UnmanagedType.U2)] public short Month;
			[MarshalAs(UnmanagedType.U2)] public short DayOfWeek;
			[MarshalAs(UnmanagedType.U2)] public short Day;
			[MarshalAs(UnmanagedType.U2)] public short Hour;
			[MarshalAs(UnmanagedType.U2)] public short Minute;
			[MarshalAs(UnmanagedType.U2)] public short Second;
			[MarshalAs(UnmanagedType.U2)] public short Milliseconds;
		}

		[DllImport("Kernel32.dll")]
		public static extern bool CloseHandle(IntPtr hndl);

		[DllImport("Kernel32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
		public static extern IntPtr CreateFileW(
		[MarshalAs(UnmanagedType.LPWStr)] string filename,
		[MarshalAs(UnmanagedType.U4)] FileAccess access,
		[MarshalAs(UnmanagedType.U4)] FileShare share,
		IntPtr securityAttributes,
		[MarshalAs(UnmanagedType.U4)] FileMode creationDisposition,
		[MarshalAs(UnmanagedType.U4)] FileAttributes flagAndAttributes,
		IntPtr templateFile);

		[DllImport("kernel32.dll")]
		static extern void GetLocalTime(ref SYSTEMTIME t);

		[DllImport("kernel32.dll")]
		public static extern int GetVolumeInformation(
			string strPath,
			StringBuilder strVolumeNameBuffer,
			int lngVolumeNameSize,
			out int lngVolumeSerialNumber,
			out int lngMaximumComponentLength,
			out int lngFileSystemFlags,
			StringBuilder strFileSystemNameBuffer,
			int lngFileSystemBameSize);

		string additionPath = Directory.GetCurrentDirectory();
		string subtractionPath = Directory.GetCurrentDirectory();
		string multiplicationPath = Directory.GetCurrentDirectory();
		string tempPath = "C:\\Windows\\Temp\\";

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

				p = CreateFileW(tempPath + textBox5.Text, FileAccess.Write, FileShare.ReadWrite, IntPtr.Zero, FileMode.OpenOrCreate, FileAttributes.Normal, IntPtr.Zero);
				uint a = 0;
				SetFilePointerEx(p, 0, out a, EMoveMethod.End);
				natOverLap.OffsetLow = (int)a;

				byte[] b = Encoding.Default.GetBytes(res.ToString() + "\n");
				WriteFile(p, b, b.Length, out len, ref natOverLap);
				CloseHandle(p);
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

				p = CreateFileW(tempPath + textBox5.Text, FileAccess.Write, FileShare.ReadWrite, IntPtr.Zero, FileMode.OpenOrCreate, FileAttributes.Normal, IntPtr.Zero);
				uint a = 0;
				SetFilePointerEx(p, 0, out a, EMoveMethod.End);
				natOverLap.OffsetLow = (int)a;

				byte[] b = Encoding.Default.GetBytes(res.ToString() + "\n");
				WriteFile(p, b, b.Length, out len, ref natOverLap);
				CloseHandle(p);
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

				p = CreateFileW(tempPath + textBox5.Text, FileAccess.Write, FileShare.ReadWrite, IntPtr.Zero, FileMode.OpenOrCreate, FileAttributes.Normal, IntPtr.Zero);
				uint a = 0;
				SetFilePointerEx(p, 0, out a, EMoveMethod.End);
				natOverLap.OffsetLow = (int)a;

				byte[] b = Encoding.Default.GetBytes(res.ToString() + "\n");
				WriteFile(p, b, b.Length, out len, ref natOverLap);
				CloseHandle(p);
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
			t = new Thread(new ThreadStart(thrd));
			t.Start();
			printToDataGridView();
			t2 = new Thread(new ThreadStart(w8ForChanges));
			t2.Start();
		}

		void thrd()
		{
			while (true)
			{
				Thread.Sleep(1000);
				GetVolumeInformation(@"C:\", volname, MAX, out sn, out maxcomplen, out sysflags, sysname, MAX);
				GetLocalTime(ref d);
				this.Invoke(new Action(() => this.Text = $"{d.Hour}:{d.Minute}:{d.Second}" + " " + volname.ToString() + sn.ToString() + sysname.ToString()));
			}
		}

		private void Form1_FormClosing(object sender, FormClosingEventArgs e)
		{
			noExit = false;
			t.Abort();
			FindCloseChangeNotification(pp[0]);
			FindCloseChangeNotification(pp[1]);
			FindCloseChangeNotification(pp[2]);
		}

		void printToDataGridView()
		{
			WIN32_FIND_DATA findData;
			IntPtr findHandle = FindFirstFile("C:\\Windows\\Temp\\*", out findData);

			int items = 0;
			try
			{
				while (FindNextFile(findHandle, out findData))
				{
					dataGridView1.Invoke(new Action(() => dataGridView1.RowCount = items + 2));
					dataGridView1.Invoke(new Action(() => dataGridView1.Rows[items].Cells[0].Value = findData.cFileName));
					dataGridView1.Invoke(new Action(() => dataGridView1.Rows[items++].Cells[1].Value = findData.nFileSizeLow / 1024 + "." + findData.nFileSizeLow % 1024));
				}
			}
			catch (Exception) { }
			finally
			{
				FindClose(findHandle);
			}
		}

		void w8ForChanges()
		{
			pp[0] = FindFirstChangeNotification("C:\\Windows\\Temp", false, 0x00000001);
			pp[1] = FindFirstChangeNotification("C:\\Windows\\Temp", false, 0x00000008);
			pp[2] = FindFirstChangeNotification("C:\\Windows\\Temp", false, 0x00000040);
			while (noExit)
			{
				WaitForMultipleObjects(3, pp, false, -1);
				printToDataGridView();
				FindNextChangeNotification(pp[0]);
				FindNextChangeNotification(pp[1]);
				FindNextChangeNotification(pp[2]);
			}
		}
	}
}
