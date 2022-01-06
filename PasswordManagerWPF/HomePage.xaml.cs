using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Diagnostics;
using PasswordManagerWPF.Classes;


namespace PasswordManagerWPF
{
    /// <summary>
    /// Logica di interazione per HomePage.xaml
    /// </summary>
    public partial class HomePage : Page
    {
        public HomePage()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
        private void createPswPage(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new CreatePsw());
        }
        private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            Process.Start(new ProcessStartInfo(e.Uri.AbsoluteUri) { UseShellExecute = true });
            e.Handled = true;
        }
        private void savedPswPage(object sender, RoutedEventArgs e)
        {
            if (globalVar.userLogged) this.NavigationService.Navigate(new SavedPassword());
            else this.NavigationService.Navigate(new Login());
        }
    }
}
