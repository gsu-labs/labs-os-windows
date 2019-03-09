namespace calculator
{
	partial class Form1
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.упорядочитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.каскадомToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.свернутьВсеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.разместитьВОкнеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.оПрограммеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.выходToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.menuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.exitToolStripMenuItem,
            this.упорядочитьToolStripMenuItem,
            this.оПрограммеToolStripMenuItem,
            this.выходToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(534, 24);
			this.menuStrip1.TabIndex = 1;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// newToolStripMenuItem
			// 
			this.newToolStripMenuItem.Name = "newToolStripMenuItem";
			this.newToolStripMenuItem.Size = new System.Drawing.Size(96, 20);
			this.newToolStripMenuItem.Text = "Открыть окно";
			this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
			// 
			// exitToolStripMenuItem
			// 
			this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
			this.exitToolStripMenuItem.Size = new System.Drawing.Size(95, 20);
			this.exitToolStripMenuItem.Text = "Закрыть окно";
			// 
			// упорядочитьToolStripMenuItem
			// 
			this.упорядочитьToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.каскадомToolStripMenuItem,
            this.свернутьВсеToolStripMenuItem,
            this.разместитьВОкнеToolStripMenuItem});
			this.упорядочитьToolStripMenuItem.Image = global::calculator.Properties.Resources.thisMenu;
			this.упорядочитьToolStripMenuItem.Name = "упорядочитьToolStripMenuItem";
			this.упорядочитьToolStripMenuItem.Size = new System.Drawing.Size(107, 20);
			this.упорядочитьToolStripMenuItem.Text = "Упорядочить";
			// 
			// каскадомToolStripMenuItem
			// 
			this.каскадомToolStripMenuItem.Name = "каскадомToolStripMenuItem";
			this.каскадомToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.каскадомToolStripMenuItem.Text = "Каскадом";
			// 
			// свернутьВсеToolStripMenuItem
			// 
			this.свернутьВсеToolStripMenuItem.Name = "свернутьВсеToolStripMenuItem";
			this.свернутьВсеToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.свернутьВсеToolStripMenuItem.Text = "Свернуть все";
			// 
			// разместитьВОкнеToolStripMenuItem
			// 
			this.разместитьВОкнеToolStripMenuItem.Name = "разместитьВОкнеToolStripMenuItem";
			this.разместитьВОкнеToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.разместитьВОкнеToolStripMenuItem.Text = "Разместить в окне";
			// 
			// оПрограммеToolStripMenuItem
			// 
			this.оПрограммеToolStripMenuItem.Name = "оПрограммеToolStripMenuItem";
			this.оПрограммеToolStripMenuItem.Size = new System.Drawing.Size(94, 20);
			this.оПрограммеToolStripMenuItem.Text = "О программе";
			// 
			// выходToolStripMenuItem
			// 
			this.выходToolStripMenuItem.Name = "выходToolStripMenuItem";
			this.выходToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
			this.выходToolStripMenuItem.Text = "Выход";
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(534, 207);
			this.Controls.Add(this.menuStrip1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.IsMdiContainer = true;
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "Form1";
			this.Text = "Меню";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem упорядочитьToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem каскадомToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem свернутьВсеToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem разместитьВОкнеToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem оПрограммеToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem выходToolStripMenuItem;
	}
}