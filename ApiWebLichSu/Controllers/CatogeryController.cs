using ApiWebLichSu.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiWebLichSu.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatogeryController : ControllerBase
    {
        private readonly ICatogerResponse _catogery;

        public CatogeryController(ICatogerResponse catogery) 
        {
            _catogery=catogery;
        }

        [HttpGet]
        public IActionResult CatogeryGet()
        { 
            return Ok(_catogery.GetCatogeries());
        }

    }
}
