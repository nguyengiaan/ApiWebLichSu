using ApiWebLichSu.Model;
using ApiWebLichSu.Model.DTO;
using ApiWebLichSu.Service.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ApiWebLichSu.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestController : ControllerBase
    {
        private readonly IQuest _quest;

        public QuestController(IQuest quest)
        {
            _quest=quest;
        }
        [HttpGet("Quest")]
        public IActionResult GetQuest(int questid) 
        {
           var list= _quest.GetQuestVM(questid);
            return Ok(list);
        }
        [HttpPost("UploadGetcollection")]
        public  async Task<IActionResult> PostQuest([FromForm] CollectionVM model) 
        {
            var status = new Status();
            if (!ModelState.IsValid)
            {
                status.StatusCode = 0;
                status.Message = "Please pass the valid data";
                return Ok(status);
            }
            if (model.file != null)
            {

                var fileResult = _quest.SaveImage(model.file);
                if ( fileResult.Item1 ==1)
                {
                    model.image_quest = fileResult.Item2;
                }
                var productResult = _quest.AddQuestColl(model);
        
                if (productResult)
                {
                    status.StatusCode = 1;
                    status.Message = "Added successfully";
                }
                else
                {
                    status.StatusCode = 0;
                    status.Message = "Error on adding product";

                }
            }
            return Ok(status);

        }
        [HttpGet("GetCollection")]
        public async Task<IActionResult> GetCollection(string iduser)
        {
            try
            {
             var list=await _quest.GetQuestCollecction(iduser);
                return Ok(list);
            }catch (Exception ex)
            
            { 
                return BadRequest(ex.Message);
            }
       
        }
        [HttpGet("GetCollectionAdmin")]
        public  async Task< IActionResult> GetCollectionAdmin()
        {
            try
            {
                var list = await _quest.GetQuestCollecctionAdmin();
                return Ok(list);
            }
            catch (Exception ex)

            {
                return BadRequest(ex.Message);
            }

        }
        [HttpGet("GetCollectionUser")]
        public async Task<IActionResult> GetCollectionAdmin(string iduser)
        {
            try
            {
                var list = await _quest.GetQuestCollecctionuser(iduser);
                return Ok(list);
            }
            catch (Exception ex)

            {
                return BadRequest(ex.Message);
            }

        }
        [HttpPost("Themcauhoi")]
        public async Task<IActionResult> Themcauhoi(QuestionVM questionVM)
        {
           
                var list = await _quest.Addquestion(questionVM);
                if (list)
                {
                    return Ok("đã thành công");
                }
                else
                {
                    return BadRequest();
                }
                
        }
        [HttpGet("GetCollectionAll")]
        public async Task<IActionResult> GetCollectionAll()
        {
            var list = await _quest.GetQuestCollecctionAll();
            if (list !=null)
            {
                return Ok(list);
            }
            else
            {
                return BadRequest();
            }
        }
    }


}
