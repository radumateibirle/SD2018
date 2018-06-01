using Assignment1.DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assignment1.DataLayer.Contracts
{
    interface ITicketRepo
    {
        List<TicketDTO> getTickets();
        List<TicketDTO> getTicketsByShowID(int ID);
        bool createTicket(TicketDTO ticket);
        bool updateTicket(TicketDTO ticket);
        bool deleteTicketByID(int ID);
    }
}
