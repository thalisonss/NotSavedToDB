using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NotSavedToDB
{
    public partial class frmSQLEditor : Form
    {
        public frmSQLEditor()
        {
            InitializeComponent();
        }

        private void frmSQLEditor_Load(object sender, EventArgs e)
        {
            txtSql.Multiline = true;
            txtSql.ScrollBars = ScrollBars.Both;
            txtSql.AcceptsTab = true;
            txtSql.AcceptsReturn = true;
            txtSql.WordWrap = false;
            txtSql.Font = new Font("Consolas", 10);
            txtSql.Dock = DockStyle.Fill;
        }
        public string SqlText
        {
            get { return txtSql.Text; }
            set { txtSql.Text = value; }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
