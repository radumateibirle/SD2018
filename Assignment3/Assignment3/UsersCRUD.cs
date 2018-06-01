using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using BLL.Models;

namespace Assignment3
{
    public partial class UsersCRUD : Form
    {
        UserServices uS = new UserServices();

        public async void initGridV()
        {
            dataGridView1.DataSource = await uS.getAll();
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[3].Visible = false;
            dataGridView1.Columns[4].Visible = false;
            dataGridView1.Columns.Add("", "");
            dataGridView1.Columns.Add("", "");
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                var row = dataGridView1.Rows[i];
                DataGridViewButtonCell bEdit = new DataGridViewButtonCell();
                bEdit.Value = "edit";
                row.Cells[dataGridView1.ColumnCount - 2] = bEdit;
                DataGridViewButtonCell bDelete = new DataGridViewButtonCell();
                bDelete.Value = "delete";
                row.Cells[dataGridView1.ColumnCount - 1] = bDelete;
            }
        }

        public async void refreshGridV()
        {
            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();
            dataGridView1.Refresh();

            dataGridView1.DataSource = await uS.getAll();
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[3].Visible = false;
            dataGridView1.Columns[4].Visible = false;
            dataGridView1.Columns.Add("", "");
            dataGridView1.Columns.Add("", "");
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                var row = dataGridView1.Rows[i];
                DataGridViewButtonCell bEdit = new DataGridViewButtonCell();
                bEdit.Value = "edit";
                row.Cells[dataGridView1.ColumnCount - 2] = bEdit;
                DataGridViewButtonCell bDelete = new DataGridViewButtonCell();
                bDelete.Value = "delete";
                row.Cells[dataGridView1.ColumnCount - 1] = bDelete;
            }
        }

        public UsersCRUD()
        {
            InitializeComponent();
            initGridV();

        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == (dataGridView1.ColumnCount - 2))
            {
                //edit
                var row = dataGridView1.Rows[e.RowIndex];
                UserModel um = new UserModel();
                um.ID = Int32.Parse(row.Cells["ID"].Value.ToString());

                if (row.Cells["GroupName"].Value == null) um.GroupName = null;
                else um.GroupName = row.Cells["GroupName"].Value.ToString();

                if (row.Cells["FullName"].Value == null) um.FullName = null;
                else um.FullName = row.Cells["FullName"].Value.ToString();

                if (row.Cells["Hobby"].Value == null) um.Hobby = null;
                else um.Hobby = row.Cells["Hobby"].Value.ToString();

                if (row.Cells["Password"].Value == null) um.Password = null;
                else um.Password = row.Cells["Password"].Value.ToString();

                if (row.Cells["Token"].Value == null) um.Token = null;
                else um.Token = row.Cells["Token"].Value.ToString();

                if (row.Cells["Type"].Value == null) um.Type = null;
                else um.Type = row.Cells["Type"].Value.ToString();
                
                if (row.Cells["Email"].Value == null) um.Email = null;
                else um.Email = row.Cells["Email"].Value.ToString();

                uS.update(um);
                for (int i = 0; i < 100000000; i++) ;
                refreshGridV();

            }
            if (e.ColumnIndex == (dataGridView1.ColumnCount - 1))
            {
                //delete
                var row = dataGridView1.Rows[e.RowIndex];
                uS.deleteByID(Int32.Parse(row.Cells["ID"].Value.ToString()));
                for (int i = 0; i < 100000000; i++) ;
                refreshGridV();
            }

        }

        private bool checkEmail(string email)
        {// a@b.c
            string[] beforeAfterAt = email.Split('@'); // [0] = a, [1] = b.c
            if (beforeAfterAt.Length != 2) return false;
            string[] beforeAfterDot = beforeAfterAt[1].Split('.'); //[0] = b, [1] = c
            if (beforeAfterDot.Length > 2) return false;
            return true;
        }

        private void tokenButton_Click(object sender, EventArgs e)
        {
            //laboratorykey@gmail.com
            //a1a2a3a4a5a6!
            if (StudentRadio.Checked == false && AdminRadio.Checked == false) return;
            if (checkEmail(emailTextBox.Text) == false) return;
            if (StudentRadio.Checked == true) uS.addUser("Student", emailTextBox.Text);
            if (AdminRadio.Checked == true) uS.addUser("Admin", emailTextBox.Text);
            for (int i = 0; i < 100000000; i++) ;
            refreshGridV();
        }
    
    }
}
