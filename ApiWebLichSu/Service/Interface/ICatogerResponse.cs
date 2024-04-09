using ApiWebLichSu.Model.DTO;

namespace ApiWebLichSu.Service
{
    public interface ICatogerResponse
    {
        public List<CatogeryVM_1> GetCatogeries();
        public List<CatogeryVM> GetCatogeriesid(int id);

        public CatogeryVM Add(CatogeryVM vm);
        public void Delete(int id);
        public void Update(CatogeryVM vm);
    }
}
