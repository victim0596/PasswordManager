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
    /// Logica di interazione per SavedPassword.xaml
    /// </summary>
    public partial class SavedPassword : Page
    {
        public SavedPassword()
        {
            InitializeComponent();
            try
            {
                dbClass db = new dbClass();
                savedPswDB.ItemsSource = db.loadSavedPassword();
                ColorChanger colorChanger = new ColorChanger();
                colorChanger.applyFontSavPsw(this);
                fontSize fontSize = new fontSize();
                fontSize.applyFontSizeSavPsw(this);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //back Button
        private void backBtn(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new HomePage());
        }
        //addpassword btn
        private void insertPassword(object sender, RoutedEventArgs e)
        {
            try
            {
                LoginForm loginForm = new LoginForm();
                loginForm.isValidPsw(appNameText.Text, passwordText.Password.ToString(), usernameText.Text);
                dbClass db = new dbClass();
                db.insertPassword(appNameText.Text, usernameText.Text, passwordText.Password.ToString());
                MessageBox.Show(LangString.pswAdded);
                this.NavigationService.Navigate(new SavedPassword());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
