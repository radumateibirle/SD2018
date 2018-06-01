namespace Assignment3
{
    partial class TeacherPanel
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.userButton = new System.Windows.Forms.Button();
            this.laboratoryButton = new System.Windows.Forms.Button();
            this.assignmentButton = new System.Windows.Forms.Button();
            this.attendanceButton = new System.Windows.Forms.Button();
            this.submissionButton = new System.Windows.Forms.Button();
            this.doneButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // userButton
            // 
            this.userButton.Location = new System.Drawing.Point(187, 52);
            this.userButton.Name = "userButton";
            this.userButton.Size = new System.Drawing.Size(75, 23);
            this.userButton.TabIndex = 0;
            this.userButton.Text = "Users";
            this.userButton.UseVisualStyleBackColor = true;
            this.userButton.Click += new System.EventHandler(this.userButton_Click);
            // 
            // laboratoryButton
            // 
            this.laboratoryButton.Location = new System.Drawing.Point(187, 100);
            this.laboratoryButton.Name = "laboratoryButton";
            this.laboratoryButton.Size = new System.Drawing.Size(75, 23);
            this.laboratoryButton.TabIndex = 1;
            this.laboratoryButton.Text = "Laboratories";
            this.laboratoryButton.UseVisualStyleBackColor = true;
            this.laboratoryButton.UseWaitCursor = true;
            this.laboratoryButton.Click += new System.EventHandler(this.laboratoryButton_Click);
            // 
            // assignmentButton
            // 
            this.assignmentButton.Location = new System.Drawing.Point(187, 148);
            this.assignmentButton.Name = "assignmentButton";
            this.assignmentButton.Size = new System.Drawing.Size(75, 23);
            this.assignmentButton.TabIndex = 2;
            this.assignmentButton.Text = "Assignments";
            this.assignmentButton.UseVisualStyleBackColor = true;
            this.assignmentButton.Click += new System.EventHandler(this.assignmentButton_Click);
            // 
            // attendanceButton
            // 
            this.attendanceButton.Location = new System.Drawing.Point(187, 197);
            this.attendanceButton.Name = "attendanceButton";
            this.attendanceButton.Size = new System.Drawing.Size(75, 23);
            this.attendanceButton.TabIndex = 3;
            this.attendanceButton.Text = "Attendance";
            this.attendanceButton.UseVisualStyleBackColor = true;
            this.attendanceButton.Click += new System.EventHandler(this.attendanceButton_Click);
            // 
            // submissionButton
            // 
            this.submissionButton.Location = new System.Drawing.Point(187, 249);
            this.submissionButton.Name = "submissionButton";
            this.submissionButton.Size = new System.Drawing.Size(75, 23);
            this.submissionButton.TabIndex = 4;
            this.submissionButton.Text = "Submissions";
            this.submissionButton.UseVisualStyleBackColor = true;
            this.submissionButton.Click += new System.EventHandler(this.submissionButton_Click);
            // 
            // doneButton
            // 
            this.doneButton.Location = new System.Drawing.Point(367, 296);
            this.doneButton.Name = "doneButton";
            this.doneButton.Size = new System.Drawing.Size(75, 23);
            this.doneButton.TabIndex = 5;
            this.doneButton.Text = "Done!";
            this.doneButton.UseVisualStyleBackColor = true;
            this.doneButton.Click += new System.EventHandler(this.doneButton_Click);
            // 
            // TeacherPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(454, 331);
            this.Controls.Add(this.doneButton);
            this.Controls.Add(this.submissionButton);
            this.Controls.Add(this.attendanceButton);
            this.Controls.Add(this.assignmentButton);
            this.Controls.Add(this.laboratoryButton);
            this.Controls.Add(this.userButton);
            this.Name = "TeacherPanel";
            this.Text = "TeacherPanel";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button userButton;
        private System.Windows.Forms.Button laboratoryButton;
        private System.Windows.Forms.Button assignmentButton;
        private System.Windows.Forms.Button attendanceButton;
        private System.Windows.Forms.Button submissionButton;
        private System.Windows.Forms.Button doneButton;
    }
}