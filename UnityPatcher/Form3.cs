using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace UnityPatcher
{
	public class Form3 : Form
	{
		private IContainer components;

		private TextBox textBox1;

		private Button button1;

		public Form3()
		{
			InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing && components != null)
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		private void InitializeComponent()
		{
			textBox1 = new System.Windows.Forms.TextBox();
			button1 = new System.Windows.Forms.Button();
			SuspendLayout();
			textBox1.BackColor = System.Drawing.SystemColors.Control;
			textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			textBox1.Location = new System.Drawing.Point(12, 13);
			textBox1.Multiline = true;
			textBox1.Name = "textBox1";
			textBox1.Size = new System.Drawing.Size(281, 64);
			textBox1.TabIndex = 0;
			textBox1.TabStop = false;
			textBox1.Text = "This patcher requires elevated priveleges.\r\n\r\nRetry... Run as administrator";
			textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			button1.DialogResult = System.Windows.Forms.DialogResult.OK;
			button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			button1.Location = new System.Drawing.Point(113, 83);
			button1.Name = "button1";
			button1.Size = new System.Drawing.Size(75, 23);
			button1.TabIndex = 1;
			button1.TabStop = false;
			button1.Text = "OKAY";
			button1.UseVisualStyleBackColor = true;
			button1.Click += new System.EventHandler(button1_Click);
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new System.Drawing.Size(305, 120);
			base.ControlBox = false;
			base.Controls.Add(button1);
			base.Controls.Add(textBox1);
			Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			ForeColor = System.Drawing.SystemColors.WindowText;
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "Form3";
			base.ShowIcon = false;
			base.ShowInTaskbar = false;
			base.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			Text = "Alert";
			ResumeLayout(false);
			PerformLayout();
		}
	}
}
