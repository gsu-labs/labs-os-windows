using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace calculator
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
		}

		private void newToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Form2 Calculator = new Form2();
			Calculator.MdiParent = this;
			Calculator.Show();
		}
	}
}
