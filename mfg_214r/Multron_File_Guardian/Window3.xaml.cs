using multronfileguardian;
using MultronFileGuardian;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Emit;
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
    /// Interaction logic for Window3.xaml
    /// </summary>
    public partial class Window3 : Window
    {
        Window2 formuc;
        Window1 formbir;
        public Window3(Window2 formuc, Window1 formbir)
        {
            InitializeComponent();
            this.formuc = formuc;
            this.formbir = formbir;
        }
        int keysize = 4096;
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        private const uint avoidcapture = 0x00000011;
        [DllImport("user32.dll")]
        public static extern uint SetWindowDisplayAffinity(IntPtr hwnd, uint dwAffinity);
        private void Load(object sender, RoutedEventArgs e)
        {


            if (formuc.xscapz1.IsChecked == true)
            {
                SetWindowDisplayAffinity(new WindowInteropHelper(this).Handle, avoidcapture);
            }

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
        public async void genkey()
        {
            btnGenerate.IsEnabled = false;
            btnGenerate.Content = "Generating...";
             
            string rsakey = await Task.Run(() => raes.rsageneratekey(keysize));
             
            textBoxPublicKey.Text = getstring(rsakey, '#', 0);
            textBoxPrivateKey.Text = getstring(rsakey, '#', 1);

            rsakey = "";

            btnGenerate.Content = "Generate RSA Key";
            btnGenerate.IsEnabled = true;


        }
        private void CopyPublicKey_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(textBoxPublicKey.Text))
            {
                try
                {
                    Clipboard.Clear();
                    Clipboard.SetText(textBoxPublicKey.Text);
                    ShowCopyNotification("Public key copied to clipboard!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error copying to clipboard: {ex.Message}",
                        "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("No public key to copy. Generate keys first!",
                    "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
        private void InfoButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("These are your RSA Public/Private Key. Public Key is the key that will be used to encrypt but cant be used to decrypt. Private Key is only for decrypt, Cant be used to encrypt. So protect your Private key, Dont give it anyone", "Multron RSA Key Generator", MessageBoxButton.OK, MessageBoxImage.Information);
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
            formbir.closedrsakgen = 1;
            Close();
        }
        private void CopyPrivateKey_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(textBoxPrivateKey.Text))
            {
                var result = MessageBox.Show(
                    "⚠️ Warning: You are about to copy your PRIVATE key to clipboard.\n\n" +
                    "This key should be kept secure and never shared!\n\n" +
                    "Continue?",
                    "Security Warning",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Warning);

                if (result == MessageBoxResult.Yes)
                {
                    try
                    {
                        Clipboard.Clear();
                        Clipboard.SetText(textBoxPrivateKey.Text);
                        ShowCopyNotification("Private key copied to clipboard!");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error copying to clipboard: {ex.Message}",
                            "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("No private key to copy. Generate keys first!",
                    "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void ShowCopyNotification(string message)
        {
    
            var timer = new System.Windows.Threading.DispatcherTimer();
            var notification = new Window
            {
                Width = 300,
                Height = 80,
                WindowStyle = WindowStyle.None,
                ResizeMode = ResizeMode.NoResize,
                WindowStartupLocation = WindowStartupLocation.CenterScreen,
                Background = System.Windows.Media.Brushes.Transparent,
                AllowsTransparency = true,
                ShowInTaskbar = false,
                Topmost = true
            };

            var border = new System.Windows.Controls.Border
            {
                Background = new System.Windows.Media.SolidColorBrush(
                System.Windows.Media.Color.FromRgb(31, 58, 147)),
                CornerRadius = new CornerRadius(8),
                Padding = new Thickness(20)
            };

            var text = new System.Windows.Controls.TextBlock
            {
                Text = "✓ " + message,
                Foreground = System.Windows.Media.Brushes.White,
                FontSize = 14,
                FontWeight = FontWeights.SemiBold,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center
            };

            border.Child = text;
            notification.Content = border;

            timer.Interval = TimeSpan.FromSeconds(2);
            timer.Tick += (s, args) =>
            {
                notification.Close();
                timer.Stop();
            };

            notification.Show();
            timer.Start();
        }

        private void GenerateKeys_Click(object sender, RoutedEventArgs e)
        {
         
           genkey();
        
         
           
        }

        private void KeyLength_Changed(object sender, SelectionChangedEventArgs e)
        {

        }

        private void comboBoxKeyLength_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (comboBoxKeyLength.SelectedItem is ComboBoxItem selectedItem)
            {
                string selectedText = selectedItem.Content.ToString();

                if (int.TryParse(selectedText, out int parsedKeysize))
                {
                    keysize = parsedKeysize;
                }
               
            }
        }
    }
}
