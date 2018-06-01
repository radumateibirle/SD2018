using Assignment2.BussinessLogicLayer.Models;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2.BussinessLogicLayer.Contracts
{
    interface ILaboratoryMapper
    {
        LaboratoryModel Map(Laboratory lab);
        Laboratory Map(LaboratoryModel lab);
    }
}
