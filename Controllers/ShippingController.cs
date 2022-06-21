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
    public class ShippingController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IAppRepository _apprepo;
        private readonly IWarehouseRepository _warehouserepo;
        private readonly IAuthRepository _authrepo;
        private readonly IShippingRepository _shippingrepo;
        private readonly IProductRepository _productrepo;
        public ShippingController(IAppRepository apprepo, IMapper mapper,
            IWarehouseRepository warehouserepo, IAuthRepository authrepo, 
            IShippingRepository shippingrepo, IProductRepository productrepo)
        {
            _mapper = mapper;
            _apprepo = apprepo;
            _warehouserepo = warehouserepo;
            _authrepo = authrepo;
            _shippingrepo = shippingrepo;
            _productrepo = productrepo;
        }
        [HttpPost("add-car")]
        public async Task<IActionResult> AddCar(CarToCreateDto carDto)
        {
            if(!await _apprepo.UserExistsById(carDto.DriverId))
                return BadRequest("User does not exist");
            var car = _mapper.Map<Car>(carDto);

            if(await _shippingrepo.CarExists(car.CarCode))
                return BadRequest("Car with this CarCode already exists");

            _apprepo.Add(car);

            if (await _apprepo.SaveAll()){
                return Ok(car);
            }
            return BadRequest("Problem adding car");
        }
        [HttpGet("get-cars")]
        public async Task<IActionResult> GetCars()
        {
            var cars = await _shippingrepo.GetCars();
            if(cars == null)
                return BadRequest("No cars yet");

            return Ok(cars); 
        }
        [HttpPost("add-to-shipping-list")]
        public async Task<IActionResult> AddProductToShippingList(ProductForShipping productForShipping)
        {
            if(!await _productrepo.ProductInWarehouseExists(productForShipping.ProductInWarehouseId))
                return BadRequest("No such record for product in warehouse");
            
            _apprepo.Add(productForShipping);

            if (await _apprepo.SaveAll()){
                return Ok(productForShipping);
            }
            return BadRequest("Problem adding car");
        }
        // [HttpPost("add-to-shipping")]
        // public async Task<IActionResult> AddToShipping()
    }
}