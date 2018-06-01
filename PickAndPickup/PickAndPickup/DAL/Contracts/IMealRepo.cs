using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Contracts
{
    public interface IMealRepo
    {
        void Add(Meal meal);
        void Delete(int mealID);
        void Update(Meal meal);
        List<Meal> GetAll();
        List<Meal> GetCurrent();
        Meal GetByID(int ID);
    }
}
