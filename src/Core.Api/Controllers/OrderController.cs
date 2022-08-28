﻿using Core.DTOs.Orders;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Services.Common.Pagination;
using Service.Services.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {

        private readonly IOrderService _service;

        public OrderController(IOrderService service)
        {
            _service = service;
        }


        [HttpPost]
        public async Task<ActionResult<OrderDto>> CreateOrderAsync(OrderCreateDto model) => await _service.CreateOrderAsync(model);

        [HttpGet]
        public async Task<ActionResult<PaginatedList<OrderDto>>> GetPaginatedAsync(int page = 1, int take = 20)
            => await _service.GetOrderPaginatedAsync(page, take);
    }
}