using ApiWebLichSu.Model;
using ApiWebLichSu.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace ApiWebLichSu.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountReponse _accountReponse;

        public AccountController(IAccountReponse accountReponse) 
        {
            _accountReponse=accountReponse;
        }
        [HttpPost("SignUp")]
        public async Task<IActionResult>SignUp(SignUp signUp)
        {
            var result= await _accountReponse.SignUpAsync(signUp); 
            if(result.Succeeded)
            {   
                return Ok(result.Succeeded);
            }
            return StatusCode(500);
        }
        [HttpPost("SignUpAdmin")]
        public async Task<IActionResult> SignUpAdmin([FromForm]SignUp signUp)
        {
            var result = await _accountReponse.SignUpAsyncAdmin(signUp);
            if (result.Succeeded)
            {
                return Ok(result.Succeeded);
            }
            return StatusCode(500);
        }
        [HttpPost("SignIn")]
        public async Task<IActionResult>SignIn(SignIn signin)
        {
            var result=await _accountReponse.SignInAsync(signin);
            if(string.IsNullOrEmpty(result))
            {
                return Unauthorized();
            }
            return Ok(result);
        }
        [HttpGet("GetDataUser")]
        public async Task<IActionResult> GetDataUser()
        {
            try
            {
                var resul = await _accountReponse.GetUserAsp();
                return Ok(resul);
            }
            catch(Exception ex) 
            { 
                return BadRequest(ex.Message);
            }
          
        }


    }
}
