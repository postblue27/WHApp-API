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
        public async Task<IActionResult> AddProduct(ProductToAddDto productToAddDto)
        {
            var warehouse = await _warehouserepo.GetWarehouse(productToAddDto.WarehouseId);
            if(warehouse == null)
                return BadRequest("No warehouse by this Id");
            
            if(!await _warehouserepo.ZoneExists(warehouse.WarehouseId, productToAddDto.ZoneId))
                return BadRequest("Provided zone does not exist in this warehouse");
            //здесь добавить проверку на то, осталось ли достаточно места на складе. 
            //Если да - вернуть зону, в котрую пометсить продукт


            var user = await _authrepo.GetUser(productToAddDto.Username, UserTypes.Renter);

            if(user == null)
                return BadRequest("User does not exist");

            var productToCreate = _mapper.Map<Product>(productToAddDto);
            productToCreate.UserId = user.UserId;

            _apprepo.Add(productToCreate);
            if(!await _apprepo.SaveAll())
            {
                return BadRequest("Problem adding product");
            }

            ProductInWarehouse piw = new ProductInWarehouse(warehouse.WarehouseId, productToCreate.ProductId, productToAddDto.ZoneId);
            _apprepo.Add(piw);
            if(await _apprepo.SaveAll())
            {
                return Ok(piw);
            }
            return BadRequest("Problem adding product");
        }
        [HttpGet("{productId}", Name = "GetProduct" )]
        public async Task<IActionResult> GetProduct(int productId)
        {
            var product = await _productrepo.GetProduct(productId);

            if(product == null)
                return BadRequest("Product does not exist");

            return Ok(product);
        }
    }
}