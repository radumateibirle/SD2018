using Assignment2.BussinessLogicLayer.Models;
using Assignment2.Controllers.Contracts;
using Assignment2.Controllers.Mapper;
using Assignment2.Models;
using BussinessLogicLayer.Contracts;
using BussinessLogicLayer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Assignment2.Controllers
{
    public class SubmissionController : ApiController
    {
        ISubmissionServices sServices;
        ISubmissionMapperAPI sMapper = new SubmissionMapperAPI();

        public SubmissionController(ISubmissionServices sS)
        {
            sServices = sS;
        }

        // GET: api/Submission
        public IEnumerable<SubmissionModel> Get()
        {
            return sServices.GetAll();
        }

        // GET: api/Submission/5
        public SubmissionModel Get(int id)
        {
            return sServices.GetByID(id);
        }


        [Route("api/Submission/Grades/{AssignmentID}")]
        // GET: api/Submission/Grades/{AssignmentID}
        public List<SubmissionModelAPI> GetGrades(int AssignmentID)
        {

            List<SubmissionModel> submissions= sServices.GetGradesByAssignmentID(AssignmentID);
            List<SubmissionModelAPI> sm = new List<SubmissionModelAPI>();
            submissions.ForEach(s => sm.Add(sMapper.Map(s)));
            return sm;
        }

        // POST: api/Submission
        public void Post([FromBody]SubmissionModelAPI value)
        {
            sServices.Add(sMapper.Map(value));
        }


        [Route("api/Submission/{studID}/Submit/{assignmentID}")]
        // POST: api/Submission/{studID}/Submit/{assignmentID}
        public void Post(int studID, int assignmentID, string git, string note)
        {
            SubmissionModelAPI sub = new SubmissionModelAPI();
            sub.StudentID = studID;
            sub.AssignmentID = assignmentID;
            sub.GitLink = git;
            sub.Notes = note;

            bool found = false;

            List<SubmissionModel> submissions = sServices.GetAllByStudentID(studID);
            submissions.ForEach(s => 
            {
                if(s.AssignmentID == assignmentID)
                {
                    return;
                }
            });

            sServices.Add(sMapper.Map(sub));
        }

        [Route("api/Submission/GradeSubmission")]
        // PUT: api/Submission/GradeSubmission
        public void Put(int id, decimal grade)
        {
            sServices.Grade(id, grade);
        }

        [Route("api/Submission/Edit")]
        // PUT: api/Submission/5
        public void Put([FromBody]SubmissionModel value)
        {
            sServices.Update(value);
        }



        // DELETE: api/Submission/5
        public void Delete(int id)
        {
            sServices.Delete(sServices.GetByID(id));
        }
    }
}
