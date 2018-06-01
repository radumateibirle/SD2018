using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Contracts
{
    public interface ILaboratoryRepo
    {
        void Add(Laboratory laboratory);
        void Delete(Laboratory laboratory);
        List<Laboratory> GetAll();
        Laboratory GetByID(int ID);
        int GetIdFromNumber(int labNr);
        void Update(Laboratory laboratory);
    }
}
