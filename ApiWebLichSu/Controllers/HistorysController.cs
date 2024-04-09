using ApiWebLichSu.Service.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiWebLichSu.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HistorysController : ControllerBase
    {
        private readonly IHistory _history;
        public HistorysController(IHistory history) 
        {
            _history=history;
        }    
        [HttpGet]
        public IActionResult GetAll() 
        {
            try
            {
                return Ok(_history.GetAll());
            }catch
            {
                return NotFound();
            }
        }
        [HttpGet("baivietlichsu")]
        public IActionResult Getbyid(int id)
        {
            try
            {
                return Ok(_history.GetbyId(id));
            }
            catch { return NotFound(); }
        }
    }
}
