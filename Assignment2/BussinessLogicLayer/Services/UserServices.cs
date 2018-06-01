using Assignment2.BussinessLogicLayer.Models;
using BussinessLogicLayer.Contracts;
using DataAccessLayer.Repository;
using DataAccessLayer.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;
using Assignment2.BussinessLogicLayer.Contracts;
using Assignment2.BussinessLogicLayer.Mapper;
using DataAccessLayer;
using System.Net.Mail;


namespace BussinessLogicLayer.Services
{
    public class UserServices : IUserServices
    {
        IUserRepo uRepo;
        IUserMapper uMapper = new UserMapper();

        public UserServices(IUserRepo uR)
        {
            uRepo = uR;
        }

        public string Add(UserModel userModel)
        {
            userModel.Token = Membership.GeneratePassword(128, 0);

            MailMessage mail = new MailMessage("laboratorykey@gmail.com", userModel.Email);
            SmtpClient client = new SmtpClient("smtp.gmail.com");
            client.Port = 587;
            client.Credentials = new System.Net.NetworkCredential("laboratorykey@gmail.com", "a1a2a3a4a5a6!");
            client.EnableSsl = true;

            mail.Subject = "Your " + userModel.Type + " account token";
            mail.Body = "Your " + userModel.Type + " account has been created!\n Use the following token to register: " + userModel.Token;
            client.Send(mail);

            uRepo.Add(uMapper.Map(userModel));
            return userModel.Token;
        }

        public void Delete(UserModel userModel)
        {
            uRepo.Delete(uMapper.Map(userModel));
        }

        public List<UserModel> GetAll()
        {
            List<User> users = uRepo.GetAll();
            List<UserModel> userModels = new List<UserModel>();
            users.ForEach(u => userModels.Add(uMapper.Map(u)));
            return userModels;
        }

        public UserModel GetByEmail(string Email)
        {
            return uMapper.Map(uRepo.GetByEmail(Email));
        }

        public UserModel GetByID(int ID)
        {
            return uMapper.Map(uRepo.GetByID(ID));
        }

        public UserModel GetByToken(string Token)
        {
            return uMapper.Map(uRepo.GetByToken(Token));
        }

        public void Update(UserModel userModel)
        {
            uRepo.Update(uMapper.Map(userModel));
        }
    }
}
