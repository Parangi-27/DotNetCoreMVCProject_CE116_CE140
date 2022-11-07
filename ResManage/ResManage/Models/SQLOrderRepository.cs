using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResManage.Models
{
    public class SQLOrderRepository : IOrderRepository
    {
        private readonly MyAppDbContext context;

        public SQLOrderRepository(MyAppDbContext context)
        {
            this.context = context;
        }

        Order IOrderRepository.Add(Order order)
        {
            context.Orders.Add(order);
            context.SaveChanges();
            return order;
        }

        Order IOrderRepository.Delete(int Id)
        {
            Order order = context.Orders.Find(Id);
            if (order != null)
            {
                context.Orders.Remove(order);
                context.SaveChanges();
            }
            return order;
        }

        IEnumerable<Order> IOrderRepository.GetAllOrders()
        {
            return context.Orders;
        }

        Order IOrderRepository.GetOrder(int id)
        {
            return context.Orders.FirstOrDefault(m => m.Id == id);
        }

        Order IOrderRepository.Update(Order orderChanges)
        {
            var food = context.Orders.Attach(orderChanges);
            food.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return orderChanges;
        }
    }

}
