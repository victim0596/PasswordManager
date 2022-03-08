using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Windows;
using System.Diagnostics;
using System.Net;

namespace PasswordManagerWPF.Classes
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
        public void registerUser(string username, string password)
        {
            if (this.checkIfExistUser()) throw new Exception("Only one account is permitted");
            SQLiteCommand cmd = this.connectionDb.CreateCommand();
            string insertUser = "INSERT INTO users (username, password) VALUES ($username, $password);";
            cmd.CommandText = insertUser;
            cmd.Parameters.AddWithValue("$username", username);
            cmd.Parameters.AddWithValue("$password", password);
            cmd.ExecuteNonQuery();
            this.connectionDb.Close();
        }

        public void loginUser(string username, string password)
        {
            SQLiteCommand cmd = this.connectionDb.CreateCommand();
            SQLiteDataReader sQLiteDataReader;
            string insertUser = "SELECT * FROM users WHERE username = $username AND password = $password";
            cmd.CommandText = insertUser;
            cmd.Parameters.AddWithValue("$username", username);
            cmd.Parameters.AddWithValue("$password", password);
            sQLiteDataReader = cmd.ExecuteReader();
            string dbUsername = "", dbPassword = "";
            while (sQLiteDataReader.Read())
            {
                dbUsername = sQLiteDataReader.GetString(0);
                dbPassword = sQLiteDataReader.GetString(1);
            }
            this.connectionDb.Close();
            if (string.IsNullOrEmpty(dbUsername) || string.IsNullOrEmpty(dbPassword)) throw new Exception("No user with this username");
            else globalVar.userLogged = true;
        }

        public List<passwordManager> loadSavedPassword()
        {
            SQLiteCommand cmd = this.connectionDb.CreateCommand();
            string query = "SELECT * FROM pswManager";
            cmd.CommandText = query;
            SQLiteDataReader sQLiteDataReader;
            sQLiteDataReader = cmd.ExecuteReader();
            List<passwordManager> passwordManagers = new List<passwordManager>();
            while (sQLiteDataReader.Read())
            {
                passwordManagers.Add(new passwordManager() { id = sQLiteDataReader.GetInt32(0), appName = sQLiteDataReader.GetString(1), password = sQLiteDataReader.GetString(2), username = sQLiteDataReader.GetString(3) });
            }
            this.connectionDb.Close();
            return passwordManagers;
        }

        public void insertPassword(string appName, string username, string password)
        {
            SQLiteCommand cmd = this.connectionDb.CreateCommand();
            string insertUser = "INSERT INTO pswManager (sitename, password, username) VALUES ($sitename, $password, $username);";
            cmd.CommandText = insertUser;
            cmd.Parameters.AddWithValue("$username", username);
            cmd.Parameters.AddWithValue("$password", password);
            cmd.Parameters.AddWithValue("$sitename", appName);
            cmd.ExecuteNonQuery();
            this.connectionDb.Close();
        }

        public bool checkIfExistUser()
        {
            SQLiteCommand cmd = this.connectionDb.CreateCommand();
            SQLiteDataReader sQLiteDataReader;
            string checkUser = "SELECT * FROM users";
            cmd.CommandText = checkUser;
            sQLiteDataReader = cmd.ExecuteReader();
            string dbUsername = "";
            while (sQLiteDataReader.Read())
            {
                dbUsername = sQLiteDataReader.GetString(0);
            }
            if (!string.IsNullOrEmpty(dbUsername)) return true;
            else return false;
        }

        public void updateDetail(string appName, string username, string password, int id)
        {
            SQLiteCommand cmd = this.connectionDb.CreateCommand();
            string updateDetailInfo = "UPDATE pswManager SET sitename = $sitename, password = $password, username = $username WHERE id = $idDetail";
            cmd.CommandText = updateDetailInfo;
            cmd.Parameters.AddWithValue("$username", username);
            cmd.Parameters.AddWithValue("$password", password);
            cmd.Parameters.AddWithValue("$sitename", appName);
            cmd.Parameters.AddWithValue("$idDetail", id);
            cmd.ExecuteNonQuery();
            this.connectionDb.Close();
        }
    }
}
