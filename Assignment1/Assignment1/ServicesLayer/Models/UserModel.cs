using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Assignment1.ServicesLayer.Models
{
    public class UserModel
    {

        private int ID;
        private string Username;
        private string Password;
        private int Function;//0 admin, 10 cashier

        public UserModel(int ID, string Username, string Password, int Function)
        {
            this.ID = ID;
            this.Username = Username;
            this.Password = Password;
            this.Function = Function;
        }
        public UserModel() { }

        public int getID() { return ID; }
        public void setID(int ID) { this.ID = ID; }

        public string getUsername() { return Username; }
        public void setUsername(string Username) { this.Username = Username; }

        public string getPassword() { return Password; }
        public void setHashedPassword(string Password) { this.Password = Password; }
        public void setPlainPassword(string Password) { this.Password = hash(Password); }

        public int getFunction() { return Function; }
        public void setFunction(int Function) { this.Function = Function; }

        public string hash(string toHash)
        {
            Console.WriteLine(toHash);
            string hashed;
            byte[] data = Encoding.UTF8.GetBytes(toHash);
            using (HashAlgorithm sha = new SHA256Managed())
            {
                byte[] encryptedBytes = sha.TransformFinalBlock(data, 0, data.Length);
                hashed = Convert.ToBase64String(sha.Hash);
            }
            Console.WriteLine(hashed);
            return hashed;
        }

        public string[] ToStringArray()
        {
            string fct = "";
            if (Function == 0) fct = "Admin";
            else fct = "Cashier";
            return new string[] { ID.ToString(), Username, Password, fct };
        }
    }
}
