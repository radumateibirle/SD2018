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
    class ShowServices : IShowService
    {
        private readonly IShowRepo repository;
        private readonly IShowMap mapper;

        public ShowServices()
        {
            repository = new ShowRepo();
            mapper = new ShowMap();
        }

        public bool add(ShowModel model)
        {
            return repository.createShow(mapper.map(model));
        }

        public bool delete(int ID)
        {
            return repository.deleteShowByID(ID);
        }

        public ShowModel getShowByShowID(int ID)
        {
            List<ShowModel> shows = getShows();
            foreach(ShowModel show in shows)
            {
                if (show.getID() == ID) return show;
            }
            return null;
        }

        public int getShowID(string title, DateTime dt)
        {
            List<ShowModel> byTitle = getShowsByTitle(title);
            foreach (ShowModel show in byTitle)
            {
                if (show.getDate().Equals(dt)) return show.getID();
            }
            return -1;
        }

        public List<ShowModel> getShows()
        {
            List<ShowModel> shows = new List<ShowModel>();
            repository.getShows().ForEach(show => shows.Add(mapper.map(show)));
            return shows;
        }

        public List<ShowModel> getShowsByTitle(string Title)
        {
            List<ShowModel> shows = new List<ShowModel>();
            repository.getShowsByTitle(Title).ForEach(show => shows.Add(mapper.map(show)));
            return shows;
        }

        public bool isID(int ID)
        {
            if (this.getShows().FindIndex(shw => shw.getID() == ID) != -1) return true;
            return false;
        }

        public bool isShow(string title, DateTime dt)
        {
            if (this.getShows().FindIndex(shw => shw.getTitle() == title && shw.getDate().Equals(dt)) != -1) return true;
            return false;
        }

        public bool update(ShowModel model)
        {
            return repository.updateShow(mapper.map(model));
        }
    }
}
