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
using PasswordManagerWPF.Classes;
using PasswordManagerWPF.GVariable;


namespace PasswordManagerWPF
{
    /// <summary>
    /// Logica di interazione per Login.xaml
    /// </summary>
    public partial class Login : Page
    {
        public Login()
        {
            dbClass dbClass = new dbClass();
            dbClass.createTable();
            InitializeComponent();
        }
        //Close button
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
        //back Button
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }
        //login btn
        private void loginBtn(object sender, RoutedEventArgs e)
        {
            LoginForm loginForm = new LoginForm();
            if (loginForm.isValid(username.Text, password.Password.ToString()))
            {
                try
                {
                    dbClass db = new dbClass();
                    db.loginUser(username.Text, password.Password.ToString());
                    this.NavigationService.Navigate(new SavedPassword());
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

        }
        //register btn
        private void registerBtn(object sender, RoutedEventArgs e)
        {
            LoginForm loginForm = new LoginForm();
            if (loginForm.isValid(username.Text, password.Password.ToString()))
            {
                try
                {
                    dbClass db = new dbClass();
                    db.registerUser(username.Text, password.Password.ToString());
                    MessageBox.Show(LangString.userCreated);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
