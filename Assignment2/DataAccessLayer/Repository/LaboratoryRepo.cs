using DataAccessLayer.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository
{
    public class LaboratoryRepo:ILaboratoryRepo
    {
        Assignment2Entities DB = new Assignment2Entities();
        public void Add(Laboratory laboratory)
        {
            if (laboratory == null) return;
            DB.Laboratories.Add(laboratory);
            DB.SaveChanges();
        }

        public void Delete(Laboratory laboratory)
        {
            if (laboratory == null) return;
            var lab = DB.Laboratories.FirstOrDefault(u => u.ID == laboratory.ID);
            if (lab == null) return;
            DB.Laboratories.Remove(lab);
            DB.SaveChanges();
        }

        public List<Laboratory> GetAll()
        {
            return DB.Laboratories.ToList();
        }

        public Laboratory GetByID(int ID)
        {
            return DB.Laboratories.FirstOrDefault(l => l.ID == ID);
        }

        public int GetIdFromNumber(int labNr)
        {
            return DB.Laboratories.FirstOrDefault(l => l.Number == labNr).ID;
        }

        public void Update(Laboratory laboratory)
        {
            if (laboratory == null) return;
            var lab = DB.Laboratories.FirstOrDefault(u => u.ID == laboratory.ID);
            if (lab == null) return;
            DB.Entry(lab).CurrentValues.SetValues(laboratory);
            DB.SaveChanges();
        }
    }
}
