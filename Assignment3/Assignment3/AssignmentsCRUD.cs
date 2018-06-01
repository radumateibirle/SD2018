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
    public partial class AssignmentsCRUD : Form
    {
        AssignmentServices aS = new AssignmentServices();
        LaboratoryServices lS = new LaboratoryServices();
        SubmissionServices sS = new SubmissionServices();
        UserServices uS = new UserServices();
        List<LaboratoryModel> labs;
        List<AssignmentModel> assigns;
        List<UserModel> users;
        public async void initGridV()
        {
            dataGridView1.DataSource = await aS.getAll();
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].Visible = false;
            dataGridView1.Columns.Add("Laboratory number", "Laboratory number");
            dataGridView1.Columns.Add("", "");
            dataGridView1.Columns.Add("", "");
            dataGridView1.Columns["Description"].Width = 230;

            users = await uS.getAll();
            assigns = await aS.getAll();
            List<string> aNames = new List<string>();
            assigns.ForEach(a => aNames.Add(a.Name));
            assignmentComboBox.DataSource = aNames;

            labs = await lS.getAll();
            List<int> labNumbers = new List<int>();

            foreach (LaboratoryModel l in labs)
            {
                labNumbers.Add(l.Number);
            }
            labNrComboBox.DataSource = labNumbers;

            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                var row = dataGridView1.Rows[i];

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
            dataGridView1.Columns.Add("Laboratory number", "Laboratory number");
            dataGridView1.Columns.Add("", "");
            dataGridView1.Columns.Add("", "");
            dataGridView1.Columns["Description"].Width = 230;
            assigns = await aS.getAll();

            var lS = new LaboratoryServices();
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                var row = dataGridView1.Rows[i];

                List<LaboratoryModel> labs = await lS.getAll();
                LaboratoryModel cLab;
                int labID = Int32.Parse(row.Cells[1].Value.ToString());
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

        public AssignmentsCRUD()
        {
            InitializeComponent();
            initGridV();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            if (nameTextBox.Text == null) return;
            if (descriptionTextBox.Text == null) return;
            if (labNrComboBox.SelectedValue == null) return;

            int labNr = Int32.Parse(labNrComboBox.SelectedValue.ToString());
            int labID = 0;
            foreach (LaboratoryModel l in labs)
            {
                if (l.Number == labNr) labID = l.ID;
            }

            AssignmentModelAPI am = new AssignmentModelAPI() { LaboratoryID = labID, Name = nameTextBox.Text, Deadline = datePicker.Value.Date, Description = descriptionTextBox.Text };

            aS.addAssignment(am);

            for (int i = 0; i < 100000000; i++) ;
            refreshGridV();
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

            if (e.ColumnIndex == (dataGridView1.ColumnCount - 2))
            {
                //edit
                var row = dataGridView1.Rows[e.RowIndex];
                AssignmentModel am = new AssignmentModel();
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
                if (row.Cells["Name"].Value == null) am.Name = null;
                else am.Name = row.Cells["Name"].Value.ToString();

                DateTime dt;
                DateTime.TryParse(row.Cells["Deadline"].Value.ToString(), out dt);
                am.Deadline = dt;

                if (row.Cells["Description"].Value == null) am.Description = null;
                else am.Description = row.Cells["Description"].Value.ToString();

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

        private async void assignmentComboBox_SelectedIndexChangedAsync(object sender, EventArgs e)
        {
            studentGradeDGV.DataSource = null;
            studentGradeDGV.Rows.Clear();
            studentGradeDGV.Columns.Clear();
            studentGradeDGV.Refresh();

            string assignmentName = assignmentComboBox.SelectedValue.ToString();
            int assID = 0;
            foreach(AssignmentModel a in assigns)
            {
                if (a.Name == assignmentName) assID = a.ID;
            }

            List<SubmissionModel>submission = await sS.getAll();
            List<SubmissionModel> subForID = new List<SubmissionModel>();
            foreach(SubmissionModel s in submission)
            {
                if (s.AssignmentID == assID) subForID.Add(s);
            }

            studentGradeDGV.DataSource = subForID;
            studentGradeDGV.Columns["ID"].Visible = false;
            studentGradeDGV.Columns["AssignmentID"].Visible = false;
            studentGradeDGV.Columns["StudentID"].Visible = false;
            studentGradeDGV.Columns["GitLink"].Visible = false;
            studentGradeDGV.Columns["Notes"].Visible = false;
            studentGradeDGV.Columns.Add("Student", "Student");

            for (int i = 0; i < studentGradeDGV.RowCount; i++)
            {
                var row = studentGradeDGV.Rows[i];

                UserModel cUsr;
                int usrID = Int32.Parse(row.Cells["StudentID"].Value.ToString());
                cUsr = users.FirstOrDefault(l => l.ID == usrID);
                row.Cells["Student"].Value = cUsr.FullName;
            }
        }
    }
}
