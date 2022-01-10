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
    /// Logica di interazione per CreatePsw.xaml
    /// </summary>
    public partial class CreatePsw : Page
    {
        public CreatePsw()
        {
            InitializeComponent();
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
            MessageBox.Show(LangString.pswCopied);
        }
        //generate Button
        private void generatePsw(object sender, RoutedEventArgs e)
        {
            EntropyCalc entropyCalc = new EntropyCalc();
            GenPassword genPassword = new GenPassword();
            //generate psw
            string password = genPassword.generate(isNumeric.IsChecked ?? false, isAlphabetic.IsChecked ?? false, isSimbol.IsChecked ?? false, pswLength.Value);
            generatedPsw.Content = password;
            //calculate entropy
            string entropyValue = entropyCalc.entropy(pswLength.Value);
            entropyBit.Content = entropyValue;
            entropyCalc.entropyTips(entropyValue, entropyMessage);
            MessageBox.Show(LangString.pswGenMes);
        }
    }
}
