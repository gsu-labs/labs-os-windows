namespace calculator
{
	partial class Form1
	{
		/// <summary>
		/// Обязательная переменная конструктора.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Освободить все используемые ресурсы.
		/// </summary>
		/// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Код, автоматически созданный конструктором форм Windows

		/// <summary>
		/// Требуемый метод для поддержки конструктора — не изменяйте 
		/// содержимое этого метода с помощью редактора кода.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.trackBar1 = new System.Windows.Forms.TrackBar();
			this.trackBar2 = new System.Windows.Forms.TrackBar();
			this.trackBar3 = new System.Windows.Forms.TrackBar();
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.trackBar2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.trackBar3)).BeginInit();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 12);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(124, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Вызов плагина addition";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(12, 63);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(139, 13);
			this.label2.TabIndex = 1;
			this.label2.Text = "Вызов плагина subtraction";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(12, 114);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(147, 13);
			this.label3.TabIndex = 2;
			this.label3.Text = "Вызов плагина multiplication";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(317, 162);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(69, 13);
			this.label4.TabIndex = 3;
			this.label4.Text = "min <---> max";
			// 
			// trackBar1
			// 
			this.trackBar1.Location = new System.Drawing.Point(241, 12);
			this.trackBar1.Maximum = 2;
			this.trackBar1.Minimum = -2;
			this.trackBar1.Name = "trackBar1";
			this.trackBar1.Size = new System.Drawing.Size(208, 45);
			this.trackBar1.TabIndex = 4;
			this.trackBar1.Value = 2;
			this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
			// 
			// trackBar2
			// 
			this.trackBar2.Location = new System.Drawing.Point(241, 63);
			this.trackBar2.Maximum = 2;
			this.trackBar2.Minimum = -2;
			this.trackBar2.Name = "trackBar2";
			this.trackBar2.Size = new System.Drawing.Size(208, 45);
			this.trackBar2.TabIndex = 5;
			this.trackBar2.Value = 2;
			this.trackBar2.Scroll += new System.EventHandler(this.trackBar2_Scroll);
			// 
			// trackBar3
			// 
			this.trackBar3.Location = new System.Drawing.Point(241, 114);
			this.trackBar3.Maximum = 2;
			this.trackBar3.Minimum = -2;
			this.trackBar3.Name = "trackBar3";
			this.trackBar3.Size = new System.Drawing.Size(208, 45);
			this.trackBar3.TabIndex = 6;
			this.trackBar3.Value = 2;
			this.trackBar3.Scroll += new System.EventHandler(this.trackBar3_Scroll);
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(96, 157);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 23);
			this.button1.TabIndex = 7;
			this.button1.Text = "START";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(15, 157);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(75, 23);
			this.button2.TabIndex = 8;
			this.button2.Text = "STOP";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(200, 12);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(21, 13);
			this.label5.TabIndex = 9;
			this.label5.Text = "kol";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(200, 63);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(21, 13);
			this.label6.TabIndex = 10;
			this.label6.Text = "kol";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(200, 114);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(21, 13);
			this.label7.TabIndex = 11;
			this.label7.Text = "kol";
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(461, 192);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.trackBar3);
			this.Controls.Add(this.trackBar2);
			this.Controls.Add(this.trackBar1);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "Form1";
			this.Text = "Calculator";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
			((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.trackBar2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.trackBar3)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TrackBar trackBar1;
		private System.Windows.Forms.TrackBar trackBar2;
		private System.Windows.Forms.TrackBar trackBar3;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
	}
}

