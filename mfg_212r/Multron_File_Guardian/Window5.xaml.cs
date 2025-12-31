using Microsoft.Win32;
using MultronFileGuardian;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Multron_File_Guardian
{
    /// <summary>
    /// Interaction logic for Window5.xaml
    /// </summary>
    public partial class Window5 : Window
    {
        Window1 forum1;
        mngProcesses process;
        byte frdrawed = 0;
        private const uint avoidcaxptures = 0x00000011;
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        [DllImport("user32.dll")]
        public static extern uint SetWindowDisplayAffinity(IntPtr hwnd, uint dwAffinity);
        public Window5(Window1 foum1, mngProcesses process)
        {
            InitializeComponent();
            this.forum1 = foum1;
            this.process = process;
        }
    
        private void TitleBar_MouseDown(object sender, MouseButtonEventArgs e)
        {

            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }
         
        private void SettingsBtn_Click(object sender, RoutedEventArgs e)
        {
            SettingsPopup.Visibility = Visibility.Visible;
        }
         
        private void CloseSettingsPopup_Click(object sender, RoutedEventArgs e)
        {
            SettingsPopup.Visibility = Visibility.Collapsed;
        }

       
        private void SettingsPopup_MouseDown(object sender, MouseButtonEventArgs e)
        {
            SettingsPopup.Visibility = Visibility.Visible;
        }
         
        private void rjButton8_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }
         
        private void rjButton7_Click(object sender, RoutedEventArgs e)
        {
            forum1.Close();
        }

        private void label6_Click(object sender, RoutedEventArgs e)
        {
            forum1.label6_Click(sender, e);
        }
        private void label13_Click(object sender, RoutedEventArgs e)
        {
            forum1.label11_Click(sender, e);
        }


        private void Settings_Click(object sender, RoutedEventArgs e)
        {
             forum1.formuc.Show();
        }
        private void rjButton1_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (textBox1.Text == "")
                {
                    System.Windows.MessageBox.Show("You need to enter a key.", label5.Text, MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    forum1.Show();
                    if (forum1.process.rcmng == 0)
                    {
                        forum1.comboBox1.Text = comboBox1.Text;
                        forum1.comboBox2.Text = comboBox2.Text;
                        forum1.comboBox3.Text = comboBox3.Text;
                        forum1.comboBox4.Text = comboBox4.Text;
                        forum1.textBox1.Text = textBox1.Text;
                        if (forum1.process.encryptstatus == 1)
                        {
                            forum1.rjButton2.RaiseEvent(new RoutedEventArgs(System.Windows.Controls.Button.ClickEvent));
                        }
                        else if (forum1.process.encryptstatus == 2)
                        {
                            forum1.rjButton1.RaiseEvent(new RoutedEventArgs(System.Windows.Controls.Button.ClickEvent));
                        }
                    }
                    else
                    {
                        forum1.forum6.Show();

                        MenuItem tsmiay = (MenuItem)forum1.forum6.Algerate;
                        foreach (MenuItem toolsmi in tsmiay.Items)
                        {
                            if (toolsmi.Header.ToString().Contains(comboBox1.Text))
                            {
                                toolsmi.RaiseEvent(new RoutedEventArgs(MenuItem.ClickEvent));
                            }
                        }
                        MenuItem tsmiuhay = (MenuItem)forum1.forum6.symmetricKeyLengthToolStripMenuItem;
                        foreach (MenuItem toolsmi in tsmiuhay.Items)
                        {
                            if (toolsmi.Header.ToString().Contains(comboBox3.Text))
                            {
                                toolsmi.RaiseEvent(new RoutedEventArgs(MenuItem.ClickEvent));
                            }
                        }
                        if (comboBox4.Text == "Encrypt-then-MAC")
                        {
                            forum1.forum6.tosavencryptthenMACToolStripMenuItem.RaiseEvent(new RoutedEventArgs(MenuItem.ClickEvent));
                            if (forum1.forum6.tosavencryptthenMACToolStripMenuItem.IsChecked == false)
                            {
                                forum1.forum6.tosavencryptthenMACToolStripMenuItem.RaiseEvent(new RoutedEventArgs(MenuItem.ClickEvent));
                            }
                        }
                        else
                        {
                            forum1.forum6.tosavencryptthenMACToolStripMenuItem.RaiseEvent(new RoutedEventArgs(MenuItem.ClickEvent)); ;
                            if (forum1.forum6.tosavencryptthenMACToolStripMenuItem.IsChecked == true)
                            {
                                forum1.forum6.tosavencryptthenMACToolStripMenuItem.RaiseEvent(new RoutedEventArgs(MenuItem.ClickEvent)); ;
                            }
                        }
                        forum1.forum6.textBox2.Text = textBox1.Text;
                        forum1.mngprocess.filepathh = forum1.listBox1.Items[0].ToString();
                        forum1.mngprocess.dntrnbcntrtlr = 1;
                        forum1.mngprocess.readfwithsalgorithmm(forum1.mngprocess.filepathh);
                        forum1.Hide();
                    }
                    forum1.formuc.showpassword1.IsChecked = checkBox1.IsChecked;
                    forum1.formuc.showpassword1_Click(sender, e);
                    this.Hide();
                }
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show("Error! = " + ex.Message + "\n" + ex.StackTrace.ToString(), label5.Text, MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private void Window_ContentRendered(object sender, EventArgs e)
        {
            frdrawed = 1;
            if (forum1.process.rcmng == 0)
            {
                comboBox1.Text = forum1.comboBox1.Text;
                comboBox2.Text = forum1.comboBox2.Text;
                comboBox3.Text = forum1.comboBox3.Text;
                comboBox4.Text = forum1.comboBox4.Text;
                label5.Text = forum1.label5.Text;
            }
            else
            {
                if (forum1.mngprocess.drawed == 0)
                {

                }
                else
                {
                    while (true)
                    {
                        if (forum1.mngprocess.drawed == 1)
                        {
                            break;
                        }
                    }
                }
                comboBox1.Items.Clear();
                comboBox3.Items.Clear();
                forum1.forum6.Show();
                label5.Text = forum1.forum6.Title;
                byte ender = 0;
                byte resulter = 0;
                MenuItem tsmiay = (MenuItem)forum1.forum6.Algerate;
                foreach (MenuItem toolsmi in tsmiay.Items)
                {
                    comboBox1.Items.Add(new ComboBoxItem { Content = toolsmi.Header.ToString() });
                    if (toolsmi.IsChecked == true)
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
                MenuItem tsmihuhay = (MenuItem)forum1.forum6.symmetricKeyLengthToolStripMenuItem;
                foreach (MenuItem toolsmi in tsmihuhay.Items)
                {
                    if (toolsmi.IsChecked == true)
                    {
                        ender = 1;
                    }
                    if (ender == 0)
                    {
                        ++resulter;
                    }
                }
                comboBox3.SelectedIndex = resulter;
                if (forum1.forum6.tosavencryptthenMACToolStripMenuItem.IsChecked == true)
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

        private void comboBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (frdrawed == 1)
            {
                ComboBoxItem selectedItem = comboBox1.SelectedItem as ComboBoxItem;
                if (selectedItem == null) return;

                string selectedText = selectedItem.Content?.ToString();
                if (string.IsNullOrEmpty(selectedText)) return;

                comboBox2.IsEnabled = selectedText.Contains("RSA");

                if (forum1.formuc?.savealgorithm1?.IsChecked == true)
                {
                    forum1.formuc.swillbesaved = 1;
                }

                comboBox3.Items.Clear();
                string[] keySizes = forum1.GetKeySizesForAlgorithm(selectedText);

                foreach (var size in keySizes)
                {
                    comboBox3.Items.Add(new ComboBoxItem { Content = size });
                }
                if (comboBox2.IsEnabled)
                {
                    textBox1.Height = 200;
                    textBox1.TextWrapping = TextWrapping.Wrap;
                    textBox1.AcceptsReturn = true;
                }
                else
                {
                    textBox1.Height = 40;
                    textBox1.TextWrapping = TextWrapping.NoWrap;
                    textBox1.AcceptsReturn = false;
                }
                if (comboBox3.Items.Count > 0)
                {
                    comboBox3.SelectedIndex = comboBox3.Items.Count - 1;
                }
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (forum1.formuc.xscapz1.IsChecked == true)
            {
                SetWindowDisplayAffinity(new WindowInteropHelper(this).Handle, avoidcaxptures);
            }
            forum1.formuc.cintegff = textBox1.FontFamily;
            forum1.formuc.showpassword1_Click(sender, e);

        }

        private void checkBox1_Click(object sender, RoutedEventArgs e)
        {
            forum1.formuc.showpassword1.IsChecked = checkBox1.IsChecked;
            forum1.formuc.showpassword1_Click(sender, e);
        }

        private void rjbutton2_Click(object sender, RoutedEventArgs e)
        {
            forum1.label11_Click(sender, e);
        }

        private void stngsbtn_Click(object sender, RoutedEventArgs e)
        {
            forum1.formuc.Show();
        }
    }
}
