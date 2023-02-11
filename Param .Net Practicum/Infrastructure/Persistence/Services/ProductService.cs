using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Primitives;
using Param_.Net_Practicum.Core.Applicaiton.Constants;
using Param_.Net_Practicum.Core.Applicaiton.Dtos.ProductDto;
using Param_.Net_Practicum.Core.Applicaiton.Dtos.ResponseDto;
using Param_.Net_Practicum.Core.Applicaiton.Exceptions;
using Param_.Net_Practicum.Core.Applicaiton.Extensions;
using Param_.Net_Practicum.Core.Applicaiton.Models;
using Param_.Net_Practicum.Core.Applicaiton.Services;
using Param_.Net_Practicum.Core.Domain.Entities;
using Param_.Net_Practicum.Infrastructure.Persistence.Context;

namespace Param_.Net_Practicum.Infrastructure.Persistence.Services
{
    public class ProductService : IProductService
    {
        private readonly ApplicationContext _context;
        public ProductService(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<BaseResponse> AddProductAsync(CreateProductDto createProductDto)
        {
            await CheckCategoryIsNull(createProductDto.CategoryId);

            Product p = new()
            {
                CategoryId = createProductDto.CategoryId,
                Description = createProductDto.Description,
                Name = createProductDto.Name,
                Price = createProductDto.Price,
            };
            await _context.Products.AddAsync(p);
            await _context.SaveChangesAsync();

            return BaseResponse.Succes(ProductConstant.ProductAddMessage);
        }

        public async Task<BaseResponse> DeleteProductAsync(Guid id)
        {
            Product? product = await _context.Products.FirstOrDefaultAsync(x => x.Id == id);

            if (product == null)
                throw new NotFoundException("Product Not Found");
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return BaseResponse.Succes(ProductConstant.ProductDeleteMessage);
        }

        public async Task<DataResponse<List<GetProductDto>>> GetListProductAsync(Dynamic? dynamic = null)
        {

            List<GetProductDto> product;
            if (dynamic != null)
                product = await _context.Products.AsQueryable().ApplyFilter(dynamic).Select(x => new GetProductDto()
                {
                    CategoryName = x.Category.Name,
                    Description = x.Description,
                    Name = x.Name,
                    Price = x.Price,
                }).ToListAsync();
            else
                product = await _context.Products.Select(x => new GetProductDto()
                {
                    CategoryName = x.Category.Name,
                    Description = x.Description,
                    Name = x.Name,
                    Price = x.Price,
                }).ToListAsync();

            return DataResponse<List<GetProductDto>>.Succes(product);
        }

        public async Task<DataResponse<GetProductDto>> GetProductById(Guid id)
        {
            var product = await _context.Products.Include(x => x.Category).FirstOrDefaultAsync(x => x.Id == id);

            if (product == null)
                throw new NotFoundException("Böyle Bir Ürün Bulunamadı");

            GetProductDto productDto = new()
            {
                CategoryName = product.Category.Name,
                Description = product.Description,
                Name = product.Name,
                Price = product.Price,
            };

            return DataResponse<GetProductDto>.Succes(productDto);
        }

        public async Task<BaseResponse> UpdateProductAsync(UpdateProductDto updateProductDto)
        {
            await CheckCategoryIsNull(updateProductDto.CategoryId);

            Product? product = await _context.Products.FirstOrDefaultAsync(x => x.Id == updateProductDto.Id);

            if (product == null)
                throw new NotFoundException("Product Not Found");

            product.Id = updateProductDto.Id;
            product.CategoryId = product.CategoryId;
            product.Description = product.Description;
            product.CreateDate = product.CreateDate;
            product.UpdateDate = DateTime.Now;
            product.Name = product.Name;
            product.Price = product.Price;

            _context.Products.Update(product);
            await _context.SaveChangesAsync();
            return BaseResponse.Succes(ProductConstant.ProductUpdateMessage);
        }

        public async Task<BaseResponse> UpdateProductPriceAsync(UpdateProductPriceDto updateProductPriceDto)
        {
            Product? product = await _context.Products.FirstOrDefaultAsync(x => x.Id == updateProductPriceDto.Id);
            if (product == null)
                throw new NotFoundException("Product Not Found");
            product.Price = updateProductPriceDto.Price;
            _context.Products.Update(product);
            await _context.SaveChangesAsync();
            return BaseResponse.Succes(ProductConstant.ProductUpdatePriceMessage);
        }

        private async Task CheckCategoryIsNull(Guid categoryId)
        {
            Category? category = await _context.Categories.FindAsync(categoryId);
            if (category == null)
                throw new NotFoundException("Category is not Found");
            return;
        }
    }
}
