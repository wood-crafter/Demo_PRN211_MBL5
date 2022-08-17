using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Winform_EF.Models;

namespace Winform_EF
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
            using (MySaleDBContext context = new MySaleDBContext())
            {
                var data = context.Products.Select( item => new
                {
                    // Custom data
                    ProductID = item.ProductId,
                    ProductName = item.ProductName,
                    Price = item.UnitPrice,
                    Stock = item.UnitsInStock,
                    Image = item.Image,
                    CategoryName = item.Category.CategoryName,
                }).ToList();
                dgv.DataSource = data;

                var data2 = context.Categories.ToList();
                cbx.DataSource = data2;
                cbx.DisplayMember = "CategoryName";
                cbx.ValueMember = "CategoryId";
            }
        }

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                return;
            }
            txtId.Text = dgv.Rows[e.RowIndex].Cells[0].FormattedValue.ToString();
            txtName.Text = dgv.Rows[e.RowIndex].Cells[1].FormattedValue.ToString();
            txtUnitprice.Text = dgv.Rows[e.RowIndex].Cells[2].FormattedValue.ToString();
            if (dgv.Rows[e.RowIndex].Cells[3].FormattedValue.ToString().Trim() == "")
            {
                nud.Value = 0;
            }
            else
            {
                nud.Value = Convert.ToUInt32(dgv.Rows[e.RowIndex].Cells[3].FormattedValue.ToString());
            }
            txtImage.Text = dgv.Rows[e.RowIndex].Cells[4].FormattedValue.ToString();
            cbx.Text = dgv.Rows[e.RowIndex].Cells[5].FormattedValue.ToString();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            // Create object to Insert
            Product product = new Product
            {
                ProductName = txtName.Text,
                UnitPrice = Convert.ToDecimal(txtUnitprice.Text),
                UnitsInStock = Convert.ToInt32(nud.Value),
                Image = txtImage.Text,
                CategoryId = Convert.ToInt32(cbx.SelectedValue.ToString()),
            };

            using(MySaleDBContext context = new MySaleDBContext())
            {
                context.Products.Add(product);
                if(context.SaveChanges() > 0)
                {
                    MessageBox.Show("Insert succesfully");
                    loadData();
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            using (MySaleDBContext context = new MySaleDBContext())
            {
                Product product = context.Products.SingleOrDefault(
                    item => item.ProductId == Convert.ToInt32(txtId.Text)
                );
                context.Products.Remove(product);
                if (context.SaveChanges() > 0)
                {
                    MessageBox.Show("Delete succesfully");
                    loadData();
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            using (MySaleDBContext context = new MySaleDBContext())
            {
                Product product = context.Products.SingleOrDefault(
                    item => item.ProductId == Convert.ToInt32(txtId.Text)
                );
                product.ProductName = txtName.Text;
                product.UnitPrice = Convert.ToDecimal(txtUnitprice.Text);
                product.UnitsInStock = Convert.ToInt32(nud.Value);
                product.CategoryId = Convert.ToInt32(cbx.SelectedValue);
                product.Image = txtImage.Text;

                if (context.SaveChanges() > 0)
                {
                    MessageBox.Show("Update succesfully");
                    loadData();
                }
            }
        }
    }
}
