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
            colTabelaDestino = new DataGridViewTextBoxColumn();
            colCamposChave = new DataGridViewTextBoxColumn();
            colSelectSQLite = new DataGridViewTextBoxColumn();
            colTestSelect = new DataGridViewButtonColumn();
            txtBanco = new TextBox();
            txtServidor = new TextBox();
            btnGenerateInsertScript = new Button();
            btnSaveProfile = new Button();
            btnLoadProfile = new Button();
            rbInsertMissing = new RadioButton();
            rbInsertAll = new RadioButton();
            rbCompareOnly = new RadioButton();
            groupBox1 = new GroupBox();
            groupBox2 = new GroupBox();
            groupBox3 = new GroupBox();
            lblProfile = new Label();
            groupBox4 = new GroupBox();
            label2 = new Label();
            label1 = new Label();
            groupBox5 = new GroupBox();
            Executar = new GroupBox();
            radioButton2 = new RadioButton();
            radioButton1 = new RadioButton();
            tabControl1 = new TabControl();
            tpDBOrigemSQLite = new TabPage();
            tpDBOrigemSQLServer = new TabPage();
            rbDBOrigem = new RadioButton();
            radioButton3 = new RadioButton();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBox4.SuspendLayout();
            groupBox5.SuspendLayout();
            Executar.SuspendLayout();
            tabControl1.SuspendLayout();
            tpDBOrigemSQLite.SuspendLayout();
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
            dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { colTabelaDestino, colCamposChave, colSelectSQLite, colTestSelect });
            dataGridView1.Location = new Point(9, 26);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(1299, 189);
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
            colSelectSQLite.ReadOnly = true;
            colSelectSQLite.Width = 125;
            // 
            // colTestSelect
            // 
            colTestSelect.HeaderText = "Visualizar Dados";
            colTestSelect.MinimumWidth = 6;
            colTestSelect.Name = "colTestSelect";
            colTestSelect.Width = 125;
            // 
            // txtBanco
            // 
            txtBanco.Location = new Point(331, 56);
            txtBanco.Name = "txtBanco";
            txtBanco.Size = new Size(300, 27);
            txtBanco.TabIndex = 5;
            // 
            // txtServidor
            // 
            txtServidor.Location = new Point(6, 56);
            txtServidor.Name = "txtServidor";
            txtServidor.Size = new Size(319, 27);
            txtServidor.TabIndex = 6;
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
            groupBox2.Controls.Add(radioButton3);
            groupBox2.Controls.Add(rbDBOrigem);
            groupBox2.Controls.Add(tabControl1);
            groupBox2.Location = new Point(25, 96);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(680, 168);
            groupBox2.TabIndex = 14;
            groupBox2.TabStop = false;
            groupBox2.Text = "Banco de dados Origem";
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
            groupBox4.Controls.Add(label2);
            groupBox4.Controls.Add(label1);
            groupBox4.Controls.Add(txtServidor);
            groupBox4.Controls.Add(txtBanco);
            groupBox4.Location = new Point(711, 96);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(637, 146);
            groupBox4.TabIndex = 16;
            groupBox4.TabStop = false;
            groupBox4.Text = "Banco de dados Destino";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(331, 33);
            label2.Name = "label2";
            label2.Size = new Size(53, 20);
            label2.TabIndex = 7;
            label2.Text = "Banco:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 33);
            label1.Name = "label1";
            label1.Size = new Size(67, 20);
            label1.TabIndex = 3;
            label1.Text = "Servidor:";
            // 
            // groupBox5
            // 
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
            Executar.Controls.Add(radioButton2);
            Executar.Controls.Add(radioButton1);
            Executar.Controls.Add(btnGenerateInsertScript);
            Executar.Location = new Point(705, 497);
            Executar.Name = "Executar";
            Executar.Size = new Size(640, 136);
            Executar.TabIndex = 18;
            Executar.TabStop = false;
            Executar.Text = "Executar";
            // 
            // radioButton2
            // 
            radioButton2.AutoSize = true;
            radioButton2.Enabled = false;
            radioButton2.Location = new Point(15, 68);
            radioButton2.Name = "radioButton2";
            radioButton2.Size = new Size(356, 24);
            radioButton2.TabIndex = 14;
            radioButton2.TabStop = true;
            radioButton2.Text = "Inserir no banco de dados (Em Desenvolvimento)";
            radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            radioButton1.AutoSize = true;
            radioButton1.Location = new Point(15, 38);
            radioButton1.Name = "radioButton1";
            radioButton1.Size = new Size(189, 24);
            radioButton1.TabIndex = 13;
            radioButton1.TabStop = true;
            radioButton1.Text = "Gerar Arquivos de Insert";
            radioButton1.UseVisualStyleBackColor = true;
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
            tpDBOrigemSQLite.Text = "tabPage1";
            tpDBOrigemSQLite.UseVisualStyleBackColor = true;
            // 
            // tpDBOrigemSQLServer
            // 
            tpDBOrigemSQLServer.Location = new Point(4, 29);
            tpDBOrigemSQLServer.Name = "tpDBOrigemSQLServer";
            tpDBOrigemSQLServer.Padding = new Padding(3);
            tpDBOrigemSQLServer.Size = new Size(648, 65);
            tpDBOrigemSQLServer.TabIndex = 1;
            tpDBOrigemSQLServer.Text = "tabPage2";
            tpDBOrigemSQLServer.UseVisualStyleBackColor = true;
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
            // 
            // radioButton3
            // 
            radioButton3.AutoSize = true;
            radioButton3.Location = new Point(223, 26);
            radioButton3.Name = "radioButton3";
            radioButton3.Size = new Size(208, 24);
            radioButton3.TabIndex = 14;
            radioButton3.TabStop = true;
            radioButton3.Text = "Banco de dados SQLServer";
            radioButton3.UseVisualStyleBackColor = true;
            // 
            // frmMain
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1360, 648);
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
            groupBox3.ResumeLayout(false);
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            groupBox5.ResumeLayout(false);
            Executar.ResumeLayout(false);
            Executar.PerformLayout();
            tabControl1.ResumeLayout(false);
            tpDBOrigemSQLite.ResumeLayout(false);
            tpDBOrigemSQLite.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label lblSelectDBSQLite;
        private Button btnSelectDBSQLite;
        private TextBox txtLoadFileDBSQLite;
        private DataGridView dataGridView1;
        private TextBox txtBanco;
        private TextBox txtServidor;
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
        private Label label2;
        private Label label1;
        private GroupBox groupBox5;
        private DataGridViewTextBoxColumn colTabelaDestino;
        private DataGridViewTextBoxColumn colCamposChave;
        private DataGridViewTextBoxColumn colSelectSQLite;
        private DataGridViewButtonColumn colTestSelect;
        private GroupBox Executar;
        private RadioButton radioButton2;
        private RadioButton radioButton1;
        private TabControl tabControl1;
        private TabPage tpDBOrigemSQLite;
        private TabPage tpDBOrigemSQLServer;
        private RadioButton radioButton3;
        private RadioButton rbDBOrigem;
    }
}
