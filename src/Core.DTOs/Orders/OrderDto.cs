using Core.DTOs.Client;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.DTOs.Orders
{
    public class OrderDto
    {
        public int OrderId { get; set; }
        public int ClientId { get; set; }
        public ClientDto Client { get; set; }
        public decimal Iva { get; set; }
        public decimal Subtotal { get; set; }
        public decimal Total { get; set; }
        public IEnumerable<OrderDetailDto> Items { get; set; }
    }

    public class OrderCreateDto
    {
        public int ClientId { get; set; }
        public IEnumerable<OrderDetailCreateDto> Items { get; set; }
    }
   

    



}
