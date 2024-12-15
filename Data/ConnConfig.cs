using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public static class ConnConfig
    {
        public const string _databaseFilePath = "../../../../myDB.db";
        public const string _connectionString = $"Data Source={_databaseFilePath};Version=3;";
    }
}
