using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Model.Orders
{
    public class Order
    {
        public int OrderId { get; set; }
        public int ClientId { get; set; }
        public Client Client { get; set; }
        public decimal Iva { get; set; }
        public decimal Subtotal { get; set; }
        public decimal Total { get; set; }

        public IEnumerable<OrderDetail> Items { get; set; }

    }
}
