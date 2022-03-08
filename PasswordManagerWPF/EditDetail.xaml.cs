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
using PasswordManagerWPF.Classes;
using PasswordManagerWPF.GVariable;

namespace PasswordManagerWPF
{
    /// <summary>
    /// Logica di interazione per EditDetail.xaml
    /// </summary>
    public partial class EditDetail : Window
    {
        public EditDetail()
        {
            InitializeComponent();
        }

        private void editInfo(object sender, RoutedEventArgs e)
        {
            try
            {
                string username = usernameText.Text;
                string password = passwordText.Text;
                string appname = appNameText.Text;
                dbClass dbClass = new dbClass();
                dbClass.updateDetail(appname, username, password, globalVar.idRowDetail);
                MessageBox.Show(LangString.messageUpdateDetail);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
