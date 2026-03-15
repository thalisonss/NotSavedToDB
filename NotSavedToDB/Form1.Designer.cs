namespace NotSavedToDB
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblSelectDBSQLite = new Label();
            btnSelectDBSQLite = new Button();
            txtLoadFileDBSQLite = new TextBox();
            dataGridView1 = new DataGridView();
            colTabelaDestino = new DataGridViewTextBoxColumn();
            colCamposChave = new DataGridViewTextBoxColumn();
            colSelectSQLite = new DataGridViewTextBoxColumn();
            colTestSelect = new DataGridViewButtonColumn();
            btnCompararBanco = new Button();
            txtBanco = new TextBox();
            txtServidor = new TextBox();
            btnGenerateInsertScript = new Button();
            btnSaveProfile = new Button();
            btnLoadProfile = new Button();
            rbInsertMissing = new RadioButton();
            rbInsertAll = new RadioButton();
            rbCompareOnly = new RadioButton();
            groupBox1 = new GroupBox();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // lblSelectDBSQLite
            // 
            lblSelectDBSQLite.AutoSize = true;
            lblSelectDBSQLite.Location = new Point(25, 41);
            lblSelectDBSQLite.Name = "lblSelectDBSQLite";
            lblSelectDBSQLite.Size = new Size(106, 20);
            lblSelectDBSQLite.TabIndex = 0;
            lblSelectDBSQLite.Text = "Selecionar .db:";
            // 
            // btnSelectDBSQLite
            // 
            btnSelectDBSQLite.Location = new Point(137, 37);
            btnSelectDBSQLite.Name = "btnSelectDBSQLite";
            btnSelectDBSQLite.Size = new Size(141, 29);
            btnSelectDBSQLite.TabIndex = 1;
            btnSelectDBSQLite.Text = "Carregar Arquivo";
            btnSelectDBSQLite.UseVisualStyleBackColor = true;
            btnSelectDBSQLite.Click += btnSelectDBSQLite_Click;
            // 
            // txtLoadFileDBSQLite
            // 
            txtLoadFileDBSQLite.Location = new Point(284, 37);
            txtLoadFileDBSQLite.Name = "txtLoadFileDBSQLite";
            txtLoadFileDBSQLite.Size = new Size(333, 27);
            txtLoadFileDBSQLite.TabIndex = 2;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { colTabelaDestino, colCamposChave, colSelectSQLite, colTestSelect });
            dataGridView1.Location = new Point(25, 90);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(1323, 244);
            dataGridView1.TabIndex = 3;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            dataGridView1.CellDoubleClick += dataGridView1_CellDoubleClick;
            // 
            // colTabelaDestino
            // 
            colTabelaDestino.HeaderText = "Tabela Destino";
            colTabelaDestino.MinimumWidth = 6;
            colTabelaDestino.Name = "colTabelaDestino";
            colTabelaDestino.Width = 125;
            // 
            // colCamposChave
            // 
            colCamposChave.HeaderText = "Campos Chave (;)";
            colCamposChave.MinimumWidth = 6;
            colCamposChave.Name = "colCamposChave";
            colCamposChave.Width = 125;
            // 
            // colSelectSQLite
            // 
            colSelectSQLite.HeaderText = "SELECT SQLite";
            colSelectSQLite.MinimumWidth = 6;
            colSelectSQLite.Name = "colSelectSQLite";
            colSelectSQLite.Width = 125;
            // 
            // colTestSelect
            // 
            colTestSelect.HeaderText = "Teste";
            colTestSelect.MinimumWidth = 6;
            colTestSelect.Name = "colTestSelect";
            colTestSelect.Width = 125;
            // 
            // btnCompararBanco
            // 
            btnCompararBanco.Location = new Point(1030, 522);
            btnCompararBanco.Name = "btnCompararBanco";
            btnCompararBanco.Size = new Size(171, 29);
            btnCompararBanco.TabIndex = 4;
            btnCompararBanco.Text = "Comparar com banco";
            btnCompararBanco.UseVisualStyleBackColor = true;
            btnCompararBanco.Click += btnCompararBanco_Click;
            // 
            // txtBanco
            // 
            txtBanco.Location = new Point(490, 522);
            txtBanco.Name = "txtBanco";
            txtBanco.Size = new Size(356, 27);
            txtBanco.TabIndex = 5;
            // 
            // txtServidor
            // 
            txtServidor.Location = new Point(25, 522);
            txtServidor.Name = "txtServidor";
            txtServidor.Size = new Size(377, 27);
            txtServidor.TabIndex = 6;
            // 
            // btnGenerateInsertScript
            // 
            btnGenerateInsertScript.Location = new Point(1207, 522);
            btnGenerateInsertScript.Name = "btnGenerateInsertScript";
            btnGenerateInsertScript.Size = new Size(141, 29);
            btnGenerateInsertScript.TabIndex = 7;
            btnGenerateInsertScript.Text = "Gerar Inserts";
            btnGenerateInsertScript.UseVisualStyleBackColor = true;
            btnGenerateInsertScript.Click += btnGenerateInsertScript_Click;
            // 
            // btnSaveProfile
            // 
            btnSaveProfile.Location = new Point(906, 37);
            btnSaveProfile.Name = "btnSaveProfile";
            btnSaveProfile.Size = new Size(141, 29);
            btnSaveProfile.TabIndex = 8;
            btnSaveProfile.Text = "Salvar Perfil";
            btnSaveProfile.UseVisualStyleBackColor = true;
            btnSaveProfile.Click += btnSaveProfile_Click;
            // 
            // btnLoadProfile
            // 
            btnLoadProfile.Location = new Point(698, 37);
            btnLoadProfile.Name = "btnLoadProfile";
            btnLoadProfile.Size = new Size(176, 29);
            btnLoadProfile.TabIndex = 9;
            btnLoadProfile.Text = "Carregar Perfil";
            btnLoadProfile.UseVisualStyleBackColor = true;
            btnLoadProfile.Click += btnLoadProfile_Click;
            // 
            // rbInsertMissing
            // 
            rbInsertMissing.AutoSize = true;
            rbInsertMissing.Location = new Point(12, 46);
            rbInsertMissing.Name = "rbInsertMissing";
            rbInsertMissing.Size = new Size(117, 24);
            rbInsertMissing.TabIndex = 10;
            rbInsertMissing.TabStop = true;
            rbInsertMissing.Text = "radioButton1";
            rbInsertMissing.UseVisualStyleBackColor = true;
            // 
            // rbInsertAll
            // 
            rbInsertAll.AutoSize = true;
            rbInsertAll.Location = new Point(135, 46);
            rbInsertAll.Name = "rbInsertAll";
            rbInsertAll.Size = new Size(117, 24);
            rbInsertAll.TabIndex = 11;
            rbInsertAll.TabStop = true;
            rbInsertAll.Text = "radioButton1";
            rbInsertAll.UseVisualStyleBackColor = true;
            // 
            // rbCompareOnly
            // 
            rbCompareOnly.AutoSize = true;
            rbCompareOnly.Location = new Point(258, 46);
            rbCompareOnly.Name = "rbCompareOnly";
            rbCompareOnly.Size = new Size(117, 24);
            rbCompareOnly.TabIndex = 12;
            rbCompareOnly.TabStop = true;
            rbCompareOnly.Text = "radioButton1";
            rbCompareOnly.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(rbInsertMissing);
            groupBox1.Controls.Add(rbCompareOnly);
            groupBox1.Controls.Add(rbInsertAll);
            groupBox1.Location = new Point(25, 357);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(419, 103);
            groupBox1.TabIndex = 13;
            groupBox1.TabStop = false;
            groupBox1.Text = "groupBox1";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1360, 561);
            Controls.Add(groupBox1);
            Controls.Add(btnLoadProfile);
            Controls.Add(btnSaveProfile);
            Controls.Add(btnGenerateInsertScript);
            Controls.Add(txtServidor);
            Controls.Add(txtBanco);
            Controls.Add(btnCompararBanco);
            Controls.Add(dataGridView1);
            Controls.Add(txtLoadFileDBSQLite);
            Controls.Add(btnSelectDBSQLite);
            Controls.Add(lblSelectDBSQLite);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblSelectDBSQLite;
        private Button btnSelectDBSQLite;
        private TextBox txtLoadFileDBSQLite;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn colTabelaDestino;
        private DataGridViewTextBoxColumn colCamposChave;
        private DataGridViewTextBoxColumn colSelectSQLite;
        private DataGridViewButtonColumn colTestSelect;
        private Button btnCompararBanco;
        private TextBox txtBanco;
        private TextBox txtServidor;
        private Button btnGenerateInsertScript;
        private Button btnSaveProfile;
        private Button btnLoadProfile;
        private RadioButton rbInsertMissing;
        private RadioButton rbInsertAll;
        private RadioButton rbCompareOnly;
        private GroupBox groupBox1;
    }
}
