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
    public partial class Cashier : Form
    {
        private ITicketService ticketServices;
        private IShowService showServices;
        private int firstRunShows = 0;
        private int firstRunTickets = 0;
        public Cashier()
        {
            InitializeComponent();

            ticketServices = new TicketServices();
            showServices = new ShowServices();

            dgvShows.ColumnCount = 6;
            dgvShows.Columns[0].Name = "ID";
            dgvShows.Columns[1].Name = "Title";
            dgvShows.Columns[2].Name = "Genre";
            dgvShows.Columns[3].Name = "Distribution";
            dgvShows.Columns[4].Name = "Date";
            dgvShows.Columns[5].Name = "Tickets";

            showServices.getShows().ForEach(show => dgvShows.Rows.Add(show.ToStringArray()));

            dgvTickets.ColumnCount = 4;
            dgvTickets.Columns[0].Name = "ID";
            dgvTickets.Columns[1].Name = "ShowID";
            dgvTickets.Columns[2].Name = "Row";
            dgvTickets.Columns[3].Name = "Seat";

            ticketServices.getTickets().ForEach(ticket => dgvTickets.Rows.Add(ticket.ToStringArray()));
        }

        private void ticketSell_Click(object sender, EventArgs e)
        {
            if (!showRowText.Text.All(Char.IsDigit))
            {
                StatusLabel.Text = "Invalid row selected!";
                return;
            }
            if (!showSeatText.Text.All(Char.IsDigit))
            {
                StatusLabel.Text = "Invalid seat selected!";
                return;
            }
            if (showTitleText.Text == "" || showDateText.Text == "")
            {
                StatusLabel.Text = "No show selected!";
                return;
            }
            if (showRowText.Text == "")
            {
                StatusLabel.Text = "No row seleted!";
                return;
            }
            if (showSeatText.Text == "")
            {
                StatusLabel.Text = "No seat seleted!";
                return;
            }
            DateTime dt;
            DateTime.TryParse(showDateText.Text, out dt);
            int showID = showServices.getShowID(showTitleText.Text, dt);
            if (showID == -1)
            {
                StatusLabel.Text = "Show not found!";
                return;
            }

            ShowModel show = showServices.getShowByShowID(showID);
            if (show == null)
            {
                StatusLabel.Text = "Show not found!";
                return;
            }
            if (ticketServices.getTicketsByShowID(showID).Count() >= show.getNumberOfTickets())
            {
                StatusLabel.Text = "Show is sold out!";
                return;
            }

            TicketModel ticket = new TicketModel();
            ticket.setShowID(showID);
            ticket.setRow(Convert.ToInt32(showRowText.Text));
            ticket.setColumn(Convert.ToInt32(showSeatText.Text));

            if (ticketServices.isTicket(ticket))
            {
                StatusLabel.Text = "Ticket already exists!";
                return;
            }
            ticketServices.add(ticket);

            //refresh tables
            StatusLabel.Text = "Ticket sold!";
            refresh();
        }

        private void ticketDelete_Click(object sender, EventArgs e)
        {
            if (ticketID.Text == "")
            {
                StatusLabel.Text = "No ticket selected!";
                return;
            }
            ticketServices.delete(Convert.ToInt32(ticketID.Text));

            //refresh tables
            StatusLabel.Text = "Reservation canceled!";
            refresh();
        }

        private void ticketUpdate_Click(object sender, EventArgs e)
        {
            if (!showRowText.Text.All(Char.IsDigit))
            {
                StatusLabel.Text = "Invalid row selected!";
                return;
            }
            if (!showSeatText.Text.All(Char.IsDigit))
            {
                StatusLabel.Text = "Invalid seat selected!";
                return;
            }
            if (showTitleText.Text == "" || showDateText.Text == "")
            {
                StatusLabel.Text = "No show selected!";
                return;
            }
            if (showRowText.Text == "")
            {
                StatusLabel.Text = "No row seleted!";
                return;
            }
            if (showSeatText.Text == "")
            {
                StatusLabel.Text = "No seat seleted!";
                return;
            }
            DateTime dt;
            DateTime.TryParse(showDateText.Text, out dt);
            int ID = showServices.getShowID(showTitleText.Text, dt);
            if (ID == -1)
            {
                StatusLabel.Text = "Show not found";
                return;
            }
            if (ticketID.Text == "")
            {
                StatusLabel.Text = "No ticket selected!";
                return;
            }
            TicketModel oldTicket = ticketServices.getTicketByID(Convert.ToInt32(ticketID.Text));
            if (oldTicket == null)
            {
                StatusLabel.Text = "Ticket not found!";
                return;
            }
            TicketModel ticket = new TicketModel();
            ticket.setID(oldTicket.getID());
            ticket.setShowID(oldTicket.getShowID());
            ticket.setRow(oldTicket.getRow());
            ticket.setColumn(Convert.ToInt32(showSeatText.Text));
            if (ticketServices.isTicket(ticket))
            {
                StatusLabel.Text = "Ticket already exists!";
                return;
            }
            ticketServices.update(ticket);

            //refresh tables
            StatusLabel.Text = "Ticket seat updated!";
            refresh();
        }

        private void refresh()
        {
            showTitleText.Text = "";
            showDateText.Text = "";
            ticketID.Text = "";
            showRowText.Text = "";
            showSeatText.Text = "";

            dgvShows.Rows.Clear();
            dgvTickets.Rows.Clear();
            showServices.getShows().ForEach(show => dgvShows.Rows.Add(show.ToStringArray()));
            ticketServices.getTickets().ForEach(ticket => dgvTickets.Rows.Add(ticket.ToStringArray()));
        }

        private void dgvShows_SelectionChanged(object sender, EventArgs e)
        {
            if (firstRunShows != 0)
            {
                int row = dgvShows.CurrentCell.RowIndex;
                
                showTitleText.Text = dgvShows.Rows[row].Cells[1].Value.ToString();
                showDateText.Text = dgvShows.Rows[row].Cells[4].Value.ToString();
            }
            else firstRunShows++;
        }

        private void dgvTickets_SelectionChanged(object sender, EventArgs e)
        {
            if (firstRunTickets != 0)
            {
                int row = dgvTickets.CurrentCell.RowIndex;

                ticketID.Text = dgvTickets.Rows[row].Cells[0].Value.ToString();
                showRowText.Text = dgvTickets.Rows[row].Cells[2].Value.ToString();
                showSeatText.Text = dgvTickets.Rows[row].Cells[3].Value.ToString();
                int showID = Convert.ToInt32(dgvTickets.Rows[row].Cells[1].Value.ToString());
                ShowModel show = showServices.getShowByShowID(showID);
                showTitleText.Text = show.getTitle();
                showDateText.Text = show.getDate().ToString();
            }
            else firstRunTickets++;
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
