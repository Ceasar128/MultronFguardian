
namespace multronfileguardian
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
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rjButton1 = new RJCodeAdvance.RJControls.RJButton();
            this.rjButton2 = new RJCodeAdvance.RJControls.RJButton();
            this.rjButton3 = new RJCodeAdvance.RJControls.RJButton();
            this.rjButton4 = new RJCodeAdvance.RJControls.RJButton();
            this.rjButton5 = new RJCodeAdvance.RJControls.RJButton();
            this.rjButton6 = new RJCodeAdvance.RJControls.RJButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label12 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.rjButton8 = new RJCodeAdvance.RJControls.RJButton();
            this.rjButton7 = new RJCodeAdvance.RJControls.RJButton();
            this.label10 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.rjButton9 = new RJCodeAdvance.RJControls.RJButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.rjButton12 = new RJCodeAdvance.RJControls.RJButton();
            this.rjButton11 = new RJCodeAdvance.RJControls.RJButton();
            this.label8 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.rjButton10 = new RJCodeAdvance.RJControls.RJButton();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.linkLabel3 = new System.Windows.Forms.LinkLabel();
            this.label9 = new System.Windows.Forms.Label();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.linkLabel4 = new System.Windows.Forms.LinkLabel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.comboBox4 = new System.Windows.Forms.ComboBox();
            this.label16 = new System.Windows.Forms.Label();
            this.linkLabel5 = new System.Windows.Forms.LinkLabel();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label11 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel5.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.AllowDrop = true;
            this.listBox1.BackColor = System.Drawing.Color.White;
            this.listBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.HorizontalScrollbar = true;
            this.listBox1.ItemHeight = 18;
            this.listBox1.Location = new System.Drawing.Point(15, 111);
            this.listBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(807, 202);
            this.listBox1.TabIndex = 1;
            this.listBox1.DragDrop += new System.Windows.Forms.DragEventHandler(this.listBox1_DragDrop);
            this.listBox1.DragEnter += new System.Windows.Forms.DragEventHandler(this.listBox1_DragEnter);
            // 
            // comboBox1
            // 
            this.comboBox1.DisplayMember = "AES256";
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "AES",
            "Serpent",
            "Twofish",
            "ThreeFish",
            "Camellia",
            "ChaCha20",
            "SM4",
            "AES-RSA Hybrid Algorithm",
            "Serpent-RSA Hybrid Algorithm",
            "Twofish-RSA Hybrid Algorithm",
            "ThreeFish-RSA Hybrid Algorithm",
            "Camellia-RSA Hybrid Algorithm",
            "ChaCha20-RSA Hybrid Algorithm",
            "SM4-RSA Hybrid Algorithm"});
            this.comboBox1.Location = new System.Drawing.Point(13, 52);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(436, 30);
            this.comboBox1.TabIndex = 3;
            this.comboBox1.SelectedValueChanged += new System.EventHandler(this.comboBox1_SelectedValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(11, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 22);
            this.label1.TabIndex = 6;
            this.label1.Text = "Algorithm";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Multiselect = true;
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.White;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(15, 425);
            this.textBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox1.Size = new System.Drawing.Size(807, 132);
            this.textBox1.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(12, 396);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 25);
            this.label2.TabIndex = 10;
            this.label2.Text = "Key";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(11, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(147, 25);
            this.label3.TabIndex = 13;
            this.label3.Text = "Process Status:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(175, 12);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(0, 19);
            this.label4.TabIndex = 14;
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Location = new System.Drawing.Point(13, 646);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(812, 62);
            this.panel1.TabIndex = 15;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // rjButton1
            // 
            this.rjButton1.BackColor = System.Drawing.Color.SeaGreen;
            this.rjButton1.BackgroundColor = System.Drawing.Color.SeaGreen;
            this.rjButton1.BorderColor = System.Drawing.Color.ForestGreen;
            this.rjButton1.BorderRadius = 5;
            this.rjButton1.BorderSize = 0;
            this.rjButton1.FlatAppearance.BorderSize = 0;
            this.rjButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rjButton1.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rjButton1.ForeColor = System.Drawing.Color.White;
            this.rjButton1.Location = new System.Drawing.Point(715, 65);
            this.rjButton1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rjButton1.Name = "rjButton1";
            this.rjButton1.Size = new System.Drawing.Size(107, 39);
            this.rjButton1.TabIndex = 16;
            this.rjButton1.Text = "Decrypt";
            this.rjButton1.TextColor = System.Drawing.Color.White;
            this.rjButton1.UseVisualStyleBackColor = false;
            this.rjButton1.EnabledChanged += new System.EventHandler(this.rjButton1_EnabledChanged);
            this.rjButton1.Click += new System.EventHandler(this.rjButton1_Click);
            // 
            // rjButton2
            // 
            this.rjButton2.BackColor = System.Drawing.Color.DarkRed;
            this.rjButton2.BackgroundColor = System.Drawing.Color.DarkRed;
            this.rjButton2.BorderColor = System.Drawing.Color.ForestGreen;
            this.rjButton2.BorderRadius = 5;
            this.rjButton2.BorderSize = 0;
            this.rjButton2.FlatAppearance.BorderSize = 0;
            this.rjButton2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rjButton2.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rjButton2.ForeColor = System.Drawing.Color.White;
            this.rjButton2.Location = new System.Drawing.Point(15, 66);
            this.rjButton2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rjButton2.Name = "rjButton2";
            this.rjButton2.Size = new System.Drawing.Size(107, 39);
            this.rjButton2.TabIndex = 17;
            this.rjButton2.Text = "Encrypt";
            this.rjButton2.TextColor = System.Drawing.Color.White;
            this.rjButton2.UseVisualStyleBackColor = false;
            this.rjButton2.Click += new System.EventHandler(this.rjButton2_Click);
            // 
            // rjButton3
            // 
            this.rjButton3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(90)))), ((int)(((byte)(71)))));
            this.rjButton3.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(90)))), ((int)(((byte)(71)))));
            this.rjButton3.BorderColor = System.Drawing.Color.ForestGreen;
            this.rjButton3.BorderRadius = 5;
            this.rjButton3.BorderSize = 0;
            this.rjButton3.FlatAppearance.BorderSize = 0;
            this.rjButton3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rjButton3.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rjButton3.ForeColor = System.Drawing.Color.White;
            this.rjButton3.Location = new System.Drawing.Point(368, 65);
            this.rjButton3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rjButton3.Name = "rjButton3";
            this.rjButton3.Size = new System.Drawing.Size(107, 39);
            this.rjButton3.TabIndex = 18;
            this.rjButton3.Text = "Browse";
            this.rjButton3.TextColor = System.Drawing.Color.White;
            this.rjButton3.UseVisualStyleBackColor = false;
            this.rjButton3.Click += new System.EventHandler(this.rjButton3_Click);
            // 
            // rjButton4
            // 
            this.rjButton4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(90)))), ((int)(((byte)(71)))));
            this.rjButton4.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(90)))), ((int)(((byte)(71)))));
            this.rjButton4.BorderColor = System.Drawing.Color.ForestGreen;
            this.rjButton4.BorderRadius = 5;
            this.rjButton4.BorderSize = 0;
            this.rjButton4.FlatAppearance.BorderSize = 0;
            this.rjButton4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rjButton4.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rjButton4.ForeColor = System.Drawing.Color.White;
            this.rjButton4.Location = new System.Drawing.Point(625, 334);
            this.rjButton4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rjButton4.Name = "rjButton4";
            this.rjButton4.Size = new System.Drawing.Size(196, 41);
            this.rjButton4.TabIndex = 19;
            this.rjButton4.Text = "Clear Selected File";
            this.rjButton4.TextColor = System.Drawing.Color.White;
            this.rjButton4.UseVisualStyleBackColor = false;
            this.rjButton4.Click += new System.EventHandler(this.rjButton4_Click);
            // 
            // rjButton5
            // 
            this.rjButton5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(90)))), ((int)(((byte)(71)))));
            this.rjButton5.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(90)))), ((int)(((byte)(71)))));
            this.rjButton5.BorderColor = System.Drawing.Color.ForestGreen;
            this.rjButton5.BorderRadius = 5;
            this.rjButton5.BorderSize = 0;
            this.rjButton5.FlatAppearance.BorderSize = 0;
            this.rjButton5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rjButton5.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rjButton5.ForeColor = System.Drawing.Color.White;
            this.rjButton5.Location = new System.Drawing.Point(15, 334);
            this.rjButton5.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rjButton5.Name = "rjButton5";
            this.rjButton5.Size = new System.Drawing.Size(111, 41);
            this.rjButton5.TabIndex = 20;
            this.rjButton5.Text = "Clear List";
            this.rjButton5.TextColor = System.Drawing.Color.White;
            this.rjButton5.UseVisualStyleBackColor = false;
            this.rjButton5.Click += new System.EventHandler(this.rjButton5_Click);
            // 
            // rjButton6
            // 
            this.rjButton6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(90)))), ((int)(((byte)(71)))));
            this.rjButton6.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(90)))), ((int)(((byte)(71)))));
            this.rjButton6.BorderColor = System.Drawing.Color.ForestGreen;
            this.rjButton6.BorderRadius = 5;
            this.rjButton6.BorderSize = 0;
            this.rjButton6.FlatAppearance.BorderSize = 0;
            this.rjButton6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rjButton6.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rjButton6.ForeColor = System.Drawing.Color.White;
            this.rjButton6.Location = new System.Drawing.Point(660, 601);
            this.rjButton6.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rjButton6.Name = "rjButton6";
            this.rjButton6.Size = new System.Drawing.Size(165, 58);
            this.rjButton6.TabIndex = 21;
            this.rjButton6.Text = "Create RSA Keys";
            this.rjButton6.TextColor = System.Drawing.Color.White;
            this.rjButton6.UseVisualStyleBackColor = false;
            this.rjButton6.Click += new System.EventHandler(this.rjButton6_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(90)))), ((int)(((byte)(71)))));
            this.panel2.Controls.Add(this.label12);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.rjButton8);
            this.panel2.Controls.Add(this.rjButton7);
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(837, 50);
            this.panel2.TabIndex = 22;
            this.panel2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel2_MouseDown);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label12.Font = new System.Drawing.Font("Microsoft YaHei UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.White;
            this.label12.Location = new System.Drawing.Point(640, 4);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(32, 40);
            this.label12.TabIndex = 27;
            this.label12.Text = "⬇";
            this.label12.Click += new System.EventHandler(this.label12_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label5.Location = new System.Drawing.Point(9, 14);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(254, 22);
            this.label5.TabIndex = 23;
            this.label5.Text = "Multron File Guardian 1.5.8";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // rjButton8
            // 
            this.rjButton8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(90)))), ((int)(((byte)(71)))));
            this.rjButton8.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(90)))), ((int)(((byte)(71)))));
            this.rjButton8.BorderColor = System.Drawing.Color.ForestGreen;
            this.rjButton8.BorderRadius = 0;
            this.rjButton8.BorderSize = 0;
            this.rjButton8.FlatAppearance.BorderSize = 0;
            this.rjButton8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rjButton8.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rjButton8.ForeColor = System.Drawing.Color.White;
            this.rjButton8.Location = new System.Drawing.Point(695, 0);
            this.rjButton8.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rjButton8.Name = "rjButton8";
            this.rjButton8.Size = new System.Drawing.Size(65, 50);
            this.rjButton8.TabIndex = 24;
            this.rjButton8.Text = "-";
            this.rjButton8.TextColor = System.Drawing.Color.White;
            this.rjButton8.UseVisualStyleBackColor = false;
            this.rjButton8.Click += new System.EventHandler(this.rjButton8_Click);
            // 
            // rjButton7
            // 
            this.rjButton7.BackColor = System.Drawing.Color.DarkRed;
            this.rjButton7.BackgroundColor = System.Drawing.Color.DarkRed;
            this.rjButton7.BorderColor = System.Drawing.Color.ForestGreen;
            this.rjButton7.BorderRadius = 0;
            this.rjButton7.BorderSize = 0;
            this.rjButton7.FlatAppearance.BorderSize = 0;
            this.rjButton7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rjButton7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rjButton7.ForeColor = System.Drawing.Color.White;
            this.rjButton7.Location = new System.Drawing.Point(768, 0);
            this.rjButton7.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rjButton7.Name = "rjButton7";
            this.rjButton7.Size = new System.Drawing.Size(65, 50);
            this.rjButton7.TabIndex = 23;
            this.rjButton7.Text = "X";
            this.rjButton7.TextColor = System.Drawing.Color.White;
            this.rjButton7.UseVisualStyleBackColor = false;
            this.rjButton7.Click += new System.EventHandler(this.rjButton7_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label10.Font = new System.Drawing.Font("Microsoft YaHei UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(5, 14);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 19);
            this.label10.TabIndex = 26;
            this.label10.Text = "About";
            this.label10.Click += new System.EventHandler(this.label10_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label6.Font = new System.Drawing.Font("Microsoft YaHei UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(5, 55);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(96, 24);
            this.label6.TabIndex = 25;
            this.label6.Text = "Hold Keys";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // rjButton9
            // 
            this.rjButton9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(90)))), ((int)(((byte)(71)))));
            this.rjButton9.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(90)))), ((int)(((byte)(71)))));
            this.rjButton9.BorderColor = System.Drawing.Color.ForestGreen;
            this.rjButton9.BorderRadius = 0;
            this.rjButton9.BorderSize = 0;
            this.rjButton9.FlatAppearance.BorderSize = 0;
            this.rjButton9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rjButton9.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rjButton9.ForeColor = System.Drawing.Color.White;
            this.rjButton9.Location = new System.Drawing.Point(163, 3200);
            this.rjButton9.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rjButton9.Name = "rjButton9";
            this.rjButton9.Size = new System.Drawing.Size(65, 37);
            this.rjButton9.TabIndex = 24;
            this.rjButton9.Text = "s";
            this.rjButton9.TextColor = System.Drawing.Color.White;
            this.rjButton9.UseVisualStyleBackColor = false;
            this.rjButton9.Click += new System.EventHandler(this.rjButton9_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(4, 622);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(825, 96);
            this.groupBox1.TabIndex = 23;
            this.groupBox1.TabStop = false;
            // 
            // linkLabel1
            // 
            this.linkLabel1.ActiveLinkColor = System.Drawing.Color.Black;
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.BackColor = System.Drawing.Color.Transparent;
            this.linkLabel1.Font = new System.Drawing.Font("Microsoft YaHei UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel1.ForeColor = System.Drawing.Color.Black;
            this.linkLabel1.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.linkLabel1.LinkColor = System.Drawing.Color.Black;
            this.linkLabel1.Location = new System.Drawing.Point(457, 48);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(28, 36);
            this.linkLabel1.TabIndex = 24;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "?";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // comboBox2
            // 
            this.comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "2048",
            "3072",
            "4096",
            "8192",
            "16384"});
            this.comboBox2.Location = new System.Drawing.Point(13, 225);
            this.comboBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(251, 30);
            this.comboBox2.TabIndex = 25;
            this.comboBox2.Tag = "";
            this.comboBox2.SelectedValueChanged += new System.EventHandler(this.comboBox2_SelectedValueChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(11, 201);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(157, 22);
            this.label7.TabIndex = 26;
            this.label7.Text = "RSA Key Length";
            // 
            // linkLabel2
            // 
            this.linkLabel2.ActiveLinkColor = System.Drawing.Color.Black;
            this.linkLabel2.AutoSize = true;
            this.linkLabel2.BackColor = System.Drawing.Color.Transparent;
            this.linkLabel2.Font = new System.Drawing.Font("Microsoft YaHei UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel2.ForeColor = System.Drawing.Color.Black;
            this.linkLabel2.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.linkLabel2.LinkColor = System.Drawing.Color.Black;
            this.linkLabel2.Location = new System.Drawing.Point(271, 222);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new System.Drawing.Size(28, 36);
            this.linkLabel2.TabIndex = 27;
            this.linkLabel2.TabStop = true;
            this.linkLabel2.Text = "?";
            this.linkLabel2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel2_LinkClicked);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.rjButton12);
            this.panel3.Controls.Add(this.rjButton11);
            this.panel3.Controls.Add(this.label8);
            this.panel3.Controls.Add(this.textBox2);
            this.panel3.Controls.Add(this.rjButton10);
            this.panel3.Location = new System.Drawing.Point(0, 50);
            this.panel3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(833, 670);
            this.panel3.TabIndex = 28;
            this.panel3.Visible = false;
            // 
            // rjButton12
            // 
            this.rjButton12.BackColor = System.Drawing.Color.DarkRed;
            this.rjButton12.BackgroundColor = System.Drawing.Color.DarkRed;
            this.rjButton12.BorderColor = System.Drawing.Color.ForestGreen;
            this.rjButton12.BorderRadius = 5;
            this.rjButton12.BorderSize = 0;
            this.rjButton12.FlatAppearance.BorderSize = 0;
            this.rjButton12.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rjButton12.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rjButton12.ForeColor = System.Drawing.Color.White;
            this.rjButton12.Location = new System.Drawing.Point(619, 311);
            this.rjButton12.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rjButton12.Name = "rjButton12";
            this.rjButton12.Size = new System.Drawing.Size(104, 43);
            this.rjButton12.TabIndex = 26;
            this.rjButton12.Text = "Cancel";
            this.rjButton12.TextColor = System.Drawing.Color.White;
            this.rjButton12.UseVisualStyleBackColor = false;
            this.rjButton12.Click += new System.EventHandler(this.rjButton12_Click);
            // 
            // rjButton11
            // 
            this.rjButton11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(90)))), ((int)(((byte)(71)))));
            this.rjButton11.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(90)))), ((int)(((byte)(71)))));
            this.rjButton11.BorderColor = System.Drawing.Color.ForestGreen;
            this.rjButton11.BorderRadius = 5;
            this.rjButton11.BorderSize = 0;
            this.rjButton11.FlatAppearance.BorderSize = 0;
            this.rjButton11.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rjButton11.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rjButton11.ForeColor = System.Drawing.Color.White;
            this.rjButton11.Location = new System.Drawing.Point(368, 311);
            this.rjButton11.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rjButton11.Name = "rjButton11";
            this.rjButton11.Size = new System.Drawing.Size(104, 43);
            this.rjButton11.TabIndex = 25;
            this.rjButton11.Text = "Ok";
            this.rjButton11.TextColor = System.Drawing.Color.White;
            this.rjButton11.UseVisualStyleBackColor = false;
            this.rjButton11.Click += new System.EventHandler(this.rjButton11_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(132, 257);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(447, 22);
            this.label8.TabIndex = 24;
            this.label8.Text = "Select folder where output file(s) will be saved to";
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.Color.White;
            this.textBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.Location = new System.Drawing.Point(139, 281);
            this.textBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox2.Name = "textBox2";
            this.textBox2.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox2.Size = new System.Drawing.Size(584, 26);
            this.textBox2.TabIndex = 23;
            this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // rjButton10
            // 
            this.rjButton10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(90)))), ((int)(((byte)(71)))));
            this.rjButton10.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(90)))), ((int)(((byte)(71)))));
            this.rjButton10.BorderColor = System.Drawing.Color.ForestGreen;
            this.rjButton10.BorderRadius = 5;
            this.rjButton10.BorderSize = 0;
            this.rjButton10.FlatAppearance.BorderSize = 0;
            this.rjButton10.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rjButton10.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rjButton10.ForeColor = System.Drawing.Color.White;
            this.rjButton10.Location = new System.Drawing.Point(139, 311);
            this.rjButton10.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rjButton10.Name = "rjButton10";
            this.rjButton10.Size = new System.Drawing.Size(104, 43);
            this.rjButton10.TabIndex = 22;
            this.rjButton10.Text = "Browse";
            this.rjButton10.TextColor = System.Drawing.Color.White;
            this.rjButton10.UseVisualStyleBackColor = false;
            this.rjButton10.Click += new System.EventHandler(this.rjButton10_Click);
            // 
            // linkLabel3
            // 
            this.linkLabel3.ActiveLinkColor = System.Drawing.Color.Black;
            this.linkLabel3.AutoSize = true;
            this.linkLabel3.BackColor = System.Drawing.Color.Transparent;
            this.linkLabel3.Font = new System.Drawing.Font("Microsoft YaHei UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel3.ForeColor = System.Drawing.Color.Black;
            this.linkLabel3.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.linkLabel3.LinkColor = System.Drawing.Color.Black;
            this.linkLabel3.Location = new System.Drawing.Point(271, 106);
            this.linkLabel3.Name = "linkLabel3";
            this.linkLabel3.Size = new System.Drawing.Size(28, 36);
            this.linkLabel3.TabIndex = 31;
            this.linkLabel3.TabStop = true;
            this.linkLabel3.Text = "?";
            this.linkLabel3.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel3_LinkClicked);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(11, 85);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(209, 22);
            this.label9.TabIndex = 30;
            this.label9.Text = "Symmetric Key Length";
            // 
            // comboBox3
            // 
            this.comboBox3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Location = new System.Drawing.Point(13, 110);
            this.comboBox3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(251, 30);
            this.comboBox3.TabIndex = 29;
            this.comboBox3.Tag = "";
            this.comboBox3.SelectedValueChanged += new System.EventHandler(this.comboBox3_SelectedValueChanged);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.linkLabel4);
            this.panel4.Controls.Add(this.rjButton6);
            this.panel4.Controls.Add(this.groupBox2);
            this.panel4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold);
            this.panel4.Location = new System.Drawing.Point(0, 50);
            this.panel4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(833, 670);
            this.panel4.TabIndex = 32;
            this.panel4.Visible = false;
            // 
            // linkLabel4
            // 
            this.linkLabel4.ActiveLinkColor = System.Drawing.Color.Black;
            this.linkLabel4.AutoSize = true;
            this.linkLabel4.BackColor = System.Drawing.Color.Transparent;
            this.linkLabel4.DisabledLinkColor = System.Drawing.Color.DarkRed;
            this.linkLabel4.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel4.ForeColor = System.Drawing.Color.DarkRed;
            this.linkLabel4.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.linkLabel4.LinkColor = System.Drawing.Color.Firebrick;
            this.linkLabel4.Location = new System.Drawing.Point(797, 2);
            this.linkLabel4.Name = "linkLabel4";
            this.linkLabel4.Size = new System.Drawing.Size(31, 29);
            this.linkLabel4.TabIndex = 33;
            this.linkLabel4.TabStop = true;
            this.linkLabel4.Text = "X";
            this.linkLabel4.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel4_LinkClicked);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.comboBox4);
            this.groupBox2.Controls.Add(this.label16);
            this.groupBox2.Controls.Add(this.linkLabel5);
            this.groupBox2.Controls.Add(this.comboBox2);
            this.groupBox2.Controls.Add(this.linkLabel3);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.linkLabel1);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.linkLabel2);
            this.groupBox2.Controls.Add(this.comboBox1);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.comboBox3);
            this.groupBox2.Location = new System.Drawing.Point(12, 2);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Size = new System.Drawing.Size(496, 279);
            this.groupBox2.TabIndex = 32;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Algorithm Options";
            // 
            // comboBox4
            // 
            this.comboBox4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox4.FormattingEnabled = true;
            this.comboBox4.Items.AddRange(new object[] {
            "No-AUTH",
            "Encrypt-then-MAC"});
            this.comboBox4.Location = new System.Drawing.Point(13, 167);
            this.comboBox4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBox4.Name = "comboBox4";
            this.comboBox4.Size = new System.Drawing.Size(251, 30);
            this.comboBox4.TabIndex = 32;
            this.comboBox4.Tag = "";
            this.comboBox4.SelectedValueChanged += new System.EventHandler(this.comboBox4_SelectedValueChanged);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.Black;
            this.label16.Location = new System.Drawing.Point(8, 143);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(123, 22);
            this.label16.TabIndex = 33;
            this.label16.Text = "Cipher Mode";
            // 
            // linkLabel5
            // 
            this.linkLabel5.ActiveLinkColor = System.Drawing.Color.Black;
            this.linkLabel5.AutoSize = true;
            this.linkLabel5.BackColor = System.Drawing.Color.Transparent;
            this.linkLabel5.Font = new System.Drawing.Font("Microsoft YaHei UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel5.ForeColor = System.Drawing.Color.Black;
            this.linkLabel5.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.linkLabel5.LinkColor = System.Drawing.Color.Black;
            this.linkLabel5.Location = new System.Drawing.Point(271, 164);
            this.linkLabel5.Name = "linkLabel5";
            this.linkLabel5.Size = new System.Drawing.Size(28, 36);
            this.linkLabel5.TabIndex = 34;
            this.linkLabel5.TabStop = true;
            this.linkLabel5.Text = "?";
            this.linkLabel5.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel5_LinkClicked);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox1.Location = new System.Drawing.Point(16, 562);
            this.checkBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(149, 23);
            this.checkBox1.TabIndex = 33;
            this.checkBox1.Text = "Show Password";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.Click += new System.EventHandler(this.checkBox1_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label11.Font = new System.Drawing.Font("Microsoft JhengHei UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.Black;
            this.label11.Location = new System.Drawing.Point(773, 562);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(54, 38);
            this.label11.TabIndex = 34;
            this.label11.Text = "⚒";
            this.label11.Click += new System.EventHandler(this.label11_Click);
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(90)))), ((int)(((byte)(71)))));
            this.panel5.Controls.Add(this.groupBox3);
            this.panel5.Location = new System.Drawing.Point(497, 50);
            this.panel5.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(293, 127);
            this.panel5.TabIndex = 35;
            this.panel5.Visible = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label14);
            this.groupBox3.Controls.Add(this.label13);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.rjButton9);
            this.groupBox3.Location = new System.Drawing.Point(5, -5);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox3.Size = new System.Drawing.Size(281, 129);
            this.groupBox3.TabIndex = 27;
            this.groupBox3.TabStop = false;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label14.Font = new System.Drawing.Font("Microsoft YaHei UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.White;
            this.label14.Location = new System.Drawing.Point(5, 32);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(178, 24);
            this.label14.TabIndex = 28;
            this.label14.Text = "Multron NoteGuard";
            this.label14.Click += new System.EventHandler(this.label14_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label13.Font = new System.Drawing.Font("Microsoft YaHei UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.White;
            this.label13.Location = new System.Drawing.Point(5, 78);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(79, 24);
            this.label13.TabIndex = 27;
            this.label13.Text = "Settings";
            this.label13.Click += new System.EventHandler(this.label13_Click);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft JhengHei UI", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.Black;
            this.label15.Location = new System.Drawing.Point(4, 597);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(111, 17);
            this.label15.TabIndex = 15;
            this.label15.Text = "Current Options:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(833, 720);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.rjButton5);
            this.Controls.Add(this.rjButton4);
            this.Controls.Add(this.rjButton3);
            this.Controls.Add(this.rjButton2);
            this.Controls.Add(this.rjButton1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Multron File Guardian";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel1;
        private RJCodeAdvance.RJControls.RJButton rjButton3;
        private RJCodeAdvance.RJControls.RJButton rjButton4;
        private RJCodeAdvance.RJControls.RJButton rjButton5;
        private System.Windows.Forms.Panel panel2;
        private RJCodeAdvance.RJControls.RJButton rjButton8;
        private System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Label label7;
        public System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.LinkLabel linkLabel2;
        private System.Windows.Forms.Panel panel3;
        private RJCodeAdvance.RJControls.RJButton rjButton10;
        private System.Windows.Forms.Label label8;
        public System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private RJCodeAdvance.RJControls.RJButton rjButton12;
        private RJCodeAdvance.RJControls.RJButton rjButton11;
        private System.Windows.Forms.LinkLabel linkLabel3;
        private System.Windows.Forms.Label label9;
        public System.Windows.Forms.ComboBox comboBox3;
        public RJCodeAdvance.RJControls.RJButton rjButton6;
        public System.Windows.Forms.ComboBox comboBox1;
        public RJCodeAdvance.RJControls.RJButton rjButton1;
        public RJCodeAdvance.RJControls.RJButton rjButton2;
        public RJCodeAdvance.RJControls.RJButton rjButton9;
        public System.Windows.Forms.Label label6;
        public System.Windows.Forms.Label label5;
        public System.Windows.Forms.Label label10;
        private RJCodeAdvance.RJControls.RJButton rjButton7;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.LinkLabel linkLabel4;
        public System.Windows.Forms.Label label11;
        public System.Windows.Forms.CheckBox checkBox1;
        public System.Windows.Forms.Label label12;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.GroupBox groupBox3;
        public System.Windows.Forms.Label label13;
        public System.Windows.Forms.Label label14;
        public System.Windows.Forms.Label label15;
        public System.Windows.Forms.ComboBox comboBox4;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.LinkLabel linkLabel5;
    }
}

