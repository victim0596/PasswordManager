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
                new UpdateDetailCommandHandler().Execute(new UpdateDetailCommand { Appname = appNameText.Text, Username = usernameText.Text, Password = passwordText.Text, Id = globalVar.idRowDetail });
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
