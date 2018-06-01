using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
    public class SubmissionModelAPI
    {
        public int AssignmentID { get; set; }
        public int StudentID { get; set; }
        public string GitLink { get; set; }
        public string Notes { get; set; }
        public Nullable<decimal> Grade { get; set; }
    }
}
