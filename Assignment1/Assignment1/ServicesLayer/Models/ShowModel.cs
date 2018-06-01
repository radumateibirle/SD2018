using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assignment1.ServicesLayer.Models
{
    public class ShowModel
    {
        private int ID;
        private string Title;
        private string Genre;
        private string Distribution;
        private DateTime Date;
        private int NumberOfTickets;


        public int getID() { return ID; }
        public void setID(int ID) { this.ID = ID; }

        public string getTitle() { return Title; }
        public void setTitle(string Title) { this.Title = Title; }

        public string getGenre() { return Genre; }
        public void setGenre(string Genre) { this.Genre = Genre; }

        public string getDistribution() { return Distribution; }
        public void setDistribution(string Distribution) { this.Distribution = Distribution; }

        public DateTime getDate() { return Date; }
        public void setDate(DateTime Date) { this.Date = Date; }

        public int getNumberOfTickets() { return NumberOfTickets; }
        public void setNumberOfTickets(int NumberOfTickets) { this.NumberOfTickets = NumberOfTickets; }

        public string[] ToStringArray()
        {
            return new string[] { ID.ToString(), Title, Genre, Distribution, Date.ToString(), NumberOfTickets.ToString() };
        }
    }
}
