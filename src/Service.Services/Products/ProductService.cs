using AutoMapper;
using Core.DTOs.Products;
using Core.Model.Products;
using Persistence.Data;
using Service.Services.Common;
using Service.Services.Common.Errors;
using Service.Services.Common.Extensions;
using Service.Services.Common.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services.Products
{
    public interface IProductService:IRepository<ProductDto,ProductCreateDto,ProductUpdateDto>
    {
        public Task<PaginatedList<ProductDto>> GetAllPaginated(int page, int take = 20);
    }
    public class ProductService : IProductService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public ProductService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async  Task<ProductDto> Create(ProductCreateDto model)
        {
            var product = new Product()
            {
                Description = model.Description,
                Name = model.Name,
                Price = model.Price
            };

            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();



            return _mapper.Map<ProductDto>(product);
        }

        public async Task Delete(int id)
        {
            
            _context.Products.Remove(
                new Product()
                {
                    ProductId = id
                }
                );
            await _context.SaveChangesAsync();

        }

        public async Task<PaginatedList<ProductDto>> GetAllPaginated(int page, int take = 20)
        {
            return _mapper.Map<PaginatedList<ProductDto>>(
                await _context.Products.OrderByDescending(x => x.ProductId)
                .AsQueryable().PagedAsync(page, take));
        }

        public async Task<ProductDto> GetById(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
                throw new NotFoundException("Could not found Product");

            return _mapper.Map<ProductDto>(product);
        }

        public  async Task Update(ProductUpdateDto model, int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
                throw new NotFoundException("Could not found Product");

            product.Description = model.Description;
            product.Name = model.Name;
            product.Price = model.Price;
            _context.Update(product);
            await _context.SaveChangesAsync();
        }
    }
}
