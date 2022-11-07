using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResManage.Models
{
    public class SQLFoodRepository : IFoodRepository
    {
        private readonly MyAppDbContext context;

        public SQLFoodRepository(MyAppDbContext context)
        {
            this.context = context;
        }

        Food IFoodRepository.Add(Food food)
        {
            context.Foods.Add(food);
            context.SaveChanges();
            return food;
        }

        Food IFoodRepository.Delete(int Id)
        {
            Food food = context.Foods.Find(Id);
            if (food != null)
            {
                context.Foods.Remove(food);
                context.SaveChanges();
            }
            return food;
        }

        IEnumerable<Food> IFoodRepository.GetAllFoods()
        {
            return context.Foods;
        }

        Food IFoodRepository.GetFood(int id)
        {
            return context.Foods.FirstOrDefault(m => m.Id == id);
        }

        Food IFoodRepository.Update(Food foodChanges)
        {
            var food = context.Foods.Attach(foodChanges);
            food.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return foodChanges;
        }
    }

}
