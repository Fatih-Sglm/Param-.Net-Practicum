using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using Param_.Net_Practicum.Core.Applicaiton.Dtos.ProductDto;
using Param_.Net_Practicum.Core.Applicaiton.Exceptions;
using Param_.Net_Practicum.Core.Applicaiton.Extensions;
using Param_.Net_Practicum.Core.Applicaiton.Models;
using Param_.Net_Practicum.Core.Applicaiton.Services;
using Param_.Net_Practicum.Core.Domain.Entities;
using Param_.Net_Practicum.CustomAttirbutes;
using Param_.Net_Practicum.Infrastructure.Persistence.Context;
using System.Linq.Dynamic.Core;

namespace Param_.Net_Practicum.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        //private readonly ApplicationContext _context;

        //public ProductController(ApplicationContext context)
        //{
        //    _context = context;
        //}

        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        #region List(HttpGet)
        /// <summary>
        ///  Return List of Products
        /// </summary>
        /// <param name="dynamic">There is a sort property in this class, it sends you the data in order with the column and sorting type you have given to it.</param>
        /// <returns></returns>
        [CustomAuthorizeAttirbute]
        [HttpGet]
        public async Task<IActionResult> GetProducts([FromQuery] Dynamic? dynamic, [FromHeader] string? token)
        {
            var ListProduct = await _productService.GetListProductAsync(dynamic);
            return Ok(ListProduct);
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
            var product = await _productService.GetProductById(productId);
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
            var response = await _productService.AddProductAsync(createProductDto);
            return Ok(response);
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
            var response = await _productService.UpdateProductAsync(updateProductDto);
            return Ok(response);
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
            var response = await _productService.UpdateProductPriceAsync(updateProductPriceDto);
            return Ok(response);
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
            var response = await _productService.DeleteProductAsync(id);
            return Ok(response);
        }

        #endregion


    }
}
