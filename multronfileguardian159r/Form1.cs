using Org.BouncyCastle;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Engines;
using Org.BouncyCastle.Crypto.Modes;
using Org.BouncyCastle.Crypto.Paddings;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;
namespace multronfileguardian
{
    public partial class Form1 : Form
    {
        public short encryptstatus = 0;
        public Form3 formuc;
        public Form5 formbes;
        Form2 rsakeygen;
        Form4 holdkey;
        public Form6 forum6;
        public short closedholdkey = 1;
        public short closedrsakgen = 1;
        public short closedmng = 1;
        int keysize = 3072;
        int symkeysize = 256;
        public short iterationrate = 4;
        short rcm = 0;
        public short rcmng = 0;
        public int argmemrate = 262144;
        HMACSHA512 hsha512 = new HMACSHA512(new byte[] {0,1,2,3,4,5,5,65});
        public short rtoperation = 1;
        public short rttoperation = 0;
        public long loop = 3;
        List<string> cmprsdf = new List<string>();
        string mfgsfolder = Application.StartupPath + "\\mfgsettings";
        string mfgalg = Application.StartupPath + "\\mfgsettings" + "\\algorithm.txt";
        string mfgalgr = Application.StartupPath + "\\mfgsettings" + "\\algorithmr.txt";
        string mfgcm = Application.StartupPath + "\\mfgsettings" + "\\algorithmciphmod.txt";
        string mfgksize = Application.StartupPath + "\\mfgsettings" + "\\salgksize.txt";
        string mfgiterate = Application.StartupPath + "\\mfgsettings" + "\\iterate.txt";
        string mfgsiterate = Application.StartupPath + "\\mfgsettings" + "\\siterate.txt";
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
        private const uint avoidcapture = 0x00000011;
        [DllImport("user32.dll")]
        public static extern uint SetWindowDisplayAffinity(IntPtr hwnd, uint dwAffinity);

        public Form1(string[] args)
        {
            InitializeComponent();
            if (args.Length > 0)
            {
                if (args[0] == "-E")
                {
                    encryptstatus = 1;
                    rcm = 1;
                }
                else if (args[0] == "-D")
                {
                    encryptstatus = 2;
                    rcm = 1;
                }
                else if (args[0] == "--mng")
                {
                    rcm = 1;
                    rcmng = 1;
                }
                if (rcm == 1)
                {
                    int fs = 1;
                    for (fs = 1; fs < args.Length;)
                    {
                        listBox1.Items.Add(args[fs]);
                        ++fs;
                    }
                }
            }
            else
            {

            }
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            getsettings();
        }
        private void darktheme()
        {
            panel2.BackColor = Color.FromArgb(40, 40, 40);
            this.BackColor = Color.FromArgb(23, 23, 23);
            rjButton2.BackColor = Color.FromArgb(100, 0, 0);
            rjButton1.BackColor = Color.FromArgb(0, 70, 0);
            rjButton9.BackColor = panel2.BackColor;
            rjButton8.BackColor = panel2.BackColor;
            panel5.BackColor = panel2.BackColor;
            foreach (Control syazi in panel1.Controls)
            {
                if (syazi.Name.Contains("label"))
                {
                    syazi.ForeColor = Color.WhiteSmoke;
                }
            }
            foreach (Control yazi in this.Controls)
            {
                if (yazi.Name.Contains("rjButton"))
                {
                    if (yazi.Name != "rjButton1" && yazi.Name != "rjButton2")
                    {
                        yazi.BackColor = Color.FromArgb(43, 40, 40);
                        yazi.ForeColor = Color.WhiteSmoke;
                    }
                }
                if (yazi.Name.Contains("label"))
                {
                    yazi.ForeColor = Color.WhiteSmoke;
                }
                if (yazi.Name.Contains("checkBox"))
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
                if (yazi.Name.Contains("listBox"))
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
            foreach (Control cntwqe in panel4.Controls)
            {
                if (cntwqe.Name.Contains("rjButton"))
                {
                    cntwqe.BackColor = Color.FromArgb(43, 40, 40);
                    cntwqe.ForeColor = Color.WhiteSmoke;
                }
                if (cntwqe.Name.Contains("groupBox"))
                {
                    cntwqe.ForeColor = Color.WhiteSmoke;
                    foreach (Control cntrlq in cntwqe.Controls)
                    {
                        if (cntrlq.Name.Contains("comboBox"))
                        {
                            ComboBox cbox = (ComboBox)cntrlq;
                            cbox.FlatStyle = FlatStyle.Popup;
                            cbox.BackColor = Color.FromArgb(30, 30, 30);
                            cbox.ForeColor = Color.WhiteSmoke;
                        }
                        if (cntrlq.Name.Contains("linkLabel"))
                        {
                            LinkLabel label = (LinkLabel)cntrlq;
                            label.LinkColor = Color.WhiteSmoke;
                        }
                        if (cntrlq.Name.Contains("label"))
                        {
                            cntrlq.ForeColor = Color.WhiteSmoke;
                        }
                    }
                }
            }
            foreach (Control pyayzi in panel3.Controls)
            {
                if (pyayzi.Name.Contains("rjButton"))
                {
                    if (pyayzi.Name != "rjButton12")
                    {
                        pyayzi.BackColor = Color.FromArgb(43, 40, 40);
                        pyayzi.ForeColor = Color.WhiteSmoke;
                    }
                }
                if (pyayzi.Name.Contains("label"))
                {
                    pyayzi.ForeColor = Color.WhiteSmoke;
                }
                if (pyayzi.Name.Contains("textBox"))
                {
                    pyayzi.BackColor = Color.FromArgb(50, 50, 50);
                    pyayzi.ForeColor = Color.WhiteSmoke;
                }
            }
        }
        private void getsettings()
        {
            formuc = new Form3(this);
            formuc.Show();
            if (System.IO.Directory.Exists(mfgsfolder))
            {
                foreach (Control cntrlr in formuc.panel1.Controls)
                {
                    if (cntrlr.Name.Contains("groupBox") == true)
                    {
                        foreach (Control cntrltwo in cntrlr.Controls)
                        {
                            if (cntrltwo.GetType().ToString().Contains("RadioButton") == true)
                            {
                                string namez = new String(cntrltwo.Name.ToCharArray()).Substring(0, cntrltwo.Name.Length - 1);
                                if (System.IO.File.Exists(mfgsfolder + "\\" + namez + ".txt") == true)
                                {
                                    string svalue = System.IO.File.ReadAllText(mfgsfolder + '\\' + namez + ".txt");
                                    if (svalue != "")
                                    {
                                        if (svalue[0] == cntrltwo.Name[cntrltwo.Name.Length - 1])
                                        {
                                            RadioButton rbutton = (RadioButton)cntrltwo;
                                            rbutton.PerformClick();
                                        }
                                    }
                                }
                                else
                                {
                                    System.IO.File.Create(mfgsfolder + "\\" + namez + ".txt").Close();
                                }
                            }
                        }
                        foreach (Control cntrltwo in cntrlr.Controls)
                        {
                            if (cntrltwo.GetType().ToString().Contains("CheckBox") == true)
                            {
                                string namez = cntrltwo.Name;
                                if (System.IO.File.Exists(mfgsfolder + "\\" + namez + ".txt") == true)
                                {
                                    string svalue = System.IO.File.ReadAllText(mfgsfolder + '\\' + namez + ".txt");
                                    if (svalue != "")
                                    {
                                        if (svalue[0] == '1')
                                        {
                                            CheckBox rbutton = (CheckBox)cntrltwo;
                                            rbutton.Checked = true;
                                        }
                                    }
                                }
                                else
                                {
                                    System.IO.File.Create(mfgsfolder + "\\" + namez + ".txt").Close();
                                }
                            }
                        }
                    }
                }
                foreach (Control cntrlr in formuc.panel3.Controls)
                {
                    if (cntrlr.Name.Contains("groupBox") == true)
                    {
                        foreach (Control cntrltwo in cntrlr.Controls)
                        {
                            if (cntrltwo.GetType().ToString().Contains("RadioButton") == true)
                            {
                                string namez = new String(cntrltwo.Name.ToCharArray()).Substring(0, cntrltwo.Name.Length - 1);
                                if (System.IO.File.Exists(mfgsfolder + "\\" + namez + ".txt") == true)
                                {
                                    string svalue = System.IO.File.ReadAllText(mfgsfolder + '\\' + namez + ".txt");
                                    if (svalue != "")
                                    {
                                        if (svalue[0] == cntrltwo.Name[cntrltwo.Name.Length - 1])
                                        {
                                            RadioButton rbutton = (RadioButton)cntrltwo;
                                            rbutton.PerformClick();
                                        }
                                    }
                                }
                                else
                                {
                                    System.IO.File.Create(mfgsfolder + "\\" + namez + ".txt").Close();
                                }
                            }
                        }
                    }
                }
                if (formuc.theme1.Checked == true)
                {
                    darktheme();
                    formuc.sdarktheme();
                }
                if (formuc.savealgorithm1.Checked == true)
                {
                    if (System.IO.File.Exists(mfgalg) == true)
                    {
                        string algorithm = System.IO.File.ReadAllText(mfgalg);
                        short ty = 0;
                        foreach (string algg in comboBox1.Items)
                        {
                            if (algg == algorithm)
                            {
                                comboBox1.Text = algorithm;
                                ty = 1;
                                break;
                            }
                        }
                        if (ty == 0)
                        {
                            comboBox1.Text = "AES";
                        }
                    }
                    else
                    {
                        comboBox1.Text = "AES";
                    }
                    if (System.IO.File.Exists(mfgalgr) == true)
                    {
                        string algorithm = System.IO.File.ReadAllText(mfgalgr);
                        short ty = 0;
                        foreach (string algg in comboBox2.Items)
                        {
                            if (algg == algorithm)
                            {
                                comboBox2.Text = algorithm;
                                ty = 1;
                                break;
                            }
                        }
                        if (ty == 0)
                        {
                            comboBox2.Text = "3072";
                        }
                    }
                    else
                    {
                        comboBox2.Text = "3072";
                    }

                    if (System.IO.File.Exists(mfgcm) == true)
                    {
                        string algorithm = System.IO.File.ReadAllText(mfgcm);
                        short ty = 0;
                        foreach (string algg in comboBox4.Items)
                        {
                            if (algg == algorithm)
                            {
                                comboBox4.Text = algorithm;
                                ty = 1;
                                break;
                            }
                        }
                        if (ty == 0)
                        {
                            comboBox4.Text = "Encrypt-then-MAC";
                        }
                    }
                    else
                    {
                        comboBox4.Text = "Encrypt-then-MAC";
                    }
                    if (System.IO.File.Exists(mfgksize) == true)
                    {
                        string keysize = System.IO.File.ReadAllText(mfgksize);
                        foreach (string algg in comboBox3.Items)
                        {
                            if (algg == keysize)
                            {
                                comboBox3.Text = keysize;
                                break;
                            }
                        }
                    }
                }
            }
            else
            {
                System.IO.Directory.CreateDirectory(mfgsfolder);
            }
            if (formuc.iterationaut1.Checked == true)
            {
                if (System.IO.File.Exists(mfgiterate) == true)
                {
                    string iterat = System.IO.File.ReadAllText(mfgiterate);
                    if (iterat.Length > 8)
                    {
                        formuc.textBox1.Text = iterationrate.ToString();
                    }
                    else
                    {
                        formuc.textBox1.Text = iterat;
                        iterationrate = short.Parse(iterat);
                    }

                }
            }
            if (formuc.iterationshrd1.Checked == true)
            {
                if (System.IO.File.Exists(mfgsiterate) == true)
                {
                    string iterat = System.IO.File.ReadAllText(mfgsiterate);
                    if (iterat.Length > 2)
                    {
                        formuc.textBox2.Text = loop.ToString();
                    }
                    else
                    {
                        formuc.textBox2.Text = iterat;
                        loop = short.Parse(iterat);
                    }

                }
            }
            formuc.Hide();
            formuc.swillbesaved = 0;
            checkBox1.Checked = formuc.showpassword1.Checked;
            formuc.firststart = 1;
        }
        public void savesettings()
        {
            if (!System.IO.Directory.Exists(mfgsfolder))

            {
                System.IO.Directory.CreateDirectory(mfgsfolder);
            }
            foreach (Control cntrlr in formuc.panel1.Controls)
            {
                if (cntrlr.Name.Contains("groupBox") == true)
                {
                    foreach (Control cntrltwo in cntrlr.Controls)
                    {
                        if (cntrltwo.GetType().ToString().Contains("RadioButton") == true)
                        {
                            string namez = new String(cntrltwo.Name.ToCharArray()).Substring(0, cntrltwo.Name.Length - 1);
                            RadioButton rbutton = (RadioButton)cntrltwo;
                            if (System.IO.File.Exists(mfgsfolder + "\\" + namez + ".txt") == false)
                            {
                                System.IO.File.Create(mfgsfolder + "\\" + namez + ".txt").Close();
                            }
                            if (rbutton.Checked == true)
                            {
                                System.IO.File.WriteAllText(mfgsfolder + "\\" + namez + ".txt", cntrltwo.Name[cntrltwo.Name.Length - 1].ToString());
                            }
                        }
                    }
                }
                if (cntrlr.Name.Contains("groupBox") == true)
                {
                    foreach (Control cntrltwo in cntrlr.Controls)
                    {
                        if (cntrltwo.GetType().ToString().Contains("CheckBox") == true)
                        {
                            string namez = cntrltwo.Name;
                            CheckBox rbutton = (CheckBox)cntrltwo;
                            System.IO.File.WriteAllText(mfgsfolder + "\\" + namez + ".txt", rbutton.Checked ? "1" : "0");

                        }
                    }
                }
            }
            foreach (Control cntrlr in formuc.panel3.Controls)
            {
                if (cntrlr.Name.Contains("groupBox") == true)
                {
                    foreach (Control cntrltwo in cntrlr.Controls)
                    {
                        if (cntrltwo.GetType().ToString().Contains("RadioButton") == true)
                        {
                            string namez = new String(cntrltwo.Name.ToCharArray()).Substring(0, cntrltwo.Name.Length - 1);
                            RadioButton rbutton = (RadioButton)cntrltwo;
                            if (System.IO.File.Exists(mfgsfolder + "\\" + namez + ".txt") == false)
                            {
                                System.IO.File.Create(mfgsfolder + "\\" + namez + ".txt").Close();
                            }
                            if (rbutton.Checked == true)
                            {
                                System.IO.File.WriteAllText(mfgsfolder + "\\" + namez + ".txt", cntrltwo.Name[cntrltwo.Name.Length - 1].ToString());
                            }
                        }
                    }
                }
            }
            if (formuc.savealgorithm1.Checked == true)
            {
                System.IO.File.WriteAllText(mfgalg, comboBox1.Text);
                System.IO.File.WriteAllText(mfgalgr, comboBox2.Text);
                System.IO.File.WriteAllText(mfgksize, comboBox3.Text);
                System.IO.File.WriteAllText(mfgcm, comboBox4.Text);
            }
            if (formuc.iterationaut1.Checked == true)
            {
                System.IO.File.WriteAllText(mfgiterate, iterationrate.ToString());
            }
            if (formuc.iterationshrd1.Checked == true)
            {
                System.IO.File.WriteAllText(mfgsiterate, loop.ToString());
            }
        }

        public byte cmpcontroller()
        {
            byte iszip = 0;
            foreach (string filex in listBox1.Items)
            {
                if (filex.Contains(".zip"))
                {
                    iszip = 1;
                    cmprsdf.Add(filex);
                }
            }
            if (iszip == 1)
            {
                return 1;
            }
            return 0;
        }

        public void aesrsaprocesses(string key)
        {
            short nstate = 0;
            System.IO.BinaryReader okur = null;
            System.IO.BinaryWriter yazar = null;
            System.IO.MemoryStream tutar = null;
            System.Security.Cryptography.CryptoStream sifreler = null;
            try {
                System.Security.Cryptography.Aes rijndael = System.Security.Cryptography.Aes.Create();
                rijndael.KeySize = symkeysize;
                rijndael.BlockSize = 128;
                rijndael.Mode = System.Security.Cryptography.CipherMode.CBC;
                rijndael.Padding = System.Security.Cryptography.PaddingMode.PKCS7;
                byte[] aeskey = new byte[symkeysize / 8];
                byte[] ivtg = new byte[16];
                foreach (string dosyalar in listBox1.Items)
                {
                    nstate = 1;
                    if (encryptstatus == 1)
                    {
                        aeskey = raes.generaterandomkey(67);
                        byte[] nraeskey = raes.rsaencrypt(aeskey, key, keysize);
                        label4.Text = "Iterating Password...";
                        if (comboBox4.Text == "Encrypt-then-MAC")
                        {
                            byte[] scrkey = raes.argonkdf(aeskey, System.Text.Encoding.ASCII.GetBytes("youcanjoinsaltinfutureversionsmsmsms").Concat(System.Text.Encoding.ASCII.GetBytes(comboBox1.Text + "-" + comboBox3.Text)).ToArray(), iterationrate, argmemrate, 2, (symkeysize / 8) * 2);
                            hsha512 = new HMACSHA512(scrkey.Skip(scrkey.Length / 2).ToArray());
                            Org.BouncyCastle.Utilities.Arrays.Clear(aeskey);
                            aeskey = scrkey.Take(scrkey.Length / 2).ToArray();
                            Org.BouncyCastle.Utilities.Arrays.Clear(scrkey);
                            scrkey = null;
                        }
                        else
                        {
                            byte[] serpkey = raes.argonkdf(aeskey, System.Text.Encoding.ASCII.GetBytes("youcanjoinsaltinfutureversionsmsmsms"), iterationrate, argmemrate, 2, (symkeysize / 8));
                            aeskey = serpkey;
                            Org.BouncyCastle.Utilities.Arrays.Clear(serpkey);
                            serpkey = new byte[] { 0 };
                        }
                        rijndael.Key = new System.Security.Cryptography.Rfc2898DeriveBytes(aeskey, System.Text.Encoding.ASCII.GetBytes("youcanjoinsaltinfutureversionsmsmsms"), iterationrate, System.Security.Cryptography.HashAlgorithmName.SHA512).GetBytes(symkeysize / 8);
                        ivtg = new System.Security.Cryptography.Rfc2898DeriveBytes(reversebarray(raes.generaterandomkey(67)), System.Text.Encoding.ASCII.GetBytes(reversestring("youcanjoinsaltinfutureversivonsmsmsms")), 143, System.Security.Cryptography.HashAlgorithmName.SHA512).GetBytes(16);
                        rijndael.IV = ivtg;
                        if (comboBox4.Text == "Encrypt-then-MAC")
                        {
                            hsha512.TransformBlock(ivtg, 0, 16, null, 0);
                        }
                        okur = new System.IO.BinaryReader(System.IO.File.Open(dosyalar, System.IO.FileMode.Open, System.IO.FileAccess.Read));
                        yazar = new System.IO.BinaryWriter(System.IO.File.Open(dosyalar + ".mfg", System.IO.FileMode.Create, System.IO.FileAccess.Write));
                        yazar.Write(nraeskey, 0, keysize / 8);
                        yazar.Write(ivtg);
                        tutar = new System.IO.MemoryStream();
                        sifreler = new System.Security.Cryptography.CryptoStream(tutar, rijndael.CreateEncryptor(), System.Security.Cryptography.CryptoStreamMode.Write);
                        byte[] neww = new byte[1000000];
                        Org.BouncyCastle.Utilities.Arrays.Clear(aeskey);
                        long filesize = new System.IO.FileInfo(dosyalar).Length;
                        string filenamew = new System.IO.FileInfo(dosyalar).Name;
                        while (okur.BaseStream.Position < filesize)
                        {
                            long ig = filesize - okur.BaseStream.Position;
                            label4.Text = "Encrypting: " + filenamew + " | %" + Math.Round((((double)okur.BaseStream.Position / (double)filesize) * 100), 0).ToString();
                            if (ig > 1000000)
                            {
                                neww = new byte[1000000];
                                okur.Read(neww, 0, 1000000);
                                sifreler.Write(neww, 0, 1000000);
                                sifreler.Flush();
                                if (comboBox4.Text == "Encrypt-then-MAC")
                                {
                                    hsha512.TransformBlock(tutar.ToArray(), 0, (int)tutar.Length, null, 0);
                                }
                                yazar.Write(tutar.ToArray(), 0, (int)tutar.Length);
                                yazar.Flush();
                                tutar.SetLength(0);
                                Org.BouncyCastle.Utilities.Arrays.Clear(neww);
                            }
                            else
                            {
                                neww = new byte[(int)ig];
                                okur.Read(neww, 0, (int)ig);
                                sifreler.Write(neww, 0, (int)ig);
                                sifreler.FlushFinalBlock();
                                if (comboBox4.Text == "Encrypt-then-MAC")
                                {
                                    hsha512.TransformFinalBlock(tutar.ToArray(), 0, (int)tutar.Length);
                                }
                                yazar.Write(tutar.ToArray(), 0, (int)tutar.Length);
                                yazar.Flush();
                                tutar.SetLength(0);
                                Org.BouncyCastle.Utilities.Arrays.Clear(neww);
                            }
                        }
                        if (comboBox4.Text == "Encrypt-then-MAC")
                        {
                            yazar.Write(hsha512.Hash);
                            yazar.Flush();
                        }
                        if (okur != null)
                        {
                            okur.Dispose();
                        }
                        if (yazar != null)
                        {
                            yazar.Dispose();
                        }
                        if (sifreler != null)
                        {
                            sifreler.Dispose();
                        }
                        if (tutar != null)
                        {
                            tutar.Dispose();
                        }
                    }
                    else
                    {
                        okur = new System.IO.BinaryReader(System.IO.File.Open(dosyalar, System.IO.FileMode.Open, System.IO.FileAccess.Read));
                        aeskey = new byte[keysize / 8];
                        okur.Read(aeskey, 0, keysize / 8);
                        okur.Read(ivtg, 0, 16);
                        aeskey = raes.rsadecrypt(aeskey, key, keysize);
                        long sposit = okur.BaseStream.Position;
                        label4.Text = "Iterating Password...";
                        if (comboBox4.Text == "Encrypt-then-MAC")
                        {
                            label4.Text = "Authentication starting...";
                            byte[] scrkey = raes.argonkdf(aeskey, System.Text.Encoding.ASCII.GetBytes("youcanjoinsaltinfutureversionsmsmsms").Concat(System.Text.Encoding.ASCII.GetBytes(comboBox1.Text + "-" + comboBox3.Text)).ToArray(), iterationrate, argmemrate, 2, (symkeysize / 8) * 2);
                            hsha512 = new HMACSHA512(scrkey.Skip(scrkey.Length / 2).ToArray());
                            Org.BouncyCastle.Utilities.Arrays.Clear(aeskey);
                            aeskey = scrkey.Take(scrkey.Length / 2).ToArray();
                            Org.BouncyCastle.Utilities.Arrays.Clear(scrkey);
                            scrkey = null;
                            hsha512.TransformBlock(ivtg, 0, 16, null, 0);
                            string afname = new FileInfo(dosyalar).Name;
                            long afsz = new FileInfo(dosyalar).Length - 64;
                            byte[] nbyers = new byte[1000000];
                            byte[] machash = null;
                            while (okur.BaseStream.Position < afsz)
                            {
                                long whwearee = afsz - okur.BaseStream.Position;
                                label4.Text = "Authenticating: " + afname + " | %" + Math.Round((((double)okur.BaseStream.Position / (double)afsz) * 100), 0).ToString(); ;
                                if (whwearee > 1000000)
                                {
                                    nbyers = new byte[1000000];
                                    okur.Read(nbyers, 0, 1000000);
                                    hsha512.TransformBlock(nbyers, 0, 1000000, null, 0);
                                }
                                else
                                {
                                    nbyers = new byte[(int)whwearee];
                                    okur.Read(nbyers, 0, (int)whwearee);
                                    hsha512.TransformFinalBlock(nbyers, 0, (int)whwearee);
                                }
                            }
                            machash = hsha512.Hash;
                            byte[] mhashinf = new byte[64];
                            okur.BaseStream.Position = new FileInfo(dosyalar).Length - 64;
                            okur.Read(mhashinf, 0, 64);
                            short hcnt = 0;
                            byte notauthed = 0;
                            foreach (byte b in machash)
                            {
                                if (b == mhashinf[hcnt])
                                {

                                }
                                else
                                {
                                    notauthed = 1;
                                    break;
                                }
                                ++hcnt;
                            }
                            if (notauthed == 1)
                            {
                                okur.Close();
                                if (File.Exists(System.IO.Path.GetDirectoryName(dosyalar) + "\\" + System.IO.Path.GetFileNameWithoutExtension(dosyalar)))
                                {
                                    System.IO.File.Delete(System.IO.Path.GetDirectoryName(dosyalar) + "\\" + System.IO.Path.GetFileNameWithoutExtension(dosyalar));
                                }
                                label4.Text = afname + " Cannot be authenticated, Decryption process denied for this file!";
                                Thread.Sleep(4000);
                                label4.Text = "";
                                continue;
                            }
                        }
                        else
                        {
                            byte[] adsk = raes.argonkdf(aeskey, System.Text.Encoding.ASCII.GetBytes("youcanjoinsaltinfutureversionsmsmsms"), iterationrate, argmemrate, 2, (symkeysize / 8));
                            aeskey = adsk;
                            Org.BouncyCastle.Utilities.Arrays.Clear(adsk);
                            adsk = null;
                        }
                        okur.BaseStream.Position = sposit;
                        rijndael.Key = new System.Security.Cryptography.Rfc2898DeriveBytes(aeskey, System.Text.Encoding.ASCII.GetBytes("youcanjoinsaltinfutureversionsmsmsms"), iterationrate, System.Security.Cryptography.HashAlgorithmName.SHA512).GetBytes(symkeysize / 8);
                        rijndael.IV = ivtg;
                        Org.BouncyCastle.Utilities.Arrays.Clear(aeskey);
                        sifreler = new System.Security.Cryptography.CryptoStream(System.IO.File.Open(System.IO.Path.GetDirectoryName(dosyalar) + "\\" + System.IO.Path.GetFileNameWithoutExtension(dosyalar), System.IO.FileMode.Create, System.IO.FileAccess.Write), rijndael.CreateDecryptor(), System.Security.Cryptography.CryptoStreamMode.Write);
                        byte[] neww = new byte[1000000];
                        long filesize = new System.IO.FileInfo(dosyalar).Length;
                        if (comboBox4.Text == "Encrypt-then-MAC")
                        {
                            filesize = filesize - 64;
                        }
                        string filenamew = new System.IO.FileInfo(dosyalar).Name;
                        while (okur.BaseStream.Position < filesize)
                        {
                            long ig = filesize - okur.BaseStream.Position;
                            label4.Text = "Decrypting: " + filenamew + " | %" + Math.Round((((double)okur.BaseStream.Position / (double)filesize) * 100), 0).ToString();

                            if (ig > 1000000)
                            {
                                neww = new byte[1000000];
                                okur.Read(neww, 0, 1000000);
                                sifreler.Write(neww, 0, 1000000);
                                sifreler.Flush();
                                Org.BouncyCastle.Utilities.Arrays.Clear(neww);
                            }
                            else
                            {
                                neww = new byte[(int)ig];
                                okur.Read(neww, 0, (int)ig);
                                sifreler.Write(neww, 0, (int)ig);
                                sifreler.FlushFinalBlock();
                                Org.BouncyCastle.Utilities.Arrays.Clear(neww);
                            }
                        }
                        rijndael.Clear();
                        hsha512.Clear();
                        if (okur != null)
                        {
                            okur.Dispose();
                        }
                        if (yazar != null)
                        {
                            yazar.Dispose();
                        }
                        if (sifreler != null)
                        {
                            sifreler.Dispose();
                        }
                        if (tutar != null)
                        {
                            tutar.Dispose();
                        }
                    }
                    if (formuc.dfafterencrypted1.Checked == true)
                    {
                        if (formuc.shredbd.Checked == true)
                        {
                            shredfile(dosyalar);
                        }
                        System.IO.File.Delete(dosyalar);
                    }
                }
            }
            catch (Exception exc) {
                nstate = 0;
                MessageBox.Show("Operation ended with a error, these may cause an error's occure: file dont exists, program haven't access to file, your password is wrong or something else, error = " + exc.Message + " | You can contact programmer, Discord = dr_wellss", "Multron File Guardian", MessageBoxButtons.OK, MessageBoxIcon.Error);
                try
                {
                    if (okur != null)
                    {
                        okur.Dispose();
                    }
                    if (yazar != null)
                    {
                        string pathof = ((FileStream)yazar.BaseStream).Name;
                        yazar.Dispose();
                        if (File.Exists(pathof) == true)
                        {
                            File.Delete(pathof);
                        }
                    }
                    if (sifreler != null)
                    {
                        sifreler.Dispose();
                    }
                    if (tutar != null)
                    {
                        tutar.Dispose();
                    }
                }
                catch (Exception k)
                {

                }
                finally
                {
                    if (okur != null)
                    {
                        okur.Dispose();
                    }
                    if (yazar != null)
                    {
                        yazar.Dispose();
                    }
                    if (sifreler != null)
                    {
                        sifreler.Dispose();
                    }
                    if (tutar != null)
                    {
                        tutar.Dispose();
                    }
                }
            }
            if (nstate == 1)
            {
                label4.Text = "Operation Done.";
                Thread.Sleep(3500); 
                if (formuc.cmpression1.Checked == false || encryptstatus == 1)
                {
                    listBox1.Items.Clear();
                }
                if (formuc.cmpression1.Checked == true && encryptstatus == 2)
                {
                    if (cmpcontroller() == 1)
                    {
                        if (panel3.InvokeRequired)
                        {
                            panel3.Invoke(new MethodInvoker(() => panel3.Visible = true));
                        }
                        else
                        {
                            panel3.Visible = true;
                        }
                    }
                    else
                    {
                        listBox1.Items.Clear();
                    }
                }
            }
            edcontrols(1);
            label4.Text = "";
            GC.Collect();
            if (rcm == 1)
            {
                Application.Exit();
            }
        }
        public void strcphprocesses(string key, IStreamCipher iscipher, short blocksize)
        {
            BinaryReader okur = null;
            BinaryWriter yazar = null;
            short nstate = 0;
            Boolean cryptstate = false;
            byte[] seasalt = new byte[32];
            byte[] keyt = new byte[32];
            byte[] ivtg = new byte[blocksize];
            try
            {
                IStreamCipher chatea = iscipher;
                if (encryptstatus == 1)
                {
                    cryptstate = true;
                }
                else
                {
                    cryptstate = false;
                }
                foreach (string dosyalar in listBox1.Items)
                {
                    nstate = 1;
                    okur = new BinaryReader(File.Open(dosyalar, FileMode.Open, FileAccess.Read));
                    label4.Text = "Iterating Password...";
                    if (encryptstatus == 1)
                    {
                        seasalt = raes.generaterandomkey(32);
                        yazar = new BinaryWriter(File.Open(dosyalar + ".mfg", FileMode.Create, FileAccess.Write));
                        ivtg = new System.Security.Cryptography.Rfc2898DeriveBytes(reversebarray(raes.generaterandomkey(67)), System.Text.Encoding.ASCII.GetBytes(reversestring("youcanjoinsaltinfutureversivonsmsmsms")), 143, System.Security.Cryptography.HashAlgorithmName.SHA512).GetBytes(blocksize);
                        if (comboBox4.Text == "Encrypt-then-MAC")
                        {
                            byte[] scrkey = raes.argonkdf(System.Text.Encoding.UTF8.GetBytes(key), seasalt.Concat(System.Text.Encoding.ASCII.GetBytes(comboBox1.Text + "-" + comboBox3.Text)).ToArray(), iterationrate, argmemrate, 2, (symkeysize / 8) * 2);
                            hsha512 = new HMACSHA512(scrkey.Skip(scrkey.Length / 2).ToArray());
                            keyt = scrkey.Take(scrkey.Length / 2).ToArray();
                            Org.BouncyCastle.Utilities.Arrays.Clear(scrkey);
                            scrkey = null;
                            hsha512.TransformBlock(ivtg, 0, blocksize, null, 0);
                        }
                        else
                        {
                            keyt = raes.argonkdf(System.Text.Encoding.UTF8.GetBytes(key), seasalt, iterationrate, argmemrate, 2, (symkeysize / 8));
                        }
                        yazar.Write(ivtg);
                    }
                    else
                    {
                        yazar = new BinaryWriter(System.IO.File.Open(System.IO.Path.GetDirectoryName(dosyalar) + "\\" + System.IO.Path.GetFileNameWithoutExtension(dosyalar), FileMode.Create, FileAccess.Write));
                        okur.Read(ivtg, 0, blocksize);
                        okur.Read(seasalt, 0, 32);
                        if (comboBox4.Text == "Encrypt-then-MAC")
                        {
                            okur.BaseStream.Position = new FileInfo(dosyalar).Length - 96;
                        }
                        else
                        {
                            okur.BaseStream.Position = new FileInfo(dosyalar).Length - 32;
                        }
                        okur.Read(seasalt, 0, 32);
                        okur.BaseStream.Position = blocksize;
                        if (comboBox4.Text == "Encrypt-then-MAC")
                        {
                            label4.Text = "Authentication starting...";
                            byte[] scrkey = raes.argonkdf(System.Text.Encoding.UTF8.GetBytes(key), seasalt.Concat(System.Text.Encoding.ASCII.GetBytes(comboBox1.Text + "-" + comboBox3.Text)).ToArray(), iterationrate, argmemrate, 2, (symkeysize / 8) * 2);
                            hsha512 = new HMACSHA512(scrkey.Skip(scrkey.Length / 2).ToArray());
                            keyt = scrkey.Take(scrkey.Length / 2).ToArray();
                            Org.BouncyCastle.Utilities.Arrays.Clear(scrkey);
                            scrkey = null;
                            hsha512.TransformBlock(ivtg, 0, blocksize, null, 0);
                            string afname = new FileInfo(dosyalar).Name;
                            long afsz = new FileInfo(dosyalar).Length - 96;
                            byte[] nbyers = new byte[1000000];
                            byte[] machash = null;
                            while (okur.BaseStream.Position < afsz)
                            {
                                long whwearee = afsz - okur.BaseStream.Position;
                                label4.Text = "Authenticating: " + afname + " | %" + Math.Round((((double)okur.BaseStream.Position / (double)afsz) * 100), 0).ToString(); ;
                                if (whwearee > 1000000)
                                {
                                    nbyers = new byte[1000000];
                                    okur.Read(nbyers, 0, 1000000);
                                    hsha512.TransformBlock(nbyers, 0, 1000000, null, 0);
                                }
                                else
                                {
                                    nbyers = new byte[(int)whwearee];
                                    okur.Read(nbyers, 0, (int)whwearee);
                                    hsha512.TransformFinalBlock(nbyers, 0, (int)whwearee);
                                }
                            }
                            machash = hsha512.Hash;
                            byte[] mhashinf = new byte[64];
                            okur.BaseStream.Position = new FileInfo(dosyalar).Length - 64;
                            okur.Read(mhashinf, 0, 64);
                            short hcnt = 0;
                            byte notauthed = 0;
                            foreach (byte b in machash)
                            {
                                if (b == mhashinf[hcnt])
                                {

                                }
                                else
                                {
                                    notauthed = 1;
                                    break;
                                }
                                ++hcnt;
                            }
                            if (notauthed == 1)
                            {
                                okur.Close();
                                yazar.Close();
                                if (File.Exists(System.IO.Path.GetDirectoryName(dosyalar) + "\\" + System.IO.Path.GetFileNameWithoutExtension(dosyalar)))
                                {
                                    System.IO.File.Delete(System.IO.Path.GetDirectoryName(dosyalar) + "\\" + System.IO.Path.GetFileNameWithoutExtension(dosyalar));
                                }
                                label4.Text = afname + " Cannot be authenticated, Decryption process denied for this file!";
                                Thread.Sleep(4000);
                                label4.Text = ""; 
                                continue;
                            }
                        }
                        else
                        {
                            keyt = raes.argonkdf(System.Text.Encoding.UTF8.GetBytes(key), seasalt, iterationrate, argmemrate, 2, (symkeysize / 8));
                        }
                        okur.BaseStream.Position = blocksize;

                    }
                    chatea.Init(cryptstate, new ParametersWithIV(new KeyParameter(keyt), ivtg));
                    byte[] bytesx = new byte[1000000];
                    Org.BouncyCastle.Utilities.Arrays.Clear(keyt);
                    long fsize = new System.IO.FileInfo(dosyalar).Length;
                    string filenamew = new System.IO.FileInfo(dosyalar).Name;
                    if (encryptstatus != 1)
                    {
                        fsize = fsize - 32;
                        if (comboBox4.Text == "Encrypt-then-MAC")
                        {
                            fsize = fsize - 64;
                        }
                    }
                    while (okur.BaseStream.Position < fsize)
                    {
                        long whereweare = fsize - okur.BaseStream.Position;
                        if (encryptstatus == 1)
                        {
                            label4.Text = "Encrypting: " + filenamew + " | %" + Math.Round((((double)okur.BaseStream.Position / (double)fsize) * 100), 0).ToString();
                        }
                        else
                        {
                            label4.Text = "Decrypting: " + filenamew + " | %" + Math.Round((((double)okur.BaseStream.Position / (double)fsize) * 100), 0).ToString();
                        }
                        if (whereweare > 1000000)
                        {
                            bytesx = new byte[1000000];
                            okur.Read(bytesx, 0, 1000000);
                            byte[] encdata = new byte[1000000];
                            chatea.ProcessBytes(bytesx, 0, 1000000, encdata, 0);
                            if (encryptstatus == 1 && comboBox4.Text == "Encrypt-then-MAC")
                            {
                                hsha512.TransformBlock(encdata, 0, encdata.Length, null, 0);
                            }
                            yazar.Write(encdata, 0, 1000000);
                            yazar.Flush();
                            Org.BouncyCastle.Utilities.Arrays.Clear(bytesx);
                        }
                        else
                        {
                            bytesx = new byte[(int)whereweare];
                            okur.Read(bytesx, 0, (int)whereweare);
                            byte[] encdata = new byte[(int)whereweare];
                            chatea.ProcessBytes(bytesx, 0, (int)whereweare, encdata, 0);
                            if (encryptstatus == 1 && comboBox4.Text == "Encrypt-then-MAC")
                            {
                                hsha512.TransformFinalBlock(encdata, 0, (int)whereweare);
                            }
                            yazar.Write(encdata, 0, (int)whereweare);
                            yazar.Flush();
                            Org.BouncyCastle.Utilities.Arrays.Clear(bytesx);
                        }
                    }
                    if (encryptstatus == 1)
                    {
                        yazar.Write(seasalt);
                        yazar.Flush();
                        if (comboBox4.Text == "Encrypt-then-MAC")
                        {
                            yazar.Write(hsha512.Hash);
                            yazar.Flush();
                        }
                    }
                    chatea.Reset();
                    hsha512.Clear();
                    if (okur != null)
                    {
                        okur.Dispose();
                    }
                    if (yazar != null)
                    {
                        yazar.Dispose();
                    }
                    if (formuc.dfafterencrypted1.Checked == true)
                    {
                        if (formuc.shredbd.Checked == true)
                        {
                            shredfile(dosyalar);
                        }
                        System.IO.File.Delete(dosyalar);
                    }
                }
            }
            catch (Exception x)
            {
                nstate = 0;
                MessageBox.Show("Operation ended with a error, these may cause an error's occure: file dont exists, program haven't access to file, your password is wrong or something else, error = " + x.Message + " | You can contact programmer, Discord = dr_wellss", "Multron File Guardian", MessageBoxButtons.OK, MessageBoxIcon.Error);
                try
                {
                    if (okur != null)
                    {
                        okur.Dispose();
                    }
                    if (yazar != null)
                    {
                        string pathof = ((FileStream)yazar.BaseStream).Name;
                        yazar.Dispose();
                        if (File.Exists(pathof) == true)
                        {
                            File.Delete(pathof);
                        }
                    }

                }
                catch (Exception k)
                {

                }
                finally
                {
                    if (okur != null)
                    {
                        okur.Dispose();
                    }
                    if (yazar != null)
                    {
                        yazar.Dispose();
                    }
                }
            }

            if (nstate == 1)
            {
                label4.Text = "Operation Done.";
                Thread.Sleep(3500);
                if (formuc.cmpression1.Checked == false || encryptstatus == 1)
                {
                    listBox1.Items.Clear();
                }
                if (formuc.cmpression1.Checked == true && encryptstatus == 2)
                {
                    if (cmpcontroller() == 1)
                    {
                        if (panel3.InvokeRequired)
                        {
                            panel3.Invoke(new MethodInvoker(() => panel3.Visible = true));
                        }
                        else
                        {
                            panel3.Visible = true;
                        }
                    }
                    else
                    {
                        listBox1.Items.Clear();
                    }
                }
            }
            edcontrols(1);
            GC.Collect();
            label4.Text = "";
            if (rcm == 1)
            {
                Application.Exit();
            }
        }

        public void strcphrsaprocesses(string key, IStreamCipher iscphr, short blocksize)
        {
            BinaryReader okur = null;
            BinaryWriter yazar = null;
            short nstate = 0;
            IStreamCipher sifreler = iscphr;
            try
            {
                byte[] serpentkey = { 0 };
                byte[] serkey = { 0 };
                byte[] ivtg = new byte[blocksize];
                foreach (string dosyalar in listBox1.Items)
                {
                    if (encryptstatus == 1)
                    {
                        nstate = 1;
                        label4.Text = "Iterating Password...";
                        serpentkey = raes.generaterandomkey(67);
                        serkey = raes.rsaencrypt(serpentkey, key, keysize);
                        ivtg = new System.Security.Cryptography.Rfc2898DeriveBytes(reversebarray(raes.generaterandomkey(67)), System.Text.Encoding.ASCII.GetBytes(reversestring("youcanjoinsaltinfutureversivonsmsmsms")), 143, System.Security.Cryptography.HashAlgorithmName.SHA512).GetBytes(blocksize);
                        if (comboBox4.Text == "Encrypt-then-MAC")
                        {
                            byte[] scrkey = raes.argonkdf(serpentkey, System.Text.Encoding.ASCII.GetBytes("youcanjoinsaltinfutureversionsmsmsms").Concat(System.Text.Encoding.ASCII.GetBytes(comboBox1.Text + "-" + comboBox3.Text)).ToArray(), iterationrate, argmemrate, 2, (symkeysize / 8) * 2);
                            hsha512 = new HMACSHA512(scrkey.Skip(scrkey.Length / 2).ToArray());
                            Org.BouncyCastle.Utilities.Arrays.Clear(serpentkey);
                            serpentkey = scrkey.Take(scrkey.Length / 2).ToArray();
                            Org.BouncyCastle.Utilities.Arrays.Clear(scrkey);
                            scrkey = null;
                            hsha512.TransformBlock(ivtg, 0, blocksize, null, 0);
                        }
                        else
                        {
                            byte[] serpkey = raes.argonkdf(serpentkey, System.Text.Encoding.ASCII.GetBytes("youcanjoinsaltinfutureversionsmsmsms"), iterationrate, argmemrate, 2, (symkeysize / 8));
                            serpentkey = serpkey;
                            Org.BouncyCastle.Utilities.Arrays.Clear(serpkey);
                            serpkey = new byte[] { 0 };
                        }
                        sifreler.Init(true, new ParametersWithIV(new KeyParameter(serpentkey), ivtg));
                        Org.BouncyCastle.Utilities.Arrays.Clear(serpentkey);
                        okur = new BinaryReader(File.Open(dosyalar, FileMode.Open, FileAccess.Read));
                        yazar = new BinaryWriter(File.Open(dosyalar + ".mfg", FileMode.Create, FileAccess.Write));
                        yazar.Write(serkey, 0, keysize / 8);
                        yazar.Write(ivtg);
                        byte[] bxynew = new byte[1000000];
                        long fsize = new System.IO.FileInfo(dosyalar).Length;
                        string filenamew = new System.IO.FileInfo(dosyalar).Name;
                        while (okur.BaseStream.Position < fsize)
                        {
                            long whereewearee = fsize - okur.BaseStream.Position;
                            label4.Text = "Encrypting: " + filenamew + " | %" + Math.Round((((double)okur.BaseStream.Position / (double)fsize) * 100), 0).ToString();
                            if (whereewearee > 1000000)
                            {
                                bxynew = new byte[1000000];
                                okur.Read(bxynew, 0, 1000000);
                                byte[] encrypted = new byte[1000000];
                                sifreler.ProcessBytes(bxynew, 0, 1000000, encrypted, 0);
                                if (comboBox4.Text == "Encrypt-then-MAC")
                                {
                                    hsha512.TransformBlock(encrypted, 0, 1000000, null, 0);
                                }
                                yazar.Write(encrypted, 0, 1000000);
                                yazar.Flush();
                                Org.BouncyCastle.Utilities.Arrays.Clear(bxynew);
                            }
                            else
                            {
                                bxynew = new byte[(int)whereewearee];
                                okur.Read(bxynew, 0, (int)whereewearee);
                                byte[] encrypted = new byte[(int)whereewearee];
                                sifreler.ProcessBytes(bxynew, 0, (int)whereewearee, encrypted, 0);
                                if (comboBox4.Text == "Encrypt-then-MAC")
                                {
                                    hsha512.TransformFinalBlock(encrypted, 0, (int)whereewearee);
                                }
                                yazar.Write(encrypted, 0, (int)whereewearee);
                                yazar.Flush();
                                Org.BouncyCastle.Utilities.Arrays.Clear(bxynew);
                            }
                        }
                        if (comboBox4.Text == "Encrypt-then-MAC")
                        {
                            yazar.Write(hsha512.Hash);
                            yazar.Flush();
                        }
                        if (okur != null)
                        {
                            okur.Dispose();
                        }
                        if (yazar != null)
                        {
                            yazar.Dispose();
                        }
                        sifreler.Reset();
                        hsha512.Clear();
                        if (formuc.dfafterencrypted1.Checked == true)
                        {
                            if (formuc.shredbd.Checked == true)
                            {
                                shredfile(dosyalar);
                            }
                            System.IO.File.Delete(dosyalar);
                        }
                    }
                    else
                    {
                        nstate = 1;
                        okur = new BinaryReader(File.Open(dosyalar, FileMode.Open, FileAccess.Read));
                        yazar = new BinaryWriter(System.IO.File.Open(System.IO.Path.GetDirectoryName(dosyalar) + "\\" + System.IO.Path.GetFileNameWithoutExtension(dosyalar), FileMode.Create, FileAccess.Write));
                        serpentkey = new byte[keysize / 8];
                        okur.Read(serpentkey, 0, keysize / 8);
                        okur.Read(ivtg, 0, blocksize);
                        byte[] dsk = raes.rsadecrypt(serpentkey, key, keysize);
                        long sposit = okur.BaseStream.Position;
                        label4.Text = "Iterating Password...";
                        if (comboBox4.Text == "Encrypt-then-MAC")
                        {
                            label4.Text = "Authentication starting...";
                            byte[] scrkey = raes.argonkdf(dsk, System.Text.Encoding.ASCII.GetBytes("youcanjoinsaltinfutureversionsmsmsms").Concat(System.Text.Encoding.ASCII.GetBytes(comboBox1.Text + "-" + comboBox3.Text)).ToArray(), iterationrate, argmemrate, 2, (symkeysize / 8) * 2);
                            hsha512 = new HMACSHA512(scrkey.Skip(scrkey.Length / 2).ToArray());
                            Org.BouncyCastle.Utilities.Arrays.Clear(dsk);
                            dsk = scrkey.Take(scrkey.Length / 2).ToArray();
                            Org.BouncyCastle.Utilities.Arrays.Clear(scrkey);
                            scrkey = null;
                            hsha512.TransformBlock(ivtg, 0, blocksize, null, 0);
                            string afname = new FileInfo(dosyalar).Name;
                            long afsz = new FileInfo(dosyalar).Length - 64;
                            byte[] nbyers = new byte[1000000];
                            byte[] machash = null;
                            while (okur.BaseStream.Position < afsz)
                            {
                                long whwearee = afsz - okur.BaseStream.Position;
                                label4.Text = "Authenticating: " + afname + " | %" + Math.Round((((double)okur.BaseStream.Position / (double)afsz) * 100), 0).ToString(); ;
                                if (whwearee > 1000000)
                                {
                                    nbyers = new byte[1000000];
                                    okur.Read(nbyers, 0, 1000000);
                                    hsha512.TransformBlock(nbyers, 0, 1000000, null, 0);
                                }
                                else
                                {
                                    nbyers = new byte[(int)whwearee];
                                    okur.Read(nbyers, 0, (int)whwearee);
                                    hsha512.TransformFinalBlock(nbyers, 0, (int)whwearee);
                                }
                            }
                            machash = hsha512.Hash;
                            byte[] mhashinf = new byte[64];
                            okur.BaseStream.Position = new FileInfo(dosyalar).Length - 64;
                            okur.Read(mhashinf, 0, 64);
                            short hcnt = 0;
                            byte notauthed = 0;
                            foreach (byte b in machash)
                            {
                                if (b == mhashinf[hcnt])
                                {

                                }
                                else
                                {
                                    notauthed = 1;
                                    break;
                                }
                                ++hcnt;
                            }
                            if (notauthed == 1)
                            {
                                okur.Close();
                                yazar.Close();
                                if (File.Exists(System.IO.Path.GetDirectoryName(dosyalar) + "\\" + System.IO.Path.GetFileNameWithoutExtension(dosyalar)))
                                {
                                    System.IO.File.Delete(System.IO.Path.GetDirectoryName(dosyalar) + "\\" + System.IO.Path.GetFileNameWithoutExtension(dosyalar));
                                }
                                label4.Text = afname + " Cannot be authenticated, Decryption process denied for this file!";
                                Thread.Sleep(4000);
                                label4.Text = "";
                                continue;
                            }
                        }
                        else
                        {
                            byte[] adsk = raes.argonkdf(dsk, System.Text.Encoding.ASCII.GetBytes("youcanjoinsaltinfutureversionsmsmsms"), iterationrate, argmemrate, 2, (symkeysize / 8));
                            dsk = adsk;
                            Org.BouncyCastle.Utilities.Arrays.Clear(adsk);
                            adsk = null;
                        }
                        okur.BaseStream.Position = sposit;
                        sifreler.Init(false, new ParametersWithIV(new KeyParameter(dsk), ivtg));
                        Org.BouncyCastle.Utilities.Arrays.Clear(dsk);
                        dsk = null;
                        byte[] bynetx = new byte[1000000];
                        long fsize = new System.IO.FileInfo(dosyalar).Length;
                        if (comboBox4.Text == "Encrypt-then-MAC")
                        {
                            fsize = fsize - 64;
                        }
                        string filenamew = new System.IO.FileInfo(dosyalar).Name;
                        while (okur.BaseStream.Position < fsize)
                        {
                            long whweare = fsize - okur.BaseStream.Position;
                            label4.Text = "Decrypting: " + filenamew + " | %" + Math.Round((((double)okur.BaseStream.Position / (double)fsize) * 100), 0).ToString();
                            if (whweare > 1000000)
                            {
                                bynetx = new byte[1000000];
                                okur.Read(bynetx, 0, 1000000);
                                byte[] encrypted = new byte[1000000];
                                sifreler.ProcessBytes(bynetx, 0, 1000000, encrypted, 0);
                                yazar.Write(encrypted, 0, 1000000);
                                yazar.Flush();
                                Org.BouncyCastle.Utilities.Arrays.Clear(bynetx);
                            }
                            else
                            {
                                bynetx = new byte[(int)whweare];
                                okur.Read(bynetx, 0, (int)whweare);
                                byte[] encrypted = new byte[(int)whweare];
                                sifreler.ProcessBytes(bynetx, 0, (int)whweare, encrypted, 0);
                                yazar.Write(encrypted, 0, (int)whweare);
                                yazar.Flush();
                                Org.BouncyCastle.Utilities.Arrays.Clear(bynetx);
                            }
                        }
                        if (okur != null)
                        {
                            okur.Dispose();
                        }
                        if (yazar != null)
                        {
                            yazar.Dispose();
                        }
                        sifreler.Reset();
                        hsha512.Clear();
                        if (formuc.dfafterencrypted1.Checked == true)
                        {
                            if (formuc.shredbd.Checked == true)
                            {
                                shredfile(dosyalar);
                            }
                            System.IO.File.Delete(dosyalar);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                nstate = 0;
                MessageBox.Show("Operation ended with a error, these may cause an error's occure: file dont exists, program haven't access to file, your password is wrong or something else, error = " + ex.Message + " | You can contact programmer, Discord = dr_wellss", "Multron File Guardian", MessageBoxButtons.OK, MessageBoxIcon.Error);
                try
                {
                    if (okur != null)
                    {
                        okur.Dispose();
                    }
                    if (yazar != null)
                    {
                        string pathof = ((FileStream)yazar.BaseStream).Name;
                        yazar.Dispose();
                        if (File.Exists(pathof) == true)
                        {
                            File.Delete(pathof);
                        }
                    }

                }
                catch (Exception k)
                {

                }
                finally
                {
                    if (okur != null)
                    {
                        okur.Dispose();
                    }
                    if (yazar != null)
                    {
                        yazar.Dispose();
                    }
                }
            }
            if (nstate == 1)
            {
                label4.Text = "Operation Done.";
                Thread.Sleep(3500); 
                if (formuc.cmpression1.Checked == false || encryptstatus == 1)
                {
                    listBox1.Items.Clear();
                }
                if (formuc.cmpression1.Checked == true && encryptstatus == 2)
                {
                    if (cmpcontroller() == 1)
                    {
                        if (panel3.InvokeRequired)
                        {
                            panel3.Invoke(new MethodInvoker(() => panel3.Visible = true));
                        }
                        else
                        {
                            panel3.Visible = true;
                        }
                    }
                    else
                    {
                        listBox1.Items.Clear();
                    }
                }
            }
            edcontrols(1);
            GC.Collect();
            label4.Text = "";
            if (rcm == 1)
            {
                Application.Exit();
            }
        }
        public void bciphersrsaprocesses(string key, IBlockCipher bc, short blocksize = 16)
        {
            BinaryReader okur = null;
            BinaryWriter yazar = null;
            short nstate = 0;
            PaddedBufferedBlockCipher sifreler = new PaddedBufferedBlockCipher(new CbcBlockCipher(bc), new Pkcs7Padding());
            try
            {
                byte[] serpentkey = { 0 };
                byte[] serkey = { 0 };
                byte[] ivtg = new byte[blocksize];
                foreach (string dosyalar in listBox1.Items)
                {
                    if (encryptstatus == 1)
                    {
                        nstate = 1;
                        label4.Text = "Iterating Password...";
                        serpentkey = raes.generaterandomkey(67);
                        serkey = raes.rsaencrypt(serpentkey, key, keysize);
                        ivtg = new System.Security.Cryptography.Rfc2898DeriveBytes(reversebarray(raes.generaterandomkey(67)), System.Text.Encoding.ASCII.GetBytes(reversestring("youcanjoinsaltinfutureversivonsmsmsms")), 143, System.Security.Cryptography.HashAlgorithmName.SHA512).GetBytes(blocksize);
                        if (comboBox4.Text == "Encrypt-then-MAC")
                        {
                            byte[] scrkey = raes.argonkdf(serpentkey, System.Text.Encoding.ASCII.GetBytes("youcanjoinsaltinfutureversionsmsmsms").Concat(System.Text.Encoding.ASCII.GetBytes(comboBox1.Text + "-" + comboBox3.Text)).ToArray(), iterationrate, argmemrate, 2, (symkeysize / 8) * 2);
                            hsha512 = new HMACSHA512(scrkey.Skip(scrkey.Length / 2).ToArray());
                            Org.BouncyCastle.Utilities.Arrays.Clear(serpentkey);
                            serpentkey = scrkey.Take(scrkey.Length / 2).ToArray();
                            Org.BouncyCastle.Utilities.Arrays.Clear(scrkey);
                            scrkey = null;
                            hsha512.TransformBlock(ivtg, 0, blocksize, null, 0);
                        }
                        else
                        {
                            byte[] serpkey = raes.argonkdf(serpentkey, System.Text.Encoding.ASCII.GetBytes("youcanjoinsaltinfutureversionsmsmsms"), iterationrate, argmemrate, 2, (symkeysize / 8));
                            serpentkey = serpkey;
                            Org.BouncyCastle.Utilities.Arrays.Clear(serpkey);
                            serpkey = null;
                        }
                        sifreler.Init(true, new ParametersWithIV(new KeyParameter(serpentkey), ivtg));
                        okur = new BinaryReader(File.Open(dosyalar, FileMode.Open, FileAccess.Read));
                        yazar = new BinaryWriter(File.Open(dosyalar + ".mfg", FileMode.Create, FileAccess.Write));
                        yazar.Write(serkey, 0, keysize / 8);
                        yazar.Write(ivtg);
                        byte[] bxynew = new byte[1000000];
                        long fsize = new System.IO.FileInfo(dosyalar).Length;
                        string filenamew = new System.IO.FileInfo(dosyalar).Name;
                        while (okur.BaseStream.Position < fsize)
                        {
                            long whereewearee = fsize - okur.BaseStream.Position;
                            label4.Text = "Encrypting: " + filenamew + " | %" + Math.Round((((double)okur.BaseStream.Position / (double)fsize) * 100), 0).ToString();
                            if (whereewearee > 1000000)
                            {
                                bxynew = new byte[1000000];
                                okur.Read(bxynew, 0, 1000000);
                                byte[] encrypted = sifreler.ProcessBytes(bxynew);
                                if (comboBox4.Text == "Encrypt-then-MAC")
                                {
                                    hsha512.TransformBlock(encrypted, 0, encrypted.Length, null, 0);
                                }
                                yazar.Write(encrypted, 0, encrypted.Length);
                                yazar.Flush();
                                Org.BouncyCastle.Utilities.Arrays.Clear(bxynew);
                            }
                            else
                            {
                                bxynew = new byte[(int)whereewearee];
                                okur.Read(bxynew, 0, (int)whereewearee);
                                byte[] encrypted = sifreler.DoFinal(bxynew);
                                if (comboBox4.Text == "Encrypt-then-MAC")
                                {
                                    hsha512.TransformFinalBlock(encrypted, 0, encrypted.Length);
                                }
                                yazar.Write(encrypted, 0, encrypted.Length);
                                yazar.Flush();
                                Org.BouncyCastle.Utilities.Arrays.Clear(bxynew);
                            }
                        }
                        if (comboBox4.Text == "Encrypt-then-MAC")
                        {
                            yazar.Write(hsha512.Hash);
                            yazar.Flush();
                        }
                        Org.BouncyCastle.Utilities.Arrays.Clear(serpentkey);
                        serpentkey = null;
                        sifreler.Reset();
                        hsha512.Clear();
                        if (okur != null)
                        {
                            okur.Dispose();
                        }
                        if (yazar != null)
                        {
                            yazar.Dispose();
                        }
                        if (formuc.dfafterencrypted1.Checked == true)
                        {
                            if (formuc.shredbd.Checked == true)
                            {
                                shredfile(dosyalar);
                            }
                            System.IO.File.Delete(dosyalar);
                        }
                    }
                    else
                    {
                        nstate = 1;
                        okur = new BinaryReader(File.Open(dosyalar, FileMode.Open, FileAccess.Read));
                        yazar = new BinaryWriter(System.IO.File.Open(System.IO.Path.GetDirectoryName(dosyalar) + "\\" + System.IO.Path.GetFileNameWithoutExtension(dosyalar), FileMode.Create, FileAccess.Write));
                        serpentkey = new byte[keysize / 8];
                        okur.Read(serpentkey, 0, keysize / 8);
                        okur.Read(ivtg, 0, blocksize);
                        byte[] dsk = raes.rsadecrypt(serpentkey, key, keysize);
                        long sposit = okur.BaseStream.Position;
                        label4.Text = "Iterating Password...";
                        if (comboBox4.Text == "Encrypt-then-MAC")
                        {
                            label4.Text = "Authentication starting...";
                            byte[] scrkey = raes.argonkdf(dsk, System.Text.Encoding.ASCII.GetBytes("youcanjoinsaltinfutureversionsmsmsms").Concat(System.Text.Encoding.ASCII.GetBytes(comboBox1.Text + "-" + comboBox3.Text)).ToArray(), iterationrate, argmemrate, 2, (symkeysize / 8) * 2);
                            hsha512 = new HMACSHA512(scrkey.Skip(scrkey.Length / 2).ToArray());
                            Org.BouncyCastle.Utilities.Arrays.Clear(dsk);
                            dsk = scrkey.Take(scrkey.Length / 2).ToArray();
                            Org.BouncyCastle.Utilities.Arrays.Clear(scrkey);
                            scrkey = null;
                            hsha512.TransformBlock(ivtg, 0, blocksize, null, 0);
                            string afname = new FileInfo(dosyalar).Name;
                            long afsz = new FileInfo(dosyalar).Length - 64;
                            byte[] nbyers = new byte[1000000];
                            byte[] machash = null;
                            while (okur.BaseStream.Position < afsz)
                            {
                                long whwearee = afsz - okur.BaseStream.Position;
                                label4.Text = "Authenticating: " + afname + " | %" + Math.Round((((double)okur.BaseStream.Position / (double)afsz) * 100), 0).ToString(); ;
                                if (whwearee > 1000000)
                                {
                                    nbyers = new byte[1000000];
                                    okur.Read(nbyers, 0, 1000000);
                                    hsha512.TransformBlock(nbyers, 0, 1000000, null, 0);
                                }
                                else
                                {
                                    nbyers = new byte[(int)whwearee];
                                    okur.Read(nbyers, 0, (int)whwearee);
                                    hsha512.TransformFinalBlock(nbyers, 0, (int)whwearee);
                                }
                            }
                            machash = hsha512.Hash;
                            byte[] mhashinf = new byte[64];
                            okur.BaseStream.Position = new FileInfo(dosyalar).Length - 64;
                            okur.Read(mhashinf, 0, 64);
                            short hcnt = 0;
                            byte notauthed = 0;
                            foreach (byte b in machash)
                            {
                                if (b == mhashinf[hcnt])
                                {

                                }
                                else
                                {
                                    notauthed = 1;
                                    break;
                                }
                                ++hcnt;
                            }
                            if (notauthed == 1)
                            {
                                okur.Close();
                                yazar.Close();
                                if (File.Exists(System.IO.Path.GetDirectoryName(dosyalar) + "\\" + System.IO.Path.GetFileNameWithoutExtension(dosyalar)))
                                {
                                    System.IO.File.Delete(System.IO.Path.GetDirectoryName(dosyalar) + "\\" + System.IO.Path.GetFileNameWithoutExtension(dosyalar));
                                }
                                label4.Text = afname + " Cannot be authenticated, Decryption process denied for this file!";
                                Thread.Sleep(4000);
                                label4.Text = "";
                                continue;
                            }
                        }
                        else
                        {
                            byte[] adsk = raes.argonkdf(dsk, System.Text.Encoding.ASCII.GetBytes("youcanjoinsaltinfutureversionsmsmsms"), iterationrate, argmemrate, 2, (symkeysize / 8));
                            dsk = adsk;
                            Org.BouncyCastle.Utilities.Arrays.Clear(adsk);
                            adsk = null;
                        }
                        okur.BaseStream.Position = sposit;
                        sifreler.Init(false, new ParametersWithIV(new KeyParameter(dsk), ivtg));
                        byte[] bynetx = new byte[1000000];
                        long fsize = new System.IO.FileInfo(dosyalar).Length;
                        if (comboBox4.Text == "Encrypt-then-MAC")
                        {
                            fsize = fsize - 64;
                        }
                        string filenamew = new System.IO.FileInfo(dosyalar).Name;
                        while (okur.BaseStream.Position < fsize)
                        {
                            long whweare = fsize - okur.BaseStream.Position;
                            label4.Text = "Decrypting: " + filenamew + " | %" + Math.Round((((double)okur.BaseStream.Position / (double)fsize) * 100), 0).ToString();
                            if (whweare > 1000000)
                            {
                                bynetx = new byte[1000000];
                                okur.Read(bynetx, 0, 1000000);
                                byte[] n = sifreler.ProcessBytes(bynetx);
                                yazar.Write(n, 0, n.Length);
                                yazar.Flush();
                                Org.BouncyCastle.Utilities.Arrays.Clear(bynetx);
                            }
                            else
                            {
                                bynetx = new byte[(int)whweare];
                                okur.Read(bynetx, 0, (int)whweare);
                                byte[] n = sifreler.DoFinal(bynetx);
                                yazar.Write(n, 0, n.Length);
                                yazar.Flush();
                                Org.BouncyCastle.Utilities.Arrays.Clear(bynetx);
                            }
                        }
                        Org.BouncyCastle.Utilities.Arrays.Clear(dsk);
                        dsk = null;
                        if (okur != null)
                        {
                            okur.Dispose();
                        }
                        if (yazar != null)
                        {
                            yazar.Dispose();
                        }
                        sifreler.Reset();
                        hsha512.Clear();
                        if (formuc.dfafterencrypted1.Checked == true)
                        {
                            if (formuc.shredbd.Checked ==  true)
                            {
                                shredfile(dosyalar);
                            }
                            System.IO.File.Delete(dosyalar);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                nstate = 0;
                MessageBox.Show("Operation ended with a error, these may cause an error's occure: file dont exists, program haven't access to file, your password is wrong or something else, error = " + ex.Message + " | You can contact programmer, Discord = dr_wellss", "Multron File Guardian", MessageBoxButtons.OK, MessageBoxIcon.Error);
                try
                {
                    if (okur != null)
                    {
                        okur.Dispose();
                    }
                    if (yazar != null)
                    {
                        string pathof = ((FileStream)yazar.BaseStream).Name;
                        yazar.Dispose();
                        if (File.Exists(pathof) == true)
                        {
                            File.Delete(pathof);
                        }
                    }

                }
                catch (Exception k)
                {

                }
                finally
                {
                    if (okur != null)
                    {
                        okur.Dispose();
                    }
                    if (yazar != null)
                    {
                        yazar.Dispose();
                    }
                }
            }
            if (nstate == 1)
            {
                label4.Text = "Operation Done.";
                Thread.Sleep(3500);
                if (formuc.cmpression1.Checked == false || encryptstatus == 1)
                {
                    listBox1.Items.Clear();
                }
                if (formuc.cmpression1.Checked == true && encryptstatus == 2)
                {
                    if (cmpcontroller() == 1)
                    {
                        if (panel3.InvokeRequired)
                        {
                            panel3.Invoke(new MethodInvoker(() => panel3.Visible = true));
                        }
                        else
                        {
                            panel3.Visible = true;
                        }
                    }
                    else
                    {
                        listBox1.Items.Clear();
                    }
                }
            }
            edcontrols(1);
            GC.Collect();
            label4.Text = "";
            if (rcm == 1)
            {
                Application.Exit();
            }
        }

        public void ciphersprocesses(string key, IBlockCipher bc, short blocksize = 16)
        {
            BinaryReader okur = null;
            BinaryWriter yazar = null;
            short nstate = 0;
            Boolean cryptstatus;
            PaddedBufferedBlockCipher sifreler = new PaddedBufferedBlockCipher(new CbcBlockCipher(bc), new Pkcs7Padding());
            byte[] seasalt = new byte[32];
            byte[] keyt = new byte[symkeysize / 8];
            byte[] ivtg = new byte[blocksize];
            if (encryptstatus == 1)
            {
                cryptstatus = true;
            }
            else
            {
                cryptstatus = false;
            }
            try
            {
                foreach (string dosyalar in listBox1.Items)
                {
                    nstate = 1;
                    okur = new BinaryReader(System.IO.File.Open(dosyalar, FileMode.Open, FileAccess.Read));
                    label4.Text = "Iterating Password...";
                    if (encryptstatus == 1)
                    {
                        seasalt = raes.generaterandomkey(32);
                        yazar = new BinaryWriter(File.Open(dosyalar + ".mfg", FileMode.Create, FileAccess.Write));
                        ivtg = new System.Security.Cryptography.Rfc2898DeriveBytes(reversebarray(raes.generaterandomkey(67)), System.Text.Encoding.ASCII.GetBytes(reversestring("youcanjoinsaltinfutureversivonsmsmsms")), 143, System.Security.Cryptography.HashAlgorithmName.SHA512).GetBytes(blocksize);
                        if (comboBox4.Text == "Encrypt-then-MAC")
                        {
                            byte[] scrkey = raes.argonkdf(System.Text.Encoding.UTF8.GetBytes(key), seasalt.Concat(System.Text.Encoding.ASCII.GetBytes(comboBox1.Text + "-" + comboBox3.Text)).ToArray(), iterationrate, argmemrate, 2, (symkeysize / 8) * 2);
                            hsha512 = new HMACSHA512(scrkey.Skip(scrkey.Length / 2).ToArray());
                            keyt = scrkey.Take(scrkey.Length / 2).ToArray();
                            Org.BouncyCastle.Utilities.Arrays.Clear(scrkey);
                            scrkey = null;
                            hsha512.TransformBlock(ivtg, 0, blocksize, null, 0);
                        }
                        else
                        {
                            keyt = raes.argonkdf(System.Text.Encoding.UTF8.GetBytes(key), seasalt, iterationrate, argmemrate, 2, (symkeysize / 8));
                        }
                        yazar.Write(ivtg);
                    }
                    else
                    {
                        yazar = new BinaryWriter(System.IO.File.Open(System.IO.Path.GetDirectoryName(dosyalar) + "\\" + System.IO.Path.GetFileNameWithoutExtension(dosyalar), FileMode.Create, FileAccess.Write));
                        okur.Read(ivtg, 0, blocksize);
                        if (comboBox4.Text == "Encrypt-then-MAC")
                        {
                            okur.BaseStream.Position = new FileInfo(dosyalar).Length - 96;
                        }
                        else
                        {
                            okur.BaseStream.Position = new FileInfo(dosyalar).Length - 32;
                        }
                        okur.Read(seasalt, 0, 32);
                        okur.BaseStream.Position = blocksize;
                        if (comboBox4.Text == "Encrypt-then-MAC")
                        {
                            label4.Text = "Authentication starting...";
                            byte[] scrkey = raes.argonkdf(System.Text.Encoding.UTF8.GetBytes(key), seasalt.Concat(System.Text.Encoding.ASCII.GetBytes(comboBox1.Text + "-" + comboBox3.Text)).ToArray(), iterationrate, argmemrate, 2, (symkeysize / 8) * 2);
                            hsha512 = new HMACSHA512(scrkey.Skip(scrkey.Length / 2).ToArray());
                            keyt = scrkey.Take(scrkey.Length / 2).ToArray();
                            Org.BouncyCastle.Utilities.Arrays.Clear(scrkey);
                            scrkey = null;
                            hsha512.TransformBlock(ivtg, 0, blocksize, null, 0);
                            string afname = new FileInfo(dosyalar).Name;
                            long afsz = new FileInfo(dosyalar).Length - 96;
                            byte[] nbyers = new byte[1000000];
                            byte[] machash = null;
                            while (okur.BaseStream.Position < afsz)
                            {
                                long whwearee = afsz - okur.BaseStream.Position;
                                label4.Text = "Authenticating: " + afname + " | %" + Math.Round((((double)okur.BaseStream.Position / (double)afsz) * 100), 0).ToString(); ;
                                if (whwearee > 1000000)
                                {
                                    nbyers = new byte[1000000];
                                    okur.Read(nbyers, 0, 1000000);
                                    hsha512.TransformBlock(nbyers, 0, 1000000, null, 0);
                                }
                                else
                                {
                                    nbyers = new byte[(int)whwearee];
                                    okur.Read(nbyers, 0, (int)whwearee);
                                    hsha512.TransformFinalBlock(nbyers, 0, (int)whwearee);
                                }
                            }
                            machash = hsha512.Hash;
                            byte[] mhashinf = new byte[64];
                            okur.BaseStream.Position = new FileInfo(dosyalar).Length - 64;
                            okur.Read(mhashinf, 0, 64);
                            short hcnt = 0;
                            byte notauthed = 0;
                            foreach (byte b in machash)
                            {
                                if (b == mhashinf[hcnt])
                                {

                                }
                                else
                                {
                                    notauthed = 1;
                                    break;
                                }
                                ++hcnt;
                            }
                            if (notauthed == 1)
                            {
                                okur.Close();
                                yazar.Close();
                                if (File.Exists(System.IO.Path.GetDirectoryName(dosyalar) + "\\" + System.IO.Path.GetFileNameWithoutExtension(dosyalar)))
                                {
                                    System.IO.File.Delete(System.IO.Path.GetDirectoryName(dosyalar) + "\\" + System.IO.Path.GetFileNameWithoutExtension(dosyalar));
                                }
                                label4.Text = afname + " Cannot be authenticated, Decryption process denied for this file!";
                                Thread.Sleep(4000);
                                label4.Text = "";
                                continue;
                            }
                        }
                        else
                        {
                            keyt = raes.argonkdf(System.Text.Encoding.UTF8.GetBytes(key), seasalt, iterationrate, argmemrate, 2, (symkeysize / 8));
                        }

                        okur.BaseStream.Position = blocksize;

                    }
                    sifreler.Init(cryptstatus, new ParametersWithIV(new KeyParameter(keyt), ivtg));
                    byte[] neww = new byte[1000000];
                    Org.BouncyCastle.Utilities.Arrays.Clear(keyt);
                    long fsize = new System.IO.FileInfo(dosyalar).Length;
                    if (encryptstatus != 1)
                    {
                        fsize = fsize - 32;
                        if (comboBox4.Text == "Encrypt-then-MAC")
                        {
                            fsize = fsize - 64;
                        }
                    }
                    string filenamew = new System.IO.FileInfo(dosyalar).Name;
                    while (okur.BaseStream.Position < fsize)
                    {
                        long whereweare = fsize - okur.BaseStream.Position;
                        if (encryptstatus == 1)
                        {
                            label4.Text = "Encrypting: " + filenamew + " | %" + Math.Round((((double)okur.BaseStream.Position / (double)fsize) * 100), 0).ToString();
                        }
                        else
                        {
                            label4.Text = "Decrypting: " + filenamew + " | %" + Math.Round((((double)okur.BaseStream.Position / (double)fsize) * 100), 0).ToString();
                        }
                        if (whereweare > 1000000)
                        {
                            neww = new byte[1000000];
                            okur.Read(neww, 0, 1000000);
                            byte[] encrypted = sifreler.ProcessBytes(neww);
                            if (encryptstatus == 1 && comboBox4.Text == "Encrypt-then-MAC")
                            {
                                hsha512.TransformBlock(encrypted, 0, encrypted.Length, null, 0);
                            }
                            yazar.Write(encrypted, 0, encrypted.Length);
                            yazar.Flush();
                            Org.BouncyCastle.Utilities.Arrays.Clear(neww);
                        }
                        else
                        {
                            neww = new byte[(int)whereweare];
                            okur.Read(neww, 0, (int)whereweare);
                            byte[] encryptted = sifreler.DoFinal(neww);
                            if (encryptstatus == 1 && comboBox4.Text == "Encrypt-then-MAC")
                            {
                                hsha512.TransformFinalBlock(encryptted, 0, encryptted.Length);
                            }
                            yazar.Write(encryptted, 0, encryptted.Length);
                            yazar.Flush();
                            Org.BouncyCastle.Utilities.Arrays.Clear(neww);
                        }
                    }
                    if (encryptstatus == 1)
                    {
                        yazar.Write(seasalt);
                        yazar.Flush();
                        if (comboBox4.Text == "Encrypt-then-MAC")
                        {
                            yazar.Write(hsha512.Hash);
                            yazar.Flush();
                        }
                    }
                    if (okur != null)
                    {
                        okur.Dispose();
                    }
                    if (yazar != null)
                    {
                        yazar.Dispose();
                    }
                    sifreler.Reset();
                    hsha512.Clear();
                    if (formuc.dfafterencrypted1.Checked == true)
                    {
                        if (formuc.shredbd.Checked == true)
                        {
                            shredfile(dosyalar);
                        }
                        System.IO.File.Delete(dosyalar);
                    }
                }
            }
            catch (Exception ex)
            {
                nstate = 0;
                MessageBox.Show("Operation ended with a error, these may cause an error's occure: file dont exists, program haven't access to file, your password is wrong or something else, error = " + ex.Message + " | You can contact programmer, Discord = dr_wellss", "Multron File Guardian", MessageBoxButtons.OK, MessageBoxIcon.Error);
                try
                {
                    if (okur != null)
                    {
                        okur.Dispose();
                    }
                    if (yazar != null)
                    {
                        string pathof = ((FileStream)yazar.BaseStream).Name;
                        yazar.Dispose();
                        if (File.Exists(pathof) == true)
                        {
                            File.Delete(pathof);
                        }
                    }

                }
                catch (Exception k)
                {

                }
                finally
                {
                    if (okur != null)
                    {
                        okur.Dispose();
                    }
                    if (yazar != null)
                    {
                        yazar.Dispose();
                    }
                }

            }
            if (nstate == 1)
            {
                label4.Text = "Operation Done.";
                Thread.Sleep(3500);
                if (formuc.cmpression1.Checked == false || encryptstatus == 1)
                {
                    listBox1.Items.Clear();
                }
                if (formuc.cmpression1.Checked == true && encryptstatus == 2)
                {
                    if (cmpcontroller() == 1)
                    {
                        if (panel3.InvokeRequired)
                        {
                            panel3.Invoke(new MethodInvoker(() => panel3.Visible = true));
                        }
                        else
                        {
                            panel3.Visible = true;
                        }
                    }
                    else
                    {
                        listBox1.Items.Clear();
                    }
                }
            }
            edcontrols(1);
            label4.Text = "";
            GC.Collect();
            if (rcm == 1)
            {
                Application.Exit();
            }
        }

        public void edcontrols(byte eod = 0)
        {
            if (eod == 0)
            {
                rjButton2.Enabled = false;
                rjButton3.Enabled = false;
                rjButton1.Enabled = false;
                rjButton5.Enabled = false;
                rjButton4.Enabled = false;
                comboBox2.Enabled = false;
                comboBox1.Enabled = false;
                textBox1.Enabled = false;
                comboBox3.Enabled = false;
                comboBox4.Enabled = false;
            }
            else
            {
                rjButton2.Enabled = true;
                rjButton3.Enabled = true;
                rjButton1.Enabled = true;
                rjButton5.Enabled = true;
                rjButton4.Enabled = true;
                if (comboBox1.Text.Contains("RSA"))
                {
                    comboBox2.Enabled = true;
                }
                comboBox1.Enabled = true;
                textBox1.Enabled = true;
                comboBox3.Enabled = true;
                comboBox4.Enabled = true;
            }
        }
        public void aesprocesses(string key)
        {
            short nstate = 0;
            System.Security.Cryptography.CryptoStream sifreler = null;
            System.IO.BinaryReader okur = null;
            System.IO.MemoryStream tutar = null;
            System.IO.BinaryWriter yazar = null;
            try
            {
                System.Security.Cryptography.Aes rijndael = System.Security.Cryptography.Aes.Create();
                rijndael.KeySize = symkeysize;
                rijndael.BlockSize = 128;
                rijndael.Mode = System.Security.Cryptography.CipherMode.CBC;
                rijndael.Padding = System.Security.Cryptography.PaddingMode.PKCS7;
                byte[] seasalt = new byte[32];
                foreach (string dosyalar in listBox1.Items)
                {
                    nstate = 1;
                    okur = new System.IO.BinaryReader(System.IO.File.Open(dosyalar, System.IO.FileMode.Open, System.IO.FileAccess.Read));
                    tutar = new MemoryStream();
                    label4.Text = "Iterating Password...";
                    if (encryptstatus == 1)
                    {
                        yazar = new BinaryWriter(System.IO.File.Open(dosyalar + ".mfg", System.IO.FileMode.Create, System.IO.FileAccess.Write));
                        byte[] geniv = new System.Security.Cryptography.Rfc2898DeriveBytes(reversebarray(raes.generaterandomkey(67)), System.Text.Encoding.ASCII.GetBytes(reversestring("youcanjoinsaltinfutureversivonsmsmsms")), 143, System.Security.Cryptography.HashAlgorithmName.SHA512).GetBytes(16);
                        rijndael.IV = geniv;
                        yazar.Write(geniv);
                        yazar.Flush();
                        seasalt = raes.generaterandomkey(32);
                        if (comboBox4.Text == "Encrypt-then-MAC")
                        {
                            byte[] scrkey = raes.argonkdf(System.Text.Encoding.UTF8.GetBytes(key), seasalt.Concat(System.Text.Encoding.ASCII.GetBytes(comboBox1.Text + "-" + comboBox3.Text)).ToArray(), iterationrate, argmemrate, 2, (symkeysize / 8) * 2);
                            hsha512 = new HMACSHA512(scrkey.Skip(scrkey.Length / 2).ToArray());
                            rijndael.Key = scrkey.Take(scrkey.Length / 2).ToArray();
                            Org.BouncyCastle.Utilities.Arrays.Clear(scrkey);
                            scrkey = null;
                            hsha512.TransformBlock(geniv, 0, 16, null, 0);
                        }
                        else
                        {
                            rijndael.Key = raes.argonkdf(System.Text.Encoding.UTF8.GetBytes(key), seasalt, iterationrate, argmemrate, 2, (symkeysize / 8));
                        }
                        sifreler = new System.Security.Cryptography.CryptoStream(tutar, rijndael.CreateEncryptor(), System.Security.Cryptography.CryptoStreamMode.Write);
                    }
                    else
                    {
                        yazar = new BinaryWriter(System.IO.File.Open(System.IO.Path.GetDirectoryName(dosyalar) + "\\" + System.IO.Path.GetFileNameWithoutExtension(dosyalar), System.IO.FileMode.Create, System.IO.FileAccess.Write));
                        byte[] genniv = new byte[16];
                        okur.Read(genniv, 0, 16);
                        if (comboBox4.Text == "Encrypt-then-MAC")
                        {
                            okur.BaseStream.Position = new FileInfo(dosyalar).Length - 96;
                        }
                        else
                        {
                            okur.BaseStream.Position = new FileInfo(dosyalar).Length - 32;
                        }
                        okur.Read(seasalt, 0, 32);
                        okur.BaseStream.Position = 16;
                        if (comboBox4.Text == "Encrypt-then-MAC")
                        {
                            label4.Text = "Authentication starting...";
                            byte[] scrkey = raes.argonkdf(System.Text.Encoding.UTF8.GetBytes(key), seasalt.Concat(System.Text.Encoding.ASCII.GetBytes(comboBox1.Text + "-" + comboBox3.Text)).ToArray(), iterationrate, argmemrate, 2, (symkeysize / 8) * 2);
                            hsha512 = new HMACSHA512(scrkey.Skip(scrkey.Length / 2).ToArray());
                            rijndael.Key = scrkey.Take(scrkey.Length / 2).ToArray();
                            Org.BouncyCastle.Utilities.Arrays.Clear(scrkey);
                            scrkey = null;
                            hsha512.TransformBlock(genniv, 0, 16, null, 0);
                            string afname = new FileInfo(dosyalar).Name;
                            long afsz = new FileInfo(dosyalar).Length - 96;
                            byte[] nbyers = new byte[1000000];
                            byte[] machash = null;
                            while (okur.BaseStream.Position < afsz)
                            {
                                long whwearee = afsz - okur.BaseStream.Position;
                                label4.Text = "Authenticating: " + afname + " | %" + Math.Round((((double)okur.BaseStream.Position / (double)afsz) * 100), 0).ToString(); ;
                                if (whwearee > 1000000)
                                {
                                    nbyers = new byte[1000000];
                                    okur.Read(nbyers, 0, 1000000);
                                    hsha512.TransformBlock(nbyers, 0, 1000000, null, 0);
                                }
                                else
                                {
                                    nbyers = new byte[(int)whwearee];
                                    okur.Read(nbyers, 0, (int)whwearee);
                                    hsha512.TransformFinalBlock(nbyers, 0, (int)whwearee);
                                }
                            }
                            machash = hsha512.Hash;
                            byte[] mhashinf = new byte[64];
                            okur.BaseStream.Position = new FileInfo(dosyalar).Length - 64;
                            okur.Read(mhashinf, 0, 64);
                            short hcnt = 0;
                            byte notauthed = 0;
                            foreach (byte b in machash)
                            {
                                if (b == mhashinf[hcnt])
                                {

                                }
                                else
                                {
                                    notauthed = 1;
                                    break;
                                }
                                ++hcnt;
                            }
                            if (notauthed == 1)
                            {
                                okur.Close();
                                yazar.Close();
                                if (File.Exists(System.IO.Path.GetDirectoryName(dosyalar) + "\\" + System.IO.Path.GetFileNameWithoutExtension(dosyalar)))
                                {
                                    System.IO.File.Delete(System.IO.Path.GetDirectoryName(dosyalar) + "\\" + System.IO.Path.GetFileNameWithoutExtension(dosyalar));
                                }
                                label4.Text = afname + " Cannot be authenticated, Decryption process denied for this file!";
                                Thread.Sleep(4000);
                                label4.Text = "";
                                continue;
                            }
                        }
                        else
                        {
                            rijndael.Key = raes.argonkdf(System.Text.Encoding.UTF8.GetBytes(key), seasalt, iterationrate, argmemrate, 2, (symkeysize / 8));
                        }
                        rijndael.IV = genniv;
                        sifreler = new System.Security.Cryptography.CryptoStream(tutar, rijndael.CreateDecryptor(), System.Security.Cryptography.CryptoStreamMode.Write);
                    }
                    byte[] bxytes = new byte[1000000];
                    long fsize = new System.IO.FileInfo(dosyalar).Length;
                    if (encryptstatus != 1)
                    {
                        fsize = fsize - 32;
                        if (comboBox4.Text == "Encrypt-then-MAC")
                        {
                            fsize = fsize - 64;
                            okur.BaseStream.Position = 16;
                        }
                    }
                    string filenamew = new System.IO.FileInfo(dosyalar).Name;
                    while (okur.BaseStream.Position < fsize)
                    {
                        if (encryptstatus == 1)
                        {
                            label4.Text = "Encrypting: " + filenamew + " | %" + Math.Round((((double)okur.BaseStream.Position / (double)fsize) * 100), 0).ToString();
                        }
                        else
                        {
                            label4.Text = "Decrypting: " + filenamew + " | %" + Math.Round((((double)okur.BaseStream.Position / (double)fsize) * 100), 0).ToString();
                        }
                        long whereweare = fsize - okur.BaseStream.Position;
                        if (whereweare > 1000000)
                        {
                            bxytes = new byte[1000000];
                            okur.Read(bxytes, 0, 1000000);
                            sifreler.Write(bxytes, 0, 1000000);
                            sifreler.Flush();
                            yazar.Write(tutar.ToArray(), 0, (int)tutar.Length);
                            yazar.Flush();
                            if (encryptstatus == 1 && comboBox4.Text == "Encrypt-then-MAC")
                            {
                                hsha512.TransformBlock(tutar.ToArray(), 0, (int)tutar.Length, null, 0);
                            }
                            tutar.SetLength(0);
                            Org.BouncyCastle.Utilities.Arrays.Clear(bxytes);
                        }
                        else
                        {
                            bxytes = new byte[(int)whereweare];
                            okur.Read(bxytes, 0, (int)whereweare);
                            sifreler.Write(bxytes, 0, (int)whereweare);
                            sifreler.FlushFinalBlock();
                            yazar.Write(tutar.ToArray(), 0, (int)tutar.Length);
                            yazar.Flush();
                            if (encryptstatus == 1 && comboBox4.Text == "Encrypt-then-MAC")
                            {
                                hsha512.TransformFinalBlock(tutar.ToArray(), 0, (int)tutar.Length);
                            }
                            tutar.SetLength(0);
                            Org.BouncyCastle.Utilities.Arrays.Clear(bxytes);
                        }
                    }
                    if (encryptstatus == 1)
                    {
                        yazar.Write(seasalt);
                        yazar.Flush();
                        if (comboBox4.Text == "Encrypt-then-MAC")
                        {
                            yazar.Write(hsha512.Hash);
                            yazar.Flush();
                        }
                    }
                    okur.Dispose();
                    sifreler.Dispose();
                    tutar.Dispose();
                    yazar.Dispose();
                    rijndael.Clear();
                    hsha512.Clear();
                    if (formuc.dfafterencrypted1.Checked == true)
                    {
                        if (formuc.shredbd.Checked == true)
                        {
                            shredfile(dosyalar);
                        }
                        System.IO.File.Delete(dosyalar);
                    }
                }
            }
            catch (Exception exc)
            {
                nstate = 0;
                MessageBox.Show("Operation ended with a error, these may cause an error's occure: file dont exists, program haven't access to file, your password is wrong or something else, error = " + exc.Message + " | You can contact programmer, Discord = dr_wellss", "Multron File Guardian", MessageBoxButtons.OK, MessageBoxIcon.Error);
                try
                {
                    if (okur != null)
                    {
                        okur.Dispose();
                    }
                    if (sifreler != null)
                    {
                        sifreler.Dispose();
                    }
                    if (yazar != null)
                    {
                        string pathof = ((FileStream)yazar.BaseStream).Name;
                        yazar.Dispose();
                        if (File.Exists(pathof) == true)
                        {
                            File.Delete(pathof);
                        }
                    }
                    if (tutar != null)
                    {
                        tutar.Dispose();
                    }
                }
                catch (Exception erf)
                {

                }
                finally
                {
                    if (okur != null)
                    {
                        okur.Dispose();
                    }
                    if (sifreler != null)
                    {
                        sifreler.Dispose();
                    }
                    if (yazar != null)
                    {
                        yazar.Dispose();
                    }
                    if (tutar != null)
                    {
                        tutar.Dispose();
                    }
                }
            }
            if (nstate == 1)
            {
                label4.Text = "Operation Done.";
                Thread.Sleep(3500);
                if (formuc.cmpression1.Checked == false || encryptstatus == 1)
                {
                    listBox1.Items.Clear();
                }
                if (formuc.cmpression1.Checked == true && encryptstatus == 2)
                {
                    if (cmpcontroller() == 1)
                    {
                        if (panel3.InvokeRequired)
                        {
                            panel3.Invoke(new MethodInvoker(() => panel3.Visible = true));
                        }
                        else
                        {
                            panel3.Visible = true;
                        }
                    }
                    else
                    {
                        listBox1.Items.Clear();
                    }
                }
            }
            edcontrols(1);
            label4.Text = "";
            GC.Collect();
            if (rcm == 1)
            {
                Application.Exit();
            }
        }
        public string reversestring(string yazi)
        {
            string ters = "";
            for (int i = yazi.Length - 1; i >= 0;)
            {
                ters += yazi[i];
                --i;
            }
            return ters;
        }
        public byte[] reversebarray(byte[] yazi)
        {
            byte[] ters = new byte[yazi.Length];
            int x = 0;
            for (int i = yazi.Length - 1; i >= 0;)
            {
                ters[x] = yazi[i];
                --i;
                ++x;
            }
            return ters;
        }
        public void shredfile(string fpath)
        {
            BinaryWriter yazar = null;
            long wfc = 0;
            long wd = 0;
            long cwd = 0;
            short nstate = 0;
            try
            {
                    nstate = 1;
                    wfc = loop * new System.IO.FileInfo(fpath).Length;
                    string fname = new System.IO.FileInfo(fpath).Name;
                    long fsize = new System.IO.FileInfo(fpath).Length;
                    System.IO.File.WriteAllBytes(fpath, raes.generaterandomkey(1000000));
                    yazar = new BinaryWriter(File.Open(fpath, FileMode.Open));
                    while (wd < wfc)
                    {
                        if (cwd >= fsize)
                        {
                            yazar.Close();
                            cwd = 0;
                            System.IO.File.WriteAllBytes(fpath, raes.generaterandomkey(1000000));
                            yazar = new BinaryWriter(File.Open(fpath, FileMode.Open));
                        }
                        yazar.Write(raes.generaterandomkey(1000000));
                        yazar.Flush();
                        wd = wd + 1000000;
                        cwd = cwd + 1000000;
                        label4.Text = "Shredding: " + fname + " | %" + Math.Round(((double)wd / (double)wfc) * 100, 0).ToString();
                    }
                    yazar.Close();
                    wd = 0;
                    wfc = 0;
                
            }
            catch (Exception exc)
            {
                nstate = 0;
                if (yazar != null)
                {
                    yazar.Close();
                }
             MessageBox.Show("An error occurred in Shredder! Error = " + exc.Message + exc.StackTrace, "Multron File Guardian", MessageBoxButtons.OK, MessageBoxIcon.Error);
        

            }
            if (nstate == 1)
            {
                label4.Text = new System.IO.FileInfo(fpath).Name + " Shredded!";
                Thread.Sleep(2000);
            }
            label4.Text = "";
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void rjButton1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                    if (comboBox1.Text == "AES")
                    {
                        encryptstatus = 2;
                        System.Threading.Thread newthread = new System.Threading.Thread(() => aesprocesses(textBox1.Text));
                        newthread.Start();
                    edcontrols(0);
                }
                else if (comboBox1.Text == "ChaCha20")
                {
                    encryptstatus = 2;
                    System.Threading.Thread nesawthread = new System.Threading.Thread(() => strcphprocesses(textBox1.Text, new ChaCha7539Engine(), 12));
                    nesawthread.Start();
                    edcontrols(0);
                }
                else if (comboBox1.Text == "HC")
                {
                    encryptstatus = 2;
                    System.Threading.Thread nesahcwthread = new System.Threading.Thread(() => strcphprocesses(textBox1.Text, new HC256Engine(), 32));
                    nesahcwthread.Start();
                    edcontrols(0);
                }
                else if (comboBox1.Text == "ChaCha20-RSA Hybrid Algorithm")
                {
                    encryptstatus = 2;
                    System.Threading.Thread nessawthread = new System.Threading.Thread(() => strcphrsaprocesses(textBox1.Text, new ChaCha7539Engine(), 12));
                    nessawthread.Start();
                    edcontrols(0);
                }
                else if (comboBox1.Text == "HC-RSA Hybrid Algorithm")
                {
                    encryptstatus = 2;
                    System.Threading.Thread nesshcawthread = new System.Threading.Thread(() => strcphrsaprocesses(textBox1.Text, new HC256Engine(), 32));
                    nesshcawthread.Start();
                    edcontrols(0);
                }
                else if (comboBox1.Text == "AES-RSA Hybrid Algorithm")
                    {
                        encryptstatus = 2;
                        System.Threading.Thread newwthread = new System.Threading.Thread(() => aesrsaprocesses(textBox1.Text));
                        newwthread.Start();
                        edcontrols(0);
                   }
                    else if (comboBox1.Text == "Serpent")
                    {
                        encryptstatus = 2;
                    System.Threading.Thread newwwthread = new System.Threading.Thread(() => ciphersprocesses(textBox1.Text, new SerpentEngine()));
                        newwwthread.Start();
                    edcontrols(0);
                }
                    else if (comboBox1.Text == "Serpent-RSA Hybrid Algorithm")
                    {
                        encryptstatus = 2;
                        System.Threading.Thread newwwwwthread = new System.Threading.Thread(() => bciphersrsaprocesses(textBox1.Text, new SerpentEngine()));
                        newwwwwthread.Start();
                    edcontrols(0);
                }
                    else if (comboBox1.Text == "Twofish")
                    {
                        encryptstatus = 2;
                        System.Threading.Thread newbwthread = new System.Threading.Thread(() => ciphersprocesses(textBox1.Text, new TwofishEngine()));
                        newbwthread.Start();
                    edcontrols(0);
                }
                    else if (comboBox1.Text == "Camellia")
                    {
                        encryptstatus = 2;
                        System.Threading.Thread newbwcthread = new System.Threading.Thread(() => ciphersprocesses(textBox1.Text, new CamelliaEngine()));
                        newbwcthread.Start();
                    edcontrols(0);
                }
                else if (comboBox1.Text == "SM4")
                {
                    encryptstatus = 2;
                    System.Threading.Thread smfonewbwcthread = new System.Threading.Thread(() => ciphersprocesses(textBox1.Text, new SM4Engine()));
                    smfonewbwcthread.Start();
                    edcontrols(0);
                }
                else if (comboBox1.Text == "Camellia-RSA Hybrid Algorithm")
                    {
                        encryptstatus = 2;
                        System.Threading.Thread newbwcrthread = new System.Threading.Thread(() => bciphersrsaprocesses(textBox1.Text, new CamelliaEngine()));
                        newbwcrthread.Start();
                    edcontrols(0);
                }
                    else if (comboBox1.Text == "SM4-RSA Hybrid Algorithm")
                {
                    encryptstatus = 2;
                    System.Threading.Thread sm4decryptr = new Thread(() => bciphersrsaprocesses(textBox1.Text, new SM4Engine()));
                    sm4decryptr.Start();
                    edcontrols(0);
                }
                    else if (comboBox1.Text == "Twofish-RSA Hybrid Algorithm")
                    {
                        encryptstatus = 2;
                        System.Threading.Thread newbwtthread = new System.Threading.Thread(() => bciphersrsaprocesses(textBox1.Text, new TwofishEngine()));
                        newbwtthread.Start();
                    edcontrols(0);
                }
                    else if (comboBox1.Text == "ThreeFish")
                    {
                        encryptstatus = 2;
                        System.Threading.Thread newbwtcthread = new System.Threading.Thread(() => ciphersprocesses(textBox1.Text, new ThreefishEngine(symkeysize), (short) (symkeysize / 8)));
                        newbwtcthread.Start();
                    edcontrols(0);
                }
                    else if (comboBox1.Text == "ThreeFish-RSA Hybrid Algorithm")
                    {
                        encryptstatus = 2;
                        System.Threading.Thread nettwbwcrthread = new System.Threading.Thread(() => bciphersrsaprocesses(textBox1.Text, new ThreefishEngine(symkeysize), (short)(symkeysize / 8)));
                        nettwbwcrthread.Start();
                    edcontrols(0);
                }
            }
            else
            {
                MessageBox.Show("You need to enter a key.", "Multron File Guardian", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void rjButton2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                if (formuc.cmpression1.Checked == true)
                {
                    if (rttoperation == 0)
                    {
                        rtoperation = 0;
                        encryptstatus = 1;
                        panel3.Visible = true;
                    }
                    else
                    {
                        rttoperation = 0;
                    }
                }
                if (rtoperation == 1)
                {
                    if (comboBox1.Text == "AES")
                    {
                        encryptstatus = 1;
                        System.Threading.Thread newthread = new System.Threading.Thread(() => aesprocesses(textBox1.Text));
                        newthread.Start(); 
                        edcontrols(0);
                    }
                    else if (comboBox1.Text == "ChaCha20-RSA Hybrid Algorithm")
                    {
                        encryptstatus = 1;
                        System.Threading.Thread nessawthread = new System.Threading.Thread(() => strcphrsaprocesses(textBox1.Text, new ChaCha7539Engine(), 12));
                        nessawthread.Start();
                        edcontrols(0);
                    }
                    else if (comboBox1.Text == "HC-RSA Hybrid Algorithm")
                    {
                        encryptstatus = 1;
                        System.Threading.Thread nesshcawthread = new System.Threading.Thread(() => strcphrsaprocesses(textBox1.Text, new HC256Engine(), 32));
                        nesshcawthread.Start();
                        edcontrols(0);
                    }
                    else if (comboBox1.Text == "ChaCha20")
                    {
                        encryptstatus = 1;
                        System.Threading.Thread nesawthread = new System.Threading.Thread(() => strcphprocesses(textBox1.Text, new ChaCha7539Engine(), 12));
                        nesawthread.Start();
                        edcontrols(0);
                    }
                    else if (comboBox1.Text == "HC")
                    {
                        encryptstatus = 1;
                        System.Threading.Thread nesahcwthread = new System.Threading.Thread(() => strcphprocesses(textBox1.Text, new HC256Engine(), 32));
                        nesahcwthread.Start();
                        edcontrols(0);
                    }
                    else if (comboBox1.Text == "AES-RSA Hybrid Algorithm")
                    {
                        encryptstatus = 1;
                        System.Threading.Thread newwthread = new System.Threading.Thread(() => aesrsaprocesses(textBox1.Text));
                        newwthread.Start();
                        edcontrols(0);
                    }
                    else if (comboBox1.Text == "Serpent")
                    {
                        encryptstatus = 1;
                        System.Threading.Thread newwwthread = new System.Threading.Thread(() => ciphersprocesses(textBox1.Text, new SerpentEngine()));
                        newwwthread.Start();
                        edcontrols(0);
                    }
                    else if (comboBox1.Text == "Serpent-RSA Hybrid Algorithm")
                    {
                        encryptstatus = 1;
                        System.Threading.Thread newwwwwthread = new System.Threading.Thread(() => bciphersrsaprocesses(textBox1.Text, new SerpentEngine()));
                        newwwwwthread.Start();
                        edcontrols(0);
                    }
                    else if (comboBox1.Text == "Twofish")
                    {
                        encryptstatus = 1;
                        System.Threading.Thread newbwthread = new System.Threading.Thread(() => ciphersprocesses(textBox1.Text, new TwofishEngine()));
                        newbwthread.Start();
                        edcontrols(0);
                    }
                    else if (comboBox1.Text == "Camellia")
                    {
                        encryptstatus = 1;
                        System.Threading.Thread newbwcthread = new System.Threading.Thread(() => ciphersprocesses(textBox1.Text, new CamelliaEngine()));
                        newbwcthread.Start();
                        edcontrols(0);
                    }
                    else if (comboBox1.Text == "SM4")
                    {
                        encryptstatus = 1;
                        System.Threading.Thread smfourthnewbwcthread = new System.Threading.Thread(() => ciphersprocesses(textBox1.Text, new SM4Engine()));
                        smfourthnewbwcthread.Start();
                        edcontrols(0);
                    }
                    else if (comboBox1.Text == "SM4-RSA Hybrid Algorithm")
                    {
                        encryptstatus = 1;
                        System.Threading.Thread rsmfourthnewbwcthread = new System.Threading.Thread(() => bciphersrsaprocesses(textBox1.Text, new SM4Engine()));
                        rsmfourthnewbwcthread.Start();
                        edcontrols(0);
                    }
                    else if (comboBox1.Text == "Camellia-RSA Hybrid Algorithm")
                    {
                        encryptstatus = 1;
                        System.Threading.Thread newbwcrthread = new System.Threading.Thread(() => bciphersrsaprocesses(textBox1.Text, new CamelliaEngine()));
                        newbwcrthread.Start();
                        edcontrols(0);
                    }
                    else if (comboBox1.Text == "ThreeFish")
                    {
                        encryptstatus = 1;
                        System.Threading.Thread newbwtcthread = new System.Threading.Thread(() => ciphersprocesses(textBox1.Text, new ThreefishEngine(symkeysize), (short) (symkeysize / 8)));
                        newbwtcthread.Start();
                        edcontrols(0);
                    }
                    else if (comboBox1.Text == "ThreeFish-RSA Hybrid Algorithm")
                    {
                        encryptstatus = 1;
                        System.Threading.Thread nettwbwcrthread = new System.Threading.Thread(() => bciphersrsaprocesses(textBox1.Text, new ThreefishEngine(symkeysize), (short) (symkeysize / 8)));
                        nettwbwcrthread.Start();
                        edcontrols(0);
                    }
                    else if (comboBox1.Text == "Twofish-RSA Hybrid Algorithm")
                    {
                        encryptstatus = 1;
                        System.Threading.Thread newbwtthread = new System.Threading.Thread(() => bciphersrsaprocesses(textBox1.Text, new TwofishEngine()));
                        newbwtthread.Start();
                        edcontrols(0);
                    }
                }
            }
            else
            {
                MessageBox.Show("You need to enter a key.", "Multron File Guardian", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void rjButton3_Click(object sender, EventArgs e)
        {
            int boyt = listBox1.HorizontalExtent;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                listBox1.Items.AddRange(openFileDialog1.FileNames);
            }
            foreach (string liist in listBox1.Items)
            {
                int boyut_size = TextRenderer.MeasureText(liist, listBox1.Font).Width;
                if (boyut_size > boyt)
                {
                    boyt = boyut_size;
                }
            }
            listBox1.HorizontalExtent = boyt;
        }

        private void rjButton4_Click(object sender, EventArgs e)
        {
            try
            {
                listBox1.Items.Remove(listBox1.SelectedItem);
            }
            catch (Exception exc)
            {
                MessageBox.Show("Operation ended with a error, these may cause an error's occure: you didnot select any file, error = " + exc.Message + " | You can contact programmer, Discord = dr_wellss", "Multron File Guardian", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void rjButton5_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            listBox1.HorizontalExtent = 0;
        }

        public void rjButton6_Click(object sender, EventArgs e)
        {
            if (closedrsakgen == 1)
            {
                rsakeygen = new Form2(this);
                rsakeygen.Show();
                closedrsakgen = 0;
            }
            else
            {
                rsakeygen.Show();
            }
        }

        private void rjButton7_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void rjButton8_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button ==  MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, 0xA1, 0x2, 0);
            }
        }
        
        private void rjButton9_Click(object sender, EventArgs e)
        {
            formuc.Show();
            formuc.WindowState = FormWindowState.Normal;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (formuc.swillbesaved == 1)
            {
                savesettings();
            }
        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            label1.Focus();
            if (formuc.savealgorithm1.Checked == true)
            {
                formuc.swillbesaved = 1;
            }
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
                comboBox3.Items.AddRange(new string[] { "128", "192", "256"});
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
                comboBox3.Items.AddRange(new string[] { "256" });
            }
            else if (comboBox1.Text.Contains("SM4") == true)
            {
                comboBox3.Items.Clear();
                comboBox3.Items.AddRange(new string[] { "128" });
            }
            comboBox3.SelectedIndex = comboBox3.Items.Count - 1;
            updatelbl();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("These algorithms are encryption algorithms, Your choices, If you have no idea, use AES or AES-RSA (In case you will use hybrid algorithm)", "Multron File Guardian", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void label6_Click(object sender, EventArgs e)
        {
            if (closedholdkey == 1)
            {
                holdkey = new Form4(this);
                holdkey.Show();
                closedholdkey = 0;
            }
            else
            {
                holdkey.Show();
            }
        }

        private void comboBox2_SelectedValueChanged(object sender, EventArgs e)
        {
            label1.Focus();
            if (formuc.savealgorithm1.Checked == true)
            {
                formuc.swillbesaved = 1;
            }
            keysize = int.Parse(comboBox2.Text);
            updatelbl();
        }
        public void updatelbl()
        {
            string dfstring = "";
            string cmpstring = "";
            string xcasp = "";
            string shredderstate = "";
            if (formuc.dfafterencrypted0.Checked == true)
            {
                dfstring = "Off";
                shredderstate = "Off";
            }
            else
            {
                dfstring = "On";
                if (formuc.shredbd.Checked == true)
                {
                    shredderstate = "On";
                }
                else
                {
                    shredderstate = "Off";
                }
            }
            if (formuc.xscapz0.Checked == true)
            {
                xcasp = "Off";
            }
            else
            {
                xcasp = "On";
            }
            if (formuc.cmpression0.Checked == true)
            {
                cmpstring = "Off";
            }
            else
            {
                cmpstring = "On";
            }
            if (comboBox1.Text.Contains("RSA"))
            {
                label15.Text = "Current Options: Algorithm: " + comboBox1.Text.Split('-')[0] + " | Symmetric Key Length: " + comboBox3.Text + " | RSA Status: On | RSA Length: " + comboBox2.Text + "\n" + "Delete After Operation: " + dfstring +" (Shredder: "+ shredderstate  +") | Compression: " + cmpstring + " | Auth: " + comboBox4.Text + " | Screen Protection: " + xcasp;
            }
            else
            {
                label15.Text = "Current Options: Algorithm: " + comboBox1.Text + " | Symmetric Key Length: " + comboBox3.Text + " | RSA Status: Off" + "\n" + "Delete After Operation: " + dfstring + " (Shredder: " + shredderstate + ") | Compression: " + cmpstring + " | Auth: " + comboBox4.Text + " | Screen Protection: " + xcasp;
            }
        }
        private void listBox1_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                listBox1.Items.AddRange((string[])e.Data.GetData(DataFormats.FileDrop, false));
            }
        }
        private void listBox1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop) == true)
            {
                e.Effect = DragDropEffects.Copy;
            }
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("These are RSA Key Lengths, RSA's security increasing as its key size increased, but it also get slower, If you've no idea what to close, 3072 Key Length is best at balance of Security and Speed. 16384 Key Length is the slowest key length", "Multron File Guardian", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void rjButton10_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox2.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void rjButton12_Click(object sender, EventArgs e)
        {
            panel3.Visible = false;
            textBox2.Text = "";
            listBox1.Items.Clear();
            cmprsdf.Clear();
            rtoperation = 1;
            rttoperation = 0;
        }
        public void compressionoperationwithzip()
        {
            short nstate = 0;
            ZipArchive zibb = null;
            Stream sbn = null;
            BinaryReader okur = null;
            BinaryWriter yazar = null;
            try
            {
                if (encryptstatus == 1)
                {
                    string oputzipf = textBox2.Text + "\\" + raes.getrandomstring(10) + ".zip";
                    zibb = new ZipArchive(File.Open(oputzipf, FileMode.OpenOrCreate), ZipArchiveMode.Create, false);
                    foreach (string fnam in listBox1.Items)
                    {
                        nstate = 1;
                        string entry = new FileInfo(fnam).Name;
                        sbn = zibb.CreateEntry(entry).Open();
                        okur = new BinaryReader(File.Open(fnam, FileMode.Open));
                        byte[] bytessx = new byte[1000000];
                        long fsize = new FileInfo(fnam).Length;
                        while (okur.BaseStream.Position < fsize)
                        {
                            long wherweare = fsize - okur.BaseStream.Position;
                            label4.Text = "Compressing: " + entry + " | %" + Math.Round((((double)okur.BaseStream.Position / (double)fsize) * 100), 0).ToString();

                            if (wherweare > 1000000)
                            {
                                bytessx = new byte[1000000];
                                okur.Read(bytessx, 0, 1000000);
                                sbn.Write(bytessx, 0, 1000000);
                                sbn.Flush();
                            }
                            else
                            {
                                bytessx = new byte[(int)wherweare];
                                okur.Read(bytessx, 0, (int)wherweare);
                                sbn.Write(bytessx, 0, (int)wherweare);
                                sbn.Flush();
                            }
                        }
                        sbn.Close();
                        okur.Close();
                        if (formuc.dfafterencrypted1.Checked == true)
                        {
                            if (formuc.shredbd.Checked == true)
                            {
                                shredfile(fnam);
                            }
                            System.IO.File.Delete(fnam);
                        }
                    }
                    zibb.Dispose();
                    listBox1.Items.Clear();
                    listBox1.Items.Add(oputzipf);
                }
                else
                {
                    foreach (string filepath in cmprsdf)
                    {
                        nstate = 1;
                        string fph = Path.GetDirectoryName(filepath) + "\\" + Path.GetFileNameWithoutExtension(filepath);
                        zibb = new ZipArchive(File.Open(fph, FileMode.Open), ZipArchiveMode.Read, false);
                        string path_file = textBox2.Text + "\\";
                        foreach (ZipArchiveEntry zae in zibb.Entries)
                        {
                            sbn = zae.Open();
                            string filea = path_file + zae.Name;
                            yazar = new BinaryWriter(File.Open(filea, FileMode.OpenOrCreate));
                            byte[] btyx = new byte[1000000];
                            long fsize = zae.Length;
                            while (yazar.BaseStream.Position < fsize)
                            {
                                long wherewere = fsize - yazar.BaseStream.Position;
                                label4.Text = "Decompressing: " + zae.Name + " | %" + Math.Round((((double)yazar.BaseStream.Position / (double)fsize) * 100), 0).ToString();
                                if (wherewere > 1000000)
                                {
                                    btyx = new byte[1000000];
                                    sbn.Read(btyx, 0, 1000000);
                                    yazar.Write(btyx, 0, 1000000);
                                    yazar.Flush();
                                }
                                else
                                {
                                    btyx = new byte[(int)wherewere];
                                    sbn.Read(btyx, 0, (int)wherewere);
                                    yazar.Write(btyx, 0, (int)wherewere);
                                    yazar.Flush();

                                }
                            }
                            yazar.Close();
                            sbn.Close();

                        }
                        zibb.Dispose();
                        if (formuc.dfafterencrypted1.Checked == true)
                        {
                            if (formuc.shredbd.Checked == true)
                            {
                                shredfile(fph);
                            }
                            System.IO.File.Delete(fph);
                        }
                    }

                    listBox1.Items.Clear();
                    cmprsdf.Clear();
                    label4.Text = "Operation Done.";
                    Thread.Sleep(3500);
                }
            }
            catch (Exception ex)
            {
                nstate = 0;
                MessageBox.Show("An error occurred in compression/decompression! Error = " + ex.Message + ex.StackTrace, "Multron File Guardian", MessageBoxButtons.OK, MessageBoxIcon.Error);
                edcontrols(1);
                label4.Text = "";
                rtoperation = 1;
                rttoperation = 0;
            }
            finally
            {
                if (zibb != null)
                {
                    zibb.Dispose();
                }
                if (sbn != null)
                {
                    sbn = null;
                }
                if (okur != null)
                {
                    okur.Dispose();
                }
                if (yazar != null)
                {
                    yazar.Dispose();
                }
            }
            if (nstate == 1) {
                edcontrols(1);
                label4.Text = "";
                rtoperation = 1;
                rttoperation = 1;
                if (encryptstatus == 1)
                {
                    rjButton2.PerformClick();
                }
            }
            textBox2.Text = "";
        }
        private void rjButton11_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(textBox2.Text) == true)
            {
                Thread xthread = new Thread(() => compressionoperationwithzip());
                xthread.Start();
                panel3.Visible = false; 
                edcontrols(0);
            }
            else
            {
                MessageBox.Show("Cant find the path!", "Multron File Guardian", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedValueChanged(object sender, EventArgs e)
        {
            label1.Focus();
            symkeysize = int.Parse(comboBox3.Text);
            if (formuc.savealgorithm1.Checked == true)
            {
                formuc.swillbesaved = 1;
            }
            updatelbl();
        }

        private void rjButton1_EnabledChanged(object sender, EventArgs e)
        {
            comboBox3.Enabled = rjButton1.Enabled;
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("This option offer you select symmetric-algorithm key size, If you have no idea, Select biggest key length.", "Multron File Guardian", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            if (formuc.xscapz1.Checked == true)
            {
                SetWindowDisplayAffinity(this.Handle, avoidcapture);
            }
            if (formuc.savealgorithm1.Checked == false)
            {
                comboBox1.SelectedIndex = 0;
                comboBox2.SelectedIndex = 1;
                comboBox4.SelectedIndex = 1;
            }
            if (rcm == 1)
            {
                if (rcmng == 1)
                {
                    forum6 = new Form6(this);
                    forum6.Show();
                    forum6.Hide();
                    closedmng = 0;
                }
                formbes = new Form5(this);
                formbes.Show();
                this.Hide();
            }
        }

        private void label10_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("This Software is made by ceasar128 aka drwellss\nYour Files/Datas will not be collected for anything, And it's %100 free and open-source.\nDo you want to copy Github page of programmer?", "Multron File Guardian", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                System.Windows.Forms.Clipboard.SetText("https://github.com/drwellss");
                MessageBox.Show("Copied successfully!", "Multron File Guardian", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            panel4.Visible = false;
        }
        private void checkBox1_Click(object sender, EventArgs e)
        {
            byte equalopen = 0;
            if (formuc.Visible == true)
            {
                equalopen = 1;
            }
            if (equalopen == 0)
            {

                formuc.WindowState = FormWindowState.Minimized;
                formuc.Show();
            }
            if (checkBox1.Checked)
            {
                formuc.showpassword1.PerformClick();
            }
            else
            {
                formuc.showpassword0.PerformClick();

            }
            if (equalopen == 0)
            {
                formuc.Hide();
            }
            if (closedmng != 1)
            {
                forum6.checkBox2.Checked = checkBox1.Checked;
            }    
        }

        private void label11_Click(object sender, EventArgs e)
        {
            panel4.Visible = true;
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

        private void label14_Click(object sender, EventArgs e)
        {
            if (closedmng == 1)
            {
                forum6 = new Form6(this);
                forum6.Show();
                closedmng = 0;
            }
            else
            {
                forum6.Show();
            }
        }

        private void comboBox4_SelectedValueChanged(object sender, EventArgs e)
        {
            if (formuc.savealgorithm1.Checked == true)
            {
                formuc.swillbesaved = 1;
            }
            updatelbl();
        }

        private void linkLabel5_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("This option offer you to encrypt with auth or without, Encrypt-then-MAC Strongly Recommended against some serious potential risks. Use Encrypt-then-MAC if you have no idea.", "Multron File Guardian", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}


