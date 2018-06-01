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
    public partial class AttendanceCRUD : Form
    {
        AttendanceServices aS = new AttendanceServices();
        UserServices uS = new UserServices();
        LaboratoryServices lS = new LaboratoryServices();

        List<UserModel> users;
        List<LaboratoryModel> labs;

        public async void initGridV()
        {
            dataGridView1.DataSource = await aS.getAll();
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].Visible = false;
            dataGridView1.Columns[2].Visible = false;
            dataGridView1.Columns.Add("Student name", "Student name");
            dataGridView1.Columns.Add("Laboratory number", "Laboratory number");
            dataGridView1.Columns.Add("", "");
            dataGridView1.Columns.Add("", "");

            users = await uS.getAll();
            List<string> userNames = new List<string>();

            foreach (UserModel u in users)
            {
                userNames.Add(u.FullName);
            }
            usersComboBox.DataSource = userNames;

            labs = await lS.getAll();
            List<int> labNumbers = new List<int>();

            foreach (LaboratoryModel l in labs)
            {
                labNumbers.Add(l.Number);
            }
            LaboratoriesComboBox.DataSource = labNumbers;

            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                var row = dataGridView1.Rows[i];

                UserModel cUsr;
                int usrID = Int32.Parse(row.Cells["StudentID"].Value.ToString());
                cUsr = users.FirstOrDefault(l => l.ID == usrID);
                row.Cells["Student name"].Value = cUsr.FullName;

                LaboratoryModel cLab;
                int labID = Int32.Parse(row.Cells["LaboratoryID"].Value.ToString());
                cLab = labs.FirstOrDefault(l => l.ID == labID);
                row.Cells["Laboratory number"].Value = cLab.Number;

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

            dataGridView1.DataSource = await aS.getAll();
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].Visible = false;
            dataGridView1.Columns[2].Visible = false;
            dataGridView1.Columns.Add("Student name", "Student name");
            dataGridView1.Columns.Add("Laboratory number", "Laboratory number");
            dataGridView1.Columns.Add("", "");
            dataGridView1.Columns.Add("", "");

            users = await uS.getAll();
            List<string> userNames = new List<string>();

            foreach (UserModel u in users)
            {
                userNames.Add(u.FullName);
            }
            usersComboBox.DataSource = userNames;

            labs = await lS.getAll();
            List<int> labNumbers = new List<int>();

            foreach (LaboratoryModel l in labs)
            {
                labNumbers.Add(l.Number);
            }
            LaboratoriesComboBox.DataSource = labNumbers;

            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                var row = dataGridView1.Rows[i];
                
                UserModel cUsr;
                int usrID = Int32.Parse(row.Cells["StudentID"].Value.ToString());
                cUsr = users.FirstOrDefault(l => l.ID == usrID);
                row.Cells["Student name"].Value = cUsr.FullName;

                LaboratoryModel cLab;
                int labID = Int32.Parse(row.Cells["LaboratoryID"].Value.ToString());
                cLab = labs.FirstOrDefault(l => l.ID == labID);
                row.Cells["Laboratory number"].Value = cLab.Number;

                DataGridViewButtonCell bEdit = new DataGridViewButtonCell();
                bEdit.Value = "edit";
                row.Cells[dataGridView1.ColumnCount - 2] = bEdit;
                DataGridViewButtonCell bDelete = new DataGridViewButtonCell();
                bDelete.Value = "delete";
                row.Cells[dataGridView1.ColumnCount - 1] = bDelete;
            }
        }

        public AttendanceCRUD()
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
                AttendanceModel am = new AttendanceModel();
                int ID = Int32.Parse(row.Cells["ID"].Value.ToString());
                am.ID = ID;

                if (row.Cells["Laboratory number"].Value == null) return;
                else
                {
                    int labNr = Int32.Parse(row.Cells["Laboratory number"].Value.ToString());
                    int labID = 0;
                    foreach (LaboratoryModel l in labs)
                    {
                        if (l.Number == labNr) labID = l.ID;
                    }
                    am.LaboratoryID = labID;
                }

                if (row.Cells["Student name"].Value == null) return;
                else
                {
                    string name = row.Cells["Student name"].Value.ToString();
                    int usrID = 0;
                    foreach (UserModel u in users)
                    {
                        if (u.FullName == name) usrID = u.ID;
                    }
                    am.StudentID = usrID;
                }
                aS.update(am);

                for (int i = 0; i < 100000000; i++) ;
                refreshGridV();

            }
            if (e.ColumnIndex == (dataGridView1.ColumnCount - 1))
            {
                //delete
                var row = dataGridView1.Rows[e.RowIndex];
                aS.deleteByID(Int32.Parse(row.Cells["ID"].Value.ToString()));
                for (int i = 0; i < 100000000; i++) ;
                refreshGridV();
            }
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            if (usersComboBox.SelectedValue == null) return;

            string name = usersComboBox.SelectedValue.ToString();
            int studentID = 0;
            foreach (UserModel s in users)
            {
                if (s.FullName == name) studentID = s.ID;
            }

            int labNr = Int32.Parse(LaboratoriesComboBox.SelectedValue.ToString());
            int labID = 0;
            foreach (LaboratoryModel l in labs)
            {
                if (l.Number == labNr) labID = l.ID;
            }

            AttendanceModelAPI am = new AttendanceModelAPI() { StudentID = studentID, LaboratoryID = labID };

            aS.addAttendance(am);

            for (int i = 0; i < 100000000; i++) ;
            refreshGridV();
        }
    }
}