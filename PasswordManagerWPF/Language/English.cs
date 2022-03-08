using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PasswordManagerWPF.GVariable;

namespace PasswordManagerWPF.Language
{
    internal class English
    {
        public void setEnglish()
        {
            //home
            LangString.createPswBtn = "Create Password";
            LangString.savedPswBtn = "Saved Password";
            //configurator
            LangString.resolution = "Resolution";
            LangString.language = "Language";
            LangString.bgColor = "Background color";
            LangString.fontColor = "Font Color";
            LangString.savedConfig = "Configuration Saved, reload app for see the changes";
            LangString.fontSize = "Font size";
            //btn
            LangString.saveBtn = "Save";
            //create psw
            LangString.number = "Digits";
            LangString.character = "Char";
            LangString.simbol = "Simbol";
            LangString.length = "Length";
            LangString.genPsw = "Generated password:";
            LangString.entropyBit = "Entropy bit:";
            LangString.entropyMessage = "";
            LangString.genPswBtn = "Generate";
            LangString.pswCopied = "Password copied";
            LangString.pswGenMes = "Password generated";
            LangString.labelFilter = "Exclude char";
            //entropy tips
            LangString.tip1 = "Very weak password, generate one more with more option or change length";
            LangString.tip2 = "Weak password, generate one more with more option or change length";
            LangString.tip3 = "Strong password, but I recommend that you generate one with more than 60 bits of entropy";
            LangString.tip4 = "Very strong password, very well";
            LangString.tip5 = "Password impossible to crack, even with all the computers in the universe together";
            //login
            LangString.register = "REGISTER";
            LangString.userCreated = "User created!";
            //saved psw
            LangString.pswAdded = "Password added!";
            LangString.appName = "App name";
            LangString.addBtn = "ADD";
            //edit detail
            LangString.updateBtnDetail = "ADD";
            LangString.messageUpdateDetail = "Detail updated!";
        }
    }
}
