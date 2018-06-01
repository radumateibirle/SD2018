using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
    public class AssignmentModelAPI
    {
        public int LaboratoryID { get; set; }
        public string Name { get; set; }
        public System.DateTime Deadline { get; set; }
        public string Description { get; set; }
    }
}
