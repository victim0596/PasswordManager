using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Windows;
using System.Diagnostics;
using System.Net;

namespace PasswordManager.Classes
{
    public class dbClass
    {
        public SQLiteConnection connectionDb;
        public dbClass()
        {
            SQLiteConnection dbConn = new SQLiteConnection("Data Source=database.db; Version = 3;");
            try
            {
                dbConn.Open();
                this.connectionDb = dbConn;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void createTable()
        {
            SQLiteCommand cmd = this.connectionDb.CreateCommand();
            string queryUsers = "CREATE TABLE IF NOT EXISTS users (username VARCHAR(20) PRIMARY KEY NOT NULL, password VARCHAR(255) NOT NULL);";
            string queryPassword = "CREATE TABLE IF NOT EXISTS pswManager (id INTEGER PRIMARY KEY AUTOINCREMENT, sitename VARCHAR(35) NOT NULL, password VARCHAR(255) NOT NULL, username VARCHAR(35) NOT NULL);";
            cmd.CommandText = queryUsers;
            cmd.ExecuteNonQuery();
            cmd.CommandText = queryPassword;
            cmd.ExecuteNonQuery();
            this.connectionDb.Close();
        }

    }
}
