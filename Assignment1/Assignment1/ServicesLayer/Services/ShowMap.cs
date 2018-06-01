using Assignment1.DataLayer.Models;
using Assignment1.ServicesLayer.Contracts;
using Assignment1.ServicesLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assignment1.ServicesLayer.Services
{
    class ShowMap : IShowMap
    {
        public ShowDTO map(ShowModel showmodel)
        {
            ShowDTO dto = new ShowDTO();

            dto.setID(showmodel.getID());
            dto.setGenre(showmodel.getGenre());
            dto.setDistribution(showmodel.getDistribution());
            dto.setDate(showmodel.getDate());
            dto.setNumberOfTickets(showmodel.getNumberOfTickets());
            dto.setTitle(showmodel.getTitle());

            return dto;
        }
        
        public ShowModel map(ShowDTO showdto)
        {
            ShowModel model = new ShowModel();

            model.setID(showdto.getID());
            model.setGenre(showdto.getGenre());
            model.setDistribution(showdto.getDistribution());
            model.setDate(showdto.getDate());
            model.setNumberOfTickets(showdto.getNumberOfTickets());
            model.setTitle(showdto.getTitle());

            return model;
        }
    }
}
