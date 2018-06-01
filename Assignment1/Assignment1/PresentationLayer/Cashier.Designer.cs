namespace Assignment1.PresentationLayer
{
    partial class Cashier
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
            this.dgvShows = new System.Windows.Forms.DataGridView();
            this.dgvTickets = new System.Windows.Forms.DataGridView();
            this.ticketSell = new System.Windows.Forms.Button();
            this.ticketDelete = new System.Windows.Forms.Button();
            this.ticketUpdate = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.showTitleText = new System.Windows.Forms.TextBox();
            this.showDateText = new System.Windows.Forms.TextBox();
            this.showRowText = new System.Windows.Forms.TextBox();
            this.showSeatText = new System.Windows.Forms.TextBox();
            this.StatusLabel = new System.Windows.Forms.Label();
            this.ticketID = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.logout = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvShows)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTickets)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvShows
            // 
            this.dgvShows.AllowUserToAddRows = false;
            this.dgvShows.AllowUserToDeleteRows = false;
            this.dgvShows.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvShows.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvShows.Location = new System.Drawing.Point(12, 253);
            this.dgvShows.Name = "dgvShows";
            this.dgvShows.Size = new System.Drawing.Size(495, 371);
            this.dgvShows.TabIndex = 0;
            this.dgvShows.SelectionChanged += new System.EventHandler(this.dgvShows_SelectionChanged);
            // 
            // dgvTickets
            // 
            this.dgvTickets.AllowUserToAddRows = false;
            this.dgvTickets.AllowUserToDeleteRows = false;
            this.dgvTickets.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTickets.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvTickets.Location = new System.Drawing.Point(610, 253);
            this.dgvTickets.Name = "dgvTickets";
            this.dgvTickets.Size = new System.Drawing.Size(372, 371);
            this.dgvTickets.TabIndex = 1;
            this.dgvTickets.SelectionChanged += new System.EventHandler(this.dgvTickets_SelectionChanged);
            // 
            // ticketSell
            // 
            this.ticketSell.Location = new System.Drawing.Point(193, 25);
            this.ticketSell.Name = "ticketSell";
            this.ticketSell.Size = new System.Drawing.Size(96, 23);
            this.ticketSell.TabIndex = 2;
            this.ticketSell.Text = "Sell ticket";
            this.ticketSell.UseVisualStyleBackColor = true;
            this.ticketSell.Click += new System.EventHandler(this.ticketSell_Click);
            // 
            // ticketDelete
            // 
            this.ticketDelete.Location = new System.Drawing.Point(193, 78);
            this.ticketDelete.Name = "ticketDelete";
            this.ticketDelete.Size = new System.Drawing.Size(96, 23);
            this.ticketDelete.TabIndex = 3;
            this.ticketDelete.Text = "Cancel ticket";
            this.ticketDelete.UseVisualStyleBackColor = true;
            this.ticketDelete.Click += new System.EventHandler(this.ticketDelete_Click);
            // 
            // ticketUpdate
            // 
            this.ticketUpdate.Location = new System.Drawing.Point(193, 131);
            this.ticketUpdate.Name = "ticketUpdate";
            this.ticketUpdate.Size = new System.Drawing.Size(96, 23);
            this.ticketUpdate.TabIndex = 4;
            this.ticketUpdate.Text = "Edit ticket";
            this.ticketUpdate.UseVisualStyleBackColor = true;
            this.ticketUpdate.Click += new System.EventHandler(this.ticketUpdate_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Show title";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Show date";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Row";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 126);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Seat";
            // 
            // showTitleText
            // 
            this.showTitleText.Location = new System.Drawing.Point(12, 25);
            this.showTitleText.Name = "showTitleText";
            this.showTitleText.ReadOnly = true;
            this.showTitleText.Size = new System.Drawing.Size(100, 20);
            this.showTitleText.TabIndex = 9;
            // 
            // showDateText
            // 
            this.showDateText.Location = new System.Drawing.Point(12, 64);
            this.showDateText.Name = "showDateText";
            this.showDateText.ReadOnly = true;
            this.showDateText.Size = new System.Drawing.Size(100, 20);
            this.showDateText.TabIndex = 10;
            // 
            // showRowText
            // 
            this.showRowText.Location = new System.Drawing.Point(12, 103);
            this.showRowText.Name = "showRowText";
            this.showRowText.Size = new System.Drawing.Size(100, 20);
            this.showRowText.TabIndex = 11;
            // 
            // showSeatText
            // 
            this.showSeatText.Location = new System.Drawing.Point(12, 142);
            this.showSeatText.Name = "showSeatText";
            this.showSeatText.Size = new System.Drawing.Size(100, 20);
            this.showSeatText.TabIndex = 12;
            // 
            // StatusLabel
            // 
            this.StatusLabel.AutoSize = true;
            this.StatusLabel.Location = new System.Drawing.Point(12, 237);
            this.StatusLabel.Name = "StatusLabel";
            this.StatusLabel.Size = new System.Drawing.Size(41, 13);
            this.StatusLabel.TabIndex = 13;
            this.StatusLabel.Text = "Ready!";
            // 
            // ticketID
            // 
            this.ticketID.Location = new System.Drawing.Point(12, 181);
            this.ticketID.Name = "ticketID";
            this.ticketID.ReadOnly = true;
            this.ticketID.Size = new System.Drawing.Size(100, 20);
            this.ticketID.TabIndex = 14;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 165);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "Ticket ID";
            // 
            // logout
            // 
            this.logout.Location = new System.Drawing.Point(907, 9);
            this.logout.Name = "logout";
            this.logout.Size = new System.Drawing.Size(75, 23);
            this.logout.TabIndex = 16;
            this.logout.Text = "LogOut";
            this.logout.UseVisualStyleBackColor = true;
            this.logout.Click += new System.EventHandler(this.logout_Click);
            // 
            // Cashier
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(994, 636);
            this.Controls.Add(this.logout);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.ticketID);
            this.Controls.Add(this.StatusLabel);
            this.Controls.Add(this.showSeatText);
            this.Controls.Add(this.showRowText);
            this.Controls.Add(this.showDateText);
            this.Controls.Add(this.showTitleText);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ticketUpdate);
            this.Controls.Add(this.ticketDelete);
            this.Controls.Add(this.ticketSell);
            this.Controls.Add(this.dgvTickets);
            this.Controls.Add(this.dgvShows);
            this.Name = "Cashier";
            this.Text = "Cashier";
            ((System.ComponentModel.ISupportInitialize)(this.dgvShows)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTickets)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvShows;
        private System.Windows.Forms.DataGridView dgvTickets;
        private System.Windows.Forms.Button ticketSell;
        private System.Windows.Forms.Button ticketDelete;
        private System.Windows.Forms.Button ticketUpdate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox showTitleText;
        private System.Windows.Forms.TextBox showDateText;
        private System.Windows.Forms.TextBox showRowText;
        private System.Windows.Forms.TextBox showSeatText;
        private System.Windows.Forms.Label StatusLabel;
        private System.Windows.Forms.TextBox ticketID;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button logout;
    }
}