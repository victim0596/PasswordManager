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
using System.Windows.Shapes;
using PasswordManager.Classes;
using PasswordManager.Components.Commands;
using PasswordManager.GVariable;

namespace PasswordManager
{
    /// <summary>
    /// Logica di interazione per SaveGenerated.xaml
    /// </summary>
    public partial class SaveGenerated : Window
    {
        public SaveGenerated()
        {
            InitializeComponent();
        }
        //add Button
        private void insertPassword(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!globalVar.userLogged) throw new Exception("To add the password you must be logged in");
                LoginForm loginForm = new LoginForm();
                loginForm.isValidPsw(appNameText.Text, passwordText.Text, usernameText.Text);
                new InsertPasswordCommandHandler().Execute(new InsertPasswordCommand { Appname = appNameText.Text, Username = usernameText.Text, Password = passwordText.Text });
                MessageBox.Show(LangString.pswAdded);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
