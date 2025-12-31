using MultronFileGuardian;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Multron_File_Guardian
{
    /// <summary>
    /// Interaction logic for Window4.xaml
    /// </summary>
    public partial class Window4 : Window
    {
        string mfgkeys = Environment.CurrentDirectory + "\\mfgsettings\\" + "publickeys.txt";
        Window1 frm1;
        private string followfs = AppContext.BaseDirectory + "\\khfsdone.smfg";

        public Window4(Window1 frm1)
        {
            InitializeComponent();
            this.frm1 = frm1;
            if (System.IO.File.Exists(mfgkeys))
            {
                foreach(string line in System.IO.File.ReadAllLines(mfgkeys))
                {
                    listBox1.Items.Add(line);
                }
             
            }
            if (System.IO.File.Exists(followfs))
            {
                SecurityWarningBanner.Visibility = Visibility.Collapsed;
            }
            else
            {
                System.IO.File.Create(followfs).Close();
            }
        }
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        private void CloseWarningBanner_Click(object sender, RoutedEventArgs e)
        {
            SecurityWarningBanner.Visibility = Visibility.Collapsed;
        }
        private void MinimizeButton_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }
        private void TitleBar_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }

        private void SaveKeys_Click(object sender, RoutedEventArgs e)
        {
        
            List<string> keys = new List<string>();
            foreach (string key in listBox1.Items)
            { 
                keys.Add(key); 
            }
            System.IO.File.WriteAllLines(mfgkeys, keys.ToArray());
        }
   
        private void AddKey_Click(object sender, RoutedEventArgs e)
        {
            string owner = textBox1.Text;
            string publicKey = textBox2.Text;

            if (string.IsNullOrEmpty(owner))
            {
                MessageBox.Show("Please enter the public key owner name.", "Multron KeyHold", MessageBoxButton.OK, MessageBoxImage.Warning);
                textBox1.Focus();
                return;
            }

            if (string.IsNullOrEmpty(publicKey))
            {
                MessageBox.Show("Please enter the public key.", "Multron KeyHold", MessageBoxButton.OK, MessageBoxImage.Warning);
                textBox2.Focus();
                return;
            }
             
            string keyEntry = $"{owner} | {publicKey}";
            listBox1.Items.Add(keyEntry);
            textBox1.Clear();
            textBox2.Clear();
            textBox1.Focus();
    
        }

        private void WriteToKeySection_Click(object sender, RoutedEventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                string pbkey = "";
                short keystate = 0;
                foreach (char c in listBox1.SelectedItem.ToString())
                {
                    if (keystate == 1 && c != ' ')
                    {
                        pbkey = pbkey + c;
                    }
                  
                         if (c == '|')
                        {
                            keystate = 1;
                        }
                   
                  
                }
                frm1.textBox1.Text = pbkey;
                if (frm1.formuc.ckh1.IsChecked == true)
                {
                    Close();
                }
            }
       
        }

        private void ClearItem_Click(object sender, RoutedEventArgs e)
        {
          
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            frm1.closedholdkey = 1;
        }
    }
}
