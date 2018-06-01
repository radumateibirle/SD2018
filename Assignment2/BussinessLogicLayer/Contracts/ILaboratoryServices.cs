using Assignment2.BussinessLogicLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLogicLayer.Contracts
{
    public interface ILaboratoryServices
    {
        void Add(LaboratoryModel laboratoryModel);
        void Delete(LaboratoryModel laboratoryModel);
        List<LaboratoryModel> GetAll();
        List<LaboratoryModel> GetFilteredList(string keyword);
        LaboratoryModel GetByID(int ID);
        int GetIdFromNumber(int labNr);
        void Update(LaboratoryModel laboratoryModel);
    }
}
