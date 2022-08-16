using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace winform_ADONET
{
    public partial class Category : Form
    {
        public Category()
        {
            InitializeComponent();
        }

        private void Category_Load(object sender, EventArgs e)
        {
            loadData();
        }

        private void loadData()
        {
            DataTable dt = new DataTable();
            string srtSelect = "SELECT * From Categories";
            dt = (new DataProvider()).executeQuery(srtSelect);
            dgv.DataSource = dt;

            dt = (new DataProvider()).executeQuery("SELECT * FROM Categories");
            cbxCategoryName.DataSource = dt;
            cbxCategoryName.DisplayMember = "CategoryName";
            cbxCategoryName.ValueMember = "CategoryId";
        }

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                return;
            }
            cbxCategoryName.Text = dgv.Rows[e.RowIndex].Cells[1].FormattedValue.ToString();
        }
    }
}
