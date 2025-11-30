using RJCodeAdvance.RJControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace multronfileguardian
{
    public partial class Form4 : Form
    {
        string mfgkeys = Application.StartupPath + "\\mfgsettings\\" + "publickeys.txt";
        Form1 frm1;

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
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

        public Form4(Form1 nform)
        {
            InitializeComponent();
            frm1 = nform;
        }
        private void darktheme()
        {
            panel2.BackColor = Color.FromArgb(40, 40, 40);
            this.BackColor = Color.FromArgb(23, 23, 23);
            rjButton8.BackColor = panel2.BackColor;
            foreach (Control yazi in this.Controls)
            {
                if (yazi.Name.Contains("rjButton"))
                {

                    yazi.BackColor = Color.FromArgb(43, 40, 40);
                    yazi.ForeColor = Color.WhiteSmoke;

                }
                if (yazi.Name.Contains("label"))
                {
                    if (yazi.Name != "label3")
                    {
                        yazi.ForeColor = Color.WhiteSmoke;
                    }
                    else
                    {
                        yazi.ForeColor = Color.Red;
                    }
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
                if (yazi.Name.Contains("listBox"))
                {
                    yazi.BackColor = Color.FromArgb(30, 30, 30);
                    yazi.ForeColor = Color.WhiteSmoke;
                }
            }
        }
        private void Form4_Load(object sender, EventArgs e)
        {

            if (frm1.formuc.theme1.Checked == true)
            {
                System.Threading.Thread threddd = new System.Threading.Thread(() => darktheme());
                threddd.Start();
            }
            if (File.Exists(mfgkeys))
            {
                listBox1.Items.AddRange(File.ReadAllLines(mfgkeys));
            }
        }

        private void rjButton1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Add(textBox1.Text + "=" + textBox2.Text);
        }

        private void rjButton2_Click(object sender, EventArgs e)
        {
            listBox1.Items.Remove(listBox1.SelectedItem);
        }

        private void rjButton3_Click(object sender, EventArgs e)
        {
            List<string> list = new List<string>();
            foreach (string s in listBox1.Items) 
            {
                list.Add(s); 
            }
            File.WriteAllLines(mfgkeys, list.ToArray());
        }

        private void rjButton4_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                string pbkey = "";
                short keystate = 0;
                foreach (char c in listBox1.SelectedItem.ToString())
                {
                    if (keystate == 1)
                    {
                        pbkey = pbkey + c;
                    }
                    if (c == '=')
                    {
                        keystate = 1;
                    }
                }
                frm1.textBox1.Text = pbkey;
                if (frm1.formuc.ckh1.Checked == true)
                {
                    Close();
                }
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

        private void rjButton7_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void rjButton8_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void label3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This area dont provide any encryption, please dont save your own symmetric key or dont save private key, Just save public keys", "Multron Key Hold", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void Form4_FormClosed(object sender, FormClosedEventArgs e)
        {
            frm1.closedholdkey = 1;
        }
    }
}
