using Assignment1.DataLayer.Models;
using Assignment1.ServicesLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assignment1.ServicesLayer.Contracts
{
    interface ITicketMap
    {
        TicketDTO map(TicketModel ticketmodel);
        TicketModel map(TicketDTO ticketdto);
    }
}
