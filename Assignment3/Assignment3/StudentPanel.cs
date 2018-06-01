using BLL;
using BLL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assignment3
{
    public partial class StudentPanel : Form
    {
        int userID;
        LaboratoryServices lS = new LaboratoryServices();

        public async void initGridV(string email)
        {

            UserServices uS = new UserServices();
            List<UserModel> users = await uS.getAll();
            userID = users.FirstOrDefault(u => u.Email == email).ID;

            List<LaboratoryModel> labs = await lS.getAll();
            dataGridView1.DataSource = labs;
            dataGridView1.Columns["ID"].Visible = false;
            dataGridView1.Columns.Add("Attended", "Attended");
            dataGridView1.Columns.Add("", "");

            AttendanceServices aS = new AttendanceServices();
            List<AttendanceModel> atts = await aS.getAll();

            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                var row = dataGridView1.Rows[i];
                DataGridViewButtonCell bAssign = new DataGridViewButtonCell();
                bAssign.Value = "See assignments";
                row.Cells[dataGridView1.ColumnCount - 1] = bAssign;

                int labID = Int32.Parse(row.Cells["ID"].Value.ToString());
                row.Cells["Attended"].Value = "No";
                foreach (AttendanceModel a in atts)
                {
                    if (a.LaboratoryID == labID)
                        if (a.StudentID == userID) row.Cells["Attended"].Value = "Yes";

                }
            }
        }

        public StudentPanel(string email, string pass)
        {
            InitializeComponent();
            initGridV(email);

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == (dataGridView1.ColumnCount - 1))
            {
                //see assignments
                var row = dataGridView1.Rows[e.RowIndex];

                var assignments = new StudentAssignments(Int32.Parse(row.Cells["ID"].Value.ToString()), userID);
                assignments.Show();
            }
        }

        private async void keywordTextBox_TextChangedAsync(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();
            dataGridView1.Refresh();

            if (keywordTextBox.Text == null)
            {
                dataGridView1.DataSource = await lS.getAll();
            }
            else
            {
                dataGridView1.DataSource = await lS.getByKeyword(keywordTextBox.Text);
            }

            dataGridView1.Columns["ID"].Visible = false;
            dataGridView1.Columns.Add("", "");
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                var row = dataGridView1.Rows[i];
                DataGridViewButtonCell bAssign = new DataGridViewButtonCell();
                bAssign.Value = "See assignments";
                row.Cells[dataGridView1.ColumnCount - 1] = bAssign;
            }
        }

        private void doneButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            var loginPanel = new Login();
            loginPanel.Closed += (s, args) => this.Close();
            loginPanel.Show();
        }
    }
}
