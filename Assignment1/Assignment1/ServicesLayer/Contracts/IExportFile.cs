using Assignment1.ServicesLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assignment1.ServicesLayer.Contracts
{
    interface IExportFile
    {
        string export(List<TicketModel> tickets, string path);
    }
}
