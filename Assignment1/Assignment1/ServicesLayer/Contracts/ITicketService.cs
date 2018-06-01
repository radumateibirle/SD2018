using Assignment1.ServicesLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assignment1.ServicesLayer.Contracts
{
    interface ITicketService
    {
        List<TicketModel> getTickets();
        List<TicketModel> getTicketsByShowID(int ShowID);
        TicketModel getTicketByID(int ID);
        bool isTicket(TicketModel ticket);
        bool isID(int ID);
        bool add(TicketModel ticket);
        bool update(TicketModel ticket);
        bool delete(int ID);
    }
}
