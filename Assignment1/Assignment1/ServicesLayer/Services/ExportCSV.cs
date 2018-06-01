using Assignment1.ServicesLayer.Contracts;
using Assignment1.ServicesLayer.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Assignment1.ServicesLayer.Services
{
    class ExportCSV : IExportFile
    {
        public int Property
        {
            get => default(int);
            set
            {
            }
        }

        public string export(List<TicketModel> tickets, string path)
        {
            string filename = "tickets-" + DateTime.Now.ToString("d-MMM-yyyy") + ".csv";
            path += filename;

            StringBuilder sb = new StringBuilder();

            sb.AppendLine("Tickets ");
            sb.AppendLine("Ticket ID, Show title, Show date, Row, Seat");

            foreach (TicketModel ticket in tickets)
            {
                var ss = new ShowServices();
                string id = ticket.getID().ToString();
                string showTitle = ss.getShowByShowID(ticket.getShowID()).getTitle();
                string showDate = ss.getShowByShowID(ticket.getShowID()).getDate().ToString();
                string row = ticket.getRow().ToString();
                string seat = ticket.getColumn().ToString();
                sb.AppendLine(id + ", " + showTitle + ", " + showDate + ", " + row + ", " + seat);
            }

            File.WriteAllText(path, sb.ToString());

            return "CSV exported to " + path;
        }
    }
}
