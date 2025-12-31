using MultronFileGuardian;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing.Design;
using System.Drawing.Text;
using System.Linq;
using System.Reflection.Metadata;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Automation.Peers;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;

using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
namespace Multron_File_Guardian
{
    /// <summary>
    /// Interaction logic for Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        public Window2()
        {
            InitializeComponent();
        }
        Processes process;
        Window1 window;
        public short swillbesaved = 0;
        public short firststart = 0;
        public FontFamily mainformff = null;
        public FontFamily mngff = null;
        public FontFamily cintegff = null;
        string mfgalg = AppContext.BaseDirectory + "\\mfgsettings" + "\\algorithm.txt";
        public Window2(Processes process, Window1 window)
        {

            this.process = process;
            this.window = window;
            InitializeComponent();
            
        }

             
        private void savealgorithm0_Click(object sender, EventArgs e)
        {
            swillbesaved = 1;
            if (System.IO.File.Exists(mfgalg))
            {
                System.IO.File.Delete(mfgalg);
            }
        }

       
 

   
 
        public void needsrestart(string change)
        {
            if (MessageBox.Show( "This change (" + change + ") need restart, Do you want to restart Multron File Guardian now?",   "Multron File Guardian",   MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
            {
                System.Diagnostics.Process.Start("cmd.exe", "/c timeout /t 3 /nobreak & start \"\" \"" + Process.GetCurrentProcess().MainModule.FileName + "\"");

                window.Close();
             
            }

        }
   
         
 

        private void iterationaut0_Click(object sender, EventArgs e)
        {
            swillbesaved = 1;
            textBox1.IsEnabled = false;
            rjButton3.IsEnabled = false;
            process.iterationrate = 4;
        }

        private void iterationaut1_Click(object sender, EventArgs e)
        {
            if(iterationshrd1.IsChecked == true)
            {
                textBox1.IsEnabled = true;
                rjButton3.IsEnabled = true;

            } else
            {
                swillbesaved = 1;
                textBox1.IsEnabled = false;
                rjButton3.IsEnabled = false;
                process.iterationrate = 4;
            }
        
        }

    

        private void rjButton3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Textbox shouldn't be empty", "Multron File Guardian", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                if (textBox1.Text[0] != '0')
                {
                    swillbesaved = 1;
                    process.iterationrate = short.Parse(textBox1.Text);
                    MessageBox.Show("Password iteration rate changed.", "Multron File Guardian", MessageBoxButton.OK, MessageBoxImage.Information);

                }

                else
                {
                    MessageBox.Show("Number shouldn't start with 0", "Multron File Guardian", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void InfoButton_Explorer_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show( "This settings let you add program to right-click menu and make program associate with .mfg extension. (This feature requires the program to stay in the same path to work.)",  "Multron File Guardian",  MessageBoxButton.OK,  MessageBoxImage.Information);
        }


        private void label1_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.GetProcessesByName("explorer")[0].Kill();
                System.Threading.Thread.Sleep(4000);
                if (System.Diagnostics.Process.GetProcessesByName("explorer")[0] == null)
                {
                    Process.Start("explorer.exe");
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show("Error: " + exc.Message + "\n" + exc.StackTrace, "Multron File Guardian", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

   

        private void dfafterencrypted0_CheckedChanged(object sender, EventArgs e)
        {
             window.updatelbl();
        }
        private void shredbd_CheckedChanged(object sender, EventArgs e)
        {
            swillbesaved = 1;
             window.updatelbl();
        }

       

        private void rjButton4_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                MessageBox.Show("Textbox shouldn't be empty", "Multron File Guardian", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                if (textBox2.Text[0] != '0')
                {
                    swillbesaved = 1;
                    process.loop = long.Parse(textBox2.Text);
                    MessageBox.Show("Shredder iteration rate changed.", "Multron File Guardian", MessageBoxButton.OK, MessageBoxImage.Information);

                }

                else
                {
                    MessageBox.Show("Number shouldn't start with 0", "Multron File Guardian", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

   

        private void InfoButton_ShredderIteration_Click(object sender)
        {
            MessageBox.Show("You can choose how many times files will be shredded. More iterate rate equal more secure shredder but slower operation, default is 3. Shredder is powered by Multron File Killer.", "Multron File Guardian", MessageBoxButton.OK, MessageBoxImage.Information);
            MessageBox.Show("One-Time Pass | 1-Round Shredding\nQuick | 4-Round Shredding\nStandard | 8-Round Shredding\nStrong | 16-Round Shredding\nExtremely Strong | 20 Or More Round Shredding", "Multron File Guardian", MessageBoxButton.OK, MessageBoxImage.Information);

        }

 

        private void AddToExplorer_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string[] mngregkeys = { ".mng", "mngg\\shell\\open\\command", ".mng\\DefaultIcon", "mngg\\shell\\open", "mngg\\DefaultIcon" };
                string[] regkeys = { ".mfg", "mfgg\\shell\\open\\command", ".mfg\\DefaultIcon", "mfgg\\shell\\open", "mfgg\\DefaultIcon" };
                IWshRuntimeLibrary.WshShortcut scut = new IWshRuntimeLibrary.WshShell().CreateShortcut(Environment.GetFolderPath(Environment.SpecialFolder.SendTo) + "\\Encrypt With Multron File Guardian.lnk");
                scut.TargetPath = Process.GetCurrentProcess().MainModule.FileName;
                scut.IconLocation = Process.GetCurrentProcess().MainModule.FileName;
                scut.WorkingDirectory = AppContext.BaseDirectory;
                scut.Arguments = "-E";
                scut.Save();
                scut = new IWshRuntimeLibrary.WshShell().CreateShortcut(Environment.GetFolderPath(Environment.SpecialFolder.SendTo) + "\\Decrypt With Multron File Guardian.lnk");
                scut.TargetPath = Process.GetCurrentProcess().MainModule.FileName;
                scut.IconLocation = Process.GetCurrentProcess().MainModule.FileName;
                scut.WorkingDirectory = AppContext.BaseDirectory;
                scut.Arguments = "-D";
                scut.Save();
                foreach (string key in regkeys)
                {
                    if (Microsoft.Win32.Registry.ClassesRoot.OpenSubKey(key) == null)
                    {
                        Microsoft.Win32.Registry.ClassesRoot.CreateSubKey(key).Close();
                    }
                }
                Microsoft.Win32.RegistryKey mfgkey = Microsoft.Win32.Registry.ClassesRoot.OpenSubKey(regkeys[2], true);
                mfgkey.SetValue(null, "\"" + AppContext.BaseDirectory + "\\pneeded\\iconmfg.ico" + "\"");
                mfgkey.Close();
                mfgkey = Microsoft.Win32.Registry.ClassesRoot.OpenSubKey(regkeys[0], true);
                mfgkey.SetValue(null, "mfgg");
                mfgkey.Close();
                mfgkey = Microsoft.Win32.Registry.ClassesRoot.OpenSubKey(regkeys[3], true);
                mfgkey.SetValue(null, "Open");
                mfgkey = Microsoft.Win32.Registry.ClassesRoot.OpenSubKey(regkeys[4], true);
                mfgkey.SetValue(null, "\"" + AppContext.BaseDirectory + "\\pneeded\\iconmfg.ico" + "\"");
                mfgkey.Close();
                mfgkey = Microsoft.Win32.Registry.ClassesRoot.OpenSubKey(regkeys[1], true);
                mfgkey.SetValue(null, "\"" + Process.GetCurrentProcess().MainModule.FileName + "\"" + " -D " + "\"" + "%1" + "\"");
                mfgkey.Close();
                foreach (string key in mngregkeys)
                {
                    if (Microsoft.Win32.Registry.ClassesRoot.OpenSubKey(key) == null)
                    {
                        Microsoft.Win32.Registry.ClassesRoot.CreateSubKey(key).Close();
                    }
                }
                Microsoft.Win32.RegistryKey mngkey = Microsoft.Win32.Registry.ClassesRoot.OpenSubKey(mngregkeys[2], true);
                mngkey.SetValue(null, "\"" + AppContext.BaseDirectory + "\\pneeded\\iconmfg.ico" + "\"");
                mngkey.Close();
                mngkey = Microsoft.Win32.Registry.ClassesRoot.OpenSubKey(mngregkeys[0], true);
                mngkey.SetValue(null, "mngg");
                mngkey.Close();
                mngkey = Microsoft.Win32.Registry.ClassesRoot.OpenSubKey(mngregkeys[3], true);
                mngkey.SetValue(null, "Open");
                mngkey = Microsoft.Win32.Registry.ClassesRoot.OpenSubKey(mngregkeys[4], true);
                mngkey.SetValue(null, "\"" + AppContext.BaseDirectory + "\\pneeded\\iconmfg.ico" + "\"");
                mngkey.Close();
                mngkey = Microsoft.Win32.Registry.ClassesRoot.OpenSubKey(mngregkeys[1], true);
                mngkey.SetValue(null, "\"" + Process.GetCurrentProcess().MainModule.FileName + "\"" + " --mng " + "\"" + "%1" + "\"");
                mngkey.Close();
                MessageBox.Show("Succesfully Added or Updated! You can find shortcut from Right-Click SendTo. To make changes applied, restart explorer.exe", "Multron File Guardian", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace, "Multron File Guardian", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void RemoveFromExplorer_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                short nstate = 0;
                string[] files = { Environment.GetFolderPath(Environment.SpecialFolder.SendTo) + "\\Encrypt With Multron File Guardian.lnk", Environment.GetFolderPath(Environment.SpecialFolder.SendTo) + "\\Decrypt With Multron File Guardian.lnk" };
                foreach (string file in files)
                {
                    if (System.IO.File.Exists(file))
                    {
                        System.IO.File.Delete(file);
                        nstate = 1;
                    }
                }
                string[] regkeys = { ".mfg", "mfgg" };
                foreach (string regkey in regkeys)
                {
                    if (Microsoft.Win32.Registry.ClassesRoot.OpenSubKey(regkey) != null)
                    {
                        Microsoft.Win32.Registry.ClassesRoot.DeleteSubKeyTree(regkey);
                        nstate = 1;
                    }
                }
                string[] mngregkeys = { ".mng", "mngg" };
                foreach (string ngregkey in mngregkeys)
                {
                    if (Microsoft.Win32.Registry.ClassesRoot.OpenSubKey(ngregkey) != null)
                    {
                        Microsoft.Win32.Registry.ClassesRoot.DeleteSubKeyTree(ngregkey);
                        nstate = 1;
                    }
                }
                if (nstate == 1)
                {
                    MessageBox.Show("Succesfully Removed! To make changes applied, restart explorer.exe", "Multron File Guardian", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("Remove operation unsuccessful! Files not found", "Multron File Guardian", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace, "Multron File Guardian", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void TitleBar_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }

        private void MinimizeButton_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Hide();
        }
        private void DeleteFileAfter_Changed(object sender, RoutedEventArgs e)
        {
            swillbesaved = 1;
            window.updatelbl();
        }

        private void shredbd_CheckedChanged(object sender, RoutedEventArgs e)
        {
            swillbesaved = 1;
             window.updatelbl();
        }

        private void SaveAlgorithm_Changed(object sender, RoutedEventArgs e)
        {
            swillbesaved = 1;
        }

        private void KeyHoldClose_Changed(object sender, RoutedEventArgs e)
        {
            swillbesaved = 1;
        }

        private void Compression_Changed(object sender, RoutedEventArgs e)
        {
            if(cmpression1.IsChecked == true)
            {
                swillbesaved = 1;
                process.rtoperation = 1;
                process.rttoperation = 0;
                window.updatelbl();
            } else
            {
                swillbesaved = 1;
                window.updatelbl();
            }
         
        }

        private void Theme_Changed(object sender, RoutedEventArgs e)
        {
            swillbesaved = 1;

            var dictionaries = Application.Current.Resources.MergedDictionaries;
             
            for (int i = dictionaries.Count - 1; i >= 0; i--)
            {
                var source = dictionaries[i].Source?.OriginalString;
                if (source != null &&
                    (source.Contains("Dark.xaml") || source.Contains("Light.xaml")))
                {
                    dictionaries.RemoveAt(i);
                }
            }
             
            var theme = new ResourceDictionary();

            if (theme1.IsChecked == true)
            {
                theme.Source = new Uri("pack://application:,,,/Themes/Dark.xaml");
                if (window.process.closedmng == 0)
                {
                    window.forum6.UseImmersiveDarkMode(new WindowInteropHelper(window.forum6).Handle, 1);
                }
            }
            else
            {
                theme.Source = new Uri("pack://application:,,,/Themes/Light.xaml");
                if (window.process.closedmng == 0)
                {
                    window.forum6.UseImmersiveDarkMode(new WindowInteropHelper(window.forum6).Handle, 0);
                }
            }

            dictionaries.Add(theme);
        }


        private void IterationAut_Changed(object sender, RoutedEventArgs e)
        {
            if(iterationaut1.IsChecked == false)
            {
                swillbesaved = 1;
                textBox1.IsEnabled = false;
                rjButton3.IsEnabled = false;
                process.iterationrate = 4;
            } else
            {
                textBox1.IsEnabled = true;
                rjButton3.IsEnabled = true;
            }
               
        }

        private void ArgonMemory_Changed(object sender, RoutedEventArgs e)
        {
            swillbesaved = 1;
        }

    
        private void InfoButton_PasswordIteration_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("This settings let you change how many time your password will be hashed, if you haven't any information about this, dont touch. Recommended iteration rate is between 4 and 15. Default iteration rate is 4", "Multron File Guardian", MessageBoxButton.OK, MessageBoxImage.Information);
        }
        private void RestartExplorer_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                System.Diagnostics.Process.GetProcessesByName("explorer")[0].Kill();
                System.Threading.Thread.Sleep(4000);
                if (System.Diagnostics.Process.GetProcessesByName("explorer")[0] == null)
                {
                    Process.Start("explorer.exe");
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show("Error: " + exc.Message + "\n" + exc.StackTrace, "Multron File Guardian", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void ConfirmSiteration_Click(object sender, RoutedEventArgs e)
        {
            if (textBox2.Text == "")
            {
                MessageBox.Show("Textbox shouldn't be empty", "Multron File Guardian", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                if (textBox2.Text[0] != '0')
                {
                    swillbesaved = 1;
                    process.loop = short.Parse(textBox2.Text);
                    MessageBox.Show("Shredder iteration rate changed.", "Multron File Guardian", MessageBoxButton.OK, MessageBoxImage.Information);

                }

                else
                {
                    MessageBox.Show("Number shouldn't start with 0", "Multron File Guardian", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
        private void ConfirmIteration_Click(object sender, RoutedEventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Textbox shouldn't be empty", "Multron File Guardian", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                if (textBox1.Text[0] != '0')
                {
                    swillbesaved = 1;
                    process.iterationrate = short.Parse(textBox1.Text);
                    MessageBox.Show("Password iteration rate changed.", "Multron File Guardian", MessageBoxButton.OK, MessageBoxImage.Information);

                }

                else
                {
                    MessageBox.Show("Number shouldn't start with 0", "Multron File Guardian", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void ScreenProtection_Changed(object sender, RoutedEventArgs e)
        {
            swillbesaved = 1;
            window.updatelbl();
            if (firststart == 1)
           {
               needsrestart("Screen Protection");
           }
        
      
        }

        private void IterationShrd_Changed(object sender, RoutedEventArgs e)
        {
            if(iterationshrd1.IsChecked == true)
            {
                textBox2.IsEnabled = true;
                rjButton4.IsEnabled = true;
                swillbesaved = 1;
            } else
            {
                swillbesaved = 1;
                textBox2.IsEnabled = false;
                rjButton4.IsEnabled = false;
                process.loop = 3;
            }
           
        }

        private void InfoButton_ScreenProtection_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("This settings is strongly recommended to you to open, as this settings prevent Multron File Guardian (and its tools) from catched in screenshot, it will protect unwanted data leaks (Example: Windows Recall and some virus types). However, this dont provide %100 guarantee protection, always scan your system for viruses.", "Multron File Guardian", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void InfoButton_ShredderIteration_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("You can choose how many times files will be shredded. More iterate rate equal more secure shredder but slower operation, default is 3. Shredder is powered by Multron File Killer.", "Multron File Guardian", MessageBoxButton.OK, MessageBoxImage.Information);
            MessageBox.Show("One-Time Pass | 1-Round Shredding\nQuick | 4-Round Shredding\nStandard | 8-Round Shredding\nStrong | 16-Round Shredding\nExtremely Strong | 20 Or More Round Shredding", "Multron File Guardian", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        public void argmem1_Click(object sender, RoutedEventArgs e)
        {
            swillbesaved = 1;
            process.argmemrate = 1 * 1024 * 256;
        }

        public void argmem2_Click(object sender, RoutedEventArgs e)
        {
            swillbesaved = 1;
            process.argmemrate = 1 * 1024 * 512;
        }

        public void argmem3_Click(object sender, RoutedEventArgs e)
        {
            swillbesaved = 1;
            process.argmemrate = 1 * 1024 * 1024;
        }
        private void textBox2_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (String.IsNullOrWhiteSpace(e.Text) == true)
            {
                e.Handled = true;
            }
            else
            {
                if (!char.IsNumber(e.Text.ToCharArray()[0]))
                {
                    e.Handled = true;
                }
            }
        }

        private void textBox2_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space || e.Key == Key.V)
            {
                e.Handled = true;
            }
        }

        private void textBox1_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (String.IsNullOrWhiteSpace(e.Text) == true)
            {
                e.Handled = true;
            }
            else
            {
                if (!char.IsNumber(e.Text.ToCharArray()[0]))
                {
                    e.Handled = true;
                }
            }
        }

        private void textBox1_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space || e.Key == Key.V)
            {
                e.Handled = true;
            }
        }

        private void InfoButton_showpasswd_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("This setting is not supported in current version.", "Multron File Guardian", MessageBoxButton.OK, MessageBoxImage.Warning);
        }

        public void showpassword1_Click(object sender, RoutedEventArgs e)
        {
            swillbesaved = 1;
            if (showpassword1.IsChecked == false)
            {
                window.textBox1.FontFamily = new FontFamily("file://" + AppContext.BaseDirectory + "/pneeded/#Password");
                window.checkBox1.IsChecked = showpassword1.IsChecked;
                if (mngff != null)
                {
                    window.forum6.textBox2.FontFamily = new FontFamily("file://" + AppContext.BaseDirectory + "/pneeded/#Password");
                    window.forum6.checkBox1.IsChecked = showpassword1.IsChecked;
                }
                if (cintegff != null)
                {
                    window.forum5.textBox1.FontFamily = new FontFamily("file://" + AppContext.BaseDirectory + "/pneeded/#Password");
                    window.forum5.checkBox1.IsChecked = showpassword1.IsChecked;
                }
            }
            else
            {
                window.textBox1.FontFamily = mainformff;
                window.checkBox1.IsChecked = showpassword1.IsChecked;
                if (mngff != null)
                {
                    window.forum6.textBox2.FontFamily = mngff;
                    window.forum6.checkBox1.IsChecked = showpassword1.IsChecked;
                }
                if (cintegff != null)
                {
                    window.forum5.textBox1.FontFamily = cintegff;
                    window.forum5.checkBox1.IsChecked = showpassword1.IsChecked;
                }
            }
        }

        private void rjButtonp3_Click(object sender, RoutedEventArgs e)
        {
            if (textBoxp1.Text == "")
            {
                MessageBox.Show("Textbox shouldn't be empty", "Multron File Guardian", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                if (textBoxp1.Text[0] != '0')
                {
                    swillbesaved = 1;
                    process.iterationrate = short.Parse(textBoxp1.Text);
                    MessageBox.Show("Parallelizm number changed.", "Multron File Guardian", MessageBoxButton.OK, MessageBoxImage.Information);

                }

                else
                {
                    MessageBox.Show("Number shouldn't start with 0", "Multron File Guardian", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void textBoxp1_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space || e.Key == Key.V)
            {
                e.Handled = true;
            }
        }

        private void textBoxp1_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (String.IsNullOrWhiteSpace(e.Text) == true)
            {
                e.Handled = true;
            }
            else
            {
                if (!char.IsNumber(e.Text.ToCharArray()[0]))
                {
                    e.Handled = true;
                }
            }
        }

        private void iterationp1_Checked(object sender, RoutedEventArgs e)
        {
            if (iterationp1.IsChecked == false)
            {
                swillbesaved = 1;
                textBoxp1.IsEnabled = false;
                rjButtonp3.IsEnabled = false;
                process.parallelizm = 1;
            }
            else
            {
                textBoxp1.IsEnabled = true;
                rjButtonp3.IsEnabled = true;
            }
        }

        private void InfoButton_argon2idparl_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("This setting lets you change the Argon2id parallelism parameter, which specifies how many threads are used while processing your password. Do not set any number that's higher than your cpu cores/thread. Do not touch if you have no idea.", "Multron File Guardian", MessageBoxButton.OK, MessageBoxImage.Warning);
        }
    }
}
