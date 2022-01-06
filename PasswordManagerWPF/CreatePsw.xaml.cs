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

namespace PasswordManagerWPF
{
    /// <summary>
    /// Logica di interazione per CreatePsw.xaml
    /// </summary>
    public partial class CreatePsw : Page
    {
        public CreatePsw()
        {
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
        //copy Button
        private void btnCopyPsw(object sender, RoutedEventArgs e)
        {
            Clipboard.SetText(generatedPsw.Content.ToString());
            MessageBox.Show("Password copied!");
        }
        //generate Button
        private void generatePsw(object sender, RoutedEventArgs e)
        {
            //generate psw
            GenPassword genPassword = new GenPassword();
            string password = genPassword.generate(isNumeric.IsChecked ?? false, isAlphabetic.IsChecked ?? false, isSimbol.IsChecked ?? false, pswLength.Value);
            generatedPsw.Content = password;
            //calculate entropy
            EntropyCalc entropyCalc = new EntropyCalc();
            entropyBit.Content = entropyCalc.entropy(pswLength.Value);
            MessageBox.Show("Password generated!");
        }
    }
}
