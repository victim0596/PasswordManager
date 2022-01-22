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
using PasswordManagerWPF.Classes;
using PasswordManagerWPF.GVariable;

namespace PasswordManagerWPF
{
    /// <summary>
    /// Logica di interazione per ColorChange.xaml
    /// </summary>
    public partial class ColorChange : Window
    {
        public ColorChange()
        {
            InitializeComponent();
        }

        public void ChangeColor(object sender, RoutedEventArgs e)
        {
            try
            {
                double rgbR = changeBG.Color.RGB_R;
                double rgbG = changeBG.Color.RGB_G;
                double rgbB = changeBG.Color.RGB_B;
                double alpha = changeBG.Color.A;
                ColorChanger colorChanger = new ColorChanger();
                colorChanger.saveColorBG(Convert.ToInt32(rgbR).ToString(), Convert.ToInt32(rgbG).ToString(), Convert.ToInt32(rgbB).ToString(), Convert.ToInt32(alpha).ToString());
                MessageBox.Show(LangString.savedConfig);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
