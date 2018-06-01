using Assignment1.DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assignment1.DataLayer.Contracts
{
    interface IShowRepo
    {
        List<ShowDTO> getShows();
        List<ShowDTO> getShowsByTitle(string Title);
        bool createShow(ShowDTO show);
        bool updateShow(ShowDTO show);
        bool deleteShowByID(int ID);
    }
}
