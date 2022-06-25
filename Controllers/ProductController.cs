using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WHApp_API.Dtos;
using WHApp_API.Interfaces;
using WHApp_API.Models;

namespace WHApp_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IAppRepository _apprepo;
        private readonly IProductRepository _productrepo;
        private readonly IWarehouseRepository _warehouserepo;
        private readonly IAuthRepository _authrepo;
        public ProductController(IAppRepository apprepo, IMapper mapper,
            IProductRepository productrepo, IWarehouseRepository warehouserepo,
            IAuthRepository authrepo)
        {
            _mapper = mapper;
            _apprepo = apprepo;
            _productrepo = productrepo;
            _warehouserepo = warehouserepo;
            _authrepo = authrepo;
        }
        [HttpPost("add-product")]
        public async Task<IActionResult> AddProduct(Product product)
        {
            _apprepo.Add(product);
            if(await _apprepo.SaveAll())
            {
                return Ok(product);
            }
            return BadRequest("Problem adding product");
        }
        [HttpGet("get-renter-products/{renterId}")]
        public async Task<IActionResult> GetOwnerWarehouses(int renterId)
        {
            var products = _apprepo.Get<Product>(p => p.RenterId == renterId);
            if(products == null)
                return BadRequest("Renter has no products yet");

            return Ok(products); 
        }
        // [HttpGet("get-products-in-warehouse")]
        // public async Task<IActionResult> GetProductsInWarehouse([FromHeader]int warehouseId)
        // {
        //     var piwList = await _productrepo.GetProductsInWarehouse(warehouseId);

        //     if(piwList == null)
        //         return BadRequest("No products in this warehouse yet");

        //     return Ok(piwList);
        // }
    }
}