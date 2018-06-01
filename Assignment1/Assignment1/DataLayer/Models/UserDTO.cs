using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assignment1.DataLayer.Models
{
    class UserDTO
    {
        private int ID;
        private string Username;
        private string Password;
        private int Function; //0 admin, 10 cashier

        public UserDTO(int ID, string Username, string Password, int Function)
        {
            this.ID = ID;
            this.Username = Username;
            this.Password = Password;
            this.Function = Function;
        }
        public UserDTO() { }

        public int getID() { return ID; }
        public void setID(int ID) { this.ID = ID; }

        public string getUsername() { return Username; }
        public void setUsername(string Username) { this.Username = Username; }
        
        public string getPassword() { return Password; }
        public void setPassword(string Password) { this.Password = Password; }

        public int getFunction() { return Function; }
        public void setFunction(int Function) { this.Function = Function; }

    }
}
