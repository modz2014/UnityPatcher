using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Security.Principal;
using System.Text;
using System.Windows.Forms;

namespace UnityPatcher
{
	public class Form1 : Form
	{
		private string appPath = "C:";

		private int patchAs;

		private IContainer components;

		private Label label1;

		private TextBox textBox1;

		private Label label2;

		private TextBox textBox2;

		private Label label3;

		private TextBox textBox3;

		private TextBox textBox4;

		private TextBox textBox5;

		private TextBox textBox6;

		private TextBox textBox7;

		private TextBox textBox8;

		private Button button1;

		private Button button2;

		private Button button3;

		private Button button4;

		private Button button5;

		private TextBox textBox9;

		public Form1()
		{
			InitializeComponent();
			button2.Enabled = false;
		}

		private void button1_Click(object sender, EventArgs e)
		{
			FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog
			{
				RootFolder = Environment.SpecialFolder.Desktop,
				Description = "Please select the folder where Unity.exe is...",
				ShowNewFolderButton = false
			};
			if (Directory.Exists(textBox1.Text))
			{
				folderBrowserDialog.SelectedPath = textBox1.Text;
			}
			if (folderBrowserDialog.ShowDialog() != DialogResult.OK)
			{
				return;
			}
			textBox1.Text = folderBrowserDialog.SelectedPath;
			try
			{
				Directory.SetCurrentDirectory(folderBrowserDialog.SelectedPath);
				if (!File.Exists(folderBrowserDialog.SelectedPath + "/Unity.exe"))
				{
					throw new IOException("Application not found!");
				}
				appPath = folderBrowserDialog.SelectedPath + "/Unity.exe";
				if (FileVersionInfo.GetVersionInfo(appPath).FileVersion.Substring(0, 4) != "2018")
				{
					textBox2.Text = "?";
					button2.Enabled = false;
					throw new IOException("Not v2018!");
				}
				textBox2.Text = FileVersionInfo.GetVersionInfo(appPath).FileVersion.Substring(0, 8);
				button2.Enabled = true;
				patchAs = 20172;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}

		private void button4_Click(object sender, EventArgs e)
		{
			string text = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";
			Random random = new Random();
			textBox4.Text = text[random.Next(0, 36)].ToString() + text[random.Next(0, 36)] + text[random.Next(0, 36)] + text[random.Next(0, 36)];
			textBox5.Text = text[random.Next(0, 36)].ToString() + text[random.Next(0, 36)] + text[random.Next(0, 36)] + text[random.Next(0, 36)];
			textBox6.Text = text[random.Next(0, 36)].ToString() + text[random.Next(0, 36)] + text[random.Next(0, 36)] + text[random.Next(0, 36)];
			textBox7.Text = text[random.Next(0, 36)].ToString() + text[random.Next(0, 36)] + text[random.Next(0, 36)] + text[random.Next(0, 36)];
			textBox8.Text = text[random.Next(0, 36)].ToString() + text[random.Next(0, 36)] + text[random.Next(0, 36)] + text[random.Next(0, 36)];
		}

		private void button5_Click(object sender, EventArgs e)
		{
			new Form2().ShowDialog();
		}

		private bool WriteLicenseToFile(string appDir, bool spfold, int version)
		{
			string text = $"{textBox3.Text}-{textBox4.Text}-{textBox5.Text}-{textBox6.Text}-{textBox7.Text}";
			if (text.Length + textBox8.TextLength != 26)
			{
				MessageBox.Show("Invalid Key must be \"22\" chars.", string.Empty, MessageBoxButtons.OK);
				return false;
			}
			List<byte> list = new List<byte>();
			list.AddRange(new byte[4] { 1, 0, 0, 0 });
			list.AddRange(Encoding.ASCII.GetBytes($"{text}-{textBox8.Text}"));
			List<string> list2 = new List<string>
			{
				"<root>",
				"  <TimeStamp2 Value=\"cn/lkLOZ3vFvbQ==\"/>",
				"  <TimeStamp Value=\"jWj8PXAeZMPzUw==\"/>",
				"  <License id=\"Terms\">",
				"    <ClientProvidedVersion Value=\"\"/>",
				$"    <DeveloperData Value=\"{Convert.ToBase64String(list.ToArray())}\"/>",
				"    <Features>"
			};
			int[] array = LicHeader.ReadAll();
			foreach (int num in array)
			{
				list2.Add($"      <Feature Value=\"{num}\"/>");
			}
			list2.Add("    </Features>");
			list2.Add("    <LicenseVersion Value=\"6.x\"/>");
			list2.Add("    <MachineBindings>");
			list2.Add("    </MachineBindings>");
			list2.Add("    <MachineID Value=\"\"/>");
			list2.Add("    <SerialHash Value=\"\"/>");
			list2.Add($"    <SerialMasked Value=\"{text}-XXXX\"/>");
			DateTime now = DateTime.Now;
			list2.Add(string.Format("    <StartDate Value=\"{0}T00:00:00\"/>", now.AddDays(-1.0).ToString("yyyy-MM-dd")));
			list2.Add("    <StopDate Value=\"\"/>");
			list2.Add(string.Format("    <UpdateDate Value=\"{0}T00:00:00\"/>", now.AddYears(10).ToString("yyyy-MM-dd")));
			list2.Add("  </License>");
			list2.Add("");
			list2.Add("<Signature xmlns=\"http://www.w3.org/2000/09/xmldsig#\">");
			list2.Add("<SignedInfo>");
			list2.Add("<CanonicalizationMethod Algorithm=\"http://www.w3.org/TR/2001/REC-xml-c14n-20010315#WithComments\"/>");
			list2.Add("<SignatureMethod Algorithm=\"http://www.w3.org/2000/09/xmldsig#rsa-sha1\"/>");
			list2.Add("<Reference URI=\"#Terms\">");
			list2.Add("<Transforms>");
			list2.Add("<Transform Algorithm=\"http://www.w3.org/2000/09/xmldsig#enveloped-signature\"/>");
			list2.Add("</Transforms>");
			list2.Add("<DigestMethod Algorithm=\"http://www.w3.org/2000/09/xmldsig#sha1\"/>");
			list2.Add("<DigestValue>oeMc1KScgy617DHMPTxbYhqNjIM=</DigestValue>");
			list2.Add("</Reference>");
			list2.Add("</SignedInfo>");
			list2.Add("<SignatureValue>WuzMPTi0Ko1vffk9gf9ds/iU0b0K8UHaLpi4kWgm6q1am5MPTYYnzH1InaSWuzYo");
			list2.Add("EpJThKspOZdO0JISeEolNdJVf3JpsY55OsD8UaruvhwZn4r9pLeNSC7SzQ1rvAWP");
			list2.Add("h77XaHizhVVs15w6NYevP27LTxbZaem5L8Zs+34VKXQFeG4g0dEI/Jhl70TqE0CS");
			list2.Add("YNF+D0zqEtyMNHsh0Rq/vPLSzPXUN12jfPLZ3dO9B+9/mG7Ljd6emZjjLZUVuSKQ");
			list2.Add("uKxN5jlHZsm2kRMudijICV6YOWMPT+oZePlCg+BJQg5/xcN5aYVBDZhNeuNwQL1H");
			list2.Add("MPT/GJPxVuETgd9k8c4uDg==</SignatureValue>");
			list2.Add("</Signature>");
			list2.Add("</root>");
			string text2 = string.Empty;
			if (spfold)
			{
				text2 = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + "\\Unity";
				if (!Directory.Exists(text2))
				{
					try
					{
						Directory.CreateDirectory(text2);
					}
					catch (Exception ex)
					{
						spfold = false;
						MessageBox.Show(ex.Message, string.Empty, MessageBoxButtons.OK);
					}
				}
				else
				{
					spfold = true;
				}
			}
			string text3 = text2 + "\\Unity_lic.ulf";
			if (spfold)
			{
				if (File.Exists(text3))
				{
					File.Delete(text3);
				}
				if (spfold)
				{
					try
					{
						if (text3 == text2 + "\\Unity_lic.ulf")
						{
							using FileStream fileStream = new FileStream(text3, FileMode.Append);
							foreach (string item in list2)
							{
								byte[] bytes = Encoding.ASCII.GetBytes($"{item}\r");
								fileStream.Write(bytes, 0, bytes.Length);
							}
							fileStream.Flush();
							fileStream.Close();
						}
						else
						{
							File.WriteAllLines(text3, list2);
						}
					}
					catch (Exception ex2)
					{
						spfold = false;
						MessageBox.Show(ex2.Message, string.Empty, MessageBoxButtons.OK);
					}
				}
			}
			if (!spfold)
			{
				if (File.Exists(text3))
				{
					File.Delete(text3);
				}
				try
				{
					if (text3 == text2 + "\\Unity_lic.ulf")
					{
						using FileStream fileStream2 = new FileStream(text3, FileMode.Append);
						foreach (string item2 in list2)
						{
							byte[] bytes2 = Encoding.ASCII.GetBytes($"{item2}\r");
							fileStream2.Write(bytes2, 0, bytes2.Length);
						}
						fileStream2.Flush();
						fileStream2.Close();
					}
					else
					{
						File.WriteAllLines(text3, list2);
					}
				}
				catch (Exception ex3)
				{
					list2.Clear();
					MessageBox.Show(ex3.Message, string.Empty, MessageBoxButtons.OK);
					return false;
				}
			}
			list2.Clear();
			return true;
		}

		private bool TestAtr(string path)
		{
			try
			{
				FileAttributes attributes = File.GetAttributes(path);
				attributes = FileAttributes.Normal;
				File.SetAttributes(path, attributes);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, string.Empty, MessageBoxButtons.OK);
				return false;
			}
			return true;
		}

		private bool ValidateTheFile(string fileName, ref int patchAs)
		{
			try
			{
				FileVersionInfo versionInfo = FileVersionInfo.GetVersionInfo(fileName);
				if (versionInfo.ProductName == null || versionInfo.FileVersion == null || !versionInfo.FileVersion.Contains("."))
				{
					throw new Exception("Can't parse the file info.");
				}
				if (versionInfo.ProductName.ToLower() != "unity")
				{
					throw new Exception("This patch is created only for Unity3d :).");
				}
				int result = 0;
				int.TryParse(versionInfo.FileVersion.Split('.')[0], out result);
				if (result == 4)
				{
					patchAs = 0;
				}
				else
				{
					if (result <= 4)
					{
						throw new Exception("This patch will not working on 2.0x - 3.0x versions.");
					}
					patchAs = 1;
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, string.Empty, MessageBoxButtons.OK);
				return false;
			}
			return true;
		}

		private void button3_Click(object sender, EventArgs e)
		{
			if (textBox1.Text.Length < 3)
			{
				textBox1.Text = Application.StartupPath;
			}
			string text = textBox1.Text;
			try
			{
				Directory.SetCurrentDirectory(text);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Hand);
				return;
			}
			WriteLicenseToFile(text, spfold: true, 20172);
		}

		private void button2_Click(object sender, EventArgs e)
		{
			if (textBox1.Text.Length < 3)
			{
				textBox1.Text = Application.StartupPath;
			}
			string text = textBox1.Text;
			try
			{
				if (Process.GetProcessesByName("unity").Length != 0)
				{
					throw new Exception("Need to close application first.");
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Hand);
				return;
			}
			File.Copy(text + "/Unity.exe", text + "/Unity.exe.bak", overwrite: true);
			NLogger.Clear();
			string se = "";
			string rep = "";
			string se2 = "";
			string rep2 = "";
			if (patchAs < 530)
			{
				se = "CC 55 8B EC 83 EC ?? 53 56 8B F1 80 7E ?? ?? 57 75 ??";
				rep = "CC B0 01 C3 83 EC ?? 53 56 8B F1 80 7E ?? ?? 57 75 ??";
				se2 = "CC 40 57 48 83 EC 30 80 79 ?? ?? 48 8B F9 75 ??";
				rep2 = "CC B0 01 C3 90 90 90 80 79 ?? ?? 48 8B F9 75 ??";
			}
			if (patchAs >= 530 && patchAs < 20172)
			{
				se = "CC 55 8B EC 83 EC ?? 53 56 8B F1 80 7E ?? ?? 57 75 ??";
				rep = "CC B0 01 C3 83 EC ?? 53 56 8B F1 80 7E ?? ?? 57 75 ??";
				se2 = "CC 40 57 48 83 EC 30 80 79 ?? ?? 48 8B F9 75 ??";
				rep2 = "CC B0 01 C3 90 90 90 80 79 ?? ?? 48 8B F9 75 ??";
			}
			if (patchAs >= 20172)
			{
				se = "CC 55 8B EC 83 EC ?? 53 56 8B F1 80 7E ?? ?? 57 75 ??";
				rep = "CC B0 01 C3 83 EC ?? 53 56 8B F1 80 7E ?? ?? 57 75 ??";
				se2 = "8D 54 24 30 49 8B CE E8 ?? ?? 00 00 84 C0 0F";
				rep2 = "8D 54 24 30 49 8B CE E8 ?? ?? 00 00 B0 01 0F";
			}
			if (patchAs >= 201722)
			{
				se = "CC 55 8B EC 83 EC ?? 53 56 8B F1 80 7E ?? ?? 57 75 ??";
				rep = "CC B0 01 C3 83 EC ?? 53 56 8B F1 80 7E ?? ?? 57 75 ??";
				se2 = "CC 48 89 5C 24 10 48 89 6C 24 18 56 41 54 41 55 ?? 83 EC 30 ?? 8B E9";
				rep2 = "CC B0 01 C3 90 90 48 89 6C 24 18 56 41 54 41 55 ?? 83 EC 30 ?? 8B E9";
			}
			if (patchAs >=2019)
            {
				se = "CC 55 8B EC 83 EC ?? 53 56 8B F1 80 7E ?? ?? 57 75 ??";
				rep = "CC B0 01 C3 83 EC ?? 53 56 8B F1 80 7E ?? ?? 57 75 ??";
				se2 = "4C 8D 44 24 20 48 8D 55 E0 48 8B CE E8 ?? ?? 00 00 84 C0 41";
				rep2 = "4C 8D 44 24 20 48 8D 55 E0 48 8B CE E8 ?? ?? 00 00 B0 01 41";
			}
			Patcher patcher = new Patcher(text + "/Unity.exe");
			if (patcher.AddString(se, rep))
			{
				if (patcher.Patch())
				{
					NLogger.LastMessage();
					WriteLicenseToFile(text, spfold: true, patchAs);
					return;
				}
				if (patchAs >= 500)
				{
					patcher.Patterns.Clear();
					if (patcher.AddString(se2, rep2) && patcher.Patch())
					{
						NLogger.LastMessage();
						WriteLicenseToFile(text, spfold: true, patchAs);
						return;
					}
				}
			}
			NLogger.LastMessage();
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			if (new WindowsPrincipal(WindowsIdentity.GetCurrent()).IsInRole(WindowsBuiltInRole.Administrator))
			{
				string text = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";
				Random random = new Random();
				textBox4.Text = text[random.Next(0, 36)].ToString() + text[random.Next(0, 36)] + text[random.Next(0, 36)] + text[random.Next(0, 36)];
				textBox5.Text = text[random.Next(0, 36)].ToString() + text[random.Next(0, 36)] + text[random.Next(0, 36)] + text[random.Next(0, 36)];
				textBox6.Text = text[random.Next(0, 36)].ToString() + text[random.Next(0, 36)] + text[random.Next(0, 36)] + text[random.Next(0, 36)];
				textBox7.Text = text[random.Next(0, 36)].ToString() + text[random.Next(0, 36)] + text[random.Next(0, 36)] + text[random.Next(0, 36)];
				textBox8.Text = text[random.Next(0, 36)].ToString() + text[random.Next(0, 36)] + text[random.Next(0, 36)] + text[random.Next(0, 36)];
			}
			else
			{
				new Form3().ShowDialog();
			}
		}

		private void PrintDebug()
		{
			Console.WriteLine(appPath);
			Console.WriteLine(patchAs);
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
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.textBox9 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(393, 36);
            this.label1.TabIndex = 0;
            this.label1.Text = "Folder containing Unity.exe";
            // 
            // textBox1
            // 
            this.textBox1.Enabled = false;
            this.textBox1.Location = new System.Drawing.Point(19, 106);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(469, 44);
            this.textBox1.TabIndex = 1;
            this.textBox1.TabStop = false;
            this.textBox1.Text = "Unity folder not selected yet !";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 185);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(259, 36);
            this.label2.TabIndex = 2;
            this.label2.Text = "Version Selected:";
            // 
            // textBox2
            // 
            this.textBox2.Enabled = false;
            this.textBox2.Location = new System.Drawing.Point(292, 185);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(170, 44);
            this.textBox2.TabIndex = 3;
            this.textBox2.TabStop = false;
            this.textBox2.Text = "?";
            this.textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 261);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(226, 36);
            this.label3.TabIndex = 4;
            this.label3.Text = "Serial Number:";
            // 
            // textBox3
            // 
            this.textBox3.Enabled = false;
            this.textBox3.Location = new System.Drawing.Point(19, 333);
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.Size = new System.Drawing.Size(48, 44);
            this.textBox3.TabIndex = 5;
            this.textBox3.TabStop = false;
            this.textBox3.Text = "U3";
            // 
            // textBox4
            // 
            this.textBox4.Enabled = false;
            this.textBox4.Location = new System.Drawing.Point(102, 333);
            this.textBox4.Name = "textBox4";
            this.textBox4.ReadOnly = true;
            this.textBox4.Size = new System.Drawing.Size(106, 44);
            this.textBox4.TabIndex = 6;
            this.textBox4.TabStop = false;
            this.textBox4.Text = "AAAA";
            // 
            // textBox5
            // 
            this.textBox5.Enabled = false;
            this.textBox5.Location = new System.Drawing.Point(226, 333);
            this.textBox5.Name = "textBox5";
            this.textBox5.ReadOnly = true;
            this.textBox5.Size = new System.Drawing.Size(96, 44);
            this.textBox5.TabIndex = 7;
            this.textBox5.TabStop = false;
            this.textBox5.Text = "AAAA";
            // 
            // textBox6
            // 
            this.textBox6.Enabled = false;
            this.textBox6.Location = new System.Drawing.Point(346, 333);
            this.textBox6.Name = "textBox6";
            this.textBox6.ReadOnly = true;
            this.textBox6.Size = new System.Drawing.Size(101, 44);
            this.textBox6.TabIndex = 8;
            this.textBox6.TabStop = false;
            this.textBox6.Text = "AAAA";
            // 
            // textBox7
            // 
            this.textBox7.Enabled = false;
            this.textBox7.Location = new System.Drawing.Point(471, 333);
            this.textBox7.Name = "textBox7";
            this.textBox7.ReadOnly = true;
            this.textBox7.Size = new System.Drawing.Size(110, 44);
            this.textBox7.TabIndex = 9;
            this.textBox7.TabStop = false;
            this.textBox7.Text = "AAAA";
            // 
            // textBox8
            // 
            this.textBox8.Enabled = false;
            this.textBox8.Location = new System.Drawing.Point(636, 333);
            this.textBox8.Name = "textBox8";
            this.textBox8.ReadOnly = true;
            this.textBox8.Size = new System.Drawing.Size(116, 44);
            this.textBox8.TabIndex = 10;
            this.textBox8.TabStop = false;
            this.textBox8.Text = "NUUN";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(566, 108);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(152, 42);
            this.button1.TabIndex = 11;
            this.button1.TabStop = false;
            this.button1.Text = "Browse";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(522, 421);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(428, 66);
            this.button2.TabIndex = 12;
            this.button2.TabStop = false;
            this.button2.Text = "PATCH";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(743, 191);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(207, 42);
            this.button3.TabIndex = 13;
            this.button3.TabStop = false;
            this.button3.Text = "FORCED Create License";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(783, 333);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(152, 46);
            this.button4.TabIndex = 14;
            this.button4.TabStop = false;
            this.button4.Text = "<<< Randomize";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(533, 185);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(167, 48);
            this.button5.TabIndex = 15;
            this.button5.TabStop = false;
            this.button5.Text = "License Options...";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // textBox9
            // 
            this.textBox9.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox9.Location = new System.Drawing.Point(19, 436);
            this.textBox9.Multiline = true;
            this.textBox9.Name = "textBox9";
            this.textBox9.ReadOnly = true;
            this.textBox9.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox9.Size = new System.Drawing.Size(356, 66);
            this.textBox9.TabIndex = 18;
            this.textBox9.TabStop = false;
            this.textBox9.Text = "Unity Patcher";
            this.textBox9.TextChanged += new System.EventHandler(this.textBox9_TextChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(18F, 36F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.ClientSize = new System.Drawing.Size(1002, 531);
            this.Controls.Add(this.textBox9);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox8);
            this.Controls.Add(this.textBox7);
            this.Controls.Add(this.textBox6);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Unity Patcher";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

		}

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
