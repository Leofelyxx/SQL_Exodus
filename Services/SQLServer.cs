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

        public List<string> databaseNames = new List<string>();
        private string _ConnectionStringServer
        {
            get
            {
                return $"Server={_ServerName};Database=master;{(_WindowsAuthentication ? "Integrated Security=True;" : $"User Id={_User};Password={_Password};")};Encrypt=True;TrustServerCertificate=True;";
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
            
            try
            {
                using var connection = new SqlConnection(_ConnectionStringServer);
                connection.Open();

                const string query = "SELECT name FROM sys.databases WHERE user_access = 0 AND state = 0";
                using var command = new SqlCommand(query, connection);
                using var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    databaseNames.Add(reader.GetString(0)); // Acessa a primeira coluna diretamente como string
                }
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao conectar ao servidor: {ex.Message}");
            }

            return false;
        }

    }
}
