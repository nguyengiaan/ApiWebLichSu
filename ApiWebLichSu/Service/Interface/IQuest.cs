using ApiWebLichSu.Model;
using ApiWebLichSu.Model.DTO;
using Microsoft.AspNetCore.Mvc;
namespace ApiWebLichSu.Service.Interface
{
    public interface IQuest
    {
        public List<QuestVM> GetQuestVM(int idquest);

        public Tuple<int, string> SaveImage(IFormFile imageFile);

        public bool AddQuestColl(CollectionVM item);

        public Task<List<QuestCollection>> GetQuestCollecction(string iduser);

        public Task<Boolean> Addquestion(QuestionVM question);

        public Task< List<QuestCollection>> GetQuestCollecctionAdmin();
    }
}
