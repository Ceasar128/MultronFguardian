using Microsoft.Win32;
using multronfileguardian;
using MultronFileGuardian;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Engines;
using Org.BouncyCastle.Crypto.Modes;
using Org.BouncyCastle.Crypto.Paddings;
using Org.BouncyCastle.Crypto.Parameters;
using System;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using System.Windows.Media;
namespace Multron_File_Guardian
{
    public class mngProcesses
    {
        public short keysize = 256;
        public Window1 formbir;
        public Window6 mng;
        public byte buzzer = 0;
        public byte scnt = 0;
        public byte stfsens = 0;
        public string filepathh = "";
        public byte dntrnbcntrtlr = 0;
        public object s = null;
        public byte swillsaved = 0;
        public byte drawed = 0;
        public EventArgs esa = null;
        public HMACSHA512 hsha512 = new HMACSHA512(new byte[] { 0, 1, 2, 3, 4, 5, 5, 65 });
        public string selectedalgorithm = "";
        public string selectedkeylength = "";
        public bool encrypt = false;
        public string mfgsfolder = AppContext.BaseDirectory + "\\mfgsettings";
        public string mngalg = AppContext.BaseDirectory + "\\mfgsettings\\mngalg.txt";
        public string mngkeyl = AppContext.BaseDirectory + "\\mfgsettings\\mngsymkeyl.txt";
        public string mngfont = AppContext.BaseDirectory + "\\mfgsettings\\mngfont.txt";

        public mngProcesses(Window1 formb, Window6 mng)
        {
            formbir = formb;
            this.mng = mng;
        }
        public async Task shredfile(string fpath)
        {
            BinaryWriter yazar = null;
            long wfc = 0;
            string formname = "";
            await mng.Dispatcher.InvokeAsync(() => { formname = mng.Title; });
            long wd = 0;
            long cwd = 0;
            short nstate = 0;
            try
            {
                nstate = 1;
                wfc = formbir.process.loop * new System.IO.FileInfo(fpath).Length;
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
                    await mng.Dispatcher.InvokeAsync(() => {
                        mng.Title = formname + " | Shredding: " + fname + " | %" + Math.Round(((double)wd / (double)wfc) * 100, 0).ToString();
                    });
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
                MessageBox.Show("An error occurred in Shredder! Error = " + exc.Message + exc.StackTrace, "Multron NoteGuard", MessageBoxButton.OK, MessageBoxImage.Error);


            }
            if (nstate == 1)
            {
                await mng.Dispatcher.InvokeAsync(() =>
                {
                    mng.Title = formname + " | " + new System.IO.FileInfo(fpath).Name + " Shredded!";
                }) ;
                Thread.Sleep(2000);
            }
             await mng.Dispatcher.InvokeAsync(() =>{  mng.Title = formname;   });
        }

   
        public async Task skclickerfnc(MenuItem tsmi)
        { 
            MenuItem symmetricKeyLengthMenu = mng.FindName("symmetricKeyLengthMenu") as MenuItem;
            if (symmetricKeyLengthMenu == null) return;
             
            if (formbir.formuc.savealgorithm1.IsChecked == true)
            {
                swillsaved = 1;
            }
             
            foreach (var obj in symmetricKeyLengthMenu.Items)
            {
                if (obj is MenuItem tsmitemm)
                {
                    tsmitemm.IsChecked = tsmitemm == tsmi;
                }
            }
             
            ComboBox comboBox3 = mng.FindName("comboBox3") as ComboBox;
            if (comboBox3 != null)
            {
                comboBox3.SelectedIndex = int.Parse(tsmi.Name.Last().ToString());
            }
        }
        public async Task<string> aesoperations(string pkey, string fpath, byte encryptstatus, byte[] textb = null)
        {
            Aes rijndael = Aes.Create();
            rijndael.KeySize = keysize;
            rijndael.BlockSize = 128;
            rijndael.Mode = CipherMode.CBC;
            rijndael.Padding = PaddingMode.PKCS7;
            byte[] seasalt = new byte[32];
            byte[] ivtg = new byte[16];
            System.IO.BinaryReader okur = null;
            System.IO.BinaryWriter yazar = null;
            System.IO.MemoryStream tutar = null;
            System.IO.MemoryStream tutrtwo = null;
            System.Security.Cryptography.CryptoStream sifreler = null;
            string formname = null;
            bool encrypthenmac = false;
            await mng.Dispatcher.InvokeAsync(() => { encrypthenmac = mng.tosavencryptthenMACToolStripMenuItem.IsChecked; });
            await mng.Dispatcher.InvokeAsync(() =>{  formname = mng.Title;   });
            try
            {
                await mng.Dispatcher.InvokeAsync(() =>
                {
                    mng.Title = formname + " | Iterating password...";
                });
             
                if (encryptstatus == 2)
                {
                    okur = new System.IO.BinaryReader(System.IO.File.Open(fpath, System.IO.FileMode.Open, System.IO.FileAccess.Read));
                    okur.Read(ivtg, 0, 16);
                    if (encrypthenmac == true)
                    {
                        okur.BaseStream.Position = new FileInfo(fpath).Length - 96;
                    }
                    else
                    {
                        okur.BaseStream.Position = new FileInfo(fpath).Length - 32;
                    }
                    okur.Read(seasalt, 0, 32);
                    okur.BaseStream.Position = 16;
                    if (encrypthenmac == true)
                    {
                        byte[] scrkey = raes.argonkdf(System.Text.Encoding.UTF8.GetBytes(pkey), seasalt.Concat(System.Text.Encoding.ASCII.GetBytes(selectedalgorithm + "-" + selectedkeylength)).ToArray(), formbir.process.iterationrate, formbir.process.argmemrate, 2, (keysize / 8) * 2);
                        hsha512 = new HMACSHA512(scrkey.Skip(scrkey.Length / 2).ToArray());
                        rijndael.Key = scrkey.Take(scrkey.Length / 2).ToArray();
                        Org.BouncyCastle.Utilities.Arrays.Clear(scrkey);
                        scrkey = null;
                        hsha512.TransformBlock(ivtg, 0, 16, null, 0);
                        string afname = new FileInfo(fpath).Name;
                        long afsz = new FileInfo(fpath).Length - 96;
                        byte[] nbyers = new byte[1000000];
                        byte[] machash = null;
                        while (okur.BaseStream.Position < afsz)
                        {
                            long whwearee = afsz - okur.BaseStream.Position;
                            if (whwearee > 1000000)
                            {
                                nbyers = new byte[1000000];
                                await mng.Dispatcher.InvokeAsync(() =>
                                {
                                    mng.Title = formname + " | Authenticating: " + "| %" + Math.Round((((double)okur.BaseStream.Position / (double)afsz) * 100), 0).ToString();
                                });
                         
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
                        okur.BaseStream.Position = new FileInfo(fpath).Length - 64;
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
                            if (yazar != null)
                            {
                                yazar.Close();
                            }
                            MessageBox.Show(afname + " Cannot be authenticated, Decryption process denied!" + "\n\n" + "Cause: Password may be wrong or file may compromised/corrupted", "Multron NoteGuard", MessageBoxButton.OK, MessageBoxImage.Warning);
                            if (formbir.process.rcmng == 1 && drawed == 0)
                            {
                                mng.Dispatcher.InvokeAsync(() => { mng.Close(); });
                            }
                            throw new Exception("Auth Failed");
                        }
                    }
                    else
                    {
                        rijndael.Key = raes.argonkdf(System.Text.Encoding.UTF8.GetBytes(pkey), seasalt, formbir.process.iterationrate, formbir.process.argmemrate, 2, (keysize / 8));
                    }
                    okur.BaseStream.Position = 16;
                    rijndael.IV = ivtg;
                    tutar = new System.IO.MemoryStream();
                    byte[] bytts = new byte[1000000];
                    sifreler = new System.Security.Cryptography.CryptoStream(tutar, rijndael.CreateDecryptor(), CryptoStreamMode.Write);
                    long fsize = new System.IO.FileInfo(fpath).Length - 32;
                    if (encrypthenmac == true)
                    {
                        fsize = fsize - 64;
                    }
                    while (okur.BaseStream.Position < fsize)
                    {
                        long ig = fsize - okur.BaseStream.Position;
                        await mng.Dispatcher.InvokeAsync(() =>
                        {

                            mng.Title = formname + " | Decrypting: " + "| %" + Math.Round((((double)okur.BaseStream.Position / (double)fsize) * 100), 0).ToString();
                        });
                        if (ig > 1000000)
                        {
                            bytts = new byte[1000000];
                            okur.Read(bytts, 0, 1000000);
                            sifreler.Write(bytts, 0, 1000000);
                            sifreler.Flush();
                            Org.BouncyCastle.Utilities.Arrays.Clear(bytts);
                        }
                        else
                        {
                            bytts = new byte[(int)ig];
                            okur.Read(bytts, 0, (int)ig);
                            sifreler.Write(bytts, 0, (int)ig);
                            sifreler.FlushFinalBlock();
                            Org.BouncyCastle.Utilities.Arrays.Clear(bytts);
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
                    if (sifreler != null)
                    {
                        sifreler.Dispose();
                    }
                    okur.Close();
                    sifreler.Close();
                    rijndael.Clear();
                    hsha512.Clear();
                     await mng.Dispatcher.InvokeAsync(() =>{  mng.Title = formname;   });
                    GC.Collect();
                    if (dntrnbcntrtlr == 1)
                    {
                        dntrnbcntrtlr = 0;
                    }
                    else
                    {
                        buzcontroller(fpath);
                    }
                    return System.Text.Encoding.UTF8.GetString(tutar.ToArray());
                }
                else
                {
                    ivtg = new System.Security.Cryptography.Rfc2898DeriveBytes(reversebarray(raes.generaterandomkey(67)), System.Text.Encoding.ASCII.GetBytes(formbir.process.reversestring("youcanjoinsaltinfutureversivonsmsmsms")), 143, System.Security.Cryptography.HashAlgorithmName.SHA512).GetBytes(16);
                    rijndael.IV = ivtg;
                    seasalt = raes.generaterandomkey(32);
                    if (encrypthenmac == true)
                    {
                        byte[] scrkey = raes.argonkdf(System.Text.Encoding.UTF8.GetBytes(pkey), seasalt.Concat(System.Text.Encoding.ASCII.GetBytes(selectedalgorithm + "-" + selectedkeylength)).ToArray(), formbir.process.iterationrate, formbir.process.argmemrate, 2, (keysize / 8) * 2);
                        hsha512 = new HMACSHA512(scrkey.Skip(scrkey.Length / 2).ToArray());
                        rijndael.Key = scrkey.Take(scrkey.Length / 2).ToArray();
                        Org.BouncyCastle.Utilities.Arrays.Clear(scrkey);
                        scrkey = null;
                        hsha512.TransformBlock(ivtg, 0, 16, null, 0);
                    }
                    else
                    {
                        rijndael.Key = raes.argonkdf(System.Text.Encoding.UTF8.GetBytes(pkey), seasalt, formbir.process.iterationrate, formbir.process.argmemrate, 2, (keysize / 8));
                    }
                    tutrtwo = new System.IO.MemoryStream(textb);
                    okur = new System.IO.BinaryReader(tutrtwo);
                    byte todelshred = 0;
                    string fffpath = "";
                    string fapth = "";
                    if (System.IO.Path.GetExtension(fpath).Contains(".mng"))
                    {
                        fffpath = fpath;
                    }
                    else
                    {
                        fapth = fpath;
                        fffpath = fpath + ".mng";
                        filepathh = fffpath;
                    }
                    yazar = new System.IO.BinaryWriter(System.IO.File.Open(fffpath, System.IO.FileMode.Create, System.IO.FileAccess.Write));
                    yazar.Write(ivtg);
                    yazar.Flush();
                    tutar = new System.IO.MemoryStream();
                    sifreler = new CryptoStream(tutar, rijndael.CreateEncryptor(), CryptoStreamMode.Write);
                    byte[] bytr = new byte[1000000];
                    long filesize = tutrtwo.Length;
                    while (okur.BaseStream.Position < filesize)
                    {
                        long ig = filesize - okur.BaseStream.Position;
                        await mng.Dispatcher.InvokeAsync(() =>
                        {
                            mng.Title = formname + " | Encrypting: " + "| %" + Math.Round((((double)okur.BaseStream.Position / (double)filesize) * 100), 0).ToString();
                        });
                    
                        if (ig > 1000000)
                        {
                            bytr = new byte[1000000];
                            okur.Read(bytr, 0, 1000000);
                            sifreler.Write(bytr, 0, 1000000);
                            sifreler.Flush();
                            if (encrypthenmac == true)
                            {
                                hsha512.TransformBlock(tutar.ToArray(), 0, (int)tutar.Length, null, 0);
                            }
                            yazar.Write(tutar.ToArray(), 0, (int)tutar.Length);
                            yazar.Flush();
                            tutar.SetLength(0);
                            Org.BouncyCastle.Utilities.Arrays.Clear(bytr);
                        }
                        else
                        {
                            bytr = new byte[(int)ig];
                            okur.Read(bytr, 0, (int)ig);
                            sifreler.Write(bytr, 0, (int)ig);
                            sifreler.FlushFinalBlock();
                            if (encrypthenmac == true)
                            {
                                hsha512.TransformFinalBlock(tutar.ToArray(), 0, (int)tutar.Length);
                            }
                            yazar.Write(tutar.ToArray(), 0, (int)tutar.Length);
                            yazar.Flush();
                            tutar.SetLength(0);
                            Org.BouncyCastle.Utilities.Arrays.Clear(bytr);
                        }
                    }
                    yazar.Write(seasalt);
                    yazar.Flush();
                    if (encrypthenmac == true)
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
                    rijndael.Clear();
                    hsha512.Clear();
                    yazar.Close();
                    okur.Close();
                    sifreler.Close();
                    tutar.Close();
                     await mng.Dispatcher.InvokeAsync(() =>{ mng.Title = formname; });
                    if (todelshred == 1)
                    {
                        await mng.Dispatcher.InvokeAsync(() =>
                        {
                            if (System.IO.File.Exists(fapth) == true)
                            {
                                if (formbir.formuc.dfafterencrypted1.IsChecked == true)
                                {
                                    if (formbir.formuc.shredbd.IsChecked == true)
                                    {
                                        shredfile(fapth);
                                    }
                                    System.IO.File.Delete(fapth);
                                }
                            }
                        });
                  
                    }
                    GC.Collect();
                }
            }
            catch (Exception ex)
            {
                 await mng.Dispatcher.InvokeAsync(() =>{ mng.Title = formname;   });
                MessageBox.Show("Operation ended with a error, these may cause an error's occure: file may not be a text file, program haven't access to file, your password is wrong or something else, Error = " + ex.Message + "\n" + ex.StackTrace.ToString(), "Multron NoteGuard", MessageBoxButton.OK, MessageBoxImage.Warning);
                filepathh = "";
                buzzer = 1;
                if (formbir.process.rcmng == 1 && drawed == 0)
                {
                    mng.Dispatcher.InvokeAsync(() => { mng.Close(); });
                }
                buzcontroller();
                try
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
            return "";
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
        private void buzcontroller(string fnpath = "")
        {
            if (buzzer != 1)
            {
                    filepathh = fnpath;
            }
            else
            {
                buzzer = 0;
            }
        }
        public async void readfwithsalgorithmm(string fwbreader)
        {
            if (selectedalgorithm == "AES")
            {
                string keysoldier = mng.textBox2.Text;
                string result = await Task.Run(() => aesoperations(keysoldier, fwbreader, 2));
                mng.textBox1.Dispatcher.Invoke(() => mng.textBox1.Text = result);
            }
            else if (selectedalgorithm == "Serpent")
            {
                string keysoldier = mng.textBox2.Text;
                string result = await Task.Run(() => ciphersoperations(keysoldier, new SerpentEngine(), fwbreader, 2));
                mng.textBox1.Dispatcher.Invoke(() => mng.textBox1.Text = result);
            }
            else if (selectedalgorithm == "Camellia")
            {
                string keysoldier = mng.textBox2.Text;
                string result = await Task.Run(() => ciphersoperations(keysoldier, new CamelliaEngine(), fwbreader, 2));
                mng.textBox1.Dispatcher.Invoke(() => mng.textBox1.Text = result);
            }
            else if (selectedalgorithm == "Twofish")
            {
                string keysoldier = mng.textBox2.Text;
                string result = await Task.Run(() => ciphersoperations(keysoldier, new TwofishEngine(), fwbreader, 2));
                mng.textBox1.Dispatcher.Invoke(() => mng.textBox1.Text = result);
            }
            else if (selectedalgorithm == "SM4")
            {
                string keysoldier = mng.textBox2.Text;
                string result = await Task.Run(() => ciphersoperations(keysoldier, new SM4Engine(), fwbreader, 2));
                mng.textBox1.Dispatcher.Invoke(() => mng.textBox1.Text = result);
            }
            else if (selectedalgorithm == "ThreeFish")
            {
                string keysoldier = mng.textBox2.Text;
                string result = await Task.Run(() => ciphersoperations(keysoldier, new ThreefishEngine(keysize), fwbreader, 2, null, (short)(keysize / 8)));
                mng.textBox1.Dispatcher.Invoke(() => mng.textBox1.Text = result);
            }
            else if (selectedalgorithm == "ChaCha20")
            {
                string keysoldier = mng.textBox2.Text;
                string result = await Task.Run(() => strcphoperations(keysoldier, new ChaCha7539Engine(), 12, fwbreader, 2));
                mng.textBox1.Dispatcher.Invoke(() => mng.textBox1.Text = result);
            }
            else if (selectedalgorithm == "HC")
            {
                int hcSize = (selectedalgorithm != null && selectedkeylength == "128") ? 16 : 32;
                IStreamCipher engine = (hcSize == 16) ? (IStreamCipher)new HC128Engine() : new HC256Engine();
                short hcSizeShort = (short)hcSize;
                string keysoldier = mng.textBox2.Text;
                string result = await Task.Run(() => strcphoperations(keysoldier, engine, hcSizeShort, fwbreader, 2));
                mng.textBox1.Dispatcher.Invoke(() => mng.textBox1.Text = result);
            }
            drawed = 1;
        }
        public async Task<string> ciphersoperations(string pkey, IBlockCipher bc, string fpath, byte encryptstatus, byte[] textb = null, short blocksize = 16)
        {
         
            PaddedBufferedBlockCipher sencryptor = new PaddedBufferedBlockCipher(new CbcBlockCipher(bc), new Pkcs7Padding());
            byte[] keyt = new byte[keysize / 8];
            byte[] seasalt = new byte[32];
            byte[] ivtg = new byte[blocksize];
            System.IO.BinaryReader okur = null; 
            System.IO.BinaryWriter yazar = null;
            System.IO.MemoryStream tutar = null;
            System.IO.MemoryStream tutrtwo = null;
            bool cstatus = false;
            bool encrypthenmac = false;

            await mng.Dispatcher.InvokeAsync(() =>
            {
                encrypthenmac = mng.tosavencryptthenMACToolStripMenuItem.IsChecked;

            });
            string formname = null;
            await mng.Dispatcher.InvokeAsync(async () =>
            {
                formname = mng.Title;
            });
           
            try
            {
                await mng.Dispatcher.InvokeAsync(() =>
                {
                    mng.Title = formname + " | Iterating password...";
                });
             
                if (encryptstatus == 2)
                {
                    cstatus = false;
                    okur = new System.IO.BinaryReader(System.IO.File.Open(fpath, System.IO.FileMode.Open, System.IO.FileAccess.Read));
                    okur.Read(ivtg, 0, blocksize);
                    if (encrypthenmac == true)
                    {
                        okur.BaseStream.Position = new FileInfo(fpath).Length - 96;
                    }
                    else
                    {
                        okur.BaseStream.Position = new FileInfo(fpath).Length - 32;
                    }
                    okur.Read(seasalt, 0, 32);
                    okur.BaseStream.Position = blocksize;
                    if (encrypthenmac == true)
                    {
                        byte[] scrkey = raes.argonkdf(System.Text.Encoding.UTF8.GetBytes(pkey), seasalt.Concat(System.Text.Encoding.ASCII.GetBytes(selectedalgorithm + "-" + selectedkeylength)).ToArray(), formbir.process.iterationrate, formbir.process.argmemrate, 2, (keysize / 8) * 2);
                        hsha512 = new HMACSHA512(scrkey.Skip(scrkey.Length / 2).ToArray());
                        keyt = scrkey.Take(scrkey.Length / 2).ToArray();
                        Org.BouncyCastle.Utilities.Arrays.Clear(scrkey);
                        scrkey = null;
                        hsha512.TransformBlock(ivtg, 0, blocksize, null, 0);
                        string afname = new FileInfo(fpath).Name;
                        long afsz = new FileInfo(fpath).Length - 96;
                        byte[] nbyers = new byte[1000000];
                        byte[] machash = null;
                        while (okur.BaseStream.Position < afsz)
                        {
                            long whwearee = afsz - okur.BaseStream.Position;
                            await mng.Dispatcher.InvokeAsync(() =>
                            {
                                mng.Title = formname + " | Authenticating: " + "| %" + Math.Round((((double)okur.BaseStream.Position / (double)afsz) * 100), 0).ToString();
                            });
                          
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
                        okur.BaseStream.Position = new FileInfo(fpath).Length - 64;
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
                            if (yazar != null)
                            {
                                yazar.Close();
                            }
                            MessageBox.Show(afname + " Cannot be authenticated, Decryption process denied!" + "\n\n" + "Cause: Password may be wrong or file may compromised/corrupted", "Multron NoteGuard", MessageBoxButton.OK, MessageBoxImage.Warning);
                            if (formbir.process.rcmng == 1 && drawed == 0)
                            {
                                mng.Dispatcher.InvokeAsync(() => { mng.Close(); });
                            }
                            throw new Exception("Auth Failed");
                        }
                    }
                    else
                    {
                        keyt = raes.argonkdf(System.Text.Encoding.UTF8.GetBytes(pkey), seasalt, formbir.process.iterationrate, formbir.process.argmemrate, 2, (keysize / 8));
                    }
                    okur.BaseStream.Position = blocksize;
                    sencryptor.Init(cstatus, new ParametersWithIV(new KeyParameter(keyt), ivtg));
                    Org.BouncyCastle.Utilities.Arrays.Clear(keyt);
                    tutar = new System.IO.MemoryStream();
                    byte[] bytts = new byte[1000000];
                    yazar = new System.IO.BinaryWriter(tutar);
                    long fsize = new System.IO.FileInfo(fpath).Length - 32;
                    if (encrypthenmac == true)
                    {
                        fsize = fsize - 64;
                    }
                    while (okur.BaseStream.Position < fsize)
                    {
                        long ig = fsize - okur.BaseStream.Position;
                        await mng.Dispatcher.InvokeAsync(() =>
                        {
                            mng.Title = formname + " | Decrypting: " + "| %" + Math.Round((((double)okur.BaseStream.Position / (double)fsize) * 100), 0).ToString();
                        });
                    
                        if (ig > 1000000)
                        {
                            bytts = new byte[1000000];
                            okur.Read(bytts, 0, 1000000);
                            byte[] decryptdata = sencryptor.ProcessBytes(bytts);
                            yazar.Write(decryptdata, 0, decryptdata.Length);
                            yazar.Flush();
                            Org.BouncyCastle.Utilities.Arrays.Clear(bytts);
                        }
                        else
                        {
                            bytts = new byte[(int)ig];
                            okur.Read(bytts, 0, (int)ig);
                            byte[] decryptdata = sencryptor.DoFinal(bytts);
                            yazar.Write(decryptdata, 0, decryptdata.Length);
                            yazar.Flush();
                            Org.BouncyCastle.Utilities.Arrays.Clear(bytts);
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
                    okur.Close();
                    yazar.Close();
                    sencryptor.Reset();
                    hsha512.Clear();
                    GC.Collect();
                     await mng.Dispatcher.InvokeAsync(() =>{ mng.Title = formname; });
                    if (dntrnbcntrtlr == 1)
                    {
                        dntrnbcntrtlr = 0;
                    }
                    else
                    {
                        buzcontroller(fpath);
                    }
                    return System.Text.Encoding.UTF8.GetString(tutar.ToArray());
                }
                else
                {
                    cstatus = true;
                    seasalt = raes.generaterandomkey(32);
                    ivtg = new System.Security.Cryptography.Rfc2898DeriveBytes(reversebarray(raes.generaterandomkey(67)), System.Text.Encoding.ASCII.GetBytes(formbir.process.reversestring("youcanjoinsaltinfutureversivonsmsmsms")), 143, System.Security.Cryptography.HashAlgorithmName.SHA512).GetBytes(blocksize);
                    if (encrypthenmac == true)
                    {
                        byte[] scrkey = raes.argonkdf(System.Text.Encoding.UTF8.GetBytes(pkey), seasalt.Concat(System.Text.Encoding.ASCII.GetBytes(selectedalgorithm + "-" + selectedkeylength)).ToArray(), formbir.process.iterationrate, formbir.process.argmemrate, 2, (keysize / 8) * 2);
                        hsha512 = new HMACSHA512(scrkey.Skip(scrkey.Length / 2).ToArray());
                        keyt = scrkey.Take(scrkey.Length / 2).ToArray();
                        Org.BouncyCastle.Utilities.Arrays.Clear(scrkey);
                        scrkey = null;
                        hsha512.TransformBlock(ivtg, 0, blocksize, null, 0);
                    }
                    else
                    {
                        keyt = raes.argonkdf(System.Text.Encoding.UTF8.GetBytes(pkey), seasalt, formbir.process.iterationrate, formbir.process.argmemrate, 2, (keysize / 8));
                    }
                    tutrtwo = new System.IO.MemoryStream(textb);
                    okur = new System.IO.BinaryReader(tutrtwo);
                    byte todelshred = 0;
                    string fapth = "";
                    string fffpath = "";
                    if (System.IO.Path.GetExtension(fpath).Contains(".mng"))
                    {
                        fffpath = fpath;
                    }
                    else
                    {
                        todelshred = 1;
                        fapth = fpath;
                        fffpath = fpath + ".mng";
                        filepathh = fffpath;
                    }
                    yazar = new System.IO.BinaryWriter(System.IO.File.Open(fffpath, System.IO.FileMode.Create, System.IO.FileAccess.Write));
                    yazar.Write(ivtg);
                    yazar.Flush();
                    tutar = new System.IO.MemoryStream();
                    sencryptor.Init(cstatus, new ParametersWithIV(new KeyParameter(keyt), ivtg));
                    Org.BouncyCastle.Utilities.Arrays.Clear(keyt);
                    byte[] bytr = new byte[1000000];
                    long filesize = tutrtwo.Length;
                    while (okur.BaseStream.Position < filesize)
                    {
                        long ig = filesize - okur.BaseStream.Position;
                        mng.Title = formname + " | Encrypting: " + "| %" + Math.Round((((double)okur.BaseStream.Position / (double)filesize) * 100), 0).ToString();
                        if (ig > 1000000)
                        {
                            bytr = new byte[1000000];
                            okur.Read(bytr, 0, 1000000);
                            byte[] encryptddata = sencryptor.ProcessBytes(bytr);
                            if (encrypthenmac == true)
                            {
                                hsha512.TransformBlock(encryptddata, 0, encryptddata.Length, null, 0);
                            }
                            yazar.Write(encryptddata, 0, (int)encryptddata.Length);
                            yazar.Flush();
                            Org.BouncyCastle.Utilities.Arrays.Clear(bytr);
                        }
                        else
                        {
                            bytr = new byte[(int)ig];
                            okur.Read(bytr, 0, (int)ig);
                            byte[] encryptddaata = sencryptor.DoFinal(bytr);

                            if (encrypthenmac == true)
                            {
                                hsha512.TransformFinalBlock(encryptddaata, 0, encryptddaata.Length);
                            }
                            yazar.Write(encryptddaata, 0, (int)encryptddaata.Length);
                            yazar.Flush();
                            Org.BouncyCastle.Utilities.Arrays.Clear(bytr);
                        }
                    }
                    yazar.Write(seasalt);
                    yazar.Flush();
                    if (encrypthenmac == true)
                    {
                        yazar.Write(hsha512.Hash);
                        yazar.Flush();
                    }
                    sencryptor.Reset();
                    hsha512.Clear();
                    if (okur != null)
                    {
                        okur.Dispose();
                    }
                    if (yazar != null)
                    {
                        yazar.Dispose();
                    }
                    if (tutar != null)
                    {
                        tutar.Dispose();
                    }

                    yazar.Close();
                    okur.Close();
                    tutar.Close();
                     await mng.Dispatcher.InvokeAsync(() =>{ mng.Title = formname; });
                    if (todelshred == 1)
                    {
                        if (System.IO.File.Exists(fapth) == true)
                        {
                            await mng.Dispatcher.InvokeAsync(() =>
                            {
                                if (formbir.formuc.dfafterencrypted1.IsChecked == true)
                                {
                                    if (formbir.formuc.shredbd.IsChecked == true)
                                    {
                                        shredfile(fapth);
                                    }
                                    System.IO.File.Delete(fapth);
                                }
                            });
                         
                        }
                    }
                    GC.Collect();
                }
            }
            catch (Exception ex)
            {
               
                   await mng.Dispatcher.InvokeAsync(() =>{ mng.Title = formname; });
                
            
                MessageBox.Show("Operation ended with a error, these may cause an error's occure: file may not be a text file, program haven't access to file, your password is wrong or something else, Error = " + ex.Message + "\n" + ex.StackTrace.ToString(), "Multron NoteGuard", MessageBoxButton.OK, MessageBoxImage.Warning);
                filepathh = "";
                buzzer = 1;
                if (formbir.process.rcmng == 1 && drawed == 0)
                {
                    mng.Dispatcher.InvokeAsync(() => { mng.Close(); });
                }
                buzcontroller();
                try
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
            return "";
        }
        public async Task<string> strcphoperations(string pkey, IStreamCipher iscphr, short blocksize, string fpath, byte encryptstatus, byte[] textb = null)
        {
            IStreamCipher sencryptor = iscphr;
            byte[] keyt = new byte[keysize / 8];
            byte[] seasalt = new byte[32];
            byte[] ivtg = new byte[blocksize];
            System.IO.BinaryReader okur = null;
            System.IO.BinaryWriter yazar = null;
            System.IO.MemoryStream tutar = null;
            System.IO.MemoryStream tutrtwo = null;
            bool cstatus = false;
            bool encrypthenmac = false;

            await mng.Dispatcher.InvokeAsync(() =>
            {
                encrypthenmac = mng.tosavencryptthenMACToolStripMenuItem.IsChecked;

            });
            string formname = null;
            await mng.Dispatcher.InvokeAsync(async () =>
            {
                formname = mng.Title;
            });

            try
            {
                await mng.Dispatcher.InvokeAsync(() =>
                {
                    mng.Title = formname + " | Iterating password...";
                });
            
                if (encryptstatus == 2)
                {
                    cstatus = false;
                    okur = new System.IO.BinaryReader(System.IO.File.Open(fpath, System.IO.FileMode.Open, System.IO.FileAccess.Read));
                    okur.Read(ivtg, 0, blocksize);
                    if (encrypthenmac == true)
                    {
                        okur.BaseStream.Position = new FileInfo(fpath).Length - 96;
                    }
                    else
                    {
                        okur.BaseStream.Position = new FileInfo(fpath).Length - 32;
                    }
                    okur.Read(seasalt, 0, 32);
                    okur.BaseStream.Position = blocksize;
                    if (encrypthenmac == true)
                    {
                        byte[] scrkey = raes.argonkdf(System.Text.Encoding.UTF8.GetBytes(pkey), seasalt.Concat(System.Text.Encoding.ASCII.GetBytes(selectedalgorithm + "-" + selectedkeylength)).ToArray(), formbir.process.iterationrate, formbir.process.argmemrate, 2, (keysize / 8) * 2);
                        hsha512 = new HMACSHA512(scrkey.Skip(scrkey.Length / 2).ToArray());
                        keyt = scrkey.Take(scrkey.Length / 2).ToArray();
                        Org.BouncyCastle.Utilities.Arrays.Clear(scrkey);
                        scrkey = null;
                        hsha512.TransformBlock(ivtg, 0, blocksize, null, 0);
                        string afname = new FileInfo(fpath).Name;
                        long afsz = new FileInfo(fpath).Length - 96;
                        byte[] nbyers = new byte[1000000];
                        byte[] machash = null;
                        while (okur.BaseStream.Position < afsz)
                        {
                            long whwearee = afsz - okur.BaseStream.Position;
                            await mng.Dispatcher.InvokeAsync(() =>
                            {
                                mng.Title = formname + " | Authenticating: " + "| %" + Math.Round((((double)okur.BaseStream.Position / (double)afsz) * 100), 0).ToString();
                            });
                     
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
                        okur.BaseStream.Position = new FileInfo(fpath).Length - 64;
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
                            if (yazar != null)
                            {
                                yazar.Close();
                            }
                            MessageBox.Show(afname + " Cannot be authenticated, Decryption process denied!" + "\n\n" + "Cause: Password may be wrong or file may compromised/corrupted", "Multron NoteGuard", MessageBoxButton.OK, MessageBoxImage.Warning);
                            if (formbir.process.rcmng == 1 && drawed == 0)
                            {
                                mng.Dispatcher.InvokeAsync(() => { mng.Close(); });
                            }
                            throw new Exception("Auth Failed");
                        }
                    }
                    else
                    {
                        keyt = raes.argonkdf(System.Text.Encoding.UTF8.GetBytes(pkey), seasalt, formbir.process.iterationrate, formbir.process.argmemrate, 2, (keysize / 8));
                    }
                    okur.BaseStream.Position = blocksize;
                    sencryptor.Init(cstatus, new ParametersWithIV(new KeyParameter(keyt), ivtg));
                    Org.BouncyCastle.Utilities.Arrays.Clear(keyt);
                    tutar = new System.IO.MemoryStream();
                    byte[] bytts = new byte[1000000];
                    yazar = new System.IO.BinaryWriter(tutar);
                    long fsize = new System.IO.FileInfo(fpath).Length - 32;
                    if (encrypthenmac == true)
                    {
                        fsize = fsize - 64;
                    }
                    while (okur.BaseStream.Position < fsize)
                    {
                        long ig = fsize - okur.BaseStream.Position;
                        await mng.Dispatcher.InvokeAsync(() =>
                        {
                            mng.Title = formname + " | Decrypting: " + "| %" + Math.Round((((double)okur.BaseStream.Position / (double)fsize) * 100), 0).ToString();
                        });
                
                        if (ig > 1000000)
                        {
                            bytts = new byte[1000000];
                            okur.Read(bytts, 0, 1000000);
                            byte[] decryptdata = new byte[1000000];
                            sencryptor.ProcessBytes(bytts, 0, 1000000, decryptdata, 0);
                            yazar.Write(decryptdata, 0, decryptdata.Length);
                            yazar.Flush();
                            Org.BouncyCastle.Utilities.Arrays.Clear(bytts);
                        }
                        else
                        {
                            bytts = new byte[(int)ig];
                            okur.Read(bytts, 0, (int)ig);
                            byte[] decryptdata = new byte[(int)ig];
                            sencryptor.ProcessBytes(bytts, 0, (int)ig, decryptdata, 0);
                            yazar.Write(decryptdata, 0, decryptdata.Length);
                            yazar.Flush();
                            Org.BouncyCastle.Utilities.Arrays.Clear(bytts);
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
                    okur.Close();
                    yazar.Close();
                    sencryptor.Reset();
                    hsha512.Clear();
                     await mng.Dispatcher.InvokeAsync(() =>{ mng.Title = formname; });
                    GC.Collect();
                    if (dntrnbcntrtlr == 1)
                    {
                        dntrnbcntrtlr = 0;
                    }
                    else
                    {
                        buzcontroller(fpath);
                    }
                    return System.Text.Encoding.UTF8.GetString(tutar.ToArray());
                }
                else
                {
                    cstatus = true;
                    seasalt = raes.generaterandomkey(32);
                    ivtg = new System.Security.Cryptography.Rfc2898DeriveBytes(reversebarray(raes.generaterandomkey(67)), System.Text.Encoding.ASCII.GetBytes(formbir.process.reversestring("youcanjoinsaltinfutureversivonsmsmsms")), 143, System.Security.Cryptography.HashAlgorithmName.SHA512).GetBytes(blocksize);
                    if (encrypthenmac == true)
                    {
                        byte[] scrkey = raes.argonkdf(System.Text.Encoding.UTF8.GetBytes(pkey), seasalt.Concat(System.Text.Encoding.ASCII.GetBytes(selectedalgorithm + "-" + selectedkeylength)).ToArray(), formbir.process.iterationrate, formbir.process.argmemrate, 2, (keysize / 8) * 2);
                        hsha512 = new HMACSHA512(scrkey.Skip(scrkey.Length / 2).ToArray());
                        keyt = scrkey.Take(scrkey.Length / 2).ToArray();
                        Org.BouncyCastle.Utilities.Arrays.Clear(scrkey);
                        scrkey = null;
                        hsha512.TransformBlock(ivtg, 0, blocksize, null, 0);
                    }
                    else
                    {
                        keyt = raes.argonkdf(System.Text.Encoding.UTF8.GetBytes(pkey), seasalt, formbir.process.iterationrate, formbir.process.argmemrate, 2, (keysize / 8));
                    }
                    tutrtwo = new System.IO.MemoryStream(textb);
                    okur = new System.IO.BinaryReader(tutrtwo);
                    string fffpath = "";
                    string fapth = "";
                    byte todelshred = 0;
                    if (System.IO.Path.GetExtension(fpath).Contains(".mng"))
                    {
                        fffpath = fpath;
                    }
                    else
                    {
                        todelshred = 1;
                        fapth = fpath;
                        fffpath = fpath + ".mng";
                        filepathh = fffpath;
                    }
                    yazar = new System.IO.BinaryWriter(System.IO.File.Open(fffpath, System.IO.FileMode.Create, System.IO.FileAccess.Write));
                    yazar.Write(ivtg);
                    yazar.Flush();
                    tutar = new System.IO.MemoryStream();
                    sencryptor.Init(cstatus, new ParametersWithIV(new KeyParameter(keyt), ivtg));
                    Org.BouncyCastle.Utilities.Arrays.Clear(keyt);
                    byte[] bytr = new byte[1000000];
                    long filesize = tutrtwo.Length;
                    while (okur.BaseStream.Position < filesize)
                    {
                        long ig = filesize - okur.BaseStream.Position;
                        await mng.Dispatcher.InvokeAsync(() =>
                        {
                            mng.Title = formname + " | Encrypting: " + "| %" + Math.Round((((double)okur.BaseStream.Position / (double)filesize) * 100), 0).ToString();

                        });
             
                        if (ig > 1000000)
                        {
                            bytr = new byte[1000000];
                            okur.Read(bytr, 0, 1000000);
                            byte[] encryptddata = new byte[1000000];
                            sencryptor.ProcessBytes(bytr, 0, 1000000, encryptddata, 0);
                            if (encrypthenmac == true)
                            {
                                hsha512.TransformBlock(encryptddata, 0, encryptddata.Length, null, 0);
                            }
                            yazar.Write(encryptddata, 0, (int)encryptddata.Length);
                            yazar.Flush();
                            Org.BouncyCastle.Utilities.Arrays.Clear(bytr);
                        }
                        else
                        {
                            bytr = new byte[(int)ig];
                            okur.Read(bytr, 0, (int)ig);
                            byte[] encryptddaata = new byte[(int)ig];
                            sencryptor.ProcessBytes(bytr, 0, (int)ig, encryptddaata, 0);
                            if (encrypthenmac == true)
                            {
                                hsha512.TransformFinalBlock(encryptddaata, 0, encryptddaata.Length);
                            }
                            yazar.Write(encryptddaata, 0, (int)encryptddaata.Length);
                            yazar.Flush();
                            Org.BouncyCastle.Utilities.Arrays.Clear(bytr);
                        }
                    }
                    yazar.Write(seasalt);
                    yazar.Flush();
                    if (encrypthenmac == true)
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
                    if (tutar != null)
                    {
                        tutar.Dispose();
                    }
                    sencryptor.Reset();
                    hsha512.Clear();
                    yazar.Close();
                    okur.Close();
                    tutar.Close();
                  
                    await mng.Dispatcher.InvokeAsync(() =>{ mng.Title = formname; });

                   
                  
                    if (todelshred == 1)
                    {
                        if (System.IO.File.Exists(fapth) == true)
                        {
                            if (formbir.formuc.dfafterencrypted1.IsChecked == true)
                            {
                                if (formbir.formuc.shredbd.IsChecked == true)
                                {
                                    shredfile(fapth);
                                }
                                System.IO.File.Delete(fapth);
                            }
                        }
                    }
                    GC.Collect();
                }
            }
            catch (Exception ex)
            {
              
                await mng.Dispatcher.InvokeAsync(() =>{ mng.Title = formname; });
                     
                MessageBox.Show("Operation ended with a error, these may cause an error's occure: file may not be a text file, program haven't access to file, your password is wrong or something else, Error = " + ex.Message + "\n" + ex.StackTrace.ToString(), "Multron NoteGuard", MessageBoxButton.OK, MessageBoxImage.Warning);
                filepathh = "";
                buzzer = 1;
                if (formbir.process.rcmng == 1 && drawed == 0)
                {
                    mng.Dispatcher.InvokeAsync(() => { mng.Close(); });
                }
                buzcontroller();
                try
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
            return "";
        }
        public void bclickerfnc(MenuItem tsmi)
        {

            
                Menu optionsMenu = mng.FindName("OptionsMenu") as Menu;

                if (optionsMenu != null)
                {
                    MenuItem optionsItem = optionsMenu.Items.OfType<MenuItem>().FirstOrDefault(i => (i.Header as string)?.Trim() == "Options");

                    if (optionsItem != null)
                    {
                        MenuItem algorithmMenu = optionsItem.Items.OfType<MenuItem>().FirstOrDefault(i => (i.Header as string)?.Trim() == "Algorithm");

                        if (algorithmMenu != null)
                        {

                            foreach (var subItem in algorithmMenu.Items.OfType<MenuItem>())
                            {
                                subItem.IsChecked = false;
                            }

                        }

                    }

                }

                tsmi.IsChecked = true;

                formbir.mngprocess.selectedalgorithm = tsmi.Header.ToString();
                string[] keyLengths;

            switch (formbir.mngprocess.selectedalgorithm)
            {
                case "AES":
                case "Serpent":
                case "Twofish":
                case "Camellia":
                    keyLengths = new string[] { "128", "192", "256" };
                    break;
                case "SM4":
                    keyLengths = new string[] { "128" };
                    break;
                case "ThreeFish":
                    keyLengths = new string[] { "256", "512", "1024" };
                    break;
                case "ChaCha20":
                    keyLengths = new string[] { "256" };
                    break;
                case "HC":
                    keyLengths = new string[] { "128", "256" };
                    break;
                default:
                    keyLengths = new string[] { };
                    break;
            }

                formbir.mngprocess.selectedkeylength = keyLengths.Length > 0 ? keyLengths[keyLengths.Length - 1] : "";
                formbir.mngprocess.swillsaved = 1;

                mng.UpdateKeyLengthMenu(keyLengths);
        }
        public void savesttngs()
        {
            try
            { 
                if (!Directory.Exists(mfgsfolder))
                {
                    try
                    {
                        Directory.CreateDirectory(mfgsfolder);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Failed to create settings folder:\n\n{ex.Message}",
                                       "Error",
                                       MessageBoxButton.OK,
                                       MessageBoxImage.Error);
                        return;
                    }
                }
                 
                Menu optionsMenu = mng.FindName("OptionsMenu") as Menu;
                if (optionsMenu != null && optionsMenu.Items.Count > 0)
                {
                    MenuItem optionsMenuItem = optionsMenu.Items[0] as MenuItem;
                    if (optionsMenuItem != null)
                    {
                        foreach (var obj in optionsMenuItem.Items)
                        {
                            if (obj is MenuItem item && !string.IsNullOrEmpty(item.Name) && item.Name.StartsWith("tosav"))
                            {
                                try
                                {
                                    string filePath = Path.Combine(mfgsfolder, item.Name + ".txt");
                                    string value = item.IsChecked ? "1" : "0";
                                    File.WriteAllText(filePath, value);
                                }
                                catch (Exception ex)
                                { 
                                    MessageBox.Show($"Failed to save setting '{item.Name}':\n\n{ex.Message}", "Error",  MessageBoxButton.OK, MessageBoxImage.Warning);
                                }
                            }
                        }
                    }
                }
              

                
                if (formbir.formuc.savealgorithm1.IsChecked == true)
                {
                    try {
                        if (!string.IsNullOrEmpty(selectedalgorithm))
                        {
                            File.WriteAllText(mngalg, selectedalgorithm);
                        }
                        else
                        {
                            MessageBox.Show("Algorithm is not selected. Using default AES.",
                                           "Information",
                                           MessageBoxButton.OK,
                                           MessageBoxImage.Information);
                            File.WriteAllText(mngalg, "AES");
                        }
                         
                        if (!string.IsNullOrEmpty(selectedkeylength))
                        {
                            File.WriteAllText(mngkeyl, selectedkeylength);
                        }
                    }

                    catch (Exception ex)
                    { 
                        MessageBox.Show($"Failed to save algorithm settings:\n\n{ex.Message}",   "Error",   MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                else
                {
                    string[] trgf = { mngalg, mngkeyl};
                    foreach (string file in trgf)
                    {
                        if (System.IO.File.Exists(file))
                        {
                            System.IO.File.Delete(file);
                        }
                    }
                }
                TextBox textBox1 = mng.textBox1;
                if (textBox1 != null)
                {
                    try
                    {
                        string isuline = "notuline";
                        if (textBox1.TextDecorations == TextDecorations.Underline)
                        {
                            isuline = "Underline";
                        }
                        string fw = new FontWeightConverter().ConvertToString(textBox1.FontWeight);
                        string fontstr = $"{textBox1.FontFamily.Source},{textBox1.FontSize},{fw},{textBox1.FontStyle}, {isuline}";
                        File.WriteAllText(mngfont, fontstr);
                    }
                    catch (Exception ex)
                    { 
                        MessageBox.Show($"Failed to save font settings:\n\n{ex.Message}", "Error",  MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                }
             
            }
            catch (Exception ex)
            { 
                MessageBox.Show($"An error occurred while saving settings:\n\n{ex.Message}",
                               "Error",
                               MessageBoxButton.OK,
                               MessageBoxImage.Error);
            }
        }
        public void getsttngs()
        {
            try
            {
                Menu optionsMenu = mng.FindName("OptionsMenu") as Menu;
                TextBox textBox1 = mng.FindName("textBox1") as TextBox;

                MenuItem optionsMenuItem = null;
                if (optionsMenu != null && optionsMenu.Items.Count > 0)
                {
                    optionsMenuItem = optionsMenu.Items[0] as MenuItem;
                }
                 
                if (optionsMenuItem != null)
                {
                    foreach (var obj in optionsMenuItem.Items)
                    {
                        if (obj is MenuItem item && !string.IsNullOrEmpty(item.Name) && item.Name.StartsWith("tosav"))
                        {
                            try
                            {
                                string path = Path.Combine(mfgsfolder, item.Name + ".txt");
                                if (File.Exists(path))
                                {
                                    string sresult = File.ReadAllText(path).Trim();
                                    item.IsChecked = (sresult == "1");
                                }
                            }
                            catch (Exception ex)
                            { 
                                MessageBox.Show($"Failed to load setting '{item.Name}':\n\n{ex.Message}", "Warning", MessageBoxButton.OK,  MessageBoxImage.Warning);
                            }
                        }
                    }
                }
               
                 
                if (formbir.formuc.savealgorithm1.IsChecked == true)
                {
                    if (File.Exists(mngalg))
                    {
                        try
                        {
                            string salgres = File.ReadAllText(mngalg).Trim();
                            bool algorithmFound = false;

                            if (optionsMenuItem != null)
                            {
                            
                                foreach (var obj in optionsMenuItem.Items)
                                {
                                    if (obj is MenuItem algorithmMenu && algorithmMenu.Header.ToString() == "Algorithm")
                                    {
                                       
                                        foreach (var subObj in algorithmMenu.Items)
                                        {
                                            if (subObj is MenuItem subitem)
                                            {
                                                string headerText = subitem.Header.ToString();
                                                  
                                                if (headerText.Equals(salgres, StringComparison.OrdinalIgnoreCase))
                                                { 
                                                    UncheckAllAlgorithms(algorithmMenu);
                                                     
                                                    subitem.IsChecked = true;

                                                    subitem.RaiseEvent(new RoutedEventArgs(MenuItem.ClickEvent));
                                                    algorithmFound = true;
                                                     
                                                    selectedalgorithm = headerText;

                                                    break;
                                                }
                                            }
                                        }

                                        if (algorithmFound)
                                            break;
                                    }
                                }
                            }
                            if (algorithmFound && File.Exists(mngkeyl))
                            {
                                try
                                {
                                    selectedkeylength = File.ReadAllText(mngkeyl).Trim();

                                    if (File.Exists(mngkeyl))
                                    {
                                        string symKeyLength = File.ReadAllText(mngkeyl).Trim();

                                        MenuItem keyLengthMenu = mng.FindName("symmetricKeyLengthToolStripMenuItem") as MenuItem;
                                        if (keyLengthMenu != null)
                                        {
                                            UncheckAllKeyLengths(keyLengthMenu);

                                            foreach (var obj in keyLengthMenu.Items)
                                            {
                                                if (obj is MenuItem item && item.Header.ToString().Contains(symKeyLength))
                                                {
                                                    item.IsChecked = true;
                                                    selectedkeylength = symKeyLength;
                                                    item.RaiseEvent(new RoutedEventArgs(MenuItem.ClickEvent));
                                                    break;
                                                }
                                            }
                                        }
                                    }
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show($"Failed to load key length setting:\n\n{ex.Message}", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                                }
                            }
                            if (!algorithmFound)
                            {
                                MenuItem aesMenu = mng.FindName("aESToolStripMenuItem0") as MenuItem;
                                if (aesMenu != null)
                                {
                                    UncheckAllAlgorithmsInParent(aesMenu);
                                    aesMenu.IsChecked = true;
                                    selectedalgorithm = "AES";
                                    aesMenu.RaiseEvent(new RoutedEventArgs(MenuItem.ClickEvent));
                                }
                                else
                                {
                                    MessageBox.Show($"Algorithm '{salgres}' not found. Please select manually.", "Warning",  MessageBoxButton.OK, MessageBoxImage.Warning);
                                }
                            } 
                            if (algorithmFound && File.Exists(mngkeyl))
                            {
                                try
                                {
                                    selectedkeylength = File.ReadAllText(mngkeyl).Trim();
                                }
                                catch (Exception ex)
                                {
                                    
                                    MessageBox.Show($"Failed to load key length setting:\n\n{ex.Message}", "Warning", MessageBoxButton.OK,  MessageBoxImage.Warning);
                                }
                            }
                        }
                        catch (Exception ex)
                        { 
                            MessageBox.Show($"Failed to load algorithm settings:\n\n{ex.Message}", "Error",  MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                    else
                    { 
                        MenuItem aesMenu = mng.FindName("aESToolStripMenuItem0") as MenuItem;
                        if (aesMenu != null)
                        {
                            UncheckAllAlgorithmsInParent(aesMenu);
                            aesMenu.IsChecked = true;
                            selectedalgorithm = "AES";
                            aesMenu.RaiseEvent(new RoutedEventArgs(MenuItem.ClickEvent));
                        }
                    }
                }
                else
                { 
                    MenuItem aesMenu = mng.FindName("aESToolStripMenuItem0") as MenuItem;
                    if (aesMenu != null)
                    {
                        UncheckAllAlgorithmsInParent(aesMenu);
                        aesMenu.IsChecked = true;
                        selectedalgorithm = "AES";
                        aesMenu.RaiseEvent(new RoutedEventArgs(MenuItem.ClickEvent));
                    }
                }

              
                if (textBox1 != null)
                {
                    if (File.Exists(mngfont))
                    {
                        try
                        {
                            string fontresult = File.ReadAllText(mngfont).Trim();
                            if (!string.IsNullOrEmpty(fontresult))
                            {
                                string[] parts = fontresult.Split(',');

                                if (!string.IsNullOrEmpty(parts[0]))
                                {
                                    try
                                    {
                                        textBox1.FontFamily = new System.Windows.Media.FontFamily(parts[0].Trim());

                                        if (!string.IsNullOrEmpty(parts[1]) && double.TryParse(parts[1].Trim(), out double size))
                                        {
                                            textBox1.FontSize = size;
                                        }
                                        if (!string.IsNullOrEmpty(parts[2]))
                                        {
                                            FontWeightConverter fwc = new FontWeightConverter();
                                            textBox1.FontWeight = (FontWeight) fwc.ConvertFromString(parts[2]);
                                        }
                                        if (!string.IsNullOrEmpty(parts[3]))
                                        {
                                            FontStyleConverter fsc = new FontStyleConverter();
                                            textBox1.FontStyle = (FontStyle)fsc.ConvertFromString(parts[3]);
                                        }
                                        if (!string.IsNullOrEmpty(parts[4]))
                                        {
                                            if (parts[4] == "Underline")
                                            {
                                                textBox1.TextDecorations = TextDecorations.Underline;
                                            }
                                        }
                                    }
                                    catch (Exception ex)
                                    { 
                                        MessageBox.Show($"An error occurred in getting font settings:\n\n{ex.Message} \n\n{ex.StackTrace.ToString()}", "Warning",  MessageBoxButton.OK, MessageBoxImage.Warning);
                                    }
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                           
                            MessageBox.Show($"Failed to load font settings:\n\n{ex.Message}",  "Warning",   MessageBoxButton.OK,  MessageBoxImage.Warning);
                        }
                    }
                }
              
                 
            }
            catch (Exception ex)
            { 
                MessageBox.Show($"An error occurred while loading settings:\n\n{ex.Message}", "Error",  MessageBoxButton.OK,  MessageBoxImage.Error);
            }
        }
        private void UncheckAllKeyLengths(MenuItem keylength)
        {
            foreach (var obj in keylength.Items)
            {
                if (obj is MenuItem item)
                {
                    item.IsChecked = false;
                }
            }
        }
        private void UncheckAllAlgorithms(MenuItem algorithmMenu)
        {
            foreach (var obj in algorithmMenu.Items)
            {
                if (obj is MenuItem item)
                {
                    item.IsChecked = false;
                }
            }
        }

        private void UncheckAllAlgorithmsInParent(MenuItem childItem)
        { 
            if (childItem.Parent is MenuItem parentMenu)
            {
                UncheckAllAlgorithms(parentMenu);
            }
        }
    }
}
