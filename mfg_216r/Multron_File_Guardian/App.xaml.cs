using MultronFileGuardian;
using System.Configuration;
using System.Data;
using System.Windows;
using System.Windows.Threading;

namespace Multron_File_Guardian
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        protected override void OnStartup(StartupEventArgs e)
        {


            base.OnStartup(e);



            var window = new Window1(e.Args);
            Application.Current.DispatcherUnhandledException += new DispatcherUnhandledExceptionEventHandler(globaluexhandler);
            window.Show();
        }
        void globaluexhandler(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            MessageBox.Show("An unexpected error occurred! Program will close immediately, Error: " + e.Exception.Message + "  " + e.Exception.StackTrace, "Multron File Guardian",MessageBoxButton.OK, MessageBoxImage.Error);
            Application.Current.Shutdown(0);
        }
    }
}
