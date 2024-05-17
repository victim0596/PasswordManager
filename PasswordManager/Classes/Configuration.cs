using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace PasswordManager.Classes
{
    public class Configuration
    {
        public string resolutionScreen { get; set; }
        public string language { get; set; }
        public string backgroundColor { get; set; }
        public string fontColor { get; set; }

        public string fontSize { get; set; }
        public string excelPath { get; set; }

        public void loadConfig(MainWindow mainWindow)
        {
            //load resolution
            Resolution res = new Resolution();
            res.loadRes(mainWindow);

            //load Language
            Languages lang = new Languages();
            lang.loadLanguages();

            //load Color
            ColorChanger colorChanger = new ColorChanger();
            colorChanger.loadColorBG(mainWindow);
            colorChanger.loadColorFG();

            //load fontSize
            fontSize fontSize = new fontSize();
            fontSize.loadFontSize();
 
        }
    }
}
