using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SQLite;


namespace ProjetoTccConnect
{
    public class ConnectDB
    {
        private SQLiteConnection connection;
        private String server;
        private String database;
        private String uid;
        private String password;

        public object MessageBox { get; private set; }
        public SQLiteConnection Connection { get => connection; set => connection = value; }
        public string Server { get => server; set => server = value; }
        public string Database { get => database; set => database = value; }
        public string Uid { get => uid; set => uid = value; }
        public string Password { get => password; set => password = value; }

        //construtor
        public ConnectDB()
        {
            Initialize();
        }

        //public void Initialize()
        //{
        //    Server = "localhost";
        //    Database = "lostserver";
        //    Uid = "root@localhost";
        //    Password = "";
        //    String connectionString;
        //    connectionString = "SERVER=" + Server + ";" + "DATABASE=" + Database + ";" + "UID=" + Uid + ";" + "PASSWORD=" + Password + ";";

        //    Connection = new SQLiteConnection(connectionString);
        //}

        public void Initialize()
        {
            String connectionString;
            //connectionString = "Data Source=C:\\Users\\rhenriques\\source\\repos\\TccProject\\TccProject\\LocalBase.db";
            connectionString = Utilidade.GetStringConfiguracao("Diretorio.Banco");

            Connection = new SQLiteConnection(connectionString);
        }

        //open connection to database
        public bool OpenConnection()
        {
            try
            {
                Connection.Open();
                return true;
            }
            catch (SQLiteException ex)
            {
                //When handling errors, you can your application's response based 
                //on the error number.
                //The two most common error numbers when connecting are as follows:
                //0: Cannot connect to server.
                //1045: Invalid user name and/or password.
                switch (ex.ErrorCode)
                {
                    case 0:
                        MessageBox = ("Cannot connect to server.  Contact administrator");
                        break;

                    case 1045:
                        MessageBox = ("Invalid username/password, please try again");
                        break;
                }
                return false;
            }
        }

        //Close connection
        public bool CloseConnection()
        {
            try
            {
                Connection.Close();
                return true;
            }
            catch (SQLiteException ex)
            {
                MessageBox = (ex.Message);
                return false;
            }
        }
    }
}