using MultronFileGuardian;
using System.Configuration;
using System.Data;
using System.Windows;

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
          
            window.Show();
        }
    }

}
