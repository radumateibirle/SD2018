using Assignment1.DataLayer.Contracts;
using Assignment1.DataLayer.Repositories;
using Assignment1.ServicesLayer.Contracts;
using Assignment1.ServicesLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assignment1.ServicesLayer.Services
{
    class UserService : IUserService
    {
        private readonly IUserRepo repository;
        private readonly IUserMap mapper;

        public UserService()
        {
            repository = new UserRepo();
            mapper = new UserMap();
            if (this.getUsers().FindIndex(usr => usr.getFunction() == 0) == -1)
            {
                UserModel admin = new UserModel();
                admin.setFunction(0);
                admin.setPlainPassword("admin");
                admin.setUsername("admin");
                this.add(admin);
                Console.WriteLine("added default admin");
            } //if no admin, add admin admin
        }

        public bool add(UserModel user)
        {
            return repository.createUser(mapper.map(user));
        }

        public bool delete(int ID)
        {
            return repository.deleteUserByID(ID);
        }

        public UserModel getUserByID(int ID)
        {
            List<UserModel> users = getUsers();
            foreach(UserModel user in users)
            {
                if (user.getID() == ID) return user;
            }
            return null;
        }

        public List<UserModel> getUsers()
        {
            List<UserModel> users = new List<UserModel>();
            repository.getUsers().ForEach(user => users.Add(mapper.map(user)));
            return users;
        }

        public bool isID(int ID)
        {

            if (this.getUsers().FindIndex(usr => usr.getID() == ID) != -1) return true;
            return false;
        }

        public bool isUsername(string Username)
        {
            if (this.getUsers().FindIndex(usr => usr.getUsername() == Username) != -1) return true;
            return false;
        }

        public int login(UserModel user)
        {
            UserModel found = this.getUsers().Find(usr => usr.getUsername() == user.getUsername());
            if (found != null) if (found.getPassword() == user.getPassword()) return found.getFunction();
            return -1;
        }

        public bool update(UserModel user)
        {
            return repository.updateUser(mapper.map(user));
        }
    }
}
