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
    public class SubmissionServices : ISubmissionServices
    {
        ISubmissionRepo sRepo;
        ISubmissionMapper sMapper = new SubmissionMapper();

        public SubmissionServices(ISubmissionRepo sR)
        {
            sRepo = sR;
        }

        public void Add(SubmissionModel submissionModel)
        {
            sRepo.Add(sMapper.Map(submissionModel));
        }

        public void Delete(SubmissionModel submissionModel)
        {
            sRepo.Delete(sMapper.Map(submissionModel));
        }

        public List<SubmissionModel> GetAll()
        {
            List<Submission> submissions = sRepo.GetAll();
            List<SubmissionModel> submissionModels = new List<SubmissionModel>();

            submissions.ForEach(l => submissionModels.Add(sMapper.Map(l)));
            return submissionModels;
        }

        public SubmissionModel GetByID(int ID)
        {
            return sMapper.Map(sRepo.GetByID(ID));
        }

        public List<SubmissionModel> GetGradesByAssignmentID(int assignmentID)
        {
            List<Submission> submissions = sRepo.GetAllByAssignmentID(assignmentID);

            List<SubmissionModel> sm = new List<SubmissionModel>();

            submissions.ForEach(s => sm.Add(sMapper.Map(s)));
            return sm;
        }

        public List<SubmissionModel> GetAllByStudentID(int ID)
        {
            List<Submission> submissions = sRepo.GetAllByStudentID(ID);
            List<SubmissionModel> submissionModels = new List<SubmissionModel>();
            submissions.ForEach(s => submissionModels.Add(sMapper.Map(s)));
            return submissionModels;
        }

        public void Update(SubmissionModel submissionModel)
        {
            sRepo.Update(sMapper.Map(submissionModel));
        }

        public void Grade(int id, decimal Grade)
        {
            sRepo.Grade(id, Grade);
        }
    }
}
