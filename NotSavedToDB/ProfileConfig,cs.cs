using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotSavedToDB
{
    public class ProfileConfig
    {
        public string Server { get; set; }
        public string Database { get; set; }
        public string SourceSqlitePath { get; set; }
        public string SourceSqlServer { get; set; }
        public string SourceSqlDatabase { get; set; }

        public string DestinationSqlitePath { get; set; }
        public string DestinationSqlServer { get; set; }
        public string DestinationSqlDatabase { get; set; }

        public bool IsSourceSqlite { get; set; }
        public bool IsSourceSqlServer { get; set; }
        public bool IsDestinationSqlite { get; set; }
        public bool IsDestinationSqlServer { get; set; }

        public bool ModeInsertAll { get; set; }
        public bool ModeCompareOnly { get; set; }
        public bool ModeInsertMissing { get; set; }

        public bool ExecuteGenerateInsertFile { get; set; }
        public bool ExecuteUpsert { get; set; }

        public List<TableConfig> Tables { get; set; } = new List<TableConfig>();
    }

    public class TableConfig
    {
        public string TabelaDestino { get; set; }
        public string CamposChave { get; set; }
        public string SelectSQLite { get; set; }
    }
}
