using Assignment1.DataLayer.Contracts;
using Assignment1.DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Assignment1.DataLayer.Repositories
{
    class ShowRepo : IShowRepo
    {
        private List<ShowDTO> showsList;
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
        private void getAllShows()
        {
            showsList = new List<ShowDTO>();
            SqlCommand cmd = connectToDB();
            cmd.CommandText = "select * from Shows";
            SqlDataReader dataReader = cmd.ExecuteReader();
            while (dataReader.Read())
            {
                ShowDTO show = new ShowDTO();
                show.setID((Int32)dataReader["ID"]);
                show.setTitle(dataReader["Title"].ToString());
                show.setGenre(dataReader["Genre"].ToString());
                show.setDistribution(dataReader["Distr"].ToString());
                DateTime dt;
                DateTime.TryParse(dataReader["Date"].ToString(), out dt);
                show.setDate(dt);
                show.setNumberOfTickets((Int32)dataReader["NumberOfTickets"]);
                showsList.Add(show);
            }
            cmd.Connection.Close();
        }
        private SqlCommand buildCmd(ShowDTO show)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("ID", show.getID());
            cmd.Parameters.AddWithValue("NrTickets", show.getNumberOfTickets());
            cmd.Parameters.AddWithValue("Genre", show.getGenre());
            cmd.Parameters.AddWithValue("Date", show.getDate().ToString());
            cmd.Parameters.AddWithValue("Distribution", show.getDistribution());
            cmd.Parameters.AddWithValue("Title", show.getTitle());
            return cmd;
        }

        public ShowRepo()
        {
            showsList = new List<ShowDTO>();
            this.getAllShows();
        }

        public bool createShow(ShowDTO show)
        {
            SqlCommand cmd = buildCmd(show);
            cmd = connectToDB(cmd);
            cmd.CommandText = "insert into Shows (Title, Genre, Distr, Date, NumberOfTickets) values (@Title, @Genre, @Distribution, @Date, @NrTickets)";
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
            showsList.Add(show);
            return true;
        }

        public bool deleteShowByID(int ID)
        {
            SqlCommand cmd = connectToDB();
            cmd.Parameters.AddWithValue("ID", ID);
            cmd.CommandText = "delete from Shows where ID=@ID";
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
            ShowDTO oldShow = showsList.Find(show => show.getID() == ID);
            showsList.Remove(oldShow);
            return true;
        }

        public List<ShowDTO> getShows()
        {
            getAllShows();
            return showsList;
        }

        public bool updateShow(ShowDTO show)
        {
            SqlCommand cmd = buildCmd(show);
            cmd = connectToDB(cmd);
            cmd.CommandText = "update Shows set Title = @Title, Genre = @Genre, Distr = @Distribution, Date = @Date, NumberOfTickets = @NrTickets where ID=@ID";
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
            ShowDTO oldShow = showsList.Find(shw => shw.getID() == show.getID());
            showsList.Remove(oldShow);
            showsList.Add(show);
            return true;
        }

        public List<ShowDTO> getShowsByTitle(string Title)
        {
            List<ShowDTO> showsByTitle = new List<ShowDTO>();
            SqlCommand cmd = connectToDB();
            cmd.Parameters.AddWithValue("Title", Title);
            cmd.CommandText = "select * from Shows where Title = @Title";
            SqlDataReader dataReader = cmd.ExecuteReader();
            while (dataReader.Read())
            {
                ShowDTO show = new ShowDTO();
                show.setID((Int32)dataReader["ID"]);
                show.setTitle(dataReader["Title"].ToString());
                show.setGenre(dataReader["Genre"].ToString());
                show.setDistribution(dataReader["Distr"].ToString());
                show.setDate(DateTime.Parse(dataReader["Date"].ToString()));
                show.setNumberOfTickets((Int32)dataReader["NumberOfTickets"]);
                showsByTitle.Add(show);
            }
            cmd.Connection.Close();

            return showsByTitle;
        }
    }
}
