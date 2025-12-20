using multronfileguardian;
using MultronFileGuardian;
using Org.BouncyCastle;
using Org.BouncyCastle.Asn1.X509;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Engines;
using Org.BouncyCastle.Crypto.Modes;
using Org.BouncyCastle.Crypto.Paddings;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Utilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Reflection.Emit;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Threading;
using System.Xml.Linq;
namespace Multron_File_Guardian
{

    public class Processes
    {
        Window1 main;

        public short encryptstatus = 0;
        public long loop = 3;
        public short rtoperation = 1;
        public short rttoperation = 0;
        public int argmemrate = 262144;
        public int keysize = 4096;
        public int symkeysize = 256;
        public short iterationrate = 4;
        public short rcm = 0;
        public short rcmng = 0;
        public short closedmng = 1;
        HMACSHA512 hsha512 = new HMACSHA512(new byte[] { 0, 1, 2, 3, 4, 5, 5, 65 });
        public List<string> cmprsdf = new List<string>();
        public string mfgsfolder = AppContext.BaseDirectory + "\\mfgsettings";
        public string mfgalg = AppContext.BaseDirectory + "\\mfgsettings" + "\\algorithm.txt";
        public string mfgalgr = AppContext.BaseDirectory + "\\mfgsettings" + "\\algorithmr.txt";
        public string mfgcm = AppContext.BaseDirectory + "\\mfgsettings" + "\\algorithmciphmod.txt";
        public string mfgksize = AppContext.BaseDirectory + "\\mfgsettings" + "\\salgksize.txt";
        public string mfgiterate = AppContext.BaseDirectory + "\\mfgsettings" + "\\iterate.txt";
        public string mfgsiterate = AppContext.BaseDirectory + "\\mfgsettings" + "\\siterate.txt";
        public Processes(Window1 main)
        {
            this.main = main;
       
        }



  

        public void savesettings()
        {
            if (!System.IO.Directory.Exists(mfgsfolder))
            {
                System.IO.Directory.CreateDirectory(mfgsfolder);
            }
             
            SaveCheckBoxSetting("showpassword1", main.formuc.showpassword1.IsChecked == true);
            SaveCheckBoxSetting("dfafterencrypted1", main.formuc.dfafterencrypted1.IsChecked == true);
            SaveCheckBoxSetting("shredbd", main.formuc.shredbd.IsChecked == true);
            SaveCheckBoxSetting("savealgorithm1", main.formuc.savealgorithm1.IsChecked == true);
            SaveCheckBoxSetting("ckh1", main.formuc.ckh1.IsChecked == true);
            SaveCheckBoxSetting("cmpression1", main.formuc.cmpression1.IsChecked == true);
            SaveCheckBoxSetting("theme1", main.formuc.theme1.IsChecked == true);
            SaveCheckBoxSetting("iterationaut1", main.formuc.iterationaut1.IsChecked == true);
            SaveCheckBoxSetting("xscapz1", main.formuc.xscapz1.IsChecked == true);
            SaveCheckBoxSetting("iterationshrd1", main.formuc.iterationshrd1.IsChecked == true);

          
            string argonMemValue = "1";
            if (main.formuc.argmem2.IsChecked == true) argonMemValue = "2";
            else if (main.formuc.argmem3.IsChecked == true) argonMemValue = "3";
            System.IO.File.WriteAllText(System.IO.Path.Combine(mfgsfolder, "argmem.txt"), argonMemValue);

            if (main.formuc.savealgorithm1.IsChecked == true)
            {
                if (main.comboBox1.SelectedItem != null)
                {
                    string val = main.comboBox1.SelectedItem is ComboBoxItem cbi1
                        ? cbi1.Content.ToString()
                        : main.comboBox1.SelectedItem.ToString();
                    System.IO.File.WriteAllText(mfgalg, val);
                }

                if (main.comboBox2.SelectedItem != null)
                {
                    string val = main.comboBox2.SelectedItem is ComboBoxItem cbi2
                        ? cbi2.Content.ToString()
                        : main.comboBox2.SelectedItem.ToString();
                    System.IO.File.WriteAllText(mfgalgr, val);
                }

                if (main.comboBox3.SelectedItem != null)
                {
                    string val = main.comboBox3.SelectedItem is ComboBoxItem cbi3
                        ? cbi3.Content.ToString()
                        : main.comboBox3.SelectedItem.ToString();
                    System.IO.File.WriteAllText(mfgksize, val);
                }

                if (main.comboBox4.SelectedItem != null)
                {
                    string val = main.comboBox4.SelectedItem is ComboBoxItem cbi4
                        ? cbi4.Content.ToString()
                        : main.comboBox4.SelectedItem.ToString();
                    System.IO.File.WriteAllText(mfgcm, val);
                }
            }


            if (main.formuc.iterationaut1.IsChecked == true && !string.IsNullOrWhiteSpace(main.formuc.textBox1.Text))
            {
                System.IO.File.WriteAllText(mfgiterate, main.formuc.textBox1.Text);
            }

            if (main.formuc.iterationshrd1.IsChecked == true && !string.IsNullOrWhiteSpace(main.formuc.textBox2.Text))
            {
                System.IO.File.WriteAllText(mfgsiterate, main.formuc.textBox2.Text);
            }
        }

        private void SaveCheckBoxSetting(string name, bool isChecked)
        {
            string filePath = System.IO.Path.Combine(mfgsfolder, name + ".txt");
            System.IO.File.WriteAllText(filePath, isChecked ? "1" : "0");
        }
       public string combobox4Text = "";
       public string combobox1Text = "";
       public string combobox2Text = "";
       public  string combobox3Text = "";
        public async Task getcomboboxtextsasync()
        {
         
            await main.Dispatcher.InvokeAsync(() =>
            {
                combobox4Text = main.comboBox4.Text;
                combobox3Text = main.comboBox3.Text;
                combobox2Text = main.comboBox2.Text;
                combobox1Text = main.comboBox1.Text;
              
            });
        }
        // encryption decryption start
        public async Task aesprocesses(string key)
        {
            await Task.Run(async () =>
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
                    foreach (string dosyalar in main.listBox1.Items)
                    {
                        nstate = 1;
                        okur = new System.IO.BinaryReader(System.IO.File.Open(dosyalar, System.IO.FileMode.Open, System.IO.FileAccess.Read));
                        tutar = new MemoryStream();
                        await main.Dispatcher.InvokeAsync(() => {
                            main.label4.Text = "Iterating Password...";
                        });
                     
                        if (encryptstatus == 1)
                        {
                            yazar = new BinaryWriter(System.IO.File.Open(dosyalar + ".mfg", System.IO.FileMode.Create, System.IO.FileAccess.Write));
                            byte[] geniv = new System.Security.Cryptography.Rfc2898DeriveBytes(reversebarray(raes.generaterandomkey(67)), System.Text.Encoding.ASCII.GetBytes(reversestring("youcanjoinsaltinfutureversivonsmsmsms")), 143, System.Security.Cryptography.HashAlgorithmName.SHA512).GetBytes(16);
                            rijndael.IV = geniv;
                            yazar.Write(geniv);
                            yazar.Flush();
                            seasalt = raes.generaterandomkey(32);
                            if (combobox4Text == "Encrypt-then-MAC")
                            {
                                byte[] scrkey = raes.argonkdf(System.Text.Encoding.UTF8.GetBytes(key), seasalt.Concat(System.Text.Encoding.ASCII.GetBytes(combobox1Text + "-" + combobox3Text)).ToArray(), iterationrate, argmemrate, 2, (symkeysize / 8) * 2);
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
                            if (combobox4Text == "Encrypt-then-MAC")
                            {
                                okur.BaseStream.Position = new FileInfo(dosyalar).Length - 96;
                            }
                            else
                            {
                                okur.BaseStream.Position = new FileInfo(dosyalar).Length - 32;
                            }
                            okur.Read(seasalt, 0, 32);
                            okur.BaseStream.Position = 16;
                            if (combobox4Text == "Encrypt-then-MAC")
                            {
                                await main.Dispatcher.InvokeAsync( () => {
                                    main.label4.Text = "Authentication starting...";
                                });
                             
                                byte[] scrkey = raes.argonkdf(System.Text.Encoding.UTF8.GetBytes(key), seasalt.Concat(System.Text.Encoding.ASCII.GetBytes(combobox1Text + "-" + combobox3Text)).ToArray(), iterationrate, argmemrate, 2, (symkeysize / 8) * 2);
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
                                    await main.Dispatcher.InvokeAsync(() =>
                                    {
                                        main.label4.Text = "Authenticating: " + afname + " | %" + Math.Round((((double)okur.BaseStream.Position / (double)afsz) * 100), 0).ToString(); 
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
                                 
                                    await main.Dispatcher.InvokeAsync(() => {
                                        main.label4.Text = afname + " Cannot be authenticated, Decryption process denied for this file!";
                                  
                                    });
                                    await Task.Delay(4000);
                                    await main.Dispatcher.InvokeAsync(() => {
                                        main.label4.Text = "";
                                    });
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
                            if (combobox4Text == "Encrypt-then-MAC")
                            {
                                fsize = fsize - 64;
                                okur.BaseStream.Position = 16;
                            }
                        }
                        string filenamew = new System.IO.FileInfo(dosyalar).Name;
                        while (okur.BaseStream.Position < fsize)
                        {
                            await main.Dispatcher.InvokeAsync(() =>
                            {
                                if (encryptstatus == 1)
                                {
                                    main.label4.Text = "Encrypting: " + filenamew + " | %" + Math.Round((((double)okur.BaseStream.Position / (double)fsize) * 100), 0).ToString();
                                }
                                else
                                {
                                    main.label4.Text = "Decrypting: " + filenamew + " | %" + Math.Round((((double)okur.BaseStream.Position / (double)fsize) * 100), 0).ToString();
                                }
                            });
                     
                            long whereweare = fsize - okur.BaseStream.Position;
                            if (whereweare > 1000000)
                            {
                                bxytes = new byte[1000000];
                                okur.Read(bxytes, 0, 1000000);
                                sifreler.Write(bxytes, 0, 1000000);
                                sifreler.Flush();
                                yazar.Write(tutar.ToArray(), 0, (int)tutar.Length);
                                yazar.Flush();
                                if (encryptstatus == 1 && combobox4Text == "Encrypt-then-MAC")
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
                                if (encryptstatus == 1 && combobox4Text == "Encrypt-then-MAC")
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
                            if (combobox4Text == "Encrypt-then-MAC")
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
                        await main.Dispatcher.InvokeAsync(async () => {
                            if (main.formuc.dfafterencrypted1.IsChecked == true)
                            {
                                if (main.formuc.shredbd.IsChecked == true)
                                {
                                    await shredfile(dosyalar);
                                }
                                System.IO.File.Delete(dosyalar);
                            }
                        });
                    
                    }
                }
                catch (Exception exc)
                {
                    nstate = 0;
                    MessageBox.Show("Operation ended with a error, these may cause an error's occure: file dont exists, program haven't access to file, your password is wrong or something else, error = " + exc.Message + " | You can contact programmer, Discord = dr_wellss " + exc.StackTrace, "Multron File Guardian", MessageBoxButton.OK, MessageBoxImage.Error);
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

                    await main.Dispatcher.InvokeAsync(() => {
                        main.label4.Text = "Operation Done.";
                    
                   
                    });
                    await Task.Delay(3500);
                    await main.Dispatcher.InvokeAsync(() => {
                      
                  
                        if (main.formuc.cmpression1.IsChecked == false || encryptstatus == 1)
                        {
                            main.listBox1.Items.Clear();
                        }
                        if (main.formuc.cmpression1.IsChecked == true && encryptstatus == 2)
                        {
                            if (cmpcontroller() == 1)
                            {
                            
                                main.panel3.Visibility = Visibility.Visible;
                             
                            }
                            else
                            {
                                main.listBox1.Items.Clear();
                            }
                        }
                    });
                   

                }
                await edcontrols(1);
                await main.Dispatcher.InvokeAsync(() => {
                    main.label4.Text = "";
                });
              
                GC.Collect();
                if (rcm == 1)
                {
                    Environment.Exit(0);
                }
            });
           
        }
        public async Task aesrsaprocesses(string key)
        {
            await Task.Run(async () =>
            {
                short nstate = 0;
                System.IO.BinaryReader okur = null;
                System.IO.BinaryWriter yazar = null;
                System.IO.MemoryStream tutar = null;
                System.Security.Cryptography.CryptoStream sifreler = null;
                try
                {
                    System.Security.Cryptography.Aes rijndael = System.Security.Cryptography.Aes.Create();
                    rijndael.KeySize = symkeysize;
                    rijndael.BlockSize = 128;
                    rijndael.Mode = System.Security.Cryptography.CipherMode.CBC;
                    rijndael.Padding = System.Security.Cryptography.PaddingMode.PKCS7;
                    byte[] aeskey = new byte[symkeysize / 8];
                    byte[] ivtg = new byte[16];
                    foreach (string dosyalar in main.listBox1.Items)
                    {
                        nstate = 1;
                        if (encryptstatus == 1)
                        {
                            aeskey = raes.generaterandomkey(67);
                            byte[] nraeskey = raes.rsaencrypt(aeskey, key, keysize);
                            await main.Dispatcher.InvokeAsync(() =>
                            {
                                main.label4.Text = "Iterating Password...";
                            });
                           
                            if (combobox4Text == "Encrypt-then-MAC")
                            {
                                byte[] scrkey = raes.argonkdf(aeskey, System.Text.Encoding.ASCII.GetBytes("youcanjoinsaltinfutureversionsmsmsms").Concat(System.Text.Encoding.ASCII.GetBytes(combobox1Text + "-" + combobox3Text)).ToArray(), iterationrate, argmemrate, 2, (symkeysize / 8) * 2);
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
                            if (combobox4Text == "Encrypt-then-MAC")
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
                                await main.Dispatcher.InvokeAsync(() =>
                                {
                                    main.label4.Text = "Encrypting: " + filenamew + " | %" + Math.Round((((double)okur.BaseStream.Position / (double)filesize) * 100), 0).ToString();
                                });
                             
                                if (ig > 1000000)
                                {
                                    neww = new byte[1000000];
                                    okur.Read(neww, 0, 1000000);
                                    sifreler.Write(neww, 0, 1000000);
                                    sifreler.Flush();
                                    if (combobox4Text == "Encrypt-then-MAC")
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
                                    if (combobox4Text == "Encrypt-then-MAC")
                                    {
                                        hsha512.TransformFinalBlock(tutar.ToArray(), 0, (int)tutar.Length);
                                    }
                                    yazar.Write(tutar.ToArray(), 0, (int)tutar.Length);
                                    yazar.Flush();
                                    tutar.SetLength(0);
                                    Org.BouncyCastle.Utilities.Arrays.Clear(neww);
                                }
                            }
                            if (combobox4Text == "Encrypt-then-MAC")
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
                            await main.Dispatcher.InvokeAsync(() =>
                            {
                                main.label4.Text = "Iterating Password...";
                            });
                        
                            if (combobox4Text == "Encrypt-then-MAC")
                            {
                                await main.Dispatcher.InvokeAsync(() =>
                                {
                                    main.label4.Text = "Authentication starting...";
                                });
                          
                                byte[] scrkey = raes.argonkdf(aeskey, System.Text.Encoding.ASCII.GetBytes("youcanjoinsaltinfutureversionsmsmsms").Concat(System.Text.Encoding.ASCII.GetBytes(combobox1Text + "-" + combobox3Text)).ToArray(), iterationrate, argmemrate, 2, (symkeysize / 8) * 2);
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
                                    await main.Dispatcher.InvokeAsync(() =>
                                    {
                                        main.label4.Text = "Authenticating: " + afname + " | %" + Math.Round((((double)okur.BaseStream.Position / (double)afsz) * 100), 0).ToString(); ;
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
                                    await main.Dispatcher.InvokeAsync(() =>
                                    {
                                        main.label4.Text = afname + " Cannot be authenticated, Decryption process denied for this file!";
                                    });
                                  
                                    await Task.Delay(4000);
                                    await main.Dispatcher.InvokeAsync(() => { main.label4.Text = ""; }); ;
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
                            if (combobox4Text == "Encrypt-then-MAC")
                            {
                                filesize = filesize - 64;
                            }
                            string filenamew = new System.IO.FileInfo(dosyalar).Name;
                            while (okur.BaseStream.Position < filesize)
                            {
                                long ig = filesize - okur.BaseStream.Position;
                                await main.Dispatcher.InvokeAsync(() =>
                                {
                                    main.label4.Text = "Decrypting: " + filenamew + " | %" + Math.Round((((double)okur.BaseStream.Position / (double)filesize) * 100), 0).ToString();
                                });
                            

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
                        await main.Dispatcher.InvokeAsync(async() =>
                        {
                            if (main.formuc.dfafterencrypted1.IsChecked == true)
                            {
                                if (main.formuc.shredbd.IsChecked == true)
                                {
                                    await shredfile(dosyalar);
                                }
                                System.IO.File.Delete(dosyalar);
                            }
                        });
                     
                    }
                }
                catch (Exception exc)
                {
                    nstate = 0;
                    MessageBox.Show("Operation ended with a error, these may cause an error's occure: file dont exists, program haven't access to file, your password is wrong or something else, error = " + exc.Message + " | You can contact programmer, Discord = dr_wellss " + " stacktrace: " + exc.StackTrace, "Multron File Guardian", MessageBoxButton.OK, MessageBoxImage.Error);
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
                    await main.Dispatcher.InvokeAsync(() =>
                    {
                        main.label4.Text = "Operation Done.";
                    });
              
                    await Task.Delay(3500);
                    await main.Dispatcher.InvokeAsync(() =>
                    {
                        if (main.formuc.cmpression1.IsChecked == false || encryptstatus == 1)
                        {
                            main.listBox1.Items.Clear();
                        }
                        if (main.formuc.cmpression1.IsChecked == true && encryptstatus == 2)
                        {
                            if (cmpcontroller() == 1)
                            {
                             
                                 main.panel3.Visibility = Visibility.Visible;
                              

                            }
                            else
                            {
                                main.listBox1.Items.Clear();
                            }
                        }
                    });
               
                }
                await edcontrols(1);
                await main.Dispatcher.InvokeAsync(() => { main.label4.Text = ""; }); ;
                GC.Collect();
                if (rcm == 1)
                {
                    Environment.Exit(0);
                }
            });
           
        }
        public async Task strcphprocesses(string key, IStreamCipher iscipher, short blocksize)
        {
            await Task.Run(async () =>
            {
                BinaryReader okur = null;
                BinaryWriter yazar = null;
                short nstate = 0;
                Boolean cryptstate = false;
                byte[] seasalt = new byte[32];
                byte[] keyt = new byte[symkeysize / 8];
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
                    foreach (string dosyalar in main.listBox1.Items)
                    {
                        nstate = 1;
                        okur = new BinaryReader(File.Open(dosyalar, FileMode.Open, FileAccess.Read));
                        await main.Dispatcher.InvokeAsync(() =>
                        {
                            main.label4.Text = "Iterating Password...";
                        });
                      
                        if (encryptstatus == 1)
                        {
                            seasalt = raes.generaterandomkey(32);
                            yazar = new BinaryWriter(File.Open(dosyalar + ".mfg", FileMode.Create, FileAccess.Write));
                            ivtg = new System.Security.Cryptography.Rfc2898DeriveBytes(reversebarray(raes.generaterandomkey(67)), System.Text.Encoding.ASCII.GetBytes(reversestring("youcanjoinsaltinfutureversivonsmsmsms")), 143, System.Security.Cryptography.HashAlgorithmName.SHA512).GetBytes(blocksize);
                            if (combobox4Text == "Encrypt-then-MAC")
                            {
                                byte[] scrkey = raes.argonkdf(System.Text.Encoding.UTF8.GetBytes(key), seasalt.Concat(System.Text.Encoding.ASCII.GetBytes(combobox1Text + "-" + combobox3Text)).ToArray(), iterationrate, argmemrate, 2, (symkeysize / 8) * 2);
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
                            if (combobox4Text == "Encrypt-then-MAC")
                            {
                                okur.BaseStream.Position = new FileInfo(dosyalar).Length - 96;
                            }
                            else
                            {
                                okur.BaseStream.Position = new FileInfo(dosyalar).Length - 32;
                            }
                            okur.Read(seasalt, 0, 32);
                            okur.BaseStream.Position = blocksize;
                            if (combobox4Text == "Encrypt-then-MAC")
                            {
                                await main.Dispatcher.InvokeAsync(() =>
                                {
                                    main.label4.Text = "Authentication starting...";
                                });
                         
                                byte[] scrkey = raes.argonkdf(System.Text.Encoding.UTF8.GetBytes(key), seasalt.Concat(System.Text.Encoding.ASCII.GetBytes(combobox1Text + "-" + combobox3Text)).ToArray(), iterationrate, argmemrate, 2, (symkeysize / 8) * 2);
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
                                    await main.Dispatcher.InvokeAsync(() =>
                                    {
                                        main.label4.Text = "Authenticating: " + afname + " | %" + Math.Round((((double)okur.BaseStream.Position / (double)afsz) * 100), 0).ToString(); ;
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
                                    await main.Dispatcher.InvokeAsync(() =>
                                    {
                                        main.label4.Text = afname + " Cannot be authenticated, Decryption process denied for this file!";
                                    });
                       
                                    await Task.Delay(4000);
                                    main.Dispatcher.Invoke(() => { main.label4.Text = ""; }); ;
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
                            if (combobox4Text == "Encrypt-then-MAC")
                            {
                                fsize = fsize - 64;
                            }
                        }
                        while (okur.BaseStream.Position < fsize)
                        {
                            long whereweare = fsize - okur.BaseStream.Position;
                            await main.Dispatcher.InvokeAsync(() =>
                            {
                                if (encryptstatus == 1)
                                {
                                    main.label4.Text = "Encrypting: " + filenamew + " | %" + Math.Round((((double)okur.BaseStream.Position / (double)fsize) * 100), 0).ToString();
                                }
                                else
                                {
                                    main.label4.Text = "Decrypting: " + filenamew + " | %" + Math.Round((((double)okur.BaseStream.Position / (double)fsize) * 100), 0).ToString();
                                }
                            });
                        
                            if (whereweare > 1000000)
                            {
                                bytesx = new byte[1000000];
                                okur.Read(bytesx, 0, 1000000);
                                byte[] encdata = new byte[1000000];
                                chatea.ProcessBytes(bytesx, 0, 1000000, encdata, 0);
                                if (encryptstatus == 1 && combobox4Text == "Encrypt-then-MAC")
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
                                if (encryptstatus == 1 && combobox4Text == "Encrypt-then-MAC")
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
                            if (combobox4Text == "Encrypt-then-MAC")
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
                        await main.Dispatcher.InvokeAsync(async() =>
                        {
                            if (main.formuc.dfafterencrypted1.IsChecked == true)
                            {
                                if (main.formuc.shredbd.IsChecked == true)
                                {
                                    await shredfile(dosyalar);
                                }
                                System.IO.File.Delete(dosyalar);
                            }
                        });
                 
                    }
                }
                catch (Exception x)
                {
                    nstate = 0;
                    MessageBox.Show("Operation ended with a error, these may cause an error's occure: file dont exists, program haven't access to file, your password is wrong or something else, error = " + x.Message + " | You can contact programmer, Discord = dr_wellss " + " stacktrace: " + x.StackTrace, "Multron File Guardian", MessageBoxButton.OK, MessageBoxImage.Error);
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
                    await main.Dispatcher.InvokeAsync(() =>
                    {
                        main.label4.Text = "Operation Done.";
                    });
                
                    await Task.Delay(3500);
                    await main.Dispatcher.InvokeAsync(() =>
                    {
                        if (main.formuc.cmpression1.IsChecked == false || encryptstatus == 1)
                        {
                            main.listBox1.Items.Clear();
                        }
                        if (main.formuc.cmpression1.IsChecked == true && encryptstatus == 2)
                        {
                            if (cmpcontroller() == 1)
                            {
                             
                                  main.panel3.Visibility = Visibility.Visible;
                               
                            }
                            else
                            {
                                main.listBox1.Items.Clear();
                            }
                        }
                    });
                
                }
                await edcontrols(1);
                GC.Collect();
               await main.Dispatcher.InvokeAsync(() => { main.label4.Text = ""; }); ;
                if (rcm == 1)
                {
                    Environment.Exit(0);
                }
            });
           
        }

        public async Task strcphrsaprocesses(string key, IStreamCipher iscphr, short blocksize)
        {
            await Task.Run(async () =>
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
                    foreach (string dosyalar in main.listBox1.Items)
                    {
                        if (encryptstatus == 1)
                        {
                            nstate = 1;
                            await main.Dispatcher.InvokeAsync(() =>
                            {
                                main.label4.Text = "Iterating Password...";
                            });
                           
                            serpentkey = raes.generaterandomkey(67);
                            serkey = raes.rsaencrypt(serpentkey, key, keysize);
                            ivtg = new System.Security.Cryptography.Rfc2898DeriveBytes(reversebarray(raes.generaterandomkey(67)), System.Text.Encoding.ASCII.GetBytes(reversestring("youcanjoinsaltinfutureversivonsmsmsms")), 143, System.Security.Cryptography.HashAlgorithmName.SHA512).GetBytes(blocksize);
                            if (combobox4Text == "Encrypt-then-MAC")
                            {
                                byte[] scrkey = raes.argonkdf(serpentkey, System.Text.Encoding.ASCII.GetBytes("youcanjoinsaltinfutureversionsmsmsms").Concat(System.Text.Encoding.ASCII.GetBytes(combobox1Text + "-" + combobox3Text)).ToArray(), iterationrate, argmemrate, 2, (symkeysize / 8) * 2);
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
                                await main.Dispatcher.InvokeAsync(() =>
                                {
                                    main.label4.Text = "Encrypting: " + filenamew + " | %" + Math.Round((((double)okur.BaseStream.Position / (double)fsize) * 100), 0).ToString();
                                });
                             
                                if (whereewearee > 1000000)
                                {
                                    bxynew = new byte[1000000];
                                    okur.Read(bxynew, 0, 1000000);
                                    byte[] encrypted = new byte[1000000];
                                    sifreler.ProcessBytes(bxynew, 0, 1000000, encrypted, 0);
                                    if (combobox4Text == "Encrypt-then-MAC")
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
                                    if (combobox4Text == "Encrypt-then-MAC")
                                    {
                                        hsha512.TransformFinalBlock(encrypted, 0, (int)whereewearee);
                                    }
                                    yazar.Write(encrypted, 0, (int)whereewearee);
                                    yazar.Flush();
                                    Org.BouncyCastle.Utilities.Arrays.Clear(bxynew);
                                }
                            }
                            if (combobox4Text == "Encrypt-then-MAC")
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
                           await main.Dispatcher.InvokeAsync(async() =>
                            {
                                if (main.formuc.dfafterencrypted1.IsChecked == true)
                                {
                                    if (main.formuc.shredbd.IsChecked == true)
                                    {
                                        await shredfile(dosyalar);
                                    }
                                    System.IO.File.Delete(dosyalar);
                                }
                            });
                            
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
                            await main.Dispatcher.InvokeAsync(() =>
                            {
                                main.label4.Text = "Iterating Password...";
                            });
                        
                            if (combobox4Text == "Encrypt-then-MAC")
                            {
                                await main.Dispatcher.InvokeAsync(() =>
                                {
                                    main.label4.Text = "Authentication starting...";
                                });
                          
                                byte[] scrkey = raes.argonkdf(dsk, System.Text.Encoding.ASCII.GetBytes("youcanjoinsaltinfutureversionsmsmsms").Concat(System.Text.Encoding.ASCII.GetBytes(combobox1Text + "-" + combobox3Text)).ToArray(), iterationrate, argmemrate, 2, (symkeysize / 8) * 2);
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
                                    await main.Dispatcher.InvokeAsync(() =>
                                    {
                                        main.label4.Text = "Authenticating: " + afname + " | %" + Math.Round((((double)okur.BaseStream.Position / (double)afsz) * 100), 0).ToString();
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
                                    await main.Dispatcher.InvokeAsync(() =>
                                    {
                                        main.label4.Text = afname + " Cannot be authenticated, Decryption process denied for this file!";
                                    });

                                   
                                    await Task.Delay(4000);
                                    main.Dispatcher.Invoke(() => { main.label4.Text = ""; }); ;
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
                            if (combobox4Text == "Encrypt-then-MAC")
                            {
                                fsize = fsize - 64;
                            }
                            string filenamew = new System.IO.FileInfo(dosyalar).Name;
                            while (okur.BaseStream.Position < fsize)
                            {
                                long whweare = fsize - okur.BaseStream.Position;
                                await main.Dispatcher.InvokeAsync(() =>
                                {
                                    main.label4.Text = "Decrypting: " + filenamew + " | %" + Math.Round((((double)okur.BaseStream.Position / (double)fsize) * 100), 0).ToString();
                                });
                              
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
                            await main.Dispatcher.InvokeAsync(async() =>
                            {
                                if (main.formuc.dfafterencrypted1.IsChecked == true)
                                {
                                    if (main.formuc.shredbd.IsChecked == true)
                                    {
                                        await shredfile(dosyalar);
                                    }
                                    System.IO.File.Delete(dosyalar);
                                }
                            });
                       
                        }
                    }
                }
                catch (Exception ex)
                {
                    nstate = 0;
                    MessageBox.Show("Operation ended with a error, these may cause an error's occure: file dont exists, program haven't access to file, your password is wrong or something else, error = " + ex.Message + " | You can contact programmer, Discord = dr_wellss " + " stacktrace: " + ex.StackTrace, "Multron File Guardian", MessageBoxButton.OK, MessageBoxImage.Error);
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
                    await main.Dispatcher.InvokeAsync(() =>
                    {
                        main.label4.Text = "Operation Done.";
                    });
              
                    await Task.Delay(3500);
                    await main.Dispatcher.InvokeAsync(() =>
                    {
                        if (main.formuc.cmpression1.IsChecked == false || encryptstatus == 1)
                        {
                            main.listBox1.Items.Clear();
                        }
                        if (main.formuc.cmpression1.IsChecked == true && encryptstatus == 2)
                        {
                            if (cmpcontroller() == 1)
                            {

                                main.panel3.Visibility = Visibility.Visible;
                               
                            }
                            else
                            {
                                main.listBox1.Items.Clear();
                            }
                        }
                    });
                  
                }
                await edcontrols(1);
                GC.Collect();
                await main.Dispatcher.InvokeAsync(() => { main.label4.Text = ""; }); ;
                if (rcm == 1)
                {
                    Environment.Exit(0);
                }
            });
            
        }
        public async Task bciphersrsaprocesses(string key, IBlockCipher bc, short blocksize = 16)
        {
            await Task.Run(async () =>
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
                    foreach (string dosyalar in main.listBox1.Items)
                    {
                        if (encryptstatus == 1)
                        {
                            nstate = 1;
                            await main.Dispatcher.InvokeAsync(() =>
                            {
                                main.label4.Text = "Iterating Password...";
                            });

                          
                            serpentkey = raes.generaterandomkey(67);
                            serkey = raes.rsaencrypt(serpentkey, key, keysize);
                            ivtg = new System.Security.Cryptography.Rfc2898DeriveBytes(reversebarray(raes.generaterandomkey(67)), System.Text.Encoding.ASCII.GetBytes(reversestring("youcanjoinsaltinfutureversivonsmsmsms")), 143, System.Security.Cryptography.HashAlgorithmName.SHA512).GetBytes(blocksize);
                            if (combobox4Text == "Encrypt-then-MAC")
                            {
                                byte[] scrkey = raes.argonkdf(serpentkey, System.Text.Encoding.ASCII.GetBytes("youcanjoinsaltinfutureversionsmsmsms").Concat(System.Text.Encoding.ASCII.GetBytes(combobox1Text + "-" + combobox3Text)).ToArray(), iterationrate, argmemrate, 2, (symkeysize / 8) * 2);
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
                                await main.Dispatcher.InvokeAsync(() =>
                                {
                                    main.label4.Text = "Encrypting: " + filenamew + " | %" + Math.Round((((double)okur.BaseStream.Position / (double)fsize) * 100), 0).ToString();
                                });
                              
                                if (whereewearee > 1000000)
                                {
                                    bxynew = new byte[1000000];
                                    okur.Read(bxynew, 0, 1000000);
                                    byte[] encrypted = sifreler.ProcessBytes(bxynew);
                                    if (combobox4Text == "Encrypt-then-MAC")
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
                                    if (combobox4Text == "Encrypt-then-MAC")
                                    {
                                        hsha512.TransformFinalBlock(encrypted, 0, encrypted.Length);
                                    }
                                    yazar.Write(encrypted, 0, encrypted.Length);
                                    yazar.Flush();
                                    Org.BouncyCastle.Utilities.Arrays.Clear(bxynew);
                                }
                            }
                            if (combobox4Text == "Encrypt-then-MAC")
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
                            await main.Dispatcher.InvokeAsync(async() =>
                            {
                                if (main.formuc.dfafterencrypted1.IsChecked == true)
                                {
                                    if (main.formuc.shredbd.IsChecked == true)
                                    {
                                        await shredfile(dosyalar);
                                    }
                                    System.IO.File.Delete(dosyalar);
                                }
                            });
                      
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
                            await main.Dispatcher.InvokeAsync(() =>
                            {
                                main.label4.Text = "Iterating Password...";
                            });
                         
                            if (combobox4Text == "Encrypt-then-MAC")
                            {
                                await main.Dispatcher.InvokeAsync(() =>
                                {
                                    main.label4.Text = "Authentication starting...";
                                });
                              
                                byte[] scrkey = raes.argonkdf(dsk, System.Text.Encoding.ASCII.GetBytes("youcanjoinsaltinfutureversionsmsmsms").Concat(System.Text.Encoding.ASCII.GetBytes(combobox1Text + "-" + combobox3Text)).ToArray(), iterationrate, argmemrate, 2, (symkeysize / 8) * 2);
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
                                    await main.Dispatcher.InvokeAsync(() =>
                                    {
                                        main.label4.Text = "Authenticating: " + afname + " | %" + Math.Round((((double)okur.BaseStream.Position / (double)afsz) * 100), 0).ToString(); 
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
                                    await main.Dispatcher.InvokeAsync(() =>
                                    {
                                            main.label4.Text = afname + " Cannot be authenticated, Decryption process denied for this file!";
                                    });
                                    await Task.Delay(4000);
                                    main.Dispatcher.Invoke(() => { main.label4.Text = ""; }); ;
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
                            if (combobox4Text == "Encrypt-then-MAC")
                            {
                                fsize = fsize - 64;
                            }
                            string filenamew = new System.IO.FileInfo(dosyalar).Name;
                            while (okur.BaseStream.Position < fsize)
                            {
                                long whweare = fsize - okur.BaseStream.Position;
                                await main.Dispatcher.InvokeAsync(() =>
                                {
                                    main.label4.Text = "Decrypting: " + filenamew + " | %" + Math.Round((((double)okur.BaseStream.Position / (double)fsize) * 100), 0).ToString();
                                });
                              
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
                            await main.Dispatcher.InvokeAsync(async() =>
                            {

                                if (main.formuc.dfafterencrypted1.IsChecked == true)
                                {
                                    if (main.formuc.shredbd.IsChecked == true)
                                    {
                                       await shredfile(dosyalar);
                                    }
                                    System.IO.File.Delete(dosyalar);
                                }
                            });
                          
                        }
                    }
                }
                catch (Exception ex)
                {
                    nstate = 0;
                    MessageBox.Show("Operation ended with a error, these may cause an error's occure: file dont exists, program haven't access to file, your password is wrong or something else, error = " + ex.Message + " | You can contact programmer, Discord = dr_wellss " + " stacktrace: " + ex.StackTrace, "Multron File Guardian", MessageBoxButton.OK, MessageBoxImage.Error);
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
                    await main.Dispatcher.InvokeAsync(() =>
                    {
                        main.label4.Text = "Operation Done.";
                    });
                
                    await Task.Delay(3500);
                    await main.Dispatcher.InvokeAsync(() =>
                    {
                        if (main.formuc.cmpression1.IsChecked == false || encryptstatus == 1)
                        {
                            main.listBox1.Items.Clear();
                        }
                        if (main.formuc.cmpression1.IsChecked == true && encryptstatus == 2)
                        {
                            if (cmpcontroller() == 1)
                            { 
                                  main.panel3.Visibility = Visibility.Visible;
                              
                            }
                            else
                            {
                                main.listBox1.Items.Clear();
                            }
                        }
                    });
               
                }
                await edcontrols(1);
                GC.Collect();
                await main.Dispatcher.InvokeAsync(() => { main.label4.Text = ""; }); ;
                if (rcm == 1)
                {
                    Environment.Exit(0);
                }
            });
            
        }

        public async Task ciphersprocesses(string key, IBlockCipher bc, short blocksize = 16)
        {
            await Task.Run(async () =>
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
                foreach (string dosyalar in main.listBox1.Items)
                {
                    nstate = 1;
                    okur = new BinaryReader(System.IO.File.Open(dosyalar, FileMode.Open, FileAccess.Read));
                    await main.Dispatcher.InvokeAsync(() =>
                    {
                        main.label4.Text = "Iterating Password...";
                    });

                    if (encryptstatus == 1)
                    {
                        seasalt = raes.generaterandomkey(32);
                        yazar = new BinaryWriter(File.Open(dosyalar + ".mfg", FileMode.Create, FileAccess.Write));
                        ivtg = new System.Security.Cryptography.Rfc2898DeriveBytes(reversebarray(raes.generaterandomkey(67)), System.Text.Encoding.ASCII.GetBytes(reversestring("youcanjoinsaltinfutureversivonsmsmsms")), 143, System.Security.Cryptography.HashAlgorithmName.SHA512).GetBytes(blocksize);

                    
                            if (combobox4Text == "Encrypt-then-MAC")
                            {
                                byte[] scrkey = raes.argonkdf(System.Text.Encoding.UTF8.GetBytes(key), seasalt.Concat(System.Text.Encoding.ASCII.GetBytes(combobox1Text + "-" + combobox3Text)).ToArray(), iterationrate, argmemrate, 2, (symkeysize / 8) * 2);
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
                   

                            if (combobox4Text == "Encrypt-then-MAC")
                            {
                                okur.BaseStream.Position = new FileInfo(dosyalar).Length - 96;
                            }
                            else
                            {
                                okur.BaseStream.Position = new FileInfo(dosyalar).Length - 32;
                            }
                    

                        okur.Read(seasalt, 0, 32);
                            okur.BaseStream.Position = blocksize;
                        if (combobox4Text == "Encrypt-then-MAC")
                        {
                            await main.Dispatcher.InvokeAsync(() =>
                            {
                                main.label4.Text = "Authentication starting...";
                            });
                            byte[] scrkey = raes.argonkdf(System.Text.Encoding.UTF8.GetBytes(key), seasalt.Concat(System.Text.Encoding.ASCII.GetBytes(combobox1Text + "-" + combobox3Text)).ToArray(), iterationrate, argmemrate, 2, (symkeysize / 8) * 2);
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
                                await main.Dispatcher.InvokeAsync(() =>
                                {
                                    main.label4.Text = "Authenticating: " + afname + " | %" + Math.Round((((double)okur.BaseStream.Position / (double)afsz) * 100), 0).ToString(); ;
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
                                await main.Dispatcher.InvokeAsync(() =>
                                {
                                    main.label4.Text = afname + " Cannot be authenticated, Decryption process denied for this file!";
                                });


                                await Task.Delay(4000);
                                main.Dispatcher.Invoke(() => { main.label4.Text = ""; }); ;
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
                        if (combobox4Text == "Encrypt-then-MAC")
                        {
                            fsize = fsize - 64;
                        }
                    }
                    string filenamew = new System.IO.FileInfo(dosyalar).Name;
                    while (okur.BaseStream.Position < fsize)
                    {
                        long whereweare = fsize - okur.BaseStream.Position;
                        await main.Dispatcher.InvokeAsync(() =>
                        {
                            if (encryptstatus == 1)
                            {
                                main.label4.Text = "Encrypting: " + filenamew + " | %" + Math.Round((((double)okur.BaseStream.Position / (double)fsize) * 100), 0).ToString();
                            }
                            else
                            {
                                main.label4.Text = "Decrypting: " + filenamew + " | %" + Math.Round((((double)okur.BaseStream.Position / (double)fsize) * 100), 0).ToString();
                            }
                        });

                        if (whereweare > 1000000)
                        {
                            neww = new byte[1000000];
                            okur.Read(neww, 0, 1000000);
                            byte[] encrypted = sifreler.ProcessBytes(neww);
                            if (encryptstatus == 1 && combobox4Text == "Encrypt-then-MAC")
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
                            if (encryptstatus == 1 && combobox4Text == "Encrypt-then-MAC")
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
                        if (combobox4Text == "Encrypt-then-MAC")
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
                    await main.Dispatcher.InvokeAsync(async() => {
                        if (main.formuc.dfafterencrypted1.IsChecked == true)
                        {
                            if (main.formuc.shredbd.IsChecked == true)
                            {
                               await shredfile(dosyalar);
                            }
                            System.IO.File.Delete(dosyalar);
                        }
                    });
                     
                    }
                }
                catch (Exception ex)
                {
                    nstate = 0;
                    MessageBox.Show("Operation ended with a error, these may cause an error's occure: file dont exists, program haven't access to file, your password is wrong or something else, error = " + ex.Message + " | You can contact programmer, Discord = dr_wellss " + " stacktrace: " + ex.StackTrace, "Multron File Guardian", MessageBoxButton.OK, MessageBoxImage.Error);
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
                    await main.Dispatcher.InvokeAsync(() =>
                    {
                        main.label4.Text = "Operation Done.";
                    });
               
                    await Task.Delay(3500);
                    await main.Dispatcher.InvokeAsync(() =>
                    {

                        if (main.formuc.cmpression1.IsChecked == false || encryptstatus == 1)
                        {
                            main.listBox1.Items.Clear();
                        }
                        if (main.formuc.cmpression1.IsChecked == true && encryptstatus == 2)
                        {
                            if (cmpcontroller() == 1)
                            {
                           
                                    main.panel3.Visibility = Visibility.Visible;
                              
                            }
                            else
                            {
                                main.listBox1.Items.Clear();
                            }
                        }

                    });
                   
                }
                await edcontrols(1);
                await main.Dispatcher.InvokeAsync(() => { main.label4.Text = ""; });

                GC.Collect();
                if (rcm == 1)
                {
                    Environment.Exit(0);
                }
            });
             
        }
        // encryption decryption end
        public async Task edcontrols(byte eod = 0)
        {
          
           await main.Dispatcher.InvokeAsync(() =>
            {
                if (eod == 0)
                {
                    main.rjButton2.IsEnabled = false;
                    main.rjButton3.IsEnabled = false;
                    main.rjButton1.IsEnabled = false;
                    main.rjButton5.IsEnabled = false;
                    main.rjButton4.IsEnabled = false;
                    main.comboBox2.IsEnabled = false;
                    main.comboBox1.IsEnabled = false;
                    main.textBox1.IsEnabled = false;
                    main.comboBox3.IsEnabled = false;
                    main.comboBox4.IsEnabled = false;
                }
                else
                {
                    main.rjButton2.IsEnabled = true;
                    main.rjButton3.IsEnabled = true;
                    main.rjButton1.IsEnabled = true;
                    main.rjButton5.IsEnabled = true;
                    main.rjButton4.IsEnabled = true;
                    if (combobox1Text.Contains("RSA"))
                    {
                        main.comboBox2.IsEnabled = true;
                    }
                    main.comboBox1.IsEnabled = true;
                    main.textBox1.IsEnabled = true;
                    main.comboBox3.IsEnabled = true;
                    main.comboBox4.IsEnabled = true;
                }
            });
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
        public byte cmpcontroller()
        {
            byte iszip = 0;
            foreach (string filex in main.listBox1.Items)
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
  
 
        public async Task shredfile(string fpath)
        {
            await Task.Run(async () =>
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
                        await main.Dispatcher.InvokeAsync(() => { main.label4.Text = "Shredding: " + fname + " | %" + Math.Round(((double)wd / (double)wfc) * 100, 0).ToString(); }); 
                       
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
                    MessageBox.Show("An error occurred in Shredder! Error = " + exc.Message + exc.StackTrace, "Multron File Guardian", MessageBoxButton.OK, MessageBoxImage.Error);


                }
                if (nstate == 1)
                {
                    await main.Dispatcher.InvokeAsync(() => { main.label4.Text = new System.IO.FileInfo(fpath).Name + " Shredded!"; });
                   
                    await Task.Delay(3500);
                }
               await main.Dispatcher.InvokeAsync(() => { main.label4.Text = ""; }); ;
            });
               
          
          
        }
   
       
        public async Task compressionoperationwithzip()
        {
            await Task.Run(async () =>
            {
                short nstate = 0;
                ZipArchive zibb = null;
                Stream sbn = null;
                BinaryReader okur = null;
                BinaryWriter yazar = null;
                string oputzipf = "";
                try
                {
                    if (encryptstatus == 1)
                    {
                        await main.Dispatcher.InvokeAsync(() =>
                        {
                            oputzipf = main.textBox2.Text + "\\" + raes.getrandomstring(10) + ".zip";
                        });

                        zibb = new ZipArchive(File.Open(oputzipf, FileMode.OpenOrCreate), ZipArchiveMode.Create, false);
                        foreach (string fnam in main.listBox1.Items)
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
                                await main.Dispatcher.InvokeAsync(() =>
                                {
                                    main.label4.Text = "Compressing: " + entry + " | %" + Math.Round((((double)okur.BaseStream.Position / (double)fsize) * 100), 0).ToString();
                                });


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
                            await main.Dispatcher.InvokeAsync(async() =>
                            {
                                if (main.formuc.dfafterencrypted1.IsChecked == true)
                                {
                                    if (main.formuc.shredbd.IsChecked == true)
                                    {
                                        await shredfile(fnam);
                                    }
                                    System.IO.File.Delete(fnam);
                                }
                            });
                        }



                        zibb.Dispose();
                        await main.Dispatcher.InvokeAsync(() =>
                        {
                            main.listBox1.Items.Clear();
                            main.listBox1.Items.Add(oputzipf);
                        });

                    }
                    else
                    {
                        foreach (string filepath in cmprsdf)
                        {
                            nstate = 1;
                            string fph = Path.GetDirectoryName(filepath) + "\\" + Path.GetFileNameWithoutExtension(filepath);
                            zibb = new ZipArchive(File.Open(fph, FileMode.Open), ZipArchiveMode.Read, false);
                            string path_file = main.textBox2.Text + "\\";
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
                                    await main.Dispatcher.InvokeAsync(() =>
                                    {
                                        main.label4.Text = "Decompressing: " + zae.Name + " | %" + Math.Round((((double)yazar.BaseStream.Position / (double)fsize) * 100), 0).ToString();
                                    });

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
                            await main.Dispatcher.InvokeAsync(async() =>
                            {
                                if (main.formuc.dfafterencrypted1.IsChecked == true)
                                {
                                    if (main.formuc.shredbd.IsChecked == true)
                                    {
                                        await shredfile(fph);
                                    }
                                    System.IO.File.Delete(fph);
                                }

                            });
                        }


                        await main.Dispatcher.InvokeAsync(() =>
                        {
                            main.listBox1.Items.Clear();
                            cmprsdf.Clear();
                            main.label4.Text = "Operation Done.";

                        });


                        await Task.Delay(3500);
                    }
                }
                catch (Exception ex)
                {
                    nstate = 0;
                    MessageBox.Show("An error occurred in compression/decompression! Error = " + ex.Message + ex.StackTrace, "Multron File Guardian", MessageBoxButton.OK, MessageBoxImage.Error);
                    await edcontrols(1);
                    await main.Dispatcher.InvokeAsync(() => { main.label4.Text = ""; });
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
                if (nstate == 1)
                {
                    await edcontrols(1);
                    await main.Dispatcher.InvokeAsync(() => { main.label4.Text = ""; });
                    rtoperation = 1;
                    rttoperation = 1;
                    if (encryptstatus == 1)
                    {
                        await main.Dispatcher.InvokeAsync(() =>
                        {
                            main.rjButton2.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                        });
                           

                    }
                }
                await main.Dispatcher.InvokeAsync(() =>
                {
                    main.textBox2.Text = "";

                });


            });
               
           
        }
    }
}
