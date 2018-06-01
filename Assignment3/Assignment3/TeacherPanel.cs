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
    public partial class TeacherPanel : Form
    {
        public TeacherPanel(string email, string pass)
        {
            InitializeComponent();
        }

        private void userButton_Click(object sender, EventArgs e)
        {
            var userCRUD = new UsersCRUD();
            userCRUD.Show();
        }

        private void laboratoryButton_Click(object sender, EventArgs e)
        {
            var laboratoryCRUD = new LaboratoriesCRUD();
            laboratoryCRUD.Show();
        }

        private void assignmentButton_Click(object sender, EventArgs e)
        {
            var assignmentCRUD = new AssignmentsCRUD();
            assignmentCRUD.Show();
        }

        private void attendanceButton_Click(object sender, EventArgs e)
        {
            var attendanceCRUD = new AttendanceCRUD();
            attendanceCRUD.Show();
        }

        private void submissionButton_Click(object sender, EventArgs e)
        {
            var submissionsCRUD = new SubmissionsCRUD();
            submissionsCRUD.Show();
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
