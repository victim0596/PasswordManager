using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;
using PasswordManager.Language;

namespace PasswordManager.Classes
{
    public class Languages
    {
        public string filename = "config.json";
        public void loadLanguages()
        {
            string jsonString = File.ReadAllText(filename);
            string lang;
            Configuration config = JsonSerializer.Deserialize<Configuration>(jsonString);
            if (config != null)
            {
                globalVar.language = config.language;
                lang = config.language;
            }
            else throw new Exception("config.json is empty");
            if (string.IsNullOrEmpty(lang)) throw new Exception("Language is empty");
            //set language
            this.setLanguage(lang);
        }

        public void saveLanguages(string lang)
        {
            if (string.IsNullOrEmpty(lang)) return;
            else
            {
                //read json file
                string jsonString = File.ReadAllText(filename);
                Configuration config = JsonSerializer.Deserialize<Configuration>(jsonString);
                if (config != null)
                {
                    //save resolution in the json
                    config.language = lang;
                    using FileStream createStream = File.Create(filename);
                    JsonSerializer.Serialize(createStream, config);
                    createStream.Dispose();
                }
                else throw new Exception("config.json is empty");
            }
        }

        public void setLanguage(string lang)
        {
            switch (lang)
            {
                case "Italiano":
                    {
                        Italian it = new Italian();
                        it.setItaliano();
                        break;
                    }
                case "English":
                    {
                        English en = new English();
                        en.setEnglish();
                        break;
                    }
            }
        }
    }
}
