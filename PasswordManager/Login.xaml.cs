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
using PasswordManager.Classes;
using PasswordManager.Components.Commands;
using PasswordManager.GVariable;
using PasswordManager.Components.Queries;


namespace PasswordManager
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
                    var user = new GetUserByUsernamePswQueryHandler().Retrieve(new GetUserByUsernamePswQuery { Username = username.Text, Password = password.Password.ToString() }).FirstOrDefault();
                    if (user == null) throw new Exception("No user with this username");
                    else globalVar.userLogged = true;
                    this.NavigationService.Navigate(new SavedPassword());
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

        }
        //keyup with enter in login button
        private void loginBtnKeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                this.loginBtn(sender, e);
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
                    new RegisterUserCommandHandler().Execute(new RegisterUserCommand { Username = username.Text, Password = password.Password.ToString() });
                    MessageBox.Show(LangString.userCreated);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(" Possible duplicate entry, you already have an account - " + ex.Message);
                }
            }
        }
    }
}
