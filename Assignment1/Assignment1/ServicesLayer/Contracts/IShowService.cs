using Assignment1.ServicesLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assignment1.ServicesLayer.Contracts
{
    interface IShowService
    {
        List<ShowModel> getShows();
        List<ShowModel> getShowsByTitle(string Title);
        ShowModel getShowByShowID(int ID);
        int getShowID(string title, DateTime dt);
        bool isShow(string title, DateTime dt);
        bool isID(int ID);
        bool add(ShowModel model);
        bool update(ShowModel model);
        bool delete(int ID);
    }
}
