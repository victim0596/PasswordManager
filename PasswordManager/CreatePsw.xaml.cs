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
using PasswordManager.GVariable;

namespace PasswordManager
{
    /// <summary>
    /// Logica di interazione per CreatePsw.xaml
    /// </summary>
    public partial class CreatePsw : Page
    {
        public CreatePsw()
        {
            InitializeComponent();
            ColorChanger colorChanger = new ColorChanger();
            colorChanger.applyFontGenPsw(this);
            fontSize fontSize = new fontSize();
            fontSize.applyFontSizeGenPsw(this);
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
            try
            {
                //read excluded char
                string excludedChar = filterChar.Text;
                genPassword.excludedChar = excludedChar;
                //check if there is duplicated in string
                genPassword.checkDuplicateExcluded(excludedChar);
                //generate psw
                string password = genPassword.generate(isNumeric.IsChecked ?? false, isAlphabetic.IsChecked ?? false, isSimbol.IsChecked ?? false, pswLength.Value);
                generatedPsw.Content = password;
                //calculate entropy
                string entropyValue = entropyCalc.entropy(pswLength.Value);
                entropyBit.Content = entropyValue;
                entropyCalc.entropyTips(entropyValue, entropyMessage);
                //set variable for savePsw
                globalVar.genPsw = password;

                MessageBox.Show(LangString.pswGenMes);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //save Button
        private void savePsw(object sender, RoutedEventArgs e)
        {
            SaveGenerated saveGenerated = new SaveGenerated();
            saveGenerated.ShowDialog();
        }
    }
}
