using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using Param_.Net_Practicum.Core.Applicaiton.Dtos;
using Param_.Net_Practicum.Core.Applicaiton.Extensions;
using Param_.Net_Practicum.Core.Applicaiton.Models;
using Param_.Net_Practicum.Core.Domain.Entities;
using Param_.Net_Practicum.Infrastructure.Persistence.Context;
using System.Linq.Dynamic.Core;

namespace Param_.Net_Practicum.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public ProductController(ApplicationContext context)
        {
            _context = context;
        }


        #region List(HttpGet)
        /// <summary>
        ///  Return List of Products
        /// </summary>
        /// <param name="dynamic">There is a sort property in this class, it sends you the data in order with the column and sorting type you have given to it.</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetProducts([FromQuery] Dynamic dynamic)
        {
            List<Product> product;
            if (dynamic != null)
                product = _context.Products.AsQueryable().ApplyFilter(dynamic);
            else
                product = await _context.Products.ToListAsync();
            return Ok(product);
        }
        #endregion


        #region GetById
        /// <summary>
        /// Returns a single product based on the entered Id
        /// </summary>
        /// <param name="productId">product Id</param>
        /// <returns></returns>
        [HttpGet("{productId}")]
        public async Task<IActionResult> GetSingeProduct([FromRoute] Guid productId)
        {
            var product = await _context.Products.FirstOrDefaultAsync(x => x.Id == productId);

            if (product == null)
                return NotFound("Böyle Bir Ürün Bulunamadı");

            return Ok(product);
        }

        #endregion


        #region Create(HttpPost)

        /// <summary>
        ///  Creating new Product
        /// </summary>
        /// <param name="createProductDto"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductDto createProductDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(GetErrorModel(ModelState));

            Product p = new()
            {
                CategoryName = createProductDto.CategoryName,
                Description = createProductDto.Description,
                Name = createProductDto.Name,
                Price = createProductDto.Price,
            };
            await _context.Products.AddAsync(p);
            return Ok();
        }

        #endregion



        #region Update(HttpPut)
        /// <summary>
        ///  Updating Existing Product
        /// </summary>
        /// <param name="updateProductDto"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> UpdateProduct(UpdateProductDto updateProductDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(GetErrorModel(ModelState));

            Product? product = await _context.Products.FirstOrDefaultAsync(x => x.Id == updateProductDto.Id);

            if (product == null)
                return NotFound("Böyle Bir Ürün Bulunamadı");

            product.Id = updateProductDto.Id;
            product.CategoryName = product.CategoryName;
            product.Description = product.Description;
            product.CreateDate = product.CreateDate;
            product.UpdateDate = DateTime.Now;
            product.Name = product.Name;
            product.Price = product.Price;
            return Ok("Ürün GÜncellendi");
        }

        #endregion

        #region Update(HttpPatch)
        /// <summary>
        /// Partially Update Existing Product
        /// </summary>
        /// <param name="updateProductPriceDto"></param>
        /// <returns></returns>
        [HttpPatch]
        public async Task<IActionResult> UpdateProductPrice(UpdateProductPriceDto updateProductPriceDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(GetErrorModel(ModelState));

            Product? product = await _context.Products.FirstOrDefaultAsync(x => x.Id == updateProductPriceDto.Id);
            if (product == null)
                return NotFound("Böyle Bir Ürün Bulunamadı");
            product.Price = updateProductPriceDto.Price;

            return Ok("Ürün GÜncellendi");
        }
        #endregion

        #region Delete(HttpDelete)
        /// <summary>
        /// Deleting Existing Product
        /// </summary>
        /// <param name="id">Product Id</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct([FromRoute] Guid id)
        {
            Product? product = await _context.Products.FirstOrDefaultAsync(x => x.Id == id);

            if (product == null)
                return NotFound("Böyle Bir Ürün Bulunamadı");
            _context.Products.Remove(product);
            return Ok("Ürün Silindi");
        }

        #endregion

        #region Private Method
        /// <summary>
        /// returns validation exception message with key
        /// </summary>
        /// <param name="modelState">State of the model sent by the client</param>
        /// <returns></returns>
        private static Dictionary<string, List<string>> GetErrorModel(ModelStateDictionary modelState)
        {
            return modelState.Where(x => x.Value.Errors.Any())
                            .ToDictionary(e => e.Key, e => e.Value.Errors.Select(e => e.ErrorMessage).ToList());
        }
        #endregion
    }
}
