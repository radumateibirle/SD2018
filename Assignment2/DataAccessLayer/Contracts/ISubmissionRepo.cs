using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Contracts
{
    public interface ISubmissionRepo
    {
        void Add(Submission submission);
        void Delete(Submission submission);
        List<Submission> GetAll();
        Submission GetByID(int ID);
        List<Submission> GetAllByAssignmentID(int ID);
        List<Submission> GetAllByStudentID(int ID);
        void Update(Submission submission);
        void Grade(int id, decimal Grade);
    }
}
