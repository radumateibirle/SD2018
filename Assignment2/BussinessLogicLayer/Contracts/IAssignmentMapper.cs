﻿using Assignment2.BussinessLogicLayer.Models;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2.BussinessLogicLayer.Contracts
{
    interface IAssignmentMapper
    {
        AssignmentModel Map(Assignment assign);
        Assignment Map(AssignmentModel assign);
    }
}
