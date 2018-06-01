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
    public class AssignmentServices : IAssignmentServices
    {
        IAssignmentRepo aRepo;
        IAssignmentMapper aMapper = new AssignmentMapper();

        public AssignmentServices (IAssignmentRepo aR)
        {
            aRepo = aR;
        }

        public void Add(AssignmentModel assignmentModel)
        {
            aRepo.Add(aMapper.Map(assignmentModel));
        }

        public void Delete(AssignmentModel assignmentModel)
        {
            aRepo.Delete(aMapper.Map(assignmentModel));
        }

        public List<AssignmentModel> GetAll()
        {
            List<Assignment> assignments = aRepo.GetAll();
            List<AssignmentModel> assignmentModels = new List<AssignmentModel>();

            assignments.ForEach(a => assignmentModels.Add(aMapper.Map(a)));
            return assignmentModels;
        }

        public AssignmentModel GetByID(int ID)
        {
            return aMapper.Map(aRepo.GetByID(ID));
        }

        public List<AssignmentModel> GetByLabID(int labID)
        {
            List<Assignment> assignments = aRepo.GetByLabID(labID);
            List<AssignmentModel> assignmentModel = new List<AssignmentModel>();

            assignments.ForEach(a => assignmentModel.Add(aMapper.Map(a)));
            return assignmentModel;
        }

        public void Update(AssignmentModel assignmentModel)
        {
            aRepo.Update(aMapper.Map(assignmentModel));
        }
    }
}
