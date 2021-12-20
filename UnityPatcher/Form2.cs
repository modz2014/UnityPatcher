using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace UnityPatcher
{
	public class Form2 : Form
	{
		public LicHeader.LicSettings LicSettings = new LicHeader.LicSettings();

		private IContainer components;

		private Button button1;

		private Button button2;

		private Label label1;

		private ComboBox type;

		private Label label2;

		private CheckBox Team;

		private CheckBox Wii;

		private CheckBox Xbox;

		private CheckBox PlayStation;

		private CheckBox psm;

		private CheckBox nRelease;

		private CheckBox educt;

		private ComboBox iPhone;

		private Label label3;

		private Label label4;

		private ComboBox Android;

		private Label label5;

		private ComboBox Blackberry;

		private Label label6;

		private ComboBox Flash;

		private Label label7;

		private ComboBox WinStore;

		private Label label8;

		private ComboBox Tizen;

		private Label label9;

		private ComboBox SamsungTV;

		private CheckBox Nintendo;

		public Form2()
		{
			InitializeComponent();
		}

		private void Form2_Load(object sender, EventArgs e)
		{
			LicSettings = LicHeader.PropLicSettings;
			type.SelectedIndex = LicSettings.Type;
			Android.SelectedIndex = LicSettings.Android;
			Blackberry.SelectedIndex = LicSettings.Blackberry;
			Flash.SelectedIndex = LicSettings.Flash;
			iPhone.SelectedIndex = LicSettings.IPhone;
			PlayStation.Checked = LicSettings.PlayStation;
			Wii.Checked = LicSettings.Wii;
			WinStore.SelectedIndex = LicSettings.WinStore;
			Xbox.Checked = LicSettings.Xbox;
			Team.Checked = LicSettings.Team;
			Tizen.SelectedIndex = LicSettings.Tizen;
			SamsungTV.SelectedIndex = LicSettings.SamsungTv;
			educt.Checked = LicSettings.Educt;
			nRelease.Checked = LicSettings.NRelease;
			Nintendo.Checked = LicSettings.Nin;
		}

		private void button1_Click(object sender, EventArgs e)
		{
			LicSettings.Type = type.SelectedIndex;
			LicSettings.Android = Android.SelectedIndex;
			LicSettings.Blackberry = Blackberry.SelectedIndex;
			LicSettings.Flash = Flash.SelectedIndex;
			LicSettings.IPhone = iPhone.SelectedIndex;
			LicSettings.PlayStation = PlayStation.Checked;
			LicSettings.Wii = Wii.Checked;
			LicSettings.WinStore = WinStore.SelectedIndex;
			LicSettings.Xbox = Xbox.Checked;
			LicSettings.Team = Team.Checked;
			LicSettings.Tizen = Tizen.SelectedIndex;
			LicSettings.SamsungTv = SamsungTV.SelectedIndex;
			LicSettings.Educt = educt.Checked;
			LicSettings.NRelease = nRelease.Checked;
			LicSettings.Nin = Nintendo.Checked;
			LicHeader.PropLicSettings = LicSettings;
			Close();
		}

		private void button2_Click(object sender, EventArgs e)
		{
			Close();
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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.type = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Team = new System.Windows.Forms.CheckBox();
            this.Wii = new System.Windows.Forms.CheckBox();
            this.Xbox = new System.Windows.Forms.CheckBox();
            this.PlayStation = new System.Windows.Forms.CheckBox();
            this.psm = new System.Windows.Forms.CheckBox();
            this.nRelease = new System.Windows.Forms.CheckBox();
            this.educt = new System.Windows.Forms.CheckBox();
            this.iPhone = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.Android = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.Blackberry = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.Flash = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.WinStore = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.Tizen = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.SamsungTV = new System.Windows.Forms.ComboBox();
            this.Nintendo = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button1.Location = new System.Drawing.Point(379, 398);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 26);
            this.button1.TabIndex = 0;
            this.button1.TabStop = false;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button2.Location = new System.Drawing.Point(298, 398);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 26);
            this.button2.TabIndex = 1;
            this.button2.TabStop = false;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 36);
            this.label1.TabIndex = 2;
            this.label1.Text = "Type:";
            // 
            // type
            // 
            this.type.FormattingEnabled = true;
            this.type.Items.AddRange(new object[] {
            "Unity for Embedded Systems",
            "Unity Pro",
            "Unity",
            "Unity Indie"});
            this.type.Location = new System.Drawing.Point(76, 9);
            this.type.Name = "type";
            this.type.Size = new System.Drawing.Size(378, 44);
            this.type.TabIndex = 3;
            this.type.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(149, 36);
            this.label2.TabIndex = 4;
            this.label2.Text = "Features:";
            // 
            // Team
            // 
            this.Team.AutoSize = true;
            this.Team.Location = new System.Drawing.Point(16, 80);
            this.Team.Name = "Team";
            this.Team.Size = new System.Drawing.Size(123, 40);
            this.Team.TabIndex = 5;
            this.Team.TabStop = false;
            this.Team.Text = "Team";
            this.Team.UseVisualStyleBackColor = true;
            // 
            // Wii
            // 
            this.Wii.AutoSize = true;
            this.Wii.Location = new System.Drawing.Point(95, 80);
            this.Wii.Name = "Wii";
            this.Wii.Size = new System.Drawing.Size(93, 40);
            this.Wii.TabIndex = 6;
            this.Wii.TabStop = false;
            this.Wii.Text = "Wii";
            this.Wii.UseVisualStyleBackColor = true;
            // 
            // Xbox
            // 
            this.Xbox.AutoSize = true;
            this.Xbox.Location = new System.Drawing.Point(158, 80);
            this.Xbox.Name = "Xbox";
            this.Xbox.Size = new System.Drawing.Size(116, 40);
            this.Xbox.TabIndex = 7;
            this.Xbox.TabStop = false;
            this.Xbox.Text = "Xbox";
            this.Xbox.UseVisualStyleBackColor = true;
            // 
            // PlayStation
            // 
            this.PlayStation.AutoSize = true;
            this.PlayStation.Location = new System.Drawing.Point(268, 80);
            this.PlayStation.Name = "PlayStation";
            this.PlayStation.Size = new System.Drawing.Size(205, 40);
            this.PlayStation.TabIndex = 8;
            this.PlayStation.TabStop = false;
            this.PlayStation.Text = "PlayStation";
            this.PlayStation.UseVisualStyleBackColor = true;
            // 
            // psm
            // 
            this.psm.AutoSize = true;
            this.psm.Location = new System.Drawing.Point(268, 136);
            this.psm.Name = "psm";
            this.psm.Size = new System.Drawing.Size(151, 40);
            this.psm.TabIndex = 9;
            this.psm.TabStop = false;
            this.psm.Text = "PS Vita";
            this.psm.UseVisualStyleBackColor = true;
            this.psm.Visible = false;
            // 
            // nRelease
            // 
            this.nRelease.AutoSize = true;
            this.nRelease.Location = new System.Drawing.Point(16, 108);
            this.nRelease.Name = "nRelease";
            this.nRelease.Size = new System.Drawing.Size(254, 40);
            this.nRelease.TabIndex = 10;
            this.nRelease.TabStop = false;
            this.nRelease.Text = "Not for release";
            this.nRelease.UseVisualStyleBackColor = true;
            // 
            // educt
            // 
            this.educt.AutoSize = true;
            this.educt.Location = new System.Drawing.Point(16, 136);
            this.educt.Name = "educt";
            this.educt.Size = new System.Drawing.Size(390, 40);
            this.educt.TabIndex = 11;
            this.educt.TabStop = false;
            this.educt.Text = "For educational use only";
            this.educt.UseVisualStyleBackColor = true;
            // 
            // iPhone
            // 
            this.iPhone.FormattingEnabled = true;
            this.iPhone.Items.AddRange(new object[] {
            "iPhone Pro",
            "iPhone",
            "None"});
            this.iPhone.Location = new System.Drawing.Point(116, 169);
            this.iPhone.Name = "iPhone";
            this.iPhone.Size = new System.Drawing.Size(338, 44);
            this.iPhone.TabIndex = 12;
            this.iPhone.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 172);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(122, 36);
            this.label3.TabIndex = 13;
            this.label3.Text = "iPhone:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 204);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(132, 36);
            this.label4.TabIndex = 15;
            this.label4.Text = "Android:";
            // 
            // Android
            // 
            this.Android.FormattingEnabled = true;
            this.Android.Items.AddRange(new object[] {
            "Android Pro",
            "Android",
            "None"});
            this.Android.Location = new System.Drawing.Point(116, 201);
            this.Android.Name = "Android";
            this.Android.Size = new System.Drawing.Size(338, 44);
            this.Android.TabIndex = 14;
            this.Android.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 236);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(172, 36);
            this.label5.TabIndex = 17;
            this.label5.Text = "Blackberry:";
            // 
            // Blackberry
            // 
            this.Blackberry.FormattingEnabled = true;
            this.Blackberry.Items.AddRange(new object[] {
            "Blackberry Pro",
            "Blackberry",
            "None"});
            this.Blackberry.Location = new System.Drawing.Point(116, 233);
            this.Blackberry.Name = "Blackberry";
            this.Blackberry.Size = new System.Drawing.Size(338, 44);
            this.Blackberry.TabIndex = 16;
            this.Blackberry.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 268);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(102, 36);
            this.label6.TabIndex = 19;
            this.label6.Text = "Flash:";
            // 
            // Flash
            // 
            this.Flash.FormattingEnabled = true;
            this.Flash.Items.AddRange(new object[] {
            "Flash Pro",
            "Flash",
            "None"});
            this.Flash.Location = new System.Drawing.Point(116, 265);
            this.Flash.Name = "Flash";
            this.Flash.Size = new System.Drawing.Size(338, 44);
            this.Flash.TabIndex = 18;
            this.Flash.TabStop = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(13, 300);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(156, 36);
            this.label7.TabIndex = 21;
            this.label7.Text = "WinStore:";
            // 
            // WinStore
            // 
            this.WinStore.FormattingEnabled = true;
            this.WinStore.Items.AddRange(new object[] {
            "WinStore Pro",
            "WinStore",
            "None"});
            this.WinStore.Location = new System.Drawing.Point(116, 297);
            this.WinStore.Name = "WinStore";
            this.WinStore.Size = new System.Drawing.Size(338, 44);
            this.WinStore.TabIndex = 20;
            this.WinStore.TabStop = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(13, 332);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(99, 36);
            this.label8.TabIndex = 23;
            this.label8.Text = "Tizen:";
            // 
            // Tizen
            // 
            this.Tizen.FormattingEnabled = true;
            this.Tizen.Items.AddRange(new object[] {
            "Tizen Pro",
            "Tizen",
            "None"});
            this.Tizen.Location = new System.Drawing.Point(116, 329);
            this.Tizen.Name = "Tizen";
            this.Tizen.Size = new System.Drawing.Size(338, 44);
            this.Tizen.TabIndex = 22;
            this.Tizen.TabStop = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(13, 364);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(197, 36);
            this.label9.TabIndex = 25;
            this.label9.Text = "SamsungTV:";
            // 
            // SamsungTV
            // 
            this.SamsungTV.FormattingEnabled = true;
            this.SamsungTV.Items.AddRange(new object[] {
            "SamsungTV Pro",
            "SamsungTV",
            "None"});
            this.SamsungTV.Location = new System.Drawing.Point(116, 361);
            this.SamsungTV.Name = "SamsungTV";
            this.SamsungTV.Size = new System.Drawing.Size(338, 44);
            this.SamsungTV.TabIndex = 24;
            this.SamsungTV.TabStop = false;
            // 
            // Nintendo
            // 
            this.Nintendo.AutoSize = true;
            this.Nintendo.Location = new System.Drawing.Point(268, 108);
            this.Nintendo.Name = "Nintendo";
            this.Nintendo.Size = new System.Drawing.Size(244, 40);
            this.Nintendo.TabIndex = 26;
            this.Nintendo.TabStop = false;
            this.Nintendo.Text = "Nintendo 3DS";
            this.Nintendo.UseVisualStyleBackColor = true;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(18F, 36F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.ClientSize = new System.Drawing.Size(497, 446);
            this.Controls.Add(this.Nintendo);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.SamsungTV);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.Tizen);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.WinStore);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.Flash);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.Blackberry);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.Android);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.iPhone);
            this.Controls.Add(this.educt);
            this.Controls.Add(this.nRelease);
            this.Controls.Add(this.psm);
            this.Controls.Add(this.PlayStation);
            this.Controls.Add(this.Xbox);
            this.Controls.Add(this.Wii);
            this.Controls.Add(this.Team);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.type);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form2";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "License Options";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Form2_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
	}
}
