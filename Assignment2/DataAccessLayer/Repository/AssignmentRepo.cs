using DataAccessLayer.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository
{
    public class AssignmentRepo:IAssignmentRepo
    {
        Assignment2Entities DB = new Assignment2Entities();
        public void Add(Assignment assignment)
        {
            if (assignment == null) return;
            DB.Assignments.Add(assignment);
            DB.SaveChanges();
        }

        public void Delete(Assignment assignment)
        {
            if (assignment == null) return;
            var assign = DB.Assignments.FirstOrDefault(a => a.ID == assignment.ID);
            if (assign == null) return;
            DB.Assignments.Remove(assign);
            DB.SaveChanges();
        }

        public List<Assignment> GetAll()
        {
            return DB.Assignments.ToList();
        }

        public Assignment GetByID(int ID)
        {
            return DB.Assignments.FirstOrDefault(l => l.ID == ID);
        }

        public List<Assignment> GetByLabID(int labID)
        {
            return DB.Assignments.Where(a => a.LaboratoryID == labID).ToList();
        }

        public void Update(Assignment assignment)
        {
            if (assignment == null) return;
            var assign = DB.Assignments.FirstOrDefault(a => a.ID == assignment.ID);
            if (assign == null) return;
            DB.Entry(assign).CurrentValues.SetValues(assignment);
            DB.SaveChanges();
        }
    }
}
