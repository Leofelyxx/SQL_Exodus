using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQL_Exodus.Services
{
    internal class SQLServer
    {
        string _ServerName { get; set; }
        string _User { get; set; }
        string _Password { get; set; }
        bool _WindowsAuthentication { get; set; }
        private bool _IsConnected { set; get; }
        private string _ConnectionStringServer
        {
            get
            {
                return $"Server=${_ServerName};Database=master;{(_WindowsAuthentication ? "Integrated Security=True;" : $"User Id={_User};Password={_Password};")}";
            }
        }
        List<string> _Databases { get; set; }
        public SQLServer(string ServerName, bool WindowsAuthentication, string User, string Password)
        {
            _ServerName = ServerName;
            _User = User;
            _Password = Password;
            _WindowsAuthentication = WindowsAuthentication;
        }

        public bool FirstConnection()
        {
            bool connected = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(_ConnectionStringServer))
                {
                    connection.Open();
                    string query = "SELECT name FROM sys.databases WHERE user_access = 0 AND state = 0";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ocorreu um erro ao tentar se conectar ao servidor: " + ex.Message);
            }
            return connected;
        }
    }
}
