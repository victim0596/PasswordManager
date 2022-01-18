using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.IO;
using System.Windows.Controls;
using System.Windows.Media;

namespace PasswordManagerWPF.Classes
{
    public class Resolution
    {
        public string filename = "config.json";
        public void saveRes(string resolution)
        {
            if (string.IsNullOrEmpty(resolution)) return;
            else
            {
                //read json file
                string jsonString = File.ReadAllText(filename);
                Configuration config = JsonSerializer.Deserialize<Configuration>(jsonString);
                if (config != null)
                {
                    //save resolution in the json
                    config.resolutionScreen = resolution;
                    using FileStream createStream = File.Create(filename);
                    JsonSerializer.Serialize(createStream, config);
                    createStream.Dispose();
                }
                else throw new Exception("config.json is empty");
            }
        }

        public void loadRes(MainWindow mainWindow)
        {
            string jsonString = File.ReadAllText(filename);
            string[] valueRes;
            Configuration config = JsonSerializer.Deserialize<Configuration>(jsonString);
            if (config != null)
            {
                //set resolution on configurator
                globalVar.resolution = config.resolutionScreen;
                valueRes = config.resolutionScreen.Split("x");
            }
            else throw new Exception("config.json is empty");
            if (string.IsNullOrEmpty(valueRes[0])) throw new Exception("Width is empty");
            //set resolution
            mainWindow.Width = Convert.ToInt32(valueRes[0]);
            mainWindow.Height = Convert.ToInt32(valueRes[1]);
        }
    }
}
