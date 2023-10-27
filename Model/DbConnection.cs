using MySql.Data.MySqlClient;
using System;

namespace QuanLyKhoHang.Model
{
    public class DbConnection
    {
        private string _host = "localhost";
        private string _database = "csharp_kho";
        private string _username = "root";
        private string _password = "";
        public MySqlConnection Connection { get; set; }

        public DbConnection() { }

        private static DbConnection _instance = null;
        public static DbConnection Instance()
        {
            if (_instance == null)
                _instance = new DbConnection();
            return _instance;
        }

        public bool IsConnect()
        {
            if (Connection == null)
            {
                if (String.IsNullOrEmpty(_database))
                {
                    return false;
                }

                string connstring = string.Format("Server={0}; database={1}; UID={2}; password={3}", _host, _database, _username, _password);

                try
                {
                    Connection = new MySqlConnection(connstring);
                    Connection.Open();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Lỗi kết nối đến CSDL: " + ex.Message);
                    return false;
                }
            }

            return true;
        }

        public void Close()
        {
            if (Connection != null)
            {
                Connection.Close();
                Connection = null;
            }
        }
    }
}
