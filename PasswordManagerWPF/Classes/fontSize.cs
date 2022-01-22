using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace PasswordManagerWPF.Classes
{
    public class fontSize
    {
        public string filename = "config.json";

        public void saveFontSize(string size)
        {
            if (string.IsNullOrEmpty(size)) return;
            else
            {
                //read json file
                string jsonString = File.ReadAllText(filename);
                Configuration config = JsonSerializer.Deserialize<Configuration>(jsonString);
                if (config != null)
                {
                    //save fontSize in the json
                    config.fontSize = size;
                    using FileStream createStream = File.Create(filename);
                    JsonSerializer.Serialize(createStream, config);
                    createStream.Dispose();
                }
                else throw new Exception("config.json is empty");
            }
        }

        public void loadFontSize()
        {
            string jsonString = File.ReadAllText(filename);
            string valueRes;
            Configuration config = JsonSerializer.Deserialize<Configuration>(jsonString);
            if (config != null)
            {
                //set resolution on configurator
                globalVar.sizeFont = config.fontSize;
                valueRes = config.fontSize.Substring(1);
            }
            else throw new Exception("config.json is empty");
            if (string.IsNullOrEmpty(valueRes)) throw new Exception("fontSize is empty");
        }

        public void applyFontSizeGenPsw(CreatePsw createPsw)
        {
            double sizeValue = Double.Parse(globalVar.sizeFont.Substring(1));
            createPsw.isNumeric.FontSize = Convert.ToInt32(createPsw.isNumeric.FontSize * sizeValue);
            createPsw.isAlphabetic.FontSize = Convert.ToInt32(createPsw.isAlphabetic.FontSize * sizeValue);
            createPsw.isSimbol.FontSize = Convert.ToInt32(createPsw.isSimbol.FontSize * sizeValue);
            createPsw.labelLength.FontSize = Convert.ToInt32(createPsw.labelLength.FontSize * sizeValue);
            createPsw.labelGenPsw.FontSize = Convert.ToInt32(createPsw.labelGenPsw.FontSize * sizeValue);
            createPsw.generatedPsw.FontSize = Convert.ToInt32(createPsw.generatedPsw.FontSize * sizeValue);
            createPsw.labelEntropy.FontSize = Convert.ToInt32(createPsw.labelEntropy.FontSize * sizeValue);
            createPsw.entropyBit.FontSize = Convert.ToInt32(createPsw.entropyBit.FontSize * sizeValue);
            createPsw.entropyMessage.FontSize = Convert.ToInt32(createPsw.entropyMessage.FontSize * sizeValue);
        }

        public void applyFontSizeSavPsw(SavedPassword savedPassword)
        {
            double sizeValue = Double.Parse(globalVar.sizeFont.Substring(1));
            savedPassword.labelApp.FontSize = Convert.ToInt32(savedPassword.labelApp.FontSize * sizeValue);
            savedPassword.labelPsw.FontSize = Convert.ToInt32(savedPassword.labelPsw.FontSize * sizeValue);
            savedPassword.labelUsername.FontSize = Convert.ToInt32(savedPassword.labelUsername.FontSize * sizeValue);
        }

    }
}
