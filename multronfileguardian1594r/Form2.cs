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
    public partial class Form2 : Form
    {
        public Form2(Form1 form)
        {
            InitializeComponent();
            mainform = form;
        }
        Form1 mainform;
        int keysize = 3072;
        private const uint avoidc = 0x00000011;
        [DllImport("user32.dll")]
        public static extern uint SetWindowDisplayAffinity(IntPtr hwnd, uint dwAffinity);
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

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("These are your RSA Public/Private Key. Public Key is the key that will be used to encrypt but cant be used to decrypt. Private Key is only for decrypt, Cant be used to encrypt. So protect your Private key, Dont give it anyone", "Multron RSA Key Generator", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void rjButton4_Click(object sender, EventArgs e)
        {
            System.Threading.Thread nthread = new System.Threading.Thread(() => genkey());
            nthread.Start();
        }



        private void rjButton7_Click(object sender, EventArgs e)
        {
            if (rjButton4.Enabled == true)
            {
                this.Close();
            }
        }

        private void rjButton8_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, 0xA1, 0x2, 0);
            }
        }
        private void darktheme()
        {
            panel2.BackColor = Color.FromArgb(40, 40, 40);
            this.BackColor = Color.FromArgb(23, 23, 23);
            rjButton8.BackColor = panel2.BackColor;
            comboBox2.FlatStyle = FlatStyle.Popup;
            comboBox2.BackColor = Color.FromArgb(30, 30, 30);
            comboBox2.ForeColor = Color.WhiteSmoke;      
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
            }
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            if (mainform.formuc.theme1.Checked == true)
            {
                System.Threading.Thread threddd = new System.Threading.Thread(() => darktheme());
                threddd.Start();
            }
            Control.CheckForIllegalCrossThreadCalls = false;
            comboBox2.Text = mainform.comboBox2.Text;
        }
        public string getstring(string data, char tag, short indx)
        {
            string reassemblied = "";
            short done = 0;
            if (indx == 0)
            {
                foreach (char c in data)
                {
                    if (c == tag)
                    {
                        break;
                    }
                    else
                    {
                        reassemblied = reassemblied + c;
                    }
                }
            }
            else
            {
                foreach (char c in data)
                {
                    if (done == 1)
                    {
                        reassemblied = reassemblied + c;
                    }
                    if (c == tag)
                    {
                        done = 1;
                    }
                }
            }
            return reassemblied;
        }
        public void genkey()
        {
            rjButton4.Enabled = false;
            rjButton4.Text = "Generating...";
            string rsakey = raes.rsageneratekey(keysize);
            textBox1.Text = getstring(rsakey, '#', 0);
            textBox2.Text = getstring(rsakey, '#', 1);
            rsakey = "";
            rjButton4.Text = "Generate RSA Key";
            rjButton4.Enabled = true;
            label1.Text = "Public Key";
            label2.Text = "Private Key";
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            mainform.closedrsakgen = 1;
        }

        private void comboBox2_SelectedValueChanged(object sender, EventArgs e)
        {
            label7.Focus();
            keysize = int.Parse(comboBox2.Text);
        }

        private void Form2_Shown(object sender, EventArgs e)
        {
            if (mainform.formuc.xscapz1.Checked == true)
            {
                SetWindowDisplayAffinity(this.Handle, avoidc);
            }
        }
    }
}
