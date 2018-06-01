namespace Assignment1.PresentationLayer
{
    partial class Admin
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
            this.dgvUsersTable = new System.Windows.Forms.DataGridView();
            this.dgvShowsTable = new System.Windows.Forms.DataGridView();
            this.userIDText = new System.Windows.Forms.TextBox();
            this.userUsernameText = new System.Windows.Forms.TextBox();
            this.userPasswordText = new System.Windows.Forms.TextBox();
            this.IDLabel = new System.Windows.Forms.Label();
            this.UsernameLabel = new System.Windows.Forms.Label();
            this.PasswordLabel = new System.Windows.Forms.Label();
            this.FunctionLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.showIDText = new System.Windows.Forms.TextBox();
            this.showTitleText = new System.Windows.Forms.TextBox();
            this.showDistributionText = new System.Windows.Forms.TextBox();
            this.showNrTicketsText = new System.Windows.Forms.TextBox();
            this.showGenreSelection = new System.Windows.Forms.ComboBox();
            this.userAdd = new System.Windows.Forms.Button();
            this.userEdit = new System.Windows.Forms.Button();
            this.userDelete = new System.Windows.Forms.Button();
            this.showAdd = new System.Windows.Forms.Button();
            this.showEdit = new System.Windows.Forms.Button();
            this.showDelete = new System.Windows.Forms.Button();
            this.exportXMLSelected = new System.Windows.Forms.Button();
            this.exportCSVSelected = new System.Windows.Forms.Button();
            this.exportXMLAll = new System.Windows.Forms.Button();
            this.exportCSVAll = new System.Windows.Forms.Button();
            this.userFunctionSelection = new System.Windows.Forms.ComboBox();
            this.StatusLabel = new System.Windows.Forms.Label();
            this.showDatePicker = new System.Windows.Forms.DateTimePicker();
            this.logout = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsersTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvShowsTable)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvUsersTable
            // 
            this.dgvUsersTable.AllowUserToAddRows = false;
            this.dgvUsersTable.AllowUserToDeleteRows = false;
            this.dgvUsersTable.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.dgvUsersTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUsersTable.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvUsersTable.Location = new System.Drawing.Point(12, 274);
            this.dgvUsersTable.Name = "dgvUsersTable";
            this.dgvUsersTable.ReadOnly = true;
            this.dgvUsersTable.ShowEditingIcon = false;
            this.dgvUsersTable.Size = new System.Drawing.Size(450, 350);
            this.dgvUsersTable.TabIndex = 0;
            this.dgvUsersTable.SelectionChanged += new System.EventHandler(this.dgvUsersTable_SelectionChanged);
            // 
            // dgvShowsTable
            // 
            this.dgvShowsTable.AllowUserToAddRows = false;
            this.dgvShowsTable.AllowUserToDeleteRows = false;
            this.dgvShowsTable.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.dgvShowsTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvShowsTable.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvShowsTable.Location = new System.Drawing.Point(532, 274);
            this.dgvShowsTable.Name = "dgvShowsTable";
            this.dgvShowsTable.ShowEditingIcon = false;
            this.dgvShowsTable.Size = new System.Drawing.Size(450, 350);
            this.dgvShowsTable.TabIndex = 1;
            this.dgvShowsTable.SelectionChanged += new System.EventHandler(this.dgvShowsTable_SelectionChanged);
            // 
            // userIDText
            // 
            this.userIDText.Location = new System.Drawing.Point(12, 34);
            this.userIDText.Name = "userIDText";
            this.userIDText.Size = new System.Drawing.Size(150, 20);
            this.userIDText.TabIndex = 2;
            // 
            // userUsernameText
            // 
            this.userUsernameText.Location = new System.Drawing.Point(12, 73);
            this.userUsernameText.Name = "userUsernameText";
            this.userUsernameText.Size = new System.Drawing.Size(150, 20);
            this.userUsernameText.TabIndex = 3;
            // 
            // userPasswordText
            // 
            this.userPasswordText.Location = new System.Drawing.Point(12, 112);
            this.userPasswordText.Name = "userPasswordText";
            this.userPasswordText.PasswordChar = '*';
            this.userPasswordText.Size = new System.Drawing.Size(150, 20);
            this.userPasswordText.TabIndex = 4;
            // 
            // IDLabel
            // 
            this.IDLabel.AutoSize = true;
            this.IDLabel.Location = new System.Drawing.Point(12, 18);
            this.IDLabel.Name = "IDLabel";
            this.IDLabel.Size = new System.Drawing.Size(18, 13);
            this.IDLabel.TabIndex = 6;
            this.IDLabel.Text = "ID";
            // 
            // UsernameLabel
            // 
            this.UsernameLabel.AutoSize = true;
            this.UsernameLabel.Location = new System.Drawing.Point(9, 57);
            this.UsernameLabel.Name = "UsernameLabel";
            this.UsernameLabel.Size = new System.Drawing.Size(55, 13);
            this.UsernameLabel.TabIndex = 7;
            this.UsernameLabel.Text = "Username";
            // 
            // PasswordLabel
            // 
            this.PasswordLabel.AutoSize = true;
            this.PasswordLabel.Location = new System.Drawing.Point(9, 96);
            this.PasswordLabel.Name = "PasswordLabel";
            this.PasswordLabel.Size = new System.Drawing.Size(53, 13);
            this.PasswordLabel.TabIndex = 8;
            this.PasswordLabel.Text = "Password";
            // 
            // FunctionLabel
            // 
            this.FunctionLabel.AutoSize = true;
            this.FunctionLabel.Location = new System.Drawing.Point(9, 135);
            this.FunctionLabel.Name = "FunctionLabel";
            this.FunctionLabel.Size = new System.Drawing.Size(48, 13);
            this.FunctionLabel.TabIndex = 9;
            this.FunctionLabel.Text = "Function";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(964, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(18, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "ID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(955, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Title";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(946, 96);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Genre";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(923, 135);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Distribution";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(952, 174);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(30, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "Date";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(892, 213);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(90, 13);
            this.label6.TabIndex = 15;
            this.label6.Text = "Number of tickets";
            // 
            // showIDText
            // 
            this.showIDText.Location = new System.Drawing.Point(782, 34);
            this.showIDText.Name = "showIDText";
            this.showIDText.Size = new System.Drawing.Size(200, 20);
            this.showIDText.TabIndex = 16;
            // 
            // showTitleText
            // 
            this.showTitleText.Location = new System.Drawing.Point(782, 73);
            this.showTitleText.Name = "showTitleText";
            this.showTitleText.Size = new System.Drawing.Size(200, 20);
            this.showTitleText.TabIndex = 17;
            // 
            // showDistributionText
            // 
            this.showDistributionText.Location = new System.Drawing.Point(782, 151);
            this.showDistributionText.Name = "showDistributionText";
            this.showDistributionText.Size = new System.Drawing.Size(200, 20);
            this.showDistributionText.TabIndex = 19;
            // 
            // showNrTicketsText
            // 
            this.showNrTicketsText.Location = new System.Drawing.Point(782, 229);
            this.showNrTicketsText.Name = "showNrTicketsText";
            this.showNrTicketsText.Size = new System.Drawing.Size(200, 20);
            this.showNrTicketsText.TabIndex = 21;
            // 
            // showGenreSelection
            // 
            this.showGenreSelection.FormattingEnabled = true;
            this.showGenreSelection.Items.AddRange(new object[] {
            "Opera",
            "Ballet"});
            this.showGenreSelection.Location = new System.Drawing.Point(782, 112);
            this.showGenreSelection.Name = "showGenreSelection";
            this.showGenreSelection.Size = new System.Drawing.Size(200, 21);
            this.showGenreSelection.TabIndex = 22;
            // 
            // userAdd
            // 
            this.userAdd.Location = new System.Drawing.Point(269, 47);
            this.userAdd.Name = "userAdd";
            this.userAdd.Size = new System.Drawing.Size(75, 23);
            this.userAdd.TabIndex = 23;
            this.userAdd.Text = "Add user";
            this.userAdd.UseVisualStyleBackColor = true;
            this.userAdd.Click += new System.EventHandler(this.userAdd_Click);
            // 
            // userEdit
            // 
            this.userEdit.Location = new System.Drawing.Point(269, 96);
            this.userEdit.Name = "userEdit";
            this.userEdit.Size = new System.Drawing.Size(75, 23);
            this.userEdit.TabIndex = 24;
            this.userEdit.Text = "Edit user";
            this.userEdit.UseVisualStyleBackColor = true;
            this.userEdit.Click += new System.EventHandler(this.userEdit_Click);
            // 
            // userDelete
            // 
            this.userDelete.Location = new System.Drawing.Point(269, 148);
            this.userDelete.Name = "userDelete";
            this.userDelete.Size = new System.Drawing.Size(75, 23);
            this.userDelete.TabIndex = 25;
            this.userDelete.Text = "Delete user";
            this.userDelete.UseVisualStyleBackColor = true;
            this.userDelete.Click += new System.EventHandler(this.userDelete_Click);
            // 
            // showAdd
            // 
            this.showAdd.Location = new System.Drawing.Point(648, 47);
            this.showAdd.Name = "showAdd";
            this.showAdd.Size = new System.Drawing.Size(75, 23);
            this.showAdd.TabIndex = 26;
            this.showAdd.Text = "Add show";
            this.showAdd.UseVisualStyleBackColor = true;
            this.showAdd.Click += new System.EventHandler(this.showAdd_Click);
            // 
            // showEdit
            // 
            this.showEdit.Location = new System.Drawing.Point(648, 96);
            this.showEdit.Name = "showEdit";
            this.showEdit.Size = new System.Drawing.Size(75, 23);
            this.showEdit.TabIndex = 27;
            this.showEdit.Text = "Edit show";
            this.showEdit.UseVisualStyleBackColor = true;
            this.showEdit.Click += new System.EventHandler(this.showEdit_Click);
            // 
            // showDelete
            // 
            this.showDelete.Location = new System.Drawing.Point(648, 148);
            this.showDelete.Name = "showDelete";
            this.showDelete.Size = new System.Drawing.Size(75, 23);
            this.showDelete.TabIndex = 28;
            this.showDelete.Text = "Delete show";
            this.showDelete.UseVisualStyleBackColor = true;
            this.showDelete.Click += new System.EventHandler(this.showDelete_Click);
            // 
            // exportXMLSelected
            // 
            this.exportXMLSelected.Location = new System.Drawing.Point(454, 34);
            this.exportXMLSelected.Name = "exportXMLSelected";
            this.exportXMLSelected.Size = new System.Drawing.Size(88, 23);
            this.exportXMLSelected.TabIndex = 29;
            this.exportXMLSelected.Text = "XML Selected";
            this.exportXMLSelected.UseVisualStyleBackColor = true;
            this.exportXMLSelected.Click += new System.EventHandler(this.exportXMLSelected_Click);
            // 
            // exportCSVSelected
            // 
            this.exportCSVSelected.Location = new System.Drawing.Point(454, 91);
            this.exportCSVSelected.Name = "exportCSVSelected";
            this.exportCSVSelected.Size = new System.Drawing.Size(88, 23);
            this.exportCSVSelected.TabIndex = 30;
            this.exportCSVSelected.Text = "CSV Selected";
            this.exportCSVSelected.UseVisualStyleBackColor = true;
            this.exportCSVSelected.Click += new System.EventHandler(this.exportCSVSelected_Click);
            // 
            // exportXMLAll
            // 
            this.exportXMLAll.Location = new System.Drawing.Point(454, 148);
            this.exportXMLAll.Name = "exportXMLAll";
            this.exportXMLAll.Size = new System.Drawing.Size(88, 23);
            this.exportXMLAll.TabIndex = 31;
            this.exportXMLAll.Text = "XML All";
            this.exportXMLAll.UseVisualStyleBackColor = true;
            this.exportXMLAll.Click += new System.EventHandler(this.exportXMLAll_Click);
            // 
            // exportCSVAll
            // 
            this.exportCSVAll.Location = new System.Drawing.Point(454, 203);
            this.exportCSVAll.Name = "exportCSVAll";
            this.exportCSVAll.Size = new System.Drawing.Size(88, 23);
            this.exportCSVAll.TabIndex = 32;
            this.exportCSVAll.Text = "CSV All";
            this.exportCSVAll.UseVisualStyleBackColor = true;
            this.exportCSVAll.Click += new System.EventHandler(this.exportCSVAll_Click);
            // 
            // userFunctionSelection
            // 
            this.userFunctionSelection.FormattingEnabled = true;
            this.userFunctionSelection.Items.AddRange(new object[] {
            "Admin",
            "Cashier"});
            this.userFunctionSelection.Location = new System.Drawing.Point(12, 151);
            this.userFunctionSelection.Name = "userFunctionSelection";
            this.userFunctionSelection.Size = new System.Drawing.Size(150, 21);
            this.userFunctionSelection.TabIndex = 33;
            // 
            // StatusLabel
            // 
            this.StatusLabel.AutoSize = true;
            this.StatusLabel.Location = new System.Drawing.Point(9, 258);
            this.StatusLabel.Name = "StatusLabel";
            this.StatusLabel.Size = new System.Drawing.Size(0, 13);
            this.StatusLabel.TabIndex = 34;
            // 
            // showDatePicker
            // 
            this.showDatePicker.Location = new System.Drawing.Point(782, 190);
            this.showDatePicker.Name = "showDatePicker";
            this.showDatePicker.Size = new System.Drawing.Size(200, 20);
            this.showDatePicker.TabIndex = 35;
            // 
            // logout
            // 
            this.logout.Location = new System.Drawing.Point(12, 203);
            this.logout.Name = "logout";
            this.logout.Size = new System.Drawing.Size(75, 23);
            this.logout.TabIndex = 36;
            this.logout.Text = "LogOut";
            this.logout.UseVisualStyleBackColor = true;
            this.logout.Click += new System.EventHandler(this.logout_Click);
            // 
            // Admin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(994, 636);
            this.Controls.Add(this.logout);
            this.Controls.Add(this.showDatePicker);
            this.Controls.Add(this.StatusLabel);
            this.Controls.Add(this.userFunctionSelection);
            this.Controls.Add(this.exportCSVAll);
            this.Controls.Add(this.exportXMLAll);
            this.Controls.Add(this.exportCSVSelected);
            this.Controls.Add(this.exportXMLSelected);
            this.Controls.Add(this.showDelete);
            this.Controls.Add(this.showEdit);
            this.Controls.Add(this.showAdd);
            this.Controls.Add(this.userDelete);
            this.Controls.Add(this.userEdit);
            this.Controls.Add(this.userAdd);
            this.Controls.Add(this.showGenreSelection);
            this.Controls.Add(this.showNrTicketsText);
            this.Controls.Add(this.showDistributionText);
            this.Controls.Add(this.showTitleText);
            this.Controls.Add(this.showIDText);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.FunctionLabel);
            this.Controls.Add(this.PasswordLabel);
            this.Controls.Add(this.UsernameLabel);
            this.Controls.Add(this.IDLabel);
            this.Controls.Add(this.userPasswordText);
            this.Controls.Add(this.userUsernameText);
            this.Controls.Add(this.userIDText);
            this.Controls.Add(this.dgvShowsTable);
            this.Controls.Add(this.dgvUsersTable);
            this.Name = "Admin";
            this.Text = "Admin";
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsersTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvShowsTable)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvUsersTable;
        private System.Windows.Forms.DataGridView dgvShowsTable;
        private System.Windows.Forms.TextBox userIDText;
        private System.Windows.Forms.TextBox userUsernameText;
        private System.Windows.Forms.TextBox userPasswordText;
        private System.Windows.Forms.Label IDLabel;
        private System.Windows.Forms.Label UsernameLabel;
        private System.Windows.Forms.Label PasswordLabel;
        private System.Windows.Forms.Label FunctionLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox showIDText;
        private System.Windows.Forms.TextBox showTitleText;
        private System.Windows.Forms.TextBox showDistributionText;
        private System.Windows.Forms.TextBox showNrTicketsText;
        private System.Windows.Forms.ComboBox showGenreSelection;
        private System.Windows.Forms.Button userAdd;
        private System.Windows.Forms.Button userEdit;
        private System.Windows.Forms.Button userDelete;
        private System.Windows.Forms.Button showAdd;
        private System.Windows.Forms.Button showEdit;
        private System.Windows.Forms.Button showDelete;
        private System.Windows.Forms.Button exportXMLSelected;
        private System.Windows.Forms.Button exportCSVSelected;
        private System.Windows.Forms.Button exportXMLAll;
        private System.Windows.Forms.Button exportCSVAll;
        private System.Windows.Forms.ComboBox userFunctionSelection;
        private System.Windows.Forms.Label StatusLabel;
        private System.Windows.Forms.DateTimePicker showDatePicker;
        private System.Windows.Forms.Button logout;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
    }
}