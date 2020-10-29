using System.Collections.Generic;
using System.Text.Json.Serialization;
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
    public class WarehouseController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IAppRepository _apprepo;
        private readonly IWarehouseRepository _warehouserepo;
        private readonly IAuthRepository _authrepo;
        public WarehouseController(IAppRepository apprepo, IMapper mapper,
            IWarehouseRepository warehouserepo, IAuthRepository authrepo)
        {
            _mapper = mapper;
            _apprepo = apprepo;
            _warehouserepo = warehouserepo;
            _authrepo = authrepo;
        }
        [HttpGet("get-warehouses")]
        public async Task<IActionResult> GetWarehouses()
        {
            var warehouses = await _warehouserepo.GetWarehouses();
            if(warehouses == null)
                return BadRequest("No warehouses yet");

            return Ok(warehouses); 
        }
        
        [HttpGet("{warehouseId}")]
        public async Task<IActionResult> GetWarehouse(int warehouseId)
        {
            var warehouse = await _warehouserepo.GetWarehouse(warehouseId);

            if(warehouse == null)
                return BadRequest("No warehouse by this Id");
            return Ok(warehouse);
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
        [HttpPost("rent-warehouse")]
        public async Task<IActionResult> RentWarehouse(RenterWarehouse renterWarehouse)
        {
            var ifExists = await _apprepo.UserExistsById(renterWarehouse.UserId, "Renter");
            // return Ok(ifExists);
            if(!await _apprepo.UserExistsById(renterWarehouse.UserId, UserTypes.Renter))
                return BadRequest("User does not exist");
            _apprepo.Add(renterWarehouse);
            if (await _apprepo.SaveAll()){
                var created = await _warehouserepo.GetRenterWarehouse(renterWarehouse.UserId, renterWarehouse.WarehouseId);
                return Ok(created);
            }
            return BadRequest("Problem renting warehouse");
        }
        [HttpPost("add-zones")]
        public async Task<IActionResult> AddZones([FromHeader]int warehouseId, [FromBody]ZonesToCreateDto zones)
        {
            var warehouse = await _warehouserepo.GetWarehouse(warehouseId);

            if(warehouse == null)
                return BadRequest("No warehouse by this Id");
            
            foreach(Zone z in zones.Zones)
            {
                z.WarehouseId = warehouse.WarehouseId;
                _apprepo.Add(z);
            }
            if(await _apprepo.SaveAll())
            {
                return Ok((await _warehouserepo.GetWarehouse(warehouseId)));
            }
            return BadRequest("Problem adding zones to warehouse with id " + warehouse.WarehouseId);
        }
        [HttpGet("get-zones")]
        public async Task<IActionResult> GetWarehouseZones([FromHeader]int warehouseId)
        {
            var warehouse = await _warehouserepo.GetWarehouseWithZones(warehouseId);

            if(warehouse == null)
                return BadRequest("No zones for warehouse by this Id");
            return Ok(warehouse.Zones);
        }
    }
}