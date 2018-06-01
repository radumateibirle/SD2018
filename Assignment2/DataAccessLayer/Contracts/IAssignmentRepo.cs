using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Contracts
{
    public interface IAssignmentRepo
    {
        void Add(Assignment assignment);
        void Delete(Assignment assignment);
        List<Assignment> GetAll();
        List<Assignment> GetByLabID(int labID);
        Assignment GetByID(int ID);
        void Update(Assignment assignment);
    }
}
