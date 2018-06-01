using Assignment1.DataLayer.Contracts;
using Assignment1.DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Assignment1.DataLayer.Repositories
{
    class UserRepo : IUserRepo
    {
        private List<UserDTO> usersList;
        private SqlCommand connectToDB()
        {
            SqlCommand command = new SqlCommand();
            command = connectToDB(command);
            return command;
        }
        private SqlCommand connectToDB(SqlCommand command)
        {
            command.Connection = new SqlConnection("Data Source=DESKTOP-1QG2BML\\SQLEXPRESS;Initial Catalog=Assignment1;Integrated Security=True");
            command.Connection.Open();
            return command;
        }
        private void getAllUsers()
        {
            usersList = new List<UserDTO>();
            SqlCommand cmd = connectToDB();
            cmd.CommandText = "select * from Users";
            SqlDataReader dataReader = cmd.ExecuteReader();
            while(dataReader.Read())
            {
                UserDTO usr = new UserDTO();
                usr.setID((Int32)dataReader["ID"]);
                usr.setPassword(dataReader["Pass"].ToString());
                usr.setUsername(dataReader["Username"].ToString());
                usr.setFunction((Int32)dataReader["RoleFlag"]);
                usersList.Add(usr);
            }
            cmd.Connection.Close();
        }
        private SqlCommand buildCmd (UserDTO usr)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("ID", usr.getID());
            cmd.Parameters.AddWithValue("Username", usr.getUsername());
            cmd.Parameters.AddWithValue("Password", usr.getPassword());
            cmd.Parameters.AddWithValue("Function", usr.getFunction());
            return cmd;
        }

        public UserRepo()
        {
            usersList = new List<UserDTO>();
            this.getAllUsers();
        }

        public bool createUser(UserDTO user)
        {
            SqlCommand cmd = buildCmd(user);
            cmd = connectToDB(cmd);
            cmd.CommandText = "insert into Users (Username, Pass, RoleFlag) values (@Username, @Password, @Function)";
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
            usersList.Add(user);
            return true;
        }

        public bool deleteUserByID(int ID)
        {
            SqlCommand cmd = connectToDB();
            cmd.Parameters.AddWithValue("ID", ID);
            cmd.CommandText = "delete from Users where ID=@ID";
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
            UserDTO oldUser = usersList.Find(user => user.getID() == ID);
            usersList.Remove(oldUser);
            return true;
        }

        public List<UserDTO> getUsers()
        {
            getAllUsers();
            return usersList;
        }

        public bool updateUser(UserDTO user)
        {
            SqlCommand cmd = buildCmd(user);
            cmd = connectToDB(cmd);
            cmd.CommandText = "update Users set Username = @Username, Pass = @Password, RoleFlag = @Function where ID=@ID";
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
            UserDTO oldUser = usersList.Find(usr => usr.getID() == user.getID());
            usersList.Remove(oldUser);
            usersList.Add(user);
            return true;
        }
    }
}
