using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PasswordManager.GVariable;

namespace PasswordManager.Language
{
    internal class Italian
    {
        public void setItaliano()
        {
            //home
            LangString.createPswBtn = "Crea Password";
            LangString.savedPswBtn = "Password Salvate";
            //configurator
            LangString.resolution = "Risoluzione";
            LangString.language = "Lingua";
            LangString.bgColor = "Colore di sfondo";
            LangString.fontColor = "Colore caratteri";
            LangString.savedConfig = "Configurazione salvata, ricarica l'app per vedere le modifiche";
            LangString.fontSize = "Grandezza font";
            //btn
            LangString.saveBtn = "Salva";
            //create psw
            LangString.number = "Numeri";
            LangString.character = "Caratteri";
            LangString.simbol = "Simboli";
            LangString.length = "Lunghezza";
            LangString.genPsw = "Password generata:";
            LangString.entropyBit = "Entropia bit:";
            LangString.entropyMessage = "";
            LangString.genPswBtn = "Genera";
            LangString.pswCopied = "Password copiata";
            LangString.pswGenMes = "Password generata";
            LangString.labelFilter = "Escludi caratteri";
            //entropy tips
            LangString.tip1 = "Password molto debole, generane un'altra con più opzioni o cambia lunghezza";
            LangString.tip2 = "Password debole, generane un'altra con più opzioni o cambia lunghezza";
            LangString.tip3 = "Password complessa, ma ti consiglio di generarne una con più di 60 bit di entropia";
            LangString.tip4 = "Password molto forte, molto bene";
            LangString.tip5 = "Password impossibile da decifrare, anche con tutti i computer dell'universo insieme";
            //login
            LangString.register = "REGISTRATI";
            LangString.userCreated = "Utente creato!";
            //saved psw
            LangString.pswAdded = "Password aggiunta!";
            LangString.appName = "Nome app";
            LangString.addBtn = "AGGIUNGI";
            LangString.findLabel = "Trova per nome app";
            LangString.messageDelete = "Sei sicuro di voler cancellare questo account?";
            LangString.entropyText = "Entropia";
            //edit detail
            LangString.updateBtnDetail = "AGGIUNGI";
            LangString.messageUpdateDetail = "Dettagli aggiornati!";
        }
    }
}
