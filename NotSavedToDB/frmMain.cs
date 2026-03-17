using Microsoft.Data.SqlClient;
using Microsoft.Data.Sqlite;
using SQLitePCL;
using System.Data;
using System.Text;
using System.Text.Json;


namespace NotSavedToDB
{
    public partial class frmMain : Form
    {
        public frmMain()
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
            progressBarProcess.Value = 0;
            progressBarProcess.Maximum = dataGridView1.Rows.Count;

            string outputFile = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
                "NotSavedToDB_Insert.sql");

            if (File.Exists(outputFile))
                File.Delete(outputFile);

            using StreamWriter sw = new StreamWriter(outputFile, true);

            int progress = 0;

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.IsNewRow)
                    continue;

                progress++;
                progressBarProcess.Value = progress;
                Application.DoEvents();

                string tabelaDestino = row.Cells["colTabelaDestino"].Value?.ToString();
                string camposChave = row.Cells["colCamposChave"].Value?.ToString();
                string selectSource = row.Cells["colSelectSQLite"].Value?.ToString();

                if (string.IsNullOrWhiteSpace(tabelaDestino) ||
                    string.IsNullOrWhiteSpace(camposChave) ||
                    string.IsNullOrWhiteSpace(selectSource))
                    continue;

                string[] chaves = camposChave.Split(';');

                // =========================
                // ORIGEM
                // =========================
                DataTable sourceData = LoadSourceData(selectSource);

                // =========================
                // KEY TABLE
                // =========================
                DataTable keyTable = new DataTable();

                foreach (var chave in chaves)
                    keyTable.Columns.Add(chave);

                foreach (DataRow dr in sourceData.Rows)
                {
                    var newRow = keyTable.NewRow();

                    foreach (var chave in chaves)
                        newRow[chave] = dr[chave];

                    keyTable.Rows.Add(newRow);
                }

                // =========================
                // DESTINO
                // =========================
                using IDbConnection conn = GetDestinationConnection();
                conn.Open();

                string tempTable = "TempKeys_" + Guid.NewGuid().ToString("N");

                CreateTempTable(conn, tempTable, chaves);

                // 🔥 AQUI ESTÁ A CORREÇÃO DO ERRO
                InsertKeysSmart(conn, tempTable, keyTable, chaves);

                string compareQuery = BuildCompareQuery(tempTable, tabelaDestino, chaves);

                List<string> missingKeys = new List<string>();

                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = compareQuery;

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

                // =========================
                // GERAR INSERT
                // =========================
                sw.WriteLine($"-- {tabelaDestino}");

                foreach (DataRow dr in sourceData.Rows)
                {
                    string key = string.Join("|", chaves.Select(c => dr[c].ToString()));

                    if (!missingKeys.Contains(key))
                        continue;

                    List<string> columns = new List<string>();
                    List<string> values = new List<string>();

                    foreach (DataColumn col in sourceData.Columns)
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

            MessageBox.Show("Processo finalizado.");
        }

        private string BuildCompareQuery(string tempTable, string tabelaDestino, string[] chaves)
        {
            var join = new StringBuilder();

            for (int i = 0; i < chaves.Length; i++)
            {
                join.Append($"t.{chaves[i]} = s.{chaves[i]}");

                if (i < chaves.Length - 1)
                    join.Append(" AND ");
            }

            return $@"
SELECT s.*
FROM {tempTable} s
WHERE NOT EXISTS
(
    SELECT 1
    FROM {tabelaDestino} t
    WHERE {join}
)";
        }

        private void CreateTempTable(IDbConnection conn, string tempTable, string[] chaves)
        {
            var sb = new StringBuilder();

            sb.Append($"CREATE TABLE {tempTable} (");

            for (int i = 0; i < chaves.Length; i++)
            {
                sb.Append($"{chaves[i]} TEXT");

                if (i < chaves.Length - 1)
                    sb.Append(",");
            }

            sb.Append(")");

            using var cmd = conn.CreateCommand();
            cmd.CommandText = sb.ToString();
            cmd.ExecuteNonQuery();
        }

        private void InsertKeysSmart(IDbConnection conn, string tempTable, DataTable keyTable, string[] chaves)
        {
            if (conn is SqlConnection sqlConn)
            {
                using (var bulk = new SqlBulkCopy(sqlConn))
                {
                    bulk.DestinationTableName = tempTable;

                    foreach (var chave in chaves)
                        bulk.ColumnMappings.Add(chave, chave);

                    bulk.WriteToServer(keyTable);
                }
            }
            else
            {
                // SQLite → INSERT com transaction (rápido)
                using var transaction = conn.BeginTransaction();

                foreach (DataRow dr in keyTable.Rows)
                {
                    List<string> values = new List<string>();

                    foreach (var item in dr.ItemArray)
                    {
                        if (item == DBNull.Value)
                            values.Add("NULL");
                        else
                            values.Add($"'{item.ToString().Replace("'", "''")}'");
                    }

                    string sql = $"INSERT INTO {tempTable} VALUES ({string.Join(",", values)})";

                    using var cmd = conn.CreateCommand();
                    cmd.CommandText = sql;
                    cmd.Transaction = transaction;
                    cmd.ExecuteNonQuery();
                }

                transaction.Commit();
            }
        }

        private void InsertKeys(IDbConnection conn, string tempTable, DataTable keyTable)
        {
            foreach (DataRow dr in keyTable.Rows)
            {
                List<string> values = new List<string>();

                foreach (var item in dr.ItemArray)
                {
                    if (item == DBNull.Value)
                        values.Add("NULL");
                    else
                        values.Add($"'{item.ToString().Replace("'", "''")}'");
                }

                string sql = $"INSERT INTO {tempTable} VALUES ({string.Join(",", values)})";

                using var cmd = conn.CreateCommand();
                cmd.CommandText = sql;
                cmd.ExecuteNonQuery();
            }
        }

        private IDbConnection GetDestinationConnection()
        {
            if (rbDBSQLServerDestino.Checked)
            {
                return new SqlConnection(
                    $"Server={txtServidor.Text};Database={txtBanco.Text};Trusted_Connection=True;TrustServerCertificate=True;");
            }
            else
            {
                return new SqliteConnection($"Data Source={txtLoadFileDBSQLiteDestino.Text}");
            }
        }

        private void GenerateInsertAll()
        {

        }




        private void btnGenerateInsertScript_Click(object sender, EventArgs e)
        {
            if (rdGenerateFileInsert.Checked)
            {
                GenerateInsertScript();
            }
            else if (rdUPSERT.Checked)
            {
                ExecuteUpsert();
            }


        }
        private void ExecuteUpsertSqlServer(
    SqlConnection conn,
    string tabelaDestino,
    DataTable sourceData,
    string[] chaves)
        {
            foreach (DataRow dr in sourceData.Rows)
            {
                List<string> updateSet = new List<string>();
                List<string> columns = new List<string>();
                List<string> values = new List<string>();
                List<string> onConditions = new List<string>();

                foreach (DataColumn col in sourceData.Columns)
                {
                    string colName = col.ColumnName;

                    string value;

                    if (colName.Equals("mc1LastUpdate", StringComparison.OrdinalIgnoreCase))
                        value = "GETDATE()";
                    else if (dr[col] == DBNull.Value)
                        value = "NULL";
                    else
                    {
                        var val = dr[col].ToString().Replace(",", ".").Replace("'", "''");
                        value = $"'{val}'";
                    }

                    columns.Add(colName);
                    values.Add(value);

                    if (!chaves.Contains(colName))
                        updateSet.Add($"target.{colName} = {value}");
                }

                foreach (var chave in chaves)
                {
                    var val = dr[chave].ToString().Replace("'", "''");
                    onConditions.Add($"target.{chave} = '{val}'");
                }

                string merge = $@"
MERGE INTO {tabelaDestino} AS target
USING (SELECT 1 AS dummy) AS source
ON ({string.Join(" AND ", onConditions)})
WHEN MATCHED THEN 
    UPDATE SET {string.Join(",", updateSet)}
WHEN NOT MATCHED THEN
    INSERT ({string.Join(",", columns)})
    VALUES ({string.Join(",", values)});
";

                using var cmd = new SqlCommand(merge, conn);
                cmd.ExecuteNonQuery();
            }
        }

        private void ExecuteUpsertSqlite(
    SqliteConnection conn,
    string tabelaDestino,
    DataTable sourceData,
    string[] chaves)
        {
            foreach (DataRow dr in sourceData.Rows)
            {
                List<string> columns = new List<string>();
                List<string> values = new List<string>();
                List<string> updates = new List<string>();

                foreach (DataColumn col in sourceData.Columns)
                {
                    string colName = col.ColumnName;

                    string value;

                    if (colName.Equals("mc1LastUpdate", StringComparison.OrdinalIgnoreCase))
                        value = "CURRENT_TIMESTAMP";
                    else if (dr[col] == DBNull.Value)
                        value = "NULL";
                    else
                    {
                        var val = dr[col].ToString().Replace(",", ".").Replace("'", "''");
                        value = $"'{val}'";
                    }

                    columns.Add(colName);
                    values.Add(value);

                    if (!chaves.Contains(colName))
                        updates.Add($"{colName} = {value}");
                }

                string sql = $@"
INSERT INTO {tabelaDestino} ({string.Join(",", columns)})
VALUES ({string.Join(",", values)})
ON CONFLICT({string.Join(",", chaves)})
DO UPDATE SET {string.Join(",", updates)};
";

                using var cmd = new SqliteCommand(sql, conn);
                cmd.ExecuteNonQuery();
            }
        }

        private void ExecuteUpsert(
    IDbConnection conn,
    string tabelaDestino,
    DataTable sourceData,
    string[] chaves)
        {
            if (conn is SqlConnection sqlConn)
            {
                ExecuteUpsertSqlServer(sqlConn, tabelaDestino, sourceData, chaves);
            }
            else if (conn is SqliteConnection sqliteConn)
            {
                ExecuteUpsertSqlite(sqliteConn, tabelaDestino, sourceData, chaves);
            }
        }

        private void GenerateInsertScript()
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

            lblProfile.Text = $"Perfil: {Path.GetFileNameWithoutExtension(dialog.FileName)}";
            MessageBox.Show("Perfil carregado.");
        }


        private DataTable LoadSourceData(string selectQuery)
        {
            DataTable dt = new DataTable();

            if (rbDBOrigem.Checked)
            {
                using var conn = new SqliteConnection($"Data Source={txtLoadFileDBSQLite.Text}");
                conn.Open();

                using var cmd = new SqliteCommand(selectQuery, conn);
                using var reader = cmd.ExecuteReader();

                dt.Load(reader);
            }
            else
            {
                using var conn = new SqlConnection(
                    $"Server={txtServerOrigem.Text};Database={txtDBOrigem.Text};Trusted_Connection=True;TrustServerCertificate=True;");

                conn.Open();

                using var cmd = new SqlCommand(selectQuery, conn);
                using var reader = cmd.ExecuteReader();

                dt.Load(reader);
            }

            return dt;
        }

        private void btnSelectDBSQLiteDestino_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();

            dialog.Title = "Selecionar banco SQLite";
            dialog.Filter = "SQLite Database (*.db)|*.db|Todos os arquivos (*.*)|*.*";
            dialog.Multiselect = false;

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                txtLoadFileDBSQLiteDestino.Text = dialog.FileName;
            }
        }
    }
}
