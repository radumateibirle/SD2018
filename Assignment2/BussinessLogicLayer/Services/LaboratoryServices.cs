using Assignment2.BussinessLogicLayer.Contracts;
using Assignment2.BussinessLogicLayer.Mapper;
using Assignment2.BussinessLogicLayer.Models;
using BussinessLogicLayer.Contracts;
using DataAccessLayer;
using DataAccessLayer.Contracts;
using DataAccessLayer.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLogicLayer.Services
{
    public class LaboratoryServices : ILaboratoryServices
    {
        ILaboratoryRepo lRepo;
        ILaboratoryMapper lMapper = new LaboratoryMapper();

        public LaboratoryServices(ILaboratoryRepo lR)
        {
            lRepo = lR;
        }

        public void Add(LaboratoryModel laboratoryModel)
        {
            lRepo.Add(lMapper.Map(laboratoryModel));
        }

        public void Delete(LaboratoryModel laboratoryModel)
        {
            lRepo.Delete(lMapper.Map(laboratoryModel));
        }

        public List<LaboratoryModel> GetAll()
        {
            List<Laboratory> laboratories = lRepo.GetAll();
            List<LaboratoryModel> laboratoryModels = new List<LaboratoryModel>();

            laboratories.ForEach(l => laboratoryModels.Add(lMapper.Map(l)));
            return laboratoryModels;
        }

        public LaboratoryModel GetByID(int ID)
        {
            return lMapper.Map(lRepo.GetByID(ID));
        }

        public List<LaboratoryModel> GetFilteredList(string keyword)
        {
            List<Laboratory> laboratories = lRepo.GetAll();
            List<LaboratoryModel> laboratoryModels = new List<LaboratoryModel>();

            laboratories.ForEach(l =>
            {
                if (l.Curricula.Contains(keyword) || l.Description.Contains(keyword))
                {
                    laboratoryModels.Add(lMapper.Map(l));
                }
            }
            );

            return laboratoryModels;
        }

        public int GetIdFromNumber(int labNr)
        {
            return lRepo.GetIdFromNumber(labNr);
        }

        public void Update(LaboratoryModel laboratoryModel)
        {
            lRepo.Update(lMapper.Map(laboratoryModel));
        }
    }
}
