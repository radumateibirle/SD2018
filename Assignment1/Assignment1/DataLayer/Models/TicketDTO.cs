using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assignment1.DataLayer.Models
{
    class TicketDTO
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
    }
}
