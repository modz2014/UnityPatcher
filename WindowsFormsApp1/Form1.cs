using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Security.Cryptography.Xml;
using System.Globalization;
using System.IO;
using System.Diagnostics;
using System.Xml;
using System.ComponentModel;
using System.Security.Principal;


namespace WindowsFormsApp1
{
    public partial class PSVITAUnity_Click : Form
    {
        private TabControl Unity;
        private TabPage tabPage1;
        private Button button5;
        private Button button2;
        private Button button1;
        private TextBox textBox2;
        private Label label2;
        private TextBox textBox1;
        private Label label1;
        private TabPage tabPage2;
        private string appPath = "C:";
        private int patchPathAs;
        private Button button3;
        private Button button8;
        private Button button9;
        private TextBox textBox17;
        private Label label5;
        private TextBox textBox18;
        private Label label6;
        private TabPage tabPage3;
        private TextBox textBox19;
        private Button button10;
        private Button button11;
        private TextBox textBox20;
        private Label label7;
        private int patchAs;

        private static readonly byte[] Fin1 = new byte[126]
        {
            103,
            101,
            116,
            76,
            105,
            99,
            101,
            110,
            115,
            101,
            73,
            110,
            102,
            111,
            40,
            99,
            97,
            108,
            108,
            98,
            97,
            99,
            107,
            41,
            32,
            123,
            13,
            10,
            32,
            32,
            32,
            32,
            47,
            47,
            32,
            108,
            111,
            97,
            100,
            32,
            108,
            105,
            99,
            101,
            110,
            115,
            101,
            13,
            10,
            32,
            32,
            32,
            32,
            47,
            47,
            32,
            103,
            101,
            116,
            32,
            108,
            97,
            116,
            101,
            115,
            116,
            32,
            100,
            97,
            116,
            97,
            32,
            102,
            114,
            111,
            109,
            32,
            108,
            105,
            99,
            101,
            110,
            115,
            101,
            67,
            111,
            114,
            101,
            13,
            10,
            32,
            32,
            32,
            32,
            108,
            105,
            99,
            101,
            110,
            115,
            101,
            73,
            110,
            102,
            111,
            46,
            97,
            99,
            116,
            105,
            118,
            97,
            116,
            101,
            100,
            32,
            61,
            32,
            108,
            105,
            99,
            101,
            110,
            115,
            101,
            67
        };

        private static readonly byte[] Rep1 = new byte[126]
        {
            103,
            101,
            116,
            76,
            105,
            99,
            101,
            110,
            115,
            101,
            73,
            110,
            102,
            111,
            40,
            99,
            97,
            108,
            108,
            98,
            97,
            99,
            107,
            41,
            32,
            123,
            13,
            10,
            32,
            32,
            32,
            32,
            47,
            47,
            32,
            108,
            111,
            97,
            100,
            32,
            108,
            105,
            99,
            101,
            110,
            115,
            101,
            13,
            10,
            32,
            32,
            32,
            32,
            47,
            47,
            32,
            103,
            101,
            116,
            32,
            108,
            97,
            116,
            101,
            115,
            116,
            32,
            100,
            97,
            116,
            97,
            32,
            102,
            114,
            111,
            109,
            32,
            108,
            105,
            99,
            101,
            110,
            115,
            101,
            67,
            111,
            114,
            101,
            13,
            10,
            32,
            32,
            32,
            32,
            108,
            105,
            99,
            101,
            110,
            115,
            101,
            73,
            110,
            102,
            111,
            46,
            97,
            99,
            116,
            105,
            118,
            97,
            116,
            101,
            100,
            32,
            61,
            32,
            32,
            116,
            114,
            117,
            101,
            59,
            47,
            47
        };

        private static readonly byte[] Fin2 = new byte[232]
        {
            118,
            101,
            114,
            105,
            102,
            121,
            76,
            105,
            99,
            101,
            110,
            115,
            101,
            68,
            97,
            116,
            97,
            40,
            120,
            109,
            108,
            44,
            32,
            110,
            101,
            119,
            102,
            105,
            108,
            101,
            32,
            61,
            32,
            102,
            97,
            108,
            115,
            101,
            41,
            32,
            123,
            13,
            10,
            32,
            32,
            32,
            32,
            114,
            101,
            116,
            117,
            114,
            110,
            32,
            110,
            101,
            119,
            32,
            80,
            114,
            111,
            109,
            105,
            115,
            101,
            40,
            40,
            114,
            101,
            115,
            111,
            108,
            118,
            101,
            44,
            32,
            114,
            101,
            106,
            101,
            99,
            116,
            41,
            32,
            61,
            62,
            32,
            123,
            13,
            10,
            32,
            32,
            32,
            32,
            32,
            32,
            105,
            102,
            32,
            40,
            120,
            109,
            108,
            32,
            61,
            61,
            61,
            32,
            39,
            39,
            41,
            32,
            123,
            13,
            10,
            32,
            32,
            32,
            32,
            32,
            32,
            32,
            32,
            116,
            104,
            105,
            115,
            46,
            108,
            105,
            99,
            101,
            110,
            115,
            101,
            83,
            116,
            97,
            116,
            117,
            115,
            32,
            61,
            32,
            76,
            73,
            67,
            69,
            78,
            83,
            69,
            95,
            83,
            84,
            65,
            84,
            85,
            83,
            46,
            107,
            76,
            105,
            99,
            101,
            110,
            115,
            101,
            69,
            114,
            114,
            111,
            114,
            70,
            108,
            97,
            103,
            95,
            78,
            111,
            76,
            105,
            99,
            101,
            110,
            115,
            101,
            59,
            13,
            10,
            32,
            32,
            32,
            32,
            32,
            32,
            32,
            32,
            114,
            101,
            106,
            101,
            99,
            116,
            40,
            41,
            59,
            13,
            10,
            32,
            32,
            32,
            32,
            32,
            32,
            32,
            32,
            114,
            101,
            116,
            117,
            114,
            110,
            59,
            13,
            10,
            32,
            32,
            32,
            32,
            32,
            32,
            125
        };

        private static readonly byte[] Rep2 = new byte[232]
        {
            118,
            101,
            114,
            105,
            102,
            121,
            76,
            105,
            99,
            101,
            110,
            115,
            101,
            68,
            97,
            116,
            97,
            40,
            120,
            109,
            108,
            44,
            32,
            110,
            101,
            119,
            102,
            105,
            108,
            101,
            32,
            61,
            32,
            102,
            97,
            108,
            115,
            101,
            41,
            32,
            123,
            13,
            10,
            32,
            32,
            32,
            32,
            114,
            101,
            116,
            117,
            114,
            110,
            32,
            110,
            101,
            119,
            32,
            80,
            114,
            111,
            109,
            105,
            115,
            101,
            40,
            40,
            114,
            101,
            115,
            111,
            108,
            118,
            101,
            44,
            32,
            114,
            101,
            106,
            101,
            99,
            116,
            41,
            32,
            61,
            62,
            32,
            123,
            13,
            10,
            32,
            32,
            32,
            114,
            101,
            115,
            111,
            108,
            118,
            101,
            40,
            116,
            114,
            117,
            101,
            41,
            59,
            47,
            42,
            39,
            41,
            32,
            123,
            13,
            10,
            32,
            32,
            32,
            32,
            32,
            32,
            32,
            32,
            116,
            104,
            105,
            115,
            46,
            108,
            105,
            99,
            101,
            110,
            115,
            101,
            83,
            116,
            97,
            116,
            117,
            115,
            32,
            61,
            32,
            76,
            73,
            67,
            69,
            78,
            83,
            69,
            95,
            83,
            84,
            65,
            84,
            85,
            83,
            46,
            107,
            76,
            105,
            99,
            101,
            110,
            115,
            101,
            69,
            114,
            114,
            111,
            114,
            70,
            108,
            97,
            103,
            95,
            78,
            111,
            76,
            105,
            99,
            101,
            110,
            115,
            101,
            59,
            13,
            10,
            32,
            32,
            32,
            32,
            32,
            32,
            32,
            32,
            114,
            101,
            106,
            101,
            99,
            116,
            40,
            41,
            59,
            13,
            10,
            32,
            32,
            32,
            32,
            32,
            32,
            32,
            32,
            114,
            101,
            116,
            117,
            114,
            110,
            59,
            13,
            10,
            32,
            32,
            32,
            32,
            32,
            42,
            47
        };

        private static readonly byte[] Fin2019 = new byte[20]
        {
            76,
            141,
            68,
            36,
            32,
            72,
            141,
            85,
            224,
            72,
            139,
            206,
            232,
            195,
            46,
            0,
            0,
            132,
            192,
            65
        };

        private static readonly byte[] Rep2019 = new byte[20]
        {
            76,
            141,
            68,
            36,
            32,
            72,
            141,
            85,
            224,
            72,
            139,
            206,
            232,
            195,
            46,
            0,
            0,
            176,
            1,
            65
        };
        private TabPage tabPage4;
        private Button button12;
        private Button button14;
        private Button button13;
        private Label label8;
        private Label label9;
        private Button button6;
        private TextBox textBox11;
        private TextBox textBox12;
        private TextBox textBox13;
        private TextBox textBox14;
        private TextBox textBox15;
        private TextBox textBox16;
        private Label label4;
        private TextBox textBox8;
        private TextBox textBox7;
        private TextBox textBox6;
        private TextBox textBox5;
        private TextBox textBox4;
        private TextBox textBox3;
        private Label label3;
        private Button button4;
        private Button button15;
        private Button button16;
        private Label label10;
        private Button button7;
        private Button button17;
        private IContainer components;
        public PSVITAUnity_Click()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.Unity = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.button5 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.button3 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.textBox11 = new System.Windows.Forms.TextBox();
            this.textBox12 = new System.Windows.Forms.TextBox();
            this.textBox13 = new System.Windows.Forms.TextBox();
            this.textBox14 = new System.Windows.Forms.TextBox();
            this.textBox15 = new System.Windows.Forms.TextBox();
            this.textBox16 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox17 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox18 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.label10 = new System.Windows.Forms.Label();
            this.textBox19 = new System.Windows.Forms.TextBox();
            this.button10 = new System.Windows.Forms.Button();
            this.button11 = new System.Windows.Forms.Button();
            this.textBox20 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.button16 = new System.Windows.Forms.Button();
            this.button15 = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.button14 = new System.Windows.Forms.Button();
            this.button13 = new System.Windows.Forms.Button();
            this.button12 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button17 = new System.Windows.Forms.Button();
            this.Unity.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.SuspendLayout();
            // 
            // Unity
            // 
            this.Unity.Controls.Add(this.tabPage1);
            this.Unity.Controls.Add(this.tabPage2);
            this.Unity.Controls.Add(this.tabPage3);
            this.Unity.Controls.Add(this.tabPage4);
            this.Unity.Location = new System.Drawing.Point(2, 3);
            this.Unity.Name = "Unity";
            this.Unity.SelectedIndex = 0;
            this.Unity.Size = new System.Drawing.Size(604, 348);
            this.Unity.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.button5);
            this.tabPage1.Controls.Add(this.button2);
            this.tabPage1.Controls.Add(this.button1);
            this.tabPage1.Controls.Add(this.textBox8);
            this.tabPage1.Controls.Add(this.textBox7);
            this.tabPage1.Controls.Add(this.textBox6);
            this.tabPage1.Controls.Add(this.textBox5);
            this.tabPage1.Controls.Add(this.textBox4);
            this.tabPage1.Controls.Add(this.textBox3);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.textBox2);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.textBox1);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.button4);
            this.tabPage1.Location = new System.Drawing.Point(8, 39);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(588, 301);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Unity 2017";
            this.tabPage1.UseVisualStyleBackColor = true;
            this.tabPage1.Click += new System.EventHandler(this.tabPage1_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(195, 76);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(152, 20);
            this.button5.TabIndex = 34;
            this.button5.TabStop = false;
            this.button5.Text = "License Options...";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(398, 130);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(152, 37);
            this.button2.TabIndex = 31;
            this.button2.TabStop = false;
            this.button2.Text = "PATCH";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(398, 37);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(152, 20);
            this.button1.TabIndex = 30;
            this.button1.TabStop = false;
            this.button1.Text = "Browse";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox8
            // 
            this.textBox8.Enabled = false;
            this.textBox8.Location = new System.Drawing.Point(327, 147);
            this.textBox8.Name = "textBox8";
            this.textBox8.ReadOnly = true;
            this.textBox8.Size = new System.Drawing.Size(65, 31);
            this.textBox8.TabIndex = 29;
            this.textBox8.TabStop = false;
            this.textBox8.Text = "NUUN";
            this.textBox8.TextChanged += new System.EventHandler(this.textBox8_TextChanged);
            // 
            // textBox7
            // 
            this.textBox7.Enabled = false;
            this.textBox7.Location = new System.Drawing.Point(256, 147);
            this.textBox7.Name = "textBox7";
            this.textBox7.ReadOnly = true;
            this.textBox7.Size = new System.Drawing.Size(65, 31);
            this.textBox7.TabIndex = 28;
            this.textBox7.TabStop = false;
            this.textBox7.Text = "AAAA";
            this.textBox7.TextChanged += new System.EventHandler(this.textBox7_TextChanged);
            // 
            // textBox6
            // 
            this.textBox6.Enabled = false;
            this.textBox6.Location = new System.Drawing.Point(185, 147);
            this.textBox6.Name = "textBox6";
            this.textBox6.ReadOnly = true;
            this.textBox6.Size = new System.Drawing.Size(65, 31);
            this.textBox6.TabIndex = 27;
            this.textBox6.TabStop = false;
            this.textBox6.Text = "AAAA";
            this.textBox6.TextChanged += new System.EventHandler(this.textBox6_TextChanged);
            // 
            // textBox5
            // 
            this.textBox5.Enabled = false;
            this.textBox5.Location = new System.Drawing.Point(114, 147);
            this.textBox5.Name = "textBox5";
            this.textBox5.ReadOnly = true;
            this.textBox5.Size = new System.Drawing.Size(65, 31);
            this.textBox5.TabIndex = 26;
            this.textBox5.TabStop = false;
            this.textBox5.Text = "AAAA";
            this.textBox5.TextChanged += new System.EventHandler(this.textBox5_TextChanged);
            // 
            // textBox4
            // 
            this.textBox4.Enabled = false;
            this.textBox4.Location = new System.Drawing.Point(43, 147);
            this.textBox4.Name = "textBox4";
            this.textBox4.ReadOnly = true;
            this.textBox4.Size = new System.Drawing.Size(65, 31);
            this.textBox4.TabIndex = 25;
            this.textBox4.TabStop = false;
            this.textBox4.Text = "AAAA";
            this.textBox4.TextChanged += new System.EventHandler(this.textBox4_TextChanged);
            // 
            // textBox3
            // 
            this.textBox3.Enabled = false;
            this.textBox3.Location = new System.Drawing.Point(9, 147);
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.Size = new System.Drawing.Size(28, 31);
            this.textBox3.TabIndex = 24;
            this.textBox3.TabStop = false;
            this.textBox3.Text = "U3";
            this.textBox3.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 126);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(154, 25);
            this.label3.TabIndex = 23;
            this.label3.Text = "Serial Number:";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // textBox2
            // 
            this.textBox2.Enabled = false;
            this.textBox2.Location = new System.Drawing.Point(8, 76);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(170, 31);
            this.textBox2.TabIndex = 22;
            this.textBox2.TabStop = false;
            this.textBox2.Text = "???";
            this.textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(181, 25);
            this.label2.TabIndex = 21;
            this.label2.Text = "Version Selected:";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // textBox1
            // 
            this.textBox1.Enabled = false;
            this.textBox1.Location = new System.Drawing.Point(9, 37);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(383, 31);
            this.textBox1.TabIndex = 20;
            this.textBox1.TabStop = false;
            this.textBox1.Text = "???";
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(353, 25);
            this.label1.TabIndex = 19;
            this.label1.Text = "Folder containing Unity.exe (v2017)";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(398, 76);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(152, 26);
            this.button4.TabIndex = 33;
            this.button4.TabStop = false;
            this.button4.Text = "Random";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.button3);
            this.tabPage2.Controls.Add(this.button6);
            this.tabPage2.Controls.Add(this.button8);
            this.tabPage2.Controls.Add(this.button9);
            this.tabPage2.Controls.Add(this.textBox11);
            this.tabPage2.Controls.Add(this.textBox12);
            this.tabPage2.Controls.Add(this.textBox13);
            this.tabPage2.Controls.Add(this.textBox14);
            this.tabPage2.Controls.Add(this.textBox15);
            this.tabPage2.Controls.Add(this.textBox16);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.textBox17);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.textBox18);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Location = new System.Drawing.Point(8, 39);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(588, 301);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Unity 2018";
            this.tabPage2.UseVisualStyleBackColor = true;
            this.tabPage2.Click += new System.EventHandler(this.tabPage2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(192, 78);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(152, 26);
            this.button3.TabIndex = 34;
            this.button3.TabStop = false;
            this.button3.Text = "License Options...";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click_1);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(405, 66);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(152, 26);
            this.button6.TabIndex = 33;
            this.button6.TabStop = false;
            this.button6.Text = "Random";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(405, 137);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(152, 35);
            this.button8.TabIndex = 31;
            this.button8.TabStop = false;
            this.button8.Text = "Patch";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(405, 19);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(152, 26);
            this.button9.TabIndex = 30;
            this.button9.TabStop = false;
            this.button9.Text = "Browse";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // textBox11
            // 
            this.textBox11.Enabled = false;
            this.textBox11.Location = new System.Drawing.Point(334, 152);
            this.textBox11.Name = "textBox11";
            this.textBox11.ReadOnly = true;
            this.textBox11.Size = new System.Drawing.Size(65, 31);
            this.textBox11.TabIndex = 29;
            this.textBox11.TabStop = false;
            this.textBox11.Text = "NUUN";
            this.textBox11.TextChanged += new System.EventHandler(this.textBox11_TextChanged);
            // 
            // textBox12
            // 
            this.textBox12.Enabled = false;
            this.textBox12.Location = new System.Drawing.Point(263, 152);
            this.textBox12.Name = "textBox12";
            this.textBox12.ReadOnly = true;
            this.textBox12.Size = new System.Drawing.Size(65, 31);
            this.textBox12.TabIndex = 28;
            this.textBox12.TabStop = false;
            this.textBox12.Text = "AAAA";
            this.textBox12.TextChanged += new System.EventHandler(this.textBox12_TextChanged);
            // 
            // textBox13
            // 
            this.textBox13.Enabled = false;
            this.textBox13.Location = new System.Drawing.Point(192, 152);
            this.textBox13.Name = "textBox13";
            this.textBox13.ReadOnly = true;
            this.textBox13.Size = new System.Drawing.Size(65, 31);
            this.textBox13.TabIndex = 27;
            this.textBox13.TabStop = false;
            this.textBox13.Text = "AAAA";
            this.textBox13.TextChanged += new System.EventHandler(this.textBox13_TextChanged);
            // 
            // textBox14
            // 
            this.textBox14.Enabled = false;
            this.textBox14.Location = new System.Drawing.Point(121, 152);
            this.textBox14.Name = "textBox14";
            this.textBox14.ReadOnly = true;
            this.textBox14.Size = new System.Drawing.Size(65, 31);
            this.textBox14.TabIndex = 26;
            this.textBox14.TabStop = false;
            this.textBox14.Text = "AAAA";
            this.textBox14.TextChanged += new System.EventHandler(this.textBox14_TextChanged);
            // 
            // textBox15
            // 
            this.textBox15.Enabled = false;
            this.textBox15.Location = new System.Drawing.Point(50, 152);
            this.textBox15.Name = "textBox15";
            this.textBox15.ReadOnly = true;
            this.textBox15.Size = new System.Drawing.Size(65, 31);
            this.textBox15.TabIndex = 25;
            this.textBox15.TabStop = false;
            this.textBox15.Text = "AAAA";
            this.textBox15.TextChanged += new System.EventHandler(this.textBox15_TextChanged);
            // 
            // textBox16
            // 
            this.textBox16.Enabled = false;
            this.textBox16.Location = new System.Drawing.Point(16, 152);
            this.textBox16.Name = "textBox16";
            this.textBox16.ReadOnly = true;
            this.textBox16.Size = new System.Drawing.Size(28, 31);
            this.textBox16.TabIndex = 24;
            this.textBox16.TabStop = false;
            this.textBox16.Text = "U3";
            this.textBox16.TextChanged += new System.EventHandler(this.textBox16_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 131);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(154, 25);
            this.label4.TabIndex = 23;
            this.label4.Text = "Serial Number:";
            // 
            // textBox17
            // 
            this.textBox17.Enabled = false;
            this.textBox17.Location = new System.Drawing.Point(9, 82);
            this.textBox17.Name = "textBox17";
            this.textBox17.Size = new System.Drawing.Size(170, 31);
            this.textBox17.TabIndex = 22;
            this.textBox17.TabStop = false;
            this.textBox17.Text = "???";
            this.textBox17.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox17.TextChanged += new System.EventHandler(this.textBox17_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 57);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(181, 25);
            this.label5.TabIndex = 21;
            this.label5.Text = "Version Selected:";
            // 
            // textBox18
            // 
            this.textBox18.Enabled = false;
            this.textBox18.Location = new System.Drawing.Point(9, 34);
            this.textBox18.Name = "textBox18";
            this.textBox18.Size = new System.Drawing.Size(383, 31);
            this.textBox18.TabIndex = 20;
            this.textBox18.TabStop = false;
            this.textBox18.Text = "???";
            this.textBox18.TextChanged += new System.EventHandler(this.textBox18_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(4, 18);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(353, 25);
            this.label6.TabIndex = 19;
            this.label6.Text = "Folder containing Unity.exe (v2018)";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.label10);
            this.tabPage3.Controls.Add(this.textBox19);
            this.tabPage3.Controls.Add(this.button10);
            this.tabPage3.Controls.Add(this.button11);
            this.tabPage3.Controls.Add(this.textBox20);
            this.tabPage3.Controls.Add(this.label7);
            this.tabPage3.Location = new System.Drawing.Point(8, 39);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(588, 301);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Unity 2019";
            this.tabPage3.UseVisualStyleBackColor = true;
            this.tabPage3.Click += new System.EventHandler(this.tabPage3_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(7, 247);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(428, 25);
            this.label10.TabIndex = 25;
            this.label10.Text = "This wil Patch Unity 2019 without Unity Hub";
            // 
            // textBox19
            // 
            this.textBox19.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox19.Location = new System.Drawing.Point(10, 71);
            this.textBox19.Multiline = true;
            this.textBox19.Name = "textBox19";
            this.textBox19.ReadOnly = true;
            this.textBox19.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox19.Size = new System.Drawing.Size(358, 126);
            this.textBox19.TabIndex = 24;
            this.textBox19.TabStop = false;
            this.textBox19.Text = "Unity Patcher For 2019.x";
            this.textBox19.TextChanged += new System.EventHandler(this.textBox19_TextChanged);
            // 
            // button10
            // 
            this.button10.Location = new System.Drawing.Point(388, 163);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(152, 34);
            this.button10.TabIndex = 23;
            this.button10.TabStop = false;
            this.button10.Text = "Patch";
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.button10_Click);
            // 
            // button11
            // 
            this.button11.Location = new System.Drawing.Point(398, 38);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(152, 26);
            this.button11.TabIndex = 22;
            this.button11.TabStop = false;
            this.button11.Text = "Browse";
            this.button11.UseVisualStyleBackColor = true;
            this.button11.Click += new System.EventHandler(this.button11_Click);
            // 
            // textBox20
            // 
            this.textBox20.Enabled = false;
            this.textBox20.Location = new System.Drawing.Point(9, 38);
            this.textBox20.Name = "textBox20";
            this.textBox20.Size = new System.Drawing.Size(383, 31);
            this.textBox20.TabIndex = 21;
            this.textBox20.TabStop = false;
            this.textBox20.Text = "???";
            this.textBox20.TextChanged += new System.EventHandler(this.textBox20_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 16);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(353, 25);
            this.label7.TabIndex = 20;
            this.label7.Text = "Folder containing Unity.exe (v2019)";
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.button16);
            this.tabPage4.Controls.Add(this.button15);
            this.tabPage4.Controls.Add(this.label9);
            this.tabPage4.Controls.Add(this.label8);
            this.tabPage4.Controls.Add(this.button14);
            this.tabPage4.Controls.Add(this.button13);
            this.tabPage4.Controls.Add(this.button12);
            this.tabPage4.Location = new System.Drawing.Point(8, 39);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(588, 301);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Download";
            this.tabPage4.UseVisualStyleBackColor = true;
            this.tabPage4.Click += new System.EventHandler(this.tabPage4_Click);
            // 
            // button16
            // 
            this.button16.Location = new System.Drawing.Point(6, 270);
            this.button16.Name = "button16";
            this.button16.Size = new System.Drawing.Size(254, 23);
            this.button16.TabIndex = 23;
            this.button16.Text = "UnitySetup-Nintendo-Switch-Support-for-Editor";
            this.button16.UseVisualStyleBackColor = true;
            this.button16.Click += new System.EventHandler(this.button16_Click);
            // 
            // button15
            // 
            this.button15.Location = new System.Drawing.Point(6, 232);
            this.button15.Name = "button15";
            this.button15.Size = new System.Drawing.Size(251, 23);
            this.button15.TabIndex = 22;
            this.button15.Text = "UnitySetup-Xbox-One-Support-for-Editor";
            this.button15.UseVisualStyleBackColor = true;
            this.button15.Click += new System.EventHandler(this.button15_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(28, 127);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(222, 25);
            this.label9.TabIndex = 21;
            this.label9.Text = "Unity Module Loaders";
            this.label9.Click += new System.EventHandler(this.label9_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(68, 17);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(219, 25);
            this.label8.TabIndex = 20;
            this.label8.Text = "Unity 2018.2.0 Beta 3";
            this.label8.Click += new System.EventHandler(this.label7_Click);
            // 
            // button14
            // 
            this.button14.Location = new System.Drawing.Point(3, 54);
            this.button14.Name = "button14";
            this.button14.Size = new System.Drawing.Size(254, 23);
            this.button14.TabIndex = 2;
            this.button14.Text = "UnitySetup64-2018.2b3";
            this.button14.UseVisualStyleBackColor = true;
            this.button14.Click += new System.EventHandler(this.button14_PS4AndPSVITAUnity_Click);
            // 
            // button13
            // 
            this.button13.Location = new System.Drawing.Point(6, 153);
            this.button13.Name = "button13";
            this.button13.Size = new System.Drawing.Size(254, 23);
            this.button13.TabIndex = 1;
            this.button13.Text = "UnitySetup-Playstation-Vita-Support-for-Editor";
            this.button13.UseVisualStyleBackColor = true;
            this.button13.Click += new System.EventHandler(this.button13_PSVITA_Click);
            // 
            // button12
            // 
            this.button12.Location = new System.Drawing.Point(6, 192);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(254, 23);
            this.button12.TabIndex = 0;
            this.button12.Text = "UnitySetup-Playstation-4-Support-for-Editor";
            this.button12.UseVisualStyleBackColor = true;
            this.button12.Click += new System.EventHandler(this.button12_PS4_Click);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(0, 0);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(75, 23);
            this.button7.TabIndex = 0;
            // 
            // button17
            // 
            this.button17.Location = new System.Drawing.Point(0, 0);
            this.button17.Name = "button17";
            this.button17.Size = new System.Drawing.Size(75, 23);
            this.button17.TabIndex = 0;
            // 
            // PSVITAUnity_Click
            // 
            this.ClientSize = new System.Drawing.Size(876, 509);
            this.Controls.Add(this.Unity);
            this.Name = "PSVITAUnity_Click";
            this.Text = "Unity Patcher";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Unity.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.ResumeLayout(false);

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

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

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
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = folderBrowserDialog.SelectedPath;
                try
                {
                    Directory.SetCurrentDirectory(folderBrowserDialog.SelectedPath);
                    if (!File.Exists(folderBrowserDialog.SelectedPath + "/Unity.exe"))
                    {
                        throw new IOException("Application not found!");
                    }
                    appPath = folderBrowserDialog.SelectedPath + "/Unity.exe";
                    if (FileVersionInfo.GetVersionInfo(appPath).FileVersion.Substring(0, 1) != "2")
                    {
                        textBox2.Text = FileVersionInfo.GetVersionInfo(appPath).FileVersion.Substring(0, 5);
                        button2.Enabled = true;
                        FileVersionInfo versionInfo = FileVersionInfo.GetVersionInfo(appPath);
                        patchAs = int.Parse(versionInfo.FileVersion[0].ToString()) * 100;
                        patchAs += int.Parse(versionInfo.FileVersion[2].ToString()) * 10;
                        patchAs += int.Parse(versionInfo.FileVersion[4].ToString());
                    }
                    else
                    {
                        textBox2.Text = FileVersionInfo.GetVersionInfo(appPath).FileVersion.Substring(0, 8);
                        button2.Enabled = true;
                        int num = int.Parse(FileVersionInfo.GetVersionInfo(appPath).FileVersion.Substring(5, 1));
                        if (num > 0)
                        {
                            if (num == 1)
                            {
                                patchAs = 20171;
                            }
                            else
                            {
                                patchAs = 20172;
                            }
                        }
                        else
                        {
                            patchAs = 2017;
                        }
                    }



                    PrintDebug();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
            }
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
            File.Copy(text + "/Unity.exe", text + "/Unity.exe.old", overwrite: true);
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
                se2 = "CC 48 89 5C 24 10 48 89 6C 24 18 56 41 54 41 55 ?? 83 EC 30 ?? 8B E9";
                rep2 = "CC B0 01 C3 90 90 48 89 6C 24 18 56 41 54 41 55 ?? 83 EC 30 ?? 8B E9";
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

        private void button3_Click(object sender, EventArgs e)
        {

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
            PrintDebug();

            Console.WriteLine(version);
            List<byte> list = new List<byte>();
            list.AddRange(new byte[4]
            {
                1,
                0,
                0,
                0
            });
            list.AddRange(Encoding.ASCII.GetBytes($"{text}-{textBox8.Text}"));
            if (version != 20172)
            {
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
                if (version < 500)
                {
                    list2.Add("    <LicenseVersion Value=\"4.x\"/>");
                }
                if (version >= 500 && version < 2017)
                {
                    list2.Add("    <LicenseVersion Value=\"5.x\"/>");
                }
                if (version == 2017)
                {
                    list2.Add("    <LicenseVersion Value=\"2017.x\"/>");
                }
                if (version == 20171)
                {
                    list2.Add("    <LicenseVersion Value=\"6.x\"/>");
                }
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
                string text2 = "";
                if (version < 500)
                {
                    text2 = "Unity_v4.x.ulf";
                }
                if (version >= 500 && version < 2017)
                {
                    text2 = "Unity_v5.x.ulf";
                }
                if (version == 2017)
                {
                    text2 = "Unity_v2017.x.ulf";
                }
                if (version == 20171)
                {
                    text2 = "Unity_lic.ulf";
                }
                string text3 = string.Empty;
                if (spfold)
                {
                    text3 = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + "\\Unity";
                    if (!Directory.Exists(text3))
                    {
                        try
                        {
                            Directory.CreateDirectory(text3);
                        }
                        catch (Exception ex)
                        {
                            spfold = false;
                            MessageBox.Show(ex.Message, string.Empty, MessageBoxButtons.OK);
                        }
                    }
                }
                if (spfold)
                {
                    if (File.Exists(text3 + "/" + text2))
                    {
                        spfold = TestAtr(text3 + "/" + text2);
                        if (spfold && MessageBox.Show($"Replace the \"{text3}\\{text2}\"?", string.Empty, MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.OK)
                        {
                            list2.Clear();
                            return true;
                        }
                    }
                    if (spfold)
                    {
                        try
                        {
                            if (version < 500)
                            {
                                text2 = "Unity_v4.x.ulf";
                            }
                            if (version >= 500 && version < 2017)
                            {
                                text2 = "Unity_v5.x.ulf";
                            }
                            if (version == 2017)
                            {
                                text2 = "Unity_v2017.x.ulf";
                            }
                            if (version == 20171)
                            {
                                text2 = "Unity_lic.ulf";
                            }
                            if (text2 == "Unity_lic.ulf")
                            {
                                using (FileStream fileStream = new FileStream(text3 + "/" + text2, FileMode.Append))
                                {
                                    foreach (string item in list2)
                                    {
                                        byte[] bytes = Encoding.ASCII.GetBytes($"{item}\r");
                                        fileStream.Write(bytes, 0, bytes.Length);
                                    }
                                    fileStream.Flush();
                                    fileStream.Close();
                                }
                            }
                            else
                            {
                                File.WriteAllLines(text3 + "/" + text2, list2);
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
                    if (File.Exists(appDir + "/" + text2))
                    {
                        if (!TestAtr(appDir + "/" + text2))
                        {
                            list2.Clear();
                            return false;
                        }
                        if (MessageBox.Show($"Replace the \"{appDir}\\{text2}\"?", string.Empty, MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.OK)
                        {
                            list2.Clear();
                            return true;
                        }
                    }
                    try
                    {
                        if (version < 500)
                        {
                            text2 = "Unity_v4.x.ulf";
                        }
                        if (version >= 500 && version < 2017)
                        {
                            text2 = "Unity_v5.x.ulf";
                        }
                        if (version == 2017)
                        {
                            text2 = "Unity_v2017.x.ulf";
                        }
                        if (version == 20171)
                        {
                            text2 = "Unity_lic.ulf";
                        }
                        if (text2 == "Unity_lic.ulf")
                        {
                            using (FileStream fileStream2 = new FileStream(text3 + "/" + text2, FileMode.Append))
                            {
                                foreach (string item2 in list2)
                                {
                                    byte[] bytes2 = Encoding.ASCII.GetBytes($"{item2}\r");
                                    fileStream2.Write(bytes2, 0, bytes2.Length);
                                }
                                fileStream2.Flush();
                                fileStream2.Close();
                            }
                        }
                        else
                        {
                            File.WriteAllLines(text3 + "/" + text2, list2);
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
            string text4 = $"{textBox3.Text}-{textBox4.Text}-{textBox5.Text}-{textBox6.Text}-{textBox7.Text}-{textBox8.Text}";
            int[] array2 = LicHeader.ReadAll();
            if (text4.Length != 27)
            {
                MessageBox.Show("Invalid Key must be \"27\" chars.", string.Empty, MessageBoxButtons.OK);
                return false;
            }
            string path = "Unity_lic.ulf";
            string value = text4.Remove(text4.Length - 4, 4) + "XXXX";
            string value2 = Convert.ToBase64String(new byte[4]
            {
                1,
                0,
                0,
                0
            }.Concat(Encoding.ASCII.GetBytes(text4)).ToArray().ToArray());
            string value3 = "6.x";
            string value4 = "false";
            string value5 = "";
            string value6 = DateTime.UtcNow.AddDays(-1.0).ToString("s", CultureInfo.InvariantCulture);
            Dictionary<string, string> dictionary = new Dictionary<string, string>();
            string value7 = "";
            string value8 = "";
            string value9 = "";
            string value10 = "";
            string value11 = DateTime.UtcNow.AddYears(10).ToString("s", CultureInfo.InvariantCulture);
            MemoryStream memoryStream = new MemoryStream();
            XmlWriterSettings settings = new XmlWriterSettings
            {
                Indent = true,
                IndentChars = "  ",
                NewLineChars = "\n",
                OmitXmlDeclaration = true,
                Encoding = Encoding.ASCII
            };
            using (XmlWriter xmlWriter = XmlWriter.Create(memoryStream, settings))
            {
                xmlWriter.WriteStartElement("root");
                xmlWriter.WriteStartElement("License");
                xmlWriter.WriteAttributeString("id", "Terms");
                xmlWriter.WriteStartElement("AlwaysOnline");
                xmlWriter.WriteAttributeString("Value", value4);
                xmlWriter.WriteEndElement();
                xmlWriter.WriteStartElement("ClientProvidedVersion");
                xmlWriter.WriteAttributeString("Value", value5);
                xmlWriter.WriteEndElement();
                xmlWriter.WriteStartElement("DeveloperData");
                xmlWriter.WriteAttributeString("Value", value2);
                xmlWriter.WriteEndElement();
                xmlWriter.WriteStartElement("Features");
                int[] array = array2;
                foreach (int num2 in array)
                {
                    xmlWriter.WriteStartElement("Feature");
                    xmlWriter.WriteAttributeString("Value", num2.ToString());
                    xmlWriter.WriteEndElement();
                }
                xmlWriter.WriteFullEndElement();
                xmlWriter.WriteStartElement("InitialActivationDate");
                xmlWriter.WriteAttributeString("Value", value6);
                xmlWriter.WriteEndElement();
                xmlWriter.WriteStartElement("LicenseVersion");
                xmlWriter.WriteAttributeString("Value", value3);
                xmlWriter.WriteEndElement();
                xmlWriter.WriteStartElement("MachineBindings");
                foreach (KeyValuePair<string, string> item3 in dictionary)
                {
                    xmlWriter.WriteStartElement("Binding");
                    xmlWriter.WriteAttributeString("Key", item3.Key);
                    xmlWriter.WriteAttributeString("Value", item3.Value);
                    xmlWriter.WriteEndElement();
                }
                xmlWriter.WriteFullEndElement();
                xmlWriter.WriteStartElement("MachineID");
                xmlWriter.WriteAttributeString("Value", value7);
                xmlWriter.WriteEndElement();
                xmlWriter.WriteStartElement("SerialHash");
                xmlWriter.WriteAttributeString("Value", value8);
                xmlWriter.WriteEndElement();
                xmlWriter.WriteStartElement("SerialMasked");
                xmlWriter.WriteAttributeString("Value", value);
                xmlWriter.WriteEndElement();
                xmlWriter.WriteStartElement("StartDate");
                xmlWriter.WriteAttributeString("Value", value9);
                xmlWriter.WriteEndElement();
                xmlWriter.WriteStartElement("StopDate");
                xmlWriter.WriteAttributeString("Value", value10);
                xmlWriter.WriteEndElement();
                xmlWriter.WriteStartElement("UpdateDate");
                xmlWriter.WriteAttributeString("Value", value11);
                xmlWriter.WriteEndElement();
                xmlWriter.WriteEndElement();
                xmlWriter.WriteEndElement();
                xmlWriter.Flush();
            }
            memoryStream.Position = 0L;
            XmlDocument xmlDocument = new XmlDocument
            {
                PreserveWhitespace = true
            };
            xmlDocument.Load(memoryStream);
            SignedXml signedXml = new SignedXml(xmlDocument)
            {
                SigningKey = new RSACryptoServiceProvider()
            };
            Reference reference = new Reference
            {
                Uri = "#Terms"
            };
            reference.AddTransform(new XmlDsigEnvelopedSignatureTransform());
            signedXml.AddReference(reference);
            signedXml.ComputeSignature();
            StringBuilder stringBuilder = new StringBuilder();
            using (XmlWriter xmlWriter2 = XmlWriter.Create(stringBuilder, settings))
            {
                XmlDocument xmlDocument2 = new XmlDocument
                {
                    InnerXml = xmlDocument.InnerXml
                };
                xmlDocument2.DocumentElement?.AppendChild(xmlDocument2.ImportNode(signedXml.GetXml(), deep: true));
                xmlDocument2.Save(xmlWriter2);
                xmlWriter2.Flush();
            }
            string contents = stringBuilder.Replace(" />", "/>").ToString();
            string text5 = spfold ? Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "Unity") : appDir;
            string text6 = Path.Combine(text5, path);
            try
            {
                Directory.CreateDirectory(text5);
                if (File.Exists(text6) && TestAtr(text6) && MessageBox.Show($"Replace the \"{text6}\"?", string.Empty, MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                {
                    return true;
                }
                File.WriteAllText(text6, contents);
            }
            catch (Exception ex4)
            {
                MessageBox.Show(ex4.Message, string.Empty, MessageBoxButtons.OK);
                return false;
            }
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
                    throw new Exception("This is Unity3D Only.");
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
                        throw new Exception("This patch will not work on 2017 please select 2017 tab at the top.");
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

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void PrintDebug()
        {
            Console.WriteLine(appPath);
            Console.WriteLine(patchAs);
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog
            {
                RootFolder = Environment.SpecialFolder.Desktop,
                Description = "Please select the folder where Unity.exe is...",
                ShowNewFolderButton = false
            };
            if (Directory.Exists(textBox18.Text))
            {
                folderBrowserDialog.SelectedPath = textBox18.Text;
            }
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                textBox18.Text = folderBrowserDialog.SelectedPath;
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
                        textBox17.Text = "?";
                        button2.Enabled = false;
                        throw new IOException("Not v2018!");
                    }
                    textBox17.Text = FileVersionInfo.GetVersionInfo(appPath).FileVersion.Substring(0, 8);
                    button2.Enabled = true;
                    patchAs = 20172;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
            }
        }

        private void button7_Click(object sender, EventArgs e)
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

        private void button6_Click(object sender, EventArgs e)
        {

            string text = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            Random random = new Random();
            textBox16.Text = text[random.Next(0, 36)].ToString() + text[random.Next(0, 36)] + text[random.Next(0, 36)] + text[random.Next(0, 36)];
            textBox15.Text = text[random.Next(0, 36)].ToString() + text[random.Next(0, 36)] + text[random.Next(0, 36)] + text[random.Next(0, 36)];
            textBox14.Text = text[random.Next(0, 36)].ToString() + text[random.Next(0, 36)] + text[random.Next(0, 36)] + text[random.Next(0, 36)];
            textBox13.Text = text[random.Next(0, 36)].ToString() + text[random.Next(0, 36)] + text[random.Next(0, 36)] + text[random.Next(0, 36)];
            textBox12.Text = text[random.Next(0, 36)].ToString() + text[random.Next(0, 36)] + text[random.Next(0, 36)] + text[random.Next(0, 36)];
            textBox11.Text = text[random.Next(0, 36)].ToString() + text[random.Next(0, 36)] + text[random.Next(0, 36)] + text[random.Next(0, 36)];

        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (textBox18.Text.Length < 3)
            {
                textBox18.Text = Application.StartupPath;
            }
            string text = textBox18.Text;
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
            File.Copy(text + "/Unity.exe", text + "/Unity.exe.old", overwrite: true);
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

        private void button3_Click_1(object sender, EventArgs e)
        {
            new Form2().ShowDialog();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void textBox18_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox17_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox16_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox15_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox14_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox13_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog
            {
                RootFolder = Environment.SpecialFolder.Desktop,
                Description = "Please select the folder where Unity.exe is...",
                ShowNewFolderButton = false
            };
            if (Directory.Exists(textBox20.Text))
            {
                folderBrowserDialog.SelectedPath = textBox20.Text;
            }
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                textBox20.Text = folderBrowserDialog.SelectedPath;
                try
                {
                    Directory.SetCurrentDirectory(folderBrowserDialog.SelectedPath);
                    if (!File.Exists(folderBrowserDialog.SelectedPath + "/Unity.exe"))
                    {
                        throw new IOException("Application not found!");
                    }
                    appPath = folderBrowserDialog.SelectedPath + "/Unity.exe";
                    if (FileVersionInfo.GetVersionInfo(appPath).FileVersion.Substring(0, 4) != "2019")
                    {
                        button2.Enabled = false;
                        throw new IOException("Not v2019!");
                    }
                    TextBox textBox = textBox19;
                    textBox.Text = textBox.Text + "Unity v2019 found." + Environment.NewLine;

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
            }
        }

        private void textBox20_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox19_TextChanged(object sender, EventArgs e)
        {

        }


        private void NewPatching()
        {
            string text = textBox1.Text + "\\Unity.exe";
            if (FindBytes(text, Rep2019) != -1)
            {
                TextBox textBox = textBox19;
                textBox.Text = textBox.Text + "Unity already patched.   License being re-written." + Environment.NewLine;
                WriteLicenseToFile(text, spfold: true, 2019);
                TextBox textBox2 = textBox19;
                textBox2.Text = textBox2.Text + "License re-written. Enjoy " + Environment.NewLine;
            }
            else if (FindBytes(text, Fin2019) != -1)
            {
                Patch2019(text);
                TextBox textBox3 = textBox19;
                textBox3.Text = textBox3.Text + "Unity patched successfully.   License being re-written." + Environment.NewLine;
                WriteLicenseToFile(text, spfold: true, 2019);
                TextBox textBox4 = textBox19;
                textBox4.Text = textBox4.Text + "License written. Enjoy " + Environment.NewLine;
            }
            else
            {
                TextBox textBox5 = textBox19;
                textBox5.Text = textBox5.Text + "Pattern not found!" + Environment.NewLine;
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (textBox20.Text.Length < 3)
            {
                textBox20.Text = Application.StartupPath;
            }
            string text = textBox20.Text;
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
            if (!File.Exists(text + "/Unity.exe.old"))
            {
                File.Copy(text + "/Unity.exe", text + "/Unity.exe.old", overwrite: true);
            }
            NLogger.Clear();
            string se = "4C 8D 44 24 20 48 8D 55 E0 48 8B CE E8 ?? ?? 00 00 84 C0 41";
            string rep = "4C 8D 44 24 20 48 8D 55 E0 48 8B CE E8 ?? ?? 00 00 B0 01 41";
            Patcher patcher = new Patcher(text + "/Unity.exe");
            patcher.Patterns.Clear();
            if (patcher.AddString(se, rep))
            {
                if (patcher.Patch())
                {
                    TextBox textBox = textBox19;
                    textBox.Text = textBox.Text + "Unity patched successfully.    License being re-written." + Environment.NewLine;
                    WriteLicenseToFile(text, spfold: true, patchAs);
                    TextBox textBox2 = textBox19;
                    textBox2.Text = textBox2.Text + "License written. Enjoy " + Environment.NewLine;
                }
                else
                {
                    TextBox textBox3 = textBox19;
                    textBox3.Text = textBox3.Text + "Unity patching failed. Already patched" + Environment.NewLine;
                }
            }
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private static int FindBytes(string fileTarget, byte[] sequence)
        {
            byte[] array = File.ReadAllBytes(fileTarget);
            int i = 0;
            int num = array.Length - sequence.Length;
            byte b = sequence[0];
            for (; i < num; i++)
            {
                if (array[i] != b)
                {
                    continue;
                }
                for (int j = 1; j < sequence.Length && array[i + j] == sequence[j]; j++)
                {
                    if (j == sequence.Length - 1)
                    {
                        return i;
                    }
                }
            }
            return -1;
        }

        private static void PatchASAR1(string originalFile)
        {
            byte[] array = File.ReadAllBytes(originalFile);
            for (int i = 0; i < array.Length; i++)
            {
                if (DetectPatch1(array, i))
                {
                    for (int j = 0; j < Fin1.Length; j++)
                    {
                        array[i + j] = Rep1[j];
                    }
                }
            }
            File.WriteAllBytes(originalFile, array);
        }

        private static void PatchASAR2(string originalFile)
        {
            byte[] array = File.ReadAllBytes(originalFile);
            for (int i = 0; i < array.Length; i++)
            {
                if (DetectPatch2(array, i))
                {
                    for (int j = 0; j < Fin2.Length; j++)
                    {
                        array[i + j] = Rep2[j];
                    }
                }
            }
            File.WriteAllBytes(originalFile, array);
        }

        private static bool DetectPatch1(byte[] sequence, int position)
        {
            if (position + Fin1.Length > sequence.Length)
            {
                return false;
            }
            for (int i = 0; i < Fin1.Length; i++)
            {
                if (Fin1[i] != sequence[position + i])
                {
                    return false;
                }
            }
            return true;
        }

        private static bool DetectPatch2(byte[] sequence, int position)
        {
            if (position + Fin2.Length > sequence.Length)
            {
                return false;
            }
            for (int i = 0; i < Fin2.Length; i++)
            {
                if (Fin2[i] != sequence[position + i])
                {
                    return false;
                }
            }
            return true;
        }

        private static void Patch2019(string originalFile)
        {
            byte[] array = File.ReadAllBytes(originalFile);
            for (int i = 0; i < array.Length; i++)
            {
                if (DetectPatch2019(array, i))
                {
                    for (int j = 0; j < Fin2019.Length; j++)
                    {
                        array[i + j] = Rep2019[j];
                    }
                }
            }
            File.WriteAllBytes(originalFile, array);
        }

        private static bool DetectPatch2019(byte[] sequence, int position)
        {
            if (position + Fin2019.Length > sequence.Length)
            {
                return false;
            }
            for (int i = 0; i < Fin2019.Length; i++)
            {
                if (Fin2019[i] != sequence[position + i])
                {
                    return false;
                }
            }
            return true;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void button12_PS4_Click(object sender, EventArgs e)
        {
            Process p = new Process();
            p.StartInfo.FileName = "http://beta.unity3d.com/download/0000358827/UnitySetup-Playstation-4-Support-for-Editor-2018.2.0b3.exe";
            p.Start();
        }

        private void button13_PSVITA_Click(object sender, EventArgs e)
        {
            Process p = new Process();
            p.StartInfo.FileName = "http://beta.unity3d.com/download/9211755266/UnitySetup-Playstation-Vita-Support-for-Editor-2017.4.2f2.exe";
            p.Start();
        }

        private void button14_PS4AndPSVITAUnity_Click(object sender, EventArgs e)
        {
            Process p = new Process();
            p.StartInfo.FileName = "http://beta.unity3d.com/download/0a6b93065060/Windows64EditorInstaller/UnitySetup64.exe";
            p.Start();
        }

        private void textBox21_TextChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void tabPage4_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void button15_Click(object sender, EventArgs e)
        {
            Process p = new Process();
            p.StartInfo.FileName = "http://beta.unity3d.com/download/0034827547/UnitySetup-Xbox-One-Support-for-Editor-2018.2.0b3.exe";
            p.Start();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            Process p = new Process();
            p.StartInfo.FileName = "http://beta.unity3d.com/download/0038b6d9bb3e/switch/UnitySetup-Nintendo-Switch-Support-for-Editor-2018.2.0b3.exe";
            p.Start();
        }
    }
}