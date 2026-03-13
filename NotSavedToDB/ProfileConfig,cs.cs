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

        public List<TableConfig> Tables { get; set; } = new List<TableConfig>();
    }

    public class TableConfig
    {
        public string TabelaDestino { get; set; }
        public string CamposChave { get; set; }
        public string SelectSQLite { get; set; }
    }
}
