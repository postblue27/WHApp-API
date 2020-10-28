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
    public class AppController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IAppRepository _apprepo;
        public AppController(IAppRepository apprepo, IMapper mapper)
        {
            _mapper = mapper;
            _apprepo = apprepo;
        }
        [HttpGet("get-warehouses")]
        public async Task<IActionResult> GetWarehouses()
        {
            var warehouses = await _apprepo.GetWarehouses();
            
            return Ok(warehouses); 
        }
        [HttpPost("add-warehouse")]
        public async Task<IActionResult> AddWarehouse(WarehouseForCreateDto warehouseDto)
        {
            var warehouse = _mapper.Map<Warehouse>(warehouseDto);

            _apprepo.Add(warehouse);

            if (await _apprepo.SaveAll()){
                //return CreatedAtRoute("GetWarehouse", new {id = track.TrackId}, trackForReturn);
                return Ok(warehouse);
            }
            return BadRequest("Problem adding warehouse");
        }
    }
}