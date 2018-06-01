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
    public partial class SubmissionsCRUD : Form
    {
        SubmissionServices sS = new SubmissionServices();
        UserServices uS = new UserServices();
        List<UserModel> users;

        public async void initGridV()
        {
            dataGridView1.DataSource = await sS.getAll();
            dataGridView1.Columns["ID"].Visible = false;
            dataGridView1.Columns["StudentID"].Visible = false;
            dataGridView1.Columns.Add("Student name", "Student name");
            dataGridView1.Columns.Add("", "");
            dataGridView1.Columns.Add("", "");

            users = await uS.getAll();
            List<string> userNames = new List<string>();

            foreach (UserModel u in users)
            {
                userNames.Add(u.FullName);
            }
            studentComboBox.DataSource = userNames;

            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                var row = dataGridView1.Rows[i];

                UserModel cUsr;
                int usrID = Int32.Parse(row.Cells["StudentID"].Value.ToString());
                cUsr = users.FirstOrDefault(l => l.ID == usrID);
                row.Cells["Student name"].Value = cUsr.FullName;
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

            dataGridView1.DataSource = await sS.getAll();
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[2].Visible = false;
            dataGridView1.Columns.Add("Student name", "Student name");
            dataGridView1.Columns.Add("", "");
            dataGridView1.Columns.Add("", "");


            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                var row = dataGridView1.Rows[i];

                UserModel cUsr;
                int usrID = Int32.Parse(row.Cells["StudentID"].Value.ToString());
                cUsr = users.FirstOrDefault(l => l.ID == usrID);
                row.Cells["Student name"].Value = cUsr.FullName;
                DataGridViewButtonCell bEdit = new DataGridViewButtonCell();
                bEdit.Value = "edit";
                row.Cells[dataGridView1.ColumnCount - 2] = bEdit;
                DataGridViewButtonCell bDelete = new DataGridViewButtonCell();
                bDelete.Value = "delete";
                row.Cells[dataGridView1.ColumnCount - 1] = bDelete;
            }
        }

        public SubmissionsCRUD()
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
                SubmissionModel sm = new SubmissionModel();
                int ID = Int32.Parse(row.Cells["ID"].Value.ToString());
                sm.ID = ID;
                sm.AssignmentID = Int32.Parse(row.Cells["AssignmentID"].Value.ToString());

                if (row.Cells["Student name"].Value == null) return;
                else
                {
                    string name = row.Cells["Student name"].Value.ToString();
                    int usrID = 0;
                    foreach (UserModel u in users)
                    {
                        if (u.FullName == name) usrID = u.ID;
                    }
                    sm.StudentID = usrID;
                }
                if (row.Cells["GitLink"].Value == null) sm.GitLink = null;
                else sm.GitLink = row.Cells["GitLink"].Value.ToString();

                if (row.Cells["Notes"].Value == null) sm.Notes = null;
                else sm.Notes = row.Cells["Notes"].Value.ToString();

                if (row.Cells["Grade"].Value != null)
                {
                    decimal grade = Decimal.Parse(row.Cells["Grade"].Value.ToString());
                    sm.Grade = grade;
                }


                sS.update(sm);

                for (int i = 0; i < 100000000; i++) ;
                refreshGridV();

            }
            if (e.ColumnIndex == (dataGridView1.ColumnCount - 1))
            {
                //delete
                var row = dataGridView1.Rows[e.RowIndex];
                sS.deleteByID(Int32.Parse(row.Cells["ID"].Value.ToString()));
                for (int i = 0; i < 100000000; i++) ;
                refreshGridV();
            }
        }

        private void addButton_Click_1(object sender, EventArgs e)
        {
            if (gitTextBox.Text == null) return;
            if (notesTextBox.Text == null) return;
            if (studentComboBox.SelectedValue == null) return;

            string name = studentComboBox.SelectedValue.ToString();
            int studentID = 0;
            foreach (UserModel s in users)
            {
                if (s.FullName == name) studentID = s.ID;
            }

            SubmissionModelAPI sm = new SubmissionModelAPI() { StudentID = studentID, GitLink = gitTextBox.Text, Notes = notesTextBox.Text };
            sm.AssignmentID = Int32.Parse(assignmentTextBox.Text);

            sS.addSubmission(sm);

            for (int i = 0; i < 100000000; i++) ;
            refreshGridV();
        }
    }
}
