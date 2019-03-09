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
			exitToolStripMenuItem.Visible = false;
		}

		private void newToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Form2 Calculator = new Form2();
			Calculator.MdiParent = this;
			Calculator.Show();
			exitToolStripMenuItem.Visible = true;
		}

		private void exitToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (DialogResult.Yes == MessageBox.Show("ЗАКРЫТЬ?", "", MessageBoxButtons.YesNo))
				this.ActiveMdiChild.Close();
			if (this.MdiChildren.Length == 0)
				exitToolStripMenuItem.Visible = false;
		}

		private void выходToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (DialogResult.Yes == MessageBox.Show("ВЫЙТИ?", "", MessageBoxButtons.YesNo))
				this.Close();
		}

		private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
		{
			MessageBox.Show("Емельянов Сергей \n Колличество открытых окон: " + 
				Convert.ToString(this.MdiChildren.Length), "О программе");
		}

		private void каскадомToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.LayoutMdi(MdiLayout.Cascade);
		}

		private void свернутьВсеToolStripMenuItem_Click(object sender, EventArgs e)
		{
			foreach (Form frm in this.MdiChildren)
				frm.WindowState = FormWindowState.Minimized;
		}

		private void разместитьВОкнеToolStripMenuItem_Click(object sender, EventArgs e)
		{
			foreach (Form frm in this.MdiChildren)
				frm.WindowState = FormWindowState.Normal;
		}

		private void Form1_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (DialogResult.No == MessageBox.Show("ТОЧНО ВЫЙТИ?", "", MessageBoxButtons.YesNo))
				e.Cancel = true;
		}
	}
}
