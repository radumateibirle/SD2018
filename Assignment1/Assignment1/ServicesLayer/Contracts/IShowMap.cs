using Assignment1.DataLayer.Models;
using Assignment1.ServicesLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assignment1.ServicesLayer.Contracts
{
    interface IShowMap
    {
        ShowDTO map(ShowModel showmodel);
        ShowModel map(ShowDTO showdto);
    }
}
