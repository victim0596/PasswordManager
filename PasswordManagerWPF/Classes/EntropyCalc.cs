using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace PasswordManagerWPF.Classes
{
    internal class EntropyCalc
    {
        public EntropyCalc()
        {
            globalVar.lowerCase = 0;
            globalVar.upperCase = 0;
            globalVar.digits = 0;
            globalVar.simbol = 0;
        }
        public string entropy(double length)
        {
            double entropy = 0;
            int poolSize = 0;
            if (globalVar.lowerCase > 0) poolSize = poolSize + 26;
            if (globalVar.upperCase > 0) poolSize = poolSize + 26;
            if (globalVar.digits > 0) poolSize = poolSize + 10;
            if (globalVar.simbol > 0) poolSize = poolSize + 32;
            entropy = length * Math.Log2(poolSize);
            return entropy.ToString("0.00");
        }
        public void entropyTips(string entropyValue, Label entropyLabel)
        {
            string message = "";
            double entropyBit = Double.Parse(entropyValue);
            switch (entropyBit)
            {
                case < 17:
                    {
                        message = "Very weak password, generate one more with more option or change length";
                        entropyLabel.Foreground = new SolidColorBrush(Colors.Red);
                        break;
                    }
                case double n when (n >= 17 && n <= 36):
                    {
                        message = "Weak password, generate one more with more option or change length";
                        entropyLabel.Foreground = new SolidColorBrush(Colors.Orange);
                        break;
                    }
                case double n when (n > 36 && n <= 60):
                    {
                        message = "Strong password, but I recommend that you generate one with more than 60 bits of entropy";
                        entropyLabel.Foreground = new SolidColorBrush(Colors.Yellow);
                        break;
                    }
                case double n when (n > 60 && n <= 124):
                    {
                        message = "Very strong password, very well";
                        entropyLabel.Foreground = new SolidColorBrush(Colors.GreenYellow);
                        break;
                    }
                case > 125:
                    {
                        message = "Password impossible to crack, even with all the computers in the universe together";
                        entropyLabel.Foreground = new SolidColorBrush(Colors.Green);
                        break;
                    }
            }
            entropyLabel.Content = message;
        }
    }
}
