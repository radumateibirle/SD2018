using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assignment1.ServicesLayer.Models
{
    public class TicketModel
    {
        private int ID;
        private int ShowID;
        private int Row;
        private int Column;

        public int getID() { return ID; }
        public void setID(int ID) { this.ID = ID; }

        public int getShowID() { return ShowID; }
        public void setShowID(int ShowID) { this.ShowID = ShowID; }

        public int getRow() { return Row; }
        public void setRow(int Row) { this.Row = Row; }

        public int getColumn() { return Column; }
        public void setColumn(int Column) { this.Column = Column; }

        public bool Equals(TicketModel ticket)
        {
            return (this.ShowID == ticket.getShowID()) && (this.Row == ticket.getRow()) && (this.Column == ticket.getColumn());
        }

        public string[] ToStringArray()
        {
            return new string[] { ID.ToString(), ShowID.ToString(), Row.ToString(), Column.ToString() };
        }
    }
}
