using Assignment2.BussinessLogicLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLogicLayer.Contracts
{
    public interface ISubmissionServices
    {
        void Add(SubmissionModel submissionModel);
        void Delete(SubmissionModel submissionModel);
        List<SubmissionModel> GetAll();
        SubmissionModel GetByID(int ID);
        List<SubmissionModel> GetGradesByAssignmentID(int assignmentID);
        List<SubmissionModel> GetAllByStudentID(int ID);
        void Update(SubmissionModel submissionModel);
        void Grade(int id, decimal Grade);
    }
}
