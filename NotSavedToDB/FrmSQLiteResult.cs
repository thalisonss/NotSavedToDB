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
    public partial class FrmSQLiteResult : Form
    {
        public FrmSQLiteResult()
        {
            InitializeComponent();
        }

        public void LoadData(DataTable dt)
        {
            dgvSQLiteResult.DataSource = dt;
        }
    }
}
