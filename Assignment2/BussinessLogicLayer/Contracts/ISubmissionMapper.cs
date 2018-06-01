using Assignment2.BussinessLogicLayer.Models;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2.BussinessLogicLayer.Contracts
{
    interface ISubmissionMapper
    {
        SubmissionModel Map(Submission sub);
        Submission Map(SubmissionModel sub);
    }
}
