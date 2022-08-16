using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace winform_ADONET
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            loadData();
        }


        private void loadData()
        {
            DataTable dt = new DataTable();
            string srtSelect = "SELECT p.productid 'id', p.productname, p.unitprice, p.unitsinstock, p.image, c.categoryname FROM Products p, Categories c where p.CategoryId=c.CategoryId";
            dt = (new DataProvider()).executeQuery(srtSelect);
            //DataTable dt2 = new DataTable();
            //dt2.Columns.Add("ID", typeof(string));
            //foreach (DataRow dr in dt.Rows)
            //{
            //    string code = 'p' + dr.ItemArray[0].ToString();
            //    dt2.Rows.Add(code);
            //}
            dgv.DataSource = dt;

            dt = (new DataProvider()).executeQuery("SELECT * FROM Categories");
            cbx.DataSource = dt;
            cbx.DisplayMember = "CategoryName";
            cbx.ValueMember = "CategoryId"; // for selectedValue
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            string strInsert = "INSERT INTO Products([ProductName], [UnitPrice], [UnitsInStock], [Image], [CategoryId]) " +
                "VALUES('"+txtName.Text+"','" + txtUnitprice.Text +"','" + nud.Value +"','" + txtImage.Text +"','"+cbx.SelectedValue+"')";

            if(new DataProvider().executeNonQuery(strInsert))
            {
                MessageBox.Show("Insert successfully");
                loadData();
            } else
            {
                MessageBox.Show("Insert fail");
            }
        }

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex == -1)
            {
                return;
            }
            txtId.Text = dgv.Rows[e.RowIndex].Cells[0].FormattedValue.ToString();
            txtName.Text = dgv.Rows[e.RowIndex].Cells[1].FormattedValue.ToString();
            txtUnitprice.Text = dgv.Rows[e.RowIndex].Cells[2].FormattedValue.ToString();
            if(dgv.Rows[e.RowIndex].Cells[3].FormattedValue.ToString().Trim() == "")
            {
                nud.Value = 0;
            } else
            {
                nud.Value = Convert.ToUInt32(dgv.Rows[e.RowIndex].Cells[3].FormattedValue.ToString());
            }
            txtImage.Text = dgv.Rows[e.RowIndex].Cells[4].FormattedValue.ToString();
            cbx.Text = dgv.Rows[e.RowIndex].Cells[5].FormattedValue.ToString();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string strInsert = "UPDATE Products SET [ProductName] = '" + txtName.Text + "', [UnitPrice] = '" + txtUnitprice.Text + "', [UnitsInStock] = '" + nud.Value + "', [Image] = '" + txtImage.Text + "', [CategoryId] = '" + cbx.SelectedValue + "' WHERE ProductID = '"+ txtId.Text.Trim() +"'";

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
            string strInsert = "DELETE FROM Products WHERE ProductID = '" + txtId.Text.Trim() + "'";

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
