namespace NotSavedToDB
{
    partial class FrmSQLiteResult
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dgvSQLiteResult = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvSQLiteResult).BeginInit();
            SuspendLayout();
            // 
            // dgvSQLiteResult
            // 
            dgvSQLiteResult.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSQLiteResult.Location = new Point(12, 12);
            dgvSQLiteResult.Name = "dgvSQLiteResult";
            dgvSQLiteResult.RowHeadersWidth = 51;
            dgvSQLiteResult.Size = new Size(1439, 589);
            dgvSQLiteResult.TabIndex = 0;
            // 
            // FrmSQLiteResult
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1463, 602);
            Controls.Add(dgvSQLiteResult);
            Name = "FrmSQLiteResult";
            Text = "FrmSQLiteResult";
            ((System.ComponentModel.ISupportInitialize)dgvSQLiteResult).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvSQLiteResult;
    }
}