using ApiWebLichSu.Data;
using ApiWebLichSu.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using System;
using ApiWebLichSu.Model.DTO;
using ApiWebLichSu.Service.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.Data.SqlClient;

namespace ApiWebLichSu.Service
{
    public class QuestReponse : IQuest
    {
        private readonly MyDbcontext _context;
        private readonly IWebHostEnvironment environment;

        public QuestReponse(MyDbcontext context, IWebHostEnvironment hostingEnvironment)
        {
            _context = context;
            environment = hostingEnvironment;
        }

        public bool AddQuestColl(CollectionVM item)
        {
            try
            {
                var data = new QuestCollection();
                data.Id = item.id;
                data.image_quest = item.image_quest;
                data.title_collection = item.title_collection;
                _context.QuestCollection.Add(data);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public async Task<bool> Addquestion([FromForm] QuestionVM question)
        {
            try
            {
                // Thêm quest vào cơ sở dữ liệu
                var quest = new Quest();
                quest.id_questcollection = question.id_questcollection;
                quest.Id = question.Id_user;
                quest.Question = question.Question;
                _context.Quest.Add(quest);
                await _context.SaveChangesAsync();

                // Thêm answer vào cơ sở dữ liệu
                var ans = new AnswerQuest();
                ans.Id_quest = quest.Id_quest;
                ans.answer = question.answer;
                _context.AnswerQuest.Add(ans);
                await _context.SaveChangesAsync();

                // Lặp qua danh sách các câu hỏi và thêm chúng vào cơ sở dữ liệu
                foreach (var a in question.QuestionList)
                {
                    var listqs = new Question();
                    listqs.Id_quest = quest.Id_quest;
                    listqs.Question_quest = a;
                    listqs.id_Answer = ans.id_Answer;
                    _context.Question.Add(listqs);
                }

                // Lưu tất cả thay đổi vào cơ sở dữ liệu
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                // Log lỗi nếu cần thiết
                return false;
            }

        }

        public async Task< List<QuestCollection>> GetQuestCollecction(string iduser)
        {
            var userParameter = new SqlParameter("@USER", iduser);
            var list = await _context.QuestCollection.FromSqlRaw("EXECUTE GETQUESTID @USER", userParameter).ToListAsync();
            return list;
        }

        public Task GetQuestCollecction()
        {
            throw new NotImplementedException();
        }

        public async Task< List<QuestCollection>> GetQuestCollecctionAdmin()
        {
            try
            {
                return await _context.QuestCollection.FromSqlRaw("EXECUTE SelectAllQuestAdmin").ToListAsync();
            }
            catch (Exception ex)
            { 
               return new List<QuestCollection>();
            }
        }


        public List<QuestVM> GetQuestVM(int idquest)
        {
      
            var listquest = from quest in _context.Quest
                            join answerQuest in _context.AnswerQuest on quest.Id_quest equals answerQuest.Id_quest
                            join question in _context.Question on quest.Id_quest equals question.Id_quest
                            where quest.id_questcollection == idquest
                            group question by new { quest.Id_quest, answerQuest.answer, quest.Question } into grouped
                            select new QuestVM
                            {
                                Id_quest = grouped.Key.Id_quest,
                                answer = grouped.Key.answer,
                                Question = grouped.Key.Question,
                                Questions = grouped.Select(q => q.Question_quest).ToList(),
                            };
            return listquest.ToList();
        }

        public Tuple<int, string> SaveImage(IFormFile imageFile)
        {
            try
            {
                var contentPath = this.environment.ContentRootPath;
                // path = "c://projects/productminiapi/uploads" ,not exactly something like that
                var path = Path.Combine(contentPath, "Uploads");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                // Check the allowed extenstions
                var ext = Path.GetExtension(imageFile.FileName);
                var allowedExtensions = new string[] { ".jpg", ".png", ".jpeg" };
                if (!allowedExtensions.Contains(ext))
                {
                    string msg = string.Format("Only {0} extensions are allowed", string.Join(",", allowedExtensions));
                    return new Tuple<int, string>(0, msg);
                }
                string uniqueString = Guid.NewGuid().ToString();
                // we are trying to create a unique filename here
                var newFileName = uniqueString + ext;
                var fileWithPath = Path.Combine(path, newFileName);
                var stream = new FileStream(fileWithPath, FileMode.Create);
                imageFile.CopyTo(stream);
                stream.Close();
                return new Tuple<int, string>(1, newFileName);
            }
            catch (Exception ex)
            {
                return new Tuple<int, string>(0, "Error has occured");
            }
        }

   
    }
}

    


       
 