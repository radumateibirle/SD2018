using Assignment2.BussinessLogicLayer.Models;
using Assignment2.Models;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2.Controllers.Contracts
{
    interface ISubmissionMapperAPI
    {
        SubmissionModelAPI Map(SubmissionModel sub);
        SubmissionModel Map(SubmissionModelAPI sub);
    }
}
