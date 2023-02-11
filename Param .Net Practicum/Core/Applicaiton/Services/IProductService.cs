using Param_.Net_Practicum.Core.Applicaiton.Dtos.ProductDto;
using Param_.Net_Practicum.Core.Applicaiton.Dtos.ResponseDto;
using Param_.Net_Practicum.Core.Applicaiton.Models;

namespace Param_.Net_Practicum.Core.Applicaiton.Services
{
    /// <summary>
    /// Interface created for product operations
    /// </summary>
    public interface IProductService
    {
        /// <summary>
        /// The method that perform for adding the product
        /// </summary>
        /// <param name="createProductDto"></param>
        /// <returns></returns>
        Task<BaseResponse> AddProductAsync(CreateProductDto createProductDto);

        /// <summary>
        /// The method that perform for the product update process
        /// </summary>
        /// <param name="updateProductDto"></param>
        /// <returns></returns>
        Task<BaseResponse> UpdateProductAsync(UpdateProductDto updateProductDto);


        /// <summary>
        /// The method that perform for the product price update process
        /// </summary>
        /// <param name="updateProductPriceDto"></param>
        /// <returns></returns>
        Task<BaseResponse> UpdateProductPriceAsync(UpdateProductPriceDto updateProductPriceDto);

        /// <summary>
        /// The method that perform for the product delete process
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<BaseResponse> DeleteProductAsync(Guid id);


        /// <summary>
        /// The method that perform for the process of pulling all of the products
        /// </summary>
        /// <param name="dynamic"></param>
        /// <returns></returns>
        Task<DataResponse<List<GetProductDto>>> GetListProductAsync(Dynamic? dynamic = null);

        /// <summary>
        /// The method that performs the operation that pulls only one of the products by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<DataResponse<GetProductDto>> GetProductById(Guid id);
    }
}
