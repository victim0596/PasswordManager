﻿using System;
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
using PasswordManager.GVariable;

namespace PasswordManager
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
            sizeFont.Text = globalVar.sizeFont;
        }

        public void colorPaletteBackground(object sender, RoutedEventArgs e)
        {
            ColorChange colorChange = new ColorChange();
            colorChange.ShowDialog();
        }
        public void colorPaletteFont(object sender, RoutedEventArgs e)
        {
            ChangeColorFont changeFont = new ChangeColorFont();
            changeFont.ShowDialog();
        }
        public void saveBtn(object sender, RoutedEventArgs e)
        {
            Resolution res = new Resolution();
            Languages lang = new Languages();
            fontSize fontSize = new fontSize();
            try
            {
                res.saveRes(resolution.Text);
                lang.saveLanguages(language.Text);
                fontSize.saveFontSize(sizeFont.Text);
                MessageBox.Show(LangString.savedConfig);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}
