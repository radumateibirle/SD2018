using Assignment1.ServicesLayer.Contracts;
using Assignment1.ServicesLayer.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;

namespace Assignment1.ServicesLayer.Services
{
    class ExportXML : IExportFile
    {
        public string export(List<TicketModel> tickets, string path)
        {
            string filename = "tickets-" + DateTime.Now.ToString("d-MMM-yyyy") + ".xml";
            path += filename;

            XmlWriter writer = XmlWriter.Create(path);
            writer.WriteStartDocument();
            writer.WriteStartElement("Tickets");

            foreach (TicketModel ticket in tickets)
            {
                writer.WriteStartElement("Ticket" + ticket.getID());
                var ss = new ShowServices();
                writer.WriteElementString("Show_title", ss.getShowByShowID(ticket.getShowID()).getTitle());
                writer.WriteElementString("Show_date", ss.getShowByShowID(ticket.getShowID()).getDate().ToString());
                writer.WriteElementString("Row", ticket.getRow().ToString());
                writer.WriteElementString("Seat", ticket.getColumn().ToString());
                writer.WriteEndElement();
            }
            writer.WriteEndElement();
            writer.WriteEndDocument();

            writer.Flush();
            writer.Close();
            
            return "XML written to " + path;
        }
    }
}
