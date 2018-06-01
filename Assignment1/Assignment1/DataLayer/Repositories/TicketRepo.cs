using Assignment1.DataLayer.Contracts;
using Assignment1.DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Assignment1.DataLayer.Repositories
{
    class TicketRepo : ITicketRepo
    {
        private List<TicketDTO> ticketsList;
        private SqlCommand connectToDB()
        {
            SqlCommand command = new SqlCommand();
            command = connectToDB(command);
            return command;
        }
        private SqlCommand connectToDB(SqlCommand command)
        {
            command.Connection = new SqlConnection("Data Source=DESKTOP-1QG2BML\\SQLEXPRESS;Initial Catalog=Assignment1;Integrated Security=True");
            command.Connection.Open();
            return command;
        }
        private void getAllTickets()
        {
            ticketsList = new List<TicketDTO>();
            SqlCommand cmd = connectToDB();
            cmd.CommandText = "select * from Tickets";
            SqlDataReader dataReader = cmd.ExecuteReader();
            while (dataReader.Read())
            {
                TicketDTO ticket = new TicketDTO();
                ticket.setID((Int32)dataReader["ID"]);
                ticket.setShowID((Int32)dataReader["ShowID"]);
                ticket.setRow((Int32)dataReader["Row"]);
                ticket.setColumn((Int32)dataReader["Col"]);
                ticketsList.Add(ticket);
            }
            cmd.Connection.Close();
        }
        private SqlCommand buildCmd(TicketDTO ticket)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("ID", ticket.getID());
            cmd.Parameters.AddWithValue("ShowID", ticket.getShowID());
            cmd.Parameters.AddWithValue("Row", ticket.getRow());
            cmd.Parameters.AddWithValue("Col", ticket.getColumn());
            return cmd;
        }
        public TicketRepo()
        {
            ticketsList = new List<TicketDTO>();
            this.getAllTickets();
        }

        public bool createTicket(TicketDTO ticket)
        {
            SqlCommand cmd = buildCmd(ticket);
            cmd = connectToDB(cmd);
            cmd.CommandText = "insert into Tickets (ShowID, Row, Col) values (@ShowID, @Row, @Col)";
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
            ticketsList.Add(ticket);
            return true;
        }

        public bool deleteTicketByID(int ID)
        {
            SqlCommand cmd = connectToDB();
            cmd.Parameters.AddWithValue("ID", ID);
            cmd.CommandText = "delete from Tickets where ID=@ID";
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
            TicketDTO oldTicket = ticketsList.Find(ticket => ticket.getID() == ID);
            ticketsList.Remove(oldTicket);
            return true;
        }

        public List<TicketDTO> getTickets()
        {
            getAllTickets();
            return ticketsList;
        }

        public bool updateTicket(TicketDTO ticket)
        {
            SqlCommand cmd = buildCmd(ticket);
            cmd = connectToDB(cmd);
            cmd.CommandText = "update Tickets set ShowID = @ShowID, Row = @Row, Col = @Col where ID=@ID";
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
            TicketDTO oldTicket = ticketsList.Find(tkt => tkt.getID() == ticket.getID());
            ticketsList.Remove(oldTicket);
            ticketsList.Add(ticket);
            return true;
        }

        public List<TicketDTO> getTicketsByShowID(int ID)
        {
            List<TicketDTO> ticketByShow = new List<TicketDTO>();
            SqlCommand cmd = connectToDB();
            cmd.Parameters.AddWithValue("ShowID", ID);
            cmd.CommandText = "select * from Tickets where ShowID = @ShowID";
            SqlDataReader dataReader = cmd.ExecuteReader();
            while (dataReader.Read())
            {
                TicketDTO ticket = new TicketDTO();
                ticket.setID((Int32)dataReader["ID"]);
                ticket.setShowID((Int32)dataReader["ShowID"]);
                ticket.setRow((Int32)dataReader["Row"]);
                ticket.setColumn((Int32)dataReader["Col"]);
                ticketByShow.Add(ticket);
            }
            cmd.Connection.Close();

            return ticketByShow;
        }
    }
}
