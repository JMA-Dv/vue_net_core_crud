using AutoMapper;
using Core.DTOs.Orders;
using Core.Model;
using Core.Model.Orders;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;
using Service.Services.Common;
using Service.Services.Common.Extensions;
using Service.Services.Common.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services.Orders
{
    public interface IOrderService
    {
        Task<OrderDto> CreateOrderAsync(OrderCreateDto order);
        Task<OrderDto> GetOrderById(int id);
        Task<PaginatedList<OrderDto>> GetOrderPaginatedAsync(int page, int take);
    }
    public class OrderService : IOrderService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        private const decimal IVA_RATE = 0.18m;

        public OrderService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<OrderDto> CreateOrderAsync(OrderCreateDto order)
        {
            var entry = _mapper.Map<Order>(order);

            CalculateOrderDetail(entry.Items);

            CalculateOrderHeader(entry);

            await _context.Orders.AddAsync(entry);
            await _context.SaveChangesAsync();
            
            return await GetOrderById(entry.OrderId);
        }

        private void CalculateOrderDetail(IEnumerable<OrderDetail> details)
        {
            foreach(var item in details)
            {
                item.Total = item.UnitPrice * item.Quantity;
                item.Iva = item.Total * IVA_RATE;
                item.Subtotal = item.Total - item.Iva;
            }
        }

        private void CalculateOrderHeader(Order order)
        {
            order.Total = order.Items.Sum(x => x.Total);
            order.Subtotal = order.Items.Sum(x => x.Subtotal);
            order.Iva = order.Items.Sum(x => x.Iva);
        }

        public async Task<OrderDto> GetOrderById(int id)
        {
            return _mapper.Map<OrderDto>(
                await _context.Orders
                .Include(x => x.Client)
                .Include(x => x.Items)
                .ThenInclude(x => x.Product)
                .FirstOrDefaultAsync(x=> x.OrderId == id));
                
        }

        public async Task<PaginatedList<OrderDto>> GetOrderPaginatedAsync(int page, int take)
        {
            return _mapper.Map<PaginatedList<OrderDto>>(
               await _context.Orders
               .Include(x=> x.Client)
               .Include(x=>x.Items).ThenInclude(x=> x.Product)
               .OrderByDescending(x => x.OrderId)
               .AsQueryable().PagedAsync(page, take));
        }
    }
}
