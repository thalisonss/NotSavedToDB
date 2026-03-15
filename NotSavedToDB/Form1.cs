using Microsoft.Data.SqlClient;
using Microsoft.Data.Sqlite;
using SQLitePCL;
using System.Data;
using System.Text;
using System.Text.Json;


namespace NotSavedToDB
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSelectDBSQLite_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();

            dialog.Title = "Selecionar banco SQLite";
            dialog.Filter = "SQLite Database (*.db)|*.db|Todos os arquivos (*.*)|*.*";
            dialog.Multiselect = false;

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                txtLoadFileDBSQLite.Text = dialog.FileName;
            }
        }

        public class SyncConfig
        {
            public string TabelaDestino { get; set; }
            public string CamposChave { get; set; }
            public string SelectSQLite { get; set; }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.Columns["colSelectSQLite"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            if (dataGridView1.Columns[e.ColumnIndex].Name == "colSelectSQLite")
            {
                string sqlAtual = dataGridView1.Rows[e.RowIndex]
                    .Cells["colSelectSQLite"]
                    .Value?.ToString();

                using (frmSQLEditor editor = new frmSQLEditor())
                {
                    editor.SqlText = sqlAtual;

                    if (editor.ShowDialog() == DialogResult.OK)
                    {
                        dataGridView1.Rows[e.RowIndex]
                            .Cells["colSelectSQLite"]
                            .Value = editor.SqlText;
                    }
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            if (dataGridView1.Columns[e.ColumnIndex].Name == "colTestSelect")
            {
                string select = dataGridView1.Rows[e.RowIndex]
                    .Cells["colSelectSQLite"]
                    .Value?.ToString();

                if (string.IsNullOrWhiteSpace(select))
                {
                    MessageBox.Show("Informe um SELECT primeiro.");
                    return;
                }

                ExecuteSQLiteSelect(select);
            }


        }

        private void ExecuteSQLiteSelect(string select)
        {
            string path = txtLoadFileDBSQLite.Text;

            if (!File.Exists(path))
            {
                MessageBox.Show("Arquivo SQLite não encontrado.");
                return;
            }

            string connString = $"Data Source={path}";

            DataTable dt = new DataTable();

            using (var conn = new SqliteConnection(connString))
            {
                conn.Open();

                using (var cmd = new SqliteCommand(select, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    dt.Load(reader);
                }
            }

            FrmSQLiteResult frm = new FrmSQLiteResult();
            frm.LoadData(dt);
            frm.ShowDialog();
        }

        private List<string> CompareKeys(
    DataTable sqliteData,
    string tabelaDestino,
    string[] chaves,
    string connSqlServer)
        {
            List<string> missingKeys = new List<string>();

            HashSet<string> sqlServerKeys = new HashSet<string>();

            using (var conn = new SqlConnection(connSqlServer))
            {
                conn.Open();

                string cols = string.Join(",", chaves);

                string query = $"SELECT {cols} FROM {tabelaDestino}";

                using (var cmd = new SqlCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        List<string> keyParts = new List<string>();

                        foreach (var c in chaves)
                            keyParts.Add(reader[c].ToString());

                        sqlServerKeys.Add(string.Join("|", keyParts));
                    }
                }
            }

            foreach (DataRow row in sqliteData.Rows)
            {
                List<string> keyParts = new List<string>();

                foreach (var c in chaves)
                    keyParts.Add(row[c].ToString());

                string key = string.Join("|", keyParts);

                if (!sqlServerKeys.Contains(key))
                    missingKeys.Add(key);
            }

            return missingKeys;
        }

    private void GenerateInsertMissing()
    {
            if (string.IsNullOrWhiteSpace(txtLoadFileDBSQLite.Text))
            {
                MessageBox.Show("Selecione o banco SQLite.");
                return;
            }

            string sqlitePath = txtLoadFileDBSQLite.Text;

            string connSqlServer =
                $"Server={txtServidor.Text};Database={txtBanco.Text};Trusted_Connection=True;TrustServerCertificate=True;";

            string outputFile = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
                "NotSavedToDB_Insert.sql");

            if (File.Exists(outputFile))
                File.Delete(outputFile);

            using StreamWriter sw = new StreamWriter(outputFile, true);

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.IsNewRow)
                    continue;

                string tabelaDestino = row.Cells["colTabelaDestino"].Value?.ToString();
                string camposChave = row.Cells["colCamposChave"].Value?.ToString();
                string selectSQLite = row.Cells["colSelectSQLite"].Value?.ToString();

                if (string.IsNullOrWhiteSpace(tabelaDestino) ||
                    string.IsNullOrWhiteSpace(camposChave) ||
                    string.IsNullOrWhiteSpace(selectSQLite))
                    continue;

                string[] chaves = camposChave.Split(';');

                // ===============================
                // Executar SELECT no SQLite
                // ===============================

                DataTable sqliteData = new DataTable();

                using (var conn = new SqliteConnection($"Data Source={sqlitePath}"))
                {
                    conn.Open();

                    using var cmd = new SqliteCommand(selectSQLite, conn);
                    using var reader = cmd.ExecuteReader();

                    sqliteData.Load(reader);
                }

                // ===============================
                // Criar tabela apenas com chaves
                // ===============================

                DataTable keyTable = new DataTable();

                foreach (var chave in chaves)
                    keyTable.Columns.Add(chave);

                foreach (DataRow dr in sqliteData.Rows)
                {
                    var newRow = keyTable.NewRow();

                    foreach (var chave in chaves)
                        newRow[chave] = dr[chave];

                    keyTable.Rows.Add(newRow);
                }

                using var sqlConn = new SqlConnection(connSqlServer);
                sqlConn.Open();

                string tempTable = "#TempKeys";

                // ===============================
                // Criar temp table
                // ===============================

                StringBuilder createSql = new StringBuilder();
                createSql.Append($"CREATE TABLE {tempTable} (");

                for (int i = 0; i < chaves.Length; i++)
                {
                    createSql.Append($"{chaves[i]} NVARCHAR(200)");

                    if (i < chaves.Length - 1)
                        createSql.Append(",");
                }

                createSql.Append(")");

                using (var cmd = new SqlCommand(createSql.ToString(), sqlConn))
                    cmd.ExecuteNonQuery();

                // ===============================
                // Criar índice
                // ===============================

                string indexCols = string.Join(",", chaves);

                using (var cmd = new SqlCommand($"CREATE INDEX IX_TempKeys ON {tempTable} ({indexCols})", sqlConn))
                    cmd.ExecuteNonQuery();

                // ===============================
                // Bulk insert das chaves
                // ===============================

                using (var bulk = new SqlBulkCopy(sqlConn))
                {
                    bulk.DestinationTableName = tempTable;

                    foreach (var chave in chaves)
                        bulk.ColumnMappings.Add(chave, chave);

                    bulk.WriteToServer(keyTable);
                }

                // ===============================
                // Montar JOIN
                // ===============================

                StringBuilder join = new StringBuilder();

                for (int i = 0; i < chaves.Length; i++)
                {
                    join.Append($"t.{chaves[i]} = s.{chaves[i]}");

                    if (i < chaves.Length - 1)
                        join.Append(" AND ");
                }

                string compareQuery = $@"
SELECT s.*
FROM {tempTable} s
WHERE NOT EXISTS
(
    SELECT 1
    FROM {tabelaDestino} t
    WHERE {join}
)";

                List<string> missingKeys = new List<string>();

                using (var cmd = new SqlCommand(compareQuery, sqlConn))
                {
                    cmd.CommandTimeout = 300;

                    using var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        List<string> keyParts = new List<string>();

                        foreach (var chave in chaves)
                            keyParts.Add(reader[chave].ToString());

                        missingKeys.Add(string.Join("|", keyParts));
                    }
                }

                if (missingKeys.Count == 0)
                    continue;

                // ===============================
                // Gerar INSERT
                // ===============================

                sw.WriteLine($"-- {tabelaDestino}");

                foreach (DataRow dr in sqliteData.Rows)
                {
                    List<string> keyParts = new List<string>();

                    foreach (var chave in chaves)
                        keyParts.Add(dr[chave].ToString());

                    string key = string.Join("|", keyParts);

                    if (!missingKeys.Contains(key))
                        continue;

                    List<string> columns = new List<string>();
                    List<string> values = new List<string>();

                    foreach (DataColumn col in sqliteData.Columns)
                    {
                        string columnName = col.ColumnName;
                        columns.Add(columnName);

                        // REGRA mc1LastUpdate
                        if (columnName.Equals("mc1LastUpdate", StringComparison.OrdinalIgnoreCase))
                        {
                            values.Add("GETDATE()");
                            continue;
                        }

                        object value = dr[col];

                        if (value == DBNull.Value)
                        {
                            values.Add("NULL");
                        }
                        else
                        {
                            string val = value.ToString();

                            // Converter decimal com vírgula para ponto
                            if (decimal.TryParse(val, out _))
                            {
                                val = val.Replace(",", ".");
                            }

                            // escapar aspas
                            val = val.Replace("'", "''");

                            values.Add($"'{val}'");
                        }
                    }

                    string insert =
                        $"INSERT INTO {tabelaDestino} ({string.Join(",", columns)}) VALUES ({string.Join(",", values)});";

                    sw.WriteLine(insert);
                }

                sw.WriteLine();
            }

            sw.Close();

            MessageBox.Show($"Script gerado em:\n{outputFile}");
        }

        private void GenerateInsertAll()
        {
            string sqlitePath = txtLoadFileDBSQLite.Text;

            string outputFile = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
                "Insert_All.sql");

            using StreamWriter sw = new StreamWriter(outputFile);

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.IsNewRow)
                    continue;

                string tabelaDestino = row.Cells["colTabelaDestino"].Value?.ToString();
                string selectSQLite = row.Cells["colSelectSQLite"].Value?.ToString();

                if (string.IsNullOrWhiteSpace(tabelaDestino) ||
                    string.IsNullOrWhiteSpace(selectSQLite))
                    continue;

                DataTable sqliteData = new DataTable();

                using (var conn = new SqliteConnection($"Data Source={sqlitePath}"))
                {
                    conn.Open();

                    using var cmd = new SqliteCommand(selectSQLite, conn);
                    using var reader = cmd.ExecuteReader();

                    sqliteData.Load(reader);
                }

                sw.WriteLine($"-- {tabelaDestino}");

                foreach (DataRow dr in sqliteData.Rows)
                {
                    List<string> columns = new List<string>();
                    List<string> values = new List<string>();

                    foreach (DataColumn col in sqliteData.Columns)
                    {
                        string columnName = col.ColumnName;

                        columns.Add(columnName);

                        if (columnName.Equals("mc1LastUpdate", StringComparison.OrdinalIgnoreCase))
                        {
                            values.Add("GETDATE()");
                            continue;
                        }

                        object value = dr[col];

                        if (value == DBNull.Value)
                        {
                            values.Add("NULL");
                        }
                        else
                        {
                            string val = value.ToString();

                            val = val.Replace(",", ".");
                            val = val.Replace("'", "''");

                            values.Add($"'{val}'");
                        }
                    }

                    string insert =
                        $"INSERT INTO {tabelaDestino} ({string.Join(",", columns)}) VALUES ({string.Join(",", values)});";

                    sw.WriteLine(insert);
                }

                sw.WriteLine();
            }

            MessageBox.Show("Script gerado com sucesso.");
        }

        private void GenerateCompareCsv()
        {
            string sqlitePath = txtLoadFileDBSQLite.Text;

            string connSqlServer =
                $"Server={txtServidor.Text};Database={txtBanco.Text};Trusted_Connection=True;TrustServerCertificate=True;";

            string missingFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "missing_keys.csv");
            string existingFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "existing_keys.csv");

            using StreamWriter swMissing = new StreamWriter(missingFile);
            using StreamWriter swExisting = new StreamWriter(existingFile);

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.IsNewRow)
                    continue;

                string tabelaDestino = row.Cells["colTabelaDestino"].Value?.ToString();
                string camposChave = row.Cells["colCamposChave"].Value?.ToString();
                string selectSQLite = row.Cells["colSelectSQLite"].Value?.ToString();

                if (string.IsNullOrWhiteSpace(tabelaDestino) ||
                    string.IsNullOrWhiteSpace(camposChave) ||
                    string.IsNullOrWhiteSpace(selectSQLite))
                    continue;

                string[] chaves = camposChave.Split(';');

                DataTable sqliteData = new DataTable();

                using (var conn = new SqliteConnection($"Data Source={sqlitePath}"))
                {
                    conn.Open();

                    using var cmd = new SqliteCommand(selectSQLite, conn);
                    using var reader = cmd.ExecuteReader();

                    sqliteData.Load(reader);
                }

                swMissing.WriteLine(string.Join(",", chaves));
                swExisting.WriteLine(string.Join(",", chaves));

                using var sqlConn = new SqlConnection(connSqlServer);
                sqlConn.Open();

                foreach (DataRow dr in sqliteData.Rows)
                {
                    List<string> conditions = new List<string>();

                    foreach (var chave in chaves)
                    {
                        string val = dr[chave].ToString().Replace("'", "''");
                        conditions.Add($"{chave} = '{val}'");
                    }

                    string sql = $"SELECT COUNT(1) FROM {tabelaDestino} WHERE {string.Join(" AND ", conditions)}";

                    using var cmd = new SqlCommand(sql, sqlConn);

                    int count = (int)cmd.ExecuteScalar();

                    string keyLine = string.Join(",", chaves.Select(c => dr[c].ToString()));

                    if (count == 0)
                        swMissing.WriteLine(keyLine);
                    else
                        swExisting.WriteLine(keyLine);
                }
            }

            MessageBox.Show("CSV gerado.");
        }


    private void btnGenerateInsertScript_Click(object sender, EventArgs e)
    {
            if (rbInsertMissing.Checked)
            {
                GenerateInsertMissing();
            }
            else if (rbInsertAll.Checked)
            {
                GenerateInsertAll();
            }
            else if (rbCompareOnly.Checked)
            {
                GenerateCompareCsv();
            }
            else
            {
                MessageBox.Show("Selecione um modo de execução.");
            }
    }


    private void btnSaveProfile_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "JSON (*.json)|*.json";
            dialog.Title = "Salvar Perfil";

            if (dialog.ShowDialog() != DialogResult.OK)
                return;

            ProfileConfig profile = new ProfileConfig();

            profile.Server = txtServidor.Text;
            profile.Database = txtBanco.Text;

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.IsNewRow)
                    continue;

                profile.Tables.Add(new TableConfig
                {
                    TabelaDestino = row.Cells["colTabelaDestino"].Value?.ToString(),
                    CamposChave = row.Cells["colCamposChave"].Value?.ToString(),
                    SelectSQLite = row.Cells["colSelectSQLite"].Value?.ToString()
                });
            }

            string json = JsonSerializer.Serialize(profile, new JsonSerializerOptions
            {
                WriteIndented = true
            });

            File.WriteAllText(dialog.FileName, json);

            MessageBox.Show("Perfil salvo com sucesso.");
        }

        private void btnLoadProfile_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "JSON (*.json)|*.json";
            dialog.Title = "Carregar Perfil";

            if (dialog.ShowDialog() != DialogResult.OK)
                return;

            string json = File.ReadAllText(dialog.FileName);

            ProfileConfig profile =
                JsonSerializer.Deserialize<ProfileConfig>(json);

            txtServidor.Text = profile.Server;
            txtBanco.Text = profile.Database;

            dataGridView1.Rows.Clear();

            foreach (var table in profile.Tables)
            {
                dataGridView1.Rows.Add(
                    table.TabelaDestino,
                    table.CamposChave,
                    table.SelectSQLite
                );
            }

            MessageBox.Show("Perfil carregado.");
        }
    }
}
