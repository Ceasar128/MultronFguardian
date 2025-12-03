using RJCodeAdvance.RJControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace multronfileguardian
{
    public partial class Form5 : Form
    {
        Form1 forum1 = null;
        private const uint avoidcaxptures = 0x00000011;
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        [DllImport("user32.dll")]
        public static extern uint SetWindowDisplayAffinity(IntPtr hwnd, uint dwAffinity);

        protected override CreateParams CreateParams
        {
            get
            {
                const int CS_DROPSHADOW = 0x20000;
                CreateParams cp = base.CreateParams;
                cp.ClassStyle |= CS_DROPSHADOW;
                return cp;
            }
        }

        public Form5(Form1 foum1)
        {
            InitializeComponent();
            this.forum1 = foum1;
        }

        private void rjButton7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void rjButton8_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void rjButton6_Click(object sender, EventArgs e)
        {
            forum1.rjButton6_Click(sender, e);
        }
        private void darktheme()
        {
            panel2.BackColor = Color.FromArgb(40, 40, 40);
            this.BackColor = Color.FromArgb(23, 23, 23);
            rjButton9.BackColor = Color.RoyalBlue;
            rjButton8.BackColor = panel2.BackColor;
            panel5.BackColor = panel2.BackColor;
            foreach (Control yazi in this.Controls)
            {
                if (yazi.Name.Contains("rjButton"))
                {
                        yazi.BackColor = Color.FromArgb(43, 40, 40);
                        yazi.ForeColor = Color.WhiteSmoke;
                }
                if (yazi.Name.Contains("checkBox"))
                {
                    yazi.ForeColor = Color.WhiteSmoke;
                }
                if (yazi.Name.Contains("label"))
                {
                    yazi.ForeColor = Color.WhiteSmoke;
                }
                if (yazi.Name.Contains("linkLabel"))
                {
                    LinkLabel label = (LinkLabel)yazi;
                    label.LinkColor = Color.WhiteSmoke;
                }
                if (yazi.Name.Contains("textBox"))
                {
                    yazi.BackColor = Color.FromArgb(30, 30, 30);
                    yazi.ForeColor = Color.WhiteSmoke;
                }
                if (yazi.Name.Contains("comboBox"))
                {
                    ComboBox cbox = (ComboBox)yazi;
                    cbox.FlatStyle = FlatStyle.Popup;
                    cbox.BackColor = Color.FromArgb(30, 30, 30);
                    cbox.ForeColor = Color.WhiteSmoke;
                }
            }
        }
        private void Form5_Load(object sender, EventArgs e)
        {
            if (forum1.formuc.theme1.Checked == true)
            {
                System.Threading.Thread threddd = new System.Threading.Thread(() => darktheme());
                threddd.Start();
            }
            textBox1.PasswordChar = forum1.textBox1.PasswordChar;
            if (forum1.rcmng == 0)
            {
                comboBox1.Text = forum1.comboBox1.Text;
                comboBox2.Text = forum1.comboBox2.Text;
                comboBox3.Text = forum1.comboBox3.Text;
                comboBox4.Text = forum1.comboBox4.Text;
                label5.Text = forum1.label5.Text;
            }
            else
            {
                comboBox1.Items.Clear();
                comboBox3.Items.Clear();
                forum1.forum6.Show();
                label5.Text = forum1.forum6.Text;
                rjButton6.Visible = false;
                byte ender = 0;
                byte resulter = 0;
                ToolStripMenuItem tsmiay = (ToolStripMenuItem)forum1.forum6.toolStripDropDownButton1.DropDownItems[0];
                foreach (ToolStripMenuItem toolsmi in tsmiay.DropDownItems)
                {
                    comboBox1.Items.Add(toolsmi.Text);
                    if (toolsmi.Checked == true)
                    {
                        ender = 1;
                    }
                    if (ender == 0)
                    {
                        ++resulter;
                    }
                }
                comboBox1.SelectedIndex = resulter;
                resulter = 0;
                ender = 0;
                ToolStripMenuItem tsmihuhay = (ToolStripMenuItem)forum1.forum6.toolStripDropDownButton1.DropDownItems[1];
                foreach (ToolStripMenuItem toolsmi in tsmihuhay.DropDownItems)
                {
                    if (toolsmi.Checked == true)
                    {
                        ender = 1;
                    }
                    if (ender == 0)
                    {
                        ++resulter;
                    }
                }
                comboBox3.SelectedIndex = resulter;
                if (forum1.forum6.tosavencryptthenMACToolStripMenuItem.Checked == true)
                {
                    comboBox4.Text = "Encrypt-then-MAC";
                }
                else
                {
                    comboBox4.Text = "No-AUTH";
                }
                forum1.forum6.Hide();
            }
        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            label1.Focus();
            if (comboBox1.Text.Contains("RSA"))
            {
                comboBox2.Enabled = true;
            }
            else
            {
                comboBox2.Enabled = false;
            }
            if (comboBox1.Text.Contains("AES") == true)
            {
                comboBox3.Items.Clear();
                comboBox3.Items.AddRange(new string[] { "128", "192", "256" });
            }
            else if (comboBox1.Text.Contains("Serpent") == true)
            {
                comboBox3.Items.Clear();
                comboBox3.Items.AddRange(new string[] { "128", "192", "256" });
            }
            else if (comboBox1.Text.Contains("Twofish") == true)
            {
                comboBox3.Items.Clear();
                comboBox3.Items.AddRange(new string[] { "128", "192", "256" });
            }
            else if (comboBox1.Text.Contains("ThreeFish") == true)
            {
                comboBox3.Items.Clear();
                comboBox3.Items.AddRange(new string[] { "256", "512", "1024" });
            }
            else if (comboBox1.Text.Contains("Camellia") == true)
            {
                comboBox3.Items.Clear();
                comboBox3.Items.AddRange(new string[] { "128", "192", "256" });
            }
            else if (comboBox1.Text.Contains("ChaCha20") == true)
            {
                comboBox3.Items.Clear();
                comboBox3.Items.AddRange(new string[] { "256" });
            }
            else if (comboBox1.Text.Contains("HC") == true)
            {
                comboBox3.Items.Clear();
                comboBox3.Items.AddRange(new string[] { "128", "256" });
            }
            else if (comboBox1.Text.Contains("SM4") == true)
            {
                comboBox3.Items.Clear();
                comboBox3.Items.AddRange(new string[] { "128" });
            }
            comboBox3.SelectedIndex = comboBox3.Items.Count - 1;
        }

        private void rjButton1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("You need to enter a key.", label5.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                forum1.Show();
                if (forum1.rcmng == 0)
                {
                    forum1.comboBox1.Text = comboBox1.Text;
                    forum1.comboBox2.Text = comboBox2.Text;
                    forum1.comboBox3.Text = comboBox3.Text;
                    forum1.comboBox4.Text = comboBox4.Text;
                    forum1.textBox1.Text = textBox1.Text;
                    forum1.checkBox1.Checked = checkBox1.Checked;
                    if (forum1.encryptstatus == 1)
                    {
                        forum1.rjButton2.PerformClick();
                    }
                    else if (forum1.encryptstatus == 2)
                    {
                        forum1.rjButton1.PerformClick();
                    }
                }
                else
                {
                    forum1.forum6.Show();
                    ToolStripMenuItem tsmiay = (ToolStripMenuItem)forum1.forum6.toolStripDropDownButton1.DropDownItems[0];
                    foreach (ToolStripMenuItem toolsmi in tsmiay.DropDownItems)
                    {
                        if (toolsmi.Text.Contains(comboBox1.Text))
                        {
                            toolsmi.PerformClick();
                        }
                    }
                    ToolStripMenuItem tsmiuhay = (ToolStripMenuItem)forum1.forum6.toolStripDropDownButton1.DropDownItems[1];
                    foreach (ToolStripMenuItem toolsmi in tsmiuhay.DropDownItems)
                    {
                        if (toolsmi.Text.Contains(comboBox3.Text))
                        {
                            toolsmi.PerformClick();
                        }
                    }
                    if (comboBox4.Text == "Encrypt-then-MAC")
                    {
                        forum1.forum6.tosavencryptthenMACToolStripMenuItem.PerformClick();
                        if (forum1.forum6.tosavencryptthenMACToolStripMenuItem.Checked == false)
                        {
                            forum1.forum6.tosavencryptthenMACToolStripMenuItem.PerformClick();
                        }
                    }
                    else
                    {
                        forum1.forum6.tosavencryptthenMACToolStripMenuItem.PerformClick();
                        if (forum1.forum6.tosavencryptthenMACToolStripMenuItem.Checked == true)
                        {
                            forum1.forum6.tosavencryptthenMACToolStripMenuItem.PerformClick();
                        }
                    }
                    forum1.forum6.textBox2.Text = textBox1.Text;
                    forum1.forum6.checkBox2.Checked = checkBox1.Checked;
                    forum1.forum6.filepathh = forum1.listBox1.Items[0].ToString();
                    forum1.forum6.dntrnbcntrtlr = 1;
                    forum1.forum6.readfwithsalgorithmm(forum1.forum6.filepathh);
                    forum1.Hide();
                }
                    this.Hide();

            }
        }

        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, 0xA1, 0x2, 0);
            }
        }

        private void rjButton9_Click(object sender, EventArgs e)
        {
            forum1.formuc.Show();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            forum1.label6_Click(sender, e);
        }

        private void comboBox3_SelectedValueChanged(object sender, EventArgs e)
        {
            label1.Focus();
        }

        private void comboBox2_SelectedValueChanged(object sender, EventArgs e)
        {
            label1.Focus();
        }

        private void checkBox1_Click(object sender, EventArgs e)
        {
            byte equalopen = 0;
            if (forum1.formuc.Visible == true)
            {
                equalopen = 1;
            }
            if (equalopen == 0)
            {

                forum1.formuc.WindowState = FormWindowState.Minimized;
                forum1.formuc.Show();
            }
            if (checkBox1.Checked)
            {
                forum1.formuc.showpassword1.PerformClick();
            }
            else
            {
                forum1.formuc.showpassword0.PerformClick();

            }
            if (equalopen == 0)
            {
                forum1.formuc.Hide();
            }
        }

        private void Form5_Shown(object sender, EventArgs e)
        {
            if (forum1.formuc.xscapz1.Checked == true)
            {
                SetWindowDisplayAffinity(this.Handle, avoidcaxptures);
            }
            checkBox1.Checked = forum1.checkBox1.Checked;
        }

        private void label13_Click(object sender, EventArgs e)
        {
            rjButton9.PerformClick();
        }

        private void label12_Click(object sender, EventArgs e)
        {
            if (panel5.Visible == false)
            {
                panel5.Visible = true;
                label12.Text = "⬆";
            }
            else
            {
                panel5.Visible = false;
                label12.Text = "⬇";
            }
        }
    }
}
