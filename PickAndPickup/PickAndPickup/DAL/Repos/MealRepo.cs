using DAL.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DAL.Repos
{
    public class MealRepo : IMealRepo
    {
        PickAndPickupEntities DB = new PickAndPickupEntities();
        public void Add(Meal meal)
        {
            if (meal == null) return;
            DB.Meals.Add(meal);
            DB.SaveChanges();
        }

        public void Delete(int mealID)
        {
            if (mealID < 1) return;
            var meal = DB.Meals.FirstOrDefault(u => u.ID == mealID);
            if (meal == null) return;
            meal.IsDeleted = true;
            DB.Entry(meal).CurrentValues.SetValues(meal);
            DB.SaveChanges();
        }

        public List<Meal> GetAll()
        {
            return DB.Meals.ToList();
        }

        public Meal GetByID(int ID)
        {
            return this.GetCurrent().FirstOrDefault(m => m.ID == ID);
        }

        public List<Meal> GetCurrent()
        {
            var Meals = DB.Meals.ToList();
            List<Meal> cm = new List<Meal>();
            foreach(Meal m in Meals)
            {
                if(m.IsDeleted!= true)
                {
                    cm.Add(m);
                }
            }

            cm.Sort();
            return cm;
        }

        public void Update(Meal meal)
        {
            if (meal == null) return;
            var ml = DB.Meals.FirstOrDefault(u => u.ID == meal.ID);
            if (ml == null) return;
            DB.Entry(ml).CurrentValues.SetValues(meal);
            DB.SaveChanges();
        }
    }
}