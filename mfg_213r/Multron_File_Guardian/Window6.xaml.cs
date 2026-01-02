using Microsoft.Win32;
using MultronFileGuardian;
using Org.BouncyCastle.Crypto.Engines;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
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
    /// Interaction logic for Window6.xaml
    /// </summary>
    public partial class Window6 : Window
    {
        
        Window1 formbir;
        private const uint avoidcaxptures = 0x00000011;
        public Window6(Window1 formbir)
        {

            this.formbir = formbir;
            InitializeComponent();
   
           

        }

        [DllImport("user32.dll")]
        public static extern uint SetWindowDisplayAffinity(IntPtr hwnd, uint dwAffinity);
        [DllImport("dwmapi.dll")]
        private static extern int DwmSetWindowAttribute(IntPtr hwnd, int attr, ref int attrValue, int attrSize);

        public bool UseImmersiveDarkMode(IntPtr handle, int y = 1)
        {
            int val = 20;
            return DwmSetWindowAttribute(handle, val, ref y, sizeof(int)) == 0;
        }

        public void UpdateKeyLengthMenu(string[] keyLengths)
        { 
            symmetricKeyLengthToolStripMenuItem.Items.Clear();
             
            foreach (string keyLength in keyLengths)
            {
                MenuItem menuItem = new MenuItem();
                menuItem.Header = keyLength + " bit";
                menuItem.Tag = keyLength;
                menuItem.Click += KeyLengthMenuItem_Click;
                 
                if (keyLength == formbir.mngprocess.selectedkeylength)
                {
                    menuItem.IsChecked = true;
                } else
                {
                    menuItem.IsChecked = false;
                }

                    symmetricKeyLengthToolStripMenuItem.Items.Add(menuItem);
            }
        }

        private void KeyLengthMenuItem_Click(object sender, RoutedEventArgs e)
        {
            if (sender is MenuItem clickedItem)
            { 
                formbir.mngprocess.selectedkeylength = clickedItem.Tag.ToString();
                 
                foreach (MenuItem item in symmetricKeyLengthToolStripMenuItem.Items)
                {
                    item.IsChecked = false;
                }
                 
                clickedItem.IsChecked = true;
            }
        }

        private void setTargetFileToolStripMenuItem_Click(object sender, RoutedEventArgs e)
        {
            var saveFileDialog = new Microsoft.Win32.SaveFileDialog
            {
                Filter = "Text Files|*.txt|All Files|*.*",
                Title = "Save File"
            };
            saveFileDialog.CheckFileExists = false;
            saveFileDialog.OverwritePrompt = false;
            bool? result = saveFileDialog.ShowDialog();
            if (result == true)
            {
                formbir.mngprocess.filepathh = saveFileDialog.FileName;
                formbir.mngprocess.stfsens = 1;
            }
        }

        private void resetTargetFileToolStripMenuItem_Click(object sender, RoutedEventArgs e)
        {
            formbir.mngprocess.filepathh = "";
        }

        private void showTargetFileToolStripMenuItem_Click(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrWhiteSpace(formbir.mngprocess.filepathh) != true)
            {
                MessageBox.Show(formbir.mngprocess.filepathh, "Multron NoteGuard", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Target file is not set", "Multron NoteGuard", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void symmetricKeyLengthToolStripMenuItem_Click(object sender, RoutedEventArgs e)
        {
            // Symmetric Key Length 
        }

        private void tosavencrypttWhileSavingToolStripMenuItem_Click(object sender, RoutedEventArgs e)
        {
            formbir.mngprocess.swillsaved = 1;
            formbir.mngprocess.encrypt = tosavencrypttWhileSavingToolStripMenuItem.IsChecked;
        }

        private void tosavencryptthenMACToolStripMenuItem_Click(object sender, RoutedEventArgs e)
        {
            formbir.mngprocess.swillsaved = 1;
        }

        private void changeFontToolStripMenuItem_Click(object sender, RoutedEventArgs e)
        {
            var fontDialog = new System.Windows.Forms.FontDialog();
            if (fontDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                
                textBox1.FontFamily = new System.Windows.Media.FontFamily(fontDialog.Font.Name);
                textBox1.FontSize = fontDialog.Font.Size * 96.0 / 72.0; 
                textBox1.FontWeight = fontDialog.Font.Bold ? FontWeights.Bold : FontWeights.Regular;
                textBox1.FontStyle = fontDialog.Font.Italic ? FontStyles.Italic : FontStyles.Normal;
                textBox1.TextDecorations = fontDialog.Font.Underline ? System.Windows.TextDecorations.Underline : null;
                formbir.mngprocess.swillsaved = 1;
            }
        }
 
        private void toolStripButton1_Click(object sender, RoutedEventArgs e)
        {
            var openFileDialog = new OpenFileDialog
            {
                Filter = "All Files|*.*|Multron NoteGuard Files|*.mng",
                Title = "Open File"
            };

            bool? result = openFileDialog.ShowDialog();

            if (result == true)
            {
                try
                {
                    string selectedFile = openFileDialog.FileName;

                    if (selectedFile.EndsWith(".mng") == true)
                    {

                        formbir.mngprocess.readfwithsalgorithmm(selectedFile);
                    }
                    else
                    {
                        textBox1.Text = System.IO.File.ReadAllText(selectedFile);
                        formbir.mngprocess.filepathh = selectedFile;
                        formbir.mngprocess.stfsens = 0;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        "Operation ended with an error. Possible causes: file may not be a text file, program does not have access, wrong password, or other reasons.\n\n" +
                        $"Error = {ex.Message}\n{ex.StackTrace}",
                        "Multron NoteGuard",
                        MessageBoxButton.OK,
                        MessageBoxImage.Error
                    );

                    formbir.mngprocess.filepathh = "";
                }
            }
        }
         
        private void toolStripButton2_Click(object sender, RoutedEventArgs e)
        {
            byte checkfs = 0;

            if (!string.IsNullOrEmpty(formbir.mngprocess.filepathh))
            {
                if (formbir.mngprocess.stfsens == 0)
                {
                    if (File.Exists(formbir.mngprocess.filepathh))
                    {
                        checkfs = 1;
                    }
                    else
                    {
                        var saveFileDialog = new Microsoft.Win32.SaveFileDialog
                        {
                            Filter = "Text Files|*.txt|All Files|*.*",
                            Title = "Save File"
                        };

                        bool? result = saveFileDialog.ShowDialog();
                        if (result == true)
                        {
                            formbir.mngprocess.filepathh = saveFileDialog.FileName;
                            checkfs = 1;
                        }
                    }
                }
                else
                {
                    checkfs = 1;
                    formbir.mngprocess.stfsens = 0;
                }
            }
            else
            {
                var saveFileDialog = new Microsoft.Win32.SaveFileDialog
                {
                    Filter = "Text Files|*.txt|All Files|*.*",
                    Title = "Save File"
                };

                bool? result = saveFileDialog.ShowDialog();
                if (result == true)
                {
                    formbir.mngprocess.filepathh = saveFileDialog.FileName;
                    checkfs = 1;
                }
            }

            if (checkfs == 1)
            {
                if (tosavencrypttWhileSavingToolStripMenuItem.IsChecked == true)
                {
                    if (!string.IsNullOrEmpty(textBox2.Text))
                    {
                        byte[] data = System.Text.Encoding.UTF8.GetBytes(textBox1.Text);
                        string key = textBox2.Text;

                        switch (formbir.mngprocess.selectedalgorithm)
                        {
                            case "AES":
                                new System.Threading.Thread(() => formbir.mngprocess.aesoperations(key, formbir.mngprocess.filepathh, 1, data)).Start();
                                break;
                            case "Serpent":
                                new System.Threading.Thread(() => formbir.mngprocess.ciphersoperations(key, new SerpentEngine(), formbir.mngprocess.filepathh, 1, data)).Start();
                                break;
                            case "Camellia":
                                new System.Threading.Thread(() => formbir.mngprocess.ciphersoperations(key, new CamelliaEngine(), formbir.mngprocess.filepathh, 1, data)).Start();
                                break;
                            case "Twofish":
                                new System.Threading.Thread(() => formbir.mngprocess.ciphersoperations(key, new TwofishEngine(), formbir.mngprocess.filepathh, 1, data)).Start();
                                break;
                            case "SM4":
                                new System.Threading.Thread(() => formbir.mngprocess.ciphersoperations(key, new SM4Engine(), formbir.mngprocess.filepathh, 1, data)).Start();
                                break;
                            case "ThreeFish":
                                new System.Threading.Thread(() => formbir.mngprocess.ciphersoperations(key, new ThreefishEngine(formbir.mngprocess.keysize), formbir.mngprocess.filepathh, 1, data, (short)(formbir.mngprocess.keysize / 8))).Start();
                                break;
                            case "ChaCha20":
                                new System.Threading.Thread(() => formbir.mngprocess.strcphoperations(key, new ChaCha7539Engine(), 12, formbir.mngprocess.filepathh, 1, data)).Start();
                                break;
                            case "HC":
                                if (formbir.mngprocess.selectedkeylength == "128")
                                    new System.Threading.Thread(() => formbir.mngprocess.strcphoperations(key, new HC128Engine(), 16, formbir.mngprocess.filepathh, 1, data)).Start();
                                else
                                    new System.Threading.Thread(() => formbir.mngprocess.strcphoperations(key, new HC256Engine(), 32, formbir.mngprocess.filepathh, 1, data)).Start();
                                break;
                        }
                    }
                    else
                    {
                        System.Windows.MessageBox.Show("You need to enter a key.", "Multron NoteGuard", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
                    }
                }
                else
                {
                    if (!formbir.mngprocess.filepathh.EndsWith(".txt", StringComparison.OrdinalIgnoreCase))
                    {
                        if (File.Exists(formbir.mngprocess.filepathh))
                        {
                            string newPath = System.IO.Path.Combine(new FileInfo(formbir.mngprocess.filepathh).Directory.FullName, System.IO.Path.GetFileName(formbir.mngprocess.filepathh) + ".txt");
                            File.Move(formbir.mngprocess.filepathh, newPath);
                            formbir.mngprocess.filepathh = newPath;
                        }
                        else
                        {
                            formbir.mngprocess.filepathh += ".txt";
                        }
                    }

                    System.IO.File.WriteAllText(formbir.mngprocess.filepathh, textBox1.Text);

                    if (System.IO.Path.GetExtension(formbir.mngprocess.filepathh).Equals(".mng", StringComparison.OrdinalIgnoreCase))
                    {
                        string newPath = System.IO.Path.Combine(new FileInfo(formbir.mngprocess.filepathh).Directory.FullName, System.IO.Path.GetFileNameWithoutExtension(formbir.mngprocess.filepathh));
                        System.IO.File.Move(formbir.mngprocess.filepathh, newPath);
                        formbir.mngprocess.filepathh = newPath;
                    }
                }
            }
            }

        private void toolStripButton3_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Multron NoteGuard is a notepad program that has encrypt feature, you can easily open your encrypted note without writing to disk.", "Multron NoteGuard", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void toolStripButton4_Click(object sender, RoutedEventArgs e)
        {
            textBox1.Text = "";
            formbir.mngprocess.filepathh = "";
            formbir.mngprocess.stfsens = 0;
        }
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (formbir.mngprocess.swillsaved == 1)
            {
                formbir.mngprocess.savesttngs();
            }
            formbir.process.closedmng = 1;
            if (formbir.process.rcmng == 1)
            {
                formbir.Close();
            } 
            else
            {
                formbir.removemngclass();
            }
            formbir.formuc.mngff = null;
        }

        private void textBox2_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            formbir.mngprocess.s = sender;
            formbir.mngprocess.esa = e;
            formbir.formuc.mngff = textBox2.FontFamily;
            formbir.formuc.showpassword1_Click(sender, e);
            if (formbir.formuc.theme1.IsChecked == true)
            {
                UseImmersiveDarkMode(new WindowInteropHelper(this).Handle);
            }

            if (OptionsMenu != null)
            {
                foreach (MenuItem obj in Algerate.Items)
                {
                    if (obj is MenuItem item)
                    {
                        item.Click += (s, args) => { formbir.mngprocess.bclickerfnc(item); };
                    }
                }

            }




            if (textBox2 != null)
            {
                textBox2.Text = formbir.textBox1.Text;
            }
            formbir.mngprocess.getsttngs();
            if (formbir.formuc.xscapz1.IsChecked == true)
            {
                SetWindowDisplayAffinity(new WindowInteropHelper(this).Handle, avoidcaxptures);
            }
        }

        private void checkBox1_Click(object sender, RoutedEventArgs e)
        {
            formbir.formuc.showpassword1.IsChecked = checkBox1.IsChecked;
            formbir.formuc.showpassword1_Click(sender, e);
        }
    }
}
