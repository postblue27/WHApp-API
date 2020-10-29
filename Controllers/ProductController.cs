using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WHApp_API.Interfaces;

namespace WHApp_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IAppRepository _apprepo;
        private readonly IProductRepository _productrepo;
        public ProductController(IAppRepository apprepo, IMapper mapper,
            IProductRepository productrepo)
        {
            _mapper = mapper;
            _apprepo = apprepo;
            _productrepo = productrepo;
        }
    }
}