using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxRole.SelectedIndex == 0)
            {
                txtSalary.Text = "10000000";
            }
            if (cbxRole.SelectedIndex == 1)
            {
                txtSalary.Text = "6000000";
            }
            if (cbxRole.SelectedIndex == 2)
            {
                txtSalary.Text = "4000000";
            }
        }

        List<Empoyee> list = new List<Empoyee>();
        private void btnAdd_Click(object sender, EventArgs e)
        {
            string code = txtCode.Text;
            string name = txtName.Text;
            bool isMale = btnMale.Checked == true;
            string role = cbxRole.SelectedItem.ToString();
            long salary = Convert.ToUInt32(txtSalary.Text);

            foreach (Empoyee emp in list)
            {
                if (emp.Code.ToLower().Trim().Equals(code.ToLower().Trim())) {
                    MessageBox.Show("Code duplicate");
                    return;
                }
            }

            list.Add(new Empoyee(code, name, isMale, role, salary));
            lstBox.Items.Add(new Empoyee(code, name, isMale, role, salary));
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            //for(int i = 0; i < 3; i++)
            //{
            //    Button btn = new Button();
            //    //btn.ForeColor = System.Drawing.Color.Red;
            //    btn.Location = new System.Drawing.Point(476 + 100 * (i + 1), 400);
            //    //btn.Name = "btnExit";
            //    btn.Size = new System.Drawing.Size(94, 29);
            //    //btn.TabIndex = 17;
            //    btn.Text = "Exit";
            //    //btn.UseVisualStyleBackColor = true;
            //    //btn.Click += new System.EventHandler(this.btnExit_Click);
            //    this.Controls.Add(btn);
            //    btn.Click += Btn_Click;
            //}
        }

        private void txtCode_Enter(object sender, EventArgs e)
        {
            txtCode.BackColor = Color.Pink;
        }

        private void txtCode_Leave(object sender, EventArgs e)
        {
            txtCode.BackColor = Color.White;
        }

        private void txtName_Enter(object sender, EventArgs e)
        {
            txtName.BackColor = Color.Pink;

        }

        private void txtName_Leave(object sender, EventArgs e)
        {
            txtName.BackColor = Color.White;

        }

        //private void Btn_Click(object? sender, EventArgs e)
        //{
        //    Button button = sender as Button;
        //    MessageBox.Show("You just clicked" + button.Text);
        //}
    }
}
