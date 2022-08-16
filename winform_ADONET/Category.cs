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
        private string selectedId = "";
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
        }

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedId = dgv.Rows[e.RowIndex].Cells[0].FormattedValue.ToString();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            string strInsert = "INSERT INTO Categories ([CategoryName]) VALUES('" + txtCategoryName.Text +"')";

            if (new DataProvider().executeNonQuery(strInsert))
            {
                MessageBox.Show("INSERT successfully");
                loadData();
            }
            else
            {
                MessageBox.Show("INSERT fail");
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(selectedId))
            {
                MessageBox.Show("Please choose record to update");
                return;
            }
            string strInsert = "UPDATE Categories SET [CategoryName] = '" + txtCategoryName.Text + "' WHERE CategoryId = '"+ selectedId +"'";

            if (new DataProvider().executeNonQuery(strInsert))
            {
                MessageBox.Show("UPDATE successfully");
                loadData();
            }
            else
            {
                MessageBox.Show("UPDATE fail");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(selectedId))
            {
                MessageBox.Show("Please choose record to delete");
                return;
            }
            string strInsert = "DELETE FROM Categories WHERE CategoryId = '" + selectedId + "'";

            if (new DataProvider().executeNonQuery(strInsert))
            {
                MessageBox.Show("DELETE successfully");
                loadData();
            }
            else
            {
                MessageBox.Show("DELETE fail");
            }
        }
    }
}
