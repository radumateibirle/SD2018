using Assignment1.ServicesLayer.Contracts;
using Assignment1.ServicesLayer.Models;
using Assignment1.ServicesLayer.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Assignment1.PresentationLayer
{
    public partial class Admin : Form
    {
        private IUserService userServices;
        private IShowService showServices;
        private int firstRunUsers = 0;
        private int firstRunShows = 0;

        public Admin()
        {
            InitializeComponent();
            userServices = new UserService();
            showServices = new ShowServices();
            
            dgvUsersTable.ColumnCount = 4;
            dgvUsersTable.Columns[0].Name = "ID";
            dgvUsersTable.Columns[1].Name = "Username";
            dgvUsersTable.Columns[2].Name = "Password";
            dgvUsersTable.Columns[3].Name = "Function";
            userServices.getUsers().ForEach(user => dgvUsersTable.Rows.Add(user.ToStringArray()));
            
            dgvShowsTable.ColumnCount = 6;
            dgvShowsTable.Columns[0].Name = "ID";
            dgvShowsTable.Columns[1].Name = "Title";
            dgvShowsTable.Columns[2].Name = "Genre";
            dgvShowsTable.Columns[3].Name = "Distribution";
            dgvShowsTable.Columns[4].Name = "Date";
            dgvShowsTable.Columns[5].Name = "Tickets";

            showServices.getShows().ForEach(show => dgvShowsTable.Rows.Add(show.ToStringArray()));
            StatusLabel.Text = "Ready!";
        }

        private void userAdd_Click(object sender, EventArgs e)
        {
            if(userUsernameText.Text == "")
            {
                StatusLabel.Text = "Error! No username chosen!";
                return;
            }
            if (userPasswordText.Text == "")
            {
                StatusLabel.Text = "Error! No password chosen!";
                return;
            }
            if (userFunctionSelection.SelectedIndex != 0 && userFunctionSelection.SelectedIndex != 1)
            {
                StatusLabel.Text = "Error! No function chosen!";
                return;
            }
            if (userServices.isUsername(userUsernameText.Text))
            {
                StatusLabel.Text = "Error! Username already exists! Try using another username or edit the existing one!";
                return;
            }
            UserModel model = new UserModel();
            model.setUsername(userUsernameText.Text);
            model.setPlainPassword(userPasswordText.Text);
            if (userFunctionSelection.SelectedIndex == 0) model.setFunction(0);
            else model.setFunction(10);
            userServices.add(model);

            //refresh
            UsersRefresh();
            StatusLabel.Text = "User added!";
        }

        private void userEdit_Click(object sender, EventArgs e)
        {
            if (userIDText.Text == "")
            {
                StatusLabel.Text = "Error! No ID chosen!";
                return;
            }
            if (userUsernameText.Text == "")
            {
                StatusLabel.Text = "Error! No username chosen!";
                return;
            }
            if (userPasswordText.Text == "")
            {
                StatusLabel.Text = "Error! No password chosen!";
                return;
            }
            if (userFunctionSelection.SelectedIndex != 0 && userFunctionSelection.SelectedIndex != 1)
            {
                StatusLabel.Text = "Error! No function chosen!";
                return;
            }
            if (!userServices.isID(Convert.ToInt32(userIDText.Text)))
            {
                StatusLabel.Text = "Error! The user with the given ID does not exist!";
            }
            
            UserModel model = new UserModel();
            model.setID(Convert.ToInt32(userIDText.Text));
            model.setUsername(userUsernameText.Text);
            if (userFunctionSelection.SelectedIndex == 0) model.setFunction(0);
            else model.setFunction(10);
            UserModel oldmodel = userServices.getUserByID(model.getID());
            if(oldmodel == null)
            {
                StatusLabel.Text = "Error! User not found!";
                return;
            }
            model.setHashedPassword(oldmodel.getPassword());
            userServices.update(model);

            //refresh
            UsersRefresh();
            StatusLabel.Text = "User edited!";
        }

        private void userDelete_Click(object sender, EventArgs e)
        {
            if (userIDText.Text == "")
            {
                StatusLabel.Text = "Error! No ID chosen!";
                return;
            }
            if (!userServices.isID(Convert.ToInt32(userIDText.Text)))
            {
                StatusLabel.Text = "Error! The user with the given ID does not exist!";
            }
            userServices.delete(Convert.ToInt32(userIDText.Text));

            //refresh
            UsersRefresh();
            StatusLabel.Text = "User deleted";
        }

        private void dgvUsersTable_SelectionChanged(object sender, EventArgs e)
        {
            if (firstRunUsers != 0)
            {
                int row = dgvUsersTable.CurrentCell.RowIndex;

                userIDText.Text = dgvUsersTable.Rows[row].Cells[0].Value.ToString();
                userUsernameText.Text = dgvUsersTable.Rows[row].Cells[1].Value.ToString();
                userPasswordText.Text = dgvUsersTable.Rows[row].Cells[2].Value.ToString();
                if (dgvUsersTable.Rows[row].Cells[3].Value.ToString() == "Admin") userFunctionSelection.SelectedIndex = 0; else userFunctionSelection.SelectedIndex = 1;
            }
            else firstRunUsers++;
        }

        private void UsersRefresh()
        {
            dgvUsersTable.Rows.Clear();
            userServices.getUsers().ForEach(user => dgvUsersTable.Rows.Add(user.ToStringArray()));

            userIDText.Text = "";
            userUsernameText.Text = "";
            userPasswordText.Text = "";
            userFunctionSelection.SelectedIndex = -1;
        }

        private void showAdd_Click(object sender, EventArgs e)
        {
            if (!showNrTicketsText.Text.All(Char.IsDigit))
            {
                StatusLabel.Text = "Invalid number of tickets selected!";
                return;
            }
            if (showTitleText.Text == "")
            {
                StatusLabel.Text = "Error! No title chosen!";
                return;
            }
            if (showDistributionText.Text == "")
            {
                StatusLabel.Text = "Error! No distribution chosen!";
                return;
            }
            if (showNrTicketsText.Text == "")
            {
                StatusLabel.Text = "Error! No number of tickets chosen!";
                return;
            }
            if (!(showGenreSelection.SelectedIndex == 0 || showGenreSelection.SelectedIndex == 1))
            {
                StatusLabel.Text = "Error! No genre chosen!";
                return;
            }
            if(showServices.isShow(showTitleText.Text, showDatePicker.Value.Date))
            {
                StatusLabel.Text = "Error! Show already exists!";
                return;
            }
            ShowModel model = new ShowModel();
            model.setTitle(showTitleText.Text);
            model.setDistribution(showDistributionText.Text);
            model.setNumberOfTickets(Convert.ToInt32(showNrTicketsText.Text));
            if (showGenreSelection.SelectedIndex == 0) model.setGenre("Opera");
            else model.setGenre("Ballet");
            model.setDate(showDatePicker.Value.Date);
            showServices.add(model);

            //refresh
            ShowRefresh();
            StatusLabel.Text = "Show added!";
        }

        private void showEdit_Click(object sender, EventArgs e)
        {
            if (!showNrTicketsText.Text.All(Char.IsDigit))
            {
                StatusLabel.Text = "Invalid number of tickets selected!";
                return;
            }
            if (showIDText.Text == "")
            {
                StatusLabel.Text = "Error! No ID chosen!";
                return;
            }
            if (showTitleText.Text == "")
            {
                StatusLabel.Text = "Error! No title chosen!";
                return;
            }
            if (showDistributionText.Text == "")
            {
                StatusLabel.Text = "Error! No distribution chosen!";
                return;
            }
            if (showNrTicketsText.Text == "")
            {
                StatusLabel.Text = "Error! No number of tickets chosen!";
                return;
            }
            if (!(showGenreSelection.SelectedIndex == 0 || showGenreSelection.SelectedIndex == 1))
            {
                StatusLabel.Text = "Error! No genre chosen!";
                return;
            }
            if (!showServices.isID(Convert.ToInt32(showIDText.Text)))
            {
                StatusLabel.Text = "Error! The show with the given ID does not exist!";
            }
            ShowModel model = new ShowModel();
            model.setID(Convert.ToInt32(showIDText.Text));
            model.setTitle(showTitleText.Text);
            model.setDistribution(showDistributionText.Text);
            model.setNumberOfTickets(Convert.ToInt32(showNrTicketsText.Text));
            if (showGenreSelection.SelectedIndex == 0) model.setGenre("Opera");
            else model.setGenre("Ballet");
            model.setDate(showDatePicker.Value.Date);
            showServices.update(model);
            StatusLabel.Text = "Show edited!";

            //refresh
            ShowRefresh();
            showGenreSelection.SelectedIndex = -1;
        }

        private void showDelete_Click(object sender, EventArgs e)
        {
            if (showIDText.Text == "")
            {
                StatusLabel.Text = "Error! No ID chosen!";
                return;
            }
            if (!showServices.isID(Convert.ToInt32(showIDText.Text)))
            {
                StatusLabel.Text = "Error! The show with the given ID does not exist!";
            }
            showServices.delete(Convert.ToInt32(showIDText.Text));

            //refresh
            ShowRefresh();
            StatusLabel.Text = "Show deleted!";

        }

        private void dgvShowsTable_SelectionChanged(object sender, EventArgs e)
        {
            if (firstRunShows != 0)
            {
                int row = dgvShowsTable.CurrentCell.RowIndex;
                
                showIDText.Text = dgvShowsTable.Rows[row].Cells[0].Value.ToString();
                showTitleText.Text = dgvShowsTable.Rows[row].Cells[1].Value.ToString();
                showDistributionText.Text = dgvShowsTable.Rows[row].Cells[3].Value.ToString();
                showNrTicketsText.Text = dgvShowsTable.Rows[row].Cells[5].Value.ToString();
                DateTime dt;
                DateTime.TryParse(dgvShowsTable.Rows[row].Cells[4].Value.ToString(), out dt);
                showDatePicker.Value = dt;

                if (dgvShowsTable.Rows[row].Cells[2].Value.ToString() == "Opera") showGenreSelection.SelectedIndex = 0;
                else showGenreSelection.SelectedIndex = 1;
            }
            else firstRunShows++;
        }

        private void ShowRefresh()
        {
            dgvShowsTable.Rows.Clear();
            showServices.getShows().ForEach(show => dgvShowsTable.Rows.Add(show.ToStringArray()));

            showIDText.Text = "";
            showTitleText.Text = "";
            showDistributionText.Text = "";
            showNrTicketsText.Text = "";
            showDatePicker.Value = DateTime.Now;
            showGenreSelection.SelectedIndex = -1;
        }

        private void exportXMLSelected_Click(object sender, EventArgs e)
        {
            if(showIDText.Text == "")
            {
                StatusLabel.Text = "No show selected";
                return;
            }
            IExportFactory factory = new ExportFactory();
            IExportFile exporter = factory.getFileExporter("XML");
            using (var folderDialog = new FolderBrowserDialog())
            {
                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    StatusLabel.Text = exporter.export(new TicketServices().getTicketsByShowID(Convert.ToInt32(showIDText.Text)), folderDialog.SelectedPath + "\\");
                }
            }
        }

        private void exportCSVSelected_Click(object sender, EventArgs e)
        {
            if (showIDText.Text == "")
            {
                StatusLabel.Text = "No show selected";
                return;
            }
            IExportFactory factory = new ExportFactory();
            IExportFile exporter = factory.getFileExporter("CSV");
            using (var folderDialog = new FolderBrowserDialog())
            {
                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    StatusLabel.Text = exporter.export(new TicketServices().getTicketsByShowID(Convert.ToInt32(showIDText.Text)), folderDialog.SelectedPath + "\\");
                }
            }

        }

        private void exportXMLAll_Click(object sender, EventArgs e)
        {
            IExportFactory factory = new ExportFactory();
            IExportFile exporter = factory.getFileExporter("XML");
            using (var folderDialog = new FolderBrowserDialog())
            {
                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    StatusLabel.Text = exporter.export(new TicketServices().getTickets(), folderDialog.SelectedPath + "\\");
                }
            }

        }

        private void exportCSVAll_Click(object sender, EventArgs e)
        {
            IExportFactory factory = new ExportFactory();
            IExportFile exporter = factory.getFileExporter("CSV");
            using (var folderDialog = new FolderBrowserDialog())
            {
                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    StatusLabel.Text = exporter.export(new TicketServices().getTickets(), folderDialog.SelectedPath + "\\");
                }
            }

        }

        private void logout_Click(object sender, EventArgs e)
        {
            this.Hide();
            var login = new Login();
            login.Closed += (s, args) => this.Close();
            login.Show();
        }
    }
}
