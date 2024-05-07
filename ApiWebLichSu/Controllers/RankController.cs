using ApiWebLichSu.Model.DTO;
using ApiWebLichSu.Service.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiWebLichSu.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RankController : ControllerBase
    {
        private readonly IRanking _rank;
        private readonly object _logger;

        public RankController(IRanking rank) 
        { 
            _rank=rank;
        }
        [HttpPost("PostScore")]
        public async Task<IActionResult> PostScore([FromForm]RankVm vm)
        {
            try
            {
                var a=await _rank.AddScore(vm);
                if(a)
                {
                    return Ok("Thành công");
                }
              
            }
            catch (Exception ex) 
            { 
                return BadRequest(ex.Message);
                
            }
            return BadRequest();

        }
        [HttpGet("OrderRank")]
        public async Task<IActionResult> OrderRank()
        {
            try
            {
                var data=await _rank.OrderRank();
                if (data!= null)
                {
                    var data1 = data.Select(e => new RankVM2
                    {
                        score = e.score,
                        LastName = e.LastName,
                    }).ToList();
                    return Ok(data1);
                }
           
            }
            catch (Exception ex) 
            {
                return BadRequest(ex.Message);
            }
            return BadRequest();
        }
    }
}
