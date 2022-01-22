using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.IO;
using System.Windows.Media;

namespace PasswordManagerWPF.Classes
{
    public class ColorChanger
    {
        public string filename = "config.json";
        public void loadColorBG(MainWindow mainWindow)
        {
            string jsonString = File.ReadAllText(filename);
            string[] valueRes;
            Configuration config = JsonSerializer.Deserialize<Configuration>(jsonString);
            if (config != null)
            {
                //set colorBG on configurator
                globalVar.colorBG = config.backgroundColor;
                valueRes = config.backgroundColor.Split("-");
            }
            else throw new Exception("config.json is empty");
            if (string.IsNullOrEmpty(valueRes[0]) || string.IsNullOrEmpty(valueRes[1]) || string.IsNullOrEmpty(valueRes[2]) || string.IsNullOrEmpty(valueRes[3])) throw new Exception("Color is empty");
            //Set background color
            mainWindow.Background = new SolidColorBrush(Color.FromArgb(Convert.ToByte(valueRes[3]), Convert.ToByte(valueRes[0]), Convert.ToByte(valueRes[1]), Convert.ToByte(valueRes[2])));
        }
        public void saveColorBG(string red, string green, string blue, string alpha)
        {
            if (string.IsNullOrEmpty(red) || string.IsNullOrEmpty(green) || string.IsNullOrEmpty(blue)) return;
            else
            {
                //read json file
                string jsonString = File.ReadAllText(filename);
                Configuration config = JsonSerializer.Deserialize<Configuration>(jsonString);
                if (config != null)
                {
                    //save resolution in the json
                    config.backgroundColor = String.Format("{0}-{1}-{2}-{3}", red, green, blue, alpha);
                    using FileStream createStream = File.Create(filename);
                    JsonSerializer.Serialize(createStream, config);
                    createStream.Dispose();
                }
                else throw new Exception("config.json is empty");
            }
        }

        public void loadColorFG()
        {
            string jsonString = File.ReadAllText(filename);
            string[] valueRes;
            Configuration config = JsonSerializer.Deserialize<Configuration>(jsonString);
            if (config != null)
            {
                //set colorFG on configurator
                globalVar.colorFG = config.fontColor;
                valueRes = config.fontColor.Split("-");
            }
            else throw new Exception("config.json is empty");
            if (string.IsNullOrEmpty(valueRes[0]) || string.IsNullOrEmpty(valueRes[1]) || string.IsNullOrEmpty(valueRes[2]) || string.IsNullOrEmpty(valueRes[3])) throw new Exception("Color is empty");
        }

        public void saveColorFG(string red, string green, string blue, string alpha)
        {
            if (string.IsNullOrEmpty(red) || string.IsNullOrEmpty(green) || string.IsNullOrEmpty(blue)) return;
            else
            {
                //read json file
                string jsonString = File.ReadAllText(filename);
                Configuration config = JsonSerializer.Deserialize<Configuration>(jsonString);
                if (config != null)
                {
                    //save resolution in the json
                    config.fontColor = String.Format("{0}-{1}-{2}-{3}", red, green, blue, alpha);
                    using FileStream createStream = File.Create(filename);
                    JsonSerializer.Serialize(createStream, config);
                    createStream.Dispose();
                }
                else throw new Exception("config.json is empty");
            }
        }

        public void applyFontGenPsw(CreatePsw createPsw)
        {
            string[] valueRes;
            valueRes = globalVar.colorFG.Split("-");
            SolidColorBrush colorFont = new SolidColorBrush(Color.FromArgb(Convert.ToByte(valueRes[3]), Convert.ToByte(valueRes[0]), Convert.ToByte(valueRes[1]), Convert.ToByte(valueRes[2])));
            createPsw.isNumeric.Foreground = colorFont;
            createPsw.isAlphabetic.Foreground = colorFont;
            createPsw.isSimbol.Foreground = colorFont;
            createPsw.labelLength.Foreground = colorFont;
            createPsw.labelGenPsw.Foreground = colorFont;
            createPsw.generatedPsw.Foreground = colorFont;
            createPsw.labelEntropy.Foreground = colorFont;
            createPsw.entropyBit.Foreground = colorFont;
            createPsw.labelFilter.Foreground = colorFont;
        }

        public void applyFontSavPsw(SavedPassword savedPassword)
        {
            string[] valueRes;
            valueRes = globalVar.colorFG.Split("-");
            SolidColorBrush colorFont = new SolidColorBrush(Color.FromArgb(Convert.ToByte(valueRes[3]), Convert.ToByte(valueRes[0]), Convert.ToByte(valueRes[1]), Convert.ToByte(valueRes[2])));
            savedPassword.labelApp.Foreground = colorFont;
            savedPassword.labelPsw.Foreground = colorFont;
            savedPassword.labelUsername.Foreground = colorFont;
        }

    }
}
