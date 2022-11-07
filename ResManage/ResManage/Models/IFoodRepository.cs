using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResManage.Models
{
    public interface IFoodRepository
    {
        Food GetFood(int Id);
        IEnumerable<Food> GetAllFoods();
        Food Add(Food food);

        Food Update(Food foodChanges);

        Food Delete(int Id);
    }
}
