using Assignment1.DataLayer.Models;
using Assignment1.ServicesLayer.Contracts;
using Assignment1.ServicesLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assignment1.ServicesLayer.Services
{
    class TicketMap : ITicketMap
    {
        public TicketDTO map(TicketModel ticketmodel)
        {
            TicketDTO dto = new TicketDTO();

            dto.setID(ticketmodel.getID());
            dto.setShowID(ticketmodel.getShowID());
            dto.setRow(ticketmodel.getRow());
            dto.setColumn(ticketmodel.getColumn());

            return dto;
            
        }

        public TicketModel map(TicketDTO ticketdto)
        {
            TicketModel model = new TicketModel();

            model.setID(ticketdto.getID());
            model.setShowID(ticketdto.getShowID());
            model.setRow(ticketdto.getRow());
            model.setColumn(ticketdto.getColumn());

            return model;
        }
    }
}
