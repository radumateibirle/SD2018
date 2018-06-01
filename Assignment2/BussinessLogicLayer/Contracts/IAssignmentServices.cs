using Assignment2.BussinessLogicLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLogicLayer.Contracts
{
    public interface IAssignmentServices
    {
        void Add(AssignmentModel assignmentModel);
        void Delete(AssignmentModel assignmentModel);
        List<AssignmentModel> GetAll();
        List<AssignmentModel> GetByLabID(int labID);
        AssignmentModel GetByID(int ID);
        void Update(AssignmentModel assignmentModel);
    }
}
