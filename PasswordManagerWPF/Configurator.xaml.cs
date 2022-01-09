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
    /// Logica di interazione per Configurator.xaml
    /// </summary>
    public partial class Configurator : Window
    {
        public Configurator()
        {
            InitializeComponent();
            resolution.Text = globalVar.resolution;
            language.Text = globalVar.language;
        }

        public void colorPaletteBackground(object sender, RoutedEventArgs e)
        {
            ColorChange colorChange = new ColorChange();
            colorChange.ShowDialog();
        }
        public void colorPaletteFont(object sender, RoutedEventArgs e)
        {

        }
        public void saveBtn(object sender, RoutedEventArgs e)
        {
            Resolution res = new Resolution();
            Languages lang = new Languages();
            try
            {
                res.saveRes(resolution.Text);
                lang.saveLanguages(language.Text);
                MessageBox.Show(LangString.savedConfig);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}
