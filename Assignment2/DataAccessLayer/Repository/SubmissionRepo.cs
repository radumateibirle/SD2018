using DataAccessLayer.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository
{
    public class SubmissionRepo:ISubmissionRepo
    {
        Assignment2Entities DB = new Assignment2Entities();
        public void Add(Submission submission)
        {
            if (submission == null) return;
            DB.Submissions.Add(submission);
            DB.SaveChanges();
        }

        public void Delete(Submission submission)
        {
            if (submission == null) return;
            Submission sub = DB.Submissions.FirstOrDefault(u => u.ID == submission.ID);
            if (sub == null) return;
            DB.Submissions.Remove(sub);
            DB.SaveChanges();
        }

        public List<Submission> GetAll()
        {
            return DB.Submissions.ToList();
        }

        public List<Submission> GetAllByAssignmentID(int ID)
        {
            return DB.Submissions.Where(s => s.AssignmentID == ID).ToList();
        }

        public List<Submission> GetAllByStudentID(int ID)
        {
            return DB.Submissions.Where(s => s.StudentID == ID).ToList();
        }

        public Submission GetByID(int ID)
        {
            return DB.Submissions.FirstOrDefault(s => s.ID == ID);
        }

        public void Grade(int id, decimal Grade)
        {
            if (Grade <= 0) return;
            Submission sub = DB.Submissions.FirstOrDefault(u => u.ID == id);
            if (sub == null) return;
            sub.Grade = Grade;
            DB.Entry(sub).CurrentValues.SetValues(sub);
            DB.SaveChanges();
        }

        public void Update(Submission submission)
        {
            if (submission == null) return;
            var sub = DB.Submissions.FirstOrDefault(u => u.ID == submission.ID);
            if (sub == null) return;
            DB.Entry(sub).CurrentValues.SetValues(submission);
            DB.SaveChanges();
        }
    }
}
