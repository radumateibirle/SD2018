using Assignment2.BussinessLogicLayer.Models;
using BussinessLogicLayer.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2Tests3.MockServices
{
    public class LaboratoryServicesMock : ILaboratoryServices
    {
        public void Add(LaboratoryModel laboratoryModel)
        {
            throw new NotImplementedException();
        }

        public void Delete(LaboratoryModel laboratoryModel)
        {
            throw new NotImplementedException();
        }

        public List<LaboratoryModel> GetAll()
        {
            List<LaboratoryModel> labs = new List<LaboratoryModel>();
            labs.Add(new LaboratoryModel() { ID = 1 });
            labs.Add(new LaboratoryModel() { ID = 2 });
            return labs;
        }

        public LaboratoryModel GetByID(int ID)
        {
            throw new NotImplementedException();
        }

        public List<LaboratoryModel> GetFilteredList(string keyword)
        {
            List<LaboratoryModel> labs = new List<LaboratoryModel>();
            labs.Add(new LaboratoryModel() { Curricula = keyword });
            return labs;
        }

        public int GetIdFromNumber(int labNr)
        {
            throw new NotImplementedException();
        }

        public void Update(LaboratoryModel laboratoryModel)
        {
            throw new NotImplementedException();
        }
    }
}
