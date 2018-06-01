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
    public partial class CreateSubmission : Form
    {
        int aID;
        int uID;
        public CreateSubmission(int assignID, int userID)
        {
            InitializeComponent();
            aID = assignID;
            uID = userID;
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            if (gitTextBox.Text == null) return;
            if (notesTextBox.Text == null) return;
            SubmissionServices sS = new SubmissionServices();
            SubmissionModelAPI sm = new SubmissionModelAPI();
            sm.AssignmentID = aID;
            sm.StudentID = uID;
            sm.GitLink = gitTextBox.Text;
            sm.Notes = notesTextBox.Text;

            sS.addSubmission(sm);

            this.Close();
        }
    }
}
