using ApiWebLichSu.Data;
using ApiWebLichSu.Model.DTO;
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
        private readonly MyDbcontext _context;

        public HistorysController(IHistory history,MyDbcontext context) 
        {
            _history=history;
            _context=context;
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

        [HttpPost("AddHistory")]
        public async Task< IActionResult> AddHistory([FromForm] HistoryVM2 vm)
        {
            try
            {
              var data =await _history.Add(vm);
              if (data)
              {
                return Ok("Thành công");
              }
            }
            catch(Exception ex)
            {
                return BadRequest(ex);
            }
            return BadRequest();
        }
        [HttpGet("GetIdCatogary")]
        public IActionResult GetIdCatogary()
        { 
            try
            {
                var data = _context.Catogery.ToList();
                return Ok(data);
            }catch(Exception ex) 
            {
                return BadRequest(ex);
            }
        }
        [HttpDelete("Deletehis")]
        public async Task<IActionResult> DeleteHistory(int id) 
        {
            try
            {
                var dele = await _history.Delete(id);
                if (dele)
                {
                    return Ok("Thành công");
                }
            }
            catch(Exception ex)
            {
                return NotFound(ex);
            }
            return NotFound();
   
        }
        [HttpPut("Update")]
        public async Task<IActionResult> UpdateHistory(int id, [FromForm] HistoryVM2 vm2)
        {
            try
            {
             var a=  await _history.Update(vm2, id);
              if (a==true)
              {
                    return Ok("Cập nhật thành công"); 
              }


            }
            catch (Exception ex)
            {
                return NotFound();
            }
            return NotFound();
        }

    }
}
