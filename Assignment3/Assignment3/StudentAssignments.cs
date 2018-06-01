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
    public partial class StudentAssignments : Form
    {
        int userID;
        int laboratoryID;
        AssignmentServices aS = new AssignmentServices();

        public async void initGridV()
        {
            List<AssignmentModel> allAssignments = await aS.getAll();
            List<AssignmentModel> assList = new List<AssignmentModel>();
            foreach(AssignmentModel a in allAssignments)
            {
                if (a.LaboratoryID == laboratoryID) assList.Add(a);
            }
            dataGridView1.DataSource = assList;
            dataGridView1.Columns["LaboratoryID"].Visible = false;
            dataGridView1.Columns["ID"].Visible = false;
            dataGridView1.Columns.Add("", "");
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                var row = dataGridView1.Rows[i];
                DataGridViewButtonCell bAssign = new DataGridViewButtonCell();
                bAssign.Value = "Add submission";
                row.Cells[dataGridView1.ColumnCount - 1] = bAssign;
            }
        }
        public StudentAssignments(int labID, int usrID)
        {
            InitializeComponent();
            initGridV();
            userID = usrID;
            laboratoryID = labID;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.ColumnIndex == (dataGridView1.ColumnCount - 1))
            {
                //see assignments
                var row = dataGridView1.Rows[e.RowIndex];

                var sub = new CreateSubmission(Int32.Parse(row.Cells["ID"].Value.ToString()), userID);
                sub.Show();
            }
        }
    }
}
