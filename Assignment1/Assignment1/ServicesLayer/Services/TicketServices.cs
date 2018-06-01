using Assignment1.DataLayer.Contracts;
using Assignment1.DataLayer.Repositories;
using Assignment1.ServicesLayer.Contracts;
using Assignment1.ServicesLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assignment1.ServicesLayer.Services
{
    class TicketServices : ITicketService
    {
        private readonly ITicketRepo repository;
        private readonly ITicketMap mapper;

        public TicketServices()
        {
            repository = new TicketRepo();
            mapper = new TicketMap();
        }

        public bool add(TicketModel ticket)
        {
            return repository.createTicket(mapper.map(ticket));
        }

        public bool delete(int ID)
        {
            return repository.deleteTicketByID(ID);
        }

        public TicketModel getTicketByID(int ID)
        {
            List<TicketModel> tickets = getTickets();
            foreach(TicketModel ticket in tickets)
            {
                if (ticket.getID() == ID) return ticket;
            }
            return null;
        }

        public List<TicketModel> getTickets()
        {
            List<TicketModel> tickets = new List<TicketModel>();
            repository.getTickets().ForEach(ticket => tickets.Add(mapper.map(ticket)));
            return tickets;
        }

        public List<TicketModel> getTicketsByShowID(int ShowID)
        {
            List<TicketModel> tickets = new List<TicketModel>();
            repository.getTicketsByShowID(ShowID).ForEach(ticket => tickets.Add(mapper.map(ticket)));
            return tickets;
        }

        public bool isID(int ID)
        {
            if (this.getTickets().FindIndex(tckt => tckt.getID() == ID) != -1) return true;
            return false;
        }

        public bool isTicket(TicketModel ticket)
        {
            if (this.getTickets().FindIndex(tckt => tckt.Equals(ticket)) != -1) return true;
            return false;
        }

        public bool update(TicketModel ticket)
        {
            return repository.updateTicket(mapper.map(ticket));
        }
    }
}
