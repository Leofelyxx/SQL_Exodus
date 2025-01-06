using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQL_Exodus.Models
{
    public class DatabasesEnum
    {
        public enum Databases
        {
            [Description("SQL Server - Local")]
            SQL_Server_Local,
            [Description("SQL Server - Remoto")]
            SQL_Server_Remote,
            [Description("MySQL")]
            MySQL,
            [Description("Postgre SQL")]
            PostgreSQL,
        }

        public static string GetDescription(Databases status)
        {
            var field = status.GetType().GetField(status.ToString());
            var attribute = (DescriptionAttribute)Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute));
            return attribute == null ? status.ToString() : attribute.Description;
        }

        public static string GetName(Databases status)
        {
            return status.ToString();
        }

        public static int GetValue(Databases status)
        {
            return (int)status;
        }
    }
}
