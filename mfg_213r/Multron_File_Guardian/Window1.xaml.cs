using Microsoft.Win32;
using Microsoft.WindowsAPICodePack.Dialogs;
using Multron_File_Guardian;
using Org.BouncyCastle.Crypto.Engines;
using Org.BouncyCastle.Tls;
using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.InteropServices;
using System.Runtime.Intrinsics.Arm;
using System.Web.Services.Description;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;

namespace MultronFileGuardian
{
    public partial class Window1 : Window
    {
        public Processes process;
        public mngProcesses mngprocess;
        public Window2 formuc;
        public Window4 formdort;
        public Window6 forum6;
        public Window5 forum5;
        public string[] args;
        Window3 window3;
        public byte dntsave = 0;
        private string followuec = AppContext.BaseDirectory + "\\followuec.smfg";
        public short closedholdkey = 1;
        public short closedrsakgen = 1;
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        private const uint avoidcapture = 0x00000011;
        [DllImport("user32.dll")]
        public static extern uint SetWindowDisplayAffinity(IntPtr hwnd, uint dwAffinity);
        public Window1(string[] args)
        {
      
    

            InitializeComponent();

            process = new Processes(this);

            this.args = args;
        


        }
        private void BuyCoffee_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
            {
                FileName = "https://www.buymeacoffee.com/multron",
                UseShellExecute = true
            });
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (System.IO.File.Exists(followuec) == true)
            {
                MessageBox.Show("Multron File Guardian closed unexpectedly, settings may not be saved. Reason may be Power loss, System crash, Task killed etc. Please clean dump/log files and pagefiles for your security.\n(Multron Win Cleaner Can be used for this)", "Multron File Guardian", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                System.IO.File.Create(followuec).Close();
            }
            formuc = new Window2(process, this);
            formuc.mainformff = textBox1.FontFamily;
            getsettings(sender,e);
         

            sidebarExpanded = !sidebarExpanded;

            if (sidebarExpanded)
            {
                sidebarPanel.Width = 240;
                showSidebarBtn.Visibility = Visibility.Collapsed;
            }
            else
            {
                sidebarPanel.Width = 0;
                showSidebarBtn.Visibility = Visibility.Visible;
            }




            if (args.Length > 0)
            {
                if (args[0] == "-E")
                {
                    process.encryptstatus = 1;
                    process.rcm = 1;
                }
                else if (args[0] == "-D")
                {
                    process.encryptstatus = 2;
                    process.rcm = 1;
                }
                else if (args[0] == "--mng")
                {
                    process.rcm = 1;
                    process.rcmng = 1;
                }
                if (process.rcm == 1)
                {
                    int fs = 1;
                    for (fs = 1; fs < args.Length;)
                    {
                        listBox1.Items.Add(args[fs]);
                        ++fs;
                    }
                }

            }
            if (formuc.savealgorithm1.IsChecked == false)
            {
                comboBox1.SelectedIndex = 0;
                comboBox2.SelectedIndex = 1;
                comboBox4.SelectedIndex = 1;
            }
            if (process.rcm == 1)
            {
                if (process.rcmng == 1)
                {
                    forum6 = new Window6(this);
                    mngprocess = new mngProcesses(this, forum6);
                    forum6.Show();
                    forum6.Hide();
                    process.closedmng = 0;
                }
                forum5 = new Window5(this, mngprocess);
                forum5.Show();
                this.Hide();
            }



            if (formuc.savealgorithm1.IsChecked == false)
            {
                comboBox1.SelectedIndex = 0;
                comboBox2.SelectedIndex = 2;
                comboBox4.SelectedIndex = 1;
            }
            if (formuc.xscapz1.IsChecked == true)
            {
                SetWindowDisplayAffinity(new WindowInteropHelper(this).Handle, avoidcapture);
            }
            updatelbl();


        }
        string GetComboBoxValue(System.Windows.Controls.ComboBox comboBox)
        {
            if (comboBox.SelectedItem is ComboBoxItem cbi)
                return cbi.Content.ToString();
            else if (comboBox.SelectedItem != null)
                return comboBox.SelectedItem.ToString();
            else
                return string.Empty;
        }

        public void updatelbl()
        {
            if(formuc == null)
            {
                return;
            }
            string dfstring = "";
            string cmpstring = "";
            string xcasp = "";
            string shredderstate = "";
            string argonprmtrs = "";
            string argonmem = "";
            string savalg = "";
            if (formuc.dfafterencrypted1.IsChecked == false)
            {
                dfstring = "Off";
                shredderstate = "Off";
            }
            else
            {
                dfstring = "On";
                if ( formuc.shredbd.IsChecked == true)
                {
                    shredderstate = "On | Pass Rate: " + process.loop.ToString() ;
                }
                else
                {
                    shredderstate = "Off";
                }
            }
            if (formuc.argmem1.IsChecked == true)
            {
                argonmem = "256 MB";
            }
            else if (formuc.argmem2.IsChecked == true)
            {
                argonmem = "512 MB";
            }
            else if (formuc.argmem3.IsChecked == true)
            {
                argonmem = "1 GB";
            }
            argonprmtrs = "Argon2id Parameters: Memory: " + argonmem + " | Iteration: " + process.iterationrate.ToString() + " | Parallelism: " + process.parallelizm.ToString();
            if ( formuc.xscapz1.IsChecked == false)
            {
                xcasp = "Off";
            }
            else
            {
                xcasp = "On";
            }
            if (formuc.savealgorithm1.IsChecked == true)
            {
                savalg = "On";
            }
            else
            {
                savalg = "Off";
            }
            if ( formuc.cmpression1.IsChecked == false)
            {
                cmpstring = "Off";
            }
            else
            {
                cmpstring = "On";
            }
            string algo = GetComboBoxValue( comboBox1);
            string rsaLen = GetComboBoxValue( comboBox2);
            string symLen = GetComboBoxValue( comboBox3);
            string auth = GetComboBoxValue( comboBox4);
            currentOptionsPanel.Children.Clear();
            if (algo.Contains("RSA"))
            {
                TextBlock textBlock = new TextBlock
                {
                    Text =
                        $"Algorithm: {algo.Split('-')[0]}\n" +
                        $"Symmetric Key Length: {symLen}\n" +
                        $"RSA Status: On\n" +
                        $"RSA Length: {rsaLen}\n" +
                        $"Delete After Operation: {dfstring} | (Shredder: {shredderstate})\n" +
                        $"Compression: {cmpstring}\n" +
                        $"Auth: {auth}\n" +
                        $"Save Algorithm Settings: {savalg}\n" +
                        $"Screen Protection: {xcasp}\n" + 
                        argonprmtrs,
                    FontSize = 12,
                    Foreground = new SolidColorBrush(Color.FromRgb(0x5B, 0x7C, 0x99)),

                    TextWrapping = TextWrapping.Wrap,
                    Margin = new Thickness(0, 0, 0, 5)
                };

                currentOptionsPanel.Children.Add(textBlock);
            }

            else
            {
                TextBlock textBlock = new TextBlock
                {
                    Text =
                       
                        $"Algorithm: {algo}\n" +
                        $"Symmetric Key Length: {symLen}\n" +
                        $"RSA Status: Off\n" +
                        $"Delete After Operation: {dfstring} | (Shredder: {shredderstate})\n" +
                        $"Compression: {cmpstring}\n" +
                        $"Auth: {auth}\n" +
                        $"Save Algorithm Settings: {savalg}\n" +
                        $"Screen Protection: {xcasp}\n" + 
                        argonprmtrs,
                    FontSize = 12,
                    Foreground = new SolidColorBrush(Color.FromRgb(0x5B, 0x7C, 0x99)),

                    TextWrapping = TextWrapping.Wrap,
                    Margin = new Thickness(0, 0, 0, 5)
                };

                currentOptionsPanel.Children.Add(textBlock);
            }

        }
        public void getsettings(object sender, RoutedEventArgs e)
        {
            formuc.Show();
            if (!System.IO.Directory.Exists(process.mfgsfolder))
            {
                System.IO.Directory.CreateDirectory(process.mfgsfolder);
                formuc.swillbesaved = 0;
                formuc.firststart = 1;
                formuc.Hide();
                return;
            }

            LoadCheckBoxSetting("showpassword1", formuc.showpassword1);
            formuc.showpassword1_Click(sender, e);
            LoadCheckBoxSetting("dfafterencrypted1", formuc.dfafterencrypted1);
            LoadCheckBoxSetting("shredbd",  formuc.shredbd);
            LoadCheckBoxSetting("savealgorithm1", formuc.savealgorithm1);
            LoadCheckBoxSetting("ckh1",  formuc.ckh1);
            LoadCheckBoxSetting("cmpression1",  formuc.cmpression1);
            LoadCheckBoxSetting("theme1", formuc.theme1);
            LoadCheckBoxSetting("iterationaut1",  formuc.iterationaut1);
            LoadCheckBoxSetting("xscapz1",  formuc.xscapz1);
            LoadCheckBoxSetting("iterationshrd1",  formuc.iterationshrd1);
            LoadCheckBoxSetting("iterationp1", formuc.iterationp1);
            string argMemFile = System.IO.Path.Combine(process.mfgsfolder, "argmem.txt");
            if (System.IO.File.Exists(argMemFile))
            {
                string value = System.IO.File.ReadAllText(argMemFile);
                if (!string.IsNullOrEmpty(value))
                {
                    if (value[0] == '1')
                    {
                        formuc.argmem1.IsChecked = true;
                        formuc.argmem1_Click(sender, e);
                    }
                    else if (value[0] == '2')
                    {
                        formuc.argmem2.IsChecked = true;
                        formuc.argmem2_Click(sender, e);
                    }
                    else if (value[0] == '3')
                    {
                        formuc.argmem3.IsChecked = true;
                        formuc.argmem3_Click(sender, e);
                    }
                }
            }
            else
            {
                System.IO.File.Create(argMemFile).Close();
            }


            if (formuc.savealgorithm1.IsChecked == true)
            {
                LoadComboBoxSetting(process.mfgalg,  comboBox1, "AES");
                LoadComboBoxSetting(process.mfgalgr,  comboBox2, "3072");
                LoadComboBoxSetting(process.mfgcm,  comboBox4, "Encrypt-then-MAC");
                LoadComboBoxSetting(process.mfgksize,  comboBox3, null);
            }

            if (formuc.iterationaut1.IsChecked == true)
            {
                if (System.IO.File.Exists(process.mfgiterate))
                {
                    string iterat = System.IO.File.ReadAllText(process.mfgiterate);
                    if (iterat.Length >  2)
                    {
                        formuc.textBox1.Text = process.iterationrate.ToString();
                    }
                    else
                    {
                         formuc.textBox1.Text = iterat;
                         process.iterationrate = short.Parse(iterat);
                    }
                }
            }

            if ( formuc.iterationshrd1.IsChecked == true)
            {
                if (System.IO.File.Exists(process.mfgsiterate))
                {
                    string iterat = System.IO.File.ReadAllText(process.mfgsiterate);
                    if (iterat.Length > 2)
                    {
                        formuc.textBox2.Text = process.loop.ToString();
                    }
                    else
                    {
                        formuc.textBox2.Text = iterat;
                        process.loop = short.Parse(iterat);
                    }
                }
            }
            if (formuc.iterationp1.IsChecked == true)
            {
                if (System.IO.File.Exists(process.mfgparalnumb))
                {
                    string iterat = System.IO.File.ReadAllText(process.mfgparalnumb);
                    if (iterat.Length > 2)
                    {
                        formuc.textBoxp1.Text = process.parallelizm.ToString();
                    }
                    else
                    {
                        formuc.textBoxp1.Text = iterat;
                        process.parallelizm = int.Parse(iterat);
                    }
                }
            }
            formuc.swillbesaved = 0;
            formuc.firststart = 1;
            formuc.Hide();

        }
        private void LoadCheckBoxSetting(string name, System.Windows.Controls.CheckBox checkBox)
        {
            string filePath = System.IO.Path.Combine(process.mfgsfolder, name + ".txt");
            if (System.IO.File.Exists(filePath))
            {
                string value = System.IO.File.ReadAllText(filePath);
                if (!string.IsNullOrEmpty(value))
                {
                    checkBox.IsChecked = (value[0] == '1');
                }
            }
            else
            {
                System.IO.File.Create(filePath).Close();
            }
        }

        private void LoadComboBoxSetting(string filePath, System.Windows.Controls.ComboBox comboBox, string defaultValue)
        {
            string valueToSelect = defaultValue;

            if (System.IO.File.Exists(filePath))
            {
                valueToSelect = System.IO.File.ReadAllText(filePath);
            }

            if (string.IsNullOrEmpty(valueToSelect)) return;

            bool found = false;

            foreach (var item in comboBox.Items)
            {
                if (item is ComboBoxItem cbi && cbi.Content.ToString() == valueToSelect)
                {
                    comboBox.SelectedItem = cbi;
                    found = true;
                    break;
                }
                else if (item is string s && s == valueToSelect)
                {
                    comboBox.SelectedItem = s;
                    found = true;
                    break;
                }
            }


        }
        private void ComboBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        { 
           
            if(formuc == null)
            {
                return;
            }
       
            ComboBoxItem selectedItem = comboBox1.SelectedItem as ComboBoxItem;
            if (selectedItem == null) return;

            string selectedText = selectedItem.Content?.ToString();
            if (string.IsNullOrEmpty(selectedText)) return;
             
            comboBox2.IsEnabled = selectedText.Contains("RSA", StringComparison.OrdinalIgnoreCase);
            if(comboBox2.IsEnabled)
            {
                textBox1.Height = 200;
                textBox1.TextWrapping = TextWrapping.Wrap;
                textBox1.AcceptsReturn = true;
                Algorithm.Text = "ASYMMETRIC";
            } else
            {
                textBox1.Height = 40;
                textBox1.TextWrapping = TextWrapping.NoWrap;
                textBox1.AcceptsReturn = false;
                Algorithm.Text = "SYMMETRIC";
            }
            if (formuc?.savealgorithm1?.IsChecked == true)
            {
                formuc.swillbesaved = 1;
            }
             
            comboBox3.Items.Clear();

            string[] keySizes = GetKeySizesForAlgorithm(selectedText);

            foreach (var size in keySizes)
            {
                comboBox3.Items.Add(new ComboBoxItem { Content = size });
            }
             
            if (comboBox3.Items.Count > 0)
            {
                comboBox3.SelectedIndex = comboBox3.Items.Count - 1;
            }
             
            updatelbl();
        }

        public string[] GetKeySizesForAlgorithm(string algorithm)
        {
            if (string.IsNullOrEmpty(algorithm))
                return Array.Empty<string>();
             
            algorithm = algorithm.ToUpperInvariant();

            return algorithm switch
            {
                var s when s.Contains("AES") => new[] { "128", "192", "256" },
                var s when s.Contains("SERPENT") => new[] { "128", "192", "256" },
                var s when s.Contains("TWOFISH") => new[] { "128", "192", "256" },
                var s when s.Contains("CAMELLIA") => new[] { "128", "192", "256" },
                var s when s.Contains("THREEFISH") => new[] { "256", "512", "1024" },
                var s when s.Contains("CHACHA20") => new[] { "256" },
                var s when s.Contains("HC") => new[] { "128", "256" },
                var s when s.Contains("SM4") => new[] { "128" },
                _ => Array.Empty<string>()
            };
        }

        private void ComboBox2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (formuc == null)
            {
                return;
            }
        

         
            if (formuc?.savealgorithm1?.IsChecked == true)
            {
                formuc.swillbesaved = 1;
            } 
            ComboBoxItem selectedItem = comboBox2.SelectedItem as ComboBoxItem;
            if (selectedItem != null)
            {
                string selected = selectedItem.Content?.ToString();
                if (!string.IsNullOrEmpty(selected) && int.TryParse(selected, out int keySize))
                {
                    if (process != null)
                    {
                        process.keysize = keySize;
                    }
                }
            } 
            updatelbl();
        }

        private void ComboBox3_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            if (formuc == null)
            {
                return;
            }
       
             
            ComboBoxItem selectedItem = comboBox3.SelectedItem as ComboBoxItem;
            if (selectedItem != null)
            {
                string selected = selectedItem.Content?.ToString();
                if (!string.IsNullOrEmpty(selected) && int.TryParse(selected, out int symKeySize))
                {
                    if (process != null)
                    {
                        process.symkeysize = symKeySize;
                    }
                }
            }
             
            if (formuc?.savealgorithm1?.IsChecked == true)
            {
                formuc.swillbesaved = 1;
            }
             
            updatelbl();
        }

        private void ComboBox4_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (formuc == null)
            {
                return;
            }
             
       
             
            if (formuc?.savealgorithm1?.IsChecked == true)
            {
                formuc.swillbesaved = 1;
            }
         
             
             updatelbl();
        }


 
        public void rjButton2_Click(object sender, EventArgs e)
        {
            
        }
        private void panel2_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left) DragMove();
        }

        private void rjButton8_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }
        private void On_Closing(object sender, CancelEventArgs e)
        {
            if (dntsave == 0)
            {
                if (formuc.swillbesaved == 1)
                {
                    process.savesettings();
                }
                if (forum6 != null)
                {
                    forum6.Close();
                }
            }
            System.IO.File.Delete(followuec);
            Environment.Exit(0);

        }
        private void rjButton7_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        
        }
        public void removemngclass()
        {
            mngprocess = null;
            GC.Collect();
        }
        private async void rjButton2_Click(object sender, RoutedEventArgs e)
        {

            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("You need to enter a key.", "Multron File Guardian", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            await process.getcomboboxtextsasync();
            string key = textBox1.Text;
             
            if (formuc.cmpression1.IsChecked == true)
            {
                if (process.rttoperation == 0)
                {
                    process.rtoperation = 0;
                    process.encryptstatus = 1;
                    panel3.Visibility = Visibility.Visible;
                }
                else
                {
                    process.rttoperation = 0;
                }
            }

            if (process.rtoperation == 1)
            {
                process.encryptstatus = 1;
                 
                await process.edcontrols(0);

                Func<Task>? operation = process.combobox1Text switch
                {
                    "AES" => async () => await Task.Run(() => process.aesprocesses(key)),
                    "ChaCha20-RSA Hybrid Algorithm" => async () => await Task.Run(() => process.strcphrsaprocesses(key, new ChaCha7539Engine(), 12)),
                    "HC-RSA Hybrid Algorithm" => async () => await Task.Run(() =>
                    {
                        if (process.combobox3Text == "128")
                            process.strcphrsaprocesses(key, new HC128Engine(), 16);
                        else
                            process.strcphrsaprocesses(key, new HC256Engine(), 32);
                    }),
                    "ChaCha20" => async () => await Task.Run(() => process.strcphprocesses(key, new ChaCha7539Engine(), 12)),
                    "HC" => async () => await Task.Run(() =>
                    {
                        if (process.combobox3Text == "128")
                            process.strcphprocesses(key, new HC128Engine(), 16);
                        else
                            process.strcphprocesses(key, new HC256Engine(), 32);
                    }),
                    "AES-RSA Hybrid Algorithm" => async () => await Task.Run(() => process.aesrsaprocesses(key)),
                    "Serpent" => async () => await Task.Run(() => process.ciphersprocesses(key, new SerpentEngine())),
                    "Serpent-RSA Hybrid Algorithm" => async () => await Task.Run(() => process.bciphersrsaprocesses(key, new SerpentEngine())),
                    "Twofish" => async () => await Task.Run(() => process.ciphersprocesses(key, new TwofishEngine())),
                    "Camellia" => async () => await Task.Run(() => process.ciphersprocesses(key, new CamelliaEngine())),
                    "SM4" => async () => await Task.Run(() => process.ciphersprocesses(key, new SM4Engine())),
                    "SM4-RSA Hybrid Algorithm" => async () => await Task.Run(() => process.bciphersrsaprocesses(key, new SM4Engine())),
                    "Camellia-RSA Hybrid Algorithm" => async () => await Task.Run(() => process.bciphersrsaprocesses(key, new CamelliaEngine())),
                    "ThreeFish" => async () => await Task.Run(() => process.ciphersprocesses(key, new ThreefishEngine(process.symkeysize), (short)(process.symkeysize / 8))),
                    "ThreeFish-RSA Hybrid Algorithm" => async () => await Task.Run(() => process.bciphersrsaprocesses(key, new ThreefishEngine(process.symkeysize), (short)(process.symkeysize / 8))),
                    "Twofish-RSA Hybrid Algorithm" => async () => await Task.Run(() => process.bciphersrsaprocesses(key, new TwofishEngine())),
                    _ => null
                };

                if (operation != null)
                {
                    try
                    {
                        await operation();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error: {ex.Message + " " + ex.StackTrace}", "Multron File Guardian", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    finally
                    {
                      
                        await process.edcontrols(1);
                    }
                }
            }
        }

        private async void rjButton1_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("You need to enter a key.", "Multron File Guardian", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            await process.getcomboboxtextsasync();
            string key = textBox1.Text;
            process.encryptstatus = 2;
             
            await process.edcontrols(0);

            Func<Task>? operation = comboBox1.Text switch
            {
                "AES" => async () => await Task.Run(() => process.aesprocesses(key)),
                "ChaCha20" => async () => await Task.Run(() => process.strcphprocesses(key, new ChaCha7539Engine(), 12)),
                "HC" => async () => await Task.Run(() =>
                {
                    if (process.combobox3Text == "128")
                        process.strcphprocesses(key, new HC128Engine(), 16);
                    else
                        process.strcphprocesses(key, new HC256Engine(), 32);
                }),
                "ChaCha20-RSA Hybrid Algorithm" => async () => await Task.Run(() => process.strcphrsaprocesses(key, new ChaCha7539Engine(), 12)),
                "HC-RSA Hybrid Algorithm" => async () => await Task.Run(() =>
                {
                    if (process.combobox3Text == "128")
                        process.strcphrsaprocesses(key, new HC128Engine(), 16);
                    else
                        process.strcphrsaprocesses(key, new HC256Engine(), 32);
                }),
                "AES-RSA Hybrid Algorithm" => async () => await Task.Run(() => process.aesrsaprocesses(key)),
                "Serpent" => async () => await Task.Run(() => process.ciphersprocesses(key, new SerpentEngine())),
                "Serpent-RSA Hybrid Algorithm" => async () => await Task.Run(() => process.bciphersrsaprocesses(key, new SerpentEngine())),
                "Twofish" => async () => await Task.Run(() => process.ciphersprocesses(key, new TwofishEngine())),
                "Camellia" => async () => await Task.Run(() => process.ciphersprocesses(key, new CamelliaEngine())),
                "SM4" => async () => await Task.Run(() => process.ciphersprocesses(key, new SM4Engine())),
                "SM4-RSA Hybrid Algorithm" => async () => await Task.Run(() => process.bciphersrsaprocesses(key, new SM4Engine())),
                "Camellia-RSA Hybrid Algorithm" => async () => await Task.Run(() => process.bciphersrsaprocesses(key, new CamelliaEngine())),
                "ThreeFish" => async () => await Task.Run(() => process.ciphersprocesses(key, new ThreefishEngine(process.symkeysize), (short)(process.symkeysize / 8))),
                "ThreeFish-RSA Hybrid Algorithm" => async () => await Task.Run(() => process.bciphersrsaprocesses(key, new ThreefishEngine(process.symkeysize), (short)(process.symkeysize / 8))),
                "Twofish-RSA Hybrid Algorithm" => async () => await Task.Run(() => process.bciphersrsaprocesses(key, new TwofishEngine())),
                _ => null
            };

            if (operation != null)
            {
                try
                {
                    await operation();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}", "Multron File Guardian", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                finally
                {
                   
                    await process.edcontrols(1);
                }
            }
        }

        private void rjButton3_Click(object sender, RoutedEventArgs e)
        {
            double maxWidth = 0;

            bool ctrl = Keyboard.IsKeyDown(Key.LeftCtrl) || Keyboard.IsKeyDown(Key.RightCtrl);
            bool shift = Keyboard.IsKeyDown(Key.LeftShift) || Keyboard.IsKeyDown(Key.RightShift);

            if (ctrl)
            { 
                var folderDialog = new Microsoft.WindowsAPICodePack.Dialogs.CommonOpenFileDialog
                {
                    IsFolderPicker = true
                };

                if (folderDialog.ShowDialog() == Microsoft.WindowsAPICodePack.Dialogs.CommonFileDialogResult.Ok)
                {
                    string selectedFolder = folderDialog.FileName;

                    if (shift)
                    { 
                        var directories = new List<string> { selectedFolder };
                        int index = 0;

                        while (index < directories.Count)
                        {
                            string currentDir = directories[index];
                            string[] subDirs = Directory.GetDirectories(currentDir);
                            if (subDirs.Length > 0)
                                directories.AddRange(subDirs);

                            foreach (var file in Directory.GetFiles(currentDir))
                            {
                                listBox1.Items.Add(file);
                          
                            }

                            index++;
                        }
                    }
                    else
                    {
                     
                        foreach (var file in Directory.GetFiles(selectedFolder))
                        {
                            listBox1.Items.Add(file);
                           
                        }
                    }
                }
            }
            else
            {
                
                var openFileDialog = new Microsoft.Win32.OpenFileDialog
                {
                    Multiselect = true
                };

                if (openFileDialog.ShowDialog() == true)
                {
                    foreach (var file in openFileDialog.FileNames)
                    {
                        listBox1.Items.Add(file);
                     
                    }
                }
            }

        
        }

        private void listBox1_Drop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                foreach (string f in (string[])e.Data.GetData(DataFormats.FileDrop))
                    listBox1.Items.Add(f);
            }
        }

        private void listBox1_DragEnter(object sender, DragEventArgs e)
        {
            e.Effects = DragDropEffects.Copy;
        }

        private void rjButton5_Click(object sender, RoutedEventArgs e)
        {
            listBox1.Items.Clear();
        }

        private void rjButton4_Click(object sender, RoutedEventArgs e)
        {
            if (listBox1.SelectedItem != null)
                listBox1.Items.Remove(listBox1.SelectedItem);
        }

        private void label10_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("This Software is made by Ceasar128\nYour Files/Datas will not be collected for anything, And it's %100 free and open-source.\nDo you want to copy Github page of programmer?", "Multron File Guardian", MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
            {
                Clipboard.SetText("https://github.com/Ceasar128");
                MessageBox.Show("Copied successfully!", "Multron File Guardian", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void label14_Click(object sender, RoutedEventArgs e)
        {
            if (process.closedmng == 1)
            {
                forum6 = new Window6(this);
                mngprocess = new mngProcesses(this, forum6);
                process.closedmng = 0;
            }
            forum6.Show();
            forum6.WindowState = WindowState.Normal;
            forum6.Activate();
        }
        private void label17_Click(object sender, RoutedEventArgs e)
        {
            formuc.Show();
            formuc.WindowState = WindowState.Normal;
            formuc.Activate();
        }
        public void label6_Click(object sender, RoutedEventArgs e)
        {
            if (closedholdkey == 1)
            {
                formdort = new Window4(this);
                closedholdkey = 0;
            }
            formdort.Show();
            formdort.WindowState = WindowState.Normal;
            formdort.Activate();
        }

        private void label13_Click(object sender, RoutedEventArgs e)
        {
            algorithmSettingsPanel.Visibility = Visibility.Visible;
        }
     
        public void label11_Click(object sender, RoutedEventArgs e)
        {
            if (closedrsakgen == 1)
            {
                window3 = new Window3(formuc, this);
                closedrsakgen = 0;
            }
            window3.Show();
            window3.WindowState = WindowState.Normal;
            window3.Activate();
        }

        private void linkLabel4_LinkClicked(object sender, MouseButtonEventArgs e)
        {
            
        }




        private void linkLabel1_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("These algorithms are encryption algorithms, Your choices, If you have no idea, use AES or AES-RSA (In case you will use hybrid algorithm)", "Multron File Guardian", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void linkLabel3_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("This option offer you select symmetric-algorithm key size, If you have no idea, Select biggest key length.", "Multron File Guardian", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void linkLabel5_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("This option offer you to encrypt with auth or without, Encrypt-then-MAC Strongly Recommended against some serious potential risks. Use Encrypt-then-MAC if you have no idea.", "Multron File Guardian", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void linkLabel2_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("These are RSA Key Lengths, RSA's security increasing as its key size increased, but it also get slower, If you've no idea what to close, 3072 Key Length is best at balance of Security and Speed. 16384 Key Length is the slowest key length", "Multron File Guardian", MessageBoxButton.OK, MessageBoxImage.Information);
        }


    
        private void rjButton10_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new CommonOpenFileDialog();
            dialog.IsFolderPicker = true;

            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                textBox2.Text = dialog.FileName;
            }
        }

        private async void rjButton11_Click(object sender, RoutedEventArgs e)
        {
            if (Directory.Exists(textBox2.Text))
            {
                panel3.Visibility = Visibility.Collapsed;
                await process.edcontrols(0);

                await Task.Run(() => process.compressionoperationwithzip());
            }
            else
            {
                MessageBox.Show("Cant find the path!", "Multron File Guardian", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void rjButton12_Click(object sender, RoutedEventArgs e)
        {
            panel3.Visibility = Visibility.Collapsed;
            process.cmprsdf.Clear();
            process.rtoperation = 1;
            process.rttoperation = 0;
            listBox1.Items.Clear();
            textBox1.Text = "";
        }

        private void rjButton9_Click(object sender, RoutedEventArgs e)
        {

        }

        private bool sidebarExpanded = true;

        private void ToggleSidebar_Click(object sender, RoutedEventArgs e)
        {
            sidebarExpanded = !sidebarExpanded;

            if (sidebarExpanded)
            {
                sidebarPanel.Width = 240;
                showSidebarBtn.Visibility = Visibility.Collapsed;
            }
            else
            {
                sidebarPanel.Width = 0;
                showSidebarBtn.Visibility = Visibility.Visible;
            }
        }

    
    
   
        private void CloseAlgorithmSettings_Click(object sender, RoutedEventArgs e)
        {
            algorithmSettingsPanel.Visibility = Visibility.Collapsed;
        }
         
        private void algorithmSettingsPanel_MouseDown(object sender, MouseButtonEventArgs e)
        {
            algorithmSettingsPanel.Visibility = Visibility.Collapsed;
         
        }

        private void Window_ContentRendered(object sender, EventArgs e)
        {

        }

        private void checkBox1_Click(object sender, RoutedEventArgs e)
        {
            formuc.showpassword1.IsChecked = checkBox1.IsChecked;
            formuc.showpassword1_Click(sender, e);
        }
    }
}
