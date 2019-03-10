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
			FormBorderStyle = FormBorderStyle.None;
			closeToolStripMenuItem.Visible = false;
		}

		private void openToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Form2 Calculator = new Form2();
			Calculator.MdiParent = this;
			Calculator.Show();
			closeToolStripMenuItem.Visible = true;
		}

		private void closeToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (DialogResult.Yes == MessageBox.Show("ЗАКРЫТЬ ТЕКУЩЕЕ ОКНО?", "", MessageBoxButtons.YesNo))
				this.ActiveMdiChild.Close();
			if (this.MdiChildren.Length == 0)
				closeToolStripMenuItem.Visible = false;
		}

		private void cascadeToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.LayoutMdi(MdiLayout.Cascade);
		}

		private void minimizedToolStripMenuItem_Click(object sender, EventArgs e)
		{
			foreach (Form frm in this.MdiChildren)
				frm.WindowState = FormWindowState.Minimized;
		}

		private void normalToolStripMenuItem_Click(object sender, EventArgs e)
		{
			foreach (Form frm in this.MdiChildren)
				frm.WindowState = FormWindowState.Normal;
		}

		private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
		{
			MessageBox.Show("Емельянов Сергей\nОСиСП\nЛабораторная работа №2\n" +
				"Колличество открытых окон:  " + 
				Convert.ToString(this.MdiChildren.Length), "О программе");
		}

		private void exitToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (DialogResult.Yes == MessageBox.Show("ВЫЙТИ?", "", MessageBoxButtons.YesNo))
				this.Close();
		}

		private void Form1_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (DialogResult.No == MessageBox.Show("ТОЧНО ВЫЙТИ?", "", MessageBoxButtons.YesNo))
				e.Cancel = true;
		}
	}
}
