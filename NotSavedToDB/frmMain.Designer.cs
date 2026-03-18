namespace NotSavedToDB
{
    partial class frmMain
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
            btnGenerateInsertScript = new Button();
            btnSaveProfile = new Button();
            btnLoadProfile = new Button();
            rbInsertMissing = new RadioButton();
            rbInsertAll = new RadioButton();
            rbCompareOnly = new RadioButton();
            groupBox1 = new GroupBox();
            groupBox2 = new GroupBox();
            rbDBSQLServerOrigem = new RadioButton();
            rbDBOrigem = new RadioButton();
            tabControl1 = new TabControl();
            tpDBOrigemSQLite = new TabPage();
            tpDBOrigemSQLServer = new TabPage();
            label3 = new Label();
            txtDBOrigem = new TextBox();
            label4 = new Label();
            txtServerOrigem = new TextBox();
            groupBox3 = new GroupBox();
            lblProfile = new Label();
            groupBox4 = new GroupBox();
            rbDBSQLServerDestino = new RadioButton();
            rbDBDestino = new RadioButton();
            groupBox5 = new GroupBox();
            Executar = new GroupBox();
            rdUPSERT = new RadioButton();
            rdGenerateFileInsert = new RadioButton();
            progressBarProcess = new ProgressBar();
            tabControl2 = new TabControl();
            tpDBOrigemSQLiteDestino = new TabPage();
            txtLoadFileDBSQLiteDestino = new TextBox();
            label1 = new Label();
            btnSelectDBSQLiteDestino = new Button();
            tpDBOrigemSQLServerDestino = new TabPage();
            label2 = new Label();
            txtBanco = new TextBox();
            label5 = new Label();
            txtServidor = new TextBox();
            colTabelaDestino = new DataGridViewTextBoxColumn();
            colCamposChave = new DataGridViewTextBoxColumn();
            colSelectSQLite = new DataGridViewTextBoxColumn();
            colTestSelect = new DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            tabControl1.SuspendLayout();
            tpDBOrigemSQLite.SuspendLayout();
            tpDBOrigemSQLServer.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBox4.SuspendLayout();
            groupBox5.SuspendLayout();
            Executar.SuspendLayout();
            tabControl2.SuspendLayout();
            tpDBOrigemSQLiteDestino.SuspendLayout();
            tpDBOrigemSQLServerDestino.SuspendLayout();
            SuspendLayout();
            // 
            // lblSelectDBSQLite
            // 
            lblSelectDBSQLite.AutoSize = true;
            lblSelectDBSQLite.Location = new Point(3, 26);
            lblSelectDBSQLite.Name = "lblSelectDBSQLite";
            lblSelectDBSQLite.Size = new Size(147, 20);
            lblSelectDBSQLite.TabIndex = 0;
            lblSelectDBSQLite.Text = "Database SQLite .db:";
            // 
            // btnSelectDBSQLite
            // 
            btnSelectDBSQLite.Location = new Point(501, 23);
            btnSelectDBSQLite.Name = "btnSelectDBSQLite";
            btnSelectDBSQLite.Size = new Size(141, 29);
            btnSelectDBSQLite.TabIndex = 1;
            btnSelectDBSQLite.Text = "Carregar Arquivo";
            btnSelectDBSQLite.UseVisualStyleBackColor = true;
            btnSelectDBSQLite.Click += btnSelectDBSQLite_Click;
            // 
            // txtLoadFileDBSQLite
            // 
            txtLoadFileDBSQLite.Enabled = false;
            txtLoadFileDBSQLite.Location = new Point(156, 23);
            txtLoadFileDBSQLite.Name = "txtLoadFileDBSQLite";
            txtLoadFileDBSQLite.Size = new Size(339, 27);
            txtLoadFileDBSQLite.TabIndex = 2;
            // 
            // dataGridView1
            // 
            dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { colTabelaDestino, colCamposChave, colSelectSQLite, colTestSelect });
            dataGridView1.Location = new Point(9, 26);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(1299, 189);
            dataGridView1.TabIndex = 3;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            dataGridView1.CellDoubleClick += dataGridView1_CellDoubleClick;
            dataGridView1.CellFormatting += dataGridView1_CellFormatting;
            dataGridView1.CellToolTipTextNeeded += dataGridView1_CellToolTipTextNeeded;
            // 
            // btnGenerateInsertScript
            // 
            btnGenerateInsertScript.Location = new Point(469, 51);
            btnGenerateInsertScript.Name = "btnGenerateInsertScript";
            btnGenerateInsertScript.Size = new Size(141, 29);
            btnGenerateInsertScript.TabIndex = 7;
            btnGenerateInsertScript.Text = "Executar";
            btnGenerateInsertScript.UseVisualStyleBackColor = true;
            btnGenerateInsertScript.Click += btnGenerateInsertScript_Click;
            // 
            // btnSaveProfile
            // 
            btnSaveProfile.Location = new Point(1170, 26);
            btnSaveProfile.Name = "btnSaveProfile";
            btnSaveProfile.Size = new Size(141, 29);
            btnSaveProfile.TabIndex = 8;
            btnSaveProfile.Text = "Salvar";
            btnSaveProfile.UseVisualStyleBackColor = true;
            btnSaveProfile.Click += btnSaveProfile_Click;
            // 
            // btnLoadProfile
            // 
            btnLoadProfile.Location = new Point(1025, 26);
            btnLoadProfile.Name = "btnLoadProfile";
            btnLoadProfile.Size = new Size(139, 29);
            btnLoadProfile.TabIndex = 9;
            btnLoadProfile.Text = "Carregar";
            btnLoadProfile.UseVisualStyleBackColor = true;
            btnLoadProfile.Click += btnLoadProfile_Click;
            // 
            // rbInsertMissing
            // 
            rbInsertMissing.AutoSize = true;
            rbInsertMissing.Location = new Point(6, 75);
            rbInsertMissing.Name = "rbInsertMissing";
            rbInsertMissing.Size = new Size(376, 24);
            rbInsertMissing.TabIndex = 10;
            rbInsertMissing.TabStop = true;
            rbInsertMissing.Text = "Inserir apenas os não encontrados no Banco Destino";
            rbInsertMissing.UseVisualStyleBackColor = true;
            // 
            // rbInsertAll
            // 
            rbInsertAll.AutoSize = true;
            rbInsertAll.Location = new Point(6, 26);
            rbInsertAll.Name = "rbInsertAll";
            rbInsertAll.Size = new Size(178, 24);
            rbInsertAll.TabIndex = 11;
            rbInsertAll.TabStop = true;
            rbInsertAll.Text = "Inserir Todos os dados";
            rbInsertAll.UseVisualStyleBackColor = true;
            // 
            // rbCompareOnly
            // 
            rbCompareOnly.AutoSize = true;
            rbCompareOnly.Location = new Point(6, 51);
            rbCompareOnly.Name = "rbCompareOnly";
            rbCompareOnly.Size = new Size(336, 24);
            rbCompareOnly.TabIndex = 12;
            rbCompareOnly.TabStop = true;
            rbCompareOnly.Text = "Apenas Comparar os dados (Extração em .csv)";
            rbCompareOnly.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            groupBox1.Controls.Add(rbInsertMissing);
            groupBox1.Controls.Add(rbCompareOnly);
            groupBox1.Controls.Add(rbInsertAll);
            groupBox1.Location = new Point(34, 497);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(665, 136);
            groupBox1.TabIndex = 13;
            groupBox1.TabStop = false;
            groupBox1.Text = "Modo de execução";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(rbDBSQLServerOrigem);
            groupBox2.Controls.Add(rbDBOrigem);
            groupBox2.Controls.Add(tabControl1);
            groupBox2.Location = new Point(25, 96);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(680, 168);
            groupBox2.TabIndex = 14;
            groupBox2.TabStop = false;
            groupBox2.Text = "Banco de dados Origem";
            // 
            // rbDBSQLServerOrigem
            // 
            rbDBSQLServerOrigem.AutoSize = true;
            rbDBSQLServerOrigem.Location = new Point(223, 26);
            rbDBSQLServerOrigem.Name = "rbDBSQLServerOrigem";
            rbDBSQLServerOrigem.Size = new Size(208, 24);
            rbDBSQLServerOrigem.TabIndex = 14;
            rbDBSQLServerOrigem.TabStop = true;
            rbDBSQLServerOrigem.Text = "Banco de dados SQLServer";
            rbDBSQLServerOrigem.UseVisualStyleBackColor = true;
            rbDBSQLServerOrigem.CheckedChanged += rbDBSQLServerOrigem_CheckedChanged;
            // 
            // rbDBOrigem
            // 
            rbDBOrigem.AutoSize = true;
            rbDBOrigem.Location = new Point(15, 26);
            rbDBOrigem.Name = "rbDBOrigem";
            rbDBOrigem.Size = new Size(186, 24);
            rbDBOrigem.TabIndex = 13;
            rbDBOrigem.TabStop = true;
            rbDBOrigem.Text = "Banco de Dados SQLite";
            rbDBOrigem.UseVisualStyleBackColor = true;
            rbDBOrigem.CheckedChanged += rbDBOrigem_CheckedChanged;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tpDBOrigemSQLite);
            tabControl1.Controls.Add(tpDBOrigemSQLServer);
            tabControl1.Location = new Point(12, 56);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(656, 98);
            tabControl1.TabIndex = 3;
            // 
            // tpDBOrigemSQLite
            // 
            tpDBOrigemSQLite.Controls.Add(txtLoadFileDBSQLite);
            tpDBOrigemSQLite.Controls.Add(lblSelectDBSQLite);
            tpDBOrigemSQLite.Controls.Add(btnSelectDBSQLite);
            tpDBOrigemSQLite.Location = new Point(4, 29);
            tpDBOrigemSQLite.Name = "tpDBOrigemSQLite";
            tpDBOrigemSQLite.Padding = new Padding(3);
            tpDBOrigemSQLite.Size = new Size(648, 65);
            tpDBOrigemSQLite.TabIndex = 0;
            tpDBOrigemSQLite.Text = "SQLite";
            tpDBOrigemSQLite.UseVisualStyleBackColor = true;
            // 
            // tpDBOrigemSQLServer
            // 
            tpDBOrigemSQLServer.Controls.Add(label3);
            tpDBOrigemSQLServer.Controls.Add(txtDBOrigem);
            tpDBOrigemSQLServer.Controls.Add(label4);
            tpDBOrigemSQLServer.Controls.Add(txtServerOrigem);
            tpDBOrigemSQLServer.Location = new Point(4, 29);
            tpDBOrigemSQLServer.Name = "tpDBOrigemSQLServer";
            tpDBOrigemSQLServer.Padding = new Padding(3);
            tpDBOrigemSQLServer.Size = new Size(648, 65);
            tpDBOrigemSQLServer.TabIndex = 1;
            tpDBOrigemSQLServer.Text = "SQLServer";
            tpDBOrigemSQLServer.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(342, 9);
            label3.Name = "label3";
            label3.Size = new Size(53, 20);
            label3.TabIndex = 11;
            label3.Text = "Banco:";
            // 
            // txtDBOrigem
            // 
            txtDBOrigem.Location = new Point(342, 32);
            txtDBOrigem.Name = "txtDBOrigem";
            txtDBOrigem.Size = new Size(300, 27);
            txtDBOrigem.TabIndex = 9;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(17, 9);
            label4.Name = "label4";
            label4.Size = new Size(67, 20);
            label4.TabIndex = 8;
            label4.Text = "Servidor:";
            // 
            // txtServerOrigem
            // 
            txtServerOrigem.Location = new Point(17, 32);
            txtServerOrigem.Name = "txtServerOrigem";
            txtServerOrigem.Size = new Size(319, 27);
            txtServerOrigem.TabIndex = 10;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(lblProfile);
            groupBox3.Controls.Add(btnLoadProfile);
            groupBox3.Controls.Add(btnSaveProfile);
            groupBox3.Location = new Point(31, 12);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(1317, 68);
            groupBox3.TabIndex = 15;
            groupBox3.TabStop = false;
            groupBox3.Text = "Informações de Perfil";
            // 
            // lblProfile
            // 
            lblProfile.Location = new Point(19, 32);
            lblProfile.Name = "lblProfile";
            lblProfile.Size = new Size(458, 25);
            lblProfile.TabIndex = 0;
            lblProfile.Text = "Nenhum Perfil carregado";
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(rbDBSQLServerDestino);
            groupBox4.Controls.Add(rbDBDestino);
            groupBox4.Location = new Point(711, 96);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(637, 168);
            groupBox4.TabIndex = 16;
            groupBox4.TabStop = false;
            groupBox4.Text = "Banco de dados Destino";
            // 
            // rbDBSQLServerDestino
            // 
            rbDBSQLServerDestino.AutoSize = true;
            rbDBSQLServerDestino.Location = new Point(220, 26);
            rbDBSQLServerDestino.Name = "rbDBSQLServerDestino";
            rbDBSQLServerDestino.Size = new Size(208, 24);
            rbDBSQLServerDestino.TabIndex = 16;
            rbDBSQLServerDestino.Text = "Banco de dados SQLServer";
            rbDBSQLServerDestino.UseVisualStyleBackColor = true;
            rbDBSQLServerDestino.CheckedChanged += rbDBSQLServerDestino_CheckedChanged;
            // 
            // rbDBDestino
            // 
            rbDBDestino.AutoSize = true;
            rbDBDestino.Location = new Point(12, 26);
            rbDBDestino.Name = "rbDBDestino";
            rbDBDestino.Size = new Size(186, 24);
            rbDBDestino.TabIndex = 15;
            rbDBDestino.Text = "Banco de Dados SQLite";
            rbDBDestino.UseVisualStyleBackColor = true;
            rbDBDestino.CheckedChanged += rbDBDestino_CheckedChanged;
            // 
            // groupBox5
            // 
            groupBox5.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            groupBox5.Controls.Add(dataGridView1);
            groupBox5.Location = new Point(37, 270);
            groupBox5.Name = "groupBox5";
            groupBox5.Size = new Size(1314, 221);
            groupBox5.TabIndex = 17;
            groupBox5.TabStop = false;
            groupBox5.Text = "Configurações de integrações";
            // 
            // Executar
            // 
            Executar.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            Executar.Controls.Add(rdUPSERT);
            Executar.Controls.Add(rdGenerateFileInsert);
            Executar.Controls.Add(btnGenerateInsertScript);
            Executar.Location = new Point(705, 497);
            Executar.Name = "Executar";
            Executar.Size = new Size(640, 136);
            Executar.TabIndex = 18;
            Executar.TabStop = false;
            Executar.Text = "Executar";
            // 
            // rdUPSERT
            // 
            rdUPSERT.AutoSize = true;
            rdUPSERT.Location = new Point(15, 68);
            rdUPSERT.Name = "rdUPSERT";
            rdUPSERT.Size = new Size(356, 24);
            rdUPSERT.TabIndex = 14;
            rdUPSERT.TabStop = true;
            rdUPSERT.Text = "Inserir no banco de dados (Em Desenvolvimento)";
            rdUPSERT.UseVisualStyleBackColor = true;
            // 
            // rdGenerateFileInsert
            // 
            rdGenerateFileInsert.AutoSize = true;
            rdGenerateFileInsert.Location = new Point(15, 38);
            rdGenerateFileInsert.Name = "rdGenerateFileInsert";
            rdGenerateFileInsert.Size = new Size(189, 24);
            rdGenerateFileInsert.TabIndex = 13;
            rdGenerateFileInsert.TabStop = true;
            rdGenerateFileInsert.Text = "Gerar Arquivos de Insert";
            rdGenerateFileInsert.UseVisualStyleBackColor = true;
            // 
            // progressBarProcess
            // 
            progressBarProcess.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            progressBarProcess.Location = new Point(31, 639);
            progressBarProcess.Name = "progressBarProcess";
            progressBarProcess.Size = new Size(1317, 29);
            progressBarProcess.TabIndex = 19;
            // 
            // tabControl2
            // 
            tabControl2.Controls.Add(tpDBOrigemSQLiteDestino);
            tabControl2.Controls.Add(tpDBOrigemSQLServerDestino);
            tabControl2.Location = new Point(717, 156);
            tabControl2.Name = "tabControl2";
            tabControl2.SelectedIndex = 0;
            tabControl2.Size = new Size(625, 102);
            tabControl2.TabIndex = 17;
            // 
            // tpDBOrigemSQLiteDestino
            // 
            tpDBOrigemSQLiteDestino.Controls.Add(txtLoadFileDBSQLiteDestino);
            tpDBOrigemSQLiteDestino.Controls.Add(label1);
            tpDBOrigemSQLiteDestino.Controls.Add(btnSelectDBSQLiteDestino);
            tpDBOrigemSQLiteDestino.Location = new Point(4, 29);
            tpDBOrigemSQLiteDestino.Name = "tpDBOrigemSQLiteDestino";
            tpDBOrigemSQLiteDestino.Padding = new Padding(3);
            tpDBOrigemSQLiteDestino.Size = new Size(617, 69);
            tpDBOrigemSQLiteDestino.TabIndex = 0;
            tpDBOrigemSQLiteDestino.Text = "SQLite";
            tpDBOrigemSQLiteDestino.UseVisualStyleBackColor = true;
            // 
            // txtLoadFileDBSQLiteDestino
            // 
            txtLoadFileDBSQLiteDestino.Enabled = false;
            txtLoadFileDBSQLiteDestino.Location = new Point(156, 23);
            txtLoadFileDBSQLiteDestino.Name = "txtLoadFileDBSQLiteDestino";
            txtLoadFileDBSQLiteDestino.Size = new Size(318, 27);
            txtLoadFileDBSQLiteDestino.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 29);
            label1.Name = "label1";
            label1.Size = new Size(147, 20);
            label1.TabIndex = 0;
            label1.Text = "Database SQLite .db:";
            // 
            // btnSelectDBSQLiteDestino
            // 
            btnSelectDBSQLiteDestino.Location = new Point(480, 22);
            btnSelectDBSQLiteDestino.Name = "btnSelectDBSQLiteDestino";
            btnSelectDBSQLiteDestino.Size = new Size(131, 29);
            btnSelectDBSQLiteDestino.TabIndex = 1;
            btnSelectDBSQLiteDestino.Text = "Carregar Arquivo";
            btnSelectDBSQLiteDestino.UseVisualStyleBackColor = true;
            btnSelectDBSQLiteDestino.Click += btnSelectDBSQLiteDestino_Click;
            // 
            // tpDBOrigemSQLServerDestino
            // 
            tpDBOrigemSQLServerDestino.Controls.Add(label2);
            tpDBOrigemSQLServerDestino.Controls.Add(txtBanco);
            tpDBOrigemSQLServerDestino.Controls.Add(label5);
            tpDBOrigemSQLServerDestino.Controls.Add(txtServidor);
            tpDBOrigemSQLServerDestino.Location = new Point(4, 29);
            tpDBOrigemSQLServerDestino.Name = "tpDBOrigemSQLServerDestino";
            tpDBOrigemSQLServerDestino.Padding = new Padding(3);
            tpDBOrigemSQLServerDestino.Size = new Size(617, 69);
            tpDBOrigemSQLServerDestino.TabIndex = 1;
            tpDBOrigemSQLServerDestino.Text = "SQLServer";
            tpDBOrigemSQLServerDestino.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(342, 12);
            label2.Name = "label2";
            label2.Size = new Size(53, 20);
            label2.TabIndex = 11;
            label2.Text = "Banco:";
            // 
            // txtBanco
            // 
            txtBanco.Location = new Point(342, 32);
            txtBanco.Name = "txtBanco";
            txtBanco.Size = new Size(269, 27);
            txtBanco.TabIndex = 9;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(17, 12);
            label5.Name = "label5";
            label5.Size = new Size(67, 20);
            label5.TabIndex = 8;
            label5.Text = "Servidor:";
            // 
            // txtServidor
            // 
            txtServidor.Location = new Point(17, 32);
            txtServidor.Name = "txtServidor";
            txtServidor.Size = new Size(319, 27);
            txtServidor.TabIndex = 10;
            // 
            // colTabelaDestino
            // 
            colTabelaDestino.HeaderText = "Tabela Destino";
            colTabelaDestino.MinimumWidth = 6;
            colTabelaDestino.Name = "colTabelaDestino";
            // 
            // colCamposChave
            // 
            colCamposChave.HeaderText = "Campos Chave (;)";
            colCamposChave.MinimumWidth = 6;
            colCamposChave.Name = "colCamposChave";
            // 
            // colSelectSQLite
            // 
            colSelectSQLite.HeaderText = "SELECT SQLite";
            colSelectSQLite.MinimumWidth = 6;
            colSelectSQLite.Name = "colSelectSQLite";
            colSelectSQLite.ReadOnly = true;
            // 
            // colTestSelect
            // 
            colTestSelect.FillWeight = 30F;
            colTestSelect.HeaderText = "Visualizar Dados";
            colTestSelect.MinimumWidth = 6;
            colTestSelect.Name = "colTestSelect";
            // 
            // frmMain
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1360, 666);
            Controls.Add(tabControl2);
            Controls.Add(progressBarProcess);
            Controls.Add(Executar);
            Controls.Add(groupBox5);
            Controls.Add(groupBox4);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Name = "frmMain";
            Text = "NSTDB - Not Saved To DB";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            tabControl1.ResumeLayout(false);
            tpDBOrigemSQLite.ResumeLayout(false);
            tpDBOrigemSQLite.PerformLayout();
            tpDBOrigemSQLServer.ResumeLayout(false);
            tpDBOrigemSQLServer.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            groupBox5.ResumeLayout(false);
            Executar.ResumeLayout(false);
            Executar.PerformLayout();
            tabControl2.ResumeLayout(false);
            tpDBOrigemSQLiteDestino.ResumeLayout(false);
            tpDBOrigemSQLiteDestino.PerformLayout();
            tpDBOrigemSQLServerDestino.ResumeLayout(false);
            tpDBOrigemSQLServerDestino.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label lblSelectDBSQLite;
        private Button btnSelectDBSQLite;
        private TextBox txtLoadFileDBSQLite;
        private DataGridView dataGridView1;
        private Button btnGenerateInsertScript;
        private Button btnSaveProfile;
        private Button btnLoadProfile;
        private RadioButton rbInsertMissing;
        private RadioButton rbInsertAll;
        private RadioButton rbCompareOnly;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private GroupBox groupBox3;
        private Label lblProfile;
        private GroupBox groupBox4;
        private GroupBox groupBox5;
        private GroupBox Executar;
        private RadioButton rdUPSERT;
        private RadioButton rdGenerateFileInsert;
        private TabControl tabControl1;
        private TabPage tpDBOrigemSQLite;
        private TabPage tpDBOrigemSQLServer;
        private RadioButton rbDBSQLServerOrigem;
        private RadioButton rbDBOrigem;
        private Label label3;
        private TextBox txtDBOrigem;
        private Label label4;
        private TextBox txtServerOrigem;
        private ProgressBar progressBarProcess;
        private RadioButton rbDBSQLServerDestino;
        private RadioButton rbDBDestino;
        private TabControl tabControl2;
        private TabPage tpDBOrigemSQLiteDestino;
        private TextBox txtLoadFileDBSQLiteDestino;
        private Label label1;
        private Button btnSelectDBSQLiteDestino;
        private TabPage tpDBOrigemSQLServerDestino;
        private Label label2;
        private TextBox txtBanco;
        private Label label5;
        private TextBox txtServidor;
        private DataGridViewTextBoxColumn colTabelaDestino;
        private DataGridViewTextBoxColumn colCamposChave;
        private DataGridViewTextBoxColumn colSelectSQLite;
        private DataGridViewButtonColumn colTestSelect;
    }
}
