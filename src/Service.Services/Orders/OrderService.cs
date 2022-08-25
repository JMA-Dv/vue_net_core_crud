using Core.DTOs.Orders;
using Core.Model;
using Persistence.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services.Orders
{

    public interface IOrderService
    {

    }
    public class OrderService : IOrderService
    {
        private readonly AppDbContext _context;

        public OrderService(AppDbContext context)
        {
            _context = context;
        }

        
    }
}
