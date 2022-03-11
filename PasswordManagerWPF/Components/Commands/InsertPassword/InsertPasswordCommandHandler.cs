﻿using PasswordManagerWPF.DBModels;
using PasswordManagerWPF.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManagerWPF.Components.Commands
{
    public class InsertPasswordCommandHandler
    {
        public void Execute(InsertPasswordCommand command)
        {
            using (var db = new DatabaseContext())
            {
                db.pswManagers.Add(new PswManager()
                {
                    USERNAME = command.Username,
                    PASSWORD = command.Password,
                    APPNAME = command.Appname
                });
                db.SaveChanges();
            }
        }
    }
}
